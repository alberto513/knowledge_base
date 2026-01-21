# ESPECIFICACIÓN TÉCNICA IMPLEMENTABLE - MFSScalpIndicator v3.0
## Análisis Técnico-Conceptual y Arquitectura de Indicador NinjaTrader 8

**Fecha:** 18 de Enero, 2026  
**Analista:** Arquitecto de Indicadores NT8  
**Estándar:** Cero Ambigüedad  
**Filosofía Base:** Flow → Cycle → Context → Signal

**FUENTES ANALIZADAS:**
- ✅ README.md [FUENTE: README]
- ✅ RESUMEN_EJECUTIVO.md [FUENTE: RESUMEN_EJECUTIVO]  
- ✅ MFS_KNOWLEDGE_BASE.json [FUENTE: JSON]

---

## PARTE 1: CONCEPTOS → VARIABLES & MÁQUINA DE ESTADOS

---

## A) MAPA DE CONCEPTOS (FPLEME) → VARIABLES (INDICADOR NT8)

### Tabla de Traducción Concepto-Implementación

| Concepto FPLEME | Cómo se Observa / Condición Exacta | Variable/Estado Sugerido NT8 | Fuente |
|-----------------|-------------------------------------|------------------------------|--------|
| **FPLEME Value** | Oscila entre -12.00 y +12.00. Indica fuerza direccional del mercado. | `double fplemeValue` (rango: -12.0 a +12.0) | [FUENTE: JSON → fpleme_philosophy.tools.FPLEME_M7_II.range] |
| **Nivel -12.00** | Extremo bajo - NO puede iniciar ciclo comprador | `const double FPLEME_EXTREME_LOW = -12.0` | [FUENTE: JSON → fpleme_philosophy.fundamental_concepts.cycle_detection.key_levels] |
| **Nivel -8.00** | Nivel bajo - precaución, evitar nuevas entradas LONG | `const double FPLEME_LOW = -8.0` | [FUENTE: JSON → fpleme_philosophy.fundamental_concepts.cycle_detection.key_levels] |
| **Nivel -4.00** | Confirmación de ciclo vendedor. Punto crítico de salida hacia 0 para ETAPA 1 LONG | `const double FPLEME_CONFIRMATION_SHORT = -4.0` | [FUENTE: JSON → fpleme_philosophy.fundamental_concepts.cycle_detection.key_levels] |
| **Nivel 0.00** | Equilibrio - punto de cambio de ciclo. Meta de ETAPA 1 | `const double FPLEME_EQUILIBRIUM = 0.0` | [FUENTE: JSON → fpleme_philosophy.fundamental_concepts.cycle_detection.key_levels] |
| **Nivel +4.00** | Confirmación de ciclo comprador. Punto crítico de salida hacia 0 para ETAPA 1 SHORT | `const double FPLEME_CONFIRMATION_LONG = 4.0` | [FUENTE: JSON → fpleme_philosophy.fundamental_concepts.cycle_detection.key_levels] |
| **Nivel +8.00** | Nivel alto - precaución, evitar nuevas entradas SHORT | `const double FPLEME_HIGH = 8.0` | [FUENTE: JSON → fpleme_philosophy.fundamental_concepts.cycle_detection.key_levels] |
| **Nivel +12.00** | Extremo alto - NO puede iniciar ciclo vendedor | `const double FPLEME_EXTREME_HIGH = 12.0` | [FUENTE: JSON → fpleme_philosophy.fundamental_concepts.cycle_detection.key_levels] |
| **Ciclo Comprador** | FPLEME >= -4 Y (FPLEME >= +4 O salió de -4 hacia 0). Color azul en NT8 | `enum CycleState { Bull, Bear, Neutral }` + `CycleState currentCycle` | [FUENTE: JSON → technical_glossary.Ciclo Comprador] |
| **Ciclo Vendedor** | FPLEME <= +4 Y (FPLEME <= -4 O salió de +4 hacia 0). Color rosa/magenta en NT8 | `CycleState currentCycle = CycleState.Bear` | [FUENTE: JSON → technical_glossary.Ciclo Vendedor] |
| **SHARK Value** | Confirmador de ciclos. Normalizado -12 a +12. | `double sharkValue` (rango: -12.0 a +12.0) | [FUENTE: JSON → indicator_current.key_components.shark_filter] |
| **SHARK Bullish** | SHARK > +4.0 | `const double SHARK_THRESHOLD_BULL = 4.0` + `bool isSharkBullish = (sharkValue > 4.0)` | [FUENTE: JSON → indicator_current.key_components.shark_filter.thresholds.bullish] |
| **SHARK Bearish** | SHARK < -4.0 | `const double SHARK_THRESHOLD_BEAR = -4.0` + `bool isSharkBearish = (sharkValue < -4.0)` | [FUENTE: JSON → indicator_current.key_components.shark_filter.thresholds.bearish] |
| **SHARK Neutral** | SHARK entre -4.0 y +4.0 | `bool isSharkNeutral = (sharkValue >= -4.0 && sharkValue <= 4.0)` | [FUENTE: JSON → indicator_current.key_components.shark_filter.thresholds.neutral] |
| **SHARK State** | Enum con 3 estados posibles | `enum SharkState { Bullish = 1, Bearish = -1, Neutral = 0 }` + `SharkState sharkState` | [FUENTE: JSON → indicator_current.key_components.shark_filter.states] |
| **Alineación SHARK-FPLEME** | Mismo color/dirección. Bullish: FPLEME >= +4 Y SHARK > +4. Bearish: FPLEME <= -4 Y SHARK < -4 | `bool IsSharkAlignedWithFpleme()` método que retorna true si ambos en mismo estado | [FUENTE: JSON → fpleme_philosophy.tools.SHARK.relationship_with_fpleme] |
| **MAP Index** | Distancia del precio respecto a precio justo, medida en unidades de ATR. Cálculo actual: (midPrice - SMA20) / ATR14 | `int lastMapIndex` (rango: entero, típicamente -10 a +10) | [FUENTE: JSON → indicator_current.key_components.map_tracking.logic] |
| **MAP0 (Precio Justo)** | Línea central de referencia de MAPS. ⚠️ INCERTO: No tenemos acceso directo a MAP0 de MAPS_M7 | `double map0Price` (⚠️ SI DISPONIBLE desde MAPS_M7, sino usar SMA20 como proxy) | [FUENTE: JSON → fpleme_philosophy.tools.MAPS_M7.components.MAP0] |
| **cycleRefMapIndex** | MAP de referencia del ciclo (primer swing del ciclo) | `int cycleRefMapIndex` | [FUENTE: JSON → indicator_current.key_components.map_tracking.variables] |
| **cycle2MapIndex** | MAP del segundo swing del ciclo | `int cycle2MapIndex` | [FUENTE: JSON → indicator_current.key_components.map_tracking.variables] |
| **cycleDirection** | Dirección del ciclo: 1=up (Bull), -1=down (Bear), 0=None | `int cycleDirection` (-1, 0, 1) | [FUENTE: JSON → indicator_current.key_components.map_tracking.variables] |
| **cycleRefValid** | Si hay un cycleRef establecido | `bool cycleRefValid` | [FUENTE: JSON → indicator_current.key_components.cycle_detection.logic] |
| **cycle2Valid** | Si hay un cycle2 establecido | `bool cycle2Valid` | [FUENTE: JSON → indicator_current.key_components.cycle_detection.logic] |
| **Escenario PPM Buy** | Progresión de Preço em MAP - Convergencia compradora. cycle2MapIndex > cycleRefMapIndex cuando cycleDirection > 0 | `enum ScenarioType { None, PpmBuy, PpmSell, MM }` + `ScenarioType currentScenario` | [FUENTE: JSON → fpleme_philosophy.fundamental_concepts.context_over_signal.contexts.PPM_buy] |
| **Escenario PPM Sell** | Convergencia vendedora. cycle2MapIndex < cycleRefMapIndex cuando cycleDirection < 0 | `currentScenario = ScenarioType.PpmSell` | [FUENTE: JSON → fpleme_philosophy.fundamental_concepts.context_over_signal.contexts.PPM_sell] |
| **Escenario MM** | MAP com MAP - Divergencia. cycle2MapIndex == cycleRefMapIndex | `currentScenario = ScenarioType.MM` | [FUENTE: JSON → fpleme_philosophy.fundamental_concepts.context_over_signal.contexts.MM] |
| **Sin Escenario** | Ciclos no establecidos, MAP errático | `currentScenario = ScenarioType.None` | [FUENTE: JSON → fpleme_philosophy.fundamental_concepts.context_over_signal.contexts.no_scenario] |
| **The_Wall Color** | Color del muro de seguridad. Verde=fuerza compra, Rosa/Magenta=fuerza venta, Amarillo=neutral. ⚠️ INCERTO: Acceso a API | `enum WallColor { Green, Pink, Magenta, Yellow, Unknown }` + `WallColor wallColor` | [FUENTE: JSON → fpleme_philosophy.tools.MAPS_M7.components.The_Wall.colors] |
| **The_Wall State** | Estado derivado del color para decisiones de trading | `enum WallState { AllowsLong, AllowsShort, Neutral, BlocksAll }` + `WallState wallState` | [FUENTE: JSON → fpleme_philosophy.operational_principles.1_never_against_the_wall] |
| **The_Wall Allows LONG** | The_Wall NO está rosa/magenta (puede ser verde o amarillo) | `bool wallAllowsLong = (wallColor != WallColor.Pink && wallColor != WallColor.Magenta)` | [FUENTE: RESUMEN_EJECUTIVO → Mejora #2] |
| **The_Wall Allows SHORT** | The_Wall NO está verde (puede ser rosa/magenta o amarillo) | `bool wallAllowsShort = (wallColor != WallColor.Green)` | [FUENTE: RESUMEN_EJECUTIVO → Mejora #2] |
| **ETAPA 1** | Inicio de ciclo. FPLEME sale de +-4 y alcanza 0 en 2º o 3er box | `enum EtapaState { None, Etapa1Long, Etapa1Short, Etapa2Long, Etapa2Short }` + `EtapaState currentEtapa` | [FUENTE: JSON → technical_glossary.ETAPA 1] |
| **ETAPA 1 LONG** | FPLEME sale de -4 (valor previo <= -4 y actual > -4) y alcanza 0 (actual >= 0) en 2º o 3er box positivo consecutivo | `bool isEtapa1Long` + validaciones de box count y extremos | [FUENTE: RESUMEN_EJECUTIVO → Mejora #1 + JSON → fpleme_philosophy.fundamental_concepts.cycle_detection.components] |
| **ETAPA 1 SHORT** | FPLEME sale de +4 (valor previo >= +4 y actual < +4) y alcanza 0 (actual <= 0) en 2º o 3er box negativo consecutivo | `bool isEtapa1Short` + validaciones de box count y extremos | [FUENTE: RESUMEN_EJECUTIVO → Mejora #1 + JSON → fpleme_philosophy.fundamental_concepts.cycle_detection.components] |
| **ETAPA 2 LONG** | Progresión de +4 a +8 en un solo box. FPLEME previo entre +4 y +8, actual >= +8 | `bool isEtapa2Long` (⚠️ NO PRIORITARIO - implementar después de ETAPA 1) | [FUENTE: JSON → technical_glossary.ETAPA 2] |
| **ETAPA 2 SHORT** | Progresión de -4 a -8 en un solo box. FPLEME previo entre -4 y -8, actual <= -8 | `bool isEtapa2Short` (⚠️ NO PRIORITARIO) | [FUENTE: JSON → technical_glossary.ETAPA 2] |
| **PAT Score** | Perfect Alignment Trigger. Suma de capas OK (0-4) | `int patScore` (rango: 0 a 4) | [FUENTE: RESUMEN_EJECUTIVO → Mejora #3] |
| **Signal Quality** | Calidad de señal basada en PAT. 4=HIGH, 3=MEDIUM, <=2=LOW | `enum SignalQuality { Low, Medium, High }` + `SignalQuality currentQuality` | [FUENTE: RESUMEN_EJECUTIVO → Mejora #3] |
| **Boxes Consecutivos** | Contador de boxes positivos o negativos consecutivos para validar timing de ETAPA 1 | `int consecutivePositiveBoxes` + `int consecutiveNegativeBoxes` | [FUENTE: RESUMEN_EJECUTIVO → Mejora #1 pseudocódigo] |
| **SwingHigh** | Pivote alto en Renko. High[0] < High[1] | `double lastSwingHigh` + `int lastSwingHighBar` | [FUENTE: JSON → indicator_current.key_components.swing_detection] |
| **SwingLow** | Pivote bajo en Renko. Low[0] > Low[1] | `double lastSwingLow` + `int lastSwingLowBar` | [FUENTE: JSON → indicator_current.key_components.swing_detection] |

---

### ⚠️ INCERTIDUMBRES Y PREGUNTAS CERRADAS

#### INCERTO #1: Acceso a FPLEME_M7_II
**Evidencia Falta:** No se confirma si FPLEME_M7_II expone propiedades públicas para acceso desde otro indicador.  
**Pregunta Cerrada:** ¿FPLEME_M7_II expone públicamente una propiedad `double FplemeValue` o serie `Values[0]` accesible desde MFSScalpIndicator en NT8? **(Sí/No)**  
**Plan B Técnico:**  
- **Opción A:** Usar SHARK calculado internamente (ya implementado en v2.0) como proxy de FPLEME. [FUENTE: JSON → indicator_current.key_components.shark_filter.calculation]  
- **Opción B:** Replicar cálculo exacto de FPLEME (complejo, requiere reverse engineering). [FUENTE: JSON → improvement_roadmap.research_needed[0]]  
**Impacto:** CRÍTICO - sin acceso real a FPLEME, el indicador no "piensa como FPLEME".

#### INCERTO #2: Acceso a The_Wall Color de MAPS_M7
**Evidencia Falta:** No se confirma si MAPS_M7 expone color de The_Wall públicamente.  
**Pregunta Cerrada:** ¿MAPS_M7 expone un método público `WallColor GetWallColor()` o propiedad `WallColor` accesible desde otro indicador? **(Sí/No)**  
**Alternativa:** ¿VX_M7 expone `WallColor GetVXWallColor()`? **(Sí/No)**  
**Plan B Técnico:**  
- **Opción A:** Analizar barras de precio relativas a MAP0 (si MAP0 accesible) para inferir color. [FUENTE: JSON → improvement_roadmap.research_needed[1]]  
- **Opción B:** Implementar cálculo de The_Wall independiente (complejo).  
- **Opción C:** Usar VX_M7 como proxy si disponible.  
**Impacto:** CRÍTICO - The_Wall es filtro obligatorio (regla inviolable).

#### INCERTO #3: Cálculo Exacto de MAP vs MAPS_M7
**Evidencia Falta:** Cálculo actual `(midPrice - SMA20) / ATR14` puede no coincidir con MAPS_M7 real.  
**Pregunta Cerrada:** ¿El cálculo MAP de MAPS_M7 es exactamente `(Close - SMA(Close, 20)) / ATR(14)`? **(Sí/No/Otro)**  
**Plan B Técnico:**  
- **Opción A:** Si MAPS_M7 expone `double MAP0`, usar directamente y calcular índice como `(Close - MAP0) / ATR(14)`.  
- **Opción B:** Validar cálculo actual con backtest comparando escenarios PPM/MM detectados vs MAPS_M7 visual.  
**Impacto:** MEDIO - afecta detección de escenarios PPM/MM.

#### INCERTO #4: Timing Entry Classic vs Mode 2.2 para ETAPA 2
**Evidencia Falta:** Documentación menciona 2 modos pero no especifica cuál por defecto.  
**Pregunta Cerrada:** Para ETAPA 2, ¿usar timing Classic (entrada en box anterior) o Mode 2.2 (entrada en box actual)? **(Classic/Mode2.2)**  
**Plan B Técnico:**  
- **Opción A:** Implementar como parámetro configurable `EntryTimingMode` con default Classic.  
- **Opción B:** Posponer ETAPA 2 hasta validar ETAPA 1 en producción.  
**Impacto:** BAJO - ETAPA 2 NO es prioritario (implementar después de ETAPA 1).

---

## B) MÁQUINA DE ESTADOS (STATE MACHINE)

### Definición de Estados y Transiciones

#### Estado de Ciclo (`CycleState`)
```csharp
public enum CycleState
{
    Unknown = 0,    // Estado inicial/indeterminado
    Bull = 1,       // Ciclo comprador (FPLEME en zona bull)
    Bear = -1,      // Ciclo vendedor (FPLEME en zona bear)
    Neutral = 2     // Equilibrio/transición (FPLEME entre -4 y +4 sin confirmar)
}
```

**Transiciones:**

| Desde | Trigger (Condición Exacta) | Guard Conditions | Hacia | Side Effects |
|-------|---------------------------|------------------|-------|--------------|
| `Unknown` | `fplemeValue >= FPLEME_CONFIRMATION_LONG` (>=4) | Ninguna | `Bull` | `cycleDirection = 1` [FUENTE: JSON → indicator_current.key_components.cycle_detection] |
| `Unknown` | `fplemeValue <= FPLEME_CONFIRMATION_SHORT` (<=4) | Ninguna | `Bear` | `cycleDirection = -1` |
| `Unknown` | `fplemeValue > -4 && fplemeValue < 4` | Ninguna | `Neutral` | `cycleDirection = 0` |
| `Bear` | `fplemePrevValue <= -4 && fplemeValue >= 0` | NOT from extremes: `fplemePrevValue > FPLEME_LOW` (-8) | `Bull` | `cycleDirection = 1`, resetear `consecutivePositiveBoxes = 1`, marcar potencial ETAPA 1 Long [FUENTE: RESUMEN_EJECUTIVO → Mejora #1] |
| `Bull` | `fplemePrevValue >= 4 && fplemeValue <= 0` | NOT from extremes: `fplemePrevValue < FPLEME_HIGH` (+8) | `Bear` | `cycleDirection = -1`, resetear `consecutiveNegativeBoxes = 1`, marcar potencial ETAPA 1 Short |
| `Bull` | `fplemeValue < FPLEME_CONFIRMATION_LONG` (< 4) Y NO cruza 0 | Ninguna | `Neutral` | `cycleDirection = 0` (⚠️ ciclo inválido) |
| `Bear` | `fplemeValue > FPLEME_CONFIRMATION_SHORT` (> -4) Y NO cruza 0 | Ninguna | `Neutral` | `cycleDirection = 0` (⚠️ ciclo inválido) |
| `Neutral` | `fplemeValue >= 4` | Ninguna | `Bull` | `cycleDirection = 1` |
| `Neutral` | `fplemeValue <= -4` | Ninguna | `Bear` | `cycleDirection = -1` |

**✅ Definido:** Transiciones de CycleState  
**✅ Definido:** Triggers y guards basados en niveles FPLEME exactos

---

#### Estado de Etapa (`EtapaState`)
```csharp
public enum EtapaState
{
    None = 0,           // Sin etapa activa
    Etapa1Long = 1,     // ETAPA 1 compradora detectada
    Etapa1Short = 2,    // ETAPA 1 vendedora detectada
    Etapa2Long = 3,     // ETAPA 2 compradora (NO PRIORITARIO)
    Etapa2Short = 4     // ETAPA 2 vendedora (NO PRIORITARIO)
}
```

**Transiciones:**

| Desde | Trigger (Condición Exacta) | Guard Conditions | Hacia | Side Effects |
|-------|---------------------------|------------------|-------|--------------|
| `None` | `CycleState` cambia de `Bear` a `Bull` | 1. `consecutivePositiveBoxes == 2 OR ==3` [FUENTE: RESUMEN_EJECUTIVO → Mejora #1]<br>2. `fplemePrevValue <= -4 && fplemeValue >= 0`<br>3. `fplemePrevValue > FPLEME_LOW` (NO desde -8/-12)<br>4. `sharkState == SharkState.Bullish` (alineación) | `Etapa1Long` | Marcar `etapa1LongConfirmed = true`, guardar `etapa1ConfirmationBar = CurrentBar`, calcular `entryPrice = Low[1]` (base del box anterior) [FUENTE: JSON → fpleme_philosophy.timing_precision.etapa1_timing.placement.LONG] |
| `None` | `CycleState` cambia de `Bull` a `Bear` | 1. `consecutiveNegativeBoxes == 2 OR ==3`<br>2. `fplemePrevValue >= 4 && fplemeValue <= 0`<br>3. `fplemePrevValue < FPLEME_HIGH` (NO desde +8/+12)<br>4. `sharkState == SharkState.Bearish` | `Etapa1Short` | Marcar `etapa1ShortConfirmed = true`, `etapa1ConfirmationBar = CurrentBar`, `entryPrice = High[1]` (topo del box anterior) [FUENTE: JSON → fpleme_philosophy.timing_precision.etapa1_timing.placement.SHORT] |
| `Etapa1Long` | Trade ejecutado O invalidación | Trade colocado O `fplemeValue` rompe 0 hacia abajo y alcanza -4 | `None` | Resetear `etapa1LongConfirmed = false`, `currentEtapa = EtapaState.None` [FUENTE: JSON → fpleme_philosophy.operational_principles.7_stops_and_invalidation.etapa1_long.invalidation] |
| `Etapa1Short` | Trade ejecutado O invalidación | Trade colocado O `fplemeValue` rompe 0 hacia arriba y alcanza +4 | `None` | Resetear `etapa1ShortConfirmed = false`, `currentEtapa = EtapaState.None` [FUENTE: JSON → fpleme_philosophy.operational_principles.7_stops_and_invalidation.etapa1_short.invalidation] |
| `None` | ⚠️ ETAPA 2 triggers (NO PRIORITARIO) | (Ver sección ETAPA 2 en Parte 2) | `Etapa2Long/Short` | ⚠️ INCERTO: Implementar después de validar ETAPA 1 |

**✅ Definido:** Transiciones para ETAPA 1 Long y Short  
**⚠️ INCERTO:** ETAPA 2 transiciones (NO prioritario - posponer implementación)

---

#### Estado de Contexto (`ScenarioType`)
```csharp
public enum ScenarioType
{
    None = 0,       // Sin escenario claro
    PpmBuy = 1,     // Convergencia compradora
    PpmSell = 2,    // Convergencia vendedora
    MM = 3          // Divergencia (MAP com MAP)
}
```

**Transiciones:**

| Desde | Trigger (Condición Exacta) | Guard Conditions | Hacia | Side Effects |
|-------|---------------------------|------------------|-------|--------------|
| `None` | SwingLow detectado y `cycleRefValid == true` | 1. `cycleDirection > 0` (Bull)<br>2. `cycle2Valid == true`<br>3. `cycle2MapIndex > cycleRefMapIndex` | `PpmBuy` | Ninguno (escenario actualizado) [FUENTE: JSON → fpleme_philosophy.fundamental_concepts.context_over_signal.contexts.PPM_buy] |
| `None` | SwingHigh detectado y `cycleRefValid == true` | 1. `cycleDirection < 0` (Bear)<br>2. `cycle2Valid == true`<br>3. `cycle2MapIndex < cycleRefMapIndex` | `PpmSell` | Ninguno [FUENTE: JSON → fpleme_philosophy.fundamental_concepts.context_over_signal.contexts.PPM_sell] |
| `None` | Swing detectado (High o Low) | 1. `cycleRefValid == true`<br>2. `cycle2Valid == true`<br>3. `cycle2MapIndex == cycleRefMapIndex` | `MM` | Ninguno [FUENTE: JSON → fpleme_philosophy.fundamental_concepts.context_over_signal.contexts.MM] |
| `PpmBuy` | Swing actualizado | `cycle2MapIndex <= cycleRefMapIndex` | `None` o `MM` | Escenario se invalida |
| `PpmSell` | Swing actualizado | `cycle2MapIndex >= cycleRefMapIndex` | `None` o `MM` | Escenario se invalida |
| `MM` | Swing actualizado | `cycle2MapIndex != cycleRefMapIndex` | `PpmBuy` o `PpmSell` | Escenario evoluciona |
| ANY | `cycleRefValid == false` O `cycle2Valid == false` | Ciclos no establecidos | `None` | Resetear escenario [FUENTE: JSON → fpleme_philosophy.fundamental_concepts.context_over_signal.contexts.no_scenario] |

**✅ Definido:** Transiciones de ScenarioType basadas en MAP progression  
**✅ Definido:** Dependencias de cycleRef y cycle2 válidos

---

#### Estado de Seguridad/The_Wall (`WallState`)
```csharp
public enum WallState
{
    Unknown = 0,        // No se puede determinar (sin acceso a API)
    AllowsLong = 1,     // The_Wall permite LONG (NO rosa/magenta)
    AllowsShort = 2,    // The_Wall permite SHORT (NO verde)
    Neutral = 3,        // The_Wall amarillo - permite ambos con precaución
    BlocksBoth = 4      // ⚠️ Estado teórico (no debería ocurrir en MAPS real)
}
```

**Transiciones:**

| Desde | Trigger (Condición Exacta) | Guard Conditions | Hacia | Side Effects |
|-------|---------------------------|------------------|-------|--------------|
| `Unknown` | `wallColor` detectado (si API disponible) | Ninguna | Según color | Actualizar `wallState` |
| ANY | `wallColor == WallColor.Green` | ⚠️ IF API disponible | `AllowsLong` | **BLOQUEAR** todas señales SHORT [FUENTE: JSON → fpleme_philosophy.operational_principles.1_never_against_the_wall] |
| ANY | `wallColor == WallColor.Pink OR WallColor.Magenta` | ⚠️ IF API disponible | `AllowsShort` | **BLOQUEAR** todas señales LONG |
| ANY | `wallColor == WallColor.Yellow` | ⚠️ IF API disponible | `Neutral` | Permitir ambos con calidad reducida (MEDIUM en PAT) |
| ANY | API no disponible | NO hay acceso a MAPS_M7 o VX_M7 | `Unknown` | ⚠️ INCERTO: Usar fallback (ver Plan B) |

**⚠️ INCERTO:** Acceso a wallColor (requiere API de MAPS_M7 o VX_M7)  
**🔎 Cómo resolverlo:** Responder pregunta cerrada INCERTO #2  
**Plan B:** Si no hay API, implementar proxy basado en análisis de precio vs MAP0 o usar modo permisivo temporal

---

#### Estado de Calidad (`SignalQuality`)
```csharp
public enum SignalQuality
{
    Low = 0,        // <=2 capas OK - EVITAR trade
    Medium = 1,     // 3 capas OK - Operar con precaución
    High = 2        // 4 capas OK (PAT) - Operar con confianza
}
```

**Cálculo (NO es máquina de estados, es scoring):**

```csharp
SignalQuality EvaluateSignalQuality(SignalDirection direction)
{
    int patScore = 0;
    
    // Capa 1: FPLEME en niveles válidos (no extremos +-8, +-12)
    if (fplemeValue >= FPLEME_LOW && fplemeValue <= FPLEME_HIGH)
    {
        patScore++;
    }
    
    // Capa 2: SHARK alineado con FPLEME
    if (IsSharkAlignedWithFpleme())
    {
        patScore++;
    }
    
    // Capa 3: Escenario favorable
    if (IsFavorableScenario(direction))
    {
        patScore++;
    }
    
    // Capa 4: The_Wall NO en contra
    if (!IsAgainstWall(direction))
    {
        patScore++;
    }
    
    // Mapeo de score a quality
    if (patScore == 4) return SignalQuality.High;
    if (patScore == 3) return SignalQuality.Medium;
    return SignalQuality.Low;
}

bool IsFavorableScenario(SignalDirection direction)
{
    if (direction == SignalDirection.Long)
    {
        // PPM Buy = ALTA calidad, MM = MEDIA, None o PPM Sell = BAJA
        return (currentScenario == ScenarioType.PpmBuy) ||
               (currentScenario == ScenarioType.MM && sharkState == SharkState.Bullish);
    }
    else // SHORT
    {
        return (currentScenario == ScenarioType.PpmSell) ||
               (currentScenario == ScenarioType.MM && sharkState == SharkState.Bearish);
    }
}

bool IsAgainstWall(SignalDirection direction)
{
    if (wallState == WallState.Unknown)
    {
        // ⚠️ INCERTO: Sin acceso a The_Wall, asumir neutral
        return false; // Modo permisivo por defecto
    }
    
    if (direction == SignalDirection.Long)
    {
        // LONG bloqueado si The_Wall AllowsShort (rosa/magenta)
        return (wallState == WallState.AllowsShort);
    }
    else // SHORT
    {
        // SHORT bloqueado si The_Wall AllowsLong (verde)
        return (wallState == WallState.AllowsLong);
    }
}
```

**✅ Definido:** Scoring PAT con 4 capas  
**✅ Definido:** Mapeo score → quality  
**⚠️ INCERTO:** Comportamiento cuando wallState == Unknown (fallback permisivo)

[FUENTE: RESUMEN_EJECUTIVO → Mejora #3]

---

## RESUMEN PARTE 1

**✅ COMPLETADO:**
- Tabla completa Concepto FPLEME → Variable NT8 (33 conceptos mapeados)
- Máquina de estados para CycleState (8 transiciones)
- Máquina de estados para EtapaState (4 transiciones principales)
- Máquina de estados para ScenarioType (8 transiciones)
- Máquina de estados para WallState (5 transiciones)
- Sistema de scoring PAT para SignalQuality

**⚠️ INCERTIDUMBRES IDENTIFICADAS:**
- INCERTO #1: Acceso a FPLEME_M7_II (CRÍTICO)
- INCERTO #2: Acceso a The_Wall de MAPS_M7 (CRÍTICO)
- INCERTO #3: Cálculo MAP exacto (MEDIO)
- INCERTO #4: Timing ETAPA 2 (BAJO - NO prioritario)

**PRÓXIMO:** PARTE 2 - Reglas de Señal ETAPA 1 (detalladas paso a paso)

---

*Continúa en archivo ESPEC_TECNICA_PARTE2_REGLAS_Y_FILTROS.md*
