#region Using declarations
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Windows.Media;
using System.Xml.Serialization;
using NinjaTrader.Data;
using NinjaTrader.Gui.Tools;
using NinjaTrader.NinjaScript;
using NinjaTrader.NinjaScript.Indicators;
using NinjaTrader.NinjaScript.DrawingTools;
using FplemeIndicators = NinjaTrader.NinjaScript.Indicators._FPLEME_;
#endregion

namespace NinjaTrader.NinjaScript.Indicators
{
	public enum FlowEntryMode
	{
		MarketClose,
		LimitPrevBox
	}

	public enum Etapa2TimingMode
	{
		Classic,
		Mode2_2
	}

	public class FlowCycleSignalsV1 : Indicator
	{
		private int upBoxes;
		private int downBoxes;
		private int lastBoxDir;
		private int sharkAlignBars;
		private int lastSharkSign;
		private int cycleSign;
		private double cycleHigh = double.NaN;
		private double cycleLow = double.NaN;
		private double lastBullHigh = double.NaN;
		private double lastBullLow = double.NaN;
		private double lastBearLow = double.NaN;
		private double lastBearHigh = double.NaN;

		private int lastSignalBar = int.MinValue;
		private int signalCount;
		private bool warnedBarsType;
		private bool isRenkoBRZ;
		private bool tradeActive;
		private bool tradeIsBuy;
		private double tradeEntry;
		private double tradeTarget;
		private double tradeStop;
		private int tradeEntryBar;
		private DateTime tradeEntryTime;
		private int tradeWins;
		private int tradeLosses;
		private int tradeCount;
		private int tradeSequence;
		private int activeTradeId;
		private double totalPoints;
		private double winPoints;
		private double lossPoints;
		private string tradeSignalType = "NONE";
		private string tradeEntryMode = "NONE";
		private bool csvInitialized;
		private bool csvPathLogged;
		private string csvPath;
		private string csvRunTag = string.Empty;
		private bool pendingEntry;
		private bool pendingIsBuy;
		private bool pendingIsEtapa2;
		private double pendingEntryPrice;
		private int pendingSignalBar = -1;
		private string pendingSignalType = "NONE";
		private int lastSignalBarNumber = -1;
		private string lastSignalType = "NONE";
		private double lastFlow;
		private double lastShark;
		private bool e1BuyArmed;
		private bool e1SellArmed;
		private bool e2BuyArmed;
		private bool e2SellArmed;
		private bool tradeIsEtapa2;
		private FplemeIndicators.FPLEME_M7 fplemeIndicator;
		private FplemeIndicators.MAPS_M7 mapsIndicator;
		private FplemeIndicators.VXM7 vxIndicator;

		private enum WallBias
		{
			Unknown,
			Bullish,
			Bearish,
			Neutral
		}

		protected override void OnStateChange()
		{
			if (State == State.SetDefaults)
			{
				Name = "FlowCycleSignalsV1";
				Description = "Box-based flow and cycle signals for RenkoBRZ.";
				Calculate = Calculate.OnBarClose;
				IsOverlay = false;
				DrawOnPricePanel = true;
				PaintPriceMarkers = false;
				IsSuspendedWhileInactive = true;

				EnableEtapa1 = true;
				EnableEtapa2 = true;
				RequireSharkAlign = true;
				RequireSlope = true;
				RequireSharkSlope = true;
				RequireSharkConfirmEtapa1 = true;
				RequireFlowSharkConvergence = true;
				MaxFlowSharkGap = 3.0;
				MinCycleRangeBoxes = 1;
				MinFlowDelta = 0.5;
				MinSharkDelta = 0.5;
				MinSharkStrength = 2.0;
				UseFplemeConfirm = true;
				FplemeMinLevel = 0.0;
				FplemeMinShark = 0.0;
				UseFplemeEtapa1Filter = false;
				UseMapsWallFilter = true;
				MapsWallNeutralTicks = 2;
				AllowWallNeutral = true;
				UseMap0Bias = false;
				Map0ToleranceTicks = 2;
				UseVxWallDirection = false;
				VxWallDirectionThreshold = 0.0;
				VxAllowNeutral = true;
				VxEtapa2Only = true;
				CooldownBars = 3;
				MinBars = 100;
				NormPeriod = 500;
				NormScale = 12;
				AllowEarlySignals = true;

				FlowOffset = 3;

				SharkOffset = 3;
				SharkMultiplier = 1.0;

				SignalThreshold = 4;
				SignalExtreme = 8;
				ExtremeNoStartLevel = 8;

				Etapa1MinConfirmBoxes = 2;
				Etapa1MaxConfirmBoxes = 3;
				SharkConfirmBars = 2;
				RequireSecondCycle = true;
				AllowEqualCycle = false;
				MinSecondCycleDeltaBoxes = 1;
				ApplySecondCycleToEtapa1 = false;

				EntryModeSetting = FlowEntryMode.LimitPrevBox;
				Etapa2TimingSetting = Etapa2TimingMode.Classic;
				EntryTimeoutBars = 3;

				ShowSignals = true;
				ShowStops = false;
				UseDynamicStops = false;
				SwingLookback = 5;
				StopExtraTicks = 0;
				StopMaxBoxes = 1;
				UseFixedTargetsStops = true;
				TargetPoints = 10;
				StopPoints = 10;
				AssumeStopOnAmbiguous = true;
				ShowStats = true;
				ShowOutcomeMarks = false;
				StatsPosition = TextPosition.TopLeft;
				ShowResultsPanel = true;
				ResultsPosition = TextPosition.BottomLeft;
				EnableTradeLog = true;
				ShowTradeLevels = true;
				ShowTradeMarkers = true;
				EnableCsvLog = true;
				UseTimestampedCsv = true;
				CsvFileName = "FlowCycleSignalsV1_trades.csv";

				AddPlot(Brushes.Silver, "FlowLine");
				AddPlot(Brushes.DimGray, "SharkLine");
			}
			else if (State == State.DataLoaded)
			{
				string btName = (Bars != null && Bars.BarsType != null) ? Bars.BarsType.GetType().Name : string.Empty;
				isRenkoBRZ = btName.IndexOf("RenkoBRZ", StringComparison.OrdinalIgnoreCase) >= 0;
				csvInitialized = false;
				csvPath = string.Empty;
				csvPathLogged = false;
				csvRunTag = DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture);
				InitializeConfirmationIndicators();
			}
		}

