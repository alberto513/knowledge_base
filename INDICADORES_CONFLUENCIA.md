# Indicadores y visual (confluencia)

Nota: resumen desde OCR y wrappers .cs. Usar como base para el indicador.

## FPLEME SC2
- Linea FPLEME (fina): altura = fuerza; niveles 0, +/-4 (cambio de color), +/-8, +/-12.
- Linea SHARK (gruesa): confirma ciclo; misma logica de fuerza.
- Linea FPLEME mas espesa = fuerza direccional alta.
- Post-its en +/-4: verde/rojo; destacado vs opaco.
- Post-its amarillos en SHARK: equilibrio y posible cambio de ciclo.
- En NinjaTrader, ciclo comprador suele ser azul y vendedor magenta.
- Parametros visibles en wrapper: PAINT_BARS, FAST_MODE, TRACK_RECORD, SHOW_ETAPA_1, SHOW_ETAPA_2, SHOW_STOP, SHOW_FREQ_1, SHOW_FREQ_2, SHOW_FREQ_3, BREAKOUTS, GRAPH_BREAKOUTS.

Visual ideas:
- Niveles 0 y +/-4 como lineas guia; +/-8 y +/-12 mas suaves.
- Grosor variable en FPLEME para resaltar fuerza.
- Marcadores tipo post-it con color y opacidad (destacado vs opaco).
- Icono o tag para Etapa 1 y Etapa 2 cuando se cumplen.

## MAPS
- MAP-0 linea central punteada (azul/naranja).
- s1..s5 arriba, i1..i5 abajo.
- Range lines mas gruesas (amplitud/atencion); no son setup.
- Problines en pares cuando sube la volatilidad (S4/S5, S5/S6, S6/S7, etc) y tambien en el lado inferior; pueden aparecer antes de que Hertz cambie.
- Pullback lines: compradores verde, vendedores rojo; indican interes. Para principiantes, pueden ocultarse.
- The Wall: linea de seguridad y direccion (verde compra, rosa venta, amarilla lateral).
- Parametros visibles en wrapper: CENTRAIS, INTERMEDIARIOS, CLEAN_MODE, THE_WALL, FORCE_LINES, PULLBACKS.

Visual ideas:
- The Wall con color dominante y etiqueta.
- Range y Problines con estilo distinto (solido vs punteado).
- Marca de cruce de The Wall para alertar consolidacion.

## VX M2
- Barras verticales: crecen/decrecen y muestran direccion de agresion.
- Map0 como centro; barras arriba = compra, abajo = venta.
- Lineas horizontales se vuelven mas gruesas cuando hay ruptura de MAP.
- Si la horizontal no engrosa, el rompimiento no ocurrio.
- The Wall del VX: color por inclinacion vs MAP.
- Post-its amarillos en The Wall (VX) para cambio de direccion.
- MEA/EE como limites de venta/compra (si estan visibles).
- The Wall del VX ayuda a ver cuando la The Wall del grafico cruza una MAP.
- VX permite ver divergencias/convergencias de MAP y saldo para romper.
- Parametros visibles en wrapper: THE_WALL, FORCE_LINES, PULLBACKS.

Visual ideas:
- Resaltar ruptura con cambio de grosor o brillo.
- Flechas pequenas en post-its amarillos para anticipar giro.

## STOP ABS
- Clase visible: StopAbsV.
- Parametros visibles en wrapper: SHOW_ABS, SHOW_STOPS, CHECK.
- Logica interna esta en .dll.

## RENKOBRZ
- Wrapper sin metodos publicos; sin parametros visibles en .cs.
- Probable BarsType; ajustar en plataforma si hace falta.

## PPM/MM
- PPM: segundo ciclo en MAP mas alta (compra) o mas baja (venta).
- MM: segundo ciclo en la misma MAP; escenario mas debil.

Visual ideas:
- Etiqueta de escenario (PPM/MM) y color por direccion.
- Marcadores en ciclo de referencia y segundo ciclo.

## Hertz
- Tres frecuencias: Macro, Conforto, Sniper (numeros para Renko).
- Numeros altos = mayor volatilidad y Renko mas grande.
- 5m para day trade, 60m para swing (calculo).
- Hertz convierte grafico temporal a atemporal, muestra velocidad del activo y ayuda a reducir lateralizacion (zipers).
- Wrapper sin parametros; clase HERTZ.

Visual ideas:
- Panel pequeno con los 3 numeros y color de riesgo (verde/amarillo/rojo).

## Generador de senales independiente
- Indicador: FlowCycleSignalsV1.
- Ubicacion: src/Indicators/FlowCycleSignalsV1.cs
- Calcula flujo/ciclo propio y emite senales de Etapa 1/2 con SHARK alineado.
