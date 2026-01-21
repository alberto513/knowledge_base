#region Using declarations
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Windows.Media;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.Tools;
using NinjaTrader.NinjaScript;
using NinjaTrader.NinjaScript.DrawingTools;
using FplemeIndicators = NinjaTrader.NinjaScript.Indicators._FPLEME_;
#endregion

namespace NinjaTrader.NinjaScript
{
	public enum ExternalInputMode
	{
		Integrated,
		Proxy
	}

	public enum ScenarioType
	{
		None,
		PPM,
		MM,
		Transition
	}

	public enum WallState
	{
		Unknown,
		Up,
		Down,
		Neutral
	}
}

namespace NinjaTrader.NinjaScript.Indicators
{
	public class MFSIndicator : Indicator
	{
		private enum BcrState
		{
			Idle = 0,
			Armed = 1,
			Confirmed = 2,
			Cooldown = 3
		}

		private enum ArState
		{
			Idle = 0,
			Armed = 1,
			Confirmed = 2,
			Cooldown = 3
		}

		private enum RmState
		{
			Idle = 0,
			Armed = 1,
			Confirmed = 2,
			Cooldown = 3
		}

		private enum PtState
		{
			Idle = 0,
			Armed = 1,
			Confirmed = 2,
			Cooldown = 3
		}

		private int lastProcessedBar = -1;
		private int closedBoxCount;
		private bool boxClosedConfirmed;
		private bool isRenkoSeries;
		private FplemeIndicators.MAPS_M7 mapsIndicator;
		private FplemeIndicators.VXM7 vxIndicator;
		private Series<double> vxIntegratedSeries;
		private Series<double> vxProxySeries;

		private double mapsMap0Integrated = double.NaN;
		private double mapsS1Integrated = double.NaN;
		private double mapsI1Integrated = double.NaN;
		private double mapsBandStepIntegrated = double.NaN;
		private double wallIntegrated = double.NaN;
		private double vxIntegrated = double.NaN;
		private double hertzIntegrated = double.NaN;

		private double mapsMap0Proxy = double.NaN;
		private double mapsS1Proxy = double.NaN;
		private double mapsI1Proxy = double.NaN;
		private double mapsBandStepProxy = double.NaN;
		private double wallProxy = double.NaN;
		private double vxProxy = double.NaN;
		private double hertzProxy = double.NaN;

		private double mapsMap0 = double.NaN;
		private double mapsS1 = double.NaN;
		private double mapsI1 = double.NaN;
		private double mapsBandStep = double.NaN;
		private double wallValue = double.NaN;
		private double vxValue = double.NaN;
		private double hertzValue = double.NaN;

		private int map0IntegratedLastChangeBar = -1;
		private int s1IntegratedLastChangeBar = -1;
		private int i1IntegratedLastChangeBar = -1;
		private int wallIntegratedLastChangeBar = -1;
		private int wallIntegratedCrossCount;
		private double lastMap0Integrated = double.NaN;
		private double lastS1Integrated = double.NaN;
		private double lastI1Integrated = double.NaN;
		private double lastWallIntegrated = double.NaN;

		private int hertzIntegratedLastChangeBar = -1;
		private double lastHertzIntegrated = double.NaN;
		private double hertzRangeAtLastChange = double.NaN;
		private int map0EffectiveLastChangeBar = -1;
		private int s1EffectiveLastChangeBar = -1;
		private int i1EffectiveLastChangeBar = -1;
		private double lastMap0Effective = double.NaN;
		private double lastS1Effective = double.NaN;
		private double lastI1Effective = double.NaN;

		private ExternalInputMode mapsEffectiveMode;
		private ExternalInputMode wallEffectiveMode;
		private ExternalInputMode vxEffectiveMode;
		private ExternalInputMode hertzEffectiveMode;

		private bool mapsIntegratedAvailable;
		private bool mapsIntegratedStale;
		private bool wallIntegratedAvailable;
		private bool wallIntegratedStale;
		private bool vxIntegratedAvailable;
		private bool vxIntegratedStale;
		private bool hertzIntegratedAvailable;
		private bool hertzIntegratedStale;

		private bool mapsAvailable;
		private bool wallAvailable;
		private bool vxAvailable;
		private bool hertzAvailable;
		private bool map0Stale;
		private bool mapIndexAvailable;
		private int mapIndexFull;
		private int mapZoneCompact;
		private int mapJumpCount;
		private bool mapJumpFlag;
		private Series<int> mapIndexFullSeries;
		private Series<int> mapZoneCompactSeries;
		private Series<int> mapJumpCountSeries;
		private ScenarioType scenarioType;
		private Series<int> scenarioTypeSeries;
		private int cycleRefMapIndex;
		private int cycle2MapIndex;
		private bool cycleRefValid;
		private bool cycle2Valid;
		private int cycleDirection;
		private int cycleRefBar = -1;
		private int cycle2Bar = -1;
		private bool transitionCandidate;
		private bool rangeActive;
		private Series<int> rangeActiveSeries;
		private int currentRenkoDirection;
		private double currentRunHigh = double.NaN;
		private double currentRunLow = double.NaN;
		private int currentRunStartBar = -1;
		private double lastSwingHighPrice = double.NaN;
		private double lastSwingLowPrice = double.NaN;
		private int lastSwingHighBar = -1;
		private int lastSwingLowBar = -1;
		private double prevSwingHighPrice = double.NaN;
		private double prevSwingLowPrice = double.NaN;
		private int prevSwingHighBar = -1;
		private int prevSwingLowBar = -1;
		private Series<double> swingHighSeries;
		private Series<double> swingLowSeries;
		private Series<int> swingHighConfirmSeries;
		private Series<int> swingLowConfirmSeries;
		private bool retestTracking;
		private int retestTargetIndex;
		private int retestDirection;
		private int retestStartBar = -1;
		private int retestBarsCount;
		private Series<int> retestActiveSeries;
		private Series<int> retestLevelSeries;
		private Series<int> retestDirectionSeries;
		private Series<int> retestBarsCountSeries;
		private Series<int> retestExpiredSeries;
		private Series<int> retestInvalidatedSeries;
		private WallState wallState;
		private Series<int> wallStateSeries;
		private Series<int> wallCrossSeries;
		private Series<int> wallAvailableSeries;
		private Series<double> wallEffectiveSeries;
		private Series<double> vxEffectiveSeries;
		private Series<int> vxIndexSeries;
		private Series<int> vxBreakSeries;
		private Series<int> vxFailBreakSeries;
		private Series<double> vxSlopeSeries;
		private double vxSlopeNormalized;
		private double[] vxAbsWorkBuffer;
		private int vxDirection;
		private double vxRunHigh = double.NaN;
		private double vxRunLow = double.NaN;
		private double lastVxSwingHigh = double.NaN;
		private double lastVxSwingLow = double.NaN;
		private int lastVxSwingHighBar = -1;
		private int lastVxSwingLowBar = -1;
		private double prevVxSwingHigh = double.NaN;
		private double prevVxSwingLow = double.NaN;
		private int prevVxSwingHighBar = -1;
		private int prevVxSwingLowBar = -1;
		private Series<double> vxSwingHighSeries;
		private Series<double> vxSwingLowSeries;
		private Series<int> vxSwingHighConfirmSeries;
		private Series<int> vxSwingLowConfirmSeries;
		private Series<int> vxDivergenceBullSeries;
		private Series<int> vxDivergenceBearSeries;
		private bool vxBreakTracking;
		private int vxBreakTargetIndex;
		private int vxBreakDirection;
		private int vxBreakStartBar = -1;
		private int vxBreakHoldCount;
		private BcrState bcrState;
		private int bcrDirection;
		private int bcrArmedBar = -1;
		private int bcrLastConfirmedBar = -1;
		private int bcrCooldownStartBar = -1;
		private int lastRetestBar = -1;
		private int lastRetestDirection;
		private int lastVxBreakBar = -1;
		private int lastVxBreakDirection;
		private Series<int> bcrStateSeries;
		private Series<int> bcrDirectionSeries;
		private Series<int> bcrArmedSeries;
		private Series<int> bcrConfirmedSeries;
		private Series<int> bcrInvalidatedSeries;
		private Series<int> bcrCooldownSeries;
		private Series<int> bcrScoreSeries;
		private string bcrReason = "BCR_NONE";
		private ArState arState;
		private int arDirection;
		private int arArmedBar = -1;
		private int arLastConfirmedBar = -1;
		private int arCooldownStartBar = -1;
		private int arLastExtremeDirection;
		private bool arExtremeReset = true;
		private Series<int> arStateSeries;
		private Series<int> arDirectionSeries;
		private Series<int> arArmedSeries;
		private Series<int> arConfirmedSeries;
		private Series<int> arInvalidatedSeries;
		private Series<int> arCooldownSeries;
		private Series<int> arScoreSeries;
		private string arReason = "AR_NONE";
		private RmState rmState;
		private int rmDirection;
		private int rmArmedBar = -1;
		private int rmLastConfirmedBar = -1;
		private int rmCooldownStartBar = -1;
		private Series<int> rmStateSeries;
		private Series<int> rmDirectionSeries;
		private Series<int> rmArmedSeries;
		private Series<int> rmConfirmedSeries;
		private Series<int> rmInvalidatedSeries;
		private Series<int> rmCooldownSeries;
		private Series<int> rmScoreSeries;
		private string rmReason = "RM_NONE";
		private PtState ptState;
		private int ptDirection;
		private int ptArmedBar = -1;
		private int ptLastConfirmedBar = -1;
		private int ptCooldownStartBar = -1;
		private int ptCycleCount;
		private int ptWallChangeBar = -1;
		private int ptLastCycleBar = -1;
		private Series<int> ptStateSeries;
		private Series<int> ptDirectionSeries;
		private Series<int> ptArmedSeries;
		private Series<int> ptConfirmedSeries;
		private Series<int> ptCooldownSeries;
		private Series<int> ptScoreSeries;
		private string ptReason = "PT_NONE";
		private const string PanelTagBcr = "LastSignalBCR";
		private const string PanelTagAr = "LastSignalAR";
		private const string PanelTagRm = "LastSignalRM";
		private const string PanelTagPt = "LastSignalPT";
		private const string PanelTagStats = "MFSStats";
		private int lastPanelSignalType;
		private int lastPanelSignalScore;
		private string lastPanelSignalTag;
		private SimpleFont panelFont;
		private int totalTrades;
		private int tradeWins;
		private int tradeLosses;
		private double totalPoints;
		private double lastSignalPrice;
		private int lastSignalDirection;
		private int lastSignalBar;
		private bool signalTracked;
		private double lastSignalTPPrice;
		private double lastSignalSLPrice;
		private double lastSignalHighestPrice;
		private double lastSignalLowestPrice;
		private string lastSignalType;
		private DateTime lastSignalEntryTime;
		private int arArmedMapIndex;
		private int rmArmedMapIndex;
		private string tradeLogFolder;
		private string tradeLogFileName;
		private StreamWriter tradeLogWriter;
		private string tradeLogPath;
		private string csvContextFolder;
		private string csvContextFileName;
		private bool csvContextOverwrite;
		private bool csvContextIncludeHeader;
		private StreamWriter csvContextWriter;
		private string csvContextPath;
		private bool csvContextHeaderWritten;
		private StreamWriter csvSignalWriter;
		private string csvSignalPath;
		private bool csvSignalHeaderWritten;

		private double[] mapProxyMidBuffer;
		private double[] mapProxySortBuffer;
		private int mapProxyCount;
		private int mapProxyIndex;

