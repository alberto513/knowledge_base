# Operativa FPLEME - reglas extraidas de PDFs

## Configuracion base (padrao de fabrica)
- XR: No
- Modo Rapido: No
- Reglas y ejemplos asumen parametros originales del FPLEME.

## FPLEME / SHARK / Post-its
- FPLEME y SHARK son lineas complementarias: FPLEME mide fuerza, SHARK confirma ciclo.
- Cambio de color FPLEME:
  - Verde/azul a rojo/rosa: cruza +4 y llega a 0.
  - Rojo/rosa a verde/azul: cruza -4 y llega a 0.
- Post-its en +4/-4 indican que cambio de color y toco 0 (ETAPA 1).
- Post-it destacado = SHARK ya alineado; post-it opaco = SHARK aun contrario (tendencia a lateralizacion).
- Post-its amarillos en SHARK indican equilibrio; no son senal por si solos.
- En activos muy volatiles, priorizar color de la linea sobre post-its.

## ETAPA 1 (inicio de ciclo)
### Compra (ETAPA 1 compradora)
- FPLEME sale de -4 y alcanza 0.
- Confirmacion suele ocurrir en 2do o 3er box positivo.
- No existe ETAPA 1 si FPLEME viene de -8/-12 (no puede llegar a 0 en 1 box).
- Post-it verde destacado si SHARK ya azul; opaco si SHARK rojo.

### Venta (ETAPA 1 vendedora)
- FPLEME sale de +4 y alcanza 0.
- Confirmacion suele ocurrir en 2do o 3er box negativo.
- No existe ETAPA 1 si FPLEME viene de +8/+12.
- Post-it rojo destacado si SHARK ya rojo; opaco si SHARK azul.

### Timing de entrada (ETAPA 1)
- Nunca comprar en el topo del box positivo.
- Entrada long: base del box positivo anterior al de confirmacion.
- Nunca vender en el fondo del box negativo.
- Entrada short: topo del box negativo anterior al de confirmacion.

### Stop y descaracterizacion (ETAPA 1)
- Long: stop debajo del ultimo fondo del ciclo comprador.
  - Limite maximo: 1 box negativo debajo de ese fondo.
  - Si rompe ese limite, FPLEME pasa a rojo y la operacion deja de ser ETAPA 1.
- Short: stop encima del ultimo topo del ciclo vendedor.
  - Limite maximo: 1 box positivo encima de ese topo.
  - Si rompe ese limite, FPLEME pasa a verde y la operacion deja de ser ETAPA 1.

## ETAPA 2 (continuacion)
### Compra (ETAPA 2 compradora)
- FPLEME sale de +4 y alcanza +8 (en el box de confirmacion).
- No es ETAPA 2 si viene de 0 -> +4.
- No es ETAPA 2 si viene de +8 -> +12.
- SHARK debe estar azul; si se pone rojo, usarlo como salida.

### Venta (ETAPA 2 vendedora)
- FPLEME sale de -4 y alcanza -8 (en el box de confirmacion).
- No es ETAPA 2 si viene de 0 -> -4.
- No es ETAPA 2 si viene de -8 -> -12.
- SHARK debe estar rojo; si se pone azul, usarlo como salida.

### Timing de entrada (ETAPA 2)
- Modo clasico: entrar en la base/topo del box anterior al que confirmo la ETAPA 2.
- Modo 2.2 (menos conservador): entrar en la base/topo del propio box de confirmacion.
- Nunca comprar en el topo ni vender en el fondo del box.

### Stop (ETAPA 2)
- Long: stop en la base de dos cuerpos de boxes positivos anteriores (contados desde el mejor punto de entrada).
- Short: stop en el topo de dos cuerpos de boxes negativos anteriores.
- Variante opcional: 2 boxes + 1 tick.

### Filtros de escenario (ETAPA 2)
- Priorizar ETAPA 2 dentro de escenarios PPM/MM.
- Solo si el precio ya rompio la The_Wall dentro del escenario.
- The_Wall debe estar en el color de la tendencia deseada.
- Cautela en zonas de sobreprecio/sobreventa.

## PPM (Progresso de Preco em MAP) - checklist
### PPM venta (regresion de precio en MAP)
1) Esperar referencia: al menos un topo + SHARK rojo (inicio ciclo vendedor).
2) Esperar un fondo + SHARK azul (inicio ciclo comprador).
3) Prepararse para entrar en el segundo ciclo vendedor.
4) Segundo ciclo vendedor mas bajo que el primero.
5) Segundo ciclo vendedor en MAP mas baja que la MAP de referencia (VX en caida).
6) The_Wall lateral o a favor en la entrada (amarilla o rosa).

### PPM compra
1) Esperar referencia: al menos un fondo + SHARK azul (inicio ciclo comprador).
2) Esperar un topo + SHARK rojo (inicio ciclo vendedor).
3) Prepararse para entrar en el segundo ciclo comprador.
4) Segundo ciclo comprador mas alto que el anterior.
5) Segundo ciclo comprador en MAP mas alta que la MAP de referencia.
6) The_Wall lateral o a favor en la entrada (amarilla o verde).

## MM (MAP com MAP)
### MM venta
1) Esperar referencia: al menos un topo + SHARK rojo (primer ciclo vendedor).
2) Esperar un fondo + SHARK azul (primer ciclo comprador).
3) Prepararse para el segundo ciclo vendedor.
4) Segundo ciclo vendedor mas bajo que el anterior.
5) Segundo ciclo vendedor en la misma MAP que la referencia (MAP 0 con MAP 0, i1 con i1, etc).
6) The_Wall lateral o a favor en la entrada (amarilla o rosa).

### MM compra
1) Esperar referencia: al menos un fondo + SHARK azul (primer ciclo comprador).
2) Esperar un topo + SHARK rojo (primer ciclo vendedor).
3) Prepararse para el segundo ciclo comprador.
4) Segundo ciclo comprador mas alto que el anterior.
5) Segundo ciclo comprador en la misma MAP que la referencia (MAP 0 con MAP 0, s1 con s1, etc).
6) The_Wall lateral o a favor en la entrada (amarilla o verde).

### Recomendaciones MM
- MM es mas debil que PPM; usarlo solo si PPM no aplica.
- Preferir MM en direccion de tendencia (ej. ventas desde MAP 0 hacia abajo).
- Evitar MM en extremos si The_Wall esta en contra (verde para venta, rosa para compra).
- Cuanto mayor la diferencia entre ciclos, mas seguro el MM.

## The_Wall (MAPS)
- The_Wall divide precio arriba/abajo; si el precio cruza la The_Wall, el mercado esta lateral o finalizando tendencia.
- Verde: alta fuerza compradora, nunca operar venta.
- Rosa/magenta: alta fuerza vendedora, nunca operar compra.
- Amarilla en centro: lateralizacion; requiere FPLEME para decidir direccion.
- Amarilla en extremos: posible inicio de escenario de reversion, pero no es entrada inmediata.
- MAPS no se usa aislado; confirmar con FPLEME/VX y escenario.

## VX (The_Wall en VX)
- The_Wall del VX y la del grafico son la misma herramienta en otra perspectiva.
- VX compara inclinacion con MAP:
  - Mas inclinada hacia arriba -> verde.
  - Mas inclinada hacia abajo -> rosa/magenta.
- Post-its amarillos en The_Wall indican cambio de direccion/color.
- VX ayuda a confirmar cruces de MAP por parte de The_Wall.

## Hertz / Renko (opcional)
- Hertz traduce grafico temporal a atemporal y ayuda a elegir el Renko.
- El valor de la etiqueta indica el Renko recomendado (frecuencia de confort).
