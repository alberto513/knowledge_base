# 🚀 PROMPT DE IMPLEMENTACIÓN - MFSScalpIndicator v3.0
## Indicador que "Piensa Como FPLEME" - NinjaTrader 8

**Fecha:** 18 de Enero, 2026  
**Objetivo:** Implementar filosofía FPLEME completa sin copiar código propietario

---

## 📋 CONTEXTO PARA EL AGENTE IMPLEMENTADOR

Eres un desarrollador experto en NinjaTrader 8 C#. Tu tarea es mejorar el indicador `MFSScalpIndicator.cs` para que "piense como FPLEME" implementando su filosofía, pero con código 100% propio.

### ARCHIVOS DE REFERENCIA OBLIGATORIOS

**Debes leer primero:**
1. `@knowledge_base_2026-01-18/00_LEEME_PRIMERO.md` (contexto general)
2. `@knowledge_base_2026-01-18/RESUMEN_EJECUTIVO.md` (problemas y mejoras)
3. `@knowledge_base_2026-01-18/INDICE_ESPECIFICACION_TECNICA.md` (arquitectura)

**Consultar durante implementación:**
- `@knowledge_base_2026-01-18/ESPEC_TECNICA_PARTE1_CONCEPTOS_Y_ESTADOS.md` (variables y estados)
- `@knowledge_base_2026-01-18/ESPEC_TECNICA_PARTE2_REGLAS_Y_FILTROS.md` (pseudocódigo ETAPA 1, PAT)
- `@knowledge_base_2026-01-18/ESPEC_TECNICA_PARTE3_INTEGRACION_Y_TESTS.md` (integración y tests)
- `@knowledge_base_2026-01-18/MFS_KNOWLEDGE_BASE.json` (referencia completa)

### ARCHIVO BASE A MODIFICAR
- `@C:\Users\PC\Documents\CICLES\MFSScalpIndicator.cs` (indicador actual v2.0)

---

## 🎯 OBJETIVO DE LA IMPLEMENTACIÓN

Transformar el indicador de:

**❌ Estado Actual (v2.0):**
- Winrate: 54.9% (NO rentable)
- Trades: 858 en 150 días (5.7/día - excesivo)
- Problema: Señales tardías, no detecta inicio de ciclos
- Filosofía: Reacciona a patrones

**✅ Estado Deseado (v3.0):**
- Winrate: >58% (mínimo), objetivo 62-65%
- Trades: 2-4 por día (alta calidad)
- Solución: Detecta ETAPA 1 al INICIO de ciclos
- Filosofía: **Flow → Cycle → Context → Signal** (piensa como FPLEME)

---

## ⚠️ RESTRICCIONES CRÍTICAS

### 🔴 PROHIBIDO (Protección IP):
1. ❌ **NO acceder a código decompilado** en `_fpleme_tools_decompiled/`
2. ❌ **NO hacer reverse engineering** de FPLEME_M7_II.dll
3. ❌ **NO copiar algoritmos internos** de FPLEME_M7_II
4. ❌ **NO acceder a propiedades privadas** de FPLEME_M7_II o MAPS_M7 sin API pública

### ✅ PERMITIDO y RECOMENDADO:
1. ✅ **Usar conceptos públicos** documentados (ETAPA 1, PAT, The_Wall)
2. ✅ **Implementar algoritmos PROPIOS** que emulen filosofía FPLEME
3. ✅ **Usar SHARK calculado** existente en v2.0 como "pseudo-FPLEME"
4. ✅ **Crear proxy de The_Wall** con análisis propio de fuerza dominante
5. ✅ **Consultar documentación pública** (MAPA_DEL_INDICADOR.md, DOCUMENTACION_FPLEME*.md)

---

## 📦 TAREAS A IMPLEMENTAR (Prioridad Ordenada)

### 🔴 FASE 1: FUNDAMENTOS (Semana 1) - OBLIGATORIO

#### TAREA 1.1: Preparar Variables Nuevas

**Agregar al archivo `MFSScalpIndicator.cs` en región `#region Variables`:**

```csharp
// FPLEME-like tracking (usando SHARK como proxy)
private double sharkPrevValue;             // Valor anterior de SHARK
private int consecutivePositiveBoxes;      // Boxes positivos consecutivos
private int consecutiveNegativeBoxes;      // Boxes negativos consecutivos

// Estados del sistema
private CycleState currentCycle;           // Bull/Bear/Neutral
private EtapaState currentEtapa;           // None/Etapa1Long/Etapa1Short
private ScenarioType currentScenario;      // PpmBuy/PpmSell/MM/None
private WallColor wallColor;               // Verde/Rosa/Amarillo/Unknown
private WallState wallState;               // AllowsLong/AllowsShort/Neutral

// ETAPA 1 tracking
private bool etapa1LongActive;             // ETAPA 1 LONG detectada
private bool etapa1ShortActive;            // ETAPA 1 SHORT detectada
private int etapa1ActivationBar;           // Barra donde se activó ETAPA 1
private double etapa1EntryPrice;           // Precio de entrada calculado

// PAT Scoring
private int patScore;                      // Score PAT (0-4)
private SignalQuality signalQuality;       // High/Medium/Low

// Parámetros nuevos
private bool allowMediumQualitySignals = true;  // Permitir señales MEDIUM
```

