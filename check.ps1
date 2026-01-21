$csv = Import-Csv "c:\Users\PC\Documents\NinjaTrader 8\logs\MFSScalp\MFSScalp_TradeLog.csv"
$ent = $csv | Where { $_.Type -eq "ENTRY" }
$ex = $csv | Where { $_.Type -eq "EXIT" }
$w = $ex | Where { $_.Direction -eq "WIN" }
$l = $ex | Where { $_.Direction -eq "LOSS" }

$pnl = 0
foreach ($e in $ex) { $pnl += [double]$e.PnL }

Write-Host "LOG REAL:"
Write-Host "Entries: $($ent.Count)"
Write-Host "Exits: $($ex.Count)"
Write-Host "Wins: $($w.Count)"
Write-Host "Losses: $($l.Count)"
Write-Host "Winrate: $([math]::Round(($w.Count / $ent.Count) * 100, 2))%"
Write-Host "PnL: $([math]::Round($pnl, 1)) ticks = $([math]::Round($pnl/4, 2)) puntos"
Write-Host ""
Write-Host "PANEL DICE:"
Write-Host "Trades: 285 | Wins: 157 | Losses: 128"
Write-Host "Winrate: 55.09%"
Write-Host "PnL: 1160.0 ticks = 290.00 puntos"
Write-Host ""
if ($ent.Count -eq 285) {
    Write-Host "CONFIRMADO!" -ForegroundColor Green
} else {
    Write-Host "NO COINCIDE" -ForegroundColor Red
}
