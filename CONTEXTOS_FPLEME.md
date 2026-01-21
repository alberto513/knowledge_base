# 🧠 SISTEMA DE CONTEXTOS - MFSScalpIndicator v3

## 📋 FILOSOFÍA: PENSAR COMO FPLEME

FPLEME no opera con señales aisladas. **Lee el mercado en capas** y solo entra cuando TODO está alineado.

```
FPLEME = FLUJO → CICLO → CONTEXTO → SEÑAL
```

El nuevo `MFSScalpIndicator v3` implementa esta filosofía mediante **3 CONTEXTOS**:

---

## 🎯 LOS 3 CONTEXTOS

### 1️⃣ **ESTADO DEL MERCADO** (`MarketState`)
**Lee:** Últimas 30 barras  
**Pregunta:** *¿En qué FASE del ciclo está el precio?*

#### Estados posibles:

| Estado | Descripción | Cuándo operar |
|--------|-------------|---------------|
| **Consolidating** 🟡 | Precio lateral, cerca de SMA20 | ⚠️ Esperar ruptura |
| **Breaking** ⚡ | Rompiendo estructura, ATR acelerando | ✅ **MEJOR MOMENTO** |
| **Trending** 📈 | Movimiento direccional establecido | ✅ Operar pullbacks |
| **Exhausted** 🔴 | Sobreextendido (>6 MAPs), ATR desacelerando | ❌ **NO OPERAR** |

#### Lógica de detección:

```csharp
// CONSOLIDANDO: >60% de barras dentro de ±1 MAP
if (consolidationRatio > 0.6)
    → MarketState.Consolidating

// ROMPIENDO: ATR acelerando + precio 1-3 MAPs del SMA
else if (atrAcceleration > 1.15 && mapDistance 1-3)
    → MarketState.Breaking  // ⭐ INICIO DE CICLO

// TENDENCIA: Precio 3-6 MAPs del SMA
else if (mapDistance 3-6)
    → MarketState.Trending

// AGOTADO: Precio >6 MAPs O ATR desacelerando <85%
else if (mapDistance > 6 || atrAcceleration < 0.85)
    → MarketState.Exhausted  // 🚫 FIN DE CICLO
```

**⚠️ CRÍTICO:** El estado `Exhausted` **BLOQUEA TODAS LAS ENTRADAS**. Esto soluciona el problema de las entradas tardías que viste en las capturas.

---

### 2️⃣ **CALIDAD DEL SETUP** (`SetupQuality`)
**Lee:** Últimas 20 barras  
**Pregunta:** *¿El timing es correcto o llegamos tarde/temprano?*

#### Estados posibles:

| Setup | Descripción | Acción |
|-------|-------------|--------|
| **Poor** | Sin estructura clara | ❌ No operar |
| **Forming** | Consolidación activa, precio cerca de SMA | ⚠️ Esperar confirmación |
| **Ready** ✅ | Consolidó → Rompió → Hay momentum | ✅ **ENTRAR** |
| **Missed** | Precio ya se alejó >4 MAPs | ❌ Oportunidad perdida |

#### Lógica de detección:

```csharp
// PERDIDO: Precio muy lejos
if (mapDistance > 4 || MarketState == Exhausted)
    → SetupQuality.Missed

// LISTO: Consolidó + Rompió + Momentum
else if (Breaking && hadConsolidation && hasMomentum)
    → SetupQuality.Ready  // ⭐ MOMENTO DE ENTRADA

// FORMÁNDOSE: Consolidación activa
else if (hadConsolidation && mapDistance <= 2)
    → SetupQuality.Forming

// POBRE: Sin estructura
else
    → SetupQuality.Poor
```

**⚠️ CRÍTICO:** Solo se permite entrada cuando `SetupQuality == Ready`. Esto asegura que NO entremos en medio de consolidación ni después de que el precio se fue.

---

### 3️⃣ **FLUJO DOMINANTE** (`DominantFlow`)
**Lee:** Últimas 50 barras  
**Pregunta:** *¿Cuál es la dirección MACRO del mercado?*

#### Estados posibles:

