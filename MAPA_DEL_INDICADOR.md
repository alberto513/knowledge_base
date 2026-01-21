# MAPA DEL INDICADOR

## Objetivo
Convertir el flujo de mercado en ciclos visibles (FPLEME + SHARK) y dar timings de entrada (ETAPA 1 y ETAPA 2) con filtros de contexto (PAT, PPM/MM, The_Wall) y gestion de riesgo/plots listos para NinjaTrader.

## Definiciones rapidas
- FPLEME: linea principal (fina) de fuerza, rango -12 a +12. Cambia color al cruzar -4/+4 hacia 0. En NinjaTrader se pinta azul (compra) o magenta/rosa (venta).
- SHARK: linea gruesa de confirmacion de ciclo; azul/verde para compra, rojo/magenta para venta; amarilla = equilibrio.
- Post-its: marcadores en +-4 (FPLEME) y amarillos en SHARK; destacan cambio de color y toque de 0. Destacado = SHARK alineado, opaco = SHARK contrario.
- ETAPA 1: inicio de ciclo cuando FPLEME sale de -4/+4 y toca 0 en el 2o o 3er box del movimiento.
- ETAPA 2: entrada reactiva cuando FPLEME ya avanzo de +4 a +8 (compra) o de -4 a -8 (venta) en un solo box.
- PAT: filtro de Alineacion Perfecta (FPLEME + SHARK + ETAPA 1 + no extremos + The_Wall a favor).
- The_Wall (MAPS/VX): muro de color; verde permite compras y bloquea ventas, rosa/magenta permite ventas y bloquea compras, amarillo = lateral/posible giro.

## Reglas exactas ETAPA 1 (paso a paso)
**Deteccion compra**
1) FPLEME salio de -4: valor previo <= -4 y valor actual > -4.
2) Alcanzar 0: valor actual >= 0.
3) Secuencia de cajas Renko: confirmar en 2o o 3er box positivo consecutivo.
4) No viene de extremo: valor previo no debe estar en -12/-8 (no puede llegar a 0 en un box).
5) Colores alineados: FPLEME en ciclo comprador y SHARK azul.
6) Preferir dentro de escenario PPM compra o MM y con The_Wall no en rosa/magenta.

**Deteccion venta**
1) FPLEME salio de +4: valor previo >= +4 y valor actual < +4.
2) Alcanzar 0: valor actual <= 0.
3) Secuencia: confirmar en 2o o 3er box negativo consecutivo.
4) No viene de extremo: valor previo no debe estar en +12/+8 (no puede llegar a 0 en un box).
5) Colores alineados: FPLEME en ciclo vendedor y SHARK rojo/magenta.
6) Preferir dentro de escenario PPM venda o MM y con The_Wall no en verde.

**Timing ETAPA 1**
- No comprar en el topo del box positivo ni vender en la base del box negativo.
- Compra: colocar en la base del box positivo anterior al de confirmacion (si confirmo en el 3er box, base del 2o; si en el 2o, base del 1o).
- Venta: colocar en el topo del box negativo anterior al de confirmacion.

## Reglas exactas ETAPA 2 (paso a paso)
**Deteccion compra**
1) Valor previo de FPLEME entre +4.00 y +8.00 (salio de +4).
2) Valor actual alcanza >= +8.00.
3) Movimiento ocurre en un solo box (reactivo).
4) No es valido si viene de 0 a +4 (eso es ETAPA 1).
5) No es valido si viene de +8 a +12 (extremo).
6) Confirmacion en el mismo box que toca +8.00.
7) SHARK debe estar azul.

**Deteccion venta**
1) Valor previo de FPLEME entre -4.00 y -8.00 (salio de -4).
2) Valor actual alcanza <= -8.00.
3) Movimiento en un solo box.
4) No es valido si viene de 0 a -4 (eso es ETAPA 1).
5) No es valido si viene de -8 a -12 (extremo).
6) Confirmacion en el mismo box que toca -8.00.
7) SHARK debe estar rojo/magenta.

**Timing ETAPA 2**
- Modo Classic: entrada en la base del box anterior al que confirmo ETAPA 2 (compra: base del box positivo previo; venta: topo del box negativo previo).
- Modo 2.2: entrada en la base/topo del propio box que confirmo ETAPA 2 (compra: Low; venta: High).
- Misma regla de timing que ETAPA 1: nunca comprar en topo de box positivo ni vender en base de box negativo.
- PENDIENTE: confirmar timing por defecto (Classic o 2.2) y si es configurable por usuario.

