#region Using declarations
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Windows.Media;
using NinjaTrader.Cbi;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;
using NinjaTrader.NinjaScript;
using NinjaTrader.NinjaScript.DrawingTools;
using NinjaTrader.NinjaScript.Indicators;
#endregion

namespace NinjaTrader.NinjaScript.Indicators
{
	public class MFSScalpIndicator : Indicator
	{
		#region Variables
		// ===== CONTEXTOS: PENSAR COMO FPLEME =====
		// Estado del mercado (últimas 30 barras)
		private enum MarketState
		{
			Consolidating,  // Lateral, sin dirección clara
			Breaking,       // Rompiendo estructura (INICIO de ciclo)
			Trending,       // En movimiento direccional (MEDIO)
			Exhausted       // Sobreextendido (FIN de ciclo)
		}
		private MarketState currentMarketState = MarketState.Consolidating;
		
		// Calidad del setup (últimas 20 barras)
		private enum SetupQuality
		{
			Poor,       // No hay setup claro
			Forming,    // Setup formándose
			Ready,      // Setup listo para entrar
			Missed      // Ya pasó la oportunidad
		}
		private SetupQuality currentSetupQuality = SetupQuality.Poor;
		
		// Dirección dominante (últimas 50 barras)
		private enum DominantFlow
		{
			Bullish,    // Estructura alcista dominante
			Bearish,    // Estructura bajista dominante
			Neutral     // Sin dirección clara
		}
		private DominantFlow currentFlow = DominantFlow.Neutral;
		
		// Historial de contexto
		private List<double> priceHistory;
		private List<double> atrHistory;
		private List<int> mapHistory;
		private const int CONTEXT_BARS_SHORT = 15;   // Momentum reciente
		private const int CONTEXT_BARS_MEDIUM = 30;  // Estructura corto plazo
		private const int CONTEXT_BARS_LONG = 50;    // Dirección dominante
		
		// MAP tracking
		private int lastMapIndex = 0;
		private int cycleRefMapIndex = 0;
		private int cycle2MapIndex = 0;
		private bool cycleRefValid = false;
		private bool cycle2Valid = false;
		private int cycleDirection = 0; // 1=alcista, -1=bajista
		
		// Swing tracking (Renko)
		private double lastSwingHigh = double.NaN;
		private double lastSwingLow = double.NaN;
		private int lastSwingHighBar = -1;
		private int lastSwingLowBar = -1;
		private List<double> swingHighs;
		private List<double> swingLows;
		
		// SHARK (confirmador de ciclo - FPLEME philosophy)
		private double sharkRaw = 0;
		private double sharkEma1 = 0;
		private double sharkEma2 = 0;
		private double sharkValue = 0;
		private int sharkState = 0; // 1=bullish, -1=bearish, 0=neutral
		private List<double> sharkHistory;
		private const int SHARK_CLOSE_OFFSET = 5;
		private const double SHARK_EMA1_ALPHA = 2.0 / 6.0; // EMA(5)
		private const double SHARK_EMA2_ALPHA = 2.0 / 3.0; // EMA(2)
		private const double SHARK_MULTIPLIER = 1.877;
		private const int SHARK_NORM_PERIOD = 500;
		
		// Signal state
		private bool signalArmed = false;
		private int signalDirection = 0;
		private int signalArmedBar = -1;
		private int signalArmedMapIndex = 0;
		
		// Trade tracking
		private int totalTrades = 0;
		private int wins = 0;
		private int losses = 0;
		private bool inTrade = false;
		private double entryPrice = 0;
		private int tradeDirection = 0;
		private int entryBar = -1;
		private int lastExitBar = -1;
		
		// PnL tracking (REAL)
		private double totalPnLTicks = 0;
		private double totalWinTicks = 0;
		private double totalLossTicks = 0;
		private double totalPnLPoints = 0;
		private const double TICKS_PER_POINT = 4.0; // NQ: 4 ticks = 1 punto
		
		// Parameters
		private int tpTicks = 40;
		private int slTicks = 40;
		private bool enableSharkFilter = true;
		
		// Logging
		private StreamWriter logWriter;
		private string logPath;
		private bool logEnabled = true;
		#endregion
		
		protected override void OnStateChange()
		{
			if (State == State.SetDefaults)
			{
				Description = "MFS Scalp - Minimalista para NQ";
				Name = "MFSScalp";
				Calculate = Calculate.OnBarClose;
				IsOverlay = true;
				DisplayInDataBox = true;
				DrawOnPricePanel = true;
				ScaleJustification = ScaleJustification.Right;
				IsSuspendedWhileInactive = true;
				
				TpTicks = 40;
				SlTicks = 40;
			}
			else if (State == State.Configure)
			{
			}
			else if (State == State.DataLoaded)
			{
				sharkHistory = new List<double>();
				priceHistory = new List<double>();
				atrHistory = new List<double>();
				mapHistory = new List<int>();
				swingHighs = new List<double>();
				swingLows = new List<double>();
				InitializeLog();
			}
			else if (State == State.Terminated)
			{
				CloseLog();
			}
		}
		
