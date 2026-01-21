# Resumen filosofico y tecnico del ecosistema FPLEME (NinjaTrader)

## Alcance y fuentes consultadas
- C:/Users/PC/Documents/CARPETA DE CURSOR/docs/DOCUMENTACION_FPLEME_V2.md (especificacion tecnica completa)
- C:/Users/PC/Documents/CARPETA DE CURSOR/docs/DOCUMENTACION_FPLEME.md (analisis SC2 + MAPS + VX + PAT)
- C:/Users/PC/Documents/CARPETA DE CURSOR/docs/MAPA_DEL_INDICADOR.md
- C:/Users/PC/Documents/CARPETA DE CURSOR/docs/OPERATIVA_FPLEME_EXTRA.md
- C:/Users/PC/Documents/CARPETA DE CURSOR/docs/REGLAS_WINRATE_FPLEME.md
- C:/Users/PC/Documents/CARPETA DE CURSOR/docs/FUENTES_PDF.md
- C:/Users/PC/Documents/CARPETA DE CURSOR/docs/confluencia/*.md (confluencia y generador V1)
- C:/Users/PC/Documents/CARPETA DE CURSOR/docs/capturas/RESUMEN_CAPTURAS.md (resumen OCR)
- C:/Users/PC/Documents/CARPETA DE CURSOR/docs/pdf_notes/*.md (notas por PDF)
- C:/Users/PC/Documents/CARPETA DE CURSOR/docs/pdf-text/*.txt (texto crudo de PDFs)

## Filosofia base (resumen)
- El mercado es flujo que se transforma en ciclos. Leer el color del box no basta; hay que leer la fase del ciclo.
- El mapa (MAPS) es la ruta. FPLEME/SHARK y VX son las herramientas cuantitativas para ejecutar la ruta.
- El contexto manda: PPM/MM + The_Wall primero, senal despues. Post-it aislado no es entrada.
- Confluencia obligatoria: Hertz (volatilidad) + MAPS/The_Wall (contexto) + FPLEME/SHARK (ciclo) + VX (agresion/ruptura).
- Nada de promedios externos. Solo flujo, ciclos y escenarios.

## Arquitectura del sistema
- FPLEME Engine (flujo/ciclo)
- SHARK Engine (confirmacion)
- ETAPA 1 Detector (inicio de ciclo)
- ETAPA 2 Detector (continuacion)
- Order Placement (timing)
- Risk Management (stops)
- Quality Filters (PPM/MM, The_Wall)
- Visual Signals (post-its, marcadores)

## FPLEME: niveles y estados
- Rango: -12 a +12.
- Niveles criticos: +12/+8/+6/+4/+3/0/-3/-4/-6/-8/-12.
- Cambio de color:
  - Verde -> rojo cuando cruza +4 y llega a 0.
  - Rojo -> verde cuando cruza -4 y llega a 0.
- NinjaTrader: ciclo comprador se pinta azul, ciclo vendedor magenta/rosa.
- Linea mas gruesa = mayor fuerza direccional.
- No iniciar ciclo desde extremos (+/-8, +/-12).

## SHARK: confirmacion de ciclo
- Linea mas gruesa, confirma direccion del ciclo.
- Post-it amarillo = equilibrio y posible cambio, pero confirma la linea.
- En activos volatiles la linea manda mas que el post-it.

## Post-its (atajos visuales)
- Post-its en +/-4 (FPLEME): indican cambio de color y toque a 0 (ETAPA 1).
- Post-it destacado = SHARK alineado (movimiento mas fluido).
- Post-it opaco = SHARK contrario (lateralizacion probable).
- Post-it amarillo en SHARK = equilibrio, no set-up por si solo.

## ETAPA 1 (inicio de ciclo)
- Compra: FPLEME sale de -4 y alcanza 0.
- Venta: FPLEME sale de +4 y alcanza 0.
- Debe ocurrir en 2do o 3er box del movimiento.
- No existe ETAPA 1 si el FPLEME viene de -8/-12 o +8/+12 (no llega a 0 en 1 box).
- Mejor momento: FPLEME + SHARK alineados.

### Timing ETAPA 1
- Nunca comprar en el tope del box positivo.
- Nunca vender en el fondo del box negativo.
- Entrada long: base del box positivo anterior.
- Entrada short: tope del box negativo anterior.
- Nunca entrar en el cierre del box de confirmacion.

### Stops ETAPA 1
- Long: stop debajo del ultimo fondo del ciclo; max 1 box negativo debajo.
- Short: stop encima del ultimo tope del ciclo; max 1 box positivo arriba.
- Regla: el motivo de entrada debe ser el mismo motivo de salida.

## ETAPA 2 (continuacion, reactiva)
- Compra: FPLEME va de +4 a +8 en un solo box.
- Venta: FPLEME va de -4 a -8 en un solo box.
- No es ETAPA 2 si va 0->+4 / 0->-4 (eso es ETAPA 1).
- No es ETAPA 2 si va +8->+12 o -8->-12 (extremos).
- SHARK alineado obligatorio.

### Timing ETAPA 2
- Classic: base/topo del box anterior al de confirmacion.
- 2.2: base/topo del mismo box de confirmacion (solo alta volatilidad).
- Nunca comprar en tope ni vender en fondo.
- Nunca entrar en el cierre del box.

### Stops ETAPA 2
- Long: base de dos boxes positivos anteriores (desde el punto de entrada).
- Short: tope de dos boxes negativos anteriores.
- Variante opcional: 2 boxes + 1 tick.
- Regla opcional: segundo box contrario solo cierra si supera minimo/ maximo + 1 tick.

## Escenarios (PPM y MM)
### PPM (Progresso de Preco em MAP)
- Escenario fuerte: progresion de ciclos en MAPs.
- Checklist venta:
  1) Referencia: topo + SHARK rojo (inicio ciclo vendedor).
  2) Fondo + SHARK azul (inicio ciclo comprador).
  3) Entrar en segundo ciclo vendedor.
  4) Segundo ciclo mas bajo.
  5) Segundo ciclo en MAP mas baja (VX debe caer).
  6) The_Wall lateral o a favor (amarilla o rosa).
- Checklist compra (simetrico): segundo ciclo mas alto y MAP mas alta; The_Wall amarilla o verde.
- PPM explica patrones clasicos; el patron no causa la reversa, la progresion en MAPs si.

### MM (MAP con MAP)
- Escenario mas debil; usar cuando PPM no aplica.
- Segundo ciclo en la misma MAP del ciclo de referencia.
- Checklist venta/compra similar a PPM, pero MAP igual.
- Mejor cuando la inclinacion de ciclos es evidente; evitar ciclos en niveles iguales.
- Evitar MM en extremos; para reversas preferir PPM.

### Fases de mercado (PPM)
- Acumulacion -> inicio de alza -> alza fuerte.
- Distribucion -> inicio de baja -> baja fuerte.
- Complementarias: reacumulacion / redistribucion.
- MAPs y The_Wall definen zona y transicion:
  - Acumulacion suele en i3-i5, The_Wall rosa que pasa a amarilla.
  - Distribucion suele en s3-s5, The_Wall verde que pasa a amarilla.
  - Inicio de alta/baja: progresion de fondos/topes en MAPs.

## MAPS
- MAP0 central (linea punteada). S1..S4 arriba, I1..I4 abajo.
- S5..S8 e I5..I8 solo en alta volatilidad.
- Range lines: lineas mas gruesas de amplitud; puntos de atencion, no set-up.
- Problines: pares que anticipan extension si la volatilidad sube (S4/S5, S5/S6, etc).
- Pullback lines: compradores verde, vendedores rojo; solo atajo visual.
- Filosofia: el mapa responde donde estamos y los caminos posibles; no usar MAPS aislado.

## The_Wall
- Verde: fuerza compradora; nunca vender.
- Rosa/magenta: fuerza vendedora; nunca comprar.
- Amarilla central: lateral; esperar confirmacion con FPLEME.
- Amarilla en extremos: posible inicio de reversa, no entrada inmediata.
- Si el precio cruza The_Wall, hay consolidacion o fin de tendencia.

## VX
- Barras crecientes arriba de MAP0 = agresion compradora.
- Barras decrecientes abajo de MAP0 = agresion vendedora.
- Ruptura de MAP: linea horizontal se engrosa cuando barras verticales la rompen.
- Si no engrosa, no hay fuerza suficiente.
- The_Wall del VX: verde si inclinada arriba vs MAP, rosa si inclinada abajo.
- Post-its amarillos en The_Wall VX indican cambio de direccion.
- VX muestra divergencia/convergencia de MAP; no usar aislado.

## Hertz
- Convierte grafico temporal en atemporal (Renko recomendado).
- Frecuencia Conforto = Renko recomendado para operar.
- Sniper = micro; Macro = macro (mapas y extremos).
- Day trade: usar grafico 5m para calcular Hertz.
- Swing trade: usar grafico 60m.
- Hertz alto = alta volatilidad. Si Conforto > 30R en 5m (futuros), evitar activo.
- No enga?ar: bajar timeframe reduce Renko pero no la volatilidad real.

## Confluencia operativa (pipeline)
1) Hertz -> define Renko (Conforto o Sniper).
2) MAPS -> define escenario y fase (PPM/MM).
3) The_Wall -> filtro de seguridad (color y cruce).
4) FPLEME/SHARK -> define ciclo y timing (ETAPA 1/2).
5) VX -> confirma ruptura y balance de agresion.
6) Entrada solo con confluencia; senal aislada se descarta.

## Implementacion y constantes visibles (decompilado)
- FPLEME: close offset 6, EMA period 2, normalizacion 500, escala 12, min bars 300.
- SHARK: close offset 5, open offset 2, EMA 5 y 2, multiplicador 1.877.
- SHARK extreme threshold 7; min bars para EMAs.
- The_Wall: K 0.0475, HHV 2, LLV 85, min bars 135, renko multiplier 11.
- Valores series: FPLEME line, SHARK line, post-its, alertas, etapa1C/V.
- MAPS/VX: series de MAP0, S/I levels, ranges, problines, pullbacks.
- RenkoBRZ: BarsType obligatorio en herramientas originales.

## Generador independiente V1 (FlowCycleSignalsV1)
- Calcula linea de flujo propia y linea tipo SHARK.
- Normaliza a [-12, 12], thresholds +/-4 y +/-8.
- Filtros: alineacion de shark, pendiente, cooldown.
- Emite E1/E2 y gestiona TP/SL fijo con estadisticas.
- RenkoBRZ obligatorio.

## Principios para un indicador propio (no copia)
- No clonar FPLEME: usar su filosofia (flujo->ciclo->contexto) pero con logica propia.
- Pasar de reglas binarias a un score de confluencia continuo.
- Hacer niveles dinamicos (ajuste por Hertz/volatilidad) en vez de umbrales fijos.
- Unificar ciclo rapido + ciclo lento (multi-escala) para reducir falsos.
- Separar 3 capas: Contexto (MAPS/The_Wall), Ciclo (Flow/Shark), Confirmacion (VX/estructura).
- Visualizar el estado, no solo la senal: mostrar fase, fuerza y calidad.

## Plan para un nuevo indicador (propuesta)
### 1) Vision
Un unico indicador que sintetiza flujo, ciclo y contexto en un solo estado de mercado, con:
- Linea de flujo (energia direccional).
- Linea de ciclo (confirmacion).
- Panel de escenario (PPM/MM + fase).
- Score de confluencia (0-100).
- Senales graduadas (E1/E2 con calidad).

### 2) Inputs y normalizacion
- RenkoBRZ como base.
- Hertz como ajuste dinamico de escala (niveles adaptativos).
- Normalizacion por ventana dinamica (percentiles o z-score).

### 3) Motor de flujo y ciclo
- Flow = precio/box con suavizado (EMA o filtro propio) y normalizacion adaptativa.
- Cycle = confirmacion con retardo corto + alineacion con flujo.
- Estados: Bull/Bear/Neutral + fuerza.

### 4) Motor de escenarios
- Detectar PPM/MM con reglas de ciclos + MAP level.
- Identificar fase (acumulacion, inicio, fuerte, distribucion, etc).
- Calcular ScenarioStrength (0-1).

### 5) Confluencia y scoring
- Score = w1*FlowAlign + w2*SharkAlign + w3*WallAlign + w4*Scenario + w5*VXBreak - w6*VolRisk.
- Umbrales: High/Med/Low para filtrar entradas.

### 6) Senales y timing
- E1/E2 propios basados en score y transicion de estados.
- Timing siempre fuera del cierre del box.
- Entradas a base/topo de box anterior, salvo modo volatilidad.

### 7) Riesgo y invalidacion
- Stops dinamicos: mezcla de swing + cajas + volatilidad.
- Invalida cuando el estado del ciclo rompe el motivo de entrada.

### 8) Visualizacion
- Modo minimal: solo flujo/ciclo + score.
- Modo full: MAPS/The_Wall/VX integrados.
- Marcas de calidad (color y opacidad) en lugar de solo flechas.

### 9) Pruebas
- Verificar look-ahead (OnBarClose).
- Tests por escenario (PPM/MM) y por fase.
- Tests de extremos (no iniciar ciclos en +/-8, +/-12).
- Validar que el score baja con desalineacion.

## Siguiente paso sugerido
Si queres, traduzco este plan a un diseno tecnico con:
- estados y estructuras de datos,
- pseudocodigo de cada modulo,
- y una primera version del indicador nuevo.
