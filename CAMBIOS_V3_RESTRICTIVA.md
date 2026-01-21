# MFSSCALP V3 - VERSION RESTRICTIVA

## PROBLEMA DETECTADO

**v3 original:**
- 8626 trades en 145 dias (59.5 trades/dia)
- Winrate: 51.53% (+2.5% vs v2)
- **CONCLUSION:** Filtros demasiado permisivos, generó MÁS trades que v2

**v2:**
- 5000 trades en 150 dias (33 trades/dia)
- Winrate: 49%

## CAMBIOS APLICADOS (VERSION RESTRICTIVA)

### 1. MarketState - MÁS ESTRICTO

**ANTES:**
- Consolidating: >60% barras cerca de SMA
- Breaking: ATR aceleración >1.15, MAP 1-3
- Trending: MAP 3-6
- Exhausted: MAP >6 o ATR <0.85

**AHORA:**
- Consolidating: >50% barras cerca de SMA (más fácil detectar consolidación)
- Breaking: ATR aceleración >1.25 (25% vs 15%), MAP 1-2 (vs 1-3)
- Trending: MAP 2-4 (vs 3-6)
- Exhausted: MAP >4 (vs >6) o ATR <0.90 (vs <0.85)

**RESULTADO:** Menos estados Breaking, más Exhausted

---

### 2. SetupQuality - MÁS EXIGENTE

**ANTES:**
- Consolidación: 4 de 7 barras cerca de SMA
- Momentum: >=2 barras consecutivas
- TooFar: >4 MAPs

**AHORA:**
- Consolidación: 7 de 12 barras cerca de SMA (mucho más tiempo)
- Momentum: >=3 barras consecutivas (más fuerza)
- TooFar: >3 MAPs (más restrictivo)
- **NUEVO:** Cooldown de 5 barras tras salida (evita re-entradas rápidas)

**RESULTADO:** Menos setups Ready

---

### 3. DominantFlow - MÁS CLARO

**ANTES:**
- Bullish/Bearish si score >30% mayor

**AHORA:**
- Bullish/Bearish si score >50% mayor
- Swings pesan x5 (vs x3)

**RESULTADO:** Más estados Neutral, menos direccionales

---

### 4. DetectSignals - SOLO BREAKING

**ANTES:**
- Permitía entradas en Breaking, Trending y Consolidating (si Ready)

**AHORA:**
- **SOLO permite entradas en Breaking**
- Bloquea: Consolidating, Trending, Exhausted

**RESULTADO:** Captura SOLO inicios de ciclo, nada más

---

## EXPECTATIVA V3 RESTRICTIVA

**Trades esperados:**
- 800-1500 trades en 150 días (~8-10 trades/día)
- Reducción del 80-90% vs v3 original

**Winrate esperado:**
- 58-65% (mejor timing, solo inicios de ciclo)
- +9-16% vs v2

**Profit Factor:**
- >1.5 (vs 1.06 de v3 original)

---

## PRÓXIMOS PASOS

1. **Borrar log:**
   ```
   c:\Users\PC\Documents\NinjaTrader 8\logs\MFSScalp\MFSScalp_TradeLog.csv
   ```

2. **Compilar indicador** en NinjaTrader

3. **Cargar 150 días** de datos

4. **Ejecutar análisis:**
   ```powershell
   powershell -ExecutionPolicy Bypass -File "c:\Users\PC\Documents\CARPETA DE CURSOR\analyze_v3_results.ps1"
   ```

5. **Validar:**
   - ¿Trades < 2000? ✓
   - ¿Winrate > 55%? ✓
   - ¿Profit Factor > 1.3? ✓

---

## RESUMEN DE AJUSTES

| Parámetro | ANTES | AHORA | Efecto |
|-----------|-------|-------|--------|
| ATR aceleración Breaking | >1.15 | >1.25 | Más restrictivo |
| MAP Breaking | 1-3 | 1-2 | Más restrictivo |
| MAP Trending | 3-6 | 2-4 | Más restrictivo |
| MAP Exhausted | >6 | >4 | Más restrictivo |
| Consolidación requerida | 4/7 barras | 7/12 barras | Más restrictivo |
| Momentum requerido | 2 barras | 3 barras | Más restrictivo |
| TooFar | >4 MAPs | >3 MAPs | Más restrictivo |
| Cooldown | No | 5 barras | Nuevo |
| Flow threshold | 30% | 50% | Más restrictivo |
| Estados permitidos | Breaking/Trending/Consolidating | SOLO Breaking | Mucho más restrictivo |

**TODOS LOS FILTROS MÁS RESTRICTIVOS = MENOS TRADES, MEJOR CALIDAD**