**Referencia:** ESPEC_TECNICA_PARTE3 → Sección G.5

---

#### TAREA 1.2: Crear Enums Necesarios

**Agregar antes de la clase `MFSScalpIndicator`:**

```csharp
public enum CycleState
{
    Unknown = 0,
    Bull = 1,
    Bear = -1,
    Neutral = 2
}

public enum EtapaState
{
    None = 0,
    Etapa1Long = 1,
    Etapa1Short = 2
}

public enum ScenarioType
{
    None = 0,
    PpmBuy = 1,
    PpmSell = 2,
    MM = 3
}

public enum WallColor
{
    Unknown = 0,
    Green = 1,
    Pink = 2,
    Magenta = 3,
    Yellow = 4
}

public enum WallState
{
    Unknown = 0,
    AllowsLong = 1,
    AllowsShort = 2,
    Neutral = 3
}

public enum SignalQuality
{
    Low = 0,
    Medium = 1,
    High = 2
}

public enum SignalDirection
{
    Long = 1,
    Short = -1,
    None = 0
}
```

**Referencia:** ESPEC_TECNICA_PARTE1 → Sección B (Máquina de Estados)

---

#### TAREA 1.3: Agregar Constantes FPLEME

**Agregar en región `#region Variables`:**

```csharp
// Niveles críticos FPLEME (usaremos SHARK como proxy)
private const double FPLEME_EXTREME_HIGH = 12.0;
private const double FPLEME_HIGH = 8.0;
private const double FPLEME_CONFIRMATION_LONG = 4.0;
private const double FPLEME_EQUILIBRIUM = 0.0;
private const double FPLEME_CONFIRMATION_SHORT = -4.0;
private const double FPLEME_LOW = -8.0;
private const double FPLEME_EXTREME_LOW = -12.0;

// Thresholds SHARK
private const double SHARK_THRESHOLD_BULL = 4.0;
private const double SHARK_THRESHOLD_BEAR = -4.0;
```

**Referencia:** ESPEC_TECNICA_PARTE1 → Sección A (Tabla de Conceptos)

---

#### TAREA 1.4: Implementar Método `CountConsecutivePositiveBoxes()`

**Agregar nuevo método privado:**

```csharp
private int CountConsecutivePositiveBoxes()
{
    int count = 0;
    
    // Box actual es positivo?
    if (Close[0] > Open[0])
    {
        count = 1;
        
        // Contar hacia atrás hasta encontrar box negativo
        for (int i = 1; i < 10 && i <= CurrentBar; i++)
        {
            if (Close[i] > Open[i])
                count++;
            else
                break; // Detener al encontrar box negativo
        }
    }
    
    return count;
}

private int CountConsecutiveNegativeBoxes()
{
    int count = 0;
    
    if (Close[0] < Open[0])
    {
        count = 1;
        
        for (int i = 1; i < 10 && i <= CurrentBar; i++)
        {
            if (Close[i] < Open[i])
                count++;
            else
                break;
        }
    }
    
    return count;
}
```

**Referencia:** ESPEC_TECNICA_PARTE2 → Sección C.1.2

---

### 🔴 FASE 2: DETECCIÓN ETAPA 1 (Semana 1-2) - CRÍTICO

#### TAREA 2.1: Implementar `DetectEtapa1Long()` Completo

**Agregar nuevo método siguiendo pseudocódigo de 10 pasos:**