		protected override void OnStateChange()
		{
			if (State == State.SetDefaults)
			{
				Name = "MFSIndicator";
				Description = "Renko-only gating scaffold for MFS.";
				Calculate = Calculate.OnBarClose;
				IsOverlay = false;
				PaintPriceMarkers = false;
				IsSuspendedWhileInactive = true;

				MapsMode = ExternalInputMode.Integrated;
				WallMode = ExternalInputMode.Integrated;
				VxMode = ExternalInputMode.Integrated;
				HertzMode = ExternalInputMode.Integrated;

				MapProxyWindow = 40;
				Map0StaleBars = 50;
				Map0StaleRangeBands = 2;
				MapJumpPenaltyBands = 2;
				WallStaleBars = 50;
				WallCrossStaleThreshold = 2;
				HertzStaleBars = 50;
				VxAvailWindowBars = 10;
				RangeWindowBars = 20;
				RangeWallCrossMin = 2;
				RangeYellowMinBars = 10;
				VxSlopeFlatThreshold = 0.20;
				VxBreakConfirmBars = 2;
				RetestBars = 6;
				BcrTimeoutBars = 12;
				BcrCooldownBars = 10;
				ArTimeoutBars = 14;
				ArCooldownBars = 14;
				RmTimeoutBars = 10;
				RmCooldownBars = 8;
				PtTimeoutBars = 14;
				PtCooldownBars = 12;
				ScoreHQ = 75;
				ScoreLQ = 55;
				ScoreTieEpsilon = 2;
				ScenarioFallback = true;
				EnableLiteSignals = false;
				ArMaxZone = 3;
				TakeProfitTicks = 40;
				StopLossTicks = 40;
				UseTrailingStop = false;
				EnableTradeLog = true;
				TradeLogFolder = string.Empty;
				TradeLogFile = "MFS_TradeLog.csv";
				EnableCsvContext = false;
				DrawPtSignals = true;
				DrawRmSignals = true;
				DrawArSignals = true;
				DrawBcrSignals = true;
				CsvContextFolder = Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
					"MFS_Logs");
				CsvContextFileName = "MFS_Context.csv";
				CsvContextOverwrite = true;
				CsvContextIncludeHeader = true;
			}
			else if (State == State.DataLoaded)
			{
				closedBoxCount = 0;
				lastProcessedBar = -1;
				boxClosedConfirmed = false;

				string barsTypeName = (Bars != null && Bars.BarsType != null)
					? Bars.BarsType.GetType().Name
					: string.Empty;
				isRenkoSeries = barsTypeName.IndexOf("Renko", StringComparison.OrdinalIgnoreCase) >= 0 || barsTypeName.IndexOf("RENKOBRZ", StringComparison.OrdinalIgnoreCase) >= 0;

				vxIntegratedSeries = new Series<double>(this);
				vxProxySeries = new Series<double>(this);
				mapIndexFullSeries = new Series<int>(this);
				mapZoneCompactSeries = new Series<int>(this);
				mapJumpCountSeries = new Series<int>(this);
				scenarioTypeSeries = new Series<int>(this);
				rangeActiveSeries = new Series<int>(this);
				swingHighSeries = new Series<double>(this);
				swingLowSeries = new Series<double>(this);
				swingHighConfirmSeries = new Series<int>(this);
				swingLowConfirmSeries = new Series<int>(this);
				retestActiveSeries = new Series<int>(this);
				retestLevelSeries = new Series<int>(this);
				retestDirectionSeries = new Series<int>(this);
				retestBarsCountSeries = new Series<int>(this);
				retestExpiredSeries = new Series<int>(this);
				retestInvalidatedSeries = new Series<int>(this);
				wallStateSeries = new Series<int>(this);
				wallCrossSeries = new Series<int>(this);
				wallAvailableSeries = new Series<int>(this);
				wallEffectiveSeries = new Series<double>(this);
				vxEffectiveSeries = new Series<double>(this);
				vxIndexSeries = new Series<int>(this);
				vxBreakSeries = new Series<int>(this);
				vxFailBreakSeries = new Series<int>(this);
				vxSlopeSeries = new Series<double>(this);
				vxSwingHighSeries = new Series<double>(this);
				vxSwingLowSeries = new Series<double>(this);
				vxSwingHighConfirmSeries = new Series<int>(this);
				vxSwingLowConfirmSeries = new Series<int>(this);
				vxDivergenceBullSeries = new Series<int>(this);
				vxDivergenceBearSeries = new Series<int>(this);
				bcrStateSeries = new Series<int>(this);
				bcrDirectionSeries = new Series<int>(this);
				bcrArmedSeries = new Series<int>(this);
				bcrConfirmedSeries = new Series<int>(this);
				bcrInvalidatedSeries = new Series<int>(this);
				bcrCooldownSeries = new Series<int>(this);
				bcrScoreSeries = new Series<int>(this);
				arStateSeries = new Series<int>(this);
				arDirectionSeries = new Series<int>(this);
				arArmedSeries = new Series<int>(this);
				arConfirmedSeries = new Series<int>(this);
				arInvalidatedSeries = new Series<int>(this);
				arCooldownSeries = new Series<int>(this);
				arScoreSeries = new Series<int>(this);
				rmStateSeries = new Series<int>(this);
				rmDirectionSeries = new Series<int>(this);
				rmArmedSeries = new Series<int>(this);
				rmConfirmedSeries = new Series<int>(this);
				rmInvalidatedSeries = new Series<int>(this);
				rmCooldownSeries = new Series<int>(this);
				rmScoreSeries = new Series<int>(this);
				ptStateSeries = new Series<int>(this);
				ptDirectionSeries = new Series<int>(this);
				ptArmedSeries = new Series<int>(this);
				ptConfirmedSeries = new Series<int>(this);
				ptCooldownSeries = new Series<int>(this);
				ptScoreSeries = new Series<int>(this);
				vxAbsWorkBuffer = new double[Math.Max(1, VxAvailWindowBars)];
				scenarioType = ScenarioType.None;
				cycleRefValid = false;
				cycle2Valid = false;
				cycleDirection = 0;
				cycleRefBar = -1;
				cycle2Bar = -1;
				cycleRefMapIndex = 0;
				cycle2MapIndex = 0;
				transitionCandidate = false;
				bcrState = BcrState.Idle;
				bcrDirection = 0;
				arState = ArState.Idle;
				arDirection = 0;
				arLastExtremeDirection = 0;
				arExtremeReset = true;
				rmState = RmState.Idle;
				rmDirection = 0;
				ptState = PtState.Idle;
				ptDirection = 0;
				ptCycleCount = 0;
				ptWallChangeBar = -1;
				ptLastCycleBar = -1;
				lastPanelSignalType = 0;
				lastPanelSignalScore = 0;
				lastPanelSignalTag = string.Empty;
				panelFont = new SimpleFont("Arial", 12);
				totalTrades = 0;
				tradeWins = 0;
				tradeLosses = 0;
				totalPoints = 0.0;
				lastSignalPrice = double.NaN;
				lastSignalDirection = 0;
				lastSignalBar = -1;
				signalTracked = false;
				mapProxyCount = 0;
				mapProxyIndex = 0;
				mapProxyMidBuffer = new double[Math.Max(1, MapProxyWindow)];
				mapProxySortBuffer = new double[Math.Max(1, MapProxyWindow)];
				InitializeExternalIndicators();
				InitializeCsvContext();
				InitializeTradeLog();
			}
			else if (State == State.Terminated)
			{
				FinalizeCsvContext();
				FinalizeTradeLog();
			}
		}

		protected override void OnBarUpdate()
		{
			if (BarsInProgress != 0)
				return;

			if (!isRenkoSeries)
				return;

			if (CurrentBar <= lastProcessedBar)
				return;

			lastProcessedBar = CurrentBar;
			closedBoxCount++;
			boxClosedConfirmed = true;

			UpdateIntegratedInputs();
			UpdateProxyInputs();
			UpdateAvailabilityAndModes();
			UpdateEffectiveMapChangeBars();
			UpdateMapIndex();
			UpdateWallStateAndCross();
			UpdateVxState();
			UpdateRangeActive();
			UpdateSwingsRenko();
			UpdateVxDivergence();
			UpdateCycleEngine();
			UpdateScenarioType();
			UpdateRetestState();
			UpdateBcrState();
			UpdateArState();
			UpdateRmState();
			UpdatePtState();
			UpdateVisualSignals();
			UpdateTradeStats();
			DrawTextFixedPanel();
			DrawStatsPanel();
			WriteCsvContextRow();
			WriteCsvSignalRow();
		}

		private void InitializeExternalIndicators()
		{
			mapsIndicator = null;
			vxIndicator = null;

			if (MapsMode == ExternalInputMode.Integrated || WallMode == ExternalInputMode.Integrated)
				mapsIndicator = MAPS_M7(false, false, true, true, false, false);

			if (VxMode == ExternalInputMode.Integrated)
				vxIndicator = VXM7(true, false, false);
		}

		private void UpdateIntegratedInputs()
		{
			mapsMap0Integrated = double.NaN;
			mapsS1Integrated = double.NaN;
			mapsI1Integrated = double.NaN;
			mapsBandStepIntegrated = double.NaN;
			wallIntegrated = double.NaN;
			vxIntegrated = double.NaN;
			hertzIntegrated = double.NaN;

			if (mapsIndicator != null)
			{
				mapsMap0Integrated = mapsIndicator.M0[0];
				mapsS1Integrated = mapsIndicator.S1[0];
				mapsI1Integrated = mapsIndicator.I1[0];
				wallIntegrated = mapsIndicator.TW[0];
			}

			if (HasValue(mapsMap0Integrated) && HasValue(mapsS1Integrated))
				mapsBandStepIntegrated = Math.Abs(mapsS1Integrated - mapsMap0Integrated);

			if (vxIndicator != null)
				vxIntegrated = vxIndicator[0];

			vxIntegratedSeries[0] = vxIntegrated;

			UpdateWallChangeAndCross();
			UpdateChangeBar(ref lastMap0Integrated, mapsMap0Integrated, ref map0IntegratedLastChangeBar);
			UpdateChangeBar(ref lastS1Integrated, mapsS1Integrated, ref s1IntegratedLastChangeBar);
			UpdateChangeBar(ref lastI1Integrated, mapsI1Integrated, ref i1IntegratedLastChangeBar);
			UpdateHertzChange();
		}

		private void UpdateProxyInputs()
		{
			int window = Math.Max(1, MapProxyWindow);
			double midPrice = (High[0] + Low[0]) * 0.5;
			mapProxyMidBuffer[mapProxyIndex] = midPrice;
			mapProxyIndex = (mapProxyIndex + 1) % window;
			mapProxyCount = Math.Min(window, mapProxyCount + 1);

			mapsMap0Proxy = ComputeMedian(mapProxyMidBuffer, mapProxyCount, mapProxySortBuffer);
			mapsBandStepProxy = ComputeProxyBandStep(mapsMap0Proxy, window);
			mapsS1Proxy = HasValue(mapsMap0Proxy) ? mapsMap0Proxy + mapsBandStepProxy : double.NaN;
			mapsI1Proxy = HasValue(mapsMap0Proxy) ? mapsMap0Proxy - mapsBandStepProxy : double.NaN;

			wallProxy = HasValue(mapsMap0Proxy) ? Close[0] - mapsMap0Proxy : double.NaN;
			vxProxy = HasValue(mapsMap0Proxy) ? Close[0] - mapsMap0Proxy : double.NaN;
			hertzProxy = ComputeWindowRange(window);

			vxProxySeries[0] = vxProxy;
		}

		private void UpdateAvailabilityAndModes()
		{
			mapsIntegratedStale = EvaluateMapsStale(
				mapsMap0Integrated,
				mapsS1Integrated,
				mapsI1Integrated,
				mapsBandStepIntegrated,
				map0IntegratedLastChangeBar,
				s1IntegratedLastChangeBar,
				i1IntegratedLastChangeBar);
			mapsIntegratedAvailable = HasValue(mapsMap0Integrated)
				&& HasValue(mapsS1Integrated)
				&& HasValue(mapsI1Integrated)
				&& mapsBandStepIntegrated > 0
				&& !mapsIntegratedStale;

			wallIntegratedStale = EvaluateWallStale(wallIntegrated, wallIntegratedLastChangeBar, wallIntegratedCrossCount);
			wallIntegratedAvailable = HasValue(wallIntegrated) && !wallIntegratedStale;

			vxIntegratedStale = !EvaluateVxAvailable(vxIntegratedSeries);
			vxIntegratedAvailable = !vxIntegratedStale;

			hertzIntegratedStale = !EvaluateHertzAvailable(hertzIntegrated, hertzIntegratedLastChangeBar);
			hertzIntegratedAvailable = !hertzIntegratedStale;

			mapsEffectiveMode = SelectEffectiveMode(MapsMode, mapsIntegratedAvailable);
			wallEffectiveMode = SelectEffectiveMode(WallMode, wallIntegratedAvailable);
			vxEffectiveMode = SelectEffectiveMode(VxMode, vxIntegratedAvailable);
			hertzEffectiveMode = SelectEffectiveMode(HertzMode, hertzIntegratedAvailable);

			if (mapsEffectiveMode == ExternalInputMode.Integrated)
			{
				mapsMap0 = mapsMap0Integrated;
				mapsS1 = mapsS1Integrated;
				mapsI1 = mapsI1Integrated;
				mapsBandStep = mapsBandStepIntegrated;
				mapsAvailable = mapsIntegratedAvailable;
			}
			else
			{
				mapsMap0 = mapsMap0Proxy;
				mapsS1 = mapsS1Proxy;
				mapsI1 = mapsI1Proxy;
				mapsBandStep = mapsBandStepProxy;
				mapsAvailable = HasValue(mapsMap0Proxy) && mapsBandStepProxy > 0;
			}

			if (wallEffectiveMode == ExternalInputMode.Integrated)
			{
				wallValue = wallIntegrated;
				wallAvailable = wallIntegratedAvailable;
			}
			else
			{
				wallValue = wallProxy;
				wallAvailable = HasValue(wallProxy);
			}

			if (vxEffectiveMode == ExternalInputMode.Integrated)
			{
				vxValue = vxIntegrated;
				vxAvailable = vxIntegratedAvailable;
			}
			else
			{
				vxValue = vxProxy;
				vxAvailable = EvaluateVxAvailable(vxProxySeries);
			}

			if (hertzEffectiveMode == ExternalInputMode.Integrated)
			{
				hertzValue = hertzIntegrated;
				hertzAvailable = hertzIntegratedAvailable;
			}
			else
			{
				hertzValue = hertzProxy;
				hertzAvailable = HasValue(hertzProxy) && hertzProxy > 0;
			}
		}

		private void UpdateWallChangeAndCross()
		{
			if (!HasValue(wallIntegrated))
				return;

			if (double.IsNaN(wallIntegrated) || double.IsNaN(mapsMap0Integrated))
				return;

			bool wallChanged = !HasValue(lastWallIntegrated) || wallIntegrated != lastWallIntegrated;
			if (wallChanged)
			{
				lastWallIntegrated = wallIntegrated;
				wallIntegratedLastChangeBar = CurrentBar;
				wallIntegratedCrossCount = 0;
			}

			if (CurrentBar < 1 || double.IsNaN(lastMap0Integrated))
				return;

			double prevSide = Close[1] - lastMap0Integrated;
			double currSide = Close[0] - mapsMap0Integrated;
			bool crossed = (prevSide <= 0 && currSide > 0) || (prevSide >= 0 && currSide < 0);
			if (crossed && !wallChanged)
				wallIntegratedCrossCount++;
		}

		private void UpdateHertzChange()
		{
			if (!HasValue(hertzIntegrated))
				return;

			if (!HasValue(lastHertzIntegrated) || hertzIntegrated != lastHertzIntegrated)
			{
				lastHertzIntegrated = hertzIntegrated;
				hertzIntegratedLastChangeBar = CurrentBar;
				hertzRangeAtLastChange = ComputeWindowRange(HertzStaleBars);
			}
		}

		private void UpdateEffectiveMapChangeBars()
		{
			UpdateChangeBar(ref lastMap0Effective, mapsMap0, ref map0EffectiveLastChangeBar);
			UpdateChangeBar(ref lastS1Effective, mapsS1, ref s1EffectiveLastChangeBar);
			UpdateChangeBar(ref lastI1Effective, mapsI1, ref i1EffectiveLastChangeBar);
		}

		private void UpdateMapIndex()
		{
			map0Stale = EvaluateMapsStale(
				mapsMap0,
				mapsS1,
				mapsI1,
				mapsBandStep,
				map0EffectiveLastChangeBar,
				s1EffectiveLastChangeBar,
				i1EffectiveLastChangeBar);

			if (map0Stale)
			{
				mapIndexAvailable = false;
				mapIndexFull = 0;
				mapZoneCompact = 0;
				mapJumpCount = 0;
				mapJumpFlag = false;
				mapIndexFullSeries[0] = mapIndexFull;
				mapZoneCompactSeries[0] = mapZoneCompact;
				mapJumpCountSeries[0] = mapJumpCount;
				return;
			}

			mapIndexAvailable = true;
			mapIndexFull = ComputeMapIndexFull(Close[0], mapsMap0, mapsBandStep);
			mapZoneCompact = ClampMapZone(mapIndexFull);
			mapJumpCount = ComputeMapJumpCount(High[0], Low[0], mapsMap0, mapsBandStep);
			mapJumpFlag = MapJumpPenaltyBands > 0 && mapJumpCount >= MapJumpPenaltyBands;
			mapIndexFullSeries[0] = mapIndexFull;
			mapZoneCompactSeries[0] = mapZoneCompact;
			mapJumpCountSeries[0] = mapJumpCount;
		}

