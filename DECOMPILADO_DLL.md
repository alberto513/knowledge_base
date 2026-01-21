# Decompilado DLL (resumen pragmatica)

Ruta de decompilado: `docs/confluencia/decompile/src/`
Nota: los metodos estan ofuscados (AgileDotNet). No se puede ver logica ni defaults internos. Solo nombres, parametros, series y constantes visibles.

## FPLEME_M7_II (FPLEME_M7)
Parametros (bool):
- PAINT_BARS: aplicar reglas de color a velas.
- FAST_MODE: modo rapido (scalpers).
- TRACK_RECORD: registro historico de Etapa 1.
- SHOW_ETAPA_1: mostrar Etapa 1.
- SHOW_ETAPA_2: mostrar Etapa 2.
- SHOW_STOP: mostrar mejor posicion de stop.
- SHOW_FREQ_1 / SHOW_FREQ_2 / SHOW_FREQ_3: mostrar 1/2/3 frecuencias.
- BREAKOUTS: calcular rompimientos de SHARK.
- GRAPH_BREAKOUTS: mostrar rompimientos en el grafico.

Series (Values):
- Values[0] FPLEME_LINE
- Values[1] SHARK_LINE
- Values[2] POST_ITS
- Values[3] FPLEME_ALERT
- Values[4] ETAPA_1C
- Values[5] ETAPA_1V

Constantes visibles:
- FPLEME_CLOSE_OFFSET=6, FPLEME_EMA_PERIOD=2
- FPLEME_NORMALIZATION_PERIOD=500, FPLEME_NORMALIZATION_MULTIPLIER=12
- FPLEME_MINIMUM_BARS=300
- SHARK_CLOSE_OFFSET=5, SHARK_OPEN_OFFSET=2
- SHARK_EMA_PERIOD_1=5, SHARK_EMA_PERIOD_2=2
- SHARK_MULTIPLIER=1.877
- SHARK_PIVOT_PERIOD=5, SHARK_MAX_MIN_PERIOD=3
- THEWALL_DEFAULT_K=0.0475
- THEWALL_DEFAULT_HHV_PERIOD=2, THEWALL_DEFAULT_LLV_PERIOD=85
- THEWALL_DEFAULT_MIN_BARS=135
- THEWALL_RENKO_MULTIPLIER=11
- PLOT_LINE_WIDTH: normal=3, thick=4, alert=5, heavy=7
- SIGNAL thresholds: +4/-4, extremos +8/-8, max=12, min=-12
- SHARK_EXTREME_THRESHOLD=7
- MINIMUM_BARS: processing=10, EMA init=5, SHARK EMA=15
- DIVISION_BY_ZERO_THRESHOLD=1e-07

Enums:
- TheWallMarketState: COMPRADOR, VENDEDOR, NEUTRO
- SharkMarketState: BULLISH, BEARISH, NEUTRO

## MAPS_M7
Parametros (bool):
- CENTRAIS, INTERMEDIARIOS, CLEAN_MODE
- THE_WALL, FORCE_LINES, PULLBACKS

Series (Values):
- M0, S1..S10, I1..I10
- TW
- RANGE_S, RANGE_I
- RANGE_U2/D2, RANGE_U3/D3, RANGE_U4/D4, RANGE_U5/D5, RANGE_U6/D6
- PROBLINE_S4..S10
- PROBLINE_I4..I10

## VX_M7 (VXM7)
Parametros (bool):
- THE_WALL, FORCE_LINES, PULLBACKS

Series (Values):
- M0, S1..S10, I1..I10
- TW, TWD
- FORCELINE_S
- PULLBACK_B, PULLBACK_S
- PROBLINES_S, PROBLINES_I
- S1HL..S10HL, I1HL..I10HL
- S1_GUIDE, I1_GUIDE

## HERTZ_N_DEFAULT (HERTZ)
Parametros: sin parametros visibles.
Series (Values): HZ1, HZ2, HZ3, HZ4

## STOP_ABS_DEFAULT (StopAbsV)
Parametros (bool):
- SHOW_ABS: mostrar ABS
- SHOW_STOPS: mostrar grandes agresiones
- CHECK: identificar zonas probables de inversion

Series (Values):
- STOP_LINE
- ABS_LINE

## RENKOBRZ (RenkoBRZ)
- BarsType RenkoBRZ.
- Metodos de logica no visibles por ofuscacion.

## Limitaciones reales
- Los metodos OnStateChange/OnBarUpdate estan vacios en el decompilado.
- No se ven defaults internos ni colores exactos.
- Para defaults exactos: abrir en NinjaTrader y leer configuracion, o deobfuscacion avanzada (no recomendada).