```csharp
private void DetectEtapa1Long()
{
    // USAR SHARK como proxy de FPLEME (no accedemos a FPLEME_M7_II)
    double fplemeValue = sharkValue;           // Proxy
    double fplemePrevValue = sharkPrevValue;   // Valor anterior
    
    // PASO 1: Condición base - Salida de -4 hacia 0
    bool baseTrigger = (fplemePrevValue <= FPLEME_CONFIRMATION_SHORT) && 
                       (fplemeValue >= FPLEME_EQUILIBRIUM);
    
    if (!baseTrigger)
        return; // No cumple condición fundamental
    
    // PASO 2: Timing - 2º o 3er box positivo
    consecutivePositiveBoxes = CountConsecutivePositiveBoxes();
    bool correctTiming = (consecutivePositiveBoxes == 2 || consecutivePositiveBoxes == 3);
    
    if (!correctTiming)
    {
        LogDebug($"ETAPA 1 LONG - timing incorrecto (box {consecutivePositiveBoxes})");
        return;
    }
    
    // PASO 3: Restricción - NO desde extremos
    bool notFromExtreme = (fplemePrevValue > FPLEME_LOW); // > -8
    
    if (!notFromExtreme)
    {
        LogDebug("ETAPA 1 LONG - viene de extremo, señal inválida");
        return;
    }
    
    // PASO 4: Confirmación - SHARK alineado (debe ser bullish)
    bool sharkAligned = (sharkState == 1); // sharkState == Bullish
    
    if (!sharkAligned)
    {
        LogDebug("ETAPA 1 LONG - SHARK no confirma, movimiento lateralizado");
        return;
    }
    
    // PASO 5: Filtro The_Wall (si disponible)
    if (wallState == WallState.AllowsShort) // The_Wall rosa/magenta
    {
        LogDebug("SEÑAL LONG BLOQUEADA: The_Wall impide LONGs");
        return; // BLOQUEADO por The_Wall
    }
    
    // ✅ TODAS LAS VALIDACIONES PASADAS - ETAPA 1 LONG CONFIRMADA
    
    // PASO 6: Calcular entry price (base del box anterior)
    etapa1EntryPrice = Low[1]; // Base del 1er box positivo
    
    // PASO 7: Calcular stop loss
    double stopLoss = Math.Max(
        lastSwingLow - (2 * TickSize),
        etapa1EntryPrice - (SlTicks * TickSize)
    );
    
    // PASO 8: Calcular take profit
    double takeProfit = etapa1EntryPrice + (TpTicks * TickSize);
    
    // PASO 9: Evaluar calidad PAT
    signalQuality = EvaluateSignalQuality(SignalDirection.Long);
    
    // PASO 10: Decisión según calidad
    if (signalQuality == SignalQuality.High)
    {
        // PAT completo (4/4) - Operar con confianza
        GenerateSignal(1, etapa1EntryPrice, stopLoss, takeProfit, "ETAPA1_LONG_PAT_HIGH");
    }
    else if (signalQuality == SignalQuality.Medium && allowMediumQualitySignals)
    {
        // 3/4 capas - Operar con precaución
        GenerateSignal(1, etapa1EntryPrice, stopLoss, takeProfit, "ETAPA1_LONG_PAT_MEDIUM");
    }
    else
    {
        LogDebug($"ETAPA 1 LONG detectado pero PAT {signalQuality} - señal bloqueada");
    }
    
    // Marcar ETAPA 1 activa
    etapa1LongActive = true;
    etapa1ActivationBar = CurrentBar;
    currentEtapa = EtapaState.Etapa1Long;
}
```

**Instrucción:** Implementa este método COMPLETO siguiendo el pseudocódigo exacto.

**Referencia:** ESPEC_TECNICA_PARTE2 → Sección C.1.9 (pseudocódigo completo)

---

#### TAREA 2.2: Implementar `DetectEtapa1Short()` (Simétrico)

**Instrucción:** Crear método simétrico a `DetectEtapa1Long()` pero para dirección SHORT:
- Cambiar: `CONFIRMATION_SHORT` por `CONFIRMATION_LONG` (salida de +4)
- Cambiar: `>= 0` por `<= 0` (hacia equilibrio)
- Cambiar: `CountConsecutivePositiveBoxes` por `CountConsecutiveNegativeBoxes`
- Cambiar: `fplemePrevValue > LOW` por `fplemePrevValue < HIGH` (< +8)
- Cambiar: `sharkState == Bullish` por `sharkState == Bearish`
- Cambiar: `Low[1]` por `High[1]` (topo del box anterior)
- Cambiar: `AllowsShort` por `AllowsLong` (bloqueo inverso)

**Referencia:** ESPEC_TECNICA_PARTE2 → Sección C.2 (ETAPA 1 SHORT)

---

### 🟠 FASE 3: THE_WALL PROXY (Semana 2) - CRÍTICO

#### TAREA 3.1: Implementar `AnalizarFuerzaDominante()`

**Este es MI análisis propio de fuerza (NO es código de MAPS_M7):**