		private void UpdateCycleEngine()
		{
			// Reset if no MAP data
			if (!mapIndexAvailable)
			{
				cycleRefValid = false;
				cycle2Valid = false;
				cycleDirection = 0;
				return;
			}

			// FILOSOFÍA FPLEME: Los ciclos se basan en swings de precio en Renko.
			// - CycleRef = primer swing confirmado (establece la dirección del ciclo)
			// - Cycle2 = segundo swing del MISMO TIPO que CycleRef (confirma el ciclo completo)
			// - Un nuevo swing OPUESTO inicia un nuevo ciclo solo si Cycle2 ya está establecido
			
			// Detectar swing HIGH confirmado
			if (swingHighConfirmSeries[0] == 1 && CurrentBar > 0)
			{
				int swingMapIndex = mapIndexFullSeries[1];
				
				// Caso 1: No hay CycleRef → establecer CycleRef como HIGH (dirección bajista)
				if (!cycleRefValid)
				{
					cycleRefValid = true;
					cycleRefBar = CurrentBar - 1;
					cycleRefMapIndex = swingMapIndex;
					cycle2Valid = false;
					cycleDirection = -1; // HIGH = inicio de movimiento bajista
				}
				// Caso 2: CycleRef es HIGH y no hay Cycle2 → establecer Cycle2
				else if (cycleDirection < 0 && !cycle2Valid)
				{
					cycle2Valid = true;
					cycle2Bar = CurrentBar - 1;
					cycle2MapIndex = swingMapIndex;
				}
				// Caso 3: CycleRef es LOW y Cycle2 está establecido → nuevo ciclo bajista
				else if (cycleDirection > 0 && cycle2Valid)
				{
					cycleRefValid = true;
					cycleRefBar = CurrentBar - 1;
					cycleRefMapIndex = swingMapIndex;
					cycle2Valid = false;
					cycleDirection = -1;
				}
			}

			// Detectar swing LOW confirmado
			if (swingLowConfirmSeries[0] == 1 && CurrentBar > 0)
			{
				int swingMapIndex = mapIndexFullSeries[1];
				
				// Caso 1: No hay CycleRef → establecer CycleRef como LOW (dirección alcista)
				if (!cycleRefValid)
				{
					cycleRefValid = true;
					cycleRefBar = CurrentBar - 1;
					cycleRefMapIndex = swingMapIndex;
					cycle2Valid = false;
					cycleDirection = 1; // LOW = inicio de movimiento alcista
				}
				// Caso 2: CycleRef es LOW y no hay Cycle2 → establecer Cycle2
				else if (cycleDirection > 0 && !cycle2Valid)
				{
					cycle2Valid = true;
					cycle2Bar = CurrentBar - 1;
					cycle2MapIndex = swingMapIndex;
				}
				// Caso 3: CycleRef es HIGH y Cycle2 está establecido → nuevo ciclo alcista
				else if (cycleDirection < 0 && cycle2Valid)
				{
					cycleRefValid = true;
					cycleRefBar = CurrentBar - 1;
					cycleRefMapIndex = swingMapIndex;
					cycle2Valid = false;
					cycleDirection = 1;
				}
			}

			// Detectar candidato a Transición (Wall neutral con múltiples cruces)
			if (wallAvailable && wallState == WallState.Neutral)
			{
				int wallCrossCount = 0;
				for (int i = 0; i < Math.Min(RangeWindowBars, CurrentBar + 1); i++)
				{
					if (wallCrossSeries[i] == 1)
						wallCrossCount++;
				}
				transitionCandidate = wallCrossCount >= RangeWallCrossMin;
			}
			else
			{
				transitionCandidate = false;
			}
		}

		private void UpdateScenarioType()
		{
			// Verificar disponibilidad de MAP
			if (!mapIndexAvailable)
			{
				scenarioType = ScenarioType.None;
				scenarioTypeSeries[0] = (int)scenarioType;
				return;
			}

			// FILOSOFÍA FPLEME: Los escenarios se basan en el PROGRESO en MAP entre ciclos.
			// - PPM (Progreso Por MAP) = Cycle2 está en MAP más alta/baja que CycleRef → tendencia clara
			// - MM (Mismo MAP) = Cycle2 está en la misma MAP que CycleRef → mercado lateral/congestión
			// - Transition = Wall neutral con múltiples cruces → mercado indeciso
			
			// Fallback: Si tenemos CycleRef pero no Cycle2, clasificar basándose en contexto actual
			if (ScenarioFallback && cycleRefValid && (!cycle2Valid || cycleDirection == 0))
			{
				// Prioridad 1: Transición si hay múltiples cruces de Wall
				if (transitionCandidate)
				{
					scenarioType = ScenarioType.Transition;
				}
				// Prioridad 2: MM si Wall neutral y precio cerca de MAP0
				else if (wallAvailable && wallState == WallState.Neutral && (rangeActive || Math.Abs(mapZoneCompact) <= 1))
				{
					scenarioType = ScenarioType.MM;
				}
				// Por defecto: PPM (asumimos tendencia hasta que se demuestre lo contrario)
				else
				{
					scenarioType = ScenarioType.PPM;
				}

				scenarioTypeSeries[0] = (int)scenarioType;
				return;
			}

			// Si no hay ciclo completo (CycleRef + Cycle2), no podemos clasificar
			if (!cycleRefValid || !cycle2Valid || cycleDirection == 0)
			{
				scenarioType = ScenarioType.None;
				scenarioTypeSeries[0] = (int)scenarioType;
				return;
			}

			// Clasificación basada en progreso en MAP
			// MM: Cycle2 en la misma MAP que CycleRef → mercado lateral
			if (cycle2MapIndex == cycleRefMapIndex)
			{
				scenarioType = ScenarioType.MM;
			}
			// PPM: Cycle2 progresa en la dirección del ciclo → tendencia
			else if ((cycleDirection > 0 && cycle2MapIndex > cycleRefMapIndex)
				|| (cycleDirection < 0 && cycle2MapIndex < cycleRefMapIndex))
			{
				scenarioType = ScenarioType.PPM;
			}
			// Transition: Wall neutral con cruces frecuentes
			else if (transitionCandidate)
			{
				scenarioType = ScenarioType.Transition;
			}
			// Ninguno: no cumple criterios
			else
			{
				scenarioType = ScenarioType.None;
			}

			scenarioTypeSeries[0] = (int)scenarioType;
		}

		private void UpdateWallStateAndCross()
		{
			wallState = WallState.Unknown;
			wallEffectiveSeries[0] = wallValue;
			wallAvailableSeries[0] = wallAvailable ? 1 : 0;

			if (!wallAvailable || !HasValue(wallValue) || CurrentBar < 1)
			{
				wallStateSeries[0] = (int)wallState;
				wallCrossSeries[0] = 0;
				return;
			}

			double prevWall = wallEffectiveSeries[1];
			if (!HasValue(prevWall))
			{
				wallStateSeries[0] = (int)wallState;
				wallCrossSeries[0] = 0;
				return;
			}

			double slope = wallValue - prevWall;
			if (slope > 0)
				wallState = WallState.Up;
			else if (slope < 0)
				wallState = WallState.Down;
			else
				wallState = WallState.Neutral;

			wallStateSeries[0] = (int)wallState;

			if (wallAvailableSeries[1] == 1)
			{
				double prevSide = Close[1] - prevWall;
				double currSide = Close[0] - wallValue;
				bool crossed = (prevSide <= 0 && currSide > 0) || (prevSide >= 0 && currSide < 0);
				wallCrossSeries[0] = crossed ? 1 : 0;
			}
			else
			{
				wallCrossSeries[0] = 0;
			}
		}

		private void UpdateVxState()
		{
			vxEffectiveSeries[0] = vxValue;
			vxSlopeNormalized = 0.0;
			vxSlopeSeries[0] = 0.0;
			vxIndexSeries[0] = 0;
			vxBreakSeries[0] = 0;
			vxFailBreakSeries[0] = 0;
			vxSwingHighConfirmSeries[0] = 0;
			vxSwingLowConfirmSeries[0] = 0;
			vxSwingHighSeries[0] = lastVxSwingHigh;
			vxSwingLowSeries[0] = lastVxSwingLow;

			if (!vxAvailable || !HasValue(vxValue))
			{
				vxBreakTracking = false;
				vxBreakHoldCount = 0;
				vxBreakDirection = 0;
				vxBreakTargetIndex = 0;
				return;
			}

			int window = Math.Max(2, VxAvailWindowBars);
			if (CurrentBar >= window - 1)
			{
				double start = vxEffectiveSeries[window - 1];
				double end = vxEffectiveSeries[0];
				if (HasValue(start) && HasValue(end))
				{
					double slope = (end - start) / (window - 1);
					double medianAbs = ComputeMedianAbs(vxEffectiveSeries, window, vxAbsWorkBuffer);
					vxSlopeNormalized = (medianAbs > 0) ? (slope / medianAbs) : 0.0;
					vxSlopeSeries[0] = vxSlopeNormalized;
				}
			}

			if (mapIndexAvailable && mapsBandStep > 0)
				vxIndexSeries[0] = ComputeMapIndexFull(vxValue, 0.0, mapsBandStep);

			UpdateVxSwings();
			UpdateVxBreakState();
		}

		private void UpdateVxSwings()
		{
			if (CurrentBar < 1)
				return;

			double prevVx = vxEffectiveSeries[1];
			if (!HasValue(prevVx) || !HasValue(vxValue))
				return;

			double delta = vxValue - prevVx;
			int direction = delta > 0 ? 1 : (delta < 0 ? -1 : 0);
			if (direction == 0)
				return;

			if (vxDirection == 0)
			{
				vxDirection = direction;
				vxRunHigh = vxValue;
				vxRunLow = vxValue;
				return;
			}

			if (direction == vxDirection)
			{
				if (direction > 0)
					vxRunHigh = Math.Max(vxRunHigh, vxValue);
				else
					vxRunLow = Math.Min(vxRunLow, vxValue);
				return;
			}

			if (vxDirection > 0)
			{
				prevVxSwingHigh = lastVxSwingHigh;
				prevVxSwingHighBar = lastVxSwingHighBar;
				lastVxSwingHigh = vxRunHigh;
				lastVxSwingHighBar = CurrentBar - 1;
				vxSwingHighConfirmSeries[0] = 1;
			}
			else
			{
				prevVxSwingLow = lastVxSwingLow;
				prevVxSwingLowBar = lastVxSwingLowBar;
				lastVxSwingLow = vxRunLow;
				lastVxSwingLowBar = CurrentBar - 1;
				vxSwingLowConfirmSeries[0] = 1;
			}

			vxDirection = direction;
			vxRunHigh = vxValue;
			vxRunLow = vxValue;
			vxSwingHighSeries[0] = lastVxSwingHigh;
			vxSwingLowSeries[0] = lastVxSwingLow;
		}

		private void UpdateVxBreakState()
		{
			if (!vxAvailable || !mapIndexAvailable || mapsBandStep <= 0)
			{
				vxBreakTracking = false;
				vxBreakHoldCount = 0;
				vxBreakDirection = 0;
				vxBreakTargetIndex = 0;
				return;
			}

			int confirmBars = Math.Max(1, VxBreakConfirmBars);

			if (!vxBreakTracking)
			{
				if (CurrentBar < 1)
					return;

				int prevIndex = vxIndexSeries[1];
				int currIndex = vxIndexSeries[0];
				if (currIndex == prevIndex)
					return;

				vxBreakTracking = true;
				vxBreakDirection = currIndex > prevIndex ? 1 : -1;
				vxBreakTargetIndex = currIndex;
				vxBreakHoldCount = 0;
				vxBreakStartBar = CurrentBar;
			}

			if (!vxBreakTracking)
				return;

			if (vxBreakDirection > 0)
			{
				if (vxIndexSeries[0] >= vxBreakTargetIndex)
					vxBreakHoldCount++;
			}
			else
			{
				if (vxIndexSeries[0] <= vxBreakTargetIndex)
					vxBreakHoldCount++;
			}

			bool swingConfirmed = (vxBreakDirection > 0 && vxSwingHighConfirmSeries[0] == 1)
				|| (vxBreakDirection < 0 && vxSwingLowConfirmSeries[0] == 1);

			if (!swingConfirmed)
				return;

			if (vxBreakHoldCount >= confirmBars)
				vxBreakSeries[0] = 1;
			else
				vxFailBreakSeries[0] = 1;

			vxBreakTracking = false;
			vxBreakHoldCount = 0;
			vxBreakDirection = 0;
			vxBreakTargetIndex = 0;
			vxBreakStartBar = -1;
		}

		private void UpdateVxDivergence()
		{
			vxDivergenceBullSeries[0] = 0;
			vxDivergenceBearSeries[0] = 0;

			if (!vxAvailable)
				return;

			bool priceHighReady = HasValue(lastSwingHighPrice) && HasValue(prevSwingHighPrice)
				&& lastSwingHighBar >= 0 && prevSwingHighBar >= 0;
			bool priceLowReady = HasValue(lastSwingLowPrice) && HasValue(prevSwingLowPrice)
				&& lastSwingLowBar >= 0 && prevSwingLowBar >= 0;
			bool vxHighReady = HasValue(lastVxSwingHigh) && HasValue(prevVxSwingHigh)
				&& lastVxSwingHighBar >= 0 && prevVxSwingHighBar >= 0;
			bool vxLowReady = HasValue(lastVxSwingLow) && HasValue(prevVxSwingLow)
				&& lastVxSwingLowBar >= 0 && prevVxSwingLowBar >= 0;

			bool newHighEvent = swingHighConfirmSeries[0] == 1 || vxSwingHighConfirmSeries[0] == 1;
			bool newLowEvent = swingLowConfirmSeries[0] == 1 || vxSwingLowConfirmSeries[0] == 1;

			if (newHighEvent && priceHighReady && vxHighReady)
			{
				bool priceHigherHigh = lastSwingHighPrice > prevSwingHighPrice;
				bool vxLowerHigh = lastVxSwingHigh < prevVxSwingHigh;
				if (priceHigherHigh && vxLowerHigh)
					vxDivergenceBearSeries[0] = 1;
			}

			if (newLowEvent && priceLowReady && vxLowReady)
			{
				bool priceLowerLow = lastSwingLowPrice < prevSwingLowPrice;
				bool vxHigherLow = lastVxSwingLow > prevVxSwingLow;
				if (priceLowerLow && vxHigherLow)
					vxDivergenceBullSeries[0] = 1;
			}
		}

		private void UpdateRangeActive()
		{
			rangeActive = false;
			rangeActiveSeries[0] = 0;

			if (!mapIndexAvailable || !vxAvailable || !wallAvailable)
				return;

			int window = Math.Max(1, RangeWindowBars);
			if (CurrentBar < window - 1)
				return;

			int rangeStartIndex = mapIndexFullSeries[window - 1];
			bool noProgress = Math.Abs(mapIndexFull - rangeStartIndex) <= 1;

			int wallCrossCount = 0;
			int yellowCount = 0;
			int vxBreakCount = 0;
			for (int i = 0; i < window; i++)
			{
				if (wallCrossSeries[i] == 1)
					wallCrossCount++;
				if (wallAvailableSeries[i] == 1 && wallStateSeries[i] == (int)WallState.Neutral)
					yellowCount++;
				if (vxBreakSeries[i] == 1)
					vxBreakCount++;
			}

			bool wallOk = wallCrossCount >= RangeWallCrossMin || yellowCount >= RangeYellowMinBars;
			bool vxOk = vxBreakCount == 0 && Math.Abs(vxSlopeSeries[0]) <= VxSlopeFlatThreshold;
			rangeActive = noProgress && wallOk && vxOk;
			rangeActiveSeries[0] = rangeActive ? 1 : 0;
		}

