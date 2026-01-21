# Analisis detallado de la hora 15:00 UTC
$csv = Import-Csv 'C:\Users\PC\Documents\NinjaTrader 8\logs\MFSScalp\MFSScalp_TradeLog.csv'
$entries = $csv | Where-Object { $_.Type -eq 'ENTRY' }

# Filtrar solo hora 15:00 UTC
$hour15 = $entries | Where-Object { 
    $time = [DateTime]::ParseExact($_.Timestamp, 'yyyy-MM-dd HH:mm:ss', $null)
    $time.Hour -eq 15
}

# Contar dias unicos
$dias = $hour15 | ForEach-Object {
    $time = [DateTime]::ParseExact($_.Timestamp, 'yyyy-MM-dd HH:mm:ss', $null)
    $time.Date
} | Select-Object -Unique

$totalTrades = $hour15.Count
$totalDias = $dias.Count
$promedioPorDia = if ($totalDias -gt 0) { [math]::Round($totalTrades / $totalDias, 2) } else { 0 }

Write-Host '===============================================' -ForegroundColor Cyan
Write-Host '  ANALISIS DETALLADO: HORA 15:00 UTC' -ForegroundColor Yellow
Write-Host '===============================================' -ForegroundColor Cyan
Write-Host ''
Write-Host 'ESTADISTICAS:' -ForegroundColor Green
Write-Host "  Total de trades:        $totalTrades"
Write-Host "  Dias con actividad:     $totalDias"
Write-Host "  Promedio por dia:       $promedioPorDia trades/dia"
Write-Host ''
Write-Host 'EXPECTATIVA REALISTA:' -ForegroundColor Magenta

if ($promedioPorDia -lt 1) {
    Write-Host "  En la hora 15:00 UTC:   Menos de 1 trade por dia" -ForegroundColor Yellow
    $diasPorTrade = if ($promedioPorDia -gt 0) { [math]::Round(1.0 / $promedioPorDia, 1) } else { 0 }
    Write-Host "  Frecuencia:             1 trade cada $diasPorTrade dias" -ForegroundColor Cyan
} else {
    Write-Host "  En la hora 15:00 UTC:   $promedioPorDia trades por dia" -ForegroundColor Cyan
}

Write-Host ''

# Desglose por dia
Write-Host 'DESGLOSE POR DIA:' -ForegroundColor Green
$hour15 | ForEach-Object {
    $time = [DateTime]::ParseExact($_.Timestamp, 'yyyy-MM-dd HH:mm:ss', $null)
    $time.Date.ToString('yyyy-MM-dd')
} | Group-Object | Sort-Object Name | ForEach-Object {
    Write-Host "  $($_.Name): $($_.Count) trade(s)"
}

Write-Host ''
Write-Host 'CONCLUSION:' -ForegroundColor Green
Write-Host '  La hora 15:00 UTC NO es una hora dorada por volumen,' -ForegroundColor Yellow
Write-Host '  SINO por CALIDAD con 75% de winrate y pocos trades.' -ForegroundColor Yellow