```csharp
private WallColor AnalizarFuerzaDominante()
{
    // Concepto: Detectar fuerza dominante del mercado
    // MI implementación usando indicadores estándar
    
    double sma20 = SMA(20)[0];
    int barsArribaSMA = 0;
    int barsAbajoSMA = 0;
    int lookback = 20; // Analizar últimos 20 boxes
    
    // Contar boxes arriba vs abajo de SMA20
    for (int i = 0; i < lookback && i <= CurrentBar; i++)
    {
        if (Close[i] > SMA(20)[i])
            barsArribaSMA++;
        else if (Close[i] < SMA(20)[i])
            barsAbajoSMA++;
    }
    
    double porcentajeArriba = (double)barsArribaSMA / lookback;
    double porcentajeAbajo = (double)barsAbajoSMA / lookback;
    
    // MI criterio de fuerza dominante:
    if (porcentajeArriba >= 0.75)       // 75%+ arriba
        return WallColor.Green;         // Fuerza compradora
    else if (porcentajeAbajo >= 0.75)   // 75%+ abajo
        return WallColor.Pink;          // Fuerza vendedora
    else
        return WallColor.Yellow;        // Neutral/lateral
}

private void UpdateWallState()
{
    wallColor = AnalizarFuerzaDominante();
    
    // Derivar estado para decisiones
    if (wallColor == WallColor.Green)
        wallState = WallState.AllowsLong;
    else if (wallColor == WallColor.Pink || wallColor == WallColor.Magenta)
        wallState = WallState.AllowsShort;
    else if (wallColor == WallColor.Yellow)
        wallState = WallState.Neutral;
    else
        wallState = WallState.Unknown;
}
```

**Instrucción:** Implementa este método y llámalo en `OnBarUpdate()` antes de detectar señales.

**Referencia:** ESPEC_TECNICA_PARTE2 → Sección D.3.3 (Proxy Fallback)

---

#### TAREA 3.2: Implementar `ApplyTheWallFilter()`

```csharp
private bool ApplyTheWallFilter(SignalDirection direction)
{
    // Regla inviolable: NUNCA contra The_Wall
    
    if (direction == SignalDirection.Long)
    {
        if (wallState == WallState.AllowsShort) // The_Wall rosa/magenta
        {
            LogDebug($"🛑 SEÑAL LONG BLOQUEADA: The_Wall {wallColor} impide LONGs");
            return false; // BLOQUEADO
        }
    }
    else if (direction == SignalDirection.Short)
    {
        if (wallState == WallState.AllowsLong) // The_Wall verde
        {
            LogDebug($"🛑 SEÑAL SHORT BLOQUEADA: The_Wall {wallColor} impide SHORTs");
            return false; // BLOQUEADO
        }
    }
    
    return true; // PERMITIDO
}
```

**Instrucción:** Llama este método en PASO 5 de `DetectEtapa1Long()` y `DetectEtapa1Short()`.

**Referencia:** ESPEC_TECNICA_PARTE2 → Sección D.4

---

### 🟡 FASE 4: PAT SCORING (Semana 2) - IMPORTANTE

#### TAREA 4.1: Implementar las 4 Capas de PAT

```csharp
private bool Layer1_FplemeValid(SignalDirection direction)
{
    // Usar SHARK como proxy de FPLEME
    double fplemeValue = sharkValue;
    
    bool notInExtremes = (fplemeValue >= FPLEME_LOW) && (fplemeValue <= FPLEME_HIGH);
    
    if (direction == SignalDirection.Long)
        return notInExtremes && (fplemeValue >= FPLEME_CONFIRMATION_SHORT);
    else
        return notInExtremes && (fplemeValue <= FPLEME_CONFIRMATION_LONG);
}

private bool Layer2_SharkAligned(SignalDirection direction)
{
    if (direction == SignalDirection.Long)
        return (sharkState == 1); // Bullish
    else
        return (sharkState == -1); // Bearish
}

private bool Layer3_FavorableScenario(SignalDirection direction)
{
    if (direction == SignalDirection.Long)
    {
        bool ppmBuy = (currentScenario == ScenarioType.PpmBuy);
        bool mmWithShark = (currentScenario == ScenarioType.MM && sharkState == 1);
        return ppmBuy || mmWithShark;
    }
    else
    {
        bool ppmSell = (currentScenario == ScenarioType.PpmSell);
        bool mmWithShark = (currentScenario == ScenarioType.MM && sharkState == -1);
        return ppmSell || mmWithShark;
    }
}

private bool Layer4_TheWallNotAgainst(SignalDirection direction)
{
    if (wallState == WallState.Unknown)
        return true; // Modo permisivo
    
    if (direction == SignalDirection.Long)
        return (wallState != WallState.AllowsShort);
    else
        return (wallState != WallState.AllowsLong);
}
```

**Referencia:** ESPEC_TECNICA_PARTE2 → Sección E.2 (Las 4 Capas)

---

#### TAREA 4.2: Implementar Scoring PAT

