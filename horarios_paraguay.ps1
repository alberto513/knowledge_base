# Convertir horarios UTC a hora de Paraguay (UTC-4)
$hourData = @(
    @{UTC=19; Trades=100; Wins=62; Losses=38; Winrate=62.0; Calidad='EXCELENTE'},
    @{UTC=3; Trades=81; Wins=46; Losses=35; Winrate=56.8; Calidad='MUY BUENO'},
    @{UTC=8; Trades=115; Wins=63; Losses=52; Winrate=54.8; Calidad='BUENO'},
    @{UTC=20; Trades=112; Wins=60; Losses=52; Winrate=53.6; Calidad='BUENO'},
    @{UTC=9; Trades=189; Wins=101; Losses=88; Winrate=53.4; Calidad='BUENO'},
    @{UTC=10; Trades=401; Wins=213; Losses=188; Winrate=53.1; Calidad='BUENO'},
    @{UTC=5; Trades=110; Wins=58; Losses=52; Winrate=52.7; Calidad='BUENO'},
    @{UTC=1; Trades=89; Wins=46; Losses=43; Winrate=51.7; Calidad='BUENO'},
    @{UTC=14; Trades=414; Wins=214; Losses=200; Winrate=51.7; Calidad='BUENO'},
    @{UTC=11; Trades=850; Wins=434; Losses=416; Winrate=51.1; Calidad='BUENO'},
    @{UTC=18; Trades=70; Wins=35; Losses=35; Winrate=50.0; Calidad='BUENO'},
    @{UTC=21; Trades=113; Wins=56; Losses=57; Winrate=49.6; Calidad='REGULAR'},
    @{UTC=4; Trades=132; Wins=65; Losses=67; Winrate=49.2; Calidad='REGULAR'},
    @{UTC=13; Trades=559; Wins=270; Losses=289; Winrate=48.3; Calidad='REGULAR'},
    @{UTC=12; Trades=825; Wins=397; Losses=428; Winrate=48.1; Calidad='REGULAR'},
    @{UTC=17; Trades=274; Wins=126; Losses=148; Winrate=46.0; Calidad='REGULAR'},
    @{UTC=16; Trades=363; Wins=167; Losses=196; Winrate=46.0; Calidad='REGULAR'},
    @{UTC=23; Trades=73; Wins=33; Losses=40; Winrate=45.2; Calidad='REGULAR'},
    @{UTC=22; Trades=85; Wins=38; Losses=47; Winrate=44.7; Calidad='MALO'},
    @{UTC=2; Trades=70; Wins=31; Losses=39; Winrate=44.3; Calidad='MALO'},
    @{UTC=15; Trades=394; Wins=171; Losses=223; Winrate=43.4; Calidad='MALO'},
    @{UTC=6; Trades=86; Wins=33; Losses=53; Winrate=38.4; Calidad='MALO'},
    @{UTC=0; Trades=69; Wins=26; Losses=43; Winrate=37.7; Calidad='MALO'},
    @{UTC=7; Trades=107; Wins=40; Losses=67; Winrate=37.4; Calidad='MALO'}
)

Write-Host '=================================================================' -ForegroundColor Cyan
Write-Host '  HORARIOS EN HORA DE PARAGUAY (UTC-4)' -ForegroundColor Yellow
Write-Host '=================================================================' -ForegroundColor Cyan
Write-Host ''
Write-Host 'UTC   | Paraguay | Trades | Wins | Losses | Winrate | Calidad' -ForegroundColor Green
Write-Host '------|----------|--------|------|--------|---------|--------' -ForegroundColor Gray

$hourData | Sort-Object Winrate -Descending | ForEach-Object {
    $utc = $_.UTC
    $py = $utc - 4
    if ($py -lt 0) { $py += 24 }
    
    $utcStr = $utc.ToString().PadLeft(2, '0')
    $pyStr = $py.ToString().PadLeft(2, '0')
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
    
    Write-Host "$utcStr`:00 | $pyStr`:00    |$tradesStr |$winsStr |$lossesStr | $winrateStr | $($_.Calidad)" -ForegroundColor $color
}

Write-Host ''
Write-Host 'MEJORES FRANJAS HORARIAS (Paraguay):' -ForegroundColor Green
Write-Host '  15:00 (19:00 UTC) -> 62.0% winrate' -ForegroundColor Cyan
Write-Host '  23:00 (03:00 UTC) -> 56.8% winrate' -ForegroundColor Cyan
Write-Host '  04:00-06:00 (08:00-10:00 UTC) -> 53-54% winrate' -ForegroundColor Cyan
Write-Host ''
Write-Host 'PEORES FRANJAS HORARIAS (Paraguay):' -ForegroundColor Red
Write-Host '  03:00 (07:00 UTC) -> 37.4% winrate' -ForegroundColor DarkYellow
Write-Host '  11:00 (15:00 UTC) -> 43.4% winrate' -ForegroundColor DarkYellow
Write-Host '  20:00 (00:00 UTC) -> 37.7% winrate' -ForegroundColor DarkYellow