| Flujo | Descripción | Dirección permitida |
|-------|-------------|---------------------|
| **Bullish** ↑ | Estructura alcista (higher lows, MAPs subiendo) | Solo LONG |
| **Bearish** ↓ | Estructura bajista (lower highs, MAPs bajando) | Solo SHORT |
| **Neutral** ↔️ | Sin dirección clara | Ambas direcciones |

#### Lógica de detección:

```csharp
// Analizar últimas 50 barras:
// - Progresión de MAPs (¿subiendo o bajando?)
// - Swings alcistas vs bajistas (higher lows vs lower highs)
// - Pesan más los swings que los MAPs individuales

if (bullScore > bearScore * 1.3)  // 30% más alcista
    → DominantFlow.Bullish
else if (bearScore > bullScore * 1.3)
    → DominantFlow.Bearish
else
    → DominantFlow.Neutral
```

**⚠️ CRÍTICO:** **NO se permite operar contra el flujo dominante**. Si el mercado es alcista en las últimas 50 barras, NO se aceptan SHORTs (y viceversa).

---

## 🔒 FILTROS DE ENTRADA (7 CAPAS)

El nuevo sistema aplica **7 FILTROS** antes de permitir una entrada:

### ✅ Filtro 1: Estado del Mercado
```csharp
if (MarketState == Exhausted) → RECHAZAR
if (MarketState == Consolidating && SetupQuality != Ready) → RECHAZAR
```

### ✅ Filtro 2: Calidad del Setup
```csharp
if (SetupQuality == Poor || SetupQuality == Missed) → RECHAZAR
```

### ✅ Filtro 3: No estar en trade
```csharp
if (inTrade) → RECHAZAR
```

### ✅ Filtro 4: Ciclos válidos
```csharp
if (!cycleRefValid || !cycle2Valid) → RECHAZAR
```

### ✅ Filtro 5: Escenario válido
```csharp
if (!isPPM && !isMM) → RECHAZAR
```

### ✅ Filtro 6: SHARK alineado
```csharp
if (LONG && sharkState <= 0) → RECHAZAR
if (SHORT && sharkState >= 0) → RECHAZAR
```

### ✅ Filtro 7: Flujo dominante alineado
```csharp
if (LONG && DominantFlow == Bearish) → RECHAZAR
if (SHORT && DominantFlow == Bullish) → RECHAZAR
```

**Solo si pasa los 7 filtros, se arma la señal.**

---

## 📊 VENTANAS DE ANÁLISIS

```
[Barra actual]
    ↑
    | ← 3 barras: Señal inmediata (swing confirmado)
    | ← 15 barras: Momentum reciente
    | ← 30 barras: Estructura de corto plazo → MarketState
    | ← 50 barras: Dirección dominante → DominantFlow
```

---

## 🎯 ¿QUÉ PROBLEMA SOLUCIONA CADA CONTEXTO?

### Problema 1: **Entradas TARDÍAS** (al final del movimiento)
**Solución:** `MarketState.Exhausted` + `SetupQuality.Missed`
- Si precio ya se alejó >6 MAPs → BLOQUEAR
- Si ATR está desacelerando → BLOQUEAR
- **Resultado:** NO entrar cuando el ciclo ya terminó ✅

### Problema 2: **Entradas contra FLUJO dominante**
**Solución:** `DominantFlow`
- Si mercado es alcista en últimas 50 barras → NO permitir SHORTs
- **Resultado:** Solo operar a favor de la dirección macro ✅

### Problema 3: **Entradas en CONSOLIDACIÓN** (sin dirección)
**Solución:** `MarketState.Consolidating` + `SetupQuality.Forming`
- Si precio lateral y no hay ruptura clara → ESPERAR
- Solo entrar si `SetupQuality == Ready` (ya rompió)
- **Resultado:** NO operar en lateralizaciones ✅

### Problema 4: **Múltiples señales en mismo movimiento**
**Solución:** `SetupQuality.Missed` después de primera entrada
- Después de entrar, si precio se alejó >4 MAPs → Setup = Missed
- **Resultado:** Una sola entrada por ciclo ✅

---

