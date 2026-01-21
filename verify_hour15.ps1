# Verificar diferencia entre ENTRY y EXIT a las 15:00
$csv = Import-Csv 'C:\Users\PC\Documents\NinjaTrader 8\logs\MFSScalp\MFSScalp_TradeLog.csv'

# Contar ENTRIES vs EXITS a las 15:00
$hour15Entries = $csv | Where-Object { 
    $time = [DateTime]::ParseExact($_.Timestamp, 'yyyy-MM-dd HH:mm:ss', $null)
    $_.Type -eq 'ENTRY' -and $time.Hour -eq 15
}

$hour15Exits = $csv | Where-Object { 
    $time = [DateTime]::ParseExact($_.Timestamp, 'yyyy-MM-dd HH:mm:ss', $null)
    $_.Type -eq 'EXIT' -and $time.Hour -eq 15
}

Write-Host 'HORA 15:00 UTC:' -ForegroundColor Yellow
Write-Host "  Entries (senales generadas a las 15:00): $($hour15Entries.Count)"
Write-Host "  Exits (trades cerrados a las 15:00):     $($hour15Exits.Count)"
Write-Host ''
Write-Host 'NOTA: El winrate se calcula segun la HORA DE CIERRE del trade,' -ForegroundColor Yellow
Write-Host '      NO la hora de ENTRADA.' -ForegroundColor Yellow
Write-Host ''
Write-Host 'Por eso la hora 15:00 muestra 43.8% winrate (trades que se cerraron a las 15:00)' -ForegroundColor Cyan
Write-Host 'Pero tiene 394 entradas (senales que se generaron a las 15:00)' -ForegroundColor Cyan