		protected override void OnBarUpdate()
		{
			if (CurrentBar < CONTEXT_BARS_LONG)
				return;
			
			// === FASE 1: ACTUALIZAR HISTORIAL (memoria del mercado) ===
			UpdateHistory();
			
			// === FASE 2: LEER CONTEXTOS (pensar como FPLEME) ===
			AnalyzeMarketState();      // ¿Consolidación, ruptura, tendencia o agotamiento?
			AnalyzeDominantFlow();     // ¿Dirección dominante en últimas 50 barras?
			AnalyzeSetupQuality();     // ¿Setup listo, formándose o perdido?
			
			// === FASE 3: INDICADORES TÉCNICOS ===
			UpdateShark();             // Confirmador de ciclo
			DetectRenkoSwings();       // Swings Renko
			UpdateCycles();            // Ciclos MAP
			
			// === FASE 4: DECISIÓN DE ENTRADA (solo si contexto favorable) ===
			DetectSignals();
			
			// === FASE 5: GESTIÓN DE TRADES ===
			ManageTrades();
			
			// === FASE 6: VISUALIZACIÓN ===
			DrawPanel();
		}
		
		// ========================================
		// MÉTODOS DE CONTEXTO: PENSAR COMO FPLEME
		// ========================================
		
		private void UpdateHistory()
		{
			// Guardar historial de precio, ATR y MAP para análisis de contexto
			double midPrice = (High[0] + Low[0]) / 2;
			double atr = ATR(14)[0];
			double sma20 = SMA(20)[0];
			
			priceHistory.Add(midPrice);
			if (priceHistory.Count > CONTEXT_BARS_LONG)
				priceHistory.RemoveAt(0);
			
			atrHistory.Add(atr);
			if (atrHistory.Count > CONTEXT_BARS_LONG)
				atrHistory.RemoveAt(0);
			
			// Calcular MAP actual
			int currentMap = 0;
			if (atr > 0)
				currentMap = (int)Math.Round((midPrice - sma20) / atr);
			
			mapHistory.Add(currentMap);
			if (mapHistory.Count > CONTEXT_BARS_LONG)
				mapHistory.RemoveAt(0);
		}
		
		private void AnalyzeMarketState()
		{
			// CONTEXTO 1: ¿En qué FASE está el mercado?
			// Información para LOG, NO para bloquear (solo Exhausted bloquea)
			
			if (atrHistory.Count < CONTEXT_BARS_MEDIUM || mapHistory.Count < CONTEXT_BARS_MEDIUM)
			{
				currentMarketState = MarketState.Consolidating;
				return;
			}
			
			// Detectar EXTENSIÓN actual
			int currentMapAbs = Math.Abs(lastMapIndex);
			
			// SOLO detectar AGOTAMIENTO (extremos peligrosos)
			// Todo lo demás es operarable
			if (currentMapAbs > 5) // Precio MUY lejos (>5 MAPs)
			{
				currentMarketState = MarketState.Exhausted;
				return;
			}
			
			// Detectar consolidación
			int barsNearSma = 0;
			for (int i = Math.Max(0, mapHistory.Count - 20); i < mapHistory.Count; i++)
			{
				if (Math.Abs(mapHistory[i]) <= 1)
					barsNearSma++;
			}
			double consolidationRatio = (double)barsNearSma / 20.0;
			
			// Detectar aceleración ATR
			double recentAtr = 0;
			double olderAtr = 0;
			
			for (int i = Math.Max(0, atrHistory.Count - 10); i < atrHistory.Count; i++)
				recentAtr += atrHistory[i];
			recentAtr /= 10.0;
			
			for (int i = Math.Max(0, atrHistory.Count - 30); i < Math.Max(0, atrHistory.Count - 10); i++)
				olderAtr += atrHistory[i];
			olderAtr /= 20.0;
			
			double atrAcceleration = (olderAtr > 0) ? (recentAtr / olderAtr) : 1.0;
			
			// Estados informativos (NO bloquean)
			if (consolidationRatio > 0.6)
			{
				currentMarketState = MarketState.Consolidating;
			}
			else if (atrAcceleration > 1.2 && currentMapAbs <= 3)
			{
				currentMarketState = MarketState.Breaking;
			}
			else
			{
				currentMarketState = MarketState.Trending;
			}
		}
		