		protected override void OnBarUpdate()
		{
			if (BarsInProgress != 0)
				return;

			if (!isRenkoBRZ)
			{
				if (!warnedBarsType)
				{
					Draw.TextFixed(this, "BarsTypeWarning", "FlowCycleSignalsV1: use RenkoBRZ", TextPosition.TopLeft,
						Brushes.Gray, new SimpleFont("Arial", 12), Brushes.Transparent, Brushes.Transparent, 0);
					warnedBarsType = true;
				}
				return;
			}

			EnsureCsvReady();

			int minOffset = Math.Max(FlowOffset, SharkOffset);
			int minRequired = Math.Max(minOffset, Math.Max(SwingLookback, 2));
			if (CurrentBar < minRequired)
				return;

			if (!AllowEarlySignals)
			{
				int requiredBars = Math.Max(MinBars, NormPeriod);
				if (CurrentBar < requiredBars)
					return;
			}

			int flowWindow = Math.Max(1, FlowOffset);
			int sharkWindow = Math.Max(1, SharkOffset);

			UpdateBoxCounts();

			double flowSum = GetBoxSum(flowWindow);
			double sharkSum = GetBoxSum(sharkWindow);

			double flowLevel = (flowSum / flowWindow) * NormScale;
			double sharkLevel = (sharkSum / sharkWindow) * NormScale * SharkMultiplier;
			flowLevel = Clamp(flowLevel, -NormScale, NormScale);
			sharkLevel = Clamp(sharkLevel, -NormScale, NormScale);

			Values[0][0] = flowLevel;
			Values[1][0] = sharkLevel;

			PlotBrushes[0][0] = flowLevel > 0 ? Brushes.Green : (flowLevel < 0 ? Brushes.Red : Brushes.Gray);
			PlotBrushes[1][0] = sharkLevel > 0 ? Brushes.Green : (sharkLevel < 0 ? Brushes.Red : Brushes.Gray);
			lastFlow = flowLevel;
			lastShark = sharkLevel;

			int sharkSign = sharkLevel > 0 ? 1 : (sharkLevel < 0 ? -1 : 0);
			UpdateSharkAlignment(sharkSign);
			UpdateCycleStats(sharkSign);

			if (CurrentBar < 1)
				return;

			CheckTradeOutcome();

			if (tradeActive)
			{
				UpdateStatsText();
				UpdateResultsPanel();
				return;
			}

			if (TryFillPending())
			{
				UpdateStatsText();
				UpdateResultsPanel();
				return;
			}

			if (pendingEntry)
			{
				UpdateStatsText();
				UpdateResultsPanel();
				return;
			}

			double prevFlow = Values[0][1];
			double flowDelta = flowLevel - prevFlow;
			double prevShark = Values[1][1];
			double sharkDelta = sharkLevel - prevShark;
			bool prevBoxUp = Close[1] > Open[1];
			bool prevBoxDown = Close[1] < Open[1];
			double minFlowDelta = Math.Max(0.0, MinFlowDelta);
			double minSharkDelta = Math.Max(0.0, MinSharkDelta);
			bool sharkSlopeBuy = sharkDelta >= minSharkDelta;
			bool sharkSlopeSell = sharkDelta <= -minSharkDelta;

			bool sharkBullNow = sharkSign > 0;
			bool sharkBearNow = sharkSign < 0;
			bool sharkBullConfirmed = sharkBullNow && sharkAlignBars >= SharkConfirmBars;
			bool sharkBearConfirmed = sharkBearNow && sharkAlignBars >= SharkConfirmBars;

			if (flowLevel <= -SignalThreshold && flowLevel > -ExtremeNoStartLevel)
				e1BuyArmed = true;
			if (flowLevel >= SignalThreshold && flowLevel < ExtremeNoStartLevel)
				e1SellArmed = true;

			if (flowLevel <= -ExtremeNoStartLevel)
				e1BuyArmed = false;
			if (flowLevel >= ExtremeNoStartLevel)
				e1SellArmed = false;

			int minConfirm = Math.Max(1, Etapa1MinConfirmBoxes);
			int maxConfirm = Math.Max(minConfirm, Etapa1MaxConfirmBoxes);
			if (upBoxes > maxConfirm)
				e1BuyArmed = false;
			if (downBoxes > maxConfirm)
				e1SellArmed = false;

			bool e1Buy = EnableEtapa1 && e1BuyArmed && flowLevel >= 0 && flowLevel <= SignalThreshold &&
				upBoxes >= minConfirm && upBoxes <= maxConfirm && prevBoxUp;
			bool e1Sell = EnableEtapa1 && e1SellArmed && flowLevel <= 0 && flowLevel >= -SignalThreshold &&
				downBoxes >= minConfirm && downBoxes <= maxConfirm && prevBoxDown;

			bool prevInE2BuyZone = prevFlow >= SignalThreshold && prevFlow < SignalExtreme;
			bool prevInE2SellZone = prevFlow <= -SignalThreshold && prevFlow > -SignalExtreme;

			e2BuyArmed = prevInE2BuyZone;
			e2SellArmed = prevInE2SellZone;

			bool e2Buy = EnableEtapa2 && prevInE2BuyZone && flowLevel >= SignalExtreme && flowLevel <= NormScale &&
				lastBoxDir > 0 && prevBoxUp;
			bool e2Sell = EnableEtapa2 && prevInE2SellZone && flowLevel <= -SignalExtreme && flowLevel >= -NormScale &&
				lastBoxDir < 0 && prevBoxDown;

			bool slopeBuy = !RequireSlope || flowDelta > minFlowDelta;
			bool slopeSell = !RequireSlope || flowDelta < -minFlowDelta;

			if (RequireSharkAlign)
			{
				bool e1SharkOkBuy = RequireSharkConfirmEtapa1 ? sharkBullConfirmed : sharkBullNow;
				bool e1SharkOkSell = RequireSharkConfirmEtapa1 ? sharkBearConfirmed : sharkBearNow;
				e1Buy = e1Buy && e1SharkOkBuy;
				e1Sell = e1Sell && e1SharkOkSell;
				e2Buy = e2Buy && sharkBullConfirmed;
				e2Sell = e2Sell && sharkBearConfirmed;
			}
			if (RequireSharkSlope)
			{
				e1Buy = e1Buy && sharkSlopeBuy;
				e2Buy = e2Buy && sharkSlopeBuy;
				e1Sell = e1Sell && sharkSlopeSell;
				e2Sell = e2Sell && sharkSlopeSell;
			}

			if (MinSharkStrength > 0.0)
			{
				bool sharkStrongBuy = sharkLevel >= MinSharkStrength;
				bool sharkStrongSell = sharkLevel <= -MinSharkStrength;
				e1Buy = e1Buy && sharkStrongBuy;
				e2Buy = e2Buy && sharkStrongBuy;
				e1Sell = e1Sell && sharkStrongSell;
				e2Sell = e2Sell && sharkStrongSell;
			}

			if (RequireFlowSharkConvergence)
			{
				double maxGap = Math.Max(0.0, MaxFlowSharkGap);
				bool sameSign = (flowLevel >= 0 && sharkLevel >= 0) || (flowLevel <= 0 && sharkLevel <= 0);
				bool converged = sameSign && Math.Abs(flowLevel - sharkLevel) <= maxGap;
				e1Buy = e1Buy && converged;
				e2Buy = e2Buy && converged;
				e1Sell = e1Sell && converged;
				e2Sell = e2Sell && converged;
			}

			if (MinCycleRangeBoxes > 0 && !double.IsNaN(cycleHigh) && !double.IsNaN(cycleLow))
			{
				double minRange = MinCycleRangeBoxes * GetBoxSize();
				bool cycleRangeOk = (cycleHigh - cycleLow) >= minRange;
				e1Buy = e1Buy && cycleRangeOk;
				e2Buy = e2Buy && cycleRangeOk;
				e1Sell = e1Sell && cycleRangeOk;
				e2Sell = e2Sell && cycleRangeOk;
			}

			bool cycleOkBuy = true;
			bool cycleOkSell = true;
			if (RequireSecondCycle || MinSecondCycleDeltaBoxes > 0)
			{
				double minCycleDelta = 0.0;
				if (MinSecondCycleDeltaBoxes > 0)
					minCycleDelta = MinSecondCycleDeltaBoxes * GetBoxSize();

				cycleOkBuy = !double.IsNaN(lastBullLow) &&
					(AllowEqualCycle ? cycleLow >= lastBullLow : cycleLow > lastBullLow);
				if (minCycleDelta > 0 && !double.IsNaN(lastBullLow))
					cycleOkBuy = cycleOkBuy && (cycleLow - lastBullLow >= minCycleDelta);

				cycleOkSell = !double.IsNaN(lastBearHigh) &&
					(AllowEqualCycle ? cycleHigh <= lastBearHigh : cycleHigh < lastBearHigh);
				if (minCycleDelta > 0 && !double.IsNaN(lastBearHigh))
					cycleOkSell = cycleOkSell && (lastBearHigh - cycleHigh >= minCycleDelta);
			}

			if (RequireSecondCycle || MinSecondCycleDeltaBoxes > 0)
			{
				if (ApplySecondCycleToEtapa1)
				{
					e1Buy = e1Buy && cycleOkBuy;
					e1Sell = e1Sell && cycleOkSell;
				}

				e2Buy = e2Buy && cycleOkBuy;
				e2Sell = e2Sell && cycleOkSell;
			}

			if (!slopeBuy)
			{
				e1Buy = false;
				e2Buy = false;
			}

			if (!slopeSell)
			{
				e1Sell = false;
				e2Sell = false;
			}

			if (flowLevel > SignalThreshold)
				e1BuyArmed = false;
			if (flowLevel < -SignalThreshold)
				e1SellArmed = false;

			if (lastSignalBar != int.MinValue && CurrentBar - lastSignalBar < CooldownBars)
			{
				e1Buy = false;
				e1Sell = false;
				e2Buy = false;
				e2Sell = false;
			}

			ApplyExternalConfirmations(ref e1Buy, ref e1Sell, ref e2Buy, ref e2Sell);

			if (!ShowSignals)
			{
				UpdateStatsText();
				UpdateResultsPanel();
				return;
			}

			Brush longBrush = Brushes.LimeGreen;
			Brush shortBrush = Brushes.Red;

			if (e1Buy)
			{
				double entryPrice;
				if (TryGetEntryPrice(true, false, out entryPrice))
				{
					Draw.VerticalLine(this, "E1Buy" + CurrentBar, 0, longBrush);
					DrawStopIfEnabled(isBuy: true, isEtapa2: false);
					signalCount++;
					LogSignal("E1_BUY");
					if (EntryModeSetting == FlowEntryMode.LimitPrevBox)
						ArmPendingEntry(isBuy: true, isEtapa2: false, entryPrice: entryPrice, signalType: "E1_BUY");
					else
						StartTrade(isBuy: true, isEtapa2: false, entryPrice: entryPrice, signalType: "E1_BUY", entryMode: GetEntryModeLabel(false));
					lastSignalBar = CurrentBar;
					e1BuyArmed = false;
					lastSignalBarNumber = CurrentBar;
					lastSignalType = "E1_BUY";
				}
			}
			else if (e2Buy)
			{
				double entryPrice;
				if (TryGetEntryPrice(true, true, out entryPrice))
				{
					Draw.VerticalLine(this, "E2Buy" + CurrentBar, 0, longBrush);
					DrawStopIfEnabled(isBuy: true, isEtapa2: true);
					signalCount++;
					LogSignal("E2_BUY");
					if (EntryModeSetting == FlowEntryMode.LimitPrevBox)
						ArmPendingEntry(isBuy: true, isEtapa2: true, entryPrice: entryPrice, signalType: "E2_BUY");
					else
						StartTrade(isBuy: true, isEtapa2: true, entryPrice: entryPrice, signalType: "E2_BUY", entryMode: GetEntryModeLabel(true));
					lastSignalBar = CurrentBar;
					e2BuyArmed = false;
					lastSignalBarNumber = CurrentBar;
					lastSignalType = "E2_BUY";
				}
			}
			else if (e1Sell)
			{
				double entryPrice;
				if (TryGetEntryPrice(false, false, out entryPrice))
				{
					Draw.VerticalLine(this, "E1Sell" + CurrentBar, 0, shortBrush);
					DrawStopIfEnabled(isBuy: false, isEtapa2: false);
					signalCount++;
					LogSignal("E1_SELL");
					if (EntryModeSetting == FlowEntryMode.LimitPrevBox)
						ArmPendingEntry(isBuy: false, isEtapa2: false, entryPrice: entryPrice, signalType: "E1_SELL");
					else
						StartTrade(isBuy: false, isEtapa2: false, entryPrice: entryPrice, signalType: "E1_SELL", entryMode: GetEntryModeLabel(false));
					lastSignalBar = CurrentBar;
					e1SellArmed = false;
					lastSignalBarNumber = CurrentBar;
					lastSignalType = "E1_SELL";
				}
			}
			else if (e2Sell)
			{
				double entryPrice;
				if (TryGetEntryPrice(false, true, out entryPrice))
				{
					Draw.VerticalLine(this, "E2Sell" + CurrentBar, 0, shortBrush);
					DrawStopIfEnabled(isBuy: false, isEtapa2: true);
					signalCount++;
					LogSignal("E2_SELL");
					if (EntryModeSetting == FlowEntryMode.LimitPrevBox)
						ArmPendingEntry(isBuy: false, isEtapa2: true, entryPrice: entryPrice, signalType: "E2_SELL");
					else
						StartTrade(isBuy: false, isEtapa2: true, entryPrice: entryPrice, signalType: "E2_SELL", entryMode: GetEntryModeLabel(true));
					lastSignalBar = CurrentBar;
					e2SellArmed = false;
					lastSignalBarNumber = CurrentBar;
					lastSignalType = "E2_SELL";
				}
			}

			UpdateStatsText();
			UpdateResultsPanel();
		}