		private void UpdateSwingsRenko()
		{
			swingHighConfirmSeries[0] = 0;
			swingLowConfirmSeries[0] = 0;

			if (CurrentBar < 1)
			{
				swingHighSeries[0] = lastSwingHighPrice;
				swingLowSeries[0] = lastSwingLowPrice;
				return;
			}

			int barDirection = GetRenkoBarDirection();
			if (barDirection == 0)
			{
				swingHighSeries[0] = lastSwingHighPrice;
				swingLowSeries[0] = lastSwingLowPrice;
				return;
			}

			if (currentRenkoDirection == 0)
			{
				currentRenkoDirection = barDirection;
				currentRunStartBar = CurrentBar;
				currentRunHigh = High[0];
				currentRunLow = Low[0];
				swingHighSeries[0] = lastSwingHighPrice;
				swingLowSeries[0] = lastSwingLowPrice;
				return;
			}

			if (barDirection == currentRenkoDirection)
			{
				if (barDirection > 0)
					currentRunHigh = Math.Max(currentRunHigh, High[0]);
				else
					currentRunLow = Math.Min(currentRunLow, Low[0]);

				swingHighSeries[0] = lastSwingHighPrice;
				swingLowSeries[0] = lastSwingLowPrice;
				return;
			}

			if (currentRenkoDirection > 0)
			{
				prevSwingHighPrice = lastSwingHighPrice;
				prevSwingHighBar = lastSwingHighBar;
				lastSwingHighPrice = currentRunHigh;
				lastSwingHighBar = CurrentBar - 1;
				swingHighConfirmSeries[0] = 1;
			}
			else
			{
				prevSwingLowPrice = lastSwingLowPrice;
				prevSwingLowBar = lastSwingLowBar;
				lastSwingLowPrice = currentRunLow;
				lastSwingLowBar = CurrentBar - 1;
				swingLowConfirmSeries[0] = 1;
			}

			currentRenkoDirection = barDirection;
			currentRunStartBar = CurrentBar;
			currentRunHigh = High[0];
			currentRunLow = Low[0];
			swingHighSeries[0] = lastSwingHighPrice;
			swingLowSeries[0] = lastSwingLowPrice;
		}

		private void UpdateRetestState()
		{
			retestActiveSeries[0] = 0;
			retestExpiredSeries[0] = 0;
			retestInvalidatedSeries[0] = 0;
			retestLevelSeries[0] = 0;
			retestDirectionSeries[0] = 0;
			retestBarsCountSeries[0] = 0;

			if (!mapIndexAvailable)
			{
				retestTracking = false;
				retestTargetIndex = 0;
				retestDirection = 0;
				retestBarsCount = 0;
				return;
			}

			if (map0Stale)
			{
				if (retestTracking)
					retestInvalidatedSeries[0] = 1;
				retestTracking = false;
				retestTargetIndex = 0;
				retestDirection = 0;
				retestBarsCount = 0;
				return;
			}

			if (!retestTracking)
			{
				if (CurrentBar < 1)
					return;

				int prevIndex = mapIndexFullSeries[1];
				if (prevIndex == mapIndexFull)
					return;

				int direction = mapIndexFull > prevIndex ? 1 : -1;
				if (direction > 0 && lastSwingLowBar < 0)
					return;
				if (direction < 0 && lastSwingHighBar < 0)
					return;

				int targetIndex = direction > 0 ? mapIndexFull - 1 : mapIndexFull + 1;
				retestTracking = true;
				retestTargetIndex = targetIndex;
				retestDirection = direction;
				retestStartBar = CurrentBar;
				retestBarsCount = 0;
			}

			if (!retestTracking)
				return;

			retestBarsCount = CurrentBar - retestStartBar;
			retestLevelSeries[0] = retestTargetIndex;
			retestDirectionSeries[0] = retestDirection;
			retestBarsCountSeries[0] = retestBarsCount;

			if (retestBarsCount > RetestBars)
			{
				retestExpiredSeries[0] = 1;
				retestTracking = false;
				retestTargetIndex = 0;
				retestDirection = 0;
				retestBarsCount = 0;
				return;
			}

			if ((retestDirection > 0 && mapIndexFull < retestTargetIndex)
				|| (retestDirection < 0 && mapIndexFull > retestTargetIndex))
			{
				retestInvalidatedSeries[0] = 1;
				retestTracking = false;
				retestTargetIndex = 0;
				retestDirection = 0;
				retestBarsCount = 0;
				return;
			}

			if (mapIndexFull == retestTargetIndex)
			{
				retestActiveSeries[0] = 1;
				retestTracking = false;
				retestTargetIndex = 0;
				retestDirection = 0;
				retestBarsCount = 0;
			}
		}

		private void UpdateBcrState()
		{
			bcrArmedSeries[0] = 0;
			bcrConfirmedSeries[0] = 0;
			bcrInvalidatedSeries[0] = 0;
			bcrCooldownSeries[0] = 0;
			bcrReason = "BCR_NONE";
			bcrScoreSeries[0] = 0;
			bcrStateSeries[0] = (int)bcrState;
			bcrDirectionSeries[0] = bcrDirection;

			if (retestActiveSeries[0] == 1)
			{
				lastRetestBar = CurrentBar;
				lastRetestDirection = retestDirectionSeries[0];
			}

			if (vxBreakSeries[0] == 1 && CurrentBar > 0)
			{
				lastVxBreakBar = CurrentBar;
				lastVxBreakDirection = vxIndexSeries[0] > vxIndexSeries[1]
					? 1
					: (vxIndexSeries[0] < vxIndexSeries[1] ? -1 : 0);
			}

			int timeoutBars = Math.Max(1, BcrTimeoutBars);
			int cooldownBars = Math.Max(1, BcrCooldownBars);

			if (bcrState == BcrState.Confirmed)
			{
				if (CurrentBar > bcrLastConfirmedBar)
				{
					bcrState = BcrState.Cooldown;
					bcrCooldownStartBar = CurrentBar;
				}
				else
				{
					bcrConfirmedSeries[0] = 1;
					bcrReason = "BCR_CONFIRM";
					bcrScoreSeries[0] = ComputeQualityScore(bcrDirection, scenarioType, mapsEffectiveMode == ExternalInputMode.Proxy);
					bcrStateSeries[0] = (int)bcrState;
					bcrDirectionSeries[0] = bcrDirection;
					return;
				}
			}

			if (bcrState == BcrState.Cooldown)
			{
				if (bcrCooldownStartBar >= 0 && (CurrentBar - bcrCooldownStartBar) < cooldownBars)
				{
					bcrCooldownSeries[0] = 1;
					bcrReason = "BCR_COOLDOWN";
					bcrStateSeries[0] = (int)bcrState;
					bcrDirectionSeries[0] = 0;
					return;
				}

				bcrState = BcrState.Idle;
				bcrDirection = 0;
				bcrArmedBar = -1;
				bcrStateSeries[0] = (int)bcrState;
				bcrDirectionSeries[0] = bcrDirection;
			}

			if (bcrState == BcrState.Armed)
			{
				// Timeout: demasiado tiempo esperando retest
				if ((CurrentBar - bcrArmedBar) > timeoutBars)
				{
					InvalidateBcr("BCR_TIMEOUT");
					return;
				}

				// MAP0 stale: precio se alejó demasiado
				if (map0Stale)
				{
					InvalidateBcr("BCR_INVALIDATE_STALE");
					return;
				}

				// Escenario cambió (solo invalidar si cambió a None)
				if (scenarioType == ScenarioType.None)
				{
					InvalidateBcr("BCR_INVALIDATE_SCENARIO");
					return;
				}

				// Hertz no disponible (solo en modo estricto)
				if (!hertzAvailable && !EnableLiteSignals)
				{
					InvalidateBcr("BCR_INVALIDATE_HERTZ");
					return;
				}

				// Progreso en MAP invalidado
				if (!IsMapProgressValid(bcrDirection))
				{
					InvalidateBcr("BCR_INVALIDATE_MAP");
					return;
				}

				// Wall cambió de dirección (solo en modo estricto)
				if (!WallAllowsDirection(bcrDirection) && !EnableLiteSignals)
				{
					InvalidateBcr("BCR_INVALIDATE_WALL");
					return;
				}

				// Detectar retest
				bool retestOk = lastRetestBar >= bcrArmedBar && lastRetestDirection == bcrDirection;
				bool retestOpposite = lastRetestBar >= bcrArmedBar
					&& lastRetestDirection != 0
					&& lastRetestDirection != bcrDirection;

				// Retest opuesto invalida
				if (retestOpposite)
				{
					InvalidateBcr("BCR_INVALIDATE_RETEST");
					return;
				}

				// Retest correcto confirma
				if (retestOk)
				{
					bcrState = BcrState.Confirmed;
					bcrLastConfirmedBar = CurrentBar;
					bcrConfirmedSeries[0] = 1;
					bcrReason = "BCR_CONFIRM";
					bcrScoreSeries[0] = ComputeQualityScore(bcrDirection, scenarioType, mapsEffectiveMode == ExternalInputMode.Proxy);
					bcrStateSeries[0] = (int)bcrState;
					bcrDirectionSeries[0] = bcrDirection;
					return;
				}

				bcrStateSeries[0] = (int)bcrState;
				bcrDirectionSeries[0] = bcrDirection;
				return;
			}

			if (bcrState != BcrState.Idle)
				return;

			// FILOSOFÍA FPLEME: BCR (Breakout Confirmation Retest) se activa cuando:
			// 1. Hay un break de VX (fuerza) en la dirección del ciclo
			// 2. El precio está progresando en MAP (PPM o Transition con dirección clara)
			// 3. Wall permite la dirección (o modo Lite activo)
			
			// Requisitos básicos
			if (!mapIndexAvailable || map0Stale)
			{
				bcrReason = "BCR_BLOCK_MAP";
				return;
			}

			// Permitir BCR en PPM y Transition (modo Lite también permite MM si hay dirección clara)
			if (scenarioType != ScenarioType.PPM && scenarioType != ScenarioType.Transition)
			{
				if (!EnableLiteSignals || scenarioType == ScenarioType.None)
				{
					bcrReason = "BCR_BLOCK_SCENARIO";
					return;
				}
			}

			// Hertz como filtro de volatilidad (opcional en modo Lite)
			if (!hertzAvailable && !EnableLiteSignals)
			{
				bcrReason = "BCR_BLOCK_HERTZ";
				return;
			}

			// Detectar break de VX
			if (vxBreakSeries[0] != 1 || CurrentBar == 0)
				return;

			int breakDirection = vxIndexSeries[0] > vxIndexSeries[1]
				? 1
				: (vxIndexSeries[0] < vxIndexSeries[1] ? -1 : 0);
			if (breakDirection == 0)
				return;

			// Inferir dirección desde MAP
			int inferredDirection = mapIndexFull > 0 ? 1 : (mapIndexFull < 0 ? -1 : 0);
			if (inferredDirection == 0)
				return;

			// Break debe alinearse con dirección de MAP
			if (breakDirection != inferredDirection)
				return;

			// Validar progreso en MAP
			if (!IsMapProgressValid(inferredDirection))
			{
				bcrReason = "BCR_BLOCK_MAP_PROGRESS";
				return;
			}

			// Validar Wall (relajado en modo Lite)
			if (!WallAllowsDirection(inferredDirection) && !EnableLiteSignals)
			{
				bcrReason = "BCR_BLOCK_WALL";
				return;
			}

			// Armar BCR
			bcrState = BcrState.Armed;
			bcrDirection = breakDirection;
			bcrArmedBar = CurrentBar;
			bcrArmedSeries[0] = 1;
			bcrReason = "BCR_ARMED";
			bcrStateSeries[0] = (int)bcrState;
			bcrDirectionSeries[0] = bcrDirection;
		}