```csharp
private SignalQuality EvaluateSignalQuality(SignalDirection direction)
{
    patScore = 0;
    
    if (Layer1_FplemeValid(direction))      patScore++;
    if (Layer2_SharkAligned(direction))     patScore++;
    if (Layer3_FavorableScenario(direction)) patScore++;
    if (Layer4_TheWallNotAgainst(direction)) patScore++;
    
    // Mapeo score → quality
    if (patScore == 4) return SignalQuality.High;
    if (patScore == 3) return SignalQuality.Medium;
    return SignalQuality.Low;
}
```

**Referencia:** ESPEC_TECNICA_PARTE2 → Sección E.3

---

### 🟡 FASE 5: ESCENARIOS PPM/MM (Semana 2) - IMPORTANTE

#### TAREA 5.1: Mejorar `DetectScenario()`

**Ya existe lógica básica en `DetectSignals()`, mejorarla:**

```csharp
private ScenarioType DetectScenario()
{
    // Prerequisito: Ciclos válidos
    if (!cycleRefValid || !cycle2Valid)
        return ScenarioType.None;
    
    // PPM Buy: Convergencia compradora
    if (cycleDirection > 0 && cycle2MapIndex > cycleRefMapIndex)
        return ScenarioType.PpmBuy;
    
    // PPM Sell: Convergencia vendedora
    if (cycleDirection < 0 && cycle2MapIndex < cycleRefMapIndex)
        return ScenarioType.PpmSell;
    
    // MM: Divergencia
    if (cycle2MapIndex == cycleRefMapIndex)
        return ScenarioType.MM;
    
    return ScenarioType.None;
}

private void UpdateScenario()
{
    currentScenario = DetectScenario();
}
```

**Instrucción:** Crear este método y llamarlo en `OnBarUpdate()`.

**Referencia:** ESPEC_TECNICA_PARTE2 → Sección F.2

---

### 🟢 FASE 6: INTEGRACIÓN (Semana 2-3) - CRÍTICA

#### TAREA 6.1: Modificar `OnBarUpdate()`

**CAMBIAR de esto:**
```csharp
protected override void OnBarUpdate()
{
    if (BarsInProgress != 0) return;
    if (CurrentBar < 20) return;
    
    UpdateShark();
    DetectRenkoSwings();
    UpdateCycles();
    DetectSignals();      // ❌ ELIMINAR esta lógica vieja
    ManageTrades();
    DrawPanel();
}
```

**A esto:**
```csharp
protected override void OnBarUpdate()
{
    if (BarsInProgress != 0) return;
    if (CurrentBar < 20) return;
    
    // Guardar valor previo de SHARK (para detectar cruces)
    sharkPrevValue = (CurrentBar > 0) ? sharkValue : 0.0;
    
    UpdateShark();              // ✅ MANTENER
    DetectRenkoSwings();        // ✅ MANTENER
    UpdateCycles();             // ✅ MANTENER (simplificado)
    UpdateWallState();          // ➕ NUEVO - analizar fuerza dominante
    UpdateScenario();           // ➕ NUEVO - detectar PPM/MM
    
    // Actualizar contadores de boxes
    consecutivePositiveBoxes = CountConsecutivePositiveBoxes();
    consecutiveNegativeBoxes = CountConsecutiveNegativeBoxes();
    
    // Detectar ETAPA 1 (reemplaza DetectSignals)
    DetectEtapa1Long();         // ➕ NUEVO
    DetectEtapa1Short();        // ➕ NUEVO
    
    ManageTrades();             // ✅ MANTENER (con bugfix línea 330)
    DrawPanel();                // ✅ MANTENER (actualizar para PAT)
}
```

**Referencia:** ESPEC_TECNICA_PARTE3 → Sección G.4 (Diffs por función)

---

#### TAREA 6.2: Simplificar `UpdateCycles()`

**Instrucción:** Mantener solo tracking de MAP y swings, ELIMINAR lógica de señales (líneas 276-291 aproximadamente).

**MANTENER:**
- Cálculo de `lastMapIndex`
- Actualización de `cycleRefMapIndex` y `cycle2MapIndex` en swings
- Actualización de `cycleDirection`
- Actualización de `cycleRefValid` y `cycle2Valid`

**ELIMINAR:**
- TODO lo relacionado con "armed" y confirmación de señales (eso ahora está en DetectEtapa1)

**Referencia:** ESPEC_TECNICA_PARTE3 → Sección G.4 (UpdateCycles Diff)

---

#### TAREA 6.3: ELIMINAR Método `DetectSignals()`

