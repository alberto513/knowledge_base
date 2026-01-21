# Analisis completo de 150 dias - hora 15:00 UTC
$csv = Import-Csv 'C:\Users\PC\Documents\NinjaTrader 8\logs\MFSScalp\MFSScalp_TradeLog.csv'
$entries = $csv | Where-Object { $_.Type -eq 'ENTRY' }

# Filtrar solo hora 15:00 UTC
$hour15 = $entries | Where-Object { 
    $time = [DateTime]::ParseExact($_.Timestamp, 'yyyy-MM-dd HH:mm:ss', $null)
    $time.Hour -eq 15
}

# Calcular rango de fechas
$allDates = $entries | ForEach-Object {
    $time = [DateTime]::ParseExact($_.Timestamp, 'yyyy-MM-dd HH:mm:ss', $null)
    $time.Date
} | Sort-Object -Unique

$firstDate = $allDates | Select-Object -First 1
$lastDate = $allDates | Select-Object -Last 1
$totalDays = ($lastDate - $firstDate).Days + 1
$daysWithData = $allDates.Count

# Contar dias con actividad en hora 15
$diasCon15 = $hour15 | ForEach-Object {
    $time = [DateTime]::ParseExact($_.Timestamp, 'yyyy-MM-dd HH:mm:ss', $null)
    $time.Date
} | Select-Object -Unique

$totalTrades15 = $hour15.Count
$totalDiasCon15 = $diasCon15.Count

# Calcular promedios
$promedioPorDiaCalendario = if ($totalDays -gt 0) { [math]::Round($totalTrades15 / $totalDays, 2) } else { 0 }
$promedioPorDiaConActividad = if ($totalDiasCon15 -gt 0) { [math]::Round($totalTrades15 / $totalDiasCon15, 2) } else { 0 }

Write-Host '===============================================' -ForegroundColor Cyan
Write-Host '  ANALISIS HORA 15:00 UTC - 150 DIAS' -ForegroundColor Yellow
Write-Host '===============================================' -ForegroundColor Cyan
Write-Host ''
Write-Host 'RANGO DE FECHAS:' -ForegroundColor Green
Write-Host "  Primer trade:           $($firstDate.ToString('yyyy-MM-dd'))"
Write-Host "  Ultimo trade:           $($lastDate.ToString('yyyy-MM-dd'))"
Write-Host "  Dias calendario:        $totalDays"
Write-Host "  Dias con datos:         $daysWithData"
Write-Host ''
Write-Host 'ESTADISTICAS HORA 15:00 UTC:' -ForegroundColor Green
Write-Host "  Total trades a las 15:  $totalTrades15"
Write-Host "  Dias con trades a 15:   $totalDiasCon15"
Write-Host ''
Write-Host 'PROMEDIOS:' -ForegroundColor Magenta
Write-Host "  Por dia calendario:     $promedioPorDiaCalendario trades/dia"
Write-Host "  Por dia con actividad:  $promedioPorDiaConActividad trades/dia"
Write-Host ''
Write-Host 'TOTAL TRADES EN EL LOG:' -ForegroundColor Green
Write-Host "  Todas las horas:        $($entries.Count) trades"
Write-Host "  Promedio por dia:       $([math]::Round($entries.Count / $totalDays, 2)) trades/dia"
Write-Host ''
Write-Host 'DISTRIBUCION POR HORA (Top 10):' -ForegroundColor Green
$entries | ForEach-Object {
    $time = [DateTime]::ParseExact($_.Timestamp, 'yyyy-MM-dd HH:mm:ss', $null)
    $time.Hour
} | Group-Object | Sort-Object Count -Descending | Select-Object -First 10 | ForEach-Object {
    $hora = $_.Name.PadLeft(2, '0')
    $count = $_.Count
    $pct = [math]::Round(($count / $entries.Count) * 100, 1)
    Write-Host "  Hora $hora`:00 UTC: $count trades ($pct%)"
}
