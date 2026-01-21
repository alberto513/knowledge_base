# Analisis completo MFSScalp v3 vs v2
$logPath = "c:\Users\PC\Documents\NinjaTrader 8\logs\MFSScalp\MFSScalp_TradeLog.csv"

Write-Host "=======================================================" -ForegroundColor Cyan
Write-Host "  ANALISIS MFSSCALP V3 - SISTEMA DE CONTEXTOS" -ForegroundColor Cyan
Write-Host "=======================================================" -ForegroundColor Cyan
Write-Host ""

# Leer CSV
$data = Import-Csv $logPath

# Separar entradas y salidas
$entries = $data | Where-Object { $_.Type -eq "ENTRY" }
$exits = $data | Where-Object { $_.Type -eq "EXIT" }

# Estadisticas generales
$totalTrades = $entries.Count
$wins = ($exits | Where-Object { $_.Direction -eq "WIN" }).Count
$losses = ($exits | Where-Object { $_.Direction -eq "LOSS" }).Count
$winrate = if ($totalTrades -gt 0) { [math]::Round(($wins / $totalTrades) * 100, 2) } else { 0 }

# PnL
$totalPnL = ($exits | Measure-Object -Property PnL -Sum).Sum
$avgPnL = if ($totalTrades -gt 0) { [math]::Round($totalPnL / $totalTrades, 2) } else { 0 }
$winPnL = ($exits | Where-Object { [double]$_.PnL -gt 0 } | Measure-Object -Property PnL -Sum).Sum
$lossPnL = [math]::Abs(($exits | Where-Object { [double]$_.PnL -lt 0 } | Measure-Object -Property PnL -Sum).Sum)
$profitFactor = if ($lossPnL -gt 0) { [math]::Round($winPnL / $lossPnL, 2) } else { 0 }

# Analisis por escenario
$ppmTrades = ($entries | Where-Object { $_.Scenario -eq "PPM" }).Count
$mmTrades = ($entries | Where-Object { $_.Scenario -eq "MM" }).Count

# Analisis por direccion
$longs = ($entries | Where-Object { $_.Direction -eq "LONG" }).Count
$shorts = ($entries | Where-Object { $_.Direction -eq "SHORT" }).Count

# Fechas
$firstDate = [DateTime]::ParseExact($entries[0].Timestamp, "yyyy-MM-dd HH:mm:ss", $null)
$lastDate = [DateTime]::ParseExact($entries[-1].Timestamp, "yyyy-MM-dd HH:mm:ss", $null)
$days = ($lastDate - $firstDate).Days

Write-Host "RESULTADOS GENERALES" -ForegroundColor Yellow
Write-Host "-------------------------------------------------------"
Write-Host "  Total de Trades:     $totalTrades"
Write-Host "  Wins:                $wins"
Write-Host "  Losses:              $losses"
Write-Host ("  Winrate:             " + $winrate + "%") -ForegroundColor $(if ($winrate -ge 55) { "Green" } else { "Red" })
Write-Host ""
Write-Host ("  Profit Factor:       " + $profitFactor) -ForegroundColor $(if ($profitFactor -ge 1.5) { "Green" } else { "Yellow" })
Write-Host "  PnL Total:           $totalPnL ticks"
Write-Host "  PnL Promedio:        $avgPnL ticks/trade"
Write-Host ""
Write-Host "  Periodo:             $days dias"
Write-Host ("  Trades/Dia:          " + [math]::Round($totalTrades / $days, 1))
Write-Host ""

Write-Host "DISTRIBUCION" -ForegroundColor Yellow
Write-Host "-------------------------------------------------------"
$longPct = [math]::Round(($longs/$totalTrades)*100,1)
$shortPct = [math]::Round(($shorts/$totalTrades)*100,1)
$ppmPct = [math]::Round(($ppmTrades/$totalTrades)*100,1)
$mmPct = [math]::Round(($mmTrades/$totalTrades)*100,1)

