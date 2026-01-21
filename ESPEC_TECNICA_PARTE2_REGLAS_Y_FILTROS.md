# ESPECIFICACIÓN TÉCNICA IMPLEMENTABLE - PARTE 2
## REGLAS DE SEÑAL, FILTROS Y ESCENARIOS

*Continúa de ESPEC_TECNICA_PARTE1_CONCEPTOS_Y_ESTADOS.md*

---

## C) REGLAS DE SEÑAL - ETAPA 1 (Prioridad #1)

### C.1) ETAPA 1 LONG - Especificación Paso a Paso

**Concepto:** Detectar inicio de ciclo comprador cuando FPLEME sale de zona vendedora (-4) hacia equilibrio (0) con timing preciso en 2º o 3er box positivo.

[FUENTE: RESUMEN_EJECUTIVO → Mejora #1 + JSON → fpleme_philosophy.fundamental_concepts.cycle_detection]

#### C.1.1) Condición Base

**Trigger Principal:**
```csharp
bool etapa1LongBaseTrigger = (fplemePrevValue <= FPLEME_CONFIRMATION_SHORT) && 
                              (fplemeValue >= FPLEME_EQUILIBRIUM);
```

**Explicación:**
- `fplemePrevValue <= -4.0`: FPLEME estaba en o debajo de nivel de confirmación SHORT
- `fplemeValue >= 0.0`: FPLEME alcanzó o superó equilibrio
- **Esto representa la salida de -4 hacia 0** ✅ Definido

[FUENTE: JSON → technical_glossary.ETAPA 1]

---

#### C.1.2) Reglas de Timing - Box Count (CRÍTICO)

**Validación de 2º o 3er Box:**
```csharp
int CountConsecutivePositiveBoxes()
{
    int count = 0;
    // Box actual es positivo (Close[0] > Open[0] en Renko)
    if (Close[0] > Open[0])
    {
        count = 1;
        
        // Contar hacia atrás
        for (int i = 1; i < 10 && i <= CurrentBar; i++)
        {
            if (Close[i] > Open[i])
            {
                count++;
            }
            else
            {
                break; // Detener al encontrar box negativo
            }
        }
    }
    return count;
}

bool timing = (consecutivePositiveBoxes == 2 || consecutivePositiveBoxes == 3);
```

**Por qué 2º o 3er box:**
- **NO 1er box:** Demasiado temprano, señal no confirmada
- **2º-3er box:** Confirmación de nuevo ciclo sin ser tardío
- **NO 4º+ box:** Demasiado tarde, se pierde inicio del ciclo

✅ Definido: Timing exacto 2 o 3 boxes consecutivos

[FUENTE: JSON → fpleme_philosophy.timing_precision.etapa1_timing.ideal_entry + RESUMEN_EJECUTIVO líneas 120-124]

---

#### C.1.3) Restricciones - NO Desde Extremos

**Validación de Origen:**
```csharp
bool notFromExtreme = (fplemePrevValue > FPLEME_LOW);
// fplemePrevValue debe ser > -8.0
// Si viene de -12 o -8, NO es válido como ETAPA 1
```

**Razón:**
- Desde -12/-8 hasta 0 en pocos boxes = movimiento demasiado rápido/errático
- ETAPA 1 requiere transición controlada desde -4
- Extremos indican agotamiento de ciclo previo, no inicio limpio

✅ Definido: Restricción `fplemePrevValue > -8.0`

[FUENTE: RESUMEN_EJECUTIVO → Mejora #1 línea 122 + JSON → fpleme_philosophy.fundamental_concepts.cycle_detection.key_levels comentarios]

---

#### C.1.4) Alineación SHARK (Confirmación)

**Validación de Confirmador:**
```csharp
bool sharkConfirms = (sharkState == SharkState.Bullish);
// sharkValue > 4.0
```

**Razón:**
- SHARK debe estar alineado con dirección de FPLEME
- Si SHARK neutral o bearish → movimiento lateralizado, NO ciclo real
- Alineación = movimiento fluido confirmado

✅ Definido: Requiere `sharkState == Bullish` para ETAPA 1 LONG

[FUENTE: RESUMEN_EJECUTIVO → Mejora #1 líneas 132-133 + JSON → fpleme_philosophy.tools.SHARK.relationship_with_fpleme]

---

#### C.1.5) Precio de Entrada Teórico

**Cálculo de Entry Price:**
```csharp
double CalculateEtapa1LongEntry(int confirmationBoxIndex)
{
    // Entrada en BASE del box ANTERIOR al de confirmación
    if (confirmationBoxIndex == 2)
    {
        // Confirmó en 2º box → entrada en base del 1er box
        return Low[1];
    }
    else if (confirmationBoxIndex == 3)
    {
        // Confirmó en 3er box → entrada en base del 2º box
        return Low[1];
    }
    
    // Fallback: base del box actual (subóptimo pero funcional)
    return Low[0];
}
```

**Por qué base del box anterior:**
- **NO topo del box positivo:** Entrada en máximo del box = worst fill
- **Base del box anterior:** Entrada en mínimo relativo = mejor R:R
- Timing exacto según filosofía FPLEME

✅ Definido: `entryPrice = Low[1]` (base del box anterior a confirmación)

[FUENTE: JSON → fpleme_philosophy.timing_precision.etapa1_timing.placement.LONG + docs/MAPA_DEL_INDICADOR.md referencia]

---

#### C.1.6) Invalidación (Exit de Setup)

**Condiciones que Invalidan ETAPA 1 LONG:**
```csharp
bool Etapa1LongInvalidated()
{
    // FPLEME rompe 0 hacia abajo Y alcanza -4
    bool crossesBackDown = (fplemePrevValue >= FPLEME_EQUILIBRIUM) &&
                           (fplemeValue <= FPLEME_CONFIRMATION_SHORT);
    
    // O trade ya fue ejecutado
    bool tradeExecuted = (currentTrade != null && currentTrade.Direction == TradeDirection.Long);
    
    return crossesBackDown || tradeExecuted;
}
```

**Razón:**
- Si FPLEME vuelve a cruzar 0 hacia -4 → ciclo NO se estableció, falso positivo
- Una vez trade ejecutado → setup consumido

✅ Definido: Invalidación al cruzar 0→-4 o trade ejecutado

[FUENTE: JSON → fpleme_philosophy.operational_principles.7_stops_and_invalidation.etapa1_long.invalidation]

---

#### C.1.7) Stop Recomendado

**Cálculo de Stop Loss:**
```csharp
double CalculateEtapa1LongStop()
{
    // Opción 1: Debajo del último swing bajo del ciclo
    double stopAtSwing = lastSwingLow - (2 * TickSize);
    
    // Opción 2: 1 box negativo debajo de entrada (máximo)
    double stopAtOneBox = entryPrice - (boxSize);
    
    // Usar el más cercano (menos riesgo)
    double stop = Math.Max(stopAtSwing, stopAtOneBox);
    
    return stop;
}
```

**Rangos:**
- **Mínimo:** Debajo del último fondo del ciclo
- **Máximo:** 1 box Renko negativo debajo de entrada
- **Recomendado:** Usar SL paramétrico (40 ticks) si es menor que máximo

✅ Definido: Stop entre último swing low y 1 box debajo

[FUENTE: JSON → fpleme_philosophy.operational_principles.7_stops_and_invalidation.etapa1_long]

---

#### C.1.8) Dependencias (Variables Requeridas)

**Variables que DEBEN estar disponibles:**
```csharp
// CRÍTICAS:
double fplemeValue;              // Valor actual de FPLEME
double fplemePrevValue;          // Valor anterior de FPLEME (barra previa)
SharkState sharkState;           // Estado actual de SHARK
int consecutivePositiveBoxes;   // Contador de boxes positivos

// IMPORTANTES:
double lastSwingLow;            // Último swing bajo (para stop)
int lastSwingLowBar;            // Barra del último swing bajo
WallState wallState;            // Estado de The_Wall (para PAT)
ScenarioType currentScenario;   // Escenario actual (para PAT)

// AUXILIARES:
int CurrentBar;                 // Barra actual
double Low[int barsAgo];        // Array de lows (para entry price)
```

✅ Definido: Lista de dependencias críticas y auxiliares

---

### C.1.9) Pseudocódigo Completo - ETAPA 1 LONG

```csharp
// ============================================================
// ETAPA 1 LONG - DETECCIÓN Y SEÑAL
// ============================================================

void DetectEtapa1Long()
{
    // 1. CONDICIÓN BASE: Salida de -4 hacia 0
    bool baseTrigger = (fplemePrevValue <= FPLEME_CONFIRMATION_SHORT) && 
                       (fplemeValue >= FPLEME_EQUILIBRIUM);
    
    if (!baseTrigger)
        return; // No cumple condición fundamental
    
    // 2. TIMING: 2º o 3er box positivo
    int positiveBoxCount = CountConsecutivePositiveBoxes();
    bool correctTiming = (positiveBoxCount == 2 || positiveBoxCount == 3);
    
    if (!correctTiming)
        return; // Timing incorrecto (demasiado temprano o tardío)
    
    // 3. RESTRICCIÓN: NO desde extremos
    bool notFromExtreme = (fplemePrevValue > FPLEME_LOW); // > -8
    
    if (!notFromExtreme)
        return; // Viene de extremo, señal inválida
    
    // 4. CONFIRMACIÓN: SHARK alineado
    bool sharkAligned = (sharkState == SharkState.Bullish); // SHARK > 4
    
    if (!sharkAligned)
        return; // SHARK no confirma, movimiento lateralizado
    
    // 5. FILTRO THE_WALL (si disponible)
    if (wallState != WallState.Unknown)
    {
        if (wallState == WallState.AllowsShort) // The_Wall rosa/magenta
        {
            return; // BLOQUEADO por The_Wall - NUNCA contra el muro
        }
    }
    
    // ✅ TODAS LAS VALIDACIONES PASADAS - ETAPA 1 LONG CONFIRMADA
    
    // 6. CALCULAR ENTRY PRICE
    double entryPrice = Low[1]; // Base del box anterior
    
    // 7. CALCULAR STOP LOSS
    double stopLoss = Math.Max(
        lastSwingLow - (2 * TickSize),
        entryPrice - (SlTicks * TickSize) // Fallback paramétrico
    );
    
    // 8. CALCULAR TAKE PROFIT
    double takeProfit = entryPrice + (TpTicks * TickSize);
    
    // 9. EVALUAR CALIDAD (PAT)
    SignalQuality quality = EvaluateSignalQuality(SignalDirection.Long);
    
    // 10. DECISIÓN DE TRADE
    if (quality == SignalQuality.High)
    {
        // PAT completo (4 capas) → Operar con confianza
        GenerateSignal(
            direction: TradeDirection.Long,
            entry: entryPrice,
            stop: stopLoss,
            target: takeProfit,
            quality: quality,
            reason: "ETAPA 1 LONG - PAT HIGH"
        );
    }
    else if (quality == SignalQuality.Medium)
    {
        // 3 capas OK → Operar con precaución o skip
        if (AllowMediumQualityTrades) // Parámetro configurable
        {
            GenerateSignal(
                direction: TradeDirection.Long,
                entry: entryPrice,
                stop: stopLoss,
                target: takeProfit,
                quality: quality,
                reason: "ETAPA 1 LONG - PAT MEDIUM"
            );
        }
    }
    else // Low quality
    {
        // NO generar señal - calidad insuficiente
        LogDebug("ETAPA 1 LONG detectado pero PAT LOW - señal bloqueada");
    }
}
```

✅ Definido: Pseudocódigo completo con 10 pasos validados

[FUENTE: RESUMEN_EJECUTIVO → Mejora #1 completa]

---

### C.2) ETAPA 1 SHORT - Especificación Paso a Paso

**Simetría con ETAPA 1 LONG** (condiciones inversas):

#### C.2.1) Condición Base
```csharp
bool etapa1ShortBaseTrigger = (fplemePrevValue >= FPLEME_CONFIRMATION_LONG) && 
                               (fplemeValue <= FPLEME_EQUILIBRIUM);
// Salida de +4 hacia 0
```

#### C.2.2) Timing
```csharp
int CountConsecutiveNegativeBoxes(); // Similar a positive pero boxes negativos
bool timing = (consecutiveNegativeBoxes == 2 || consecutiveNegativeBoxes == 3);
```

#### C.2.3) Restricciones
```csharp
bool notFromExtreme = (fplemePrevValue < FPLEME_HIGH); // < +8.0
```

#### C.2.4) Alineación SHARK
```csharp
bool sharkConfirms = (sharkState == SharkState.Bearish); // SHARK < -4
```

#### C.2.5) Entry Price
```csharp
double entryPrice = High[1]; // Topo del box anterior
```

#### C.2.6) Invalidación
```csharp
bool invalidated = (fplemePrevValue <= 0 && fplemeValue >= FPLEME_CONFIRMATION_LONG);
// FPLEME rompe 0 hacia arriba y alcanza +4
```

#### C.2.7) Stop
```csharp
double stop = Math.Min(
    lastSwingHigh + (2 * TickSize),
    entryPrice + (SlTicks * TickSize)
);
```

✅ Definido: ETAPA 1 SHORT es simétrico a LONG

[FUENTE: RESUMEN_EJECUTIVO → Mejora #1 + JSON simetría implícita]

---

## D) THE_WALL - FILTRO INVIOLABLE (Prioridad #2)

### D.1) Regla Fundamental

**Principio Absoluto:**
> "NUNCA operar contra The_Wall"

[FUENTE: JSON → fpleme_philosophy.operational_principles.1_never_against_the_wall.rule]

---

### D.2) Definición de Regla por Color

```csharp
enum WallColor
{
    Unknown,    // Sin acceso a API
    Green,      // Alta fuerza de compra
    Pink,       // Alta fuerza de venta
    Magenta,    // Alta fuerza de venta (variante)
    Yellow      // Consolidación/equilibrio
}

// REGLA #1: The_Wall Verde → BLOQUEAR SHORT
if (wallColor == WallColor.Green)
{
    // PROHIBIDO: Generar cualquier señal SHORT
    // Razón: Ir contra fuerza dominante compradora
    if (signalDirection == SignalDirection.Short)
    {
        return; // BLOQUEADO
    }
}

// REGLA #2: The_Wall Rosa/Magenta → BLOQUEAR LONG
if (wallColor == WallColor.Pink || wallColor == WallColor.Magenta)
{
    // PROHIBIDO: Generar cualquier señal LONG
    // Razón: Ir contra fuerza dominante vendedora
    if (signalDirection == SignalDirection.Long)
    {
        return; // BLOQUEADO
    }
}

// REGLA #3: The_Wall Amarillo → NEUTRAL (permitir con precaución)
if (wallColor == WallColor.Yellow)
{
    // Permitir ambas direcciones pero reducir calidad en PAT
    // (ver sección PAT - Capa 4)
}
```

✅ Definido: Reglas de bloqueo por color exacto

[FUENTE: RESUMEN_EJECUTIVO → Mejora #2 líneas 153-175 + JSON → fpleme_philosophy.tools.MAPS_M7.components.The_Wall.rules]

---

### D.3) Cómo Obtener WallColor

#### D.3.1) Opción A: API de MAPS_M7 (IDEAL)

```csharp
// ⚠️ INCERTO: Requiere confirmación de API pública

// Suponiendo que MAPS_M7 expone método público:
private MAPS_M7 mapsIndicator;

protected override void OnStateChange()
{
    if (State == State.DataLoaded)
    {
        // Intentar obtener instancia de MAPS_M7
        mapsIndicator = Indicators.MAPS_M7(
            cENTRAIS: true,
            iNTERMEDIARIOS: true,
            cLEAN_MODE: false,
            tHE_WALL: true,  // CRÍTICO: The_Wall debe estar activado
            fORCE_LINES: false,
            pULLBACKS: false
        );
    }
}

WallColor GetWallColorFromMAPS()
{
    if (mapsIndicator == null)
        return WallColor.Unknown;
    
    // ⚠️ PREGUNTA CERRADA CRÍTICA:
    // ¿MAPS_M7 expone una propiedad pública WallColor o método GetWallColor()?
    
    // Supuesto (a validar):
    // return (WallColor)mapsIndicator.TheWallColor[0];
    
    return WallColor.Unknown; // Fallback si no hay acceso
}
```

**Pregunta Cerrada:** ¿MAPS_M7 expone `TheWallColor` como serie o propiedad pública accesible? **(Sí/No)**

---

#### D.3.2) Opción B: API de VX_M7 (ALTERNATIVA)

```csharp
// VX_M7 puede exponer The_Wall de forma alternativa
private VXM7 vxIndicator;

protected override void OnStateChange()
{
    if (State == State.DataLoaded)
    {
        vxIndicator = Indicators.VXM7(
            tHE_WALL: true,
            fORCE_LINES: true,
            pULLBACKS: false
        );
    }
}

WallColor GetWallColorFromVX()
{
    if (vxIndicator == null)
        return WallColor.Unknown;
    
    // ⚠️ PREGUNTA CERRADA:
    // ¿VX_M7 expone VXWallColor o método similar?
    
    return WallColor.Unknown; // Fallback
}
```

**Pregunta Cerrada:** ¿VX_M7 expone `VXWallColor` accesible públicamente? **(Sí/No)**

---

#### D.3.3) Opción C: Proxy/Inferencia (FALLBACK)

```csharp
// Si NO hay acceso a API, inferir color por análisis de precio vs SMA
WallColor InferWallColorFromPrice()
{
    // Proxy simplificado (subóptimo pero funcional):
    // - Si precio consistentemente arriba de SMA(20) → inferir Green
    // - Si precio consistentemente abajo de SMA(20) → inferir Pink
    // - Si cruzando frecuentemente → Yellow
    
    double sma20 = SMA(20)[0];
    int barsAboveSMA = 0;
    int barsBelowSMA = 0;
    int lookback = 10;
    
    for (int i = 0; i < lookback; i++)
    {
        if (Close[i] > SMA(20)[i])
            barsAboveSMA++;
        else if (Close[i] < SMA(20)[i])
            barsBelowSMA++;
    }
    
    if (barsAboveSMA >= 8) // 80%+ arriba
        return WallColor.Green;
    else if (barsBelowSMA >= 8) // 80%+ abajo
        return WallColor.Pink;
    else
        return WallColor.Yellow; // Lateral
}
```

⚠️ **ADVERTENCIA:** Este proxy es SUBÓPTIMO y NO reemplaza The_Wall real de MAPS.  
**Usar SOLO si API no disponible.**  
**VALIDAR con backtest comparativo vs MAPS visual.**

---

#### D.3.4) Modo Fallback - Estrategia de Implementación

```csharp
WallColor GetWallColor()
{
    // Prioridad 1: MAPS_M7
    WallColor color = GetWallColorFromMAPS();
    if (color != WallColor.Unknown)
        return color;
    
    // Prioridad 2: VX_M7
    color = GetWallColorFromVX();
    if (color != WallColor.Unknown)
        return color;
    
    // Prioridad 3: Proxy (con advertencia en log)
    LogWarning("The_Wall: Sin acceso a API, usando proxy subóptimo");
    return InferWallColorFromPrice();
}
```

✅ Definido: Estrategia de fallback con 3 niveles  
⚠️ INCERTO: Disponibilidad de API (CRÍTICO - requiere validación)

[FUENTE: JSON → improvement_roadmap.research_needed[1] + RESUMEN_EJECUTIVO → Riesgo #2]

---

### D.4) Pseudocódigo - Filtro The_Wall Completo

```csharp
// ============================================================
// THE_WALL FILTER - BLOQUEO OBLIGATORIO
// ============================================================

bool ApplyTheWallFilter(SignalDirection direction)
{
    // 1. Obtener color de The_Wall
    WallColor wallColor = GetWallColor();
    
    // 2. Aplicar regla inviolable
    if (direction == SignalDirection.Long)
    {
        // LONG bloqueado si The_Wall rosa/magenta
        if (wallColor == WallColor.Pink || wallColor == WallColor.Magenta)
        {
            LogDebug($"SEÑAL LONG BLOQUEADA: The_Wall {wallColor} impide LONGs");
            return false; // BLOQUEADO
        }
    }
    else if (direction == SignalDirection.Short)
    {
        // SHORT bloqueado si The_Wall verde
        if (wallColor == WallColor.Green)
        {
            LogDebug($"SEÑAL SHORT BLOQUEADA: The_Wall {wallColor} impide SHORTs");
            return false; // BLOQUEADO
        }
    }
    
    // 3. The_Wall permite señal (verde para LONG, rosa para SHORT, o amarillo neutral)
    return true; // PERMITIDO
}

// Uso en generación de señal:
if (!ApplyTheWallFilter(signalDirection))
{
    return; // Señal bloqueada por The_Wall - NO generar trade
}
```

✅ Definido: Filtro completo con logging y bloqueo explícito

[FUENTE: RESUMEN_EJECUTIVO → Mejora #2 completa]

---

## E) PAT (PERFECT ALIGNMENT TRIGGER) Y SCORING

### E.1) Definición de PAT

**PAT = 4 Capas de Validación Simultánea**

Sistema de scoring que evalúa calidad de señal basándose en alineación de 4 componentes fundamentales.

[FUENTE: RESUMEN_EJECUTIVO → Mejora #3 + JSON → fpleme_philosophy.confirmation_layers]

---

### E.2) Las 4 Capas de PAT

#### CAPA 1: FPLEME en Niveles Válidos

**Condición:**
```csharp
bool Layer1_FplemeValid(SignalDirection direction)
{
    // FPLEME NO debe estar en extremos +-8 o +-12
    bool notInExtremes = (fplemeValue >= FPLEME_LOW) &&      // > -8
                         (fplemeValue <= FPLEME_HIGH);       // < +8
    
    // Además, debe estar en zona apropiada para la dirección
    if (direction == SignalDirection.Long)
    {
        // Para LONG: FPLEME debe ser >= -4 (en o saliendo de zona vendedora)
        return notInExtremes && (fplemeValue >= FPLEME_CONFIRMATION_SHORT);
    }
    else // SHORT
    {
        // Para SHORT: FPLEME debe ser <= +4 (en o saliendo de zona compradora)
        return notInExtremes && (fplemeValue <= FPLEME_CONFIRMATION_LONG);
    }
}
```

**Razón:** Evitar entradas en agotamiento de ciclo (extremos)

✅ Definido: Validación de niveles FPLEME válidos

---

#### CAPA 2: SHARK Alineado

**Condición:**
```csharp
bool Layer2_SharkAligned(SignalDirection direction)
{
    if (direction == SignalDirection.Long)
    {
        // Para LONG: SHARK debe ser Bullish (> +4)
        return (sharkState == SharkState.Bullish);
    }
    else // SHORT
    {
        // Para SHORT: SHARK debe ser Bearish (< -4)
        return (sharkState == SharkState.Bearish);
    }
}
```

**Razón:** Confirmar que ciclo es real, no movimiento lateralizado

✅ Definido: Alineación SHARK obligatoria

---

#### CAPA 3: Escenario Favorable

**Condición:**
```csharp
bool Layer3_FavorableScenario(SignalDirection direction)
{
    if (direction == SignalDirection.Long)
    {
        // LONG favorecido por:
        // - PPM Buy (convergencia compradora) = ALTA calidad
        // - MM con SHARK bullish = MEDIA calidad
        bool ppmBuy = (currentScenario == ScenarioType.PpmBuy);
        bool mmWithShark = (currentScenario == ScenarioType.MM) && 
                          (sharkState == SharkState.Bullish);
        
        return ppmBuy || mmWithShark;
    }
    else // SHORT
    {
        // SHORT favorecido por:
        // - PPM Sell (convergencia vendedora) = ALTA calidad
        // - MM con SHARK bearish = MEDIA calidad
        bool ppmSell = (currentScenario == ScenarioType.PpmSell);
        bool mmWithShark = (currentScenario == ScenarioType.MM) && 
                          (sharkState == SharkState.Bearish);
        
        return ppmSell || mmWithShark;
    }
}
```

**Razón:** Context > Signal - priorizar trades en escenarios favorables

✅ Definido: Lógica de escenario favorable por dirección

---

#### CAPA 4: The_Wall NO en Contra

**Condición:**
```csharp
bool Layer4_TheWallNotAgainst(SignalDirection direction)
{
    // Si wallState es Unknown, modo permisivo
    if (wallState == WallState.Unknown)
    {
        return true; // Permitir (con advertencia ya loggeada)
    }
    
    if (direction == SignalDirection.Long)
    {
        // LONG permitido si The_Wall NO es AllowsShort (rosa/magenta)
        return (wallState != WallState.AllowsShort);
    }
    else // SHORT
    {
        // SHORT permitido si The_Wall NO es AllowsLong (verde)
        return (wallState != WallState.AllowsLong);
    }
}
```

**Razón:** Regla inviolable - nunca contra fuerza dominante

✅ Definido: Validación The_Wall con fallback

---

### E.3) Sistema de Scoring

```csharp
enum SignalQuality
{
    Low = 0,     // <=2 capas OK - EVITAR
    Medium = 1,  // 3 capas OK - Precaución
    High = 2     // 4 capas OK - Confianza
}

SignalQuality EvaluateSignalQuality(SignalDirection direction)
{
    int patScore = 0;
    
    // Evaluar cada capa
    if (Layer1_FplemeValid(direction))     patScore++;
    if (Layer2_SharkAligned(direction))    patScore++;
    if (Layer3_FavorableScenario(direction)) patScore++;
    if (Layer4_TheWallNotAgainst(direction)) patScore++;
    
    // Mapeo score → quality
    if (patScore == 4) return SignalQuality.High;   // PAT completo
    if (patScore == 3) return SignalQuality.Medium; // Casi PAT
    return SignalQuality.Low;                        // Insuficiente
}
```

✅ Definido: Scoring 0-4 con mapeo a quality

---

### E.4) Tabla de Decisiones PAT

| Dirección | FPLEME Válido | SHARK Alineado | Escenario | The_Wall | Score | Quality | Acción |
|-----------|---------------|----------------|-----------|----------|-------|---------|--------|
| LONG | ✅ | ✅ | PPM Buy | Verde/Amarillo | 4 | HIGH | ✅ OPERAR confianza |
| LONG | ✅ | ✅ | MM | Verde/Amarillo | 4 | HIGH | ✅ OPERAR confianza |
| LONG | ✅ | ✅ | PPM Buy | Rosa | 3 | MEDIUM | ⚠️ Precaución o skip |
| LONG | ✅ | ✅ | None | Verde | 3 | MEDIUM | ⚠️ Precaución o skip |
| LONG | ✅ | ❌ | PPM Buy | Verde | 3 | MEDIUM | ⚠️ Precaución (SHARK desalineado) |
| LONG | ❌ (extremo) | ✅ | PPM Buy | Verde | 3 | MEDIUM | ⚠️ Precaución (en extremo) |
| LONG | ✅ | ✅ | None | Amarillo | 3 | MEDIUM | ⚠️ Sin escenario claro |
| LONG | ANY | ANY | ANY | Rosa/Magenta | 0 | BLOCKED | ❌ BLOQUEADO por Wall |
| LONG | ✅ | ❌ | None | Rosa | <=2 | LOW | ❌ EVITAR |
| LONG | ❌ | ❌ | ANY | ANY | <=2 | LOW | ❌ EVITAR |
| SHORT | ✅ | ✅ | PPM Sell | Rosa/Amarillo | 4 | HIGH | ✅ OPERAR confianza |
| SHORT | ✅ | ✅ | MM | Rosa/Amarillo | 4 | HIGH | ✅ OPERAR confianza |
| SHORT | ANY | ANY | ANY | Verde | 0 | BLOCKED | ❌ BLOQUEADO por Wall |
| SHORT | ✅ | ❌ | PPM Sell | Rosa | 3 | MEDIUM | ⚠️ Precaución |
| SHORT | ✅ | ✅ | None | Rosa | 3 | MEDIUM | ⚠️ Sin escenario |
| SHORT | ❌ | ❌ | ANY | ANY | <=2 | LOW | ❌ EVITAR |

✅ Definido: Tabla completa de decisiones con 16 casos ejemplo

---

### E.5) Uso de SignalQuality en Generación de Señal

```csharp
void GenerateSignalIfQualitySufficient(
    SignalDirection direction,
    double entryPrice,
    double stopLoss,
    double takeProfit)
{
    // 1. Evaluar calidad
    SignalQuality quality = EvaluateSignalQuality(direction);
    
    // 2. Decisión basada en quality
    switch (quality)
    {
        case SignalQuality.High:
            // PAT completo - operar con confianza
            CreateSignal(direction, entryPrice, stopLoss, takeProfit, quality);
            LogInfo($"✅ SEÑAL {direction} GENERADA - PAT HIGH (4/4)");
            break;
            
        case SignalQuality.Medium:
            // 3 capas OK - decisión según parámetro
            if (AllowMediumQualitySignals) // Parámetro configurable
            {
                CreateSignal(direction, entryPrice, stopLoss, takeProfit, quality);
                LogInfo($"⚠️ SEÑAL {direction} GENERADA - PAT MEDIUM (3/4)");
            }
            else
            {
                LogDebug($"⚠️ SEÑAL {direction} PAT MEDIUM - bloqueada por parámetro");
            }
            break;
            
        case SignalQuality.Low:
            // <=2 capas - NO operar
            LogDebug($"❌ SEÑAL {direction} PAT LOW (<=2/4) - bloqueada");
            break;
    }
}
```

✅ Definido: Lógica de decisión con parámetro configurable para MEDIUM

---

## F) ESCENARIOS PPM/MM

### F.1) Detección de PPM/MM

**Datos Necesarios:**
- `cycleRefMapIndex`: MAP del primer swing del ciclo
- `cycle2MapIndex`: MAP del segundo swing del ciclo
- `cycleDirection`: Dirección del ciclo (1=Bull, -1=Bear)
- `cycleRefValid`: Si cycleRef está establecido
- `cycle2Valid`: Si cycle2 está establecido

[FUENTE: JSON → indicator_current.key_components.map_tracking + cycle_detection]

---

### F.2) Reglas de Detección

```csharp
ScenarioType DetectScenario()
{
    // Prerequisito: Ambos ciclos deben estar válidos
    if (!cycleRefValid || !cycle2Valid)
    {
        return ScenarioType.None;
    }
    
    // PPM Buy: Convergencia compradora
    // - Ciclo Bull (direction > 0)
    // - cycle2MAP progresó por ENCIMA de cycleRefMAP
    if (cycleDirection > 0 && cycle2MapIndex > cycleRefMapIndex)
    {
        return ScenarioType.PpmBuy;
    }
    
    // PPM Sell: Convergencia vendedora
    // - Ciclo Bear (direction < 0)
    // - cycle2MAP progresó por DEBAJO de cycleRefMAP
    if (cycleDirection < 0 && cycle2MapIndex < cycleRefMapIndex)
    {
        return ScenarioType.PpmSell;
    }
    
    // MM: Divergencia
    // - cycle2MAP igual a cycleRefMAP
    if (cycle2MapIndex == cycleRefMapIndex)
    {
        return ScenarioType.MM;
    }
    
    // Ningún escenario detectado
    return ScenarioType.None;
}
```

✅ Definido: Lógica de detección basada en progresión de MAP

[FUENTE: RESUMEN_EJECUTIVO → Mejora #5 líneas 288-321 + JSON → fpleme_philosophy.fundamental_concepts.context_over_signal.contexts]

---

### F.3) Qué Pasa si MAP Real No Disponible

⚠️ **INCERTO:** Si no hay acceso a MAPS_M7 para obtener MAP real:

**Plan B:**
```csharp
int CalculateMapIndexFallback()
{
    // Usar cálculo simplificado actual
    double midPrice = (High[0] + Low[0]) * 0.5;
    double sma20 = SMA(20)[0];
    double atr14 = ATR(14)[0];
    
    if (atr14 <= 0.0)
        return 0;
    
    int mapIndex = (int)Math.Round((midPrice - sma20) / atr14);
    return mapIndex;
}
```

**Validación Requerida:**
- Comparar escenarios detectados con MAP simplificado vs MAPS_M7 visual en backtest
- Si discrepancia > 20% → buscar acceso a MAP real o ajustar cálculo

✅ Definido: Fallback con advertencia de validación

[FUENTE: JSON → indicator_current.key_components.map_tracking.logic + improvement_roadmap.research_needed[2]]

---

### F.4) Casos de Ejemplo PPM/MM

#### Caso 1: PPM Buy
```
Ciclo Bull (direction = 1)
- Swing Low 1: MAP = -2 (cycleRef)
- Swing High: MAP = +3
- Swing Low 2: MAP = 0 (cycle2)

cycle2MapIndex (0) > cycleRefMapIndex (-2) ✅
→ ScenarioType.PpmBuy
→ Calidad ALTA para señales LONG
```

#### Caso 2: PPM Sell
```
Ciclo Bear (direction = -1)
- Swing High 1: MAP = +3 (cycleRef)
- Swing Low: MAP = -1
- Swing High 2: MAP = +1 (cycle2)

cycle2MapIndex (+1) < cycleRefMapIndex (+3) ✅
→ ScenarioType.PpmSell
→ Calidad ALTA para señales SHORT
```

#### Caso 3: MM (Divergencia)
```
Ciclo Bull (direction = 1)
- Swing Low 1: MAP = -1 (cycleRef)
- Swing High: MAP = +2
- Swing Low 2: MAP = -1 (cycle2)

cycle2MapIndex (-1) == cycleRefMapIndex (-1) ✅
→ ScenarioType.MM
→ Calidad MEDIA (requiere confirmación SHARK)
```

#### Caso 4: None
```
- cycleRefValid = false (primer ciclo no establecido)
→ ScenarioType.None
→ Calidad BAJA (señales evitadas)
```

✅ Definido: 4 casos de ejemplo con valores concretos

---

## RESUMEN PARTE 2

**✅ COMPLETADO:**
- **C) Reglas ETAPA 1:** Especificación completa LONG y SHORT con 9 subsecciones cada una
- **D) The_Wall Filter:** Reglas inviolables con 3 opciones de acceso (API MAPS, API VX, proxy)
- **E) PAT Scoring:** 4 capas definidas, scoring 0-4, tabla de decisiones con 16 casos
- **F) Escenarios PPM/MM:** Detección con 4 casos de ejemplo, fallback para MAP no disponible

**⚠️ INCERTIDUMBRES MANTENIDAS:**
- INCERTO #1: Acceso a FPLEME_M7_II (usar SHARK calculado como Plan B)
- INCERTO #2: Acceso a The_Wall (usar proxy como Plan B)
- INCERTO #3: Cálculo MAP exacto (validar con backtest)

**PRÓXIMO:** PARTE 3 - Integración con Indicador Actual, Bloqueadores, Casos de Prueba

---

*Continúa en archivo ESPEC_TECNICA_PARTE3_INTEGRACION_Y_TESTS.md*