		private void AnalyzeDominantFlow()
		{
			// CONTEXTO 2: ¿Cuál es la DIRECCIÓN DOMINANTE en últimas 50 barras?
			// Esto es como FPLEME lee la "estructura macro"
			
			if (mapHistory.Count < CONTEXT_BARS_LONG)
			{
				currentFlow = DominantFlow.Neutral;
				return;
			}
			
			// Contar swings alcistas vs bajistas
			int bullishSwings = 0;
			int bearishSwings = 0;
			
			// Analizar progresión de MAPs
			int mapsUp = 0;
			int mapsDown = 0;
			
			for (int i = Math.Max(1, mapHistory.Count - CONTEXT_BARS_LONG); i < mapHistory.Count; i++)
			{
				int mapDelta = mapHistory[i] - mapHistory[i - 1];
				if (mapDelta > 0) mapsUp++;
				else if (mapDelta < 0) mapsDown++;
			}
			
			// Analizar swings confirmados (últimas 10 entradas)
			int recentSwings = Math.Min(10, swingHighs.Count);
			for (int i = Math.Max(0, swingLows.Count - recentSwings); i < swingLows.Count; i++)
			{
				if (i > 0 && swingLows[i] > swingLows[i - 1])
					bullishSwings++; // Higher lows
			}
			
			recentSwings = Math.Min(10, swingHighs.Count);
			for (int i = Math.Max(0, swingHighs.Count - recentSwings); i < swingHighs.Count; i++)
			{
				if (i > 0 && swingHighs[i] < swingHighs[i - 1])
					bearishSwings++; // Lower highs
			}
			
			// DECISIÓN: Dominancia (balanceado)
			double bullScore = mapsUp + (bullishSwings * 4); // Swings pesan x4
			double bearScore = mapsDown + (bearishSwings * 4);
			
			if (bullScore > bearScore * 1.4) // 40% más alcista
				currentFlow = DominantFlow.Bullish;
			else if (bearScore > bullScore * 1.4) // 40% más bajista
				currentFlow = DominantFlow.Bearish;
			else
				currentFlow = DominantFlow.Neutral;
		}
		
		private void AnalyzeSetupQuality()
		{
			// CONTEXTO 3: Calidad del setup (SOLO INFORMATIVO, no bloquea)
			// Se usa para logging y panel, NO para filtrar entradas
			
			if (mapHistory.Count < CONTEXT_BARS_MEDIUM)
			{
				currentSetupQuality = SetupQuality.Poor;
				return;
			}
			
			int currentMapAbs = Math.Abs(lastMapIndex);
			
			// SOLO clasificar, NO filtrar
			if (currentMarketState == MarketState.Exhausted)
			{
				currentSetupQuality = SetupQuality.Missed;
			}
			else if (currentMarketState == MarketState.Breaking)
			{
				currentSetupQuality = SetupQuality.Ready;
			}
			else if (currentMarketState == MarketState.Consolidating)
			{
				currentSetupQuality = SetupQuality.Forming;
			}
			else
			{
				// Trending = ya en movimiento
				currentSetupQuality = currentMapAbs <= 3 ? SetupQuality.Ready : SetupQuality.Forming;
			}
		}
		
		// ========================================
		// INDICADORES TÉCNICOS
		// ========================================
		
		private void UpdateShark()
		{
			// SHARK: Confirmador de ciclo basado en constantes FPLEME
			// Formula: (Close[0] - Close[5]) → EMA(5) → EMA(2) → × 1.877 → NORMALIZAR [-12, +12]
			
			int offset = Math.Min(SHARK_CLOSE_OFFSET, CurrentBar);
			sharkRaw = Close[0] - Close[offset];
			
			// EMA(5) - primera suavización
			if (CurrentBar == 0)
			{
				sharkEma1 = sharkRaw;
			}
			else
			{
				sharkEma1 = SHARK_EMA1_ALPHA * sharkRaw + (1 - SHARK_EMA1_ALPHA) * sharkEma1;
			}
			
			// EMA(2) - segunda suavización
			if (CurrentBar == 0)
			{
				sharkEma2 = sharkEma1;
			}
			else
			{
				sharkEma2 = SHARK_EMA2_ALPHA * sharkEma1 + (1 - SHARK_EMA2_ALPHA) * sharkEma2;
			}
			
			// Aplicar multiplicador FPLEME
			double sharkRawValue = sharkEma2 * SHARK_MULTIPLIER;
			
			// Guardar historial para normalización
			sharkHistory.Add(sharkRawValue);
			if (sharkHistory.Count > SHARK_NORM_PERIOD)
				sharkHistory.RemoveAt(0);
			
			// NORMALIZACIÓN FPLEME: [-12, +12] basado en min/max de últimos 500 valores
			if (sharkHistory.Count >= 20) // Mínimo para normalizar
			{
				double minShark = double.MaxValue;
				double maxShark = double.MinValue;
				
				foreach (double val in sharkHistory)
				{
					if (val < minShark) minShark = val;
					if (val > maxShark) maxShark = val;
				}
				
				double range = maxShark - minShark;
				if (range > 0.0001)
				{
					// Normalizar a [-12, +12]
					sharkValue = ((sharkRawValue - minShark) / range) * 24.0 - 12.0;
					
					// Clamp
					if (sharkValue > 12.0) sharkValue = 12.0;
					if (sharkValue < -12.0) sharkValue = -12.0;
				}
				else
				{
					sharkValue = 0;
				}
			}
			else
			{
				sharkValue = 0; // No hay suficiente historial
			}
			
			// Estado del SHARK: Umbrales FPLEME (±4 = cambio de ciclo)
			// SHARK > +4 = ciclo comprador fuerte
			// SHARK < -4 = ciclo vendedor fuerte
			if (sharkValue > 4.0)
				sharkState = 1;  // BULL
			else if (sharkValue < -4.0)
				sharkState = -1; // BEAR
			else
				sharkState = 0;  // NEUTRAL
		}
		