		private void UpdateArState()
		{
			arArmedSeries[0] = 0;
			arConfirmedSeries[0] = 0;
			arInvalidatedSeries[0] = 0;
			arCooldownSeries[0] = 0;
			arReason = "AR_NONE";
			arScoreSeries[0] = 0;
			arStateSeries[0] = (int)arState;
			arDirectionSeries[0] = arDirection;

			if (mapIndexAvailable && !map0Stale && Math.Abs(mapZoneCompact) <= 1)
				arExtremeReset = true;

			int timeoutBars = Math.Max(1, ArTimeoutBars);
			int cooldownBars = Math.Max(1, ArCooldownBars);

			if (arState == ArState.Confirmed)
			{
				if (CurrentBar > arLastConfirmedBar)
				{
					arState = ArState.Cooldown;
					arCooldownStartBar = CurrentBar;
				}
				else
				{
					arConfirmedSeries[0] = 1;
					arReason = "AR_CONFIRM";
					arScoreSeries[0] = ComputeQualityScore(arDirection, scenarioType, mapsEffectiveMode == ExternalInputMode.Proxy);
					arStateSeries[0] = (int)arState;
					arDirectionSeries[0] = arDirection;
					return;
				}
			}

			if (arState == ArState.Cooldown)
			{
				if (arCooldownStartBar >= 0 && (CurrentBar - arCooldownStartBar) < cooldownBars)
				{
					arCooldownSeries[0] = 1;
					arReason = "AR_COOLDOWN";
					arStateSeries[0] = (int)arState;
					arDirectionSeries[0] = 0;
					return;
				}

				arState = ArState.Idle;
				arDirection = 0;
				arArmedBar = -1;
				arStateSeries[0] = (int)arState;
				arDirectionSeries[0] = arDirection;
			}

			if (arState == ArState.Armed)
			{
				if ((CurrentBar - arArmedBar) > timeoutBars)
				{
					InvalidateAr("AR_TIMEOUT");
					return;
				}

				if (map0Stale)
				{
					InvalidateAr("AR_INVALIDATE_STALE");
					return;
				}

				if (!EnableLiteSignals && !(scenarioType == ScenarioType.MM || scenarioType == ScenarioType.Transition))
				{
					InvalidateAr("AR_INVALIDATE_SCENARIO");
					return;
				}

				// CONFIRMACIÓN ULTRA-ESTRICTA: Solo confirmar cuando precio YA se movió a favor
				// Esto elimina los Bars=1 losses (50% de pérdidas actuales)
				// Requiere: precio se movió AL MENOS 2 MAP bands a favor + swing confirmado
				
				bool wallOk = wallAvailable && (EnableLiteSignals || wallState == WallState.Neutral);
				bool hertzOk = hertzAvailable;
				
				// Verificar movimiento de precio a favor (mínimo 2 bands para confirmar)
				bool priceMovedFavor = false;
				if (mapIndexAvailable && CurrentBar > arArmedBar)
				{
					int currentMapIndex = mapIndexFull;
					int mapIndexDiff = arDirection > 0 
						? (currentMapIndex - arArmedMapIndex)  // LONG: debe subir
						: (arArmedMapIndex - currentMapIndex); // SHORT: debe bajar
					
					// Requiere mínimo 2 MAP bands de movimiento a favor
					priceMovedFavor = mapIndexDiff >= 2;
				}
				
				// Swing confirmado en dirección
				bool swingConfirm = (arDirection > 0 && swingLowConfirmSeries[0] == 1)
					|| (arDirection < 0 && swingHighConfirmSeries[0] == 1);
				
				// Requiere TODOS: wall, hertz, movimiento significativo Y swing
				bool confirm = wallOk && hertzOk && priceMovedFavor && swingConfirm;

				if (confirm)
				{
					arState = ArState.Confirmed;
					arLastConfirmedBar = CurrentBar;
					arConfirmedSeries[0] = 1;
					arReason = "AR_CONFIRM";
					arScoreSeries[0] = ComputeQualityScore(arDirection, scenarioType, mapsEffectiveMode == ExternalInputMode.Proxy);
					arStateSeries[0] = (int)arState;
					arDirectionSeries[0] = arDirection;
					return;
				}

				if (!wallOk)
					arReason = "AR_WAIT_WALL";
				else if (!hertzOk)
					arReason = "AR_WAIT_HERTZ";
				else if (!priceMovedFavor)
					arReason = "AR_WAIT_MAP_MOVE";
				else if (!swingConfirm)
					arReason = "AR_WAIT_SWING";

				arStateSeries[0] = (int)arState;
				arDirectionSeries[0] = arDirection;
				return;
			}

			if (arState != ArState.Idle)
				return;

			if (!mapIndexAvailable || map0Stale)
			{
				arReason = !mapIndexAvailable ? "AR_BLOCK_MAP" : "AR_BLOCK_STALE";
				return;
			}

			if (!EnableLiteSignals && !(scenarioType == ScenarioType.MM || scenarioType == ScenarioType.Transition))
			{
				arReason = "AR_BLOCK_SCENARIO";
				return;
			}

			// FILOSOFÍA FPLEME: AR (Accumulation/Redistribution) se activa cuando:
			// 1. Precio está en zona extrema de MAP (s2+/i2+)
			// 2. Hay evento VX (divergencia o failbreak) indicando agotamiento
			// 3. Wall neutral (o modo Lite activo)
			// En modo Lite: relajar requisito de VX event
			
			// Hertz opcional en modo Lite
			if (!hertzAvailable && !EnableLiteSignals)
			{
				arReason = "AR_BLOCK_HERTZ";
				return;
			}

			// Wall: neutral en modo estricto, cualquier estado en modo Lite
			if (!wallAvailable || (!EnableLiteSignals && wallState != WallState.Neutral))
			{
				arReason = "AR_BLOCK_WALL";
				return;
			}

			// FILTRO 1: Detectar zona extrema (basado en análisis CSV)
			// Datos muestran: zonas ±4 tienen 40% WR, zonas ±1 a ±3 tienen 60% WR
			// Bloquear zonas demasiado extremas (configurable, default: |zone| > 3)
			if (Math.Abs(mapZoneCompact) > ArMaxZone)
			{
				arReason = "AR_BLOCK_ZONE_TOO_EXTREME";
				return;
			}

			// FILOSOFÍA CORRECTA: AR es para REVERSIONES en zonas EXTREMAS
			// Zona extrema válida: ±2 o ±3 ÚNICAMENTE (no ±1 que es demasiado cerca de MAP0)
			// Los datos CSV mostraron zona ±1 con buen WR, PERO eso incluye RM que es el trigger correcto ahí
			int zoneDirection = 0;
			if (mapZoneCompact == 2 || mapZoneCompact == 3)
				zoneDirection = -1; // Zona superior → esperar reversión bajista
			else if (mapZoneCompact == -2 || mapZoneCompact == -3)
				zoneDirection = 1; // Zona inferior → esperar reversión alcista
			else
			{
				arReason = "AR_BLOCK_ZONE_NOT_EXTREME";
				return;
			}

			// FILTRO 2: Wall alignment (basado en análisis CSV)
			// AR LONG + Wall Down = múltiples losses
			// AR SHORT + Wall Up = múltiples losses
			// Solo permitir si Wall es Neutral o alineado con la dirección
			if (wallAvailable && !EnableLiteSignals)
			{
				if (zoneDirection > 0 && wallState == WallState.Down)
				{
					arReason = "AR_BLOCK_WALL_CONTRA";
					return;
				}
				if (zoneDirection < 0 && wallState == WallState.Up)
				{
					arReason = "AR_BLOCK_WALL_CONTRA";
					return;
				}
			}

			// Evento VX: divergencia o failbreak (relajado en modo Lite)
			bool vxEvent = zoneDirection > 0
				? (vxDivergenceBullSeries[0] == 1 || vxFailBreakSeries[0] == 1)
				: (vxDivergenceBearSeries[0] == 1 || vxFailBreakSeries[0] == 1);

			// En modo Lite, permitir armar sin VX event si hay ciclo válido
			if (!vxEvent && !EnableLiteSignals)
			{
				arReason = "AR_BLOCK_VX_EVENT";
				return;
			}

			// Evitar rearmar en la misma dirección sin reset
			if (!arExtremeReset && zoneDirection == arLastExtremeDirection)
			{
				arReason = "AR_BLOCK_REARM";
				return;
			}

			// Armar AR
			arState = ArState.Armed;
			arDirection = zoneDirection;
			arArmedBar = CurrentBar;
			arArmedMapIndex = mapIndexFull;
			arExtremeReset = false;
			arLastExtremeDirection = zoneDirection;
			arArmedSeries[0] = 1;
			arReason = "AR_ARMED";
			arStateSeries[0] = (int)arState;
			arDirectionSeries[0] = arDirection;
		}

		private void InvalidateAr(string reason)
		{
			arInvalidatedSeries[0] = 1;
			arReason = reason;
			arState = ArState.Cooldown;
			arCooldownStartBar = CurrentBar;
			arDirection = 0;
			arArmedBar = -1;
			arStateSeries[0] = (int)arState;
			arDirectionSeries[0] = arDirection;
		}

		private void UpdateRmState()
		{
			rmArmedSeries[0] = 0;
			rmConfirmedSeries[0] = 0;
			rmInvalidatedSeries[0] = 0;
			rmCooldownSeries[0] = 0;
			rmReason = "RM_NONE";
			rmScoreSeries[0] = 0;
			rmStateSeries[0] = (int)rmState;
			rmDirectionSeries[0] = rmDirection;

			int timeoutBars = Math.Max(1, RmTimeoutBars);
			int cooldownBars = Math.Max(1, RmCooldownBars);

			if (rmState == RmState.Confirmed)
			{
				if (CurrentBar > rmLastConfirmedBar)
				{
					rmState = RmState.Cooldown;
					if (rmCooldownStartBar < 0)
						rmCooldownStartBar = rmLastConfirmedBar;
				}
				else
				{
					rmConfirmedSeries[0] = 1;
					rmReason = "RM_CONFIRM";
					rmScoreSeries[0] = ComputeQualityScore(rmDirection, scenarioType, mapsEffectiveMode == ExternalInputMode.Proxy);
					rmStateSeries[0] = (int)rmState;
					rmDirectionSeries[0] = rmDirection;
					return;
				}
			}

			if (rmState == RmState.Cooldown)
			{
				if (rmCooldownStartBar >= 0 && (CurrentBar - rmCooldownStartBar) < cooldownBars)
				{
					rmCooldownSeries[0] = 1;
					rmStateSeries[0] = (int)rmState;
					rmDirectionSeries[0] = 0;
					return;
				}

				rmState = RmState.Idle;
				rmDirection = 0;
				rmArmedBar = -1;
				rmStateSeries[0] = (int)rmState;
				rmDirectionSeries[0] = rmDirection;
			}

			// FILOSOFÍA FPLEME: RM (Range Market) se activa cuando:
			// 1. Escenario MM (mismo MAP) o Transition
			// 2. Precio oscila cerca de MAP0 (zona central)
			// 3. Wall neutral (mercado indeciso)
			// 4. VX flat (sin fuerza clara)
			
			// FILTRO 3: RM solo en MM/Transition (basado en análisis CSV)
			// Datos muestran: RM en PPM tiene 55% WR (bajo), RM en MM/Transition tiene 60% WR
			// RM en None tiene 0% WR → bloquear estrictamente
			bool scenarioOk = scenarioType == ScenarioType.MM || scenarioType == ScenarioType.Transition;
			
			bool rangeOk = rangeActive 
				|| (EnableLiteSignals && Math.Abs(mapZoneCompact) <= 1)
				|| (wallAvailable && wallState == WallState.Neutral && Math.Abs(mapZoneCompact) <= 2);
			bool wallOk = wallAvailable && (EnableLiteSignals || wallState == WallState.Neutral);
			bool vxOk = vxAvailable && (EnableLiteSignals || (vxBreakSeries[0] == 0 && Math.Abs(vxSlopeSeries[0]) <= VxSlopeFlatThreshold));
			
			// RM: dirección basada en oscilación en rango
			// Si precio está en zona positiva, esperar reversión bajista
			// Si precio está en zona negativa, esperar reversión alcista
			int zoneDirection = 0;
			if (mapZoneCompact > 0)
				zoneDirection = -1; // Precio alto → esperar bajada
			else if (mapZoneCompact < 0)
				zoneDirection = 1;  // Precio bajo → esperar subida

			if (rmState == RmState.Armed)
			{
				if ((CurrentBar - rmArmedBar) > timeoutBars)
				{
					InvalidateRm("RM_TIMEOUT");
					return;
				}

				if (!scenarioOk || !rangeOk)
				{
					InvalidateRm("RM_BLOCK_RANGE");
					return;
				}

				if (!wallOk)
				{
					InvalidateRm("RM_BLOCK_WALL");
					return;
				}

			if (!vxOk)
			{
				InvalidateRm("RM_BLOCK_VX");
				return;
			}

			// CONFIRMACIÓN ULTRA-ESTRICTA: Solo confirmar cuando precio YA osciló
			// Requiere: precio se movió hacia MAP0 (al menos 1 band) Y swing confirmado
			
			bool priceMovedToRange = false;
			if (mapIndexAvailable && CurrentBar > rmArmedBar)
			{
				int currentMapIndex = mapIndexFull;
				// RM: precio debe moverse hacia MAP0 (zona central)
				// LONG: precio debe subir hacia 0
				// SHORT: precio debe bajar hacia 0
				if (rmDirection > 0)
				{
					// RM LONG: precio debe estar más cerca de 0 que cuando se armó
					priceMovedToRange = currentMapIndex > rmArmedMapIndex && Math.Abs(currentMapIndex) <= 1;
				}
				else if (rmDirection < 0)
				{
					// RM SHORT: precio debe estar más cerca de 0 que cuando se armó
					priceMovedToRange = currentMapIndex < rmArmedMapIndex && Math.Abs(currentMapIndex) <= 1;
				}
			}
			
			bool swingConfirm = (rmDirection > 0 && swingLowConfirmSeries[0] == 1)
				|| (rmDirection < 0 && swingHighConfirmSeries[0] == 1);
			
			// Requiere AMBOS: movimiento hacia rango Y swing confirmado
			bool confirm = priceMovedToRange && swingConfirm;

			if (confirm)
			{
				rmState = RmState.Confirmed;
				rmLastConfirmedBar = CurrentBar;
				rmCooldownStartBar = CurrentBar;
				rmConfirmedSeries[0] = 1;
				rmReason = "RM_CONFIRM";
				rmScoreSeries[0] = ComputeQualityScore(rmDirection, scenarioType, mapsEffectiveMode == ExternalInputMode.Proxy);
				rmStateSeries[0] = (int)rmState;
				rmDirectionSeries[0] = rmDirection;
				return;
			}

			if (!priceMovedToRange)
				rmReason = "RM_WAIT_MAP_MOVE";
			else if (!swingConfirm)
				rmReason = "RM_WAIT_SWING";

			rmStateSeries[0] = (int)rmState;
			rmDirectionSeries[0] = rmDirection;
			return;
			}

			if (rmState != RmState.Idle)
				return;

			if (!scenarioOk || !rangeOk)
			{
				rmReason = "RM_BLOCK_RANGE";
				return;
			}

			if (!wallOk)
			{
				rmReason = "RM_BLOCK_WALL";
				return;
			}

			if (!vxOk)
			{
				rmReason = "RM_BLOCK_VX";
				return;
			}

			if (zoneDirection == 0)
				return;

			rmState = RmState.Armed;
			rmDirection = zoneDirection;
			rmArmedBar = CurrentBar;
			rmArmedMapIndex = mapIndexFull;
			rmArmedSeries[0] = 1;
			rmReason = "RM_ARMED";
			rmStateSeries[0] = (int)rmState;
			rmDirectionSeries[0] = rmDirection;
		}

		private void UpdatePtState()
		{
			ptArmedSeries[0] = 0;
			ptConfirmedSeries[0] = 0;
			ptCooldownSeries[0] = 0;
			ptReason = "PT_NONE";
			ptScoreSeries[0] = 0;
			ptStateSeries[0] = (int)ptState;
			ptDirectionSeries[0] = ptDirection;

			int timeoutBars = Math.Max(1, PtTimeoutBars);
			int cooldownBars = Math.Max(1, PtCooldownBars);

			if (ptState == PtState.Confirmed)
			{
				if (CurrentBar > ptLastConfirmedBar)
				{
					ptState = PtState.Cooldown;
					if (ptCooldownStartBar < 0)
						ptCooldownStartBar = ptLastConfirmedBar;
				}
				else
				{
					ptConfirmedSeries[0] = 1;
					ptReason = "PT_CONFIRM";
					ptScoreSeries[0] = ComputeQualityScore(ptDirection, scenarioType, mapsEffectiveMode == ExternalInputMode.Proxy);
					ptStateSeries[0] = (int)ptState;
					ptDirectionSeries[0] = ptDirection;
					return;
				}
			}

			if (ptState == PtState.Cooldown)
			{
				if (ptCooldownStartBar >= 0 && (CurrentBar - ptCooldownStartBar) < cooldownBars)
				{
					ptCooldownSeries[0] = 1;
					ptStateSeries[0] = (int)ptState;
					ptDirectionSeries[0] = 0;
					return;
				}

				ptState = PtState.Idle;
				ptDirection = 0;
				ptArmedBar = -1;
				ptCycleCount = 0;
				ptWallChangeBar = -1;
				ptLastCycleBar = -1;
				ptStateSeries[0] = (int)ptState;
				ptDirectionSeries[0] = ptDirection;
			}

			bool scenarioOk = scenarioType == ScenarioType.Transition;
			bool wallOk = wallAvailable && wallState != WallState.Unknown;
			bool wallChange = false;
			if (wallOk && CurrentBar >= 1)
			{
				bool colorChanged = wallStateSeries[1] != (int)WallState.Unknown
					&& wallStateSeries[0] != wallStateSeries[1];
				wallChange = wallCrossSeries[0] == 1 || colorChanged;
			}

			int wallDirection = 0;
			if (wallState == WallState.Up)
				wallDirection = 1;
			else if (wallState == WallState.Down)
				wallDirection = -1;

			bool vxOk = vxAvailable && vxBreakSeries[0] == 0 && Math.Abs(vxSlopeSeries[0]) <= VxSlopeFlatThreshold;

			if (ptState == PtState.Armed)
			{
				if ((CurrentBar - ptArmedBar) > timeoutBars)
				{
					InvalidatePt("PT_TIMEOUT");
					return;
				}

				if (!scenarioOk)
				{
					ptReason = "PT_BLOCK_SCENARIO";
					ptStateSeries[0] = (int)ptState;
					ptDirectionSeries[0] = ptDirection;
					return;
				}

				if (!wallOk)
				{
					ptReason = "PT_BLOCK_WALL";
					ptStateSeries[0] = (int)ptState;
					ptDirectionSeries[0] = ptDirection;
					return;
				}

				if (wallDirection == 0)
				{
					InvalidatePt("PT_BLOCK_WALL_NEUTRAL");
					return;
				}

				bool cycleEvent = (ptDirection > 0 && swingLowConfirmSeries[0] == 1)
					|| (ptDirection < 0 && swingHighConfirmSeries[0] == 1);
				if (cycleEvent && CurrentBar > ptWallChangeBar && CurrentBar != ptLastCycleBar)
				{
					ptCycleCount = Math.Min(2, ptCycleCount + 1);
					ptLastCycleBar = CurrentBar;
				}

				if (ptCycleCount < 2 || CurrentBar == ptLastCycleBar)
				{
					ptReason = "PT_BLOCK_CYCLE";
					ptStateSeries[0] = (int)ptState;
					ptDirectionSeries[0] = ptDirection;
					return;
				}

				bool vxAligned = vxOk && ((ptDirection > 0 && vxSlopeSeries[0] >= 0)
					|| (ptDirection < 0 && vxSlopeSeries[0] <= 0));
				if (!vxAligned)
				{
					ptReason = "PT_BLOCK_VX";
					ptStateSeries[0] = (int)ptState;
					ptDirectionSeries[0] = ptDirection;
					return;
				}

				bool mapProgress = (ptDirection > 0 && mapIndexFull >= 1)
					|| (ptDirection < 0 && mapIndexFull <= -1);
				if (!mapProgress)
				{
					ptReason = "PT_BLOCK_MAP";
					ptStateSeries[0] = (int)ptState;
					ptDirectionSeries[0] = ptDirection;
					return;
				}

				ptState = PtState.Confirmed;
				ptLastConfirmedBar = CurrentBar;
				ptCooldownStartBar = CurrentBar;
				ptConfirmedSeries[0] = 1;
				ptReason = "PT_CONFIRM";
				ptScoreSeries[0] = ComputeQualityScore(ptDirection, scenarioType, mapsEffectiveMode == ExternalInputMode.Proxy);
				ptStateSeries[0] = (int)ptState;
				ptDirectionSeries[0] = ptDirection;
				return;
			}

			if (ptState != PtState.Idle)
				return;

			if (!scenarioOk)
			{
				ptReason = "PT_BLOCK_SCENARIO";
				return;
			}

			if (!wallOk || !wallChange || wallDirection == 0)
			{
				ptReason = "PT_BLOCK_WALL";
				return;
			}

			ptState = PtState.Armed;
			ptDirection = wallDirection;
			ptArmedBar = CurrentBar;
			ptCycleCount = 0;
			ptWallChangeBar = CurrentBar;
			ptLastCycleBar = -1;
			ptArmedSeries[0] = 1;
			ptReason = "PT_ARMED";
			ptStateSeries[0] = (int)ptState;
			ptDirectionSeries[0] = ptDirection;
		}