## 📈 EXPECTATIVAS DE RESULTADOS

### ANTES (v2 - sin contextos):
- 5000 trades en 150 días
- 49% winrate
- Problema: Entradas tardías, contra flujo, en consolidación

### DESPUÉS (v3 - con contextos):
- **~800-1500 trades en 150 días** (más selectivo)
- **55-65% winrate esperado** (mejor calidad)
- **Menos trades, mejor timing**

### Trade-off:
- ❌ Menos oportunidades (más filtros)
- ✅ Mejor winrate (mejor timing)
- ✅ Menos trades perdedores (evita finales de ciclo)
- ✅ Captura INICIOS de ciclo (como en las capturas que mostraste)

---

## 🔧 PARÁMETROS AJUSTABLES

### Ventanas de contexto:
```csharp
CONTEXT_BARS_SHORT = 15   // Momentum reciente
CONTEXT_BARS_MEDIUM = 30  // Estado del mercado
CONTEXT_BARS_LONG = 50    // Flujo dominante
```

### Umbrales de estado:
```csharp
consolidationRatio > 0.6      // Cuándo considerar consolidación
atrAcceleration > 1.15        // Cuándo detectar ruptura
mapDistance > 6               // Cuándo considerar agotamiento
```

### Umbrales de setup:
```csharp
hadConsolidation: 4 de 7 barras  // Mínimo de consolidación previa
consecutiveBars >= 2             // Mínimo momentum
mapDistance > 4                  // Setup perdido
```

---

## 🧪 CÓMO VALIDAR

### Test 1: **Entradas en BREAKING (no en EXHAUSTED)**
```
Cargar gráfico → Observar panel "Estado"
✅ Entradas deberían ocurrir cuando Estado = "ROMPIENDO ⚡"
❌ NO debe entrar cuando Estado = "AGOTADO 🔴"
```

### Test 2: **Setup READY en las entradas**
```
Al momento de entrada:
✅ Setup debe mostrar "LISTO ✓"
❌ NO debe mostrar "PERDIDO" o "POBRE"
```

### Test 3: **Flujo ALINEADO**
```
LONG debe ocurrir cuando Flujo = "ALCISTA ↑"
SHORT debe ocurrir cuando Flujo = "BAJISTA ↓"
```

### Test 4: **Comparar con capturas**
```
Las 3 capturas que mostraste:
- Ciclos claros con ruptura
- Precio rompe SMA y sigue direccional
→ v3 debería capturar ESTOS momentos
→ v3 debería IGNORAR los finales de movimiento
```

---

## 📝 LOGGING

El log incluye ahora:
```csv
Timestamp, Instrument, Type, Direction, Price, Scenario, MapIdx, CycleDir, PnL, Bars
```

Para analizar si los contextos funcionan:
1. Borrar log anterior
2. Cargar 150 días
3. Analizar:
   - ¿Winrate mejoró?
   - ¿Menos trades pero mejor calidad?
   - ¿PnL promedio por trade subió?

---

## 🎓 RESUMEN: PENSAR COMO FPLEME

```
❌ ANTES: "¿Hubo swing?" → ENTRA
✅ AHORA: 
   1. ¿Mercado rompiendo o agotado? (MarketState)
   2. ¿Setup listo o perdido? (SetupQuality)
   3. ¿Flujo alineado o contra? (DominantFlow)
   4. ¿SHARK confirmado?
   5. ¿Ciclos válidos?
   6. ¿Escenario correcto?
   7. ¿Swing confirmado?
   → SI TODO ALINEADO → ENTRA
```

**Esto es pensar como FPLEME: múltiples capas de confirmación antes de actuar.** 🧠

---

## 🚀 PRÓXIMOS PASOS

1. **Compilar** el indicador en NinjaTrader
2. **Cargar** en gráfico RenkoBRZ
3. **Observar** el panel de contextos en tiempo real
4. **Backtest** 150 días y comparar con v2
5. **Analizar** log para validar mejora de winrate
6. **Forward test** en demo para confirmar robustez

**Clave:** El indicador ahora piensa en **50 barras hacia atrás** antes de decidir, no solo en la barra actual. 📊