		private double Clamp(double value, double min, double max)
		{
			if (value > max)
				return max;
			if (value < min)
				return min;
			return value;
		}

		private int GetBoxDirection(int barsAgo)
		{
			if (CurrentBar < barsAgo)
				return 0;

			double diff = Close[barsAgo] - Open[barsAgo];
			if (diff > 0)
				return 1;
			if (diff < 0)
				return -1;
			return 0;
		}

		private bool TryGetPrevBoxEntryPrice(bool isBuy, out double entryPrice)
		{
			entryPrice = 0.0;
			if (CurrentBar < 1)
				return false;

			double prevOpen = Open[1];
			double prevClose = Close[1];
			if (isBuy)
			{
				if (prevClose <= prevOpen)
					return false;
				entryPrice = Math.Min(prevOpen, prevClose);
				return true;
			}

			if (prevClose >= prevOpen)
				return false;
			entryPrice = Math.Max(prevOpen, prevClose);
			return true;
		}

		private bool TryGetCurrentBoxEntryPrice(bool isBuy, out double entryPrice)
		{
			entryPrice = 0.0;

			double currOpen = Open[0];
			double currClose = Close[0];
			if (isBuy)
			{
				if (currClose <= currOpen)
					return false;
				entryPrice = Math.Min(currOpen, currClose);
				return true;
			}

			if (currClose >= currOpen)
				return false;
			entryPrice = Math.Max(currOpen, currClose);
			return true;
		}