		private void DetectRenkoSwings()
		{
			// Swing High: barra actual es menor que la anterior (Renko bajó)
			if (CurrentBar > 0 && High[0] < High[1])
			{
				lastSwingHigh = High[1];
				lastSwingHighBar = CurrentBar - 1;
				
				// Guardar en historial
				swingHighs.Add(lastSwingHigh);
				if (swingHighs.Count > 20) swingHighs.RemoveAt(0);
			}
			
			// Swing Low: barra actual es mayor que la anterior (Renko subió)
			if (CurrentBar > 0 && Low[0] > Low[1])
			{
				lastSwingLow = Low[1];
				lastSwingLowBar = CurrentBar - 1;
				
				// Guardar en historial
				swingLows.Add(lastSwingLow);
				if (swingLows.Count > 20) swingLows.RemoveAt(0);
			}
		}
		
		private void UpdateCycles()
		{
			// Calcular MAP index simple (basado en distancia desde precio medio)
			double midPrice = (High[0] + Low[0]) / 2;
			double sma20 = SMA(20)[0];
			double atr = ATR(14)[0];
			
			if (atr <= 0)
				return;
			
			// MAP index: cuántas ATRs está el precio del SMA
			int currentMapIndex = (int)Math.Round((midPrice - sma20) / atr);
			lastMapIndex = currentMapIndex;
			
			// Detectar nuevo swing high
			if (lastSwingHighBar == CurrentBar - 1)
			{
				if (!cycleRefValid)
				{
					// Primer swing: establecer CycleRef
					cycleRefValid = true;
					cycleRefMapIndex = currentMapIndex;
					cycle2Valid = false;
					cycleDirection = -1; // Bajista
				}
				else if (cycleDirection < 0 && !cycle2Valid)
				{
					// Segundo swing bajista: establecer Cycle2
					cycle2Valid = true;
					cycle2MapIndex = currentMapIndex;
				}
				else if (cycleDirection > 0 && cycle2Valid)
				{
					// Swing opuesto: reiniciar ciclo
					cycleRefValid = true;
					cycleRefMapIndex = currentMapIndex;
					cycle2Valid = false;
					cycleDirection = -1;
				}
			}
			
			// Detectar nuevo swing low
			if (lastSwingLowBar == CurrentBar - 1)
			{
				if (!cycleRefValid)
				{
					// Primer swing: establecer CycleRef
					cycleRefValid = true;
					cycleRefMapIndex = currentMapIndex;
					cycle2Valid = false;
					cycleDirection = 1; // Alcista
				}
				else if (cycleDirection > 0 && !cycle2Valid)
				{
					// Segundo swing alcista: establecer Cycle2
					cycle2Valid = true;
					cycle2MapIndex = currentMapIndex;
				}
				else if (cycleDirection < 0 && cycle2Valid)
				{
					// Swing opuesto: reiniciar ciclo
					cycleRefValid = true;
					cycleRefMapIndex = currentMapIndex;
					cycle2Valid = false;
					cycleDirection = 1;
				}
			}
		}
		