		private void InvalidateRm(string reason)
		{
			rmInvalidatedSeries[0] = 1;
			rmReason = reason;
			rmState = RmState.Cooldown;
			rmCooldownStartBar = CurrentBar;
			rmDirection = 0;
			rmArmedBar = -1;
			rmStateSeries[0] = (int)rmState;
			rmDirectionSeries[0] = rmDirection;
		}

		private void InvalidatePt(string reason)
		{
			ptReason = reason;
			ptState = PtState.Cooldown;
			ptCooldownStartBar = CurrentBar;
			ptDirection = 0;
			ptArmedBar = -1;
			ptCycleCount = 0;
			ptWallChangeBar = -1;
			ptLastCycleBar = -1;
			ptStateSeries[0] = (int)ptState;
			ptDirectionSeries[0] = ptDirection;
		}

		private void UpdateVisualSignals()
		{
			if (!boxClosedConfirmed)
				return;

			if (DrawBcrSignals)
				DrawTriggerSignal("BCR", bcrConfirmedSeries[0], bcrDirectionSeries[0], bcrScoreSeries[0], Brushes.Blue, 2);
			if (DrawArSignals)
				DrawTriggerSignal("AR", arConfirmedSeries[0], arDirectionSeries[0], arScoreSeries[0], Brushes.Orange, 4);
			if (DrawRmSignals)
				DrawTriggerSignal("RM", rmConfirmedSeries[0], rmDirectionSeries[0], rmScoreSeries[0], Brushes.Green, 6);
			if (DrawPtSignals)
				DrawTriggerSignal("PT", ptConfirmedSeries[0], ptDirectionSeries[0], ptScoreSeries[0], Brushes.Purple, 8);
		}

		private void DrawTriggerSignal(
			string prefix,
			int confirmed,
			int direction,
			int score,
			Brush brush,
			int offsetTicks)
		{
			if (confirmed != 1)
				return;

			string tag = prefix + "_" + CurrentBar;

			// Validar dirección
			if (direction == 0)
				return;

			// Dibujar línea vertical
			// Para LONG: color más brillante, para SHORT: color más oscuro
			Brush lineBrush = brush;
			if (direction < 0)
			{
				// Hacer el color más oscuro para SHORT
				if (brush == Brushes.Blue)
					lineBrush = Brushes.DarkBlue;
				else if (brush == Brushes.Orange)
					lineBrush = Brushes.OrangeRed;
				else if (brush == Brushes.Green)
					lineBrush = Brushes.DarkGreen;
				else if (brush == Brushes.Purple)
					lineBrush = Brushes.DarkMagenta;
			}

			Draw.VerticalLine(this, tag, 0, lineBrush);

			// Determinar calidad para el label
			string label = prefix;
			if (score >= ScoreHQ)
				label += " HQ";
			else if (score >= ScoreLQ)
				label += " LQ";
			else
				return;

			// Añadir indicador de dirección al label
			label += direction > 0 ? " ↑" : " ↓";

			// Posicionar texto arriba (si LONG) o abajo (si SHORT) de la barra
			double textY = direction > 0 
				? Low[0] - (offsetTicks * TickSize) 
				: High[0] + (offsetTicks * TickSize);

			Draw.Text(this, tag + "_T", label, 0, textY, lineBrush);
		}

		private void DrawTextFixedPanel()
		{
			if (!boxClosedConfirmed)
				return;

			int selectedType = 0;
			int selectedScore = 0;
			string selectedTag = string.Empty;
			string selectedLabel = string.Empty;
			Brush selectedBrush = null;

			if (DrawPtSignals && ptConfirmedSeries[0] == 1)
			{
				selectedType = 4;
				selectedScore = ptScoreSeries[0];
				selectedTag = PanelTagPt;
				selectedLabel = "PT";
				selectedBrush = Brushes.Purple;
			}
			else if (DrawRmSignals && rmConfirmedSeries[0] == 1)
			{
				selectedType = 3;
				selectedScore = rmScoreSeries[0];
				selectedTag = PanelTagRm;
				selectedLabel = "RM";
				selectedBrush = Brushes.Green;
			}
			else if (DrawArSignals && arConfirmedSeries[0] == 1)
			{
				selectedType = 2;
				selectedScore = arScoreSeries[0];
				selectedTag = PanelTagAr;
				selectedLabel = "AR";
				selectedBrush = Brushes.Orange;
			}
			else if (DrawBcrSignals && bcrConfirmedSeries[0] == 1)
			{
				selectedType = 1;
				selectedScore = bcrScoreSeries[0];
				selectedTag = PanelTagBcr;
				selectedLabel = "BCR";
				selectedBrush = Brushes.Blue;
			}

			if (selectedType == 0)
				return;

			string quality = selectedScore >= ScoreHQ ? "HQ" : (selectedScore >= ScoreLQ ? "LQ" : "LQ");
			string text = selectedLabel + " " + quality;

			if (lastPanelSignalType != 0
				&& lastPanelSignalType != selectedType
				&& !string.IsNullOrEmpty(lastPanelSignalTag))
			{
				RemoveDrawObject(lastPanelSignalTag);
			}

			if (selectedType != lastPanelSignalType || selectedScore != lastPanelSignalScore)
			{
				Draw.TextFixed(this, selectedTag, text, TextPosition.TopLeft, selectedBrush, panelFont,
					Brushes.Transparent, Brushes.Transparent, 0);
				lastPanelSignalType = selectedType;
				lastPanelSignalScore = selectedScore;
				lastPanelSignalTag = selectedTag;
			}
		}

		private void UpdateTradeStats()
		{
			// Detectar nueva señal confirmada
			int currentDirection = 0;
			bool signalConfirmed = false;
			string signalType = "";

			if (DrawBcrSignals && bcrConfirmedSeries[0] == 1 && !signalTracked)
			{
				currentDirection = bcrDirectionSeries[0];
				signalConfirmed = true;
				signalType = "BCR";
			}
			else if (DrawArSignals && arConfirmedSeries[0] == 1 && !signalTracked)
			{
				currentDirection = arDirectionSeries[0];
				signalConfirmed = true;
				signalType = "AR";
			}
			else if (DrawRmSignals && rmConfirmedSeries[0] == 1 && !signalTracked)
			{
				currentDirection = rmDirectionSeries[0];
				signalConfirmed = true;
				signalType = "RM";
			}
			else if (DrawPtSignals && ptConfirmedSeries[0] == 1 && !signalTracked)
			{
				currentDirection = ptDirectionSeries[0];
				signalConfirmed = true;
				signalType = "PT";
			}

			// Iniciar tracking de nuevo trade
			if (signalConfirmed)
			{
				totalTrades++;
				lastSignalPrice = Close[0];
				lastSignalType = signalType;
				lastSignalEntryTime = Time[0];
				lastSignalDirection = currentDirection;
				lastSignalBar = CurrentBar;
				signalTracked = true;

				// Calcular niveles de TP y SL
				double tpDistance = TakeProfitTicks * TickSize;
				double slDistance = StopLossTicks * TickSize;

				if (currentDirection > 0) // Long
				{
					lastSignalTPPrice = lastSignalPrice + tpDistance;
					lastSignalSLPrice = lastSignalPrice - slDistance;
				}
				else if (currentDirection < 0) // Short
				{
					lastSignalTPPrice = lastSignalPrice - tpDistance;
					lastSignalSLPrice = lastSignalPrice + slDistance;
				}

				lastSignalHighestPrice = Close[0];
				lastSignalLowestPrice = Close[0];
			}

			// Evaluar trade activo en cada barra
			if (signalTracked && lastSignalBar >= 0 && CurrentBar > lastSignalBar)
			{
				// Actualizar extremos para trailing stop
				if (High[0] > lastSignalHighestPrice)
					lastSignalHighestPrice = High[0];
				if (Low[0] < lastSignalLowestPrice)
					lastSignalLowestPrice = Low[0];

				bool tradeCompleted = false;
				bool isWin = false;

			if (lastSignalDirection > 0) // Long
			{
				bool tpHit = High[0] >= lastSignalTPPrice;
				bool slHit = false;

				if (UseTrailingStop)
				{
					// Trailing stop: mover SL cuando el precio avanza
					double trailDistance = StopLossTicks * TickSize;
					double newSL = lastSignalHighestPrice - trailDistance;
					if (newSL > lastSignalSLPrice)
						lastSignalSLPrice = newSL;

					slHit = Low[0] <= lastSignalSLPrice;
				}
				else
				{
					slHit = Low[0] <= lastSignalSLPrice;
				}

				// Si ambos se tocan en la misma barra, decidir por distancia
				if (tpHit && slHit)
				{
					double distToTP = lastSignalTPPrice - lastSignalPrice;
					double distToSL = lastSignalPrice - lastSignalSLPrice;
					// El más cercano se toca primero
					tradeCompleted = true;
					isWin = distToTP <= distToSL;
				}
				else if (tpHit)
				{
					tradeCompleted = true;
					isWin = true;
				}
				else if (slHit)
				{
					tradeCompleted = true;
					isWin = false;
				}
			}
			else if (lastSignalDirection < 0) // Short
			{
				bool tpHit = Low[0] <= lastSignalTPPrice;
				bool slHit = false;

				if (UseTrailingStop)
				{
					// Trailing stop: mover SL cuando el precio avanza
					double trailDistance = StopLossTicks * TickSize;
					double newSL = lastSignalLowestPrice + trailDistance;
					if (newSL < lastSignalSLPrice)
						lastSignalSLPrice = newSL;

					slHit = High[0] >= lastSignalSLPrice;
				}
				else
				{
					slHit = High[0] >= lastSignalSLPrice;
				}

				// Si ambos se tocan en la misma barra, decidir por distancia
				if (tpHit && slHit)
				{
					double distToTP = lastSignalPrice - lastSignalTPPrice;
					double distToSL = lastSignalSLPrice - lastSignalPrice;
					// El más cercano se toca primero
					tradeCompleted = true;
					isWin = distToTP <= distToSL;
				}
				else if (tpHit)
				{
					tradeCompleted = true;
					isWin = true;
				}
				else if (slHit)
				{
					tradeCompleted = true;
					isWin = false;
				}
			}

				// Registrar resultado del trade
				if (tradeCompleted)
				{
					if (isWin)
						tradeWins++;
					else
						tradeLosses++;

					// Calcular PnL en ticks
					double exitPrice = isWin 
						? lastSignalTPPrice 
						: lastSignalSLPrice;
					double pnlTicks = (exitPrice - lastSignalPrice) / TickSize * lastSignalDirection;
					double pnlPoints = pnlTicks * TickSize;
					totalPoints += pnlPoints;
					int barsInTrade = CurrentBar - lastSignalBar;

					// Log del trade
					LogTrade(lastSignalType, lastSignalDirection, lastSignalPrice, 
						lastSignalTPPrice, lastSignalSLPrice, exitPrice, isWin, pnlTicks, barsInTrade);

					signalTracked = false;
					lastSignalPrice = double.NaN;
					lastSignalDirection = 0;
					lastSignalBar = -1;
					lastSignalTPPrice = double.NaN;
					lastSignalSLPrice = double.NaN;
					lastSignalHighestPrice = double.NaN;
					lastSignalLowestPrice = double.NaN;
					lastSignalType = "";
				}
			}
		}