Write-Host ("  LONGs:               " + $longs + " (" + $longPct + "%)")
Write-Host ("  SHORTs:              " + $shorts + " (" + $shortPct + "%)")
Write-Host ""
Write-Host ("  PPM:                 " + $ppmTrades + " (" + $ppmPct + "%)")
Write-Host ("  MM:                  " + $mmTrades + " (" + $mmPct + "%)")
Write-Host ""

# Comparacion con v2
Write-Host "COMPARACION V2 vs V3" -ForegroundColor Yellow
Write-Host "-------------------------------------------------------"
Write-Host "                       V2 (sin contextos)  |  V3 (con contextos)"
Write-Host "  Trades (150 dias):   ~5000               |  $totalTrades"
$wrColor = if ($winrate -gt 49) { "Green" } else { "Red" }
Write-Host ("  Winrate:             49%                 |  " + $winrate + "%") -ForegroundColor $wrColor
$tradesPerDay = [math]::Round($totalTrades / $days, 1)
Write-Host "  Trades/dia:          ~33                 |  $tradesPerDay"
Write-Host ""

# Analisis de calidad
$avgBars = if ($exits.Count -gt 0) { [math]::Round(($exits | Measure-Object -Property Bars -Average).Average, 1) } else { 0 }
Write-Host "CALIDAD DE TRADES" -ForegroundColor Yellow
Write-Host "-------------------------------------------------------"
Write-Host "  Duracion promedio:   $avgBars barras"
Write-Host ""

# Analisis estadistico
if ($totalTrades -ge 30) {
    $p = $winrate / 100
    $n = $totalTrades
    $expectedWins = $n * 0.5
    $actualWins = $wins
    $stdDev = [math]::Sqrt($n * 0.5 * 0.5)
    $zScore = if ($stdDev -gt 0) { [math]::Round(($actualWins - $expectedWins) / $stdDev, 2) } else { 0 }
    
    Write-Host "SIGNIFICANCIA ESTADISTICA" -ForegroundColor Yellow
    Write-Host "-------------------------------------------------------"
    Write-Host "  Z-Score:             $zScore"
    
    if ($zScore -gt 1.96) {
        Write-Host "  Resultado:           ESTADISTICAMENTE SIGNIFICATIVO (>95%)" -ForegroundColor Green
    } elseif ($zScore -gt 1.64) {
        Write-Host "  Resultado:           SIGNIFICATIVO (>90%)" -ForegroundColor Yellow
    } else {
        Write-Host "  Resultado:           NO SIGNIFICATIVO" -ForegroundColor Red
    }
    Write-Host ""
}

# Conclusion
Write-Host "=======================================================" -ForegroundColor Cyan
Write-Host "  CONCLUSION" -ForegroundColor Cyan
Write-Host "=======================================================" -ForegroundColor Cyan

$improvement = $winrate - 49
if ($winrate -ge 55) {
    $improvementStr = [math]::Round($improvement, 1)
    Write-Host ("EXITO: Winrate mejoro +" + $improvementStr + "% vs v2") -ForegroundColor Green
    Write-Host ("Trades mas selectivos (" + $totalTrades + " vs 5000)") -ForegroundColor Green
    Write-Host "Sistema de contextos FUNCIONANDO" -ForegroundColor Green
} elseif ($winrate -ge 52) {
    $improvementStr = [math]::Round($improvement, 1)
    Write-Host ("MEJORIA LEVE: +" + $improvementStr + "% vs v2") -ForegroundColor Yellow
    Write-Host "Puede necesitar ajuste de parametros" -ForegroundColor Yellow
} else {
    Write-Host ("SIN MEJORA: " + $winrate + "% vs 49% (v2)") -ForegroundColor Red
    Write-Host "Necesita revision de filtros" -ForegroundColor Red
}
Write-Host ""