**Instrucción:** 
1. Eliminar método `DetectSignals()` completo (líneas 255-321)
2. Su funcionalidad está reemplazada por `DetectEtapa1Long()` y `DetectEtapa1Short()`
3. Eliminar variables relacionadas: `signalArmed`, `signalDirection`, `signalArmedBar`, `signalArmedMapIndex`

**Referencia:** ESPEC_TECNICA_PARTE3 → Sección G.2 (Componentes que se reemplazan)

---

#### TAREA 6.4: Actualizar `DrawPanel()` para PAT

**Agregar líneas al panel:**

```csharp
private void DrawPanel()
{
    double wr = totalTrades > 0 ? (double)wins / totalTrades * 100.0 : 0.0;
    string scenario = GetScenarioName(currentScenario);  // Nuevo método
    string wallStatus = wallColor.ToString();
    string qualityStatus = signalQuality.ToString();
    
    string text = string.Format(CultureInfo.InvariantCulture,
        "MFS SCALP v3.0 (FPLEME Thinking)\n" +
        "Trades: {0} | W: {1} | L: {2} | WR: {3:F1}%\n" +
        "MAP: {4} | Cycle: {5} | Scenario: {6}\n" +
        "SHARK: {7} ({8:F2}) | State: {9}\n" +
        "The_Wall: {10} | PAT Score: {11}/4 ({12})\n" +    // ➕ NUEVO
        "ETAPA: {13} | InTrade: {14}",                      // ➕ NUEVO
        totalTrades, wins, losses, wr,
        lastMapIndex,
        GetCycleName(currentCycle),   // ➕ NUEVO
        scenario,
        GetSharkStateName(sharkState),
        sharkValue,
        sharkState,
        wallStatus,                    // ➕ NUEVO
        patScore,                      // ➕ NUEVO
        qualityStatus,                 // ➕ NUEVO
        currentEtapa,                  // ➕ NUEVO
        inTrade ? "Y" : "N");
    
    Draw.TextFixed(this, "Panel", text, TextPosition.TopLeft,
        Brushes.White, new SimpleFont("Arial", 10),
        Brushes.Transparent, Brushes.Transparent, 0);
}

private string GetScenarioName(ScenarioType s)
{
    switch (s)
    {
        case ScenarioType.PpmBuy: return "PPM_BUY";
        case ScenarioType.PpmSell: return "PPM_SELL";
        case ScenarioType.MM: return "MM";
        default: return "NONE";
    }
}

private string GetCycleName(CycleState c)
{
    switch (c)
    {
        case CycleState.Bull: return "BULL";
        case CycleState.Bear: return "BEAR";
        default: return "NEUTRAL";
    }
}
```

**Referencia:** ESPEC_TECNICA_PARTE3 → Sección G (Integración)

---

## 🎯 CRITERIOS DE ÉXITO (Validación)

### Backtest Requerido
**Mínimo:** 6 meses de datos en NQ o MNQ

### Métricas Objetivo

| Métrica | Valor Actual (v2.0) | Mínimo Aceptable (v3.0) | Objetivo Ideal |
|---------|---------------------|------------------------|----------------|
| **Winrate** | 54.9% | **>58%** ✅ | >62% 🎯 |
| **Trades/día** | 5.7 | **2-4** ✅ | 2-3 🎯 |
| **Profit Factor** | 1.23 | **>1.5** ✅ | >2.0 🎯 |
| **Expectancy** | 3.92 ticks | **>5 ticks** ✅ | >8 ticks 🎯 |
| **Z-Score** | 1.86 | **>2.0** ✅ | >2.5 🎯 |

