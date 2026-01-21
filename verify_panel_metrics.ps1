# Verificar métricas del panel MFSScalp v4
$logPath = "c:\Users\PC\Documents\NinjaTrader 8\logs\MFSScalp\MFSScalp_TradeLog.csv"

Write-Host "═══════════════════════════════════════════════════════" -ForegroundColor Cyan
Write-Host "  VERIFICACIÓN PANEL vs LOG" -ForegroundColor Cyan
Write-Host "═══════════════════════════════════════════════════════" -ForegroundColor Cyan
Write-Host ""

# Leer CSV
$data = Import-Csv $logPath

# Separar entradas y salidas
$entries = $data | Where-Object { $_.Type -eq "ENTRY" }
$exits = $data | Where-Object { $_.Type -eq "EXIT" }

Write-Host "DATOS DEL LOG:" -ForegroundColor Yellow
Write-Host "  Total líneas: $($data.Count)"
Write-Host "  Entradas: $($entries.Count)"
Write-Host "  Salidas: $($exits.Count)"
Write-Host ""

# Calculos
$totalTrades = $entries.Count
$wins = ($exits | Where-Object { $_.Direction -eq "WIN" }).Count
$losses = ($exits | Where-Object { $_.Direction -eq "LOSS" }).Count
$winrate = if ($totalTrades -gt 0) { [math]::Round(($wins / $totalTrades) * 100, 2) } else { 0 }

# PnL (convertir a double)
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
$avgPnLTicks = if ($totalTrades -gt 0) { $totalPnLTicks / $totalTrades } else { 0 }
$avgPnLPoints = if ($totalTrades -gt 0) { $totalPnLPoints / $totalTrades } else { 0 }
$avgWinTicks = if ($wins -gt 0) { $totalWinTicks / $wins } else { 0 }
$avgLossTicks = if ($losses -gt 0) { $totalLossTicks / $losses } else { 0 }
$profitFactor = if ($totalLossTicks -gt 0) { $totalWinTicks / $totalLossTicks } else { 0 }
$expectancy = if ($totalTrades -gt 0) { ($avgWinTicks * ($winrate / 100.0)) - ($avgLossTicks * (1.0 - $winrate / 100.0)) } else { 0 }

Write-Host "═══════════════════════════════════════════════════════" -ForegroundColor Green
Write-Host "  MÉTRICAS CALCULADAS DEL LOG" -ForegroundColor Green
Write-Host "═══════════════════════════════════════════════════════" -ForegroundColor Green
Write-Host ""

Write-Host "TRADES: $totalTrades | W: $wins | L: $losses"
Write-Host "WINRATE: $($winrate)%"
Write-Host ""
Write-Host "TP/SL: 40 ticks (10.0 pts) / 40 ticks (10.0 pts)"
Write-Host ""
Write-Host ("PnL TOTAL: " + [math]::Round($totalPnLTicks, 1) + " ticks = " + [math]::Round($totalPnLPoints, 2) + " puntos")
Write-Host ("PnL PROMEDIO: " + [math]::Round($avgPnLTicks, 2) + " ticks/trade (" + [math]::Round($avgPnLPoints, 2) + " pts)")
Write-Host ""
Write-Host ("WIN PROMEDIO: " + [math]::Round($avgWinTicks, 1) + " ticks")
Write-Host ("LOSS PROMEDIO: " + [math]::Round($avgLossTicks, 1) + " ticks")
Write-Host ("PROFIT FACTOR: " + [math]::Round($profitFactor, 2))
Write-Host ("EXPECTATIVA: " + [math]::Round($expectancy, 2) + " ticks/trade")
Write-Host ""

Write-Host "═══════════════════════════════════════════════════════" -ForegroundColor Yellow
Write-Host "  COMPARACIÓN PANEL" -ForegroundColor Yellow
Write-Host "═══════════════════════════════════════════════════════" -ForegroundColor Yellow
Write-Host ""
Write-Host "Panel dice:"
Write-Host "  TRADES: 285 | W: 157 | L: 128"
Write-Host "  WINRATE: 55.09%"
Write-Host "  PnL TOTAL: 1160.0 ticks = 290.00 puntos"
Write-Host "  PnL PROMEDIO: 4.07 ticks/trade (1.02 pts)"
Write-Host "  WIN PROMEDIO: 40.0 ticks"
Write-Host "  LOSS PROMEDIO: 40.0 ticks"
Write-Host "  PROFIT FACTOR: 1.23"
Write-Host ""
Write-Host "Log real:"
Write-Host ("  TRADES: " + $totalTrades + " | W: " + $wins + " | L: " + $losses)
Write-Host ("  WINRATE: " + $winrate + "%")
Write-Host ("  PnL TOTAL: " + [math]::Round($totalPnLTicks, 1) + " ticks = " + [math]::Round($totalPnLPoints, 2) + " puntos")
Write-Host ("  PnL PROMEDIO: " + [math]::Round($avgPnLTicks, 2) + " ticks/trade (" + [math]::Round($avgPnLPoints, 2) + " pts)")
Write-Host ("  WIN PROMEDIO: " + [math]::Round($avgWinTicks, 1) + " ticks")
Write-Host ("  LOSS PROMEDIO: " + [math]::Round($avgLossTicks, 1) + " ticks")
Write-Host ("  PROFIT FACTOR: " + [math]::Round($profitFactor, 2))
Write-Host ""

# Verificar si coinciden
Write-Host "═══════════════════════════════════════════════════════" -ForegroundColor Cyan
if ($totalTrades -eq 285 -and $wins -eq 157 -and $losses -eq 128) {
    Write-Host "✅ CONFIRMADO: Los números del panel COINCIDEN con el log" -ForegroundColor Green
} else {
    Write-Host "❌ DISCREPANCIA: Panel y log NO coinciden" -ForegroundColor Red
    Write-Host "   Diferencia Trades: $($totalTrades - 285)"
    Write-Host "   Diferencia Wins: $($wins - 157)"
    Write-Host "   Diferencia Losses: $($losses - 128)"
}
Write-Host "═══════════════════════════════════════════════════════" -ForegroundColor Cyan
Write-Host ""

# Mostrar primeras 10 salidas para verificar
Write-Host "PRIMERAS 10 SALIDAS DEL LOG:" -ForegroundColor Yellow
$exits | Select-Object -First 10 | Format-Table Timestamp, Direction, PnL, Bars
