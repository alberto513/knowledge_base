# Reglas de confluencia (flujo y ciclos)

Nota: reglas sintetizadas desde OCR de capturas. Si algo no cuadra, validar en la imagen fuente.

## Principio base
- Confluencia = escenario (MAPS: PPM/MM + The Wall) + ciclo (FPLEME/SHARK) + confirmacion cuantitativa (VX) + filtro de volatilidad (Hertz).
- MAPA es la ruta: lectura mayoritaria; FPLEME/VX completan el resto.
- Un solo indicador no es setup. Post-it aislado no es entrada ni salida.
- No usar EMAs u otros promedios. Prioridad: flujo y ciclos.

## Reglas de direccion (The Wall)
- Nunca vender con The Wall verde; nunca comprar con The Wall rosa.
- The Wall amarilla en zona central = lateralizacion; evitar entradas.
- Si el precio atraviesa The Wall, el mercado esta sin direccion (consolidacion).
- The Wall amarilla en extremos = posible inicio de reversa, no entrada inmediata.
- Dentro de PPM/MM, ideal que The Wall ya haya sido rompida y este a favor.

## Reglas FPLEME/SHARK
- Etapa 1 compra: FPLEME de -4.00 a 0.00.
- Etapa 1 venta: FPLEME de +4.00 a 0.00.
- No existe Etapa 1 si FPLEME esta en +/-8 o +/-12.
- Etapa 2 compra: FPLEME de +4.00 a +8.00.
- Etapa 2 venta: FPLEME de -4.00 a -8.00.
- No existe Etapa 2 si FPLEME va 0->4 o 8->12.
- Post-it destacado = Shark alineado con la etapa; mayor fluidez.
- Post-it opaco = Shark no alineado; mayor lateralizacion.
- Post-it amarillo en SHARK = equilibrio; posible cambio, no confirmacion.
- En activos muy volatiles, la linea puede cambiar antes del post-it; priorizar color de linea.
- FPLEME y SHARK alineados = mayor probabilidad; desalineados = lateral.

## Reglas de escenario (MAPS)
- PPM: segundo ciclo debe avanzar en MAP mas alta (compra) o mas baja (venta); VX debe confirmar la direccion.
- MM: segundo ciclo en la misma MAP; escenario mas debil; usar solo cuando PPM no aplica.
- Evitar MM en extremos (sobreprecio/subprecio). Para reversa, preferir PPM.
- Range y Problines son puntos de atencion, no setups.
- Lineas de compradores/vendedores (pullback) indican interes, no ejecucion; para principiantes se pueden ocultar.
- Problines aparecen en pares (S4/S5, S5/S6, etc) cuando sube volatilidad; pueden aparecer antes de que Hertz cambie.
- Range se ajusta con la volatilidad; no asumir reversa automatica.

## Fases y zonas (MAPS)
- Acumulacion: suele ocurrir en i3/i4/i5 (mas profundo si el activo es mas volatil); The Wall aun rosa; si es valida, lateraliza a amarillo y el precio se mantiene arriba de The Wall y MAP-0.
- Inicio de alta: por encima de i4; PPM aplica; The Wall cambia de rosa a amarillo.
- Alta fuerte: desde MAP-0 hacia arriba; fondos mas altos; acelera al romper S2; The Wall no puede estar rosa.
- Distribucion: suele ocurrir en s3/s4/s5 (OCR en Nasdaq es ambiguo); The Wall aun verde; si es valida, lateraliza a amarillo y el precio queda abajo de The Wall y MAP-0.
- Inicio de baja: por debajo de s4; PPM aplica; The Wall cambia de verde a amarillo.
- Baja fuerte: desde MAP-0 hacia abajo; topes mas bajos; acelera al romper i2; The Wall no puede estar verde.

## Reglas VX
- VX confirma rupturas de MAP cuando la linea horizontal se vuelve mas espesa.
- Si barras verticales no cruzan la horizontal, no hay rompimiento.
- Barras crecientes arriba de MAP0 = agresion compradora; barras decrecientes abajo = agresion vendedora.
- The Wall del VX debe inclinarse a favor de la tendencia (verde compra, rosa venta).
- Post-its amarillos en The Wall (VX) anticipan cambio; no operan solos.
- The Wall del VX ayuda a ver cuando la The Wall del grafico cruza una MAP.
- VX ayuda a ver divergencias/convergencias de MAP y el saldo para romper The Wall.

## Reglas Hertz (volatilidad)
- Numero mayor = mas volatilidad; implica stops y alvos mayores.
- En futuros, si Frecuencia Conforto > 30R en grafico 5m, evitar ese activo.
- No "enganar" cambiando timeframe; el riesgo real sigue alto.
- Hertz convierte grafico temporal en atemporal y ayuda a reducir lateralizacion (zipers).

## Generador independiente V1
- Opera solo con RenkoBRZ y lectura propia de flujo/ciclo.
- Etapa 1 y 2 basadas en umbrales +/-4 y +/-8.
- Shark alineado obligatorio: compra solo con ciclo bullish, venta solo con ciclo bearish.
- Filtro de pendiente y cooldown para reducir ruido.
- Especificacion: docs/confluencia/GENERADOR_SENALES_V1.md
