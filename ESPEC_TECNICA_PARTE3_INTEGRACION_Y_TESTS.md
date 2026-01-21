# ESPECIFICACIÓN TÉCNICA IMPLEMENTABLE - PARTE 3
## INTEGRACIÓN, BLOQUEADORES Y CASOS DE PRUEBA

*Continúa de ESPEC_TECNICA_PARTE2_REGLAS_Y_FILTROS.md*

---

## G) INTEGRACIÓN CON INDICADOR ACTUAL (MFSScalpIndicator v2.0)

### G.1) Componentes que SE MANTIENEN (NO Modificar)

**Basado en análisis del JSON → indicator_current:**

| Componente | Ubicación Código | Razón para Mantener | Fuente |
|------------|------------------|---------------------|--------|
| **Detección de Swings Renko** | `DetectRenkoSwings()` líneas 181-194 | ✅ Funciona correctamente. SwingHigh cuando `High[0] < High[1]`, SwingLow cuando `Low[0] > Low[1]` | [JSON → indicator_current.key_components.swing_detection + RESUMEN_EJECUTIVO línea 104] |
| **Cálculo SHARK** | `UpdateShark()` líneas 116-179 | ✅ Implementación razonable del confirmador. 5 pasos: raw, EMA1, EMA2, multiply, normalize | [JSON → indicator_current.key_components.shark_filter + RESUMEN_EJECUTIVO línea 105] |
| **Bug Fix TP/SL** | `ManageTrades()` línea 330: `if (CurrentBar == entryBar) return;` | ✅ Corrección crítica ya implementada. NO evaluar TP/SL en barra de entrada | [JSON → bugs_fixed[0] + RESUMEN_EJECUTIVO línea 106] |
| **Sistema de Logging** | `InitializeLog()`, `CloseLog()`, `LogTrade()` líneas 438-515 | ✅ CSV detallado para análisis post-trade. Formato: Timestamp, Instrument, Type, Direction, Price, Scenario, MapIdx, CycleDir, PnL, Bars | [JSON → indicator_current.logging + RESUMEN_EJECUTIVO línea 107] |
| **Panel Informativo** | `DrawPanel()` líneas 400-429 | ✅ Visualización en tiempo real del estado. Muestra: Trades, WR, MAP, Cycle, Scenario, SHARK, CycleRef, Armed, InTrade | [JSON → indicator_current.architecture.execution_flow[6] + RESUMEN_EJECUTIVO línea 108] |
| **Parámetros Base** | `TpTicks`, `SlTicks`, `EnableSharkFilter` | ✅ Parámetros configurables existentes. Añadir nuevos sin eliminar estos | [JSON → indicator_current.parameters] |
| **Variables de Swing** | `lastSwingHigh`, `lastSwingLow`, `lastSwingHighBar`, `lastSwingLowBar` | ✅ Necesarios para stops y validación de ciclos | [JSON → indicator_current.key_components.swing_detection.variables] |

✅ Definido: 7 componentes que NO se modifican

---

### G.2) Componentes que SE REEMPLAZAN (Reescribir)

