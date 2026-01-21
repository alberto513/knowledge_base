# Generador de senales V1 (independiente)

Objetivo: generar senales de entrada basadas en flujo y cambio de ciclo, sin depender de FPLEME/MAPS/VX/HERTZ.
Base: RenkoBRZ.

## Entradas (parametros)
- enableE1: true
- enableE2: true
- requireSharkAlign: true (obligatorio)
- requireSlope: true (filtro simple)
- cooldownBars: 3
- minBars: 100
- normPeriod: 500
- normScale: 12
- allowEarlySignals: true

## Linea de flujo (FPLEME-like)
- raw = Close[0] - Close[6]
- ema = EMA(raw, 2)
- norm = ((ema - min) / (max - min)) * 24 - 12
  - min/max sobre los ultimos 500 valores de ema
  - clamp a [-12, 12]

## Linea de ciclo (SHARK-like)
- raw = Close[0] - Close[5]
- ema1 = EMA(raw, 5)
- ema2 = EMA(ema1, 2)
- shark = ema2 * 1.877
- sharkNorm = normalizar igual que flujo (500, escala 12)
- sharkState: bullish si sharkNorm > 0, bearish si < 0, neutral si = 0

## Etapas
- E1 compra: armar si flujo <= -4; senal cuando flujo >= 0.
- E1 venta: armar si flujo >= +4; senal cuando flujo <= 0.
- E2 compra: armar si flujo entre +4 y +8; senal cuando flujo >= +8.
- E2 venta: armar si flujo entre -4 y -8; senal cuando flujo <= -8.

## Reglas de senal
- Solo RenkoBRZ.
- Shark alineado obligatorio:
  - compra solo si sharkState bullish
  - venta solo si sharkState bearish
- Filtro de pendiente (requireSlope):
  - compra si flujo - prevFlujo > 0
  - venta si flujo - prevFlujo < 0
- Cooldown: no emitir nueva senal si han pasado menos de cooldownBars desde la ultima senal.
- Con allowEarlySignals=true, se permiten senales antes de minBars usando ventana dinamica.

## Salida
- Plot flujo (linea fina) y shark (linea gruesa).
- Marcar E1/E2 con flechas y etiqueta (E1/E2).
- Opcional: serie booleana para alerta.

## Stop sugerido (opcional)
- E1 compra: ultimo swing low (pivot 5) con limite max 1 box abajo.
- E1 venta: ultimo swing high (pivot 5) con limite max 1 box arriba.
- E2 compra: base de los ultimos 2 boxes positivos (o low mas bajo de esos 2) + 1 tick opcional.
- E2 venta: techo de los ultimos 2 boxes negativos (o high mas alto de esos 2) + 1 tick opcional.

## Medicion (TP/SL fijo)
- TargetPoints y StopPoints por defecto = 10 (pensado para NQ).
- El indicador cuenta wins/losses con un trade a la vez.
- Si target y stop se tocan en la misma barra, por defecto cuenta stop (conservador).
- Stats en panel (ShowStats) y marcas opcionales (ShowOutcomeMarks).

## Implementacion
- Codigo: src/Indicators/FlowCycleSignalsV1.cs
- Indicador NinjaTrader 8, independiente y sin dependencias externas.

## Notas
- Los offsets/periodos usan constantes visibles en los DLL (6, 5, 2, 5, 1.877, 500, 12).
- La logica exacta de FPLEME/SHARK es protegida; este V1 replica la estructura y thresholds.
