# Herramientas ZIP (inspeccion rapida)

Ruta: `fpleme herramientas/`

## Versiones (Info.xml)
- FPLEME_M7_II.zip: NinjaTrader 8.1.4.2, Agile 6.9.1.7
- HERTZ_N_DEFAULT.zip: NinjaTrader 8.1.1.0
- MAPS_M7.zip: NinjaTrader 8.1.4.2, Agile 6.9.1.7
- RENKOBRZ.zip: NinjaTrader 8.1.4.2, Agile 6.9.1.7
- STOP_ABS_DEFAULT.zip: NinjaTrader 8.1.1.0
- VX_M7.zip: NinjaTrader 8.1.4.2, Agile 6.9.1.7

## Parametros visibles en wrappers (.cs)
### FPLEME_M7_II -> clase FPLEME_M7
- PAINT_BARS, FAST_MODE, TRACK_RECORD
- SHOW_ETAPA_1, SHOW_ETAPA_2, SHOW_STOP
- SHOW_FREQ_1, SHOW_FREQ_2, SHOW_FREQ_3
- BREAKOUTS, GRAPH_BREAKOUTS

### MAPS_M7 -> clase MAPS_M7
- CENTRAIS, INTERMEDIARIOS, CLEAN_MODE
- THE_WALL, FORCE_LINES, PULLBACKS

### VX_M7 -> clase VXM7
- THE_WALL, FORCE_LINES, PULLBACKS

### STOP_ABS_DEFAULT -> clase StopAbsV
- SHOW_ABS, SHOW_STOPS, CHECK

### HERTZ_N_DEFAULT -> clase HERTZ
- Sin parametros visibles en wrapper.

### RENKOBRZ
- Wrapper sin metodos publicos; sin parametros visibles en .cs.

## Limitaciones
- Los .cs solo contienen wrappers generados por NinjaTrader.
- La logica y defaults estan dentro de los .dll, no visibles sin decompilar o abrir en NinjaTrader.
- Si queres detalles internos (calculo, colores exactos, reglas), hay que decompilar los .dll o exportar propiedades desde la plataforma.

## Decompilado
- Resumen tecnico: docs/confluencia/DECOMPILADO_DLL.md
- Nota: los metodos estan ofuscados (AgileDotNet); no se ven defaults ni logica interna.
