# Operativa con confluencia

Nota: flujo basado en OCR de capturas. Confirmar en fuente si hay duda.

## 1. Filtro de volatilidad (Hertz)
- Day trade: usar grafico 5m para calcular Hertz (contrato full/perpetuo).
- Swing trade: usar grafico 60m.
- Usar frecuencia Conforto o Sniper para Renko; Macro para mapeo.
- Si Conforto > 30R en 5m, cambiar de activo.
- En mini contratos, calcular en full y luego aplicar el numero al mini.
- Si el numero cambia en medio del trade, no invalida la lectura; actualizar luego.

## 2. Mapeo
- Identificar MAP-0, s1..s5 arriba, i1..i5 abajo.
- Marcar Range y Problines como zonas de atencion; Problines pueden aparecer antes de que Hertz cambie.
- Lineas de compradores/vendedores (pullback) son solo atajos; si confunden, ocultarlas.
- The Wall debe separar arriba/abajo; si el precio la cruza, hay lateral.

## 3. Escenario
- Definir si el mercado esta en PPM o MM y en que fase (acumulacion, inicio de alta, alta fuerte, distribucion, inicio de baja, baja fuerte).
- PPM: buscar progresion de fondos/topes en MAPs; MM: retorno a la misma MAP.
- Confirmar que The Wall ya fue rompida en el sentido del trade y esta a favor.

## 4. Confluencia de direccion
- The Wall en color a favor (verde compra, rosa venta, amarilla lateral).
- Precio por encima de The Wall para compras; por debajo para ventas.
- VX barras y The Wall del VX alineadas con la direccion.
- FPLEME y SHARK alineados.

## 5. Entrada
- Etapa 1 compra: FPLEME -4->0 con Shark azul; no comprar al cierre; orden en base del box anterior.
- Etapa 1 venta: FPLEME +4->0 con Shark rojo; no vender al cierre; orden en techo del box anterior.
- Etapa 2 compra: FPLEME +4->+8 con Shark azul; entrada clasica en base del box anterior o Etapa 2.2 en base del box de confirmacion (util en alta volatilidad).
- Etapa 2 venta: FPLEME -4->-8 con Shark rojo; entrada clasica en techo del box anterior o Etapa 2.2 en techo del box de confirmacion.
- Si SHARK cambia contra el trade, usarlo como senal de salida.

## 6. Stop
- Etapa 1 compra: stop bajo el ultimo fondo; max 1 box negativo debajo.
- Etapa 1 venta: stop sobre el ultimo tope; max 1 box positivo arriba.
- Etapa 2 compra: stop en base de dos boxes positivos previos; opcional +1 tick.
- Etapa 2 venta: stop en techo de dos boxes negativos previos; opcional +1 tick.
- Tick = variacion minima del activo (ejemplos OCR: dolar 0.50, Nasdaq 0.25, oro 0.10).

## 7. Filtros finales
- Evitar Etapa 2 en sobreprecio (compra) o sobreventa (venta).
- Evitar trades sin escenario PPM/MM o con The Wall cruzada.
- No operar solo por post-it, por contacto con MAP o por Range.
- Si FPLEME/SHARK desalinean, esperar; suele indicar lateral.

## Uso con generador independiente V1
- RenkoBRZ obligatorio; el generador calcula su propia lectura de flujo/ciclo.
- Mantener FPLEME como lectura principal y usar la senal solo para entrada.
- Solo tomar senales con ciclo alineado (ya incluido en el generador).
- Si el contexto de MAPS/The Wall contradice la senal, omitirla.
- Especificacion: docs/confluencia/GENERADOR_SENALES_V1.md
