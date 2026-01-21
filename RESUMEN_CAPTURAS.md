# Resumen de capturas (OCR)

Fuente: `docs/capturas/OCR_CAPTURAS.txt`.

## Etapa 1 (timing)
- Definicion compra: FPLEME sale de -4 y cierra un box que lleva la linea a 0.
- Definicion venta: FPLEME sale de +4 y cierra un box que lleva la linea a 0.
- Post-it verde destacado: Etapa 1 con Shark alineado (azul). Verde opaco: Shark en contra.
- No es Etapa 1 si FPLEME esta en -12/-8 o +12/+8; debe llegar a 0.
- Entrada compra: nunca en el tope del box positivo; colocar orden cerca de la base del box positivo anterior.
- Entrada venta: nunca en el fondo del box negativo; colocar orden cerca del tope del box negativo anterior.
- Stop venta: sobre el ultimo techo; maximo 1 box por encima. Si rompe y cierra 1 box arriba, invalida Etapa 1.
- Filtro: Etapa 1 mas segura dentro de PPM o MM (no aislada).

## Etapa 2
- Compra: FPLEME sale de +4 y llega a +8; Shark azul.
- Venta: FPLEME sale de -4 y llega a -8; Shark rojo.
- No es Etapa 2 si va 0->4 o 8->12.
- Entrada: nunca al cierre del box.
  - Etapa 2 clasica: entrada cerca de la base (compra) o tope (venta) del box anterior.
  - Etapa 2.2: entrada cerca de la base/tope del mismo box que confirma la etapa.
- Stop compra: base de dos cuerpos de boxes positivos anteriores (desde el mejor punto). Opcion +1 tick.
- Stop venta: tope de dos cuerpos de boxes negativos anteriores. Opcion +1 tick.
- Filtro escenario: operar Etapa 2 dentro de PPM o MM y con The_Wall ya rota y en color de la tendencia.
- Cautela: evitar Etapa 2 compra en zona de sobreprecio.
- Si Shark cambia a color opuesto, considerar salida.

## FPLEME (lineas y niveles)
- Niveles: +4 verde, -4 rojo, 0 blanco, +8/-8 gris, +12/-12 extremos.
- Linea FPLEME (fina): fuerza direccional. Linea Shark (gruesa) confirma ciclo.
- Cambio de color FPLEME:
  - Verde->rojo cuando cruza +4 y llega a 0.
  - Rojo->verde cuando cruza -4 y llega a 0.
- Post-its en +4/-4 indican cambio de color y toque a 0 (Etapa 1). No usar aislado.
- Post-its amarillos en Shark indican equilibrio y posible cambio, confirma la linea.
- En NinjaTrader: ciclo comprador azul, vendedor magenta.
- En activos muy volatiles, la linea puede cambiar antes del post-it.
- Linea mas gruesa = mayor fuerza direccional.

## MAPS (mapa de precio)
- MAP0 central (linea punteada). Arriba: s1..s4 (y s5..s8 en alta vol). Abajo: i1..i4 (y i5..i8).
- Range: lineas gruesas que delimitan amplitud, puntos de atencion, no setup.
- Problines: pares que aparecen si el precio puede exceder s4/i4; indica probabilidad de ir a lineas mas lejanas.
  No anticipar reversal en s4/i4 si Problines activas.
- Pullback lines (compradores/vendedores): verde/rojo. Solo como atajo visual, confirmar con FPLEME.
- The_Wall:
  - Verde: fuerza compradora fuerte (no vender).
  - Rosa/magenta: fuerza vendedora fuerte (no comprar).
  - Amarilla: lateral en zona central; en extremos puede indicar posible reversal.
  - Si el precio cruza The_Wall, mercado sin direccion clara.

## MM (MAP con MAP)
- Usar cuando PPM no aplica; mas debil y suele ocurrir en lateral.
- Reglas venta (resumen):
  1) Esperar techo de referencia y Shark rojo (inicio ciclo vendedor).
  2) Esperar fondo y Shark azul (inicio ciclo comprador).
  3) Entrar en segundo ciclo vendedor.
  4) Segundo ciclo vendedor mas bajo que el anterior.
  5) En la misma MAP del ciclo de referencia (MAP0 con MAP0, i1 con i1, s1 con s1, etc).
  6) The_Wall lateral o a favor (amarilla o rosa).
- Reglas compra: simetrico (segundo ciclo comprador mas alto, misma MAP, The_Wall amarilla o verde).
- Mas seguro si la inclinacion de ciclos es evidente; evitar niveles iguales.
- Evitar MM en extremos (sobreprecio/subprecio); usar PPM para reversals.

## PPM (progreso de precio en MAPS)
- Fases: acumulacion -> inicio de alza -> alza fuerte.
  Distribucion -> inicio de baja -> baja fuerte.
  Complementarias: reacumulacion/redistribucion.
- Acumulacion: tras baja fuerte, en MAP inferiores (i3/i4/i5 segun volatilidad).
  The_Wall rosa; si exitosa pasa a amarilla y precio se mantiene sobre The_Wall y MAP0.
- Inicio de alza: precio por encima de i4; The_Wall va de rosa a amarilla.
  PPM son fondos mas altos (ej i3 luego i1).
- Alza fuerte: precio en MAP superiores, acelera al romper s2.
  The_Wall no rosa (ideal verde). PPM o MM desde MAP0.
- Distribucion: tras alza fuerte, en MAP superiores (s3/s4/s5).
  The_Wall aun verde; luego inicio de baja y baja fuerte.
- Redistribucion: acumulacion fallida y la baja continua.

## VX
- Barras crecientes sobre MAP0 = agresion compradora; decrecientes bajo MAP0 = agresion vendedora.
- Rompimiento de lineas horizontales: si barras verticales rompen, la linea se engrosa (MAP rota).
  Si no rompen, falta fuerza.
- No usar VX aislado; sirve para leer MAP y divergencia/convergencia.
- The_Wall en VX: verde si inclinada arriba vs MAP, rosa si inclinada abajo.
  Post-its amarillos indican cambio.

## Hertz
- Hertz indica volatilidad; mayor Hertz = mas volatil.
- Si Frecuencia Conforto > 30R en 5 min (futuros), recomendacion: cambiar de activo ese dia.
- Cambiar a 1 min reduce Renko pero no elimina volatilidad; sigue el aviso del Hertz.
