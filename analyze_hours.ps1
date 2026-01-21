# Analizar winrate por hora
$csv = Import-Csv "c:\Users\PC\Documents\NinjaTrader 8\logs\MFSScalp\MFSScalp_TradeLog.csv"

# Filtrar solo EXIT
$exits = $csv | Where-Object {$_.Type -eq 'EXIT'}

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
        'Winrate%' = $wr
    }
} | Sort-Object Hour

$hourStats | Format-Table -AutoSize

Write-Host "`nMejores Horarios (Winrate > 52%):" -ForegroundColor Green
$hourStats | Where-Object {$_.'Winrate%' -gt 52} | Format-Table -AutoSize

Write-Host "`nPeores Horarios (Winrate < 48%):" -ForegroundColor Red
$hourStats | Where-Object {$_.'Winrate%' -lt 48} | Format-Table -AutoSize