| Componente | Ubicación Actual | Problema Identificado | Reemplazo Propuesto | Fuente |
|------------|------------------|----------------------|---------------------|--------|
| **UpdateCycles()** | Líneas 196-253 | ❌ Detección de ciclo basada solo en swings, NO detecta ETAPA 1 correctamente. Timing tardío | ✅ NUEVO: `DetectEtapa1()` que valida: salida de +-4 hacia 0, 2º/3er box, no extremos, SHARK alineado | [RESUMEN_EJECUTIVO → Problema #2 "señales tardías" + Mejora #1] |
| **DetectSignals()** | Líneas 255-321 | ❌ Lógica "armed + confirmado" genera señales al final del movimiento. No implementa PAT ni The_Wall | ✅ NUEVO: `GenerateEtapa1Signal()` con PAT scoring y filtro The_Wall obligatorio | [RESUMEN_EJECUTIVO → Problema #1 "no piensa como FPLEME" + Mejora #3] |
| **Cálculo MAP simplificado** | `UpdateCycles()` línea 198-205: `(midPrice - sma20) / atr` | ⚠️ Puede no coincidir con MAPS_M7 real. Escenarios PPM/MM no se detectan correctamente | ✅ MEJORAR: Intentar acceder a MAPS_M7.MAP0 si disponible, sino mantener cálculo actual con validación | [RESUMEN_EJECUTIVO → Problema #4 + JSON → improvement_roadmap.research_needed[2]] |
| **Escenario PPM/MM** | `DetectSignals()` líneas 260-263: `isPpm` y `isMm` básicos | ❌ Lógica simplificada. No se usa como filtro de calidad | ✅ NUEVO: `DetectScenario()` que retorna enum ScenarioType y se integra en PAT Capa 3 | [RESUMEN_EJECUTIVO → Mejora #5 + JSON → fpleme_philosophy.fundamental_concepts.context_over_signal] |
| **Filtro SHARK** | `DetectSignals()` líneas 267-273: opcional según parámetro | ⚠️ Correcto pero no suficiente. Falta validar alineación (mismo color) | ✅ MEJORAR: Cambiar de check opcional a obligatorio en ETAPA 1. Verificar alineación, no solo estado | [JSON → indicator_current.key_components.signal_detection.conditions[4] + Parte 1 Máquina Estados] |

✅ Definido: 5 componentes que requieren reescritura

---

### G.3) Componentes NUEVOS a Agregar

| Componente Nuevo | Propósito | Ubicación Sugerida | Dependencias | Fuente |
|------------------|-----------|-------------------|--------------|--------|
| **CountConsecutivePositiveBoxes()** | Contar boxes positivos consecutivos para timing ETAPA 1 | Nuevo método auxiliar | Acceso a Open[] y Close[] | [Parte 2 → C.1.2] |
| **CountConsecutiveNegativeBoxes()** | Contar boxes negativos consecutivos para timing ETAPA 1 SHORT | Nuevo método auxiliar | Acceso a Open[] y Close[] | [Parte 2 → C.2.2] |
| **GetWallColor()** | Obtener color de The_Wall desde MAPS_M7, VX_M7 o proxy | Nuevo método con fallback | MAPS_M7 o VX_M7 indicadores | [Parte 2 → D.3] |
| **EvaluateSignalQuality()** | Scoring PAT con 4 capas | Nuevo método que retorna SignalQuality | fplemeValue, sharkState, currentScenario, wallState | [Parte 2 → E.3] |
| **Layer1_FplemeValid()** | PAT Capa 1 - FPLEME en niveles válidos | Método auxiliar de PAT | fplemeValue | [Parte 2 → E.2 Capa 1] |
| **Layer2_SharkAligned()** | PAT Capa 2 - SHARK alineado | Método auxiliar de PAT | sharkState, direction | [Parte 2 → E.2 Capa 2] |
| **Layer3_FavorableScenario()** | PAT Capa 3 - Escenario favorable | Método auxiliar de PAT | currentScenario, direction | [Parte 2 → E.2 Capa 3] |
| **Layer4_TheWallNotAgainst()** | PAT Capa 4 - The_Wall no en contra | Método auxiliar de PAT | wallState, direction | [Parte 2 → E.2 Capa 4] |
| **DetectEtapa1Long()** | Detectar ETAPA 1 LONG con todas las validaciones | Reemplaza parte de UpdateCycles + DetectSignals | fplemeValue, fplemePrevValue, sharkState, boxes count | [Parte 2 → C.1] |
| **DetectEtapa1Short()** | Detectar ETAPA 1 SHORT con todas las validaciones | Reemplaza parte de UpdateCycles + DetectSignals | fplemeValue, fplemePrevValue, sharkState, boxes count | [Parte 2 → C.2] |
| **ApplyTheWallFilter()** | Filtro obligatorio de The_Wall | Llamado antes de generar cualquier señal | wallColor, direction | [Parte 2 → D.4] |
| **CalculateEtapa1LongEntry()** | Calcular precio de entrada para ETAPA 1 LONG | Dentro de DetectEtapa1Long | Low[], confirmationBoxIndex | [Parte 2 → C.1.5] |
| **CalculateEtapa1ShortEntry()** | Calcular precio de entrada para ETAPA 1 SHORT | Dentro de DetectEtapa1Short | High[], confirmationBoxIndex | [Parte 2 → C.2.5] |
| **Etapa1LongInvalidated()** | Verificar invalidación de ETAPA 1 LONG | Llamado en cada bar mientras etapa activa | fplemeValue, fplemePrevValue | [Parte 2 → C.1.6] |
| **Etapa1ShortInvalidated()** | Verificar invalidación de ETAPA 1 SHORT | Llamado en cada bar mientras etapa activa | fplemeValue, fplemePrevValue | [Parte 2 → C.2.6] |

✅ Definido: 15 métodos nuevos a implementar

---

### G.4) Lista de Diffs por Función

#### OnBarUpdate() - Flujo Principal

**ACTUAL (v2.0):**
```csharp
protected override void OnBarUpdate()
{
    if (BarsInProgress != 0) return;
    if (CurrentBar < 20) return;
    
    UpdateShark();           // MANTENER
    DetectRenkoSwings();     // MANTENER
    UpdateCycles();          // ❌ REEMPLAZAR
    DetectSignals();         // ❌ REEMPLAZAR
    ManageTrades();          // MANTENER (con bugfix)
    DrawPanel();             // MANTENER
}
```

**PROPUESTO (v3.0):**
```csharp
protected override void OnBarUpdate()
{
    if (BarsInProgress != 0) return;
    if (CurrentBar < 20) return;
    
    UpdateShark();              // ✅ MANTENER
    DetectRenkoSwings();        // ✅ MANTENER
    UpdateCycles();             // ✅ MANTENER (solo para MAP tracking)
    UpdateWallColor();          // ➕ NUEVO - obtener The_Wall
    UpdateScenario();           // ➕ NUEVO - detectar PPM/MM
    DetectEtapa1Long();         // ➕ NUEVO - reemplaza DetectSignals
    DetectEtapa1Short();        // ➕ NUEVO - reemplaza DetectSignals
    ManageTrades();             // ✅ MANTENER
    DrawPanel();                // ✅ MANTENER (actualizar para mostrar PAT score)
}
```

**Diff Summary:**
- ✅ Mantener: UpdateShark, DetectRenkoSwings, ManageTrades (con bugfix), DrawPanel
- 🔧 Modificar: UpdateCycles (simplificar, solo MAP tracking, NO detección de señales)
- ➕ Agregar: UpdateWallColor, UpdateScenario, DetectEtapa1Long, DetectEtapa1Short
- ❌ Eliminar/Reemplazar: DetectSignals (lógica "armed" obsoleta)

---

#### UpdateCycles() - Simplificar

**ACTUAL:** 58 líneas (196-253) con lógica de ciclos + señales mezclada

**PROPUESTO:** Reducir a solo tracking de MAP y swings
```csharp
private void UpdateCycles()
{
    // Solo calcular MAP index
    double midPrice = (High[0] + Low[0]) * 0.5;
    double sma20 = SMA(20)[0];
    double atr = ATR(14)[0];
    
    if (atr <= 0.0) return;
    
    int currentMapIndex = (int)Math.Round((midPrice - sma20) / atr);
    lastMapIndex = currentMapIndex;
    
    // Actualizar cycleRef y cycle2 al detectar swings
    if (lastSwingHighBar == CurrentBar - 1)
    {
        if (!cycleRefValid)
        {
            cycleRefValid = true;
            cycleRefMapIndex = currentMapIndex;
            cycle2Valid = false;
            cycleDirection = -1;
        }
        else if (cycleDirection < 0 && !cycle2Valid)
        {
            cycle2Valid = true;
            cycle2MapIndex = currentMapIndex;
        }
        // ... lógica similar para otros casos
    }
    
    if (lastSwingLowBar == CurrentBar - 1)
    {
        // Similar para swing low
    }
}
```

**Diff:** Eliminar toda la lógica de señales (líneas 276-291 originales), mantener solo MAP y ciclo tracking

---

#### DetectSignals() - ELIMINAR y Reemplazar con DetectEtapa1Long/Short

**ACTUAL:** 67 líneas (255-321) con lógica "armed + confirmado"

**PROPUESTO:** Eliminar completamente y reemplazar con:
1. `DetectEtapa1Long()` - pseudocódigo en Parte 2 → C.1.9
2. `DetectEtapa1Short()` - simétrico a Long

**Razón:** Lógica actual no implementa filosofía FPLEME. Señales tardías.

---

### G.5) Nuevas Variables de Clase a Agregar

```csharp
// En región #region Variables

// FPLEME tracking
private double fplemePrevValue;           // Valor previo de FPLEME para detectar cruces
private CycleState currentCycle;          // Estado del ciclo actual

// Box counting para timing ETAPA 1
private int consecutivePositiveBoxes;     // Boxes positivos consecutivos
private int consecutiveNegativeBoxes;     // Boxes negativos consecutivos

// The_Wall
private MAPS_M7 mapsIndicator;            // Indicador MAPS_M7 (si accesible)
private VXM7 vxIndicator;                 // Indicador VX_M7 (alternativa)
private WallColor wallColor;              // Color actual de The_Wall
private WallState wallState;              // Estado derivado de wallColor

// Escenarios
private ScenarioType currentScenario;     // Escenario actual (PPM/MM/None)

// ETAPA 1
private EtapaState currentEtapa;          // ETAPA activa
private bool etapa1LongConfirmed;         // ETAPA 1 LONG confirmada
private bool etapa1ShortConfirmed;        // ETAPA 1 SHORT confirmada
private int etapa1ConfirmationBar;        // Barra donde se confirmó ETAPA 1
private double etapa1EntryPrice;          // Precio de entrada calculado

// PAT Scoring
private int patScore;                     // Score PAT actual (0-4)
private SignalQuality currentQuality;     // Calidad de señal actual

// Parámetros nuevos
private bool AllowMediumQualitySignals = true;  // Permitir señales MEDIUM
```

✅ Definido: 17 variables nuevas

---

## H) LISTA DE BLOQUEADORES + PREGUNTAS CERRADAS

### H.1) Bloqueadores Críticos

#### BLOQUEADOR #1: Acceso a Valores Reales de FPLEME

**Descripción:** Sin acceso a FPLEME_M7_II real, el indicador usa SHARK calculado internamente como proxy. Esto puede no reflejar exactamente FPLEME oficial.

**Impacto:** ⚠️ CRÍTICO - Afecta detección de ETAPA 1 (crucesde niveles +-4 hacia 0)

**Evidencia que Falta:** Confirmación de que FPLEME_M7_II expone propiedades públicas

**Pregunta Cerrada #1:**  
¿FPLEME_M7_II expone públicamente una propiedad o serie `double FplemeValue` (o similar) accesible desde otro indicador en NinjaTrader 8?
- **Respuesta esperada:** Sí / No / Nombre exacto de la propiedad

**Pregunta Cerrada #2:**  
¿FPLEME_M7_II expone `FplemeState CurrentState` o `CycleState` para saber si está en Bull/Bear?
- **Respuesta esperada:** Sí / No / Nombre exacto

**Pregunta Cerrada #3:**  
¿FPLEME_M7_II expone `bool IsEtapa1Long` y `bool IsEtapa1Short` para saber si ETAPA 1 está activa?
- **Respuesta esperada:** Sí / No

**Plan B Técnico:**
- **Opción A (ACTUAL):** Usar SHARK calculado internamente como proxy de FPLEME. [Ya implementado en v2.0]
- **Opción B:** Replicar cálculo exacto de FPLEME (complejo, requiere reverse engineering del DLL)
- **Opción C:** Solicitar al desarrollador de FPLEME_M7_II que exponga API pública

**Recomendación:** Validar Opción A con backtest exhaustivo. Si WR no mejora a >58%, considerar Opción C.

[FUENTE: JSON → improvement_roadmap.research_needed[0] + api_access_requirements.fpleme_m7_ii]

---

#### BLOQUEADOR #2: Acceso a The_Wall Color

**Descripción:** Sin acceso a color de The_Wall de MAPS_M7 o VX_M7, no se puede aplicar filtro inviolable "NUNCA contra The_Wall".

**Impacto:** ⚠️ CRÍTICO - The_Wall es regla #1 de FPLEME (80% del éxito según filosofía)

**Evidencia que Falta:** Confirmación de API pública de MAPS_M7 o VX_M7

**Pregunta Cerrada #4:**  
¿MAPS_M7 expone `WallColor TheWallColor` o método `WallColor GetWallColor()` accesible públicamente?
- **Respuesta esperada:** Sí / No / Nombre exacto

**Pregunta Cerrada #5:**  
¿VX_M7 expone `WallColor VXWallColor` o método similar?
- **Respuesta esperada:** Sí / No / Nombre exacto

**Pregunta Cerrada #6:**  
¿MAPS_M7 expone `double MAP0` (Precio Justo) como serie accesible?
- **Respuesta esperada:** Sí / No / Nombre exacto

**Plan B Técnico:**
- **Opción A:** Proxy basado en análisis de precio vs SMA(20) [Implementado en Parte 2 → D.3.3]
- **Opción B:** Implementar cálculo completo de The_Wall independiente (muy complejo)
- **Opción C:** Modo permisivo temporal (asumir The_Wall neutral) - NO RECOMENDADO

**Recomendación:** Probar Opción A y validar contra MAPS visual. Si discrepancia >30%, buscar acceso a API.

[FUENTE: JSON → improvement_roadmap.research_needed[1] + api_access_requirements.maps_m7]

---

#### BLOQUEADOR #3: Cálculo MAP Exacto

**Descripción:** Cálculo actual `(midPrice - SMA20) / ATR14` puede no coincidir con MAPS_M7 real, afectando detección de escenarios PPM/MM.

**Impacto:** ⚠️ MEDIO - Afecta PAT Capa 3 (escenario favorable)

**Evidencia que Falta:** Fórmula exacta de MAP en MAPS_M7

**Pregunta Cerrada #7:**  
¿El cálculo de MAP en MAPS_M7 es exactamente `(Close - SMA(Close, 20)) / ATR(14)`?
- **Respuesta esperada:** Sí / No, es [fórmula alternativa] / Desconocido

**Pregunta Cerrada #8:**  
¿MAPS_M7 usa `(High + Low) / 2` (midPrice) o `Close` para el cálculo?
- **Respuesta esperada:** midPrice / Close / Otro

**Plan B Técnico:**
- **Opción A (ACTUAL):** Mantener cálculo simplificado y validar con backtest comparativo
- **Opción B:** Si MAP0 accesible desde MAPS_M7, calcular índice como `(Close - MAP0) / ATR`
- **Opción C:** Ajustar empíricamente (probar SMA(15), SMA(25), ATR(10), ATR(20))

**Recomendación:** Validar con backtest. Si escenarios PPM/MM detectados < 70% match con MAPS visual, ajustar.

[FUENTE: JSON → improvement_roadmap.research_needed[2]]

---

### H.2) Bloqueadores Menores (No Críticos)

#### BLOQUEADOR #4: Timing ETAPA 2

**Descripción:** Documentación menciona 2 modos (Classic vs Mode 2.2) pero no especifica default.

**Impacto:** ⚠️ BAJO - ETAPA 2 NO es prioritario (implementar después de ETAPA 1 validada)

**Pregunta Cerrada #9:**  
Para ETAPA 2, ¿usar timing Classic (entrada en box anterior) o Mode 2.2 (entrada en box actual)?
- **Respuesta esperada:** Classic / Mode 2.2 / Ambos como parámetro

**Plan B:** Implementar como parámetro `EntryTimingMode` con default Classic. Posponer hasta validar ETAPA 1.

[FUENTE: JSON → improvement_roadmap.research_needed[4]]

---

#### BLOQUEADOR #5: R:R Óptimo

**Descripción:** R:R 1:1 actual es insuficiente. Necesita determinar óptimo (1.5:1, 2:1, dinámico).

**Impacto:** ⚠️ MEDIO - Afecta rentabilidad pero NO detección de señales

**Pregunta Cerrada #10:**  
¿Qué R:R prefieres para backtests iniciales?
- **Respuesta esperada:** 1.5:1 (60:40) / 2:1 (80:40) / Dinámico por MAP / Mantener 1:1 y mejorar WR primero

**Plan B:** Probar 1.5:1 y 2:1 en paralelo durante backtest de Fase 2.

[FUENTE: RESUMEN_EJECUTIVO → Mejora #4 + JSON → improvement_roadmap.research_needed[3]]

---

### H.3) Matriz de Bloqueadores

| ID | Bloqueador | Impacto | Pregunta Cerrada | Plan B | Prioridad |
|----|------------|---------|------------------|--------|-----------|
| #1 | Acceso FPLEME_M7_II | CRÍTICO | P#1, P#2, P#3 | Usar SHARK calculado (Opción A) | 🔴 ALTA |
| #2 | Acceso The_Wall | CRÍTICO | P#4, P#5, P#6 | Proxy precio vs SMA (Opción A) | 🔴 ALTA |
| #3 | Cálculo MAP exacto | MEDIO | P#7, P#8 | Validar cálculo actual con backtest | 🟡 MEDIA |
| #4 | Timing ETAPA 2 | BAJO | P#9 | Posponer hasta validar ETAPA 1 | 🟢 BAJA |
| #5 | R:R óptimo | MEDIO | P#10 | Probar 1.5:1 y 2:1 en backtest | 🟡 MEDIA |

✅ Definido: 5 bloqueadores con 10 preguntas cerradas

---

## I) CASOS DE PRUEBA (Mínimo 10)

### Formato de Casos de Prueba: Given/When/Then

---

### CASO #1: ETAPA 1 LONG Válido en 2º Box

**Given (Condiciones Iniciales):**
- `fplemePrevValue = -5.0` (debajo de -4)
- `fplemeValue = 0.5` (alcanza 0)
- `consecutivePositiveBoxes = 2` (2º box positivo)
- `sharkState = SharkState.Bullish` (SHARK alineado)
- `wallColor = WallColor.Green` (permite LONG)
- `currentScenario = ScenarioType.PpmBuy` (convergencia compradora)

**When (Acción):**
- `DetectEtapa1Long()` ejecutado en `CurrentBar`

**Then (Resultado Esperado):**
- ✅ `etapa1LongConfirmed = true`
- ✅ `entryPrice = Low[1]` (base del 1er box positivo)
- ✅ `patScore = 4` (4 capas OK)
- ✅ `currentQuality = SignalQuality.High` (PAT completo)
- ✅ Señal LONG generada con log "ETAPA 1 LONG - PAT HIGH"

**Objetivo:** Validar detección correcta de ETAPA 1 LONG en timing ideal (2º box) con PAT completo.

[FUENTE: Parte 2 → C.1]

---

### CASO #2: ETAPA 1 SHORT Válido en 3er Box

**Given:**
- `fplemePrevValue = +6.0` (arriba de +4)
- `fplemeValue = -0.5` (alcanza 0)
- `consecutiveNegativeBoxes = 3` (3er box negativo)
- `sharkState = SharkState.Bearish` (SHARK alineado)
- `wallColor = WallColor.Pink` (permite SHORT)
- `currentScenario = ScenarioType.PpmSell` (convergencia vendedora)

**When:**
- `DetectEtapa1Short()` ejecutado

**Then:**
- ✅ `etapa1ShortConfirmed = true`
- ✅ `entryPrice = High[1]` (topo del 2º box negativo)
- ✅ `patScore = 4`
- ✅ `currentQuality = SignalQuality.High`
- ✅ Señal SHORT generada

**Objetivo:** Validar simetría ETAPA 1 SHORT con timing en 3er box.

[FUENTE: Parte 2 → C.2]

---

### CASO #3: ETAPA 1 LONG Bloqueado por The_Wall

**Given:**
- `fplemePrevValue = -5.0`, `fplemeValue = 0.5` (cruce válido)
- `consecutivePositiveBoxes = 2` (timing OK)
- `sharkState = SharkState.Bullish` (alineado)
- **`wallColor = WallColor.Pink`** ❌ (The_Wall CONTRA)

**When:**
- `DetectEtapa1Long()` ejecutado
- `ApplyTheWallFilter(SignalDirection.Long)` retorna `false`

**Then:**
- ❌ Señal BLOQUEADA
- ❌ `etapa1LongConfirmed = false` (no se confirma)
- ✅ Log: "SEÑAL LONG BLOQUEADA: The_Wall Pink impide LONGs"

**Objetivo:** Validar regla inviolable "NUNCA contra The_Wall".

[FUENTE: Parte 2 → D.4 + RESUMEN_EJECUTIVO → Mejora #2]

---

### CASO #4: ETAPA 1 Inválido - Desde Extremo

**Given:**
- **`fplemePrevValue = -10.0`** ❌ (extremo -8/-12)
- `fplemeValue = 0.5`
- `consecutivePositiveBoxes = 2`
- `sharkState = SharkState.Bullish`

**When:**
- `DetectEtapa1Long()` ejecutado
- Check `notFromExtreme = (fplemePrevValue > FPLEME_LOW)` retorna `false`

**Then:**
- ❌ Señal NO generada
- ❌ Return early en paso 3 de pseudocódigo
- ✅ Log: "ETAPA 1 LONG - viene de extremo, señal inválida"

**Objetivo:** Validar restricción de NO venir de extremos.

[FUENTE: Parte 2 → C.1.3]

---

### CASO #5: ETAPA 1 Inválido - Timing Incorrecto (1er Box)

**Given:**
- `fplemePrevValue = -5.0`, `fplemeValue = 0.5`
- **`consecutivePositiveBoxes = 1`** ❌ (demasiado temprano)
- `sharkState = SharkState.Bullish`

**When:**
- `DetectEtapa1Long()` ejecutado
- Check `correctTiming = (positiveBoxCount == 2 || == 3)` retorna `false`

**Then:**
- ❌ Señal NO generada
- ❌ Return early en paso 2
- ✅ Log: "ETAPA 1 LONG - timing incorrecto (box 1)"

**Objetivo:** Validar timing estricto de 2º o 3er box (NO antes).

[FUENTE: Parte 2 → C.1.2]

---

### CASO #6: ETAPA 1 Inválido - SHARK Desalineado

**Given:**
- `fplemePrevValue = -5.0`, `fplemeValue = 0.5`
- `consecutivePositiveBoxes = 2`
- **`sharkState = SharkState.Neutral`** ❌ (NO alineado)

**When:**
- `DetectEtapa1Long()` ejecutado
- Check `sharkAligned = (sharkState == Bullish)` retorna `false`

**Then:**
- ❌ Señal NO generada
- ❌ Return early en paso 4
- ✅ Log: "ETAPA 1 LONG - SHARK no confirma, movimiento lateralizado"

**Objetivo:** Validar requisito de alineación SHARK obligatoria.

[FUENTE: Parte 2 → C.1.4]

---

### CASO #7: PAT Score MEDIUM (3/4 Capas)

**Given:**
- ETAPA 1 LONG detectado y validado
- `fplemeValue = 2.0` ✅ (niveles válidos)
- `sharkState = SharkState.Bullish` ✅ (alineado)
- **`currentScenario = ScenarioType.None`** ❌ (sin escenario - Capa 3 fail)
- `wallColor = WallColor.Green` ✅ (permite LONG)

**When:**
- `EvaluateSignalQuality(SignalDirection.Long)` ejecutado
- `patScore = 3` (Capas 1, 2, 4 OK; Capa 3 NO)

**Then:**
- ✅ `currentQuality = SignalQuality.Medium`
- ✅ Si `AllowMediumQualitySignals = true` → Señal generada con advertencia
- ✅ Log: "⚠️ SEÑAL LONG GENERADA - PAT MEDIUM (3/4)"
- ✅ Si `AllowMediumQualitySignals = false` → Señal bloqueada

**Objetivo:** Validar scoring PAT con calidad MEDIUM y parámetro configurable.

[FUENTE: Parte 2 → E.3 + E.5]

---

### CASO #8: PAT Score LOW (2/4 Capas) - Evitar

**Given:**
- ETAPA 1 LONG detectado
- **`fplemeValue = 9.0`** ❌ (extremo > +8 - Capa 1 fail)
- **`sharkState = SharkState.Neutral`** ❌ (desalineado - Capa 2 fail)
- `currentScenario = ScenarioType.PpmBuy` ✅ (Capa 3 OK)
- `wallColor = WallColor.Green` ✅ (Capa 4 OK)

**When:**
- `EvaluateSignalQuality()` ejecutado
- `patScore = 2`

**Then:**
- ❌ `currentQuality = SignalQuality.Low`
- ❌ Señal NO generada
- ✅ Log: "❌ SEÑAL LONG PAT LOW (2/4) - bloqueada"

**Objetivo:** Validar bloqueo de señales con calidad insuficiente (<=2 capas).

[FUENTE: Parte 2 → E.3]

---

### CASO #9: Escenario PPM Buy Detectado Correctamente

**Given:**
- `cycleRefValid = true`, `cycle2Valid = true`
- `cycleDirection = 1` (Bull)
- `cycleRefMapIndex = -2`
- `cycle2MapIndex = 0` (progresó hacia arriba)

**When:**
- `DetectScenario()` ejecutado
- Check `cycle2MapIndex > cycleRefMapIndex` → `0 > -2` = `true`

**Then:**
- ✅ `currentScenario = ScenarioType.PpmBuy`
- ✅ En PAT Capa 3 para LONG → `favorableScenario = true`
- ✅ Señales LONG tendrán mayor calidad

**Objetivo:** Validar detección de convergencia compradora (PPM Buy).

[FUENTE: Parte 2 → F.2 + F.4 Caso 1]

---

### CASO #10: Escenario MM (Divergencia) con SHARK Confirma MEDIUM

**Given:**
- `cycleRefValid = true`, `cycle2Valid = true`
- `cycleRefMapIndex = -1`, `cycle2MapIndex = -1` (igual - MM)
- `cycleDirection = 1` (Bull)
- `sharkState = SharkState.Bullish`

**When:**
- `DetectScenario()` ejecutado → `ScenarioType.MM`
- PAT Capa 3 evaluada para LONG

**Then:**
- ✅ `currentScenario = ScenarioType.MM`
- ✅ `Layer3_FavorableScenario(LONG)` retorna `true` (MM + SHARK bullish)
- ✅ Calidad MEDIA (si otras 3 capas OK → PAT score 4, pero escenario no optimal)

**Objetivo:** Validar que MM es válido pero de calidad MEDIA, requiere SHARK alineado.

[FUENTE: Parte 2 → F.2 + F.4 Caso 3]

---

### CASO #11: Invalidación de ETAPA 1 LONG

**Given:**
- `etapa1LongConfirmed = true` (ETAPA 1 activa)
- `etapa1ConfirmationBar = 100`
- `CurrentBar = 102`
- **`fplemePrevValue = 0.5`** (estaba arriba de 0)
- **`fplemeValue = -4.5`** (rompió 0 hacia abajo y alcanzó -4)

**When:**
- `Etapa1LongInvalidated()` ejecutado cada bar

**Then:**
- ✅ Invalidación detectada: `crossesBackDown = true`
- ✅ `etapa1LongConfirmed = false` (reset)
- ✅ `currentEtapa = EtapaState.None`
- ✅ Si señal aún no ejecutada → cancelar señal

**Objetivo:** Validar invalidación cuando FPLEME rompe 0 hacia -4 (ciclo no se estableció).

[FUENTE: Parte 2 → C.1.6]

---

### CASO #12: Comparación vs Lógica Actual (Evitar Señal Tardía)

**Escenario de Mercado:**
- Ciclo bull establece en bars 100-105
- ETAPA 1 LONG debería disparar en bar 102 (2º box positivo, FPLEME alcanza 0)
- Lógica actual v2.0 dispara en bar 107 (después de varios boxes más)

**Given (Lógica v2.0 - ACTUAL):**
- `UpdateCycles()` arma señal en bar 105 cuando MAP avanza
- `DetectSignals()` confirma en bar 107 cuando aparece swing de retroceso

**When:**
- Ambos indicadores (v2.0 y v3.0 propuesto) corren en mismo backtest

**Then:**
- ✅ v3.0 genera señal en bar 102 (ETAPA 1 timing)
- ❌ v2.0 genera señal en bar 107 (5 bars tarde)
- ✅ v3.0 captura mejor precio de entrada (base de box en bar 101)
- ✅ v3.0 evita "desperdicio de comienzo claro de ciclo"

**Objetivo:** Validar que nueva lógica NO genera señales tardías (problema actual).

[FUENTE: RESUMEN_EJECUTIVO → Problema #2 + JSON → trader_feedback[2]]

---

## RESUMEN PARTE 3 & ENTREGABLES COMPLETOS

### ✅ PARTE 3 COMPLETADA:

**G) Integración con Indicador Actual:**
- 7 componentes que SE MANTIENEN
- 5 componentes que SE REEMPLAZAN
- 15 métodos NUEVOS a agregar
- 17 variables nuevas
- Diffs detallados para OnBarUpdate, UpdateCycles, DetectSignals

**H) Bloqueadores + Preguntas Cerradas:**
- 3 bloqueadores CRÍTICOS (#1 FPLEME, #2 The_Wall, #3 MAP)
- 2 bloqueadores MENORES (#4 ETAPA 2, #5 R:R)
- **10 preguntas cerradas** específicas para resolver incertidumbres
- Plan B técnico para cada bloqueador

**I) Casos de Prueba:**
- **12 casos de prueba** en formato Given/When/Then (superando mínimo de 10)
- Casos cubren: ETAPA 1 válido, bloqueos por The_Wall, restricciones, PAT scoring, escenarios, invalidación, comparación vs lógica actual

---

## ENTREGABLES A-I COMPLETOS - RESUMEN FINAL

### ✅ A) MAPA DE CONCEPTOS → VARIABLES
- 33 conceptos FPLEME mapeados a variables NT8
- Todas con fuente citada
- 4 INCERTIDUMBRES identificadas con preguntas cerradas

### ✅ B) MÁQUINA DE ESTADOS
- 5 máquinas de estados definidas: CycleState, EtapaState, ScenarioType, WallState, SignalQuality
- 30+ transiciones con triggers, guards, side effects exactos
- Todo con fuente citada

### ✅ C) REGLAS DE SEÑAL ETAPA 1
- Especificación completa LONG (9 subsecciones)
- Especificación completa SHORT (simétrica)
- Pseudocódigo completo de 10 pasos
- Dependencias y variables críticas listadas

### ✅ D) THE_WALL - FILTRO INVIOLABLE
- Regla fundamental definida
- 3 opciones de acceso (MAPS, VX, proxy)
- Pseudocódigo con fallback
- INCERTIDUMBRE #2 identificada con 3 preguntas cerradas

### ✅ E) PAT (PERFECT ALIGNMENT TRIGGER)
- 4 capas definidas con condiciones exactas
- Sistema de scoring 0-4
- Tabla de decisiones con 16 casos
- Pseudocódigo completo de uso

### ✅ F) ESCENARIOS PPM/MM
- Reglas de detección exactas
- 4 casos de ejemplo con valores concretos
- Fallback si MAP no disponible

### ✅ G) INTEGRACIÓN CON INDICADOR ACTUAL
- Componentes a mantener (7)
- Componentes a reemplazar (5)
- Métodos nuevos (15)
- Variables nuevas (17)
- Diffs por función

### ✅ H) BLOQUEADORES + PREGUNTAS CERRADAS
- 5 bloqueadores identificados
- 10 preguntas cerradas específicas (NO abiertas)
- Plan B técnico para cada bloqueador
- Matriz de prioridades

### ✅ I) CASOS DE PRUEBA
- 12 casos en formato Given/When/Then
- Cubren todos los aspectos críticos
- Incluyen comparación vs lógica actual

---

## ESTÁNDAR "CERO AMBIGÜEDAD" - CHECKLIST

✅ **NO inventes:** Todo basado en archivos fuente (JSON, README, RESUMEN_EJECUTIVO)  
✅ **Citas internas:** Cada afirmación importante con [FUENTE: ...]  
✅ **Sin dudas al aire:** Incertidumbres marcadas como ⚠️ INCERTO con preguntas cerradas  
✅ **FPLEME-first:** Filosofía Flow → Cycle → Context → Signal respetada  
✅ **Prioridades:** ETAPA 1 + The_Wall primero, luego PAT, luego PPM/MM, R:R al final  
✅ **Entregables ejecutables:** Reglas, estados, triggers, variables, pseudocódigo C# estilo NT8  
✅ **Casos de prueba:** 12 casos Given/When/Then

---

## PRÓXIMOS PASOS TÉCNICOS

**FASE INVESTIGACIÓN (Semana 1):**
1. Responder **10 preguntas cerradas** de sección H para resolver INCERTIDUMBRES
2. Validar acceso a APIs de FPLEME_M7_II y MAPS_M7
3. Si no hay acceso, confirmar uso de Plans B (SHARK proxy, The_Wall proxy)

**FASE IMPLEMENTACIÓN (Semana 2-3):**
4. Implementar métodos nuevos según sección G.3 (15 métodos)
5. Reescribir UpdateCycles y eliminar DetectSignals según G.4
6. Agregar 17 variables nuevas según G.5

**FASE VALIDACIÓN (Semana 4):**
7. Ejecutar 12 casos de prueba de sección I
8. Backtest comparativo v2.0 vs v3.0 (mínimo 6 meses datos)
9. Validar métricas: WR >58%, trades/día 2-4, Profit Factor >1.5

**CRITERIO DE ÉXITO:**
- ✅ WR >= 58% (vs 54.9% actual)
- ✅ Trades/día 2-4 (vs 5.7 actual)
- ✅ Profit Factor >= 1.5 (vs 1.23 actual)
- ✅ NO señales tardías (validar con caso #12)
- ✅ The_Wall respetado (0% trades bloqueados post-ejecución)

---

**FIN DE ESPECIFICACIÓN TÉCNICA IMPLEMENTABLE**

*Documentos Generados:*
1. ESPEC_TECNICA_PARTE1_CONCEPTOS_Y_ESTADOS.md (Entregables A, B)
2. ESPEC_TECNICA_PARTE2_REGLAS_Y_FILTROS.md (Entregables C, D, E, F)
3. ESPEC_TECNICA_PARTE3_INTEGRACION_Y_TESTS.md (Entregables G, H, I)

**Especificación lista para implementación en NinjaTrader 8 con "cero ambigüedad".**
