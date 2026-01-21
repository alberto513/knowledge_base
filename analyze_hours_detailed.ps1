# Analizar winrate por hora - DETALLADO
$csv = Import-Csv "c:\Users\PC\Documents\NinjaTrader 8\logs\MFSScalp\MFSScalp_TradeLog.csv"

# Filtrar solo EXIT
$exits = $csv | Where-Object {$_.Type -eq 'EXIT'}

Write-Host "=== ANALISIS POR HORA ===" -ForegroundColor Cyan
Write-Host "Total Trades: $($exits.Count)" -ForegroundColor Yellow
Write-Host ""

# Agrupar por hora
$hourStats = $exits | ForEach-Object {
    $hour = ([datetime]$_.Timestamp).Hour
    [PSCustomObject]@{
        Hour = $hour
        Result = $_.Direction
    }
} | Group-Object Hour | ForEach-Object {
    $wins = ($_.Group | Where-Object Result -eq 'WIN').Count
    $total = $_.Count
    $losses = $total - $wins
    $wr = if($total -gt 0){[math]::Round($wins/$total*100,1)}else{0}
    
    [PSCustomObject]@{
        Hour = [int]$_.Name
        Trades = $total
        Wins = $wins
        Losses = $losses
        'WR%' = $wr
    }
} | Sort-Object Hour

$hourStats | Format-Table -AutoSize

Write-Host "`n=== MEJORES HORARIOS (Winrate > 55% Y Trades > 10) ===" -ForegroundColor Green
$best = $hourStats | Where-Object {$_.'WR%' -gt 55 -and $_.Trades -gt 10}
$best | Format-Table -AutoSize

if ($best) {
    $bestTrades = ($best | Measure-Object -Property Trades -Sum).Sum
    $bestWins = ($best | Measure-Object -Property Wins -Sum).Sum
    $bestWR = [math]::Round($bestWins/$bestTrades*100,1)
    Write-Host "Total en mejores horarios: $bestTrades trades, WR: $bestWR%" -ForegroundColor Green
}

Write-Host "`n=== PEORES HORARIOS (Winrate < 45% O Trades < 5) ===" -ForegroundColor Red
$worst = $hourStats | Where-Object {$_.'WR%' -lt 45 -or $_.Trades -lt 5}
$worst | Format-Table -AutoSize

if ($worst) {
    $worstTrades = ($worst | Measure-Object -Property Trades -Sum).Sum
    $worstLosses = ($worst | Measure-Object -Property Losses -Sum).Sum
    Write-Host "Total en peores horarios: $worstTrades trades" -ForegroundColor Red
}

Write-Host "`n=== RECOMENDACION ===" -ForegroundColor Yellow
Write-Host "Operar SOLO en estos horarios (UTC):" -ForegroundColor Cyan
$best | ForEach-Object { Write-Host "  - $($_.Hour):00 (WR: $($_.'WR%')%)" -ForegroundColor Green }

Write-Host "`nEVITAR estos horarios:" -ForegroundColor Cyan
$worst | ForEach-Object { Write-Host "  - $($_.Hour):00 (WR: $($_.'WR%')%)" -ForegroundColor Red }