		private bool TryGetEntryPrice(bool isBuy, bool isEtapa2, out double entryPrice)
		{
			if (EntryModeSetting == FlowEntryMode.MarketClose)
			{
				entryPrice = Close[0];
				return true;
			}

			if (isEtapa2 && Etapa2TimingSetting == Etapa2TimingMode.Mode2_2)
				return TryGetCurrentBoxEntryPrice(isBuy, out entryPrice);

			return TryGetPrevBoxEntryPrice(isBuy, out entryPrice);
		}

		private string GetEntryModeLabel(bool isEtapa2)
		{
			if (EntryModeSetting != FlowEntryMode.LimitPrevBox)
				return EntryModeSetting.ToString();
			if (!isEtapa2)
				return EntryModeSetting.ToString();
			return string.Format("{0}-{1}", EntryModeSetting, Etapa2TimingSetting);
		}

		private double GetBoxSum(int length)
		{
			int len = Math.Min(length, CurrentBar + 1);
			if (len <= 0)
				return 0.0;

			double sum = 0.0;
			for (int i = 0; i < len; i++)
				sum += GetBoxDirection(i);
			return sum;
		}

		private double GetBoxSize()
		{
			double size = Math.Abs(Close[0] - Open[0]);
			if (size <= 0)
				size = TickSize;
			return size;
		}

		private void UpdateBoxCounts()
		{
			int dir = GetBoxDirection(0);
			lastBoxDir = dir;
			if (dir > 0)
			{
				upBoxes++;
				downBoxes = 0;
			}
			else if (dir < 0)
			{
				downBoxes++;
				upBoxes = 0;
			}
			else
			{
				upBoxes = 0;
				downBoxes = 0;
			}
		}

		private void UpdateSharkAlignment(int sharkSign)
		{
			if (sharkSign != 0 && sharkSign == lastSharkSign)
				sharkAlignBars++;
			else
				sharkAlignBars = sharkSign != 0 ? 1 : 0;

			lastSharkSign = sharkSign;
		}

		private void UpdateCycleStats(int sharkSign)
		{
			if (sharkSign == 0)
				return;

			if (cycleSign != sharkSign)
			{
				if (cycleSign == 1 && !double.IsNaN(cycleHigh) && !double.IsNaN(cycleLow))
				{
					lastBullHigh = cycleHigh;
					lastBullLow = cycleLow;
				}
				else if (cycleSign == -1 && !double.IsNaN(cycleHigh) && !double.IsNaN(cycleLow))
				{
					lastBearLow = cycleLow;
					lastBearHigh = cycleHigh;
				}

				cycleSign = sharkSign;
				cycleHigh = High[0];
				cycleLow = Low[0];
				return;
			}

			if (double.IsNaN(cycleHigh))
				cycleHigh = High[0];
			else
				cycleHigh = Math.Max(cycleHigh, High[0]);

			if (double.IsNaN(cycleLow))
				cycleLow = Low[0];
			else
				cycleLow = Math.Min(cycleLow, Low[0]);
		}

		private void InitializeConfirmationIndicators()
		{
			fplemeIndicator = null;
			mapsIndicator = null;
			vxIndicator = null;

			if (UseFplemeConfirm || UseFplemeEtapa1Filter)
			{
				bool showEtapa1 = UseFplemeEtapa1Filter;
				fplemeIndicator = FPLEME_M7(false, false, false, showEtapa1, false, false, false, false, false, false, false);
			}

			if (UseMapsWallFilter || UseMap0Bias)
				mapsIndicator = MAPS_M7(false, false, true, true, false, false);

			if (UseVxWallDirection)
				vxIndicator = VXM7(true, false, false);
		}

		private void ApplyExternalConfirmations(ref bool e1Buy, ref bool e1Sell, ref bool e2Buy, ref bool e2Sell)
		{
			if ((UseFplemeConfirm || UseFplemeEtapa1Filter) && fplemeIndicator != null)
			{
				e1Buy = e1Buy && PassFplemeConfirm(isBuy: true, isEtapa2: false);
				e1Sell = e1Sell && PassFplemeConfirm(isBuy: false, isEtapa2: false);
				e2Buy = e2Buy && PassFplemeConfirm(isBuy: true, isEtapa2: true);
				e2Sell = e2Sell && PassFplemeConfirm(isBuy: false, isEtapa2: true);
			}

			if ((UseMapsWallFilter || UseMap0Bias) && mapsIndicator != null)
			{
				bool mapsBuyOk = PassMapsConfirm(isBuy: true);
				bool mapsSellOk = PassMapsConfirm(isBuy: false);
				e1Buy = e1Buy && mapsBuyOk;
				e2Buy = e2Buy && mapsBuyOk;
				e1Sell = e1Sell && mapsSellOk;
				e2Sell = e2Sell && mapsSellOk;
			}

			if (UseVxWallDirection && vxIndicator != null)
			{
				bool vxBuyOk = PassVxDirection(isBuy: true);
				bool vxSellOk = PassVxDirection(isBuy: false);
				if (!VxEtapa2Only)
				{
					e1Buy = e1Buy && vxBuyOk;
					e1Sell = e1Sell && vxSellOk;
				}
				e2Buy = e2Buy && vxBuyOk;
				e2Sell = e2Sell && vxSellOk;
			}
		}