		private void DrawStatsPanel()
		{
			if (!boxClosedConfirmed)
				return;

			double winrate = totalTrades > 0 ? (double)tradeWins / totalTrades * 100.0 : 0.0;
			bool winrateEligible = TakeProfitTicks == 40 && StopLossTicks == 40 && !UseTrailingStop;
			string winrateText = winrateEligible
				? winrate.ToString("F1", CultureInfo.InvariantCulture) + "%"
				: "N/A";
			string totalPointsText = totalPoints.ToString("F1", CultureInfo.InvariantCulture);
			
			// Info de trade activo
			string activeTradeInfo = "No Active Trade";
			if (signalTracked && HasValue(lastSignalPrice))
			{
				double currentPrice = Close[0];
				double pnlTicks = (currentPrice - lastSignalPrice) / TickSize * lastSignalDirection;
				double distToTP = (lastSignalTPPrice - currentPrice) / TickSize * lastSignalDirection;
				double distToSL = (currentPrice - lastSignalSLPrice) / TickSize * lastSignalDirection;
				string direction = lastSignalDirection > 0 ? "LONG" : "SHORT";
				activeTradeInfo = string.Format("Active: {0} | PnL: {1:F0}t | TP: {2:F0}t | SL: {3:F0}t",
					direction, pnlTicks, distToTP, distToSL);
			}

			string text = string.Format(CultureInfo.InvariantCulture,
				"MFS Stats | TP: {0}t | SL: {1}t | Trail: {2}\n"
				+ "Trades: {3} | Wins: {4} | Losses: {5} | WR(10pt): {6}\n"
				+ "TotalPts: {7}\n"
				+ "{8}\n\n"
				+ "Diagnostics:\n"
				+ "MapAvail: {9}  WallAvail: {10}  VxAvail: {11}  HertzAvail: {12}\n"
				+ "MapIdx: {13}  Zone: {14}  Stale: {15}\n"
				+ "Wall: {16}  Cross: {17}  RangeActive: {18}\n"
				+ "VX Break: {19}  Fail: {20}  DivB: {21}  DivS: {22}  Slope: {23:F2}\n"
				+ "CycleRef: {24}  Cycle2: {25}  Dir: {26}\n"
				+ "Scenario: {27}\n"
				+ "BCR: {28} ({29})\nAR: {30} ({31})\nRM: {32} ({33})\nPT: {34} ({35})",
				TakeProfitTicks, StopLossTicks, UseTrailingStop ? "ON" : "OFF",
				totalTrades, tradeWins, tradeLosses, winrateText,
				totalPointsText,
				activeTradeInfo,
				mapIndexAvailable ? "Y" : "N",
				wallAvailable ? "Y" : "N",
				vxAvailable ? "Y" : "N",
				hertzAvailable ? "Y" : "N",
				mapIndexFull,
				mapZoneCompact,
				map0Stale ? "Y" : "N",
				wallState,
				(CurrentBar > 0 && wallCrossSeries[0] == 1) ? "Y" : "N",
				rangeActive ? "Y" : "N",
				(CurrentBar > 0 && vxBreakSeries[0] == 1) ? "Y" : "N",
				(CurrentBar > 0 && vxFailBreakSeries[0] == 1) ? "Y" : "N",
				(CurrentBar > 0 && vxDivergenceBullSeries[0] == 1) ? "Y" : "N",
				(CurrentBar > 0 && vxDivergenceBearSeries[0] == 1) ? "Y" : "N",
				vxSlopeSeries[0],
				cycleRefValid ? "Y" : "N",
				cycle2Valid ? "Y" : "N",
				cycleDirection,
				scenarioType,
				bcrState, bcrReason,
				arState, arReason,
				rmState, rmReason,
				ptState, ptReason);

			Draw.TextFixed(this, PanelTagStats, text, TextPosition.BottomLeft, Brushes.White,
				panelFont, Brushes.Transparent, Brushes.Transparent, 0);
		}

		private int GetRmZoneDirection()
		{
			if (mapZoneCompact >= 2)
				return -1;
			if (mapZoneCompact <= -2)
				return 1;
			return 0;
		}

		private bool IsRmZoneValid(int direction)
		{
			if (direction > 0)
				return mapZoneCompact <= -2;
			if (direction < 0)
				return mapZoneCompact >= 2;
			return false;
		}

		private void InvalidateBcr(string reason)
		{
			bcrInvalidatedSeries[0] = 1;
			bcrReason = reason;
			bcrState = BcrState.Cooldown;
			bcrCooldownStartBar = CurrentBar;
			bcrDirection = 0;
			bcrArmedBar = -1;
			bcrStateSeries[0] = (int)bcrState;
			bcrDirectionSeries[0] = bcrDirection;
		}

		private bool WallAllowsDirection(int direction)
		{
			if (!wallAvailable)
				return false;

			if (direction > 0 && wallState == WallState.Down)
				return false;

			if (direction < 0 && wallState == WallState.Up)
				return false;

			return true;
		}

		private bool IsMapProgressValid(int direction)
		{
			if (!mapIndexAvailable || mapJumpFlag)
				return false;

			if (direction > 0)
				return mapIndexFull >= 1;

			if (direction < 0)
				return mapIndexFull <= -1;

			return false;
		}

		private int GetRenkoBarDirection()
		{
			double delta = Close[0] - Close[1];
			if (delta > 0)
				return 1;
			if (delta < 0)
				return -1;
			return 0;
		}

		private void InitializeCsvContext()
		{
			if (!EnableCsvContext)
				return;

			csvContextFolder = CsvContextFolder ?? string.Empty;
			csvContextFileName = CsvContextFileName ?? string.Empty;
			if (string.IsNullOrWhiteSpace(csvContextFileName))
				return;
			csvContextPath = Path.Combine(csvContextFolder, csvContextFileName);

			if (!string.IsNullOrWhiteSpace(csvContextFolder))
				Directory.CreateDirectory(csvContextFolder);

			FileMode mode = CsvContextOverwrite ? FileMode.Create : FileMode.Append;
			csvContextWriter = new StreamWriter(new FileStream(csvContextPath, mode, FileAccess.Write, FileShare.Read))
			{
				AutoFlush = true
			};
			csvContextHeaderWritten = false;

			if (CsvContextIncludeHeader)
				WriteCsvContextHeader();

			string baseName = Path.GetFileNameWithoutExtension(csvContextFileName);
			if (string.IsNullOrWhiteSpace(baseName))
				baseName = "MFS_Context";
			string signalFileName = baseName + "_Signals.csv";
			csvSignalPath = Path.Combine(csvContextFolder, signalFileName);
			csvSignalWriter = new StreamWriter(new FileStream(csvSignalPath, mode, FileAccess.Write, FileShare.Read))
			{
				AutoFlush = true
			};
			csvSignalHeaderWritten = false;

			if (CsvContextIncludeHeader)
				WriteCsvSignalHeader();
		}

		private void FinalizeCsvContext()
		{
			if (csvContextWriter == null)
				return;

			try
			{
				csvContextWriter.Flush();
			}
			catch
			{
			}
			finally
			{
				csvContextWriter.Dispose();
				csvContextWriter = null;
			}

			if (csvSignalWriter == null)
				return;

			try
			{
				csvSignalWriter.Flush();
			}
			catch
			{
			}
			finally
			{
				csvSignalWriter.Dispose();
				csvSignalWriter = null;
			}
		}

		private void InitializeTradeLog()
		{
			if (!EnableTradeLog)
				return;

			try
			{
				// Usar la ruta de NinjaTrader si el parámetro está vacío
				if (string.IsNullOrWhiteSpace(TradeLogFolder))
				{
					// Obtener la carpeta de documentos de NinjaTrader
					string ntFolder = NinjaTrader.Core.Globals.UserDataDir;
					tradeLogFolder = Path.Combine(ntFolder, "logs", "MFS");
				}
				else
				{
					tradeLogFolder = TradeLogFolder;
				}

				tradeLogFileName = string.IsNullOrWhiteSpace(TradeLogFile)
					? "MFS_TradeLog.csv"
					: TradeLogFile;

				if (!Directory.Exists(tradeLogFolder))
					Directory.CreateDirectory(tradeLogFolder);

				tradeLogPath = Path.Combine(tradeLogFolder, tradeLogFileName);
				bool fileExists = File.Exists(tradeLogPath);

				tradeLogWriter = new StreamWriter(tradeLogPath, true, System.Text.Encoding.UTF8);
				tradeLogWriter.AutoFlush = true;

				// Escribir header si es archivo nuevo
				if (!fileExists)
				{
					tradeLogWriter.WriteLine("Timestamp,Instrument,SignalType,Direction,EntryPrice,TPPrice,SLPrice,ExitPrice,Result,PnLTicks,Scenario,MapIdx,Zone,Wall,VXSlope,CycleDir,Bars");
				}

				Print(string.Format("Trade Log iniciado: {0}", tradeLogPath));
			}
			catch (Exception ex)
			{
				Print(string.Format("Error inicializando Trade Log: {0}", ex.Message));
				tradeLogWriter = null;
			}
		}

		private void FinalizeTradeLog()
		{
			if (tradeLogWriter == null)
				return;

			try
			{
				tradeLogWriter.Flush();
			}
			catch
			{
			}
			finally
			{
				tradeLogWriter.Dispose();
				tradeLogWriter = null;
			}
		}

		private void LogTrade(string signalType, int direction, double entryPrice, double tpPrice, double slPrice, 
			double exitPrice, bool isWin, double pnlTicks, int barsInTrade)
		{
			if (!EnableTradeLog || tradeLogWriter == null)
				return;

			try
			{
				string timestamp = Time[0].ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
				string instrument = Instrument != null ? Instrument.FullName : "Unknown";
				string dir = direction > 0 ? "LONG" : "SHORT";
				string result = isWin ? "WIN" : "LOSS";
				string scenario = scenarioType.ToString();
				string wall = wallState.ToString();

				string line = string.Format(CultureInfo.InvariantCulture,
					"{0},{1},{2},{3},{4:F2},{5:F2},{6:F2},{7:F2},{8},{9:F1},{10},{11},{12},{13},{14:F2},{15},{16}",
					timestamp, instrument, signalType, dir, entryPrice, tpPrice, slPrice, exitPrice,
					result, pnlTicks, scenario, mapIndexFull, mapZoneCompact, wall,
					vxSlopeSeries[0], cycleDirection, barsInTrade);

				tradeLogWriter.WriteLine(line);
			}
			catch (Exception ex)
			{
				Print(string.Format("Error escribiendo Trade Log: {0}", ex.Message));
			}
		}

		private void WriteCsvContextHeader()
		{
			if (csvContextWriter == null || csvContextHeaderWritten)
				return;

			string header = string.Join(",",
				"Time",
				"BarIndex",
				"Close",
				"Map0",
				"S1",
				"I1",
				"BandStep",
				"MapMode",
				"MapAvailable",
				"MapIndexAvailable",
				"MapIndexFull",
				"MapZoneCompact",
				"MapJumpCount",
				"MapJumpFlag",
				"Map0Stale",
				"WallMode",
				"WallAvailable",
				"WallValue",
				"WallState",
				"WallCross",
				"VxMode",
				"VxAvailable",
				"VxValue",
				"VxSlope",
				"VxBreak",
				"VxFailBreak",
				"VxDivBull",
				"VxDivBear",
				"VxIndex",
				"HertzMode",
				"HertzAvailable",
				"HertzValue",
				"ScenarioType",
				"RangeActive",
				"BcrState",
				"BcrDir",
				"BcrReason",
				"BcrScore",
				"ArState",
				"ArDir",
				"ArReason",
				"ArScore",
				"RmState",
				"RmDir",
				"RmReason",
				"RmScore",
				"PtState",
				"PtDir",
				"PtReason",
				"PtScore",
				"ClosedBoxCount");

			csvContextWriter.WriteLine(header);
			csvContextHeaderWritten = true;
		}

		private void WriteCsvSignalHeader()
		{
			if (csvSignalWriter == null || csvSignalHeaderWritten)
				return;

			string header = string.Join(",",
				"Time",
				"BarIndex",
				"Close",
				"TriggerType",
				"TriggerDir",
				"TriggerScore");

			csvSignalWriter.WriteLine(header);
			csvSignalHeaderWritten = true;
		}

		private void WriteCsvContextRow()
		{
			if (!EnableCsvContext || csvContextWriter == null || !boxClosedConfirmed)
				return;

			if (CsvContextIncludeHeader && !csvContextHeaderWritten)
				WriteCsvContextHeader();

			string timeStamp = Time[0].ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
			string line = string.Join(",",
				timeStamp,
				CurrentBar.ToString(CultureInfo.InvariantCulture),
				FormatDouble(Close[0]),
				FormatDouble(mapsMap0),
				FormatDouble(mapsS1),
				FormatDouble(mapsI1),
				FormatDouble(mapsBandStep),
				((int)mapsEffectiveMode).ToString(CultureInfo.InvariantCulture),
				BoolToInt(mapsAvailable),
				BoolToInt(mapIndexAvailable),
				mapIndexFull.ToString(CultureInfo.InvariantCulture),
				mapZoneCompact.ToString(CultureInfo.InvariantCulture),
				mapJumpCount.ToString(CultureInfo.InvariantCulture),
				BoolToInt(mapJumpFlag),
				BoolToInt(map0Stale),
				((int)wallEffectiveMode).ToString(CultureInfo.InvariantCulture),
				BoolToInt(wallAvailable),
				FormatDouble(wallValue),
				((int)wallState).ToString(CultureInfo.InvariantCulture),
				wallCrossSeries[0].ToString(CultureInfo.InvariantCulture),
				((int)vxEffectiveMode).ToString(CultureInfo.InvariantCulture),
				BoolToInt(vxAvailable),
				FormatDouble(vxValue),
				FormatDouble(vxSlopeNormalized),
				vxBreakSeries[0].ToString(CultureInfo.InvariantCulture),
				vxFailBreakSeries[0].ToString(CultureInfo.InvariantCulture),
				vxDivergenceBullSeries[0].ToString(CultureInfo.InvariantCulture),
				vxDivergenceBearSeries[0].ToString(CultureInfo.InvariantCulture),
				vxIndexSeries[0].ToString(CultureInfo.InvariantCulture),
				((int)hertzEffectiveMode).ToString(CultureInfo.InvariantCulture),
				BoolToInt(hertzAvailable),
				FormatDouble(hertzValue),
				((int)scenarioType).ToString(CultureInfo.InvariantCulture),
				BoolToInt(rangeActive),
				bcrStateSeries[0].ToString(CultureInfo.InvariantCulture),
				bcrDirectionSeries[0].ToString(CultureInfo.InvariantCulture),
				bcrReason ?? "BCR_NONE",
				bcrScoreSeries[0].ToString(CultureInfo.InvariantCulture),
				arStateSeries[0].ToString(CultureInfo.InvariantCulture),
				arDirectionSeries[0].ToString(CultureInfo.InvariantCulture),
				arReason ?? "AR_NONE",
				arScoreSeries[0].ToString(CultureInfo.InvariantCulture),
				rmStateSeries[0].ToString(CultureInfo.InvariantCulture),
				rmDirectionSeries[0].ToString(CultureInfo.InvariantCulture),
				rmReason ?? "RM_NONE",
				rmScoreSeries[0].ToString(CultureInfo.InvariantCulture),
				ptStateSeries[0].ToString(CultureInfo.InvariantCulture),
				ptDirectionSeries[0].ToString(CultureInfo.InvariantCulture),
				ptReason ?? "PT_NONE",
				ptScoreSeries[0].ToString(CultureInfo.InvariantCulture),
				closedBoxCount.ToString(CultureInfo.InvariantCulture));

			csvContextWriter.WriteLine(line);
		}

