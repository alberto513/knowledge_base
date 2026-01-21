# Reglas para aumentar winrate (flujo y ciclos)

## Objetivo
Elevar la tasa de acierto priorizando flujo y ciclos, aun si baja la frecuencia.

## Alcance y filosofia
- Usar solo herramientas inteligentes del ecosistema FPLEME: FPLEME, SHARK, MAPS, VX, The_Wall, escenarios PPM/MM y Renko/Hertz.
- No usar EMAs, MAs, RSI, MACD ni osciladores externos.
- Confirmar siempre por flujo y ciclo, no por velocidad o promedio.

## Configuracion base
- FPLEME en parametros de fabrica: XR = No, Modo Rapido = No.
- Renko ajustado por Hertz (frecuencia de confort) cuando aplique.
- Calculo OnBarClose (sin repaint).

## Regla 0: operar solo con escenario
- No operar se?ales aisladas.
- Solo operar si hay escenario PPM o MM valido y alineado con la direccion.
- Si no hay escenario, la senal es solo informativa (no trade).

## The_Wall (seguridad obligatoria)
- Verde: nunca vender.
- Rosa/magenta: nunca comprar.
- Amarilla en centro: lateral; solo con escenario confirmado y FPLEME/SHARK alineados.
- Amarilla en extremos: inicio de posible reversion, pero NO es entrada inmediata.

## SHARK (confirmacion de ciclo)
- Long: SHARK debe estar azul y alineado.
- Short: SHARK debe estar rojo/magenta y alineado.
- Si SHARK cambia contra la posicion, considerar salida o invalidacion.
- Post-it opaco = menor calidad; evitar para aumentar winrate.

## Evitar extremos
- No iniciar ciclos cuando FPLEME esta en +8/+12 o -8/-12.
- Evitar entradas cuando sigma esta cerca del extremo (zona de sobreprecio/sobreventa).

## ETAPA 1 (regla estricta)
### Long
- FPLEME sale de -4 y alcanza 0.
- Confirmacion en 2do o 3er box positivo consecutivo.
- SHARK ya azul (post-it destacado).
- Dentro de escenario PPM/MM y The_Wall no en contra.

### Short
- FPLEME sale de +4 y alcanza 0.
- Confirmacion en 2do o 3er box negativo consecutivo.
- SHARK ya rojo (post-it destacado).
- Dentro de escenario PPM/MM y The_Wall no en contra.

### Timing ETAPA 1
- Nunca entrar en el cierre del box de confirmacion.
- Long: entrar en la base del box positivo anterior.
- Short: entrar en el topo del box negativo anterior.

## ETAPA 2 (regla estricta)
### Long
- FPLEME sale de +4 y alcanza +8 en un solo box.
- No es ETAPA 2 si viene de 0 -> +4 o de +8 -> +12.
- SHARK azul confirmado.
- Solo dentro de escenario PPM/MM y con precio rompiendo The_Wall en favor.

### Short
- FPLEME sale de -4 y alcanza -8 en un solo box.
- No es ETAPA 2 si viene de 0 -> -4 o de -8 -> -12.
- SHARK rojo confirmado.
- Solo dentro de escenario PPM/MM y con precio rompiendo The_Wall en favor.

### Timing ETAPA 2
- Preferir modo clasico para mayor winrate.
- Modo clasico: entrar en base/topo del box anterior al de confirmacion.
- Modo 2.2: solo si el activo es muy volatil y el escenario es fuerte.

## Stops e invalidacion
### ETAPA 1
- Long: stop bajo el ultimo fondo del ciclo.
  - Limite maximo: 1 box negativo debajo del fondo.
- Short: stop sobre el ultimo topo del ciclo.
  - Limite maximo: 1 box positivo arriba del topo.
- Si se rompe el limite maximo, la operacion deja de ser ETAPA 1.

### ETAPA 2
- Long: stop en la base de dos cuerpos de boxes positivos anteriores.
- Short: stop en el topo de dos cuerpos de boxes negativos anteriores.
- Variante opcional: 2 boxes + 1 tick.

## PPM (checklist obligatorio)
### PPM compra
1) Fondo de referencia + SHARK azul.
2) Topo + SHARK rojo.
3) Entrar en el segundo ciclo comprador.
4) Segundo ciclo mas alto.
5) Segundo ciclo en MAP mas alta que la referencia.
6) The_Wall lateral o verde.

### PPM venta
1) Topo de referencia + SHARK rojo.
2) Fondo + SHARK azul.
3) Entrar en el segundo ciclo vendedor.
4) Segundo ciclo mas bajo.
5) Segundo ciclo en MAP mas baja que la referencia (VX en caida).
6) The_Wall lateral o rosa.

## MM (checklist obligatorio si no hay PPM)
### MM compra
1) Fondo de referencia + SHARK azul.
2) Topo + SHARK rojo.
3) Entrar en el segundo ciclo comprador.
4) Segundo ciclo mas alto.
5) Segundo ciclo en la misma MAP que la referencia.
6) The_Wall lateral o verde.

### MM venta
1) Topo de referencia + SHARK rojo.
2) Fondo + SHARK azul.
3) Entrar en el segundo ciclo vendedor.
4) Segundo ciclo mas bajo.
5) Segundo ciclo en la misma MAP que la referencia.
6) The_Wall lateral o rosa.

## Reglas de prioridad (para winrate)
- Prioridad 1: ETAPA 1 dentro de PPM/MM con SHARK alineado y The_Wall favorable.
- Prioridad 2: ETAPA 2 dentro de PPM/MM con rompimiento de The_Wall a favor.
- No usar Early entries ni fallbacks.
- Ignorar senales LQ; solo HQ.

## Requisitos de datos (para codigo)
- Sigma FPLEME y estado de post-its en +/-4.
- SHARK y su color/estado.
- The_Wall (MAPS) color y posicion relativa al precio.
- VX: color/inclinacion de The_Wall y post-its amarillos.
- Deteccion de escenarios PPM/MM y su direccion.
- Conteo de boxes Renko y cruce de niveles.