		private bool PassFplemeConfirm(bool isBuy, bool isEtapa2)
		{
			if ((!UseFplemeConfirm && !UseFplemeEtapa1Filter) || fplemeIndicator == null)
				return true;

			double fplemeLine = fplemeIndicator.FPLEME_LINE[0];
			double fplemeShark = fplemeIndicator.SHARK_LINE[0];
			if (double.IsNaN(fplemeLine) || double.IsNaN(fplemeShark))
				return true;

			double minLevel = Math.Max(0.0, FplemeMinLevel);
			double minShark = Math.Max(0.0, FplemeMinShark);
			bool ok = isBuy ? (fplemeLine >= minLevel && fplemeShark >= minShark)
				: (fplemeLine <= -minLevel && fplemeShark <= -minShark);

			if (!isEtapa2 && UseFplemeEtapa1Filter)
			{
				double etapaValue = isBuy ? fplemeIndicator.ETAPA_1C[0] : fplemeIndicator.ETAPA_1V[0];
				if (!double.IsNaN(etapaValue))
					ok = ok && etapaValue > 0;
			}

			return ok;
		}

		private bool PassMapsConfirm(bool isBuy)
		{
			if (mapsIndicator == null)
				return true;

			bool ok = true;
			if (UseMapsWallFilter)
			{
				double neutralThreshold = Math.Max(0.0, MapsWallNeutralTicks) * TickSize;
				WallBias bias = GetWallBias(mapsIndicator.TW, neutralThreshold);
				ok = ok && WallAllows(bias, isBuy, AllowWallNeutral);
			}

			if (UseMap0Bias)
			{
				double map0 = mapsIndicator.M0[0];
				if (!double.IsNaN(map0))
				{
					double tol = Math.Max(0.0, Map0ToleranceTicks) * TickSize;
					ok = ok && (isBuy ? Close[0] <= map0 + tol : Close[0] >= map0 - tol);
				}
			}

			return ok;
		}

		private bool PassVxDirection(bool isBuy)
		{
			if (!UseVxWallDirection || vxIndicator == null)
				return true;

			double dirValue = vxIndicator.TWD[0];
			if (double.IsNaN(dirValue))
				return true;

			double threshold = Math.Abs(VxWallDirectionThreshold);
			if (dirValue > threshold)
				return isBuy;
			if (dirValue < -threshold)
				return !isBuy;

			return VxAllowNeutral;
		}

		private WallBias GetWallBias(ISeries<double> series, double neutralThreshold)
		{
			if (series == null || CurrentBar < 1)
				return WallBias.Unknown;

			double curr = series[0];
			double prev = series[1];
			if (double.IsNaN(curr) || double.IsNaN(prev))
				return WallBias.Unknown;

			double delta = curr - prev;
			if (delta > neutralThreshold)
				return WallBias.Bullish;
			if (delta < -neutralThreshold)
				return WallBias.Bearish;
			return WallBias.Neutral;
		}

		private bool WallAllows(WallBias bias, bool isBuy, bool allowNeutral)
		{
			if (bias == WallBias.Unknown)
				return true;
			if (bias == WallBias.Neutral)
				return allowNeutral;
			return isBuy ? bias == WallBias.Bullish : bias == WallBias.Bearish;
		}

		private double GetSeriesMin(ISeries<double> series, int length)
		{
			if (length <= 0)
				return series[0];

			double min = double.MaxValue;
			for (int i = 0; i < length; i++)
			{
				double v = series[i];
				if (v < min)
					min = v;
			}
			return min == double.MaxValue ? series[0] : min;
		}

		private double GetSeriesMax(ISeries<double> series, int length)
		{
			if (length <= 0)
				return series[0];

			double max = double.MinValue;
			for (int i = 0; i < length; i++)
			{
				double v = series[i];
				if (v > max)
					max = v;
			}
			return max == double.MinValue ? series[0] : max;
		}

		private void LogEvent(string message)
		{
			if (!EnableTradeLog)
				return;
			Print(string.Format("FlowCycleSignalsV1 | {0:yyyy-MM-dd HH:mm:ss} | Bar {1} | {2}", Time[0], CurrentBar, message));
		}

		private void LogSignal(string signalType)
		{
			LogEvent(string.Format("SIGNAL {0} count={1} flow={2:F2} shark={3:F2}", signalType, signalCount, lastFlow, lastShark));
		}

		private void StartTrade(bool isBuy, bool isEtapa2, double entryPrice, string signalType, string entryMode)
		{
			tradeActive = true;
			tradeIsBuy = isBuy;
			tradeIsEtapa2 = isEtapa2;
			tradeEntry = entryPrice;
			tradeEntryBar = CurrentBar;
			tradeEntryTime = Time[0];
			tradeSignalType = string.IsNullOrWhiteSpace(signalType) ? "NONE" : signalType;
			tradeEntryMode = string.IsNullOrWhiteSpace(entryMode) ? "NONE" : entryMode;
			double pointScale = GetPointScale();
			tradeTarget = isBuy ? tradeEntry + TargetPoints * pointScale : tradeEntry - TargetPoints * pointScale;
			tradeStop = UseFixedTargetsStops ? (isBuy ? tradeEntry - StopPoints * pointScale : tradeEntry + StopPoints * pointScale) : ComputeTradeStop(isBuy, isEtapa2);
			activeTradeId = ++tradeSequence;
			DrawTradeLevels();
			DrawTradeEntryMarker();
			LogEvent(string.Format("ENTRY {0} {1} mode={2} entry={3:F2} tp={4:F2} sl={5:F2}", activeTradeId, tradeSignalType, tradeEntryMode, tradeEntry, tradeTarget, tradeStop));
		}

		private void CheckTradeOutcome()
		{
			if (!tradeActive)
				return;

			if (CurrentBar <= tradeEntryBar)
				return;

			bool hitTarget = tradeIsBuy ? High[0] >= tradeTarget : Low[0] <= tradeTarget;
			bool hitStop = tradeIsBuy ? Low[0] <= tradeStop : High[0] >= tradeStop;

			if (hitTarget && hitStop)
			{
				if (AssumeStopOnAmbiguous)
					hitTarget = false;
				else
					hitStop = false;
			}

			if (hitTarget)
			{
				tradeActive = false;
				tradeWins++;
				tradeCount++;
				double exitPrice = tradeTarget;
				double pnl = tradeIsBuy ? exitPrice - tradeEntry : tradeEntry - exitPrice;
				double pnlPoints = ToPoints(pnl);
				totalPoints += pnlPoints;
				winPoints += Math.Abs(pnlPoints);
				DrawTradeExitMarker(true, exitPrice);
				WriteTradeCsv("TP", exitPrice, pnlPoints);
				LogEvent(string.Format("EXIT TP {0} {1} mode={2} entry={3:F2} exit={4:F2} pnl={5:F2} net={6:F2} bars={7} W/L={8}/{9}",
					activeTradeId, tradeSignalType, tradeEntryMode, tradeEntry, exitPrice, pnlPoints, totalPoints, CurrentBar - tradeEntryBar, tradeWins, tradeLosses));
			}
			else if (hitStop)
			{
				tradeActive = false;
				tradeLosses++;
				tradeCount++;
				double exitPrice = tradeStop;
				double pnl = tradeIsBuy ? exitPrice - tradeEntry : tradeEntry - exitPrice;
				double pnlPoints = ToPoints(pnl);
				totalPoints += pnlPoints;
				lossPoints += Math.Abs(pnlPoints);
				DrawTradeExitMarker(false, exitPrice);
				WriteTradeCsv("SL", exitPrice, pnlPoints);
				LogEvent(string.Format("EXIT SL {0} {1} mode={2} entry={3:F2} exit={4:F2} pnl={5:F2} net={6:F2} bars={7} W/L={8}/{9}",
					activeTradeId, tradeSignalType, tradeEntryMode, tradeEntry, exitPrice, pnlPoints, totalPoints, CurrentBar - tradeEntryBar, tradeWins, tradeLosses));
			}
		}