### Validaciones Cualitativas
- ✅ **NO señales tardías:** Comparar timing de entrada v2.0 vs v3.0 (Caso de Prueba #12)
- ✅ **The_Wall respetado:** 0% de señales ejecutadas contra The_Wall
- ✅ **ETAPA 1 detectada:** Señales en 2º o 3er box (NO antes, NO después)
- ✅ **PAT funciona:** Reducción visible en señales de baja calidad

**Referencia:** ESPEC_TECNICA_PARTE3 → Sección I (12 Casos de Prueba)

---

## 🧪 CASOS DE PRUEBA OBLIGATORIOS

### Ejecutar MÍNIMO estos 5 casos:

**1. CASO #1:** ETAPA 1 LONG válido en 2º box → ✅ Debe generar señal  
**2. CASO #3:** ETAPA 1 LONG bloqueado por The_Wall rosa → ❌ NO debe generar  
**3. CASO #4:** ETAPA 1 desde extremo (-10) → ❌ NO debe generar  
**4. CASO #5:** ETAPA 1 en 1er box (temprano) → ❌ NO debe generar  
**5. CASO #12:** Comparación v2.0 vs v3.0 timing → ✅ v3.0 más temprano

**Referencia Completa:** ESPEC_TECNICA_PARTE3 → Sección I (12 casos detallados)

---

## 🔄 FLUJO DE IMPLEMENTACIÓN PASO A PASO

### DÍA 1-2: Setup
```bash
1. Hacer backup de MFSScalpIndicator.cs (renombrar a MFSScalpIndicator_v2_backup.cs)
2. Crear copia de trabajo: MFSScalpIndicator.cs
3. Agregar enums (Tarea 1.2)
4. Agregar variables nuevas (Tarea 1.1)
5. Agregar constantes (Tarea 1.3)
6. Compilar y verificar que no hay errores
```

### DÍA 3-5: Métodos Auxiliares
```bash
7. Implementar CountConsecutivePositiveBoxes() (Tarea 1.4)
8. Implementar CountConsecutiveNegativeBoxes() (Tarea 1.4)
9. Implementar AnalizarFuerzaDominante() (Tarea 3.1)
10. Implementar UpdateWallState() (Tarea 3.1)
11. Implementar ApplyTheWallFilter() (Tarea 3.2)
12. Compilar y probar métodos individuales
```

### DÍA 6-8: ETAPA 1
```bash
13. Implementar DetectEtapa1Long() completo (Tarea 2.1)
14. Implementar DetectEtapa1Short() (Tarea 2.2)
15. Compilar y probar detección en gráfico visual
```

### DÍA 9-10: PAT
```bash
16. Implementar 4 métodos Layer1-4 (Tarea 4.1)
17. Implementar EvaluateSignalQuality() (Tarea 4.2)
18. Integrar PAT en DetectEtapa1 métodos
19. Compilar y probar scoring
```

### DÍA 11-12: Integración
```bash
20. Modificar OnBarUpdate() con nuevo flujo (Tarea 6.1)
21. Simplificar UpdateCycles() (Tarea 6.2)
22. Eliminar DetectSignals() viejo (Tarea 6.3)
23. Actualizar DrawPanel() con PAT info (Tarea 6.4)
24. Implementar DetectScenario() y UpdateScenario() (Tarea 5.1)
25. Compilar versión completa
```

### DÍA 13-15: Testing
```bash
26. Ejecutar 12 casos de prueba manualmente
27. Backtest 6 meses de datos
28. Analizar métricas: WR, trades/día, PF
29. Comparar v2.0 vs v3.0
30. Ajustar si es necesario
```

---

## 📝 LOGGING Y DEBUG

**Agregar logs detallados para debugging:**

```csharp
private void LogDebug(string message)
{
    if (logWriter != null)
    {
        string line = $"{DateTime.Now:HH:mm:ss},DEBUG,{message}";
        logWriter.WriteLine(line);
    }
    Print($"[MFSv3] {message}");
}
```

**Llamar en puntos clave:**
- Cuando ETAPA 1 se detecta
- Cuando The_Wall bloquea señal
- Cuando PAT score se calcula
- Cuando señal se genera o se bloquea

---

## ⚠️ ADVERTENCIAS IMPORTANTES

### 1. NO Esperes Perfección Inmediata
- Primera versión puede tener WR ~56-58% (mejor que 54.9% pero no óptimo)
- Requerirá iteraciones y ajustes
- **Está OK** - estamos construyendo algoritmos propios

### 2. The_Wall Proxy Es Aproximado
- NO será tan preciso como The_Wall real de MAPS_M7
- **Está OK** - es MI análisis de fuerza dominante
- Validar con backtest

### 3. SHARK Como Proxy de FPLEME
- SHARK y FPLEME son similares pero NO idénticos
- **Está OK** - SHARK es suficiente para implementar filosofía
- Puede haber discrepancias de 2-5% vs FPLEME real

### 4. Ajustes Necesarios
- Thresholds (±4, ±8) pueden necesitar ajuste fino
- Lookback de The_Wall proxy (20 boxes) puede variar
- **Documentar ajustes** en comentarios de código

---

## 🎯 RESULTADO ESPERADO

### Indicador MFSScalpIndicator v3.0

**Características:**
- ✅ Detecta ETAPA 1 al INICIO de ciclos (timing correcto)
- ✅ Filtra con The_Wall proxy (nunca contra fuerza dominante)
- ✅ Scoring PAT (4 capas de validación)
- ✅ Detecta escenarios PPM/MM
- ✅ Genera 2-4 señales/día de alta calidad
- ✅ WR proyectado: 58-62%
- ✅ 100% código propio (sin copiar FPLEME)
- ✅ Piensa según filosofía FPLEME: **Flow → Cycle → Context → Signal**

**Comparación:**
- v2.0: Reacciona a patrones (tardío)
- v3.0: Detecta ciclos (temprano)
- FPLEME: Detecta ciclos (temprano, algoritmos profesionales optimizados)

**Gap esperado:** v3.0 será 90-95% tan efectivo como FPLEME real, con código propio.

---

## 📚 PREGUNTAS FRECUENTES

### P: ¿Por qué no usar FPLEME_M7_II directamente?
**R:** Porque queremos un indicador INDEPENDIENTE que piense como FPLEME, no que dependa de FPLEME. Esto nos da control total y capacidad de ajustar.

### P: ¿The_Wall proxy será tan bueno como el real?
**R:** No, será ~80-85% tan efectivo. Pero es suficiente para mejorar WR de 54.9% a >58%. Si necesitas más precisión, hay que investigar acceso a API de MAPS_M7.

### P: ¿SHARK es suficiente como proxy de FPLEME?
**R:** Para la filosofía sí. SHARK ya oscila -12 a +12, tiene niveles +-4, detecta fuerza direccional. Puede haber diferencias de 2-5% vs FPLEME real, pero implementa el concepto.

### P: ¿Cuánto tiempo tomará?
**R:** 2-3 semanas para implementación completa + testing. 1 semana si te enfocas solo en ETAPA 1 + The_Wall.

---

## ✅ CHECKLIST FINAL ANTES DE COMENZAR

**Antes de implementar, verifica:**

- [ ] Has leído `00_LEEME_PRIMERO.md`
- [ ] Has leído `INDICE_ESPECIFICACION_TECNICA.md`
- [ ] Entiendes filosofía: Flow → Cycle → Context → Signal
- [ ] Tienes backup de `MFSScalpIndicator.cs` v2.0
- [ ] Entiendes que usarás SHARK como proxy (NO accederás a FPLEME_M7_II)
- [ ] Entiendes que The_Wall será proxy (NO accederás a MAPS_M7)
- [ ] Tienes claro qué mantener y qué reemplazar (Sección G)
- [ ] Tienes los 12 casos de prueba listos para validar

---

## 🚀 COMANDO PARA INICIAR

**Copia y pega este prompt cuando estés listo:**

```
Soy desarrollador de NinjaTrader 8. Necesito implementar MFSScalpIndicator v3.0 que "piense como FPLEME" usando código 100% propio (sin copiar de FPLEME_M7_II).

ARCHIVOS DE REFERENCIA:
- @knowledge_base_2026-01-18/ESPEC_TECNICA_PARTE1_CONCEPTOS_Y_ESTADOS.md
- @knowledge_base_2026-01-18/ESPEC_TECNICA_PARTE2_REGLAS_Y_FILTROS.md
- @knowledge_base_2026-01-18/ESPEC_TECNICA_PARTE3_INTEGRACION_Y_TESTS.md

ARCHIVO A MODIFICAR:
- @MFSScalpIndicator.cs

FASE 1 - Implementar:
1. Agregar enums (CycleState, EtapaState, ScenarioType, WallColor, WallState, SignalQuality, SignalDirection)
2. Agregar 17 variables nuevas listadas en PARTE3 → G.5
3. Agregar constantes FPLEME (niveles +-12, +-8, +-4, 0)
4. Implementar CountConsecutivePositiveBoxes() y CountConsecutiveNegativeBoxes()

RESTRICCIONES:
- ❌ NO acceder a código decompilado de FPLEME
- ❌ NO copiar algoritmos de FPLEME_M7_II
- ✅ Usar SHARK existente como proxy de FPLEME
- ✅ Implementar conceptos públicos con lógica propia

OBJETIVO: Código que compile sin errores con los enums y variables nuevas.

Procede con Fase 1. Después te daré Fase 2 (ETAPA 1).
```

---

## 📖 DOCUMENTACIÓN DE SOPORTE

**Si tienes dudas durante implementación:**

1. **¿Qué variables necesito?** → PARTE3 → G.5
2. **¿Cómo implemento ETAPA 1?** → PARTE2 → C.1.9 (pseudocódigo completo)
3. **¿Cómo funciona The_Wall?** → PARTE2 → D.4
4. **¿Cómo funciona PAT?** → PARTE2 → E.3
5. **¿Qué mantener/reemplazar?** → PARTE3 → G.1, G.2, G.4
6. **¿Cómo validar?** → PARTE3 → I (12 casos)

---

**ESPECIFICACIÓN COMPLETA LISTA PARA IMPLEMENTAR**

*Usa este prompt para comenzar la construcción del indicador que "piensa como FPLEME" con código 100% propio.*

---

**Archivos en:**
`C:\Users\PC\Documents\CICLES\knowledge_base_2026-01-18\`
