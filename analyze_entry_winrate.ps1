# Analisis de winrate por HORA DE ENTRADA
$csv = Import-Csv 'C:\Users\PC\Documents\NinjaTrader 8\logs\MFSScalp\MFSScalp_TradeLog.csv'

# Crear array para emparejar entries con exits
$trades = @{}
$tradeId = 0

foreach ($row in $csv) {
    if ($row.Type -eq 'ENTRY') {
        $tradeId++
        $time = [DateTime]::ParseExact($row.Timestamp, 'yyyy-MM-dd HH:mm:ss', $null)
        $trades[$tradeId] = @{
            EntryTime = $time
            EntryHour = $time.Hour
            ExitPnL = $null
        }
    }
    elseif ($row.Type -eq 'EXIT' -and $tradeId -gt 0) {
        $pnl = [double]$row.PnL
        $trades[$tradeId].ExitPnL = $pnl
    }
}

# Agrupar por hora de entrada
$hourStats = @{}

foreach ($trade in $trades.Values) {
    if ($trade.ExitPnL -ne $null) {
        $hour = $trade.EntryHour
        
        if (-not $hourStats.ContainsKey($hour)) {
            $hourStats[$hour] = @{
                Total = 0
                Wins = 0
                Losses = 0
            }
        }
        
        $hourStats[$hour].Total++
        
        if ($trade.ExitPnL -gt 0) {
            $hourStats[$hour].Wins++
        }
        elseif ($trade.ExitPnL -lt 0) {
            $hourStats[$hour].Losses++
        }
    }
}

Write-Host '===============================================' -ForegroundColor Cyan
Write-Host '  WINRATE POR HORA DE ENTRADA (UTC)' -ForegroundColor Yellow
Write-Host '===============================================' -ForegroundColor Cyan
Write-Host ''
Write-Host 'Hora  | Trades | Wins | Losses | Winrate | Calidad' -ForegroundColor Green
Write-Host '------|--------|------|--------|---------|--------' -ForegroundColor Gray

$results = @()

foreach ($hour in 0..23) {
    if ($hourStats.ContainsKey($hour)) {
        $stats = $hourStats[$hour]
        $total = $stats.Total
        $wins = $stats.Wins
        $losses = $stats.Losses
        
        if ($total -gt 0) {
            $winrate = [math]::Round(($wins / $total) * 100, 1)
        } else {
            $winrate = 0
        }
        
        # Determinar calidad
        $calidad = ''
        if ($total -ge 10) {
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
            Trades = $total
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

Write-Host 'TOP 10 MEJORES HORARIOS (por winrate):' -ForegroundColor Green
$results | Where-Object { $_.Trades -ge 10 } | Sort-Object Winrate -Descending | Select-Object -First 10 | ForEach-Object {
    $hourStr = $_.Hora.ToString().PadLeft(2, '0')
    Write-Host "  $hourStr`:00 UTC -> $($_.Trades) trades, $($_.Winrate)% winrate" -ForegroundColor Cyan
}

Write-Host ''
Write-Host 'TOP 10 PEORES HORARIOS (por winrate):' -ForegroundColor Red
$results | Where-Object { $_.Trades -ge 10 } | Sort-Object Winrate | Select-Object -First 10 | ForEach-Object {
    $hourStr = $_.Hora.ToString().PadLeft(2, '0')
    Write-Host "  $hourStr`:00 UTC -> $($_.Trades) trades, $($_.Winrate)% winrate" -ForegroundColor DarkYellow
}