		private void DrawTradeLevels()
		{
			if (!ShowTradeLevels)
				return;

		}

		private void DrawTradeEntryMarker()
		{
			if (!ShowTradeMarkers)
				return;

			Brush entryBrush = tradeIsBuy ? Brushes.LimeGreen : Brushes.Red;
			Draw.VerticalLine(this, "EntryLine_" + activeTradeId, 0, entryBrush);
		}

		private void DrawTradeExitMarker(bool isWin, double exitPrice)
		{
			if (!ShowTradeMarkers)
				return;

		}

		private string BuildCsvPath()
		{
			string fileName = string.IsNullOrWhiteSpace(CsvFileName) ? "FlowCycleSignalsV1_trades.csv" : CsvFileName.Trim();
			if (UseTimestampedCsv)
			{
				if (string.IsNullOrWhiteSpace(csvRunTag))
					csvRunTag = DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture);

				string ext = Path.GetExtension(fileName);
				if (string.IsNullOrWhiteSpace(ext))
					ext = ".csv";

				string name = Path.GetFileNameWithoutExtension(fileName);
				string dir = Path.GetDirectoryName(fileName);
				string stamped = string.Format("{0}_{1}{2}", name, csvRunTag, ext);
				fileName = string.IsNullOrEmpty(dir) ? stamped : Path.Combine(dir, stamped);
			}

			if (Path.IsPathRooted(fileName))
				return fileName;

