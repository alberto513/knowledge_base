# Analisis completo MFSScalp v4 - METRICAS REALES
# Autor: Sistema automatizado
# Fecha: 2026-01-12

$logPath = "c:\Users\PC\Documents\NinjaTrader 8\logs\MFSScalp\MFSScalp_TradeLog.csv"

Write-Host ""
Write-Host "=================================================================" -ForegroundColor Cyan
Write-Host "  MFSScalp v4 - ANALISIS COMPLETO" -ForegroundColor Cyan
Write-Host "=================================================================" -ForegroundColor Cyan
Write-Host ""

# Verificar si existe el log
if (-not (Test-Path $logPath)) {
    Write-Host "ERROR: Log no encontrado en $logPath" -ForegroundColor Red
    Write-Host "Ejecuta el indicador primero en NinjaTrader" -ForegroundColor Yellow
    exit
}

# Leer datos
$data = Import-Csv $logPath
$entries = @($data | Where-Object { $_.Type -eq "ENTRY" })
$exits = @($data | Where-Object { $_.Type -eq "EXIT" })

Write-Host "DATOS CARGADOS:" -ForegroundColor Yellow
Write-Host "  Total registros: $($data.Count)"
Write-Host "  Entradas: $($entries.Count)"
Write-Host "  Salidas: $($exits.Count)"
Write-Host ""

if ($entries.Count -eq 0) {
    Write-Host "No hay trades en el log" -ForegroundColor Red
    exit
}

# Calculos basicos
$totalTrades = $entries.Count
$wins = @($exits | Where-Object { $_.Direction -eq "WIN" })
$losses = @($exits | Where-Object { $_.Direction -eq "LOSS" })
$winCount = $wins.Count
$lossCount = $losses.Count
$winrate = [math]::Round(($winCount / $totalTrades) * 100, 2)

# PnL detallado
$totalPnLTicks = 0
$totalWinTicks = 0
$totalLossTicks = 0

foreach ($exit in $exits) {
    $pnl = [double]$exit.PnL
    $totalPnLTicks += $pnl
    
    if ($pnl -gt 0) {
        $totalWinTicks += $pnl
    } else {
        $totalLossTicks += [math]::Abs($pnl)
    }
}

$totalPnLPoints = $totalPnLTicks / 4.0
$avgPnLTicks = $totalPnLTicks / $totalTrades
$avgPnLPoints = $totalPnLPoints / $totalTrades
$avgWinTicks = if ($winCount -gt 0) { $totalWinTicks / $winCount } else { 0 }
$avgLossTicks = if ($lossCount -gt 0) { $totalLossTicks / $lossCount } else { 0 }
$profitFactor = if ($totalLossTicks -gt 0) { $totalWinTicks / $totalLossTicks } else { 0 }
$expectancy = $avgWinTicks * ($winrate / 100.0) - $avgLossTicks * (1.0 - $winrate / 100.0)

# Fechas
$firstDate = [DateTime]::ParseExact($entries[0].Timestamp, "yyyy-MM-dd HH:mm:ss", $null)
$lastDate = [DateTime]::ParseExact($entries[-1].Timestamp, "yyyy-MM-dd HH:mm:ss", $null)
$dias = ($lastDate - $firstDate).Days
if ($dias -eq 0) { $dias = 1 }

Write-Host "=================================================================" -ForegroundColor Green
Write-Host "  RESULTADOS PRINCIPALES" -ForegroundColor Green
Write-Host "=================================================================" -ForegroundColor Green
Write-Host ""
Write-Host "TRADES: $totalTrades | WINS: $winCount | LOSSES: $lossCount"
Write-Host "WINRATE: $winrate%" -ForegroundColor $(if ($winrate -ge 55) { "Green" } elseif ($winrate -ge 50) { "Yellow" } else { "Red" })
Write-Host ""
Write-Host "PnL TOTAL: $([math]::Round($totalPnLTicks, 1)) ticks = $([math]::Round($totalPnLPoints, 2)) puntos"
Write-Host "PnL USD: `$$([math]::Round($totalPnLPoints * 20, 2))" -ForegroundColor $(if ($totalPnLPoints -gt 0) { "Green" } else { "Red" })
Write-Host ""
Write-Host "PROMEDIO POR TRADE: $([math]::Round($avgPnLTicks, 2)) ticks ($([math]::Round($avgPnLPoints, 2)) puntos)"
Write-Host "WIN PROMEDIO: $([math]::Round($avgWinTicks, 1)) ticks"
Write-Host "LOSS PROMEDIO: $([math]::Round($avgLossTicks, 1)) ticks"
Write-Host ""
Write-Host "PROFIT FACTOR: $([math]::Round($profitFactor, 2))" -ForegroundColor $(if ($profitFactor -ge 1.5) { "Green" } elseif ($profitFactor -ge 1.0) { "Yellow" } else { "Red" })
Write-Host "EXPECTATIVA: $([math]::Round($expectancy, 2)) ticks/trade" -ForegroundColor $(if ($expectancy -gt 0) { "Green" } else { "Red" })
Write-Host ""
Write-Host "PERIODO: $dias dias"
Write-Host "TRADES/DIA: $([math]::Round($totalTrades / $dias, 1))"
Write-Host ""