		private void DetectSignals()
		{
			// ===== LEER EL FLUJO: PENSAR COMO FPLEME =====
			// FPLEME lee ciclos, no espera perfección
			
			// FILTRO 1: ¿Ya en trade?
			if (inTrade)
				return;
			
			// FILTRO 2: ¿Ciclos detectados?
			if (!cycleRefValid || !cycle2Valid)
				return;
			
			// FILTRO 3: ¿Escenario válido? (PPM o MM)
			bool isPPM = (cycleDirection > 0 && cycle2MapIndex > cycleRefMapIndex) ||
			             (cycleDirection < 0 && cycle2MapIndex < cycleRefMapIndex);
			bool isMM = cycle2MapIndex == cycleRefMapIndex;
			
			if (!isPPM && !isMM)
				return;
			
			// FILTRO 4: ¿SHARK confirma el ciclo?
			if (enableSharkFilter)
			{
				if (cycleDirection > 0 && sharkState <= 0)
					return; // Ciclo alcista requiere SHARK alcista
				if (cycleDirection < 0 && sharkState >= 0)
					return; // Ciclo bajista requiere SHARK bajista
			}
			
			// FILTRO 5: ¿Flujo macro alineado? (contexto de 50 barras)
			// NO entrar contra dirección dominante
			if (currentFlow == DominantFlow.Bullish && cycleDirection < 0)
				return; // NO short si flujo alcista
			if (currentFlow == DominantFlow.Bearish && cycleDirection > 0)
				return; // NO long si flujo bajista
			
			// FILTRO 6: ¿Mercado agotado? (solo bloquear extremos)
			if (currentMarketState == MarketState.Exhausted)
				return; // NO entrar si precio muy lejos (>4 MAPs)
			
			// FILTRO 7: ¿Cooldown tras última salida?
			if (CurrentBar - lastExitBar < 3) // Reducido de 5 a 3
				return; // Esperar 3 barras tras salida
			
			// ===== DETECCIÓN DE CICLO (como FPLEME) =====
			
			// Detectar movimiento en MAPs
			int mapMovement = lastMapIndex - cycleRefMapIndex;
			
			// ARMAR SEÑAL: Precio se movió en dirección del ciclo
			if (!signalArmed)
			{
				// LONG: ciclo alcista + precio subió al menos 1 MAP
				if (cycleDirection > 0 && mapMovement >= 1)
				{
					signalArmed = true;
					signalDirection = 1;
					signalArmedBar = CurrentBar;
					signalArmedMapIndex = lastMapIndex;
				}
				
				// SHORT: ciclo bajista + precio bajó al menos 1 MAP
				if (cycleDirection < 0 && mapMovement <= -1)
				{
					signalArmed = true;
					signalDirection = -1;
					signalArmedBar = CurrentBar;
					signalArmedMapIndex = lastMapIndex;
				}
			}
			
			// CONFIRMAR SEÑAL: Swing en dirección del ciclo
			if (signalArmed && CurrentBar > signalArmedBar)
			{
				bool confirm = false;
				
				// LONG: confirmar con swing low (precio retoma alcista)
				if (signalDirection > 0 && lastSwingLowBar == CurrentBar - 1)
					confirm = true;
				
				// SHORT: confirmar con swing high (precio retoma bajista)
				if (signalDirection < 0 && lastSwingHighBar == CurrentBar - 1)
					confirm = true;
				
				if (confirm)
				{
					// ✅ ENTRAR: Ciclo detectado y confirmado
					totalTrades++;
					inTrade = true;
					entryPrice = Close[0];
					tradeDirection = signalDirection;
					entryBar = CurrentBar;
					
					// Log entrada
					string currentScenario = GetScenario();
					LogTrade("ENTRY", tradeDirection > 0 ? "LONG" : "SHORT", entryPrice, 
						currentScenario, lastMapIndex, cycleDirection);
					
					// Dibujar señal
					string tag = "Signal_" + CurrentBar;
					if (tradeDirection > 0)
					{
						Draw.ArrowUp(this, tag, false, 0, Low[0] - 2 * TickSize, Brushes.Lime);
					}
					else
					{
						Draw.ArrowDown(this, tag, false, 0, High[0] + 2 * TickSize, Brushes.Red);
					}
					
					// Reset armed
					signalArmed = false;
					signalDirection = 0;
				}
			}
		}
		
