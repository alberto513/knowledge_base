# Analisis completo por hora: Trades y Winrate
$csv = Import-Csv 'C:\Users\PC\Documents\NinjaTrader 8\logs\MFSScalp\MFSScalp_TradeLog.csv'

# Crear hashtable para almacenar estadisticas por hora
$hourStats = @{}

foreach ($row in $csv) {
    $time = [DateTime]::ParseExact($row.Timestamp, 'yyyy-MM-dd HH:mm:ss', $null)
    $hour = $time.Hour
    
    if (-not $hourStats.ContainsKey($hour)) {
        $hourStats[$hour] = @{
            Entries = 0
            Exits = 0
            Wins = 0
            Losses = 0
        }
    }
    
    if ($row.Type -eq 'ENTRY') {
        $hourStats[$hour].Entries++
    }
    elseif ($row.Type -eq 'EXIT') {
        $hourStats[$hour].Exits++
        $pnl = [double]$row.PnL
        if ($pnl -gt 0) {
            $hourStats[$hour].Wins++
        }
        elseif ($pnl -lt 0) {
            $hourStats[$hour].Losses++
        }
    }
}

Write-Host '===============================================' -ForegroundColor Cyan
Write-Host '  ANALISIS COMPLETO POR HORA (UTC)' -ForegroundColor Yellow
Write-Host '===============================================' -ForegroundColor Cyan
Write-Host ''
Write-Host 'Hora  | Trades | Wins | Losses | Winrate | Calidad' -ForegroundColor Green
Write-Host '------|--------|------|--------|---------|--------' -ForegroundColor Gray

$results = @()

foreach ($hour in 0..23) {
    if ($hourStats.ContainsKey($hour)) {
        $stats = $hourStats[$hour]
        $totalTrades = $stats.Exits
        $wins = $stats.Wins
        $losses = $stats.Losses
        
        if ($totalTrades -gt 0) {
            $winrate = [math]::Round(($wins / $totalTrades) * 100, 1)
        } else {
            $winrate = 0
        }
        
        # Determinar calidad
        $calidad = ''
        if ($totalTrades -ge 10) {
            if ($winrate -ge 60) { $calidad = 'EXCELENTE' }
            elseif ($winrate -ge 55) { $calidad = 'MUY BUENO' }
            elseif ($winrate -ge 50) { $calidad = 'BUENO' }
            elseif ($winrate -ge 45) { $calidad = 'REGULAR' }
            else { $calidad = 'MALO' }
        } else {
            $calidad = 'Pocos datos'
        }
        
        $results += [PSCustomObject]@{
            Hora = $hour
            Trades = $totalTrades
            Wins = $wins
            Losses = $losses
            Winrate = $winrate
            Calidad = $calidad
        }
    }
}

# Ordenar por hora y mostrar
$results | Sort-Object Hora | ForEach-Object {
    $hourStr = $_.Hora.ToString().PadLeft(2, '0')
    $tradesStr = $_.Trades.ToString().PadLeft(6)
    $winsStr = $_.Wins.ToString().PadLeft(4)
    $lossesStr = $_.Losses.ToString().PadLeft(6)
    $winrateStr = ('{0:F1}%' -f $_.Winrate).PadLeft(7)
    
    $color = 'White'
    if ($_.Calidad -eq 'EXCELENTE') { $color = 'Green' }
    elseif ($_.Calidad -eq 'MUY BUENO') { $color = 'Cyan' }
    elseif ($_.Calidad -eq 'BUENO') { $color = 'Yellow' }
    elseif ($_.Calidad -eq 'REGULAR') { $color = 'DarkYellow' }
    elseif ($_.Calidad -eq 'MALO') { $color = 'Red' }
    else { $color = 'Gray' }
    
    Write-Host "$hourStr`:00 |$tradesStr |$winsStr |$lossesStr | $winrateStr | $($_.Calidad)" -ForegroundColor $color
}

Write-Host ''
Write-Host 'RESUMEN:' -ForegroundColor Yellow
$totalTrades = ($results | Measure-Object -Property Trades -Sum).Sum
$totalWins = ($results | Measure-Object -Property Wins -Sum).Sum
$totalLosses = ($results | Measure-Object -Property Losses -Sum).Sum
$overallWinrate = if ($totalTrades -gt 0) { [math]::Round(($totalWins / $totalTrades) * 100, 2) } else { 0 }

Write-Host "  Total trades: $totalTrades"
Write-Host "  Total wins: $totalWins"
Write-Host "  Total losses: $totalLosses"
Write-Host "  Winrate general: $overallWinrate%"
Write-Host ''

Write-Host 'MEJORES HORARIOS (Winrate >= 55% y Trades >= 10):' -ForegroundColor Green
$results | Where-Object { $_.Winrate -ge 55 -and $_.Trades -ge 10 } | Sort-Object Winrate -Descending | ForEach-Object {
    $hourStr = $_.Hora.ToString().PadLeft(2, '0')
    Write-Host "  $hourStr`:00 UTC -> $($_.Trades) trades, $($_.Winrate)% winrate" -ForegroundColor Cyan
}

Write-Host ''
Write-Host 'PEORES HORARIOS (Winrate < 50% y Trades >= 10):' -ForegroundColor Red
$results | Where-Object { $_.Winrate -lt 50 -and $_.Trades -ge 10 } | Sort-Object Winrate | ForEach-Object {
    $hourStr = $_.Hora.ToString().PadLeft(2, '0')
    Write-Host "  $hourStr`:00 UTC -> $($_.Trades) trades, $($_.Winrate)% winrate" -ForegroundColor DarkYellow
}