		private void WriteCsvSignalRow()
		{
			if (!EnableCsvContext || csvSignalWriter == null || !boxClosedConfirmed)
				return;

			if (CsvContextIncludeHeader && !csvSignalHeaderWritten)
				WriteCsvSignalHeader();

			string triggerType = string.Empty;
			int triggerDir = 0;
			int triggerScore = 0;

			if (DrawPtSignals && ptConfirmedSeries[0] == 1)
			{
				triggerType = "PT";
				triggerDir = ptDirectionSeries[0];
				triggerScore = ptScoreSeries[0];
			}
			else if (DrawRmSignals && rmConfirmedSeries[0] == 1)
			{
				triggerType = "RM";
				triggerDir = rmDirectionSeries[0];
				triggerScore = rmScoreSeries[0];
			}
			else if (DrawArSignals && arConfirmedSeries[0] == 1)
			{
				triggerType = "AR";
				triggerDir = arDirectionSeries[0];
				triggerScore = arScoreSeries[0];
			}
			else if (DrawBcrSignals && bcrConfirmedSeries[0] == 1)
			{
				triggerType = "BCR";
				triggerDir = bcrDirectionSeries[0];
				triggerScore = bcrScoreSeries[0];
			}

			if (string.IsNullOrEmpty(triggerType))
				return;

			string timeStamp = Time[0].ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
			string line = string.Join(",",
				timeStamp,
				CurrentBar.ToString(CultureInfo.InvariantCulture),
				FormatDouble(Close[0]),
				triggerType,
				triggerDir.ToString(CultureInfo.InvariantCulture),
				triggerScore.ToString(CultureInfo.InvariantCulture));

			csvSignalWriter.WriteLine(line);
		}

		private static string FormatDouble(double value)
		{
			if (double.IsNaN(value) || double.IsInfinity(value))
				return "NaN";
			return value.ToString("0.#####", CultureInfo.InvariantCulture);
		}

		private static string BoolToInt(bool value)
		{
			return value ? "1" : "0";
		}

		private bool EvaluateMapsStale(
			double map0,
			double s1,
			double i1,
			double bandStep,
			int map0LastChange,
			int s1LastChange,
			int i1LastChange)
		{
			if (!HasValue(map0) || !HasValue(s1) || !HasValue(i1) || bandStep <= 0)
				return true;

			if (map0LastChange < 0 || s1LastChange < 0 || i1LastChange < 0)
				return true;

			bool unchanged = (CurrentBar - map0LastChange) >= Map0StaleBars
				&& (CurrentBar - s1LastChange) >= Map0StaleBars
				&& (CurrentBar - i1LastChange) >= Map0StaleBars;

			if (!unchanged)
				return false;

			double range = ComputeWindowRange(Map0StaleBars);
			return range > (Map0StaleRangeBands * bandStep);
		}

		private bool EvaluateWallStale(double wall, int lastChangeBar, int crossCount)
		{
			if (!HasValue(wall))
				return true;

			if (lastChangeBar < 0)
				return true;

			if ((CurrentBar - lastChangeBar) >= WallStaleBars)
				return true;

			return crossCount >= WallCrossStaleThreshold;
		}

		private bool EvaluateVxAvailable(Series<double> series)
		{
			int window = Math.Max(1, VxAvailWindowBars);
			if (CurrentBar < window - 1)
				return false;

			double mean = 0.0;
			for (int i = 0; i < window; i++)
			{
				double v = series[i];
				if (double.IsNaN(v))
					return false;
				mean += v;
			}

			mean /= window;
			double variance = 0.0;
			for (int i = 0; i < window; i++)
			{
				double diff = series[i] - mean;
				variance += diff * diff;
			}

			return variance > 0.0;
		}

		private bool EvaluateHertzAvailable(double value, int lastChangeBar)
		{
			if (!HasValue(value) || value <= 0)
				return false;

			if (lastChangeBar < 0)
				return true;

			if ((CurrentBar - lastChangeBar) < HertzStaleBars)
				return true;

			double rangeNow = ComputeWindowRange(HertzStaleBars);
			bool expanded = HasValue(hertzRangeAtLastChange) && rangeNow > hertzRangeAtLastChange;
			return !expanded;
		}

		private int ComputeMapIndexFull(double price, double map0, double bandStep)
		{
			if (!HasValue(price) || !HasValue(map0) || bandStep <= 0)
				return 0;

			if (price == map0)
				return 0;

			if (price > map0)
			{
				int idx = (int)Math.Ceiling((price - map0) / bandStep);
				return Math.Min(8, Math.Max(1, idx));
			}

			int negIdx = (int)Math.Ceiling((map0 - price) / bandStep);
			return -Math.Min(8, Math.Max(1, negIdx));
		}

		private int ComputeMapJumpCount(double high, double low, double map0, double bandStep)
		{
			if (!HasValue(high) || !HasValue(low) || !HasValue(map0) || bandStep <= 0)
				return 0;

			int highIndex = ComputeMapIndexFull(high, map0, bandStep);
			int lowIndex = ComputeMapIndexFull(low, map0, bandStep);
			return Math.Abs(highIndex - lowIndex);
		}

		private int ClampMapZone(int mapIndex)
		{
			if (mapIndex > 3)
				return 3;
			if (mapIndex < -3)
				return -3;
			return mapIndex;
		}

		private int ComputeQualityScore(int direction, ScenarioType scenario, bool isProxy)
		{
			double score = 0.0;
			double maxScore = 100.0;

			if (!mapsAvailable || map0Stale)
				return 0;

			if (isProxy)
				maxScore = 70.0;

			double mapScore = 0.0;
			if (mapsEffectiveMode == ExternalInputMode.Integrated)
				mapScore = 25.0;
			else
				mapScore = 17.5;

			double wallScore = 0.0;
			if (wallAvailable)
			{
				if (mapsEffectiveMode == ExternalInputMode.Integrated)
					wallScore = 20.0;
				else
					wallScore = 14.0;

				if (wallState == WallState.Neutral)
					wallScore *= 0.9;
				else if ((direction > 0 && wallState == WallState.Down) || (direction < 0 && wallState == WallState.Up))
					wallScore *= 0.3;
			}

			double vxScore = 0.0;
			if (vxAvailable)
			{
				if (vxEffectiveMode == ExternalInputMode.Integrated)
					vxScore = 20.0;
				else
					vxScore = 14.0;

				if (vxBreakSeries[0] == 1 && ((direction > 0 && vxIndexSeries[0] > 0) || (direction < 0 && vxIndexSeries[0] < 0)))
					vxScore *= 1.1;
				if (vxFailBreakSeries[0] == 1)
					vxScore *= 0.8;
			}

			double cycleScore = 0.0;
			if (cycleRefValid && cycle2Valid)
			{
				if (mapsEffectiveMode == ExternalInputMode.Integrated)
					cycleScore = 15.0;
				else
					cycleScore = 10.5;
			}
			else if (cycleRefValid)
			{
				if (mapsEffectiveMode == ExternalInputMode.Integrated)
					cycleScore = 7.5;
				else
					cycleScore = 5.25;
			}

			double scenarioScore = 0.0;
			if (scenario == ScenarioType.PPM || scenario == ScenarioType.MM)
				scenarioScore = 20.0;
			else if (scenario == ScenarioType.Transition)
				scenarioScore = 15.0;

			score = mapScore + wallScore + vxScore + cycleScore + scenarioScore;
			score = Math.Min(score, maxScore);

			return (int)Math.Round(score);
		}

		private double ComputeMedianAbs(Series<double> series, int count, double[] work)
		{
			int length = Math.Min(count, work.Length);
			if (length <= 0)
				return 0.0;

			for (int i = 0; i < length; i++)
				work[i] = Math.Abs(series[i]);

			Array.Sort(work, 0, length);
			int mid = length / 2;
			if ((length % 2) == 1)
				return work[mid];

			return (work[mid - 1] + work[mid]) * 0.5;
		}

		private ExternalInputMode SelectEffectiveMode(ExternalInputMode requested, bool integratedOk)
		{
			if (requested == ExternalInputMode.Proxy)
				return ExternalInputMode.Proxy;
			return integratedOk ? ExternalInputMode.Integrated : ExternalInputMode.Proxy;
		}

		private static bool HasValue(double value)
		{
			return !double.IsNaN(value) && !double.IsInfinity(value);
		}

		private void UpdateChangeBar(ref double lastValue, double currentValue, ref int lastChangeBar)
		{
			if (!HasValue(currentValue))
				return;

			if (!HasValue(lastValue) || currentValue != lastValue)
			{
				lastValue = currentValue;
				lastChangeBar = CurrentBar;
			}
		}

		private double ComputeMedian(double[] source, int count, double[] work)
		{
			if (count <= 0)
				return double.NaN;

			Array.Copy(source, work, count);
			Array.Sort(work, 0, count);

			int mid = count / 2;
			if ((count % 2) == 1)
				return work[mid];

			return (work[mid - 1] + work[mid]) * 0.5;
		}

		private double ComputeProxyBandStep(double map0ProxyValue, int window)
		{
			if (!HasValue(map0ProxyValue))
				return double.NaN;

			double maxHigh = High[0];
			double minLow = Low[0];
			int bars = Math.Min(window, CurrentBar + 1);

			for (int i = 1; i < bars; i++)
			{
				maxHigh = Math.Max(maxHigh, High[i]);
				minLow = Math.Min(minLow, Low[i]);
			}

			double rangeUpper = Math.Abs(maxHigh - map0ProxyValue);
			double rangeLower = Math.Abs(map0ProxyValue - minLow);
			double range = Math.Max(rangeUpper, rangeLower);
			return range / 8.0;
		}

		private double ComputeWindowRange(int window)
		{
			int bars = Math.Min(Math.Max(1, window), CurrentBar + 1);
			double maxHigh = High[0];
			double minLow = Low[0];

			for (int i = 1; i < bars; i++)
			{
				maxHigh = Math.Max(maxHigh, High[i]);
				minLow = Math.Min(minLow, Low[i]);
			}

			return maxHigh - minLow;
		}

		[NinjaScriptProperty]
		[Display(Name = "MAPS Mode", Order = 1, GroupName = "Inputs")]
		public ExternalInputMode MapsMode { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Wall Mode", Order = 2, GroupName = "Inputs")]
		public ExternalInputMode WallMode { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "VX Mode", Order = 3, GroupName = "Inputs")]
		public ExternalInputMode VxMode { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Hertz Mode", Order = 4, GroupName = "Inputs")]
		public ExternalInputMode HertzMode { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Map Proxy Window", Order = 10, GroupName = "Inputs")]
		public int MapProxyWindow { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Map0 Stale Bars", Order = 11, GroupName = "Inputs")]
		public int Map0StaleBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Map0 Stale Range Bands", Order = 12, GroupName = "Inputs")]
		public int Map0StaleRangeBands { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Map Jump Penalty Bands", Order = 13, GroupName = "Inputs")]
		public int MapJumpPenaltyBands { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Wall Stale Bars", Order = 14, GroupName = "Inputs")]
		public int WallStaleBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Wall Cross Stale Threshold", Order = 15, GroupName = "Inputs")]
		public int WallCrossStaleThreshold { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Hertz Stale Bars", Order = 16, GroupName = "Inputs")]
		public int HertzStaleBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "VX Avail Window Bars", Order = 17, GroupName = "Inputs")]
		public int VxAvailWindowBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Range Window Bars", Order = 18, GroupName = "Inputs")]
		public int RangeWindowBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Range Wall Cross Min", Order = 19, GroupName = "Inputs")]
		public int RangeWallCrossMin { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Range Yellow Min Bars", Order = 20, GroupName = "Inputs")]
		public int RangeYellowMinBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "VX Slope Flat Threshold", Order = 21, GroupName = "Inputs")]
		public double VxSlopeFlatThreshold { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "VX Break Confirm Bars", Order = 22, GroupName = "Inputs")]
		public int VxBreakConfirmBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Retest Bars", Order = 23, GroupName = "Inputs")]
		public int RetestBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "BCR Timeout Bars", Order = 24, GroupName = "Inputs")]
		public int BcrTimeoutBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "BCR Cooldown Bars", Order = 25, GroupName = "Inputs")]
		public int BcrCooldownBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "AR Timeout Bars", Order = 26, GroupName = "Inputs")]
		public int ArTimeoutBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "AR Cooldown Bars", Order = 27, GroupName = "Inputs")]
		public int ArCooldownBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "RM Timeout Bars", Order = 28, GroupName = "Inputs")]
		public int RmTimeoutBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "RM Cooldown Bars", Order = 29, GroupName = "Inputs")]
		public int RmCooldownBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "PT Timeout Bars", Order = 30, GroupName = "Inputs")]
		public int PtTimeoutBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "PT Cooldown Bars", Order = 31, GroupName = "Inputs")]
		public int PtCooldownBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Score HQ Threshold", Order = 32, GroupName = "Inputs")]
		public int ScoreHQ { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Score LQ Threshold", Order = 33, GroupName = "Inputs")]
		public int ScoreLQ { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Score Tie Epsilon", Order = 34, GroupName = "Inputs")]
		public int ScoreTieEpsilon { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Enable CSV Context", Order = 35, GroupName = "Inputs")]
		public bool EnableCsvContext { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "CSV Context Folder", Order = 36, GroupName = "Inputs")]
		public string CsvContextFolder { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "CSV Context File Name", Order = 37, GroupName = "Inputs")]
		public string CsvContextFileName { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "CSV Context Overwrite", Order = 38, GroupName = "Inputs")]
		public bool CsvContextOverwrite { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "CSV Context Include Header", Order = 39, GroupName = "Inputs")]
		public bool CsvContextIncludeHeader { get; set; }


		[NinjaScriptProperty]
		[Display(Name = "Scenario Fallback (pre Cycle2)", Order = 0, GroupName = "Signal Filters")]
		public bool ScenarioFallback { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Enable Lite Signals", Order = 1, GroupName = "Signal Filters")]
		public bool EnableLiteSignals { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "AR Max Zone", Order = 1, GroupName = "Signal Filters", Description = "Zona MAP máxima para AR (default: 3, CSV muestra zona 4+ tiene 40% WR)")]
		[Range(2, 8)]
		public int ArMaxZone { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Take Profit (Ticks)", Order = 2, GroupName = "Signal Filters", Description = "TP en ticks (NQ: 40 ticks = 10 puntos)")]
		[Range(1, 1000)]
		public int TakeProfitTicks { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Stop Loss (Ticks)", Order = 3, GroupName = "Signal Filters", Description = "SL en ticks (NQ: 40 ticks = 10 puntos)")]
		[Range(1, 1000)]
		public int StopLossTicks { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Use Trailing Stop", Order = 4, GroupName = "Signal Filters")]
		public bool UseTrailingStop { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Enable Trade Log", Order = 5, GroupName = "Signal Filters", Description = "Exportar cada trade a CSV")]
		public bool EnableTradeLog { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Trade Log Folder", Order = 6, GroupName = "Signal Filters", Description = "Carpeta para guardar log de trades")]
		public string TradeLogFolder { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Trade Log File", Order = 7, GroupName = "Signal Filters")]
		public string TradeLogFile { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Draw PT Signals", Order = 40, GroupName = "Signal Filters")]
		public bool DrawPtSignals { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Draw RM Signals", Order = 41, GroupName = "Signal Filters")]
		public bool DrawRmSignals { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Draw AR Signals", Order = 42, GroupName = "Signal Filters")]
		public bool DrawArSignals { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Draw BCR Signals", Order = 43, GroupName = "Signal Filters")]
		public bool DrawBcrSignals { get; set; }
	}
}