		private void ManageTrades()
		{
			if (!inTrade)
				return;
			
			// NO evaluar TP/SL en la misma barra de entrada
			// En OnBarClose, necesitamos esperar a la siguiente barra
			if (CurrentBar == entryBar)
				return;
			
			double tpDistance = tpTicks * TickSize;
			double slDistance = slTicks * TickSize;
			
			if (tradeDirection > 0)
			{
				// LONG
				double tp = entryPrice + tpDistance;
				double sl = entryPrice - slDistance;
				
				// En RENKO con OnBarClose:
				// - High[0] = máximo de la barra ya cerrada
				// - Low[0] = mínimo de la barra ya cerrada
				// Evaluar qué nivel está MÁS CERCA del entry para determinar qué se alcanzó primero
				
				bool tpReached = High[0] >= tp;
				bool slReached = Low[0] <= sl;
				
				if (tpReached && slReached)
				{
					// Ambos alcanzados en la misma barra Renko
					// Determinar cuál está más cerca del entry (se alcanzó primero)
					double distanceToTp = Math.Abs(tp - entryPrice);
					double distanceToSl = Math.Abs(entryPrice - sl);
					
					if (distanceToTp < distanceToSl)
					{
						// TP más cerca = se alcanzó primero
						wins++;
						double pnlTicks = (tp - entryPrice) / TickSize;
						totalPnLTicks += pnlTicks;
						totalWinTicks += pnlTicks;
						totalPnLPoints = totalPnLTicks / TICKS_PER_POINT;
						LogTrade("EXIT", "WIN", tp, "", lastMapIndex, cycleDirection, pnlTicks, CurrentBar - entryBar);
						inTrade = false;
						lastExitBar = CurrentBar;
						Draw.Text(this, "TP_" + CurrentBar, "TP", 0, High[0] + 2 * TickSize, Brushes.Lime);
					}
					else
					{
						// SL más cerca = se alcanzó primero
						losses++;
						double pnlTicks = (sl - entryPrice) / TickSize;
						totalPnLTicks += pnlTicks;
						totalLossTicks += Math.Abs(pnlTicks);
						totalPnLPoints = totalPnLTicks / TICKS_PER_POINT;
						LogTrade("EXIT", "LOSS", sl, "", lastMapIndex, cycleDirection, pnlTicks, CurrentBar - entryBar);
						inTrade = false;
						lastExitBar = CurrentBar;
						Draw.Text(this, "SL_" + CurrentBar, "SL", 0, Low[0] - 2 * TickSize, Brushes.Red);
					}
				}
				else if (tpReached)
				{
					// Solo TP alcanzado
					wins++;
					double pnlTicks = (tp - entryPrice) / TickSize;
					totalPnLTicks += pnlTicks;
					totalWinTicks += pnlTicks;
					totalPnLPoints = totalPnLTicks / TICKS_PER_POINT;
					LogTrade("EXIT", "WIN", tp, "", lastMapIndex, cycleDirection, pnlTicks, CurrentBar - entryBar);
					inTrade = false;
					lastExitBar = CurrentBar;
					Draw.Text(this, "TP_" + CurrentBar, "TP", 0, High[0] + 2 * TickSize, Brushes.Lime);
				}
				else if (slReached)
				{
					// Solo SL alcanzado
					losses++;
					double pnlTicks = (sl - entryPrice) / TickSize;
					totalPnLTicks += pnlTicks;
					totalLossTicks += Math.Abs(pnlTicks);
					totalPnLPoints = totalPnLTicks / TICKS_PER_POINT;
					LogTrade("EXIT", "LOSS", sl, "", lastMapIndex, cycleDirection, pnlTicks, CurrentBar - entryBar);
					inTrade = false;
					lastExitBar = CurrentBar;
					Draw.Text(this, "SL_" + CurrentBar, "SL", 0, Low[0] - 2 * TickSize, Brushes.Red);
				}
			}
			else
			{
				// SHORT
				double tp = entryPrice - tpDistance;
				double sl = entryPrice + slDistance;
				
				bool tpReached = Low[0] <= tp;
				bool slReached = High[0] >= sl;
				
				if (tpReached && slReached)
				{
					// Ambos alcanzados en la misma barra Renko
					double distanceToTp = Math.Abs(entryPrice - tp);
					double distanceToSl = Math.Abs(sl - entryPrice);
					
					if (distanceToTp < distanceToSl)
					{
						// TP más cerca = se alcanzó primero
						wins++;
						double pnlTicks = (entryPrice - tp) / TickSize;
						totalPnLTicks += pnlTicks;
						totalWinTicks += pnlTicks;
						totalPnLPoints = totalPnLTicks / TICKS_PER_POINT;
						LogTrade("EXIT", "WIN", tp, "", lastMapIndex, cycleDirection, pnlTicks, CurrentBar - entryBar);
						inTrade = false;
						lastExitBar = CurrentBar;
						Draw.Text(this, "TP_" + CurrentBar, "TP", 0, Low[0] - 2 * TickSize, Brushes.Lime);
					}
					else
					{
						// SL más cerca = se alcanzó primero
						losses++;
						double pnlTicks = (entryPrice - sl) / TickSize;
						totalPnLTicks += pnlTicks;
						totalLossTicks += Math.Abs(pnlTicks);
						totalPnLPoints = totalPnLTicks / TICKS_PER_POINT;
						LogTrade("EXIT", "LOSS", sl, "", lastMapIndex, cycleDirection, pnlTicks, CurrentBar - entryBar);
						inTrade = false;
						lastExitBar = CurrentBar;
						Draw.Text(this, "SL_" + CurrentBar, "SL", 0, High[0] + 2 * TickSize, Brushes.Red);
					}
				}
				else if (tpReached)
				{
					// Solo TP alcanzado
					wins++;
					double pnlTicks = (entryPrice - tp) / TickSize;
					totalPnLTicks += pnlTicks;
					totalWinTicks += pnlTicks;
					totalPnLPoints = totalPnLTicks / TICKS_PER_POINT;
					LogTrade("EXIT", "WIN", tp, "", lastMapIndex, cycleDirection, pnlTicks, CurrentBar - entryBar);
					inTrade = false;
					lastExitBar = CurrentBar;
					Draw.Text(this, "TP_" + CurrentBar, "TP", 0, Low[0] - 2 * TickSize, Brushes.Lime);
				}
				else if (slReached)
				{
					// Solo SL alcanzado
					losses++;
					double pnlTicks = (entryPrice - sl) / TickSize;
					totalPnLTicks += pnlTicks;
					totalLossTicks += Math.Abs(pnlTicks);
					totalPnLPoints = totalPnLTicks / TICKS_PER_POINT;
					LogTrade("EXIT", "LOSS", sl, "", lastMapIndex, cycleDirection, pnlTicks, CurrentBar - entryBar);
					inTrade = false;
					lastExitBar = CurrentBar;
					Draw.Text(this, "SL_" + CurrentBar, "SL", 0, High[0] + 2 * TickSize, Brushes.Red);
				}
			}
		}
		