## PAT y filtros de calidad
- PAT long: FPLEME en ciclo comprador (>= -4 y (>= +4 o Post-it -4 + valor >=0)), SHARK comprador (azul/verde), ETAPA 1 compra confirmada, no en extremos (<= +8), The_Wall no rosa/magenta y zona comprador. 
- PAT short: simetrico (FPLEME <= +4 y (<= -4 o Post-it +4 + valor <=0), SHARK rojo/magenta, ETAPA 1 venta confirmada, no en extremos >= -8, The_Wall no verde y zona vendedora).
- Escenarios: PPM/MM aumentan calidad; fuera de escenario bajar calidad (ej. SignalQuality Medium/Low en doc). 
- The_Wall como seguridad: nunca comprar si The_Wall rosa/magenta; nunca vender si verde.
- Movimiento fluido vs lateral: SHARK alineado = fluido; SHARK opuesto = lateral (post-it opaco).
- Activos muy volatiles: priorizar color de la linea sobre Post-its.

## Stops y descaracterizacion
- ETAPA 1 compra: Stop minimo debajo del ultimo fondo del ciclo; Stop maximo 1 box negativo debajo. Invalida si FPLEME rompe 0 hacia abajo y alcanza -4.
- ETAPA 1 venta: Stop minimo arriba del ultimo tope; Stop maximo 1 box positivo arriba. Invalida si FPLEME rompe 0 hacia arriba y alcanza +4.
- ETAPA 2: ver seccion 3B.7 (stops especificos por etapa 2). PENDIENTE: definir reglas exactas de stop ETAPA 2 que usaremos en codigo.

## Parametros configurables (segun doc V2)
- FplemeM7Configuration (bool, default): PaintBars=true, FastMode=false, TrackRecord=false, ShowEtapa1=true, ShowEtapa2=true, ShowStop=true, ShowFreq1=false, ShowFreq2=false, ShowFreq3=false, Breakouts=false, GraphBreakouts=false.
- VxM7Configuration (bool, default): TheWall=true, ForceLines=true, Pullbacks=false.
- MapsM7Configuration (bool, default): Centrais=true, Intermediarios=true, CleanMode=false, TheWall=true, ForceLines=false, Pullbacks=false.
- StopAbsVConfiguration (bool, default): ShowAbs=true, ShowStops=true, Check=true.
- EntryTimingMode (enum): Classic=0, Mode2_2=1 (aplica a ETAPA 2). PENDIENTE: confirmar exposicion/configuracion para usuario.
- NinjaTrader color mapping: ciclo comprador se pinta azul, ciclo vendedor magenta/rosa.

## Que dibujar/mostrar en el chart
- Linea FPLEME (fina), color segun ciclo (azul/magenta) y grosor aumentan con fuerza.
- Linea SHARK (gruesa) con estado/color (azul/verde compra, rojo/magenta venta, amarillo equilibrio).
- Post-its en +-4 para FPLEME (verde/rojo claros y destacados), Post-it amarillo en SHARK cuando equilibrio.
- MAP0 y lineas MAPS (S1-S8 arriba, i1-i8 abajo; S5-S8/i5-i8 solo en alta volatilidad), colores segun doc (verde compradores, rojo/rosa vendedores, amarillo lateral/extremos de giro, etc.).
- The_Wall (MAPS y VX) con color de fuerza (verde o rosa/magenta) y post-its amarillos en VX.
- Opcional: pintura de barras segun ciclo (PaintBars), graficado de breakouts si se habilita.
- Marcadores/plots para ETAPA 1 y ETAPA 2 cuando se confirmen.

## Casos de prueba manuales (grilla)
1) ETAPA 1 compra valida: partir con FPLEME <= -4, que cruce a >=0 en 2o/3er box positivo; verificar Post-it en -4, SHARK azul, The_Wall no rosa. Entrada en base del box previo, stop bajo ultimo fondo.
2) ETAPA 1 invalida por extremo: FPLEME en -12/-8 intentando llegar a 0 en un box -> no debe disparar.
3) ETAPA 2 compra: FPLEME previo ~+4..+7, actual >=+8 en un box; SHARK azul; confirmar marker ETAPA 2; probar timing Classic vs 2.2.
4) Timing invalido: intentar comprar en el topo del box positivo -> debe marcarse como entrada invalida.
5) Filtro The_Wall: con The_Wall rosa/magenta, cualquier senal de compra ETAPA 1/2 debe bloquearse.
6) PENDIENTE: escenarios PPM/MM visuales a validar (necesitamos ejemplos graficos o reglas de deteccion concretas en codigo).

## Notas
- Toda la logica usa configuracion "patron de fabrica": XR desactivado, Modo Rapido desactivado.
- Priorizar alineacion de FPLEME y SHARK para evitar movimientos lateralizados.
- Documentos PDF referidos en V2 complementan ejemplos graficos (no incluidos aqui).