# Distribucion
$longs = @($entries | Where-Object { $_.Direction -eq "LONG" })
$shorts = @($entries | Where-Object { $_.Direction -eq "SHORT" })
$ppm = @($entries | Where-Object { $_.Scenario -eq "PPM" })
$mm = @($entries | Where-Object { $_.Scenario -eq "MM" })

Write-Host "=================================================================" -ForegroundColor Yellow
Write-Host "  DISTRIBUCION" -ForegroundColor Yellow
Write-Host "=================================================================" -ForegroundColor Yellow
Write-Host ""
Write-Host "DIRECCION:"
Write-Host "  LONGs: $($longs.Count) ($([math]::Round(($longs.Count/$totalTrades)*100,1))%)"
Write-Host "  SHORTs: $($shorts.Count) ($([math]::Round(($shorts.Count/$totalTrades)*100,1))%)"
Write-Host ""
Write-Host "ESCENARIO:"
Write-Host "  PPM: $($ppm.Count) ($([math]::Round(($ppm.Count/$totalTrades)*100,1))%)"
Write-Host "  MM: $($mm.Count) ($([math]::Round(($mm.Count/$totalTrades)*100,1))%)"
Write-Host ""

# Duracion
$avgBars = if ($exits.Count -gt 0) { 
    $totalBars = 0
    foreach ($e in $exits) { $totalBars += [int]$e.Bars }
    $totalBars / $exits.Count
} else { 0 }

Write-Host "DURACION PROMEDIO: $([math]::Round($avgBars, 1)) barras"
Write-Host ""

# Estadistica
if ($totalTrades -ge 30) {
    $n = $totalTrades
    $expectedWins = $n * 0.5
    $actualWins = $winCount
    $stdDev = [math]::Sqrt($n * 0.5 * 0.5)
    $zScore = if ($stdDev -gt 0) { ($actualWins - $expectedWins) / $stdDev } else { 0 }
    
    Write-Host "=================================================================" -ForegroundColor Magenta
    Write-Host "  SIGNIFICANCIA ESTADISTICA" -ForegroundColor Magenta
    Write-Host "=================================================================" -ForegroundColor Magenta
    Write-Host ""
    Write-Host "Z-Score: $([math]::Round($zScore, 2))"
    
    if ($zScore -gt 1.96) {
        Write-Host "Resultado: ESTADISTICAMENTE SIGNIFICATIVO (>95% confianza)" -ForegroundColor Green
        Write-Host "El winrate NO es suerte, es REAL" -ForegroundColor Green
    } elseif ($zScore -gt 1.64) {
        Write-Host "Resultado: SIGNIFICATIVO (>90% confianza)" -ForegroundColor Yellow
    } else {
        Write-Host "Resultado: NO SIGNIFICATIVO (puede ser suerte)" -ForegroundColor Red
    }
    Write-Host ""
}

# Calificacion final
Write-Host "=================================================================" -ForegroundColor Cyan
Write-Host "  CALIFICACION FINAL" -ForegroundColor Cyan
Write-Host "=================================================================" -ForegroundColor Cyan
Write-Host ""

$score = 0
if ($winrate -ge 55) { $score += 3 } elseif ($winrate -ge 52) { $score += 2 } elseif ($winrate -ge 50) { $score += 1 }
if ($profitFactor -ge 1.5) { $score += 3 } elseif ($profitFactor -ge 1.2) { $score += 2 } elseif ($profitFactor -ge 1.0) { $score += 1 }
if ($expectancy -gt 2) { $score += 2 } elseif ($expectancy -gt 0) { $score += 1 }
if ($totalTrades -ge 500) { $score += 2 } elseif ($totalTrades -ge 200) { $score += 1 }

if ($score -ge 9) {
    Write-Host "EXCELENTE - Sistema rentable y robusto" -ForegroundColor Green
    Write-Host "  Winrate: BUENO" -ForegroundColor Green
    Write-Host "  Profit Factor: BUENO" -ForegroundColor Green
    Write-Host "  Expectativa: POSITIVA" -ForegroundColor Green
    Write-Host "  Trades: SUFICIENTES" -ForegroundColor Green
} elseif ($score -ge 6) {
    Write-Host "BUENO - Sistema rentable" -ForegroundColor Yellow
    Write-Host "  Sistema funciona pero puede mejorar" -ForegroundColor Yellow
} elseif ($score -ge 3) {
    Write-Host "REGULAR - Apenas rentable" -ForegroundColor Yellow
    Write-Host "  Necesita optimizacion" -ForegroundColor Yellow
} else {
    Write-Host "MALO - Sistema NO rentable" -ForegroundColor Red
    Write-Host "  Necesita revision completa" -ForegroundColor Red
}

Write-Host ""
Write-Host "=================================================================" -ForegroundColor Cyan
Write-Host ""