		private string GetScenario()
		{
			if (!cycleRefValid || !cycle2Valid)
				return "None";
			
			bool isPPM = (cycleDirection > 0 && cycle2MapIndex > cycleRefMapIndex) ||
			             (cycleDirection < 0 && cycle2MapIndex < cycleRefMapIndex);
			bool isMM = cycle2MapIndex == cycleRefMapIndex;
			
			if (isPPM) return "PPM";
			if (isMM) return "MM";
			return "None";
		}
		
		private void DrawPanel()
		{
			// Calculos REALES
			double wr = totalTrades > 0 ? (double)wins / totalTrades * 100 : 0;
			double avgPnLTicks = totalTrades > 0 ? totalPnLTicks / totalTrades : 0;
			double avgPnLPoints = totalTrades > 0 ? totalPnLPoints / totalTrades : 0;
			double avgWinTicks = wins > 0 ? totalWinTicks / wins : 0;
			double avgLossTicks = losses > 0 ? totalLossTicks / losses : 0;
			double profitFactor = totalLossTicks > 0 ? totalWinTicks / totalLossTicks : 0;
			double expectancy = avgWinTicks * (wr / 100.0) - avgLossTicks * (1.0 - wr / 100.0);
			
			// TP/SL info
			double tpPoints = tpTicks / TICKS_PER_POINT;
			double slPoints = slTicks / TICKS_PER_POINT;
			
			// Colores
			Brush wrColor = wr >= 55 ? Brushes.Lime : (wr >= 50 ? Brushes.Yellow : Brushes.Red);
			Brush pnlColor = totalPnLPoints >= 0 ? Brushes.Lime : Brushes.Red;
			Brush pfColor = profitFactor >= 1.5 ? Brushes.Lime : (profitFactor >= 1.0 ? Brushes.Yellow : Brushes.Red);
			
			string text = string.Format(
				"MFS SCALP v4 (REAL)\n" +
				"═══════════════════════════════════════\n" +
				"TRADES: {0} | W: {1} | L: {2}\n" +
				"WINRATE: {3:F2}%\n" +
				"═══════════════════════════════════════\n" +
				"TP/SL: {4} ticks ({5:F1} pts) / {6} ticks ({7:F1} pts)\n" +
				"───────────────────────────────────────\n" +
				"PnL TOTAL: {8:F1} ticks = {9:F2} puntos\n" +
				"PnL PROMEDIO: {10:F2} ticks/trade ({11:F2} pts)\n" +
				"───────────────────────────────────────\n" +
				"WIN PROMEDIO: {12:F1} ticks\n" +
				"LOSS PROMEDIO: {13:F1} ticks\n" +
				"PROFIT FACTOR: {14:F2}\n" +
				"EXPECTATIVA: {15:F2} ticks/trade\n" +
				"═══════════════════════════════════════\n" +
				"SHARK: {16} ({17:F1}) | MAP: {18} | Ciclo: {19}\n" +
				"Armed: {20} | InTrade: {21}",
				totalTrades, wins, losses,
				wr,
				tpTicks, tpPoints, slTicks, slPoints,
				totalPnLTicks, totalPnLPoints,
				avgPnLTicks, avgPnLPoints,
				avgWinTicks,
				avgLossTicks,
				profitFactor,
				expectancy,
				sharkState > 0 ? "BULL" : (sharkState < 0 ? "BEAR" : "NEUT"),
				sharkValue,
				lastMapIndex,
				cycleDirection > 0 ? "UP" : (cycleDirection < 0 ? "DOWN" : "-"),
				signalArmed ? "Y" : "N",
				inTrade ? "Y" : "N"
			);
			
			Draw.TextFixed(this, "Panel", text, TextPosition.TopLeft, 
				Brushes.White, new Gui.Tools.SimpleFont("Consolas", 9), 
				Brushes.Transparent, Brushes.Transparent, 0);
		}
		
		private bool IsSharkAligned()
		{
			if (cycleDirection > 0 && sharkState > 0) return true;
			if (cycleDirection < 0 && sharkState < 0) return true;
			return false;
		}
		
		private void InitializeLog()
		{
			if (!logEnabled)
				return;
			
			try
			{
				string ntFolder = NinjaTrader.Core.Globals.UserDataDir;
				string logFolder = Path.Combine(ntFolder, "logs", "MFSScalp");
				
				if (!Directory.Exists(logFolder))
					Directory.CreateDirectory(logFolder);
				
				logPath = Path.Combine(logFolder, "MFSScalp_TradeLog.csv");
				bool fileExists = File.Exists(logPath);
				
				logWriter = new StreamWriter(logPath, true, System.Text.Encoding.UTF8);
				logWriter.AutoFlush = true;
				
				if (!fileExists)
				{
					logWriter.WriteLine("Timestamp,Instrument,Type,Direction,Price,Scenario,MapIdx,CycleDir,PnL,Bars");
				}
				
				Print(string.Format("MFSScalp Log: {0}", logPath));
			}
			catch (Exception ex)
			{
				Print("Error initializing log: " + ex.Message);
				logWriter = null;
			}
		}
		