			string baseDir = NinjaTrader.Core.Globals.UserDataDir;
			return Path.Combine(baseDir, fileName);
		}

		private void EnsureCsvReady()
		{
			if (!EnableCsvLog || csvInitialized)
				return;

			csvPath = BuildCsvPath();

			try
			{
				bool writeHeader = !File.Exists(csvPath) || new FileInfo(csvPath).Length == 0;
				if (writeHeader)
				{
					string header = "TradeId,Instrument,BarsType,BarsValue,SignalType,EntryMode,EntryTime,EntryPrice,ExitTime,ExitPrice,PnLPoints,Result,BarsHeld,TargetPoints,StopPoints,TargetPrice,StopPrice,TargetUsedPoints,StopUsedPoints";
					File.AppendAllText(csvPath, header + Environment.NewLine);
				}
				csvInitialized = true;
				if (!csvPathLogged)
				{
					Print("FlowCycleSignalsV1 | CSV path: " + csvPath);
					csvPathLogged = true;
				}
			}
			catch (Exception ex)
			{
				csvInitialized = false;
				Print("FlowCycleSignalsV1 | CSV error: " + ex.Message);
			}
		}

		private void WriteTradeCsv(string result, double exitPrice, double pnl)
		{
			if (!EnableCsvLog)
				return;

			EnsureCsvReady();
			if (!csvInitialized)
				return;

			string instrument = Instrument != null ? Instrument.FullName : "NA";
			string barsType = Bars != null && Bars.BarsType != null ? Bars.BarsType.GetType().Name : "NA";
			int barsValue = BarsPeriod != null ? BarsPeriod.Value : 0;
			int barsHeld = CurrentBar - tradeEntryBar;
			double targetUsedPoints = ToPoints(Math.Abs(tradeTarget - tradeEntry));
			double stopUsedPoints = ToPoints(Math.Abs(tradeEntry - tradeStop));

			string line = string.Format(CultureInfo.InvariantCulture,
				"{0},\"{1}\",\"{2}\",{3},\"{4}\",\"{5}\",{6:yyyy-MM-dd HH:mm:ss},{7:F2},{8:yyyy-MM-dd HH:mm:ss},{9:F2},{10:F2},\"{11}\",{12},{13},{14},{15:F2},{16:F2},{17:F2},{18:F2}",
				activeTradeId, instrument, barsType, barsValue, tradeSignalType, tradeEntryMode,
				tradeEntryTime, tradeEntry, Time[0], exitPrice, pnl, result, barsHeld, TargetPoints, StopPoints,
				tradeTarget, tradeStop, targetUsedPoints, stopUsedPoints);

			try
			{
				File.AppendAllText(csvPath, line + Environment.NewLine);
			}
			catch (Exception ex)
			{
				Print("FlowCycleSignalsV1 | CSV write error: " + ex.Message);
			}
		}

		private void UpdateStatsText()
		{
			if (!ShowStats)
				return;

			double winrate = tradeCount > 0 ? (double)tradeWins / tradeCount * 100.0 : 0.0;
			string text = string.Format("Signals: {0}  Trades: {1}  W: {2}  L: {3}  WR: {4:F1}%  Pts: {5:F1}",
				signalCount, tradeCount, tradeWins, tradeLosses, winrate, totalPoints);
			Draw.TextFixed(this, "FlowCycleStats", text, StatsPosition, Brushes.Gray, new SimpleFont("Arial", 12),
				Brushes.Transparent, Brushes.Transparent, 0);
		}

		private void UpdateResultsPanel()
		{
			if (!ShowResultsPanel)
				return;

			double winrate = tradeCount > 0 ? (double)tradeWins / tradeCount * 100.0 : 0.0;
			string pendingText = pendingEntry ? string.Format("Pending: {0} @ {1:F2} ({2})", pendingSignalType, pendingEntryPrice, CurrentBar - pendingSignalBar) : "Pending: NONE";
			string text = string.Format("Signals: {0}  Trades: {1}  Winrate: {2:F1}%  W/L: {3}/{4}  Pts: {5:F1} (W:{6:F1} L:{7:F1})\n{8}\nLast: {9}  Bar: {10}\nFlow: {11:F2}  Shark: {12:F2}  SharkBars: {13}\nUp/Down: {14}/{15}  E1Arm(B/S): {16}/{17}  E2Arm(B/S): {18}/{19}\nCycleHi/Lo: {20:F2}/{21:F2}",
				signalCount, tradeCount, winrate, tradeWins, tradeLosses, totalPoints, winPoints, lossPoints,
				pendingText,
				lastSignalType, lastSignalBarNumber < 0 ? "NA" : lastSignalBarNumber.ToString(),
				lastFlow, lastShark, sharkAlignBars,
				upBoxes, downBoxes, e1BuyArmed, e1SellArmed, e2BuyArmed, e2SellArmed,
				cycleHigh, cycleLow);

			Draw.TextFixed(this, "FlowCycleResults", text, ResultsPosition, Brushes.LightGray,
				new SimpleFont("Arial", 12), Brushes.Transparent, Brushes.Transparent, 0);
		}

		private double ComputeTradeStop(bool isBuy, bool isEtapa2)
		{
			double pointScale = GetPointScale();
			double stopFallback = StopPoints * pointScale;
			if (UseFixedTargetsStops)
				return isBuy ? tradeEntry - stopFallback : tradeEntry + stopFallback;
			if (!UseDynamicStops)
				return isBuy ? tradeEntry - stopFallback : tradeEntry + stopFallback;

			double signalStop = ComputeSignalStop(isBuy, isEtapa2);
			if (double.IsNaN(signalStop))
				return isBuy ? tradeEntry - stopFallback : tradeEntry + stopFallback;

			if (isBuy && signalStop >= tradeEntry)
				return tradeEntry - stopFallback;
			if (!isBuy && signalStop <= tradeEntry)
				return tradeEntry + stopFallback;

			return signalStop;
		}

		private double ComputeSignalStop(bool isBuy, bool isEtapa2)
		{
			return isEtapa2 ? CalculateEtapa2Stop(isBuy) : CalculateEtapa1Stop(isBuy);
		}

		private double CalculateEtapa1Stop(bool isBuy)
		{
			int swingWindow = Math.Min(SwingLookback, CurrentBar + 1);
			if (swingWindow < 2)
				return double.NaN;

			double basePrice;
			if (!double.IsNaN(cycleLow) && !double.IsNaN(cycleHigh) && cycleSign != 0)
				basePrice = isBuy ? cycleLow : cycleHigh;
			else
				basePrice = isBuy ? GetSeriesMin(Low, swingWindow) : GetSeriesMax(High, swingWindow);

			double extra = StopExtraTicks * TickSize;
			double rawStop = isBuy ? basePrice - extra : basePrice + extra;

			if (StopMaxBoxes > 0)
			{
				double boxSize = GetBoxSize();
				if (boxSize > 0)
				{
					double maxBoxMove = StopMaxBoxes * boxSize;
					rawStop = isBuy ? Math.Max(rawStop, basePrice - maxBoxMove) : Math.Min(rawStop, basePrice + maxBoxMove);
				}
			}

			return rawStop;
		}

		private double CalculateEtapa2Stop(bool isBuy)
		{
			int needed = 2;
			int count = 0;
			int targetDir = isBuy ? 1 : -1;
			for (int barsAgo = 1; barsAgo <= CurrentBar; barsAgo++)
			{
				if (GetBoxDirection(barsAgo) != targetDir)
					continue;

				count++;
				if (count == needed)
				{
					double basePrice = isBuy ? Low[barsAgo] : High[barsAgo];
					double extra = StopExtraTicks * TickSize;
					return isBuy ? basePrice - extra : basePrice + extra;
				}
			}

			return double.NaN;
		}

		private void DrawStopIfEnabled(bool isBuy, bool isEtapa2)
		{
			if (!ShowStops)
				return;
			double stopPrice = ComputeSignalStop(isBuy, isEtapa2);
			if (double.IsNaN(stopPrice))
				return;

		}

		private double GetPointScale()
		{
			if (Instrument != null && Instrument.MasterInstrument != null)
			{
				string name = Instrument.MasterInstrument.Name;
				if (!string.IsNullOrWhiteSpace(name) && name.Equals("GC", StringComparison.OrdinalIgnoreCase))
					return 0.2;
			}

			return 1.0;
		}

		private double ToPoints(double priceDelta)
		{
			double scale = GetPointScale();
			if (scale <= 0.0)
				return priceDelta;
			return priceDelta / scale;
		}

		private void ArmPendingEntry(bool isBuy, bool isEtapa2, double entryPrice, string signalType)
		{
			pendingEntry = true;
			pendingIsBuy = isBuy;
			pendingIsEtapa2 = isEtapa2;
			pendingEntryPrice = entryPrice;
			pendingSignalBar = CurrentBar;
			pendingSignalType = signalType;
			LogEvent(string.Format("PENDING {0} entry={1:F2} timeout={2}", pendingSignalType, pendingEntryPrice, EntryTimeoutBars));
		}

		private bool TryFillPending()
		{
			if (!pendingEntry)
				return false;
			if (CurrentBar <= pendingSignalBar)
				return false;

			bool filled = pendingIsBuy ? Low[0] <= pendingEntryPrice : High[0] >= pendingEntryPrice;
			if (filled)
			{
				StartTrade(pendingIsBuy, pendingIsEtapa2, pendingEntryPrice, pendingSignalType, GetEntryModeLabel(pendingIsEtapa2));
				pendingEntry = false;
				return true;
			}

			if (EntryTimeoutBars > 0 && CurrentBar - pendingSignalBar >= EntryTimeoutBars)
			{
				LogEvent(string.Format("PENDING_CANCEL {0} waited={1}", pendingSignalType, CurrentBar - pendingSignalBar));
				pendingEntry = false;
			}

			return false;
		}

		[Browsable(false)]
		[XmlIgnore]
		public Series<double> FlowLine => Values[0];

		[Browsable(false)]
		[XmlIgnore]
		public Series<double> SharkLine => Values[1];

		[NinjaScriptProperty]
		[Display(Name = "Enable Etapa 1", Order = 1, GroupName = "Signals")]
		public bool EnableEtapa1 { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Enable Etapa 2", Order = 2, GroupName = "Signals")]
		public bool EnableEtapa2 { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Require Shark Align", Order = 3, GroupName = "Signals")]
		public bool RequireSharkAlign { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Require Slope", Order = 4, GroupName = "Signals")]
		public bool RequireSlope { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Require Shark Slope", Order = 5, GroupName = "Signals")]
		public bool RequireSharkSlope { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Require Shark Confirm Etapa1", Order = 6, GroupName = "Signals")]
		public bool RequireSharkConfirmEtapa1 { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Require Flow/Shark Convergence", Order = 7, GroupName = "Signals")]
		public bool RequireFlowSharkConvergence { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Max Flow/Shark Gap", Order = 8, GroupName = "Signals")]
		[Range(0, 12)]
		public double MaxFlowSharkGap { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Min Cycle Range Boxes", Order = 9, GroupName = "Signals")]
		[Range(0, 20)]
		public int MinCycleRangeBoxes { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Min Flow Delta", Order = 10, GroupName = "Signals")]
		[Range(0, 12)]
		public double MinFlowDelta { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Min Shark Delta", Order = 11, GroupName = "Signals")]
		[Range(0, 12)]
		public double MinSharkDelta { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Min Shark Strength", Order = 12, GroupName = "Signals")]
		[Range(0, 12)]
		public double MinSharkStrength { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Use FPLEME Confirm", Order = 1, GroupName = "Confirmations")]
		public bool UseFplemeConfirm { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "FPLEME Min Level", Order = 2, GroupName = "Confirmations")]
		[Range(0, 12)]
		public double FplemeMinLevel { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "FPLEME Min Shark", Order = 3, GroupName = "Confirmations")]
		[Range(0, 12)]
		public double FplemeMinShark { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "FPLEME Etapa1 Filter", Order = 4, GroupName = "Confirmations")]
		public bool UseFplemeEtapa1Filter { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Use MAPS Wall Filter", Order = 5, GroupName = "Confirmations")]
		public bool UseMapsWallFilter { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Maps Wall Neutral Ticks", Order = 6, GroupName = "Confirmations")]
		[Range(0, 50)]
		public int MapsWallNeutralTicks { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Allow Wall Neutral", Order = 7, GroupName = "Confirmations")]
		public bool AllowWallNeutral { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Use Map0 Bias", Order = 8, GroupName = "Confirmations")]
		public bool UseMap0Bias { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Map0 Tolerance Ticks", Order = 9, GroupName = "Confirmations")]
		[Range(0, 50)]
		public int Map0ToleranceTicks { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Use VX Wall Direction", Order = 10, GroupName = "Confirmations")]
		public bool UseVxWallDirection { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "VX Wall Dir Threshold", Order = 11, GroupName = "Confirmations")]
		public double VxWallDirectionThreshold { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "VX Allow Neutral", Order = 12, GroupName = "Confirmations")]
		public bool VxAllowNeutral { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "VX Etapa2 Only", Order = 13, GroupName = "Confirmations")]
		public bool VxEtapa2Only { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Cooldown Bars", Order = 13, GroupName = "Signals")]
		[Range(0, 100)]
		public int CooldownBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Show Signals", Order = 14, GroupName = "Signals")]
		public bool ShowSignals { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Show Stops", Order = 15, GroupName = "Signals")]
		public bool ShowStops { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Etapa1 Min Confirm Boxes", Order = 1, GroupName = "Etapa1")]
		[Range(1, 6)]
		public int Etapa1MinConfirmBoxes { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Etapa1 Max Confirm Boxes", Order = 2, GroupName = "Etapa1")]
		[Range(1, 6)]
		public int Etapa1MaxConfirmBoxes { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Flow Window (bars)", Order = 1, GroupName = "Flow")]
		[Range(1, 50)]
		public int FlowOffset { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Shark Window (bars)", Order = 1, GroupName = "Shark")]
		[Range(1, 100)]
		public int SharkOffset { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Shark Multiplier", Order = 2, GroupName = "Shark")]
		public double SharkMultiplier { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Shark Confirm Bars", Order = 3, GroupName = "Shark")]
		[Range(1, 10)]
		public int SharkConfirmBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Warmup Bars", Order = 1, GroupName = "Normalization")]
		[Range(50, 2000)]
		public int NormPeriod { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Normalization Scale", Order = 2, GroupName = "Normalization")]
		[Range(4, 50)]
		public int NormScale { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Min Bars", Order = 3, GroupName = "Normalization")]
		[Range(50, 2000)]
		public int MinBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Allow Early Signals", Order = 4, GroupName = "Normalization")]
		public bool AllowEarlySignals { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Require 2nd Cycle (E2)", Order = 1, GroupName = "Filters")]
		public bool RequireSecondCycle { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Allow Equal Cycle", Order = 2, GroupName = "Filters")]
		public bool AllowEqualCycle { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Min 2nd Cycle Boxes", Order = 3, GroupName = "Filters")]
		[Range(0, 10)]
		public int MinSecondCycleDeltaBoxes { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Apply 2nd Cycle to Etapa1", Order = 4, GroupName = "Filters")]
		public bool ApplySecondCycleToEtapa1 { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Entry Mode", Order = 1, GroupName = "Execution")]
		public FlowEntryMode EntryModeSetting { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Etapa2 Timing", Order = 2, GroupName = "Execution")]
		public Etapa2TimingMode Etapa2TimingSetting { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Entry Timeout Bars", Order = 3, GroupName = "Execution")]
		[Range(1, 20)]
		public int EntryTimeoutBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Signal Threshold", Order = 1, GroupName = "Thresholds")]
		[Range(1, 12)]
		public int SignalThreshold { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Signal Extreme", Order = 2, GroupName = "Thresholds")]
		[Range(4, 12)]
		public int SignalExtreme { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Extreme No Start Level", Order = 3, GroupName = "Thresholds")]
		[Range(4, 12)]
		public int ExtremeNoStartLevel { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Use Dynamic Stops", Order = 0, GroupName = "Stops")]
		public bool UseDynamicStops { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Swing Lookback", Order = 1, GroupName = "Stops")]
		[Range(2, 20)]
		public int SwingLookback { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Stop Extra Ticks", Order = 2, GroupName = "Stops")]
		[Range(0, 10)]
		public int StopExtraTicks { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Stop Max Boxes", Order = 3, GroupName = "Stops")]
		[Range(0, 5)]
		public int StopMaxBoxes { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Use Fixed TP/SL", Order = 0, GroupName = "TP_SL")]
		public bool UseFixedTargetsStops { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Target Points", Order = 1, GroupName = "TP_SL")]
		[Range(1, 100)]
		public int TargetPoints { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Stop Points", Order = 2, GroupName = "TP_SL")]
		[Range(1, 100)]
		public int StopPoints { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Assume Stop on Ambiguous", Order = 3, GroupName = "TP_SL")]
		public bool AssumeStopOnAmbiguous { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Show Stats", Order = 4, GroupName = "TP_SL")]
		public bool ShowStats { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Show Outcome Marks", Order = 5, GroupName = "TP_SL")]
		public bool ShowOutcomeMarks { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Stats Position", Order = 6, GroupName = "TP_SL")]
		public TextPosition StatsPosition { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Show Results Panel", Order = 1, GroupName = "Debug")]
		public bool ShowResultsPanel { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Results Position", Order = 2, GroupName = "Debug")]
		public TextPosition ResultsPosition { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Enable Trade Log", Order = 3, GroupName = "Debug")]
		public bool EnableTradeLog { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Show Trade Levels", Order = 4, GroupName = "Debug")]
		public bool ShowTradeLevels { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Show Trade Markers", Order = 5, GroupName = "Debug")]
		public bool ShowTradeMarkers { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Enable CSV Log", Order = 6, GroupName = "Debug")]
		public bool EnableCsvLog { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Use Timestamped CSV", Order = 7, GroupName = "Debug")]
		public bool UseTimestampedCsv { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "CSV File Name", Order = 8, GroupName = "Debug")]
		public string CsvFileName { get; set; }
	}
}