		private void CloseLog()
		{
			if (logWriter != null)
			{
				try
				{
					logWriter.Close();
					logWriter = null;
				}
				catch { }
			}
		}
		
		private void LogTrade(string type, string direction, double price, 
			string scenario, int mapIdx, int cycleDir, double pnl = 0, int bars = 0)
		{
			if (!logEnabled || logWriter == null)
				return;
			
			try
			{
				// Usar Time[0] para obtener el timestamp REAL de la barra
				DateTime barTime = Time[0];
				
				string line = string.Format(CultureInfo.InvariantCulture,
					"{0},{1},{2},{3},{4:F2},{5},{6},{7},{8:F1},{9}",
					barTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
					Instrument.FullName,
					type,
					direction,
					price,
					scenario,
					mapIdx,
					cycleDir,
					pnl,
					bars);
				
				logWriter.WriteLine(line);
			}
			catch (Exception ex)
			{
				Print("Error writing log: " + ex.Message);
			}
		}
		
		#region Properties
		[NinjaScriptProperty]
		[Range(1, 1000)]
		[Display(Name = "TP Ticks", Order = 1, GroupName = "Parameters")]
		public int TpTicks
		{
			get { return tpTicks; }
			set { tpTicks = value; }
		}
		
		[NinjaScriptProperty]
		[Range(1, 1000)]
		[Display(Name = "SL Ticks", Order = 2, GroupName = "Parameters")]
		public int SlTicks
		{
			get { return slTicks; }
			set { slTicks = value; }
		}
		
		[NinjaScriptProperty]
		[Display(Name = "Enable SHARK Filter", Description = "Require SHARK alignment (FPLEME philosophy)", Order = 3, GroupName = "Parameters")]
		public bool EnableSharkFilter
		{
			get { return enableSharkFilter; }
			set { enableSharkFilter = value; }
		}
		#endregion
	}
}

#region NinjaScript generated code. Neither change nor remove.

namespace NinjaTrader.NinjaScript.Indicators
{
	public partial class Indicator : NinjaTrader.Gui.NinjaScript.IndicatorRenderBase
	{
		private MFSScalpIndicator[] cacheMFSScalpIndicator;
		public MFSScalpIndicator MFSScalpIndicator(int tpTicks, int slTicks, bool enableSharkFilter)
		{
			return MFSScalpIndicator(Input, tpTicks, slTicks, enableSharkFilter);
		}

		public MFSScalpIndicator MFSScalpIndicator(ISeries<double> input, int tpTicks, int slTicks, bool enableSharkFilter)
		{
			if (cacheMFSScalpIndicator != null)
				for (int idx = 0; idx < cacheMFSScalpIndicator.Length; idx++)
					if (cacheMFSScalpIndicator[idx] != null && cacheMFSScalpIndicator[idx].TpTicks == tpTicks && cacheMFSScalpIndicator[idx].SlTicks == slTicks && cacheMFSScalpIndicator[idx].EnableSharkFilter == enableSharkFilter && cacheMFSScalpIndicator[idx].EqualsInput(input))
						return cacheMFSScalpIndicator[idx];
			return CacheIndicator<MFSScalpIndicator>(new MFSScalpIndicator(){ TpTicks = tpTicks, SlTicks = slTicks, EnableSharkFilter = enableSharkFilter }, input, ref cacheMFSScalpIndicator);
		}
	}
}

namespace NinjaTrader.NinjaScript.MarketAnalyzerColumns
{
	public partial class MarketAnalyzerColumn : MarketAnalyzerColumnBase
	{
		public Indicators.MFSScalpIndicator MFSScalpIndicator(int tpTicks, int slTicks, bool enableSharkFilter)
		{
			return indicator.MFSScalpIndicator(Input, tpTicks, slTicks, enableSharkFilter);
		}

		public Indicators.MFSScalpIndicator MFSScalpIndicator(ISeries<double> input , int tpTicks, int slTicks, bool enableSharkFilter)
		{
			return indicator.MFSScalpIndicator(input, tpTicks, slTicks, enableSharkFilter);
		}
	}
}

namespace NinjaTrader.NinjaScript.Strategies
{
	public partial class Strategy : NinjaTrader.Gui.NinjaScript.StrategyRenderBase
	{
		public Indicators.MFSScalpIndicator MFSScalpIndicator(int tpTicks, int slTicks, bool enableSharkFilter)
		{
			return indicator.MFSScalpIndicator(Input, tpTicks, slTicks, enableSharkFilter);
		}

		public Indicators.MFSScalpIndicator MFSScalpIndicator(ISeries<double> input , int tpTicks, int slTicks, bool enableSharkFilter)
		{
			return indicator.MFSScalpIndicator(input, tpTicks, slTicks, enableSharkFilter);
		}
	}
}

#endregion
