using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Serialization;
using Azs=;
using NTRes.NinjaTrader.Gui.Chart;
using NinjaTrader.Custom;
using NinjaTrader.Data;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.DrawingTools;
using NinjaTrader.Gui.NinjaScript;
using NinjaTrader.Gui.Tools;
using NinjaTrader.NinjaScript.Indicators;
using NinjaTrader.NinjaScript.Indicators._FPLEME_;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;

[assembly: AssemblyProduct("STOP_ABS")]
[assembly: ComVisible(false)]
[assembly: AssemblyCompany("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyDescription("")]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: CompilationRelaxations(8)]
[assembly: NeutralResourcesLanguage("en", UltimateResourceFallbackLocation.MainAssembly)]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTitle("NinjaTrader Exported STOP_ABS")]
[assembly: AssemblyTrademark("")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyVersion("0.16.5.1")]
internal class <Module>
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	static <Module>()
	{
		<AgileDotNetRTPro>.Initialize();
		<AgileDotNetRTPro>.PostInitialize();
		Cjs=.Vee(throwOnError: false);
	}
}
namespace NinjaTrader.NinjaScript.MarketAnalyzerColumns
{
	public class MarketAnalyzerColumn : MarketAnalyzerColumnBase
	{
		private Indicator indicator;

		[Browsable(false)]
		public bool IsDataSeriesRequired
		{
			get
			{
				return ((NinjaScriptBase)this).IsDataSeriesRequired;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MarketAnalyzerColumn()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WoodiesCCI WoodiesCCI(int chopIndicatorWidth, int neutralBars, int period, int periodEma, int periodLinReg, int periodTurbo, int sideWinderLimit0, int sideWinderLimit1, int sideWinderWidth)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WoodiesCCI WoodiesCCI(ISeries<double> input, int chopIndicatorWidth, int neutralBars, int period, int periodEma, int periodLinReg, int periodTurbo, int sideWinderLimit0, int sideWinderLimit1, int sideWinderWidth)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WoodiesPivots WoodiesPivots(HLCCalculationModeWoodie priorDayHlc, int width)
		{
			return null;
		}

		public WoodiesPivots WoodiesPivots(ISeries<double> input, HLCCalculationModeWoodie priorDayHlc, int width)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			return indicator.WoodiesPivots(input, priorDayHlc, width);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WisemanAlligator WisemanAlligator(int jawPeriod, int teethPeriod, int lipsPeriod, int jawOffset, int teethOffset, int lipsOffset)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WisemanAlligator WisemanAlligator(ISeries<double> input, int jawPeriod, int teethPeriod, int lipsPeriod, int jawOffset, int teethOffset, int lipsOffset)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WisemanAwesomeOscillator WisemanAwesomeOscillator()
		{
			return null;
		}

		public WisemanAwesomeOscillator WisemanAwesomeOscillator(ISeries<double> input)
		{
			return indicator.WisemanAwesomeOscillator(input);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WisemanFractal WisemanFractal(int strength, int triangleOffset)
		{
			return null;
		}

		public WisemanFractal WisemanFractal(ISeries<double> input, int strength, int triangleOffset)
		{
			return indicator.WisemanFractal(input, strength, triangleOffset);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowCumulativeDelta OrderFlowCumulativeDelta(CumulativeDeltaType deltaType, CumulativeDeltaPeriod period, int sizeFilter)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowCumulativeDelta OrderFlowCumulativeDelta(ISeries<double> input, CumulativeDeltaType deltaType, CumulativeDeltaPeriod period, int sizeFilter)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowMarketDepthMap OrderFlowMarketDepthMap(BaseVolumeRange baseRange, int maxRange, int minRange, OpacityDistribution opacityDistribution, int depthMargin, bool extendLastKnown, bool showBidAskLine)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowMarketDepthMap OrderFlowMarketDepthMap(ISeries<double> input, BaseVolumeRange baseRange, int maxRange, int minRange, OpacityDistribution opacityDistribution, int depthMargin, bool extendLastKnown, bool showBidAskLine)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowVWAP OrderFlowVWAP(VWAPResolution resolution, TradingHours tradingHoursInstance, VWAPStandardDeviations numStandardDeviations, double sD1Multiplier, double sD2Multiplier, double sD3Multiplier)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowVWAP OrderFlowVWAP(ISeries<double> input, VWAPResolution resolution, TradingHours tradingHoursInstance, VWAPStandardDeviations numStandardDeviations, double sD1Multiplier, double sD2Multiplier, double sD3Multiplier)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowTradeDetector OrderFlowTradeDetector(TradeDetectorBaseLargeVolumeOn baseLargeVolumeOn, int minimumVolumeForMarker, int maximumMarkerSize, TradeDetectorSizeBase baseMarkerSizeOn, bool hoverValues)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowTradeDetector OrderFlowTradeDetector(ISeries<double> input, TradeDetectorBaseLargeVolumeOn baseLargeVolumeOn, int minimumVolumeForMarker, int maximumMarkerSize, TradeDetectorSizeBase baseMarkerSizeOn, bool hoverValues)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public StopAbsV StopAbsV(bool sHOW_ABS, bool sHOW_STOPS, bool cHECK)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public StopAbsV StopAbsV(ISeries<double> input, bool sHOW_ABS, bool sHOW_STOPS, bool cHECK)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SUM SUM(int period)
		{
			return null;
		}

		public SUM SUM(ISeries<double> input, int period)
		{
			return indicator.SUM(input, period);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EMA EMA(int period)
		{
			return null;
		}

		public EMA EMA(ISeries<double> input, int period)
		{
			return indicator.EMA(input, period);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static MarketAnalyzerColumn()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
}
namespace NinjaTrader.NinjaScript.Indicators
{
	public class Indicator : IndicatorRenderBase
	{
		private WoodiesCCI[] cacheWoodiesCCI;

		private WoodiesPivots[] cacheWoodiesPivots;

		private WisemanAlligator[] cacheWisemanAlligator;

		private WisemanAwesomeOscillator[] cacheWisemanAwesomeOscillator;

		private WisemanFractal[] cacheWisemanFractal;

		private OrderFlowCumulativeDelta[] cacheOrderFlowCumulativeDelta;

		private OrderFlowMarketDepthMap[] cacheOrderFlowMarketDepthMap;

		private OrderFlowVWAP[] cacheOrderFlowVWAP;

		private OrderFlowTradeDetector[] cacheOrderFlowTradeDetector;

		private StopAbsV[] cacheStopAbsV;

		private SUM[] cacheSUM;

		private EMA[] cacheEMA;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WoodiesCCI WoodiesCCI(int chopIndicatorWidth, int neutralBars, int period, int periodEma, int periodLinReg, int periodTurbo, int sideWinderLimit0, int sideWinderLimit1, int sideWinderWidth)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WoodiesCCI WoodiesCCI(ISeries<double> input, int chopIndicatorWidth, int neutralBars, int period, int periodEma, int periodLinReg, int periodTurbo, int sideWinderLimit0, int sideWinderLimit1, int sideWinderWidth)
		{
			return null;
		}

		public WoodiesPivots WoodiesPivots(HLCCalculationModeWoodie priorDayHlc, int width)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			return WoodiesPivots(((NinjaScriptBase)this).Input, priorDayHlc, width);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WoodiesPivots WoodiesPivots(ISeries<double> input, HLCCalculationModeWoodie priorDayHlc, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WisemanAlligator WisemanAlligator(int jawPeriod, int teethPeriod, int lipsPeriod, int jawOffset, int teethOffset, int lipsOffset)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WisemanAlligator WisemanAlligator(ISeries<double> input, int jawPeriod, int teethPeriod, int lipsPeriod, int jawOffset, int teethOffset, int lipsOffset)
		{
			return null;
		}

		public WisemanAwesomeOscillator WisemanAwesomeOscillator()
		{
			return WisemanAwesomeOscillator(((NinjaScriptBase)this).Input);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WisemanAwesomeOscillator WisemanAwesomeOscillator(ISeries<double> input)
		{
			return null;
		}

		public WisemanFractal WisemanFractal(int strength, int triangleOffset)
		{
			return WisemanFractal(((NinjaScriptBase)this).Input, strength, triangleOffset);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WisemanFractal WisemanFractal(ISeries<double> input, int strength, int triangleOffset)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowCumulativeDelta OrderFlowCumulativeDelta(CumulativeDeltaType deltaType, CumulativeDeltaPeriod period, int sizeFilter)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowCumulativeDelta OrderFlowCumulativeDelta(ISeries<double> input, CumulativeDeltaType deltaType, CumulativeDeltaPeriod period, int sizeFilter)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowMarketDepthMap OrderFlowMarketDepthMap(BaseVolumeRange baseRange, int maxRange, int minRange, OpacityDistribution opacityDistribution, int depthMargin, bool extendLastKnown, bool showBidAskLine)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowMarketDepthMap OrderFlowMarketDepthMap(ISeries<double> input, BaseVolumeRange baseRange, int maxRange, int minRange, OpacityDistribution opacityDistribution, int depthMargin, bool extendLastKnown, bool showBidAskLine)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowVWAP OrderFlowVWAP(VWAPResolution resolution, TradingHours tradingHoursInstance, VWAPStandardDeviations numStandardDeviations, double sD1Multiplier, double sD2Multiplier, double sD3Multiplier)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowVWAP OrderFlowVWAP(ISeries<double> input, VWAPResolution resolution, TradingHours tradingHoursInstance, VWAPStandardDeviations numStandardDeviations, double sD1Multiplier, double sD2Multiplier, double sD3Multiplier)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowTradeDetector OrderFlowTradeDetector(TradeDetectorBaseLargeVolumeOn baseLargeVolumeOn, int minimumVolumeForMarker, int maximumMarkerSize, TradeDetectorSizeBase baseMarkerSizeOn, bool hoverValues)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowTradeDetector OrderFlowTradeDetector(ISeries<double> input, TradeDetectorBaseLargeVolumeOn baseLargeVolumeOn, int minimumVolumeForMarker, int maximumMarkerSize, TradeDetectorSizeBase baseMarkerSizeOn, bool hoverValues)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public StopAbsV StopAbsV(bool sHOW_ABS, bool sHOW_STOPS, bool cHECK)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public StopAbsV StopAbsV(ISeries<double> input, bool sHOW_ABS, bool sHOW_STOPS, bool cHECK)
		{
			return null;
		}

		public SUM SUM(int period)
		{
			return SUM(((NinjaScriptBase)this).Input, period);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SUM SUM(ISeries<double> input, int period)
		{
			return null;
		}

		public EMA EMA(int period)
		{
			return EMA(((NinjaScriptBase)this).Input, period);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EMA EMA(ISeries<double> input, int period)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Indicator()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
}
namespace NinjaTrader.NinjaScript.PerformanceMetrics
{
	public class PerformanceMetric : PerformanceMetricBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		static PerformanceMetric()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
}
namespace NinjaTrader.NinjaScript.Strategies
{
	public class Strategy : StrategyRenderBase
	{
		private Indicator indicator;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Strategy()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WoodiesCCI WoodiesCCI(int chopIndicatorWidth, int neutralBars, int period, int periodEma, int periodLinReg, int periodTurbo, int sideWinderLimit0, int sideWinderLimit1, int sideWinderWidth)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WoodiesCCI WoodiesCCI(ISeries<double> input, int chopIndicatorWidth, int neutralBars, int period, int periodEma, int periodLinReg, int periodTurbo, int sideWinderLimit0, int sideWinderLimit1, int sideWinderWidth)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WoodiesPivots WoodiesPivots(HLCCalculationModeWoodie priorDayHlc, int width)
		{
			return null;
		}

		public WoodiesPivots WoodiesPivots(ISeries<double> input, HLCCalculationModeWoodie priorDayHlc, int width)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			return indicator.WoodiesPivots(input, priorDayHlc, width);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WisemanAlligator WisemanAlligator(int jawPeriod, int teethPeriod, int lipsPeriod, int jawOffset, int teethOffset, int lipsOffset)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WisemanAlligator WisemanAlligator(ISeries<double> input, int jawPeriod, int teethPeriod, int lipsPeriod, int jawOffset, int teethOffset, int lipsOffset)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WisemanAwesomeOscillator WisemanAwesomeOscillator()
		{
			return null;
		}

		public WisemanAwesomeOscillator WisemanAwesomeOscillator(ISeries<double> input)
		{
			return indicator.WisemanAwesomeOscillator(input);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public WisemanFractal WisemanFractal(int strength, int triangleOffset)
		{
			return null;
		}

		public WisemanFractal WisemanFractal(ISeries<double> input, int strength, int triangleOffset)
		{
			return indicator.WisemanFractal(input, strength, triangleOffset);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowCumulativeDelta OrderFlowCumulativeDelta(CumulativeDeltaType deltaType, CumulativeDeltaPeriod period, int sizeFilter)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowCumulativeDelta OrderFlowCumulativeDelta(ISeries<double> input, CumulativeDeltaType deltaType, CumulativeDeltaPeriod period, int sizeFilter)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowMarketDepthMap OrderFlowMarketDepthMap(BaseVolumeRange baseRange, int maxRange, int minRange, OpacityDistribution opacityDistribution, int depthMargin, bool extendLastKnown, bool showBidAskLine)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowMarketDepthMap OrderFlowMarketDepthMap(ISeries<double> input, BaseVolumeRange baseRange, int maxRange, int minRange, OpacityDistribution opacityDistribution, int depthMargin, bool extendLastKnown, bool showBidAskLine)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowVWAP OrderFlowVWAP(VWAPResolution resolution, TradingHours tradingHoursInstance, VWAPStandardDeviations numStandardDeviations, double sD1Multiplier, double sD2Multiplier, double sD3Multiplier)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowVWAP OrderFlowVWAP(ISeries<double> input, VWAPResolution resolution, TradingHours tradingHoursInstance, VWAPStandardDeviations numStandardDeviations, double sD1Multiplier, double sD2Multiplier, double sD3Multiplier)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowTradeDetector OrderFlowTradeDetector(TradeDetectorBaseLargeVolumeOn baseLargeVolumeOn, int minimumVolumeForMarker, int maximumMarkerSize, TradeDetectorSizeBase baseMarkerSizeOn, bool hoverValues)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public OrderFlowTradeDetector OrderFlowTradeDetector(ISeries<double> input, TradeDetectorBaseLargeVolumeOn baseLargeVolumeOn, int minimumVolumeForMarker, int maximumMarkerSize, TradeDetectorSizeBase baseMarkerSizeOn, bool hoverValues)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public StopAbsV StopAbsV(bool sHOW_ABS, bool sHOW_STOPS, bool cHECK)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public StopAbsV StopAbsV(ISeries<double> input, bool sHOW_ABS, bool sHOW_STOPS, bool cHECK)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SUM SUM(int period)
		{
			return null;
		}

		public SUM SUM(ISeries<double> input, int period)
		{
			return indicator.SUM(input, period);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EMA EMA(int period)
		{
			return null;
		}

		public EMA EMA(ISeries<double> input, int period)
		{
			return indicator.EMA(input, period);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Strategy()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
}
namespace NinjaTrader.Custom
{
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[CompilerGenerated]
	public class Resource
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceManager ResourceManager
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		public static string Acceleration
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string AccelerationMax
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string AccelerationStep
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ADLAD
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string AlertOnBreak
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string AlertOnBreakSound
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string AndrewsPitchforkCalculationMethod_ModifiedSchiff
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string AndrewsPitchforkCalculationMethod_Schiff
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string AndrewsPitchforkCalculationMethod_StandardPitchfork
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string AskLineLength
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string AskLineStroke
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string AuthDisclosureText1
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string AuthDisclosureText2
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BandPct
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarDown
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarSpacing
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarsPeriodType
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarsPeriodTypeNameDay
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarsPeriodTypeNameHeikenAshi
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarsPeriodTypeNameKagi
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarsPeriodTypeNameLineBreak
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarsPeriodTypeNameMinute
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarsPeriodTypeNameMonth
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarsPeriodTypeNamePointAndFigure
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarsPeriodTypeNameRange
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarsPeriodTypeNameRenko
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarsPeriodTypeNameSecond
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarsPeriodTypeNameTick
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarsPeriodTypeNameVolume
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarsPeriodTypeNameWeek
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarsPeriodTypeNameYear
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarsPeriodValue
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarTimerDisconnectedError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarTimerSessionTimeError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarTimerTimeBasedError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarTimerTimeRemaining
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarTimerWaitingOnDataError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BarUp
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BasePeriod
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BidLineLength
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BidLineStroke
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BlockTradeSize
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BollingerLowerBand
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BollingerMiddleBand
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BollingerUpperBand
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BuySellPressureBuyPressure
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BuySellPressureSellPressure
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BuySellVolumeBuys
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string BuySellVolumeSells
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CandlestickPatternFound
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CCILevel1
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CCILevel2
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CCILevelMinus1
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CCILevelMinus2
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ChartSpan_Day
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ChartSpan_Min1
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ChartSpan_Min15
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ChartSpan_Min240
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ChartSpan_Min30
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ChartSpan_Min5
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ChartSpan_Min60
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ChartSpan_Month
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ChartSpan_Week
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ChartSpan_Year
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ConstantLines1
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ConstantLines2
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ConstantLines3
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ConstantLines4
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string COT1
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string COT2
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string COT3
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string COT4
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string COT5
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CotDataError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CotDataStillDownloading
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CotDataWarning
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CountDown
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CountType_Trades
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CountType_Volume
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CurrentDayOHLError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CurrentDayOHLHigh
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CurrentDayOHLLow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CurrentDayOHLOpen
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CustomWindowAddOnBuyMarket
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CustomWindowAddOnSellMarket
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CustomWindowSampleDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string CustomWindowSampleName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DataBarsTypeDaily
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DataBarsTypeDay
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DataBarsTypeMinute
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DataBarsTypeMonth
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DataBarsTypeMonthly
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DataBarsTypePointAndFigure
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DataBarsTypeRange
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DataBarsTypeRenko
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DataBarsTypeSecond
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DataBarsTypeTick
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DataBarsTypeVolume
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DataBarsTypeWeek
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DataBarsTypeWeekly
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DataBarsTypeYear
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DataBarsTypeYearly
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Day
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Days
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DeviationType
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DeviationValue
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DMMinusDI
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DMPlusDI
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DonchianChannelMean
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DownBarColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DrawingToolIndicatorDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DrawingToolIndicatorName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string DrawLines
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string EMA1
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string EMA2
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string EmailSignature
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string EnvelopePercentage
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string FacebookServiceName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string FacebookSignature
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Fast
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string FastLimit
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string FastPeriod
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string FibonacciTextAlignment_ExtremeLeft
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string FibonacciTextAlignment_ExtremeRight
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string FibonacciTextAlignment_Left
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string FibonacciTextAlignment_Off
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string FibonacciTextAlignment_Right
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string FileFilterAnyLoadingDialog
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string FileFilterAnyWinForms
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string FileName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Font
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Forecast
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string GannFanDirection_DownLeft
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string GannFanDirection_DownRight
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string GannFanDirection_UpLeft
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string GannFanDirection_UpRight
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string GuiAuthorize
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string GuiChartStyleDojiBrush
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string HigherHigh
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string HigherLow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string HighlightVerticalRangeUnit_Currency
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string HighlightVerticalRangeUnit_Percent
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string HighlightVerticalRangeUnit_Pips
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string HighlightVerticalRangeUnit_Price
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string HighlightVerticalRangeUnit_Ticks
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string HLCCalculationMode
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string HLCCalculationMode_CalcFromIntradayData
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string HLCCalculationMode_DailyBars
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string HLCCalculationMode_UserDefinedValues
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string HLCCalculationModeDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Import
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ImportTypeNinjaTraderBeginningOfBar
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ImportTypeNinjaTraderDateTimeFormatError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ImportTypeNinjaTraderEndOfBar
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ImportTypeNinjaTraderFieldSeparatorNotIdentified
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ImportTypeNinjaTraderFormatError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ImportTypeNinjaTraderInstrumentNotSupported
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ImportTypeNinjaTraderNumericPriceFormatError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ImportTypeNinjaTraderUnableReadData
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ImportTypeNinjaTraderUnexpectedFieldNumber
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ImportTypeTickData
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string IncrementalPeriod
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Intermediate
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Interval
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string KeltnerChannelMidline
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string KeyReversalPlot0
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string LastLineLength
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string LastLineStroke
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string LegendLocation
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string LegendLocation_BottomLeft
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string LegendLocation_BottomRight
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string LegendLocation_Disabled
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string LegendLocation_TopLeft
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string LegendLocation_TopRight
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Length
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Line1Value
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Line2Value
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Line3Value
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Line4Value
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string LineColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Load
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Location
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string LowerHigh
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string LowerLow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MailCcAddress
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MailCcAddressDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MailServiceMailAddress
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MailServiceName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MailServicePort
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MailServiceSenderDisplayName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MailServiceServer
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MailServiceSSL
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MailSubject
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MailSubjectDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MailToAddress
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MailToAddressDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MAMAFAMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MAPeriod
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MAType
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MovingAverage
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MovingAverageRibbonPlot1
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MovingAverageRibbonPlot2
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MovingAverageRibbonPlot3
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MovingAverageRibbonPlot4
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MovingAverageRibbonPlot5
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MovingAverageRibbonPlot6
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MovingAverageRibbonPlot7
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string MovingAverageRibbonPlot8
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NBarsDownTrigger
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NegativeColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NetChangePosition_BottomLeft
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NetChangePosition_BottomRight
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NetChangePosition_TopLeft
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NetChangePosition_TopRight
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBackground
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBarsTypeDay
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBarsTypeHeikenAshi
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBarsTypeKagi
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBarsTypeKagiReversal
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBarsTypeLineBreak
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBarsTypeLineBreakLineBreaks
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBarsTypeMinute
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBarsTypeMonth
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBarsTypePointAndFigure
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBarsTypePointAndFigureBoxSize
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBarsTypePointAndFigureReversal
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBarsTypeRange
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBarsTypeRenko
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBarsTypeRenkoBrickSize
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBarsTypeSecond
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBarsTypeTick
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBarsTypeVolume
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBarsTypeWeek
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptBorder
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleBarWidth
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleBox
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleBoxDownBarsColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleBoxDownBarsOutline
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleBoxUpBarsColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleBoxUpBarsOutline
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleCandleDownBarsColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleCandleOutline
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleCandlestick
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleCandlestickHollow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleCandleUpBarsColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleCandleWick
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleEquivolume
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleHeikenAshi
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleKagi
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleKagiThickLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleKagiThinLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleLineOnClose
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleLineOnCloseColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleLineOnCloseWidth
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleLineWidth
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleMountain
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleMountainColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleMountainOutline
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleOHLC
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleOhlcDownBarsColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleOhlcUpBarsColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleOpenClose
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleOpenCloseDownBarsColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleOpenCloseDownBarsOutline
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleOpenCloseUpBarsColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStyleOpenCloseUpBarsOutline
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStylePointAndFigure
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStylePointAndFigureDownColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptChartStylePointAndFigureUpColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolAnchor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolAnchorEnd
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolAnchorExtension
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolAnchorMiddle
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolAnchorStart
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolAnchorText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolAndrewsPitchfork
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolAndrewsPitchforkCalculationMethod
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolAndrewsPitchforkCategoryStrokes
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolAndrewsPitchforkDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolAndrewsPitchforkExtendLinesBack
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolAndrewsPitchforkExtensionStroke
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolAndrewsPitchforkRetracement
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolArc
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolAreaOpacity
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolArrowLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolBackgroundOpacity
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolEllipse
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolExtendedLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolFibonacciCircle
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolFibonacciExtensions
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolFibonacciLevelsBaseAnchorLineStroke
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolFibonacciRetracements
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolFibonacciRetracementsExtendLinesLeft
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolFibonacciRetracementsExtendLinesRight
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolFibonacciRetracementsTextAlignment
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolFibonacciRetracementsTextLocation
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolFibonacciTimeCircleDivideTimeSeparately
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolFibonacciTimeExtensions
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolFibonacciTimeExtensionsShowText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolGannFan
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolGannFanDisplayText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolGannFanFanDirection
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolGannFanPointsPerBar
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolHorizontalLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolPath
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolPathBegin
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolPathEnd
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolPathSegment
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolPathShowCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolPolygon
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolPriceLevelsOpacity
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRay
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRectangle
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegion
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegionHighlightDirection
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegionHighlightDirectionStroke
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegionHighlightHorizontalTextFormat
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegionHighlightVerticalRangeUnit
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegionHighlightVerticalTextFormat
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegionHiglightX
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegionHiglightY
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegressionChannel
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegressionChannelLowerChannel
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegressionChannelLowerChannelColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegressionChannelPriceType
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegressionChannelRegressionChannel
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegressionChannelStandardDeviationExtendLeft
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegressionChannelStandardDeviationExtendRight
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegressionChannelStandardDeviationLowerDistance
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegressionChannelStandardDeviationUpperDistance
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegressionChannelType
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegressionChannelUpperChannel
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRegressionChannelUpperChannelColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRiskRewardAnchorEntry
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRiskRewardAnchorLineStroke
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRiskRewardAnchorReward
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRiskRewardAnchorRisk
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRiskRewardCategoryColors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRiskRewardDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRiskRewardLineStrokeEntry
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRiskRewardLineStrokeReward
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRiskRewardLineStrokeRisk
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRiskRewardName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRiskRewardRatio
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRuler
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRulerDaysFormat
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRulerNumberBarsText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRulerTimeText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRulerYValueDisplayUnit
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolRulerYValueText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingTools
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolsChartArrowDownMarkerName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolsChartArrowUpMarkerName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolsChartDiamondMarkerName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolsChartDotMarkerName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolsChartSquareMarkerName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolsChartTriangleDownMarkerName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolsChartTriangleUpMarkerName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolsGannAngleRatioX
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolsGannAngleRatioY
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolsGannAngles
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolsGannAnglesPrompt
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolShapesAreaBrush
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolShapesOutlineBrush
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolsPriceLevelIsVisible
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolsPriceLevelLineStroke
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolsPriceLevels
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolsPriceLevelsPrompt
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolsPriceLevelUnset
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolsPriceLevelValue
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolStroke
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolTextAlignment
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolTextBackBrush
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolTextBrush
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolTextFixed
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolTextFixedTextPosition
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolTextFont
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolTextOutlineStroke
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolTextOutlineVisible
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolTimeCycles
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolTrendChannel
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolTrendChannelDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolTrendChannelEnd1AnchorDisplayName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolTrendChannelParallelStroke
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolTrendChannelStart1AnchorDisplayName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolTrendChannelStart2AnchorDisplayName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolTrendChannelTrendStroke
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolTriangle
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptDrawingToolVerticalLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptGeneral
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptGeneticOptimizerAveragePerformanceOffsetPercent
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptGeneticOptimizerConvergenceThreshold
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptGeneticOptimizerCrossoverIndex
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptGeneticOptimizerCrossoverRatePercent
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptGeneticOptimizerFastGenerations
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptGeneticOptimizerGenerations
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptGeneticOptimizerGenerationSize
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptGeneticOptimizerMinimumPerformance
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptGeneticOptimizerMutationRatePercent
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptGeneticOptimizerMutationStrengthPercent
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptGeneticOptimizerResetSizePercent
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptGeneticOptimizerSlowGenerations
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptGeneticOptimizerStabilitySizePercent
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptGeneticOptimizerThresholdGenerations
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicator
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorAvg
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDefault
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionADL
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionADX
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionADXR
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionAPZ
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionAroon
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionAroonOscillator
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionATR
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionBarTimer
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionBlockVolume
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionBollinger
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionBOP
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionBuySellPressure
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionBuySellVolume
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionCamarillaPivots
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionCandlestickPattern
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionCCI
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionChaikinMoneyFlow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionChaikinOscillator
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionChaikinVolatility
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionChoppinessIndex
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionCMO
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionConstantLines
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionCorrelation
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionCOT
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionCurrentDayOHL
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionDarvas
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionDEMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionDisparityIndex
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionDM
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionDMI
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionDMIndex
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionDonchianChannel
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionDoubleStochastics
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionEaseOfMovement
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionEMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionFibonacciPivots
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionFisherTransform
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionFOSC
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionHMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionKAMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionKeltnerChannel
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionKeyReversalDown
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionKeyReversalUp
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionLinReg
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionLinRegIntercept
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionLinRegSlope
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionMACD
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionMAEnvelopes
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionMAMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionMAX
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionMcClellanOscillator
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionMFI
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionMIN
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionMomentum
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionMoneyFlowOscillator
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionMovingAverageRibbon
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionNBarsDown
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionNBarsUp
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionNetChangeDisplay
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionOBV
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionParabolicSAR
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionPFE
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionPivots
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionPPO
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionPriceLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionPriceOscillator
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionPriorDayOHLC
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionPsychologicalLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionRange
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionRangeCounter
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionRegressionChannel
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionRelativeVigorIndex
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionRIND
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionROC
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionRSI
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionRSquared
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionRSS
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionRVI
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionSampleCustomRender
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionSMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionStdDev
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionStdError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionStochastics
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionStochasticsFast
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionStochRSI
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionSUM
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionSwing
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionT3
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionTEMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionTickCounter
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionTMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionTrendLines
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionTRIX
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionTSF
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionTSI
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionUltimateOscillator
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionVMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionVOL
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionVOLMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionVolumeCounter
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionVolumeOscillator
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionVolumeProfile
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionVolumeUpDown
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionVolumeZones
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionVortex
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionVROC
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionVWMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionWilliamsR
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionWMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionZigZag
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDescriptionZLEMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDiff
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDisparityLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorDown
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorLower
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorMcClellanOscillatorLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorMiddle
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorMoneyFlowLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameADL
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameADX
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameADXR
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameAPZ
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameAroon
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameAroonOscillator
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameATR
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameBarTimer
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameBlockVolume
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameBollinger
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameBOP
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameBuySellPressure
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameBuySellVolume
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameCamarillaPivots
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameCandlestickPattern
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameCCI
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameChaikinMoneyFlow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameChaikinOscillator
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameChaikinVolatility
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameChoppinessIndex
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameCMO
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameConstantLines
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameCorrelation
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameCOT
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameCurrentDayOHL
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameDarvas
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameDEMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameDisparityIndex
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameDM
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameDMI
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameDMIndex
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameDonchianChannel
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameDoubleStochastics
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameEaseOfMovement
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameEMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameFibonacciPivots
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameFisherTransform
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameFOSC
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameHMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameKAMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameKelterChannel
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameKeyReversalDown
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameKeyReversalUp
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameLinReg
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameLinRegIntercept
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameLinRegSlope
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameMACD
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameMAEnvelopes
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameMAMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameMAX
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameMcClellanOscillator
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameMFI
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameMIN
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameMomentum
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameMoneyFlowOscillator
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameMovingAverageRibbon
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameNBarsDown
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameNBarsUp
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameNetChangeDisplay
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameOBV
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameParabolicSAR
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNamePFE
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNamePivots
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNamePPO
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNamePriceLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNamePriceOscillator
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNamePriorDayOHLC
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNamePsychologicalLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameRange
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameRangeCounter
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameRegressionChannel
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameRelativeVigorIndex
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameRIND
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameROC
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameRSI
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameRSquared
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameRSS
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameRVI
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameSampleCustomRender
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameSMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameStdDev
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameStdError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameStochastics
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameStochasticsFast
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameStochRSI
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameSUM
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameSwing
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameT3
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameTEMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameTickCounter
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameTMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameTrendLines
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameTRIX
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameTSF
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameTSI
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameUltimateOscillator
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameVMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameVOL
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameVOLMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameVolumeCounter
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameVolumeOscillator
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameVolumeProfile
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameVolumesZones
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameVolumeUpDown
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameVortex
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameVROC
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameVWMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameWilliamsR
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameWMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameZigZag
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNameZLEMA
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorNeutral
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorOverbought
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorOverBoughtLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorOversold
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorOverSoldLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorRelativeVigorIndex
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorSignal
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorUp
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorUpper
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorVIMinus
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorVIPlus
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorVisualGroup
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIndicatorZeroLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptIsVisibleOnlyFocused
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptLines
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptLoadingData
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionAskPrice
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionAskSize
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionAverageDailyVolume
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionBeta
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionBidAskSpread
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionBidPrice
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionBidSize
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionCalendarYearHigh
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionCalendarYearHighDate
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionCalendarYearLow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionCalendarYearLowDate
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionChartMini
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionChartNetChange
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionCurrentRatio
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionDailyHigh
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionDailyLow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionDailyVolume
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionDaysUntilRollover
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionDividendAmount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionDividendPayDate
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionDividendYield
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionEarningsPerShare
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionFiveYearsGrowthPercentage
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionHigh52Weeks
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionHigh52WeeksDate
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionHistoricalVolatility
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionInstrument
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionLastClose
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionLastPrice
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionLastSize
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionLow52Weeks
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionLow52WeeksDate
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionMarketCap
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionMarketPrice
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionNetChange
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionNetChangeMaxDown
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionNetChangeMaxUp
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionNextYearsEarningsPerShare
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionNotes
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionOpening
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionOpenInterest
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionPercentHeldByInstitutions
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionPositionAvgPrice
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionPositionSize
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionPriceEarningsRatio
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionProfitLoss
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionRealizedProfitLoss
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionRevenuePerShare
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionSettlement
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionSharesOutstanding
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionShortInterest
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionShortInterestRatio
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionTimeLastTick
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionTradedContracts
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionTSTrend
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionUnrealizedProfitLoss
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnDescriptionVwap
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameAskPrice
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameAskSize
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameAverageDailyVolume
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameBeta
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameBidAskSpread
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameBidPrice
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameBidSize
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameCalendarYearHigh
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameCalendarYearHighDate
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameCalendarYearLow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameCalendarYearLowDate
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameChartMini
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameChartNetChange
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameCurrentRatio
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameDailyHigh
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameDailyLow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameDailyVolume
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameDaysUntilRollover
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameDividendAmount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameDividendPayDate
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameDividendYield
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameEarningsPerShare
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameFiveYearsGrowthPercentage
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameHigh52Weeks
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameHigh52WeeksDate
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameHistoricalVolatility
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameInstrument
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameLastClose
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameLastPrice
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameLastSize
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameLow52Weeks
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameLow52WeeksDate
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameMarketCap
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameMarketPrice
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameNetChange
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameNetChangeMaxDown
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameNetChangeMaxUp
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameNextYearsEarningsPerShare
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameNotes
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameOpening
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameOpenInterest
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNamePercentHeldByInstitutions
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNamePositionAvgPrice
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNamePositionSize
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNamePriceEarningsRatio
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameProfitLoss
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameRealizedProfitLoss
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameRevenuePerShare
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameSettlement
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameSharesOutstanding
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameShortInterest
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameShortInterestRatio
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameTimeLastTick
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameTradedContracts
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameTSTrend
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameUnrealizedProfitLoss
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptMarketAnalyzerColumnNameVwap
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptNumberOfRows
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOnBarCloseError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOnPriceChangeError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxAvgMfe
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxAvgMfeLong
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxAvgMfeShort
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxAvgProfit
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxAvgProfitLong
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxAvgProfitShort
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxNetProfit
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxNetProfitLong
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxNetProfitShort
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxPercentProfitable
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxPercentProfitableLong
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxPercentProfitableShort
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxProbablity
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxProbablityLong
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxProbablityShort
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxProfitFactor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxProfitFactorLong
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxProfitFactorShort
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxR2
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxR2Long
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxR2Short
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxSharpeRatio
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxSharpeRatioLong
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxSharpeRatioShort
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxSortinoRatio
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxSortinoRatioLong
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxSortinoRatioShort
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxStrength
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxStrengthLong
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxStrengthShort
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxUlcerRatio
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxUlcerRatioLong
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxUlcerRatioShort
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxWinLossRatio
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxWinLossRatioLong
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMaxWinLossRatioShort
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMinAvgMae
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMinAvgMaeLong
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMinAvgMaeShort
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMinDrawDown
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMinDrawDownLong
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizationFitnessNameMinDrawDownShort
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizerDefault
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptOptimizerGenetic
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptParameters
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyDescriptionSampleATMStrategy
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyDescriptionSampleCustomPerformance
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyDescriptionSampleFramework
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyDescriptionSampleMACrossOver
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyDescriptionSampleMultiInstrument
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyDescriptionSampleMultiTimeFrame
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyGenerator
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyGeneratorCandleStickPatternPrompt
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyGeneratorEntries
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyGeneratorEntriesOrExits
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyGeneratorIndicatorException
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyGeneratorIndicatorsPrompt
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyGeneratorPeformance
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyGeneratorProperties
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyGeneratorTerminated
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyGeneratorUseCandleStickPattern
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyGeneratorUseIndicators
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyNameSampleATMStrategy
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyNameSampleCustomPerformance
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyNameSampleFramework
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyNameSampleMACrossOver
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyNameSampleMultiInstrument
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyNameSampleMultiTimeFrame
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptStrategyParameters
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptSuperDomColumnApq
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptSuperDomColumnBaseInitializeBarsPoolError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptSuperDomColumnDescriptionApq
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptSuperDomColumnDescriptionNotes
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptSuperDomColumnDescriptionPnl
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptSuperDomColumnDescriptionVolume
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptSuperDomColumnNotes
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptSuperDomColumnProfitAndLoss
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptSuperDomColumnVolume
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptTileError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NinjaScriptYOffset
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NumberOfCotPlots
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NumberOfTrendLines
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string NumStdDev
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string OffsetMultiplier
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string OldTrendsOpacity
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Opacity
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PathCapMode_Arrow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PathCapMode_Line
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PathToolCapMode_Arrow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PathToolCapMode_Line
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PerformanceMetricSampleCumProfit
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Period
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PeriodD
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PeriodK
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PeriodQ
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PFEZero
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PiviotsDailyBarsError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PiviotsDailyDataError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PiviotsInsufficentDataError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PiviotsPeriodTypeError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PiviotsWeeklyBarsError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PivotRange
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PivotRange_Daily
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PivotRange_Monthly
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PivotRange_Weekly
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PivotsPP
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PivotsR1
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PivotsR2
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PivotsR3
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PivotsR4
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PivotsS1
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PivotsS2
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PivotsS3
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PivotsS4
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PlotCurrentValue
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PositiveColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PPOSmoothed
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PriceLinePlotAsk
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PriceLinePlotBid
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PriceLinePlotLast
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PriorDayOHLCClose
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PriorDayOHLCHigh
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PriorDayOHLCIntradayError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PriorDayOHLCLow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string PriorDayOHLCOpen
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string RangeCounterBarError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string RangeCounterRemaing
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string RangerCounterCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string RangeValue
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string RegionHighlightDirection_Horizontal
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string RegionHighlightDirection_Vertical
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string RegressionChannelType_Segment
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string RegressionChannelType_StandardDeviation
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ROCPeriod
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string RVISignalLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SampleAddOnDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SampleAddOnHiThere
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SampleAddOnName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SampleCumProfit
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SampleCumProfitDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SampleCustomPlotLowerRightCorner
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SampleCustomPlotUpperLeftCorner
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SelectPattern
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SelectPatternDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SendAlerts
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SendAlertsDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareArgsException
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareBadGatewayError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareBadRequestError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareException
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareFacebookCouldNotRetrieveUser
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareFacebookCouldNotVerifyToken
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareFacebookNoResult
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareFacebookPermissionDenied
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareFacebookScopesNotFound
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareFacebookSentSuccessfully
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareForbidden
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareGatewayTimeoutError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareImageNoLongerExists
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareInternalServerError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareMailException
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareMailPreconfiguredAol
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareMailPreconfiguredComcast
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareMailPreconfiguredGmail
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareMailPreconfiguredICloud
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareMailPreconfiguredManual
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareMailPreconfiguredOutlook
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareMailPreconfiguredYahoo
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareMailSendError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareMailSentSuccessfully
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareNonSuccessCode
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareNotAuthorized
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareServiceParameters
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareServicePassword
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareServiceSignature
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareServiceUserName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareStockTwitsNoAccount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareStockTwitsSentSuccessfully
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareTextMessageEmail
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareTextMessageEmailRequired
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareTextMessageErrorOnShare
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareTextMessageMmsAddress
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareTextMessageName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareTextMessagePhoneNumber
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareTextMessagePreconfiguredAtt
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareTextMessagePreconfiguredManual
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareTextMessagePreconfiguredSprint
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareTextMessagePreconfiguredTMobile
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareTextMessagePreconfiguredVerizon
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareTextMessageSentSuccessfully
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareTextMessageSmsAddress
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareTooManyRequests
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShareTwitterSentSuccessfully
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShowAskLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShowBidLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShowClose
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShowHigh
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShowLastLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShowLow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShowOpen
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShowPatternCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShowPatternCountDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ShowPercent
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SignalPeriod
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Slow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SlowLimit
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SlowPeriod
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SmallAreaColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Smooth
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Smoothing
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string StochasticsD
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string StochasticsK
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string StockTwitsSentiment
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string StockTwitsSentimentDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string StockTwitsServiceName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string StockTwitsSignature
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Strength
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SuperDomColumnException
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SwingHigh
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SwingLow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SwingSwingHighBarBarsAgoGreaterEqual
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SwingSwingHighBarBarsAgoOutOfRange
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SwingSwingHighBarInstanceGreaterEqual
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SwingSwingLowBarBarsAgoGreaterEqual
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SwingSwingLowBarBarsAgoOutOfRange
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string SwingSwingLowBarInstanceGreaterEqual
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TextColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TextFont
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TextFontDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TextPosition_BottomLeft
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TextPosition_BottomRight
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TextPosition_Center
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TextPosition_TopLeft
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TextPosition_TopRight
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TickCounterBarError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TickCounterTickCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TickCounterTicksRemaining
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TrendLinesCurrentTrendLine
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TrendLinesNotVisible
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TrendLinesTrendLineBroken
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TrendLinesTrendLineHigh
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TrendLinesTrendLineLow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TrendStrength
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TrendStrengthDescription
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TRIXSignal
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TwitterAuthHeader
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TwitterAuthText1
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TwitterAuthText2
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TwitterServiceName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string TwitterSignature
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Unit
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string UpBarColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string UseHighLow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string UserDefinedClose
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string UserDefinedHigh
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string UserDefinedLow
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string VFactor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string VolatilityPeriod
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string VolumeCounterBarError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string VolumeCounterVolumeCount
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string VolumeCounterVolumeRemaining
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string VolumeDivisor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string VolumeDown
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string VolumeDownColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string VolumeNeutralColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string VolumeUp
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string VolumeUpColor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string VOLVolume
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string Width
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string WilliamsPercentR
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ZigZagDeviationValueError
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ZigZagHighBarBarsAgoOutOfRange
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ZigZagHighBarInstanceGreaterEqual
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ZigZagLowBarBarsAgoOutOfRange
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ZigZagLowBarInstanceGreaterEqual
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ZigZigHighBarBarsAgoGreaterEqual
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public static string ZigZigLowBarBarsAgoGreaterEqual
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		internal Resource()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Resource()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
}
namespace NinjaTrader.NinjaScript.DrawingTools
{
	public abstract class PriceLevelContainer : DrawingTool
	{
		[PropertyEditor("NinjaTrader.Gui.Tools.CollectionEditor")]
		[SkipOnCopyTo(true)]
		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolsPriceLevels", Prompt = "NinjaScriptDrawingToolsPriceLevelsPrompt", GroupName = "NinjaScriptLines", Order = 99)]
		public List<PriceLevel> PriceLevels { get; set; }

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void CopyTo(NinjaScript ninjaScript)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected PriceLevelContainer()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetAllPriceLevelsRenderTarget()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static PriceLevelContainer()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class AndrewsPitchfork : PriceLevelContainer
	{
		[TypeConverter("NinjaTrader.Custom.ResourceEnumConverter")]
		public enum AndrewsPitchforkCalculationMethod
		{
			StandardPitchfork,
			Schiff,
			ModifiedSchiff
		}

		private const int cursorSensitivity = 15;

		private ChartAnchor editingAnchor;

		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolAnchor", GroupName = "NinjaScriptLines", Order = 1)]
		public Stroke AnchorLineStroke { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolAndrewsPitchforkCalculationMethod", GroupName = "NinjaScriptGeneral", Order = 4)]
		public AndrewsPitchforkCalculationMethod CalculationMethod { get; set; }

		[Display(Order = 3)]
		public ChartAnchor ExtensionAnchor { get; set; }

		[Display(Order = 2)]
		public ChartAnchor EndAnchor { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolAndrewsPitchforkRetracement", GroupName = "NinjaScriptLines", Order = 2)]
		public Stroke RetracementLineStroke { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolAndrewsPitchforkExtendLinesBack", GroupName = "NinjaScriptLines")]
		public bool IsExtendedLinesBack { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolFibonacciTimeExtensionsShowText", GroupName = "NinjaScriptGeneral")]
		public bool IsTextDisplayed { get; set; }

		public override object Icon => Icons.DrawAndrewsPitchfork;

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolPriceLevelsOpacity", GroupName = "NinjaScriptGeneral")]
		public int PriceLevelOpacity { get; set; }

		[Display(Order = 1)]
		public ChartAnchor StartAnchor { get; set; }

		public override bool SupportsAlerts => true;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected void DrawPriceLevelText(double minX, double maxX, Point endPoint, PriceLevel priceLevel, ChartPanel panel)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private IEnumerable<Tuple<Point, Point>> GetAndrewsEndPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsAlertConditionTrue(AlertConditionItem conditionItem, Condition condition, ChartAlertValue[] values, ChartControl chartControl, ChartScale chartScale)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseDown(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseUp(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static AndrewsPitchfork()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public static class Draw
	{
		private const int defaultRegionOpacity = 25;

		private static readonly Brush defaultRegionBrush;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static AndrewsPitchfork AndrewsPitchforkCore(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, DateTime anchor1Time, double anchor1Y, int anchor2BarsAgo, DateTime anchor2Time, double anchor2Y, int anchor3BarsAgo, DateTime anchor3Time, double anchor3Y, Brush brush, DashStyleHelper dashStyle, int width, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static AndrewsPitchfork AndrewsPitchfork(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static AndrewsPitchfork AndrewsPitchfork(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static AndrewsPitchfork AndrewsPitchfork(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static AndrewsPitchfork AndrewsPitchfork(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Arc ArcCore(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Arc Arc(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Arc Arc(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Arc Arc(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Arc Arc(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Arc Arc(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Arc Arc(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Arc Arc(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Arc Arc(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static T ChartMarkerCore<T>(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, DateTime time, double yVal, Brush brush, bool isGlobal, string templateName) where T : ChartMarker
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowDown ArrowDown(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowDown ArrowDown(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowDown ArrowDown(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowDown ArrowDown(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowDown ArrowDown(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowDown ArrowDown(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowUp ArrowUp(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowUp ArrowUp(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowUp ArrowUp(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowUp ArrowUp(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowUp ArrowUp(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowUp ArrowUp(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Diamond Diamond(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Diamond Diamond(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Diamond Diamond(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Diamond Diamond(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Diamond Diamond(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Diamond Diamond(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Dot Dot(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Dot Dot(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Dot Dot(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Dot Dot(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Dot Dot(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Dot Dot(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Square Square(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Square Square(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Square Square(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Square Square(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Square Square(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Square Square(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TriangleDown TriangleDown(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TriangleDown TriangleDown(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TriangleDown TriangleDown(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TriangleDown TriangleDown(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TriangleDown TriangleDown(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TriangleDown TriangleDown(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TriangleUp TriangleUp(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TriangleUp TriangleUp(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TriangleUp TriangleUp(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TriangleUp TriangleUp(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TriangleUp TriangleUp(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TriangleUp TriangleUp(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static T FibonacciCore<T>(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, bool isGlobal, string templateName) where T : FibonacciLevels
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static FibonacciExtensions FibonacciExtensionsCore(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, int extensionBarsAgo, DateTime extensionTime, double extensionY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static FibonacciCircle FibonacciCircle(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static FibonacciCircle FibonacciCircle(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static FibonacciCircle FibonacciCircle(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static FibonacciCircle FibonacciCircle(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static FibonacciExtensions FibonacciExtensions(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, int extensionBarsAgo, double extensionY)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static FibonacciExtensions FibonacciExtensions(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, DateTime extensionTime, double extensionY)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static FibonacciExtensions FibonacciExtensions(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, DateTime extensionTime, double extensionY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static FibonacciExtensions FibonacciExtensions(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, int extensionBarsAgo, double extensionY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static FibonacciRetracements FibonacciRetracements(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static FibonacciRetracements FibonacciRetracements(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static FibonacciRetracements FibonacciRetracements(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static FibonacciRetracements FibonacciRetracements(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static FibonacciTimeExtensions FibonacciTimeExtensions(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static FibonacciTimeExtensions FibonacciTimeExtensions(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static FibonacciTimeExtensions FibonacciTimeExtensions(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static FibonacciTimeExtensions FibonacciTimeExtensions(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static GannFan GannFanCore(NinjaScriptBase owner, bool isAutoScale, string tag, int barsAgo, DateTime time, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static GannFan GannFan(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static GannFan GannFan(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static GannFan GannFan(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static GannFan GannFan(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static T DrawLineTypeCore<T>(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool isGlobal, string templateName) where T : Line
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static ArrowLine ArrowLineCore(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowLine ArrowLine(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowLine ArrowLine(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowLine ArrowLine(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowLine ArrowLine(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowLine ArrowLine(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowLine ArrowLine(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ArrowLine ArrowLine(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static ExtendedLine ExtendedLineCore(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static HorizontalLine HorizontalLineCore(NinjaScriptBase owner, bool isAutoScale, string tag, double y, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		public static HorizontalLine HorizontalLine(NinjaScriptBase owner, string tag, double y, Brush brush)
		{
			return HorizontalLineCore(owner, isAutoScale: false, tag, y, brush, (DashStyleHelper)0, 1);
		}

		public static HorizontalLine HorizontalLine(NinjaScriptBase owner, string tag, double y, Brush brush, DashStyleHelper dashStyle, int width)
		{
			//IL_0005: Unknown result type (might be due to invalid IL or missing references)
			return HorizontalLineCore(owner, isAutoScale: false, tag, y, brush, dashStyle, width);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static HorizontalLine HorizontalLine(NinjaScriptBase owner, string tag, double y, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static HorizontalLine HorizontalLine(NinjaScriptBase owner, string tag, double y, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static HorizontalLine HorizontalLine(NinjaScriptBase owner, string tag, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static HorizontalLine HorizontalLine(NinjaScriptBase owner, string tag, bool isAutoScale, double y, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static HorizontalLine HorizontalLine(NinjaScriptBase owner, string tag, bool isAutoscale, double y, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Line Line(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Line Line(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Line Line(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Line Line(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Line Line(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Line Line(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Line Line(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Line Line(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Line Line(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Line Line(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static VerticalLine VerticalLineCore(NinjaScriptBase owner, bool isAutoScale, string tag, int barsAgo, DateTime time, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static VerticalLine VerticalLine(NinjaScriptBase owner, string tag, DateTime time, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static VerticalLine VerticalLine(NinjaScriptBase owner, string tag, DateTime time, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static VerticalLine VerticalLine(NinjaScriptBase owner, string tag, int barsAgo, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static VerticalLine VerticalLine(NinjaScriptBase owner, string tag, int barsAgo, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static VerticalLine VerticalLine(NinjaScriptBase owner, string tag, DateTime time, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static VerticalLine VerticalLine(NinjaScriptBase owner, string tag, int barsAgo, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static VerticalLine VerticalLine(NinjaScriptBase owner, string tag, int barsAgo, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static VerticalLine VerticalLine(NinjaScriptBase owner, string tag, DateTime time, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Ray RayCore(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ray Ray(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ray Ray(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ray Ray(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ray Ray(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ray Ray(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ray Ray(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ray Ray(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ray Ray(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static PathTool PathCore(NinjaScriptBase owner, string tag, bool isAutoScale, List<ChartAnchor> chartAnchors, Brush brush, DashStyleHelper dashStyle, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static PathTool PathBasic(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, DateTime anchor1Time, double anchor1Y, int anchor2BarsAgo, DateTime anchor2Time, double anchor2Y, int anchor3BarsAgo, DateTime anchor3Time, double anchor3Y, int anchor4BarsAgo, DateTime anchor4Time, double anchor4Y, int anchor5BarsAgo, DateTime anchor5Time, double anchor5Y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static PathTool PathTool(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static PathTool PathTool(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static PathTool PathTool(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y, int anchor4BarsAgo, double anchor4Y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static PathTool PathTool(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y, DateTime anchor4Time, double anchor4Y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static PathTool PathTool(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y, int anchor4BarsAgo, double anchor4Y, int anchor5BarsAgo, double anchor5Y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static PathTool PathTool(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y, DateTime anchor4Time, double anchor4Y, DateTime anchor5Time, double anchor5Y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static PathTool PathTool(NinjaScriptBase owner, string tag, bool isAutoScale, List<ChartAnchor> chartAnchors, Brush brush, DashStyleHelper dashStyle)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static PathTool PathTool(NinjaScriptBase owner, string tag, bool isAutoScale, List<ChartAnchor> chartAnchors, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Polygon PolygonCore(NinjaScriptBase owner, string tag, bool isAutoScale, List<ChartAnchor> chartAnchors, Brush brush, DashStyleHelper dashStyle, Brush areaBrush, int areaOpacity, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Polygon PolygonBasic(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, DateTime anchor1Time, double anchor1Y, int anchor2BarsAgo, DateTime anchor2Time, double anchor2Y, int anchor3BarsAgo, DateTime anchor3Time, double anchor3Y, int anchor4BarsAgo, DateTime anchor4Time, double anchor4Y, int anchor5BarsAgo, DateTime anchor5Time, double anchor5Y, int anchor6BarsAgo, DateTime anchor6Time, double anchor6Y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Polygon Polygon(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y, int anchor4BarsAgo, double anchor4Y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Polygon Polygon(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y, DateTime anchor4Time, double anchor4Y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Polygon Polygon(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y, int anchor4BarsAgo, double anchor4Y, int anchor5BarsAgo, double anchor5Y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Polygon Polygon(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y, DateTime anchor4Time, double anchor4Y, DateTime anchor5Time, double anchor5Y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Polygon Polygon(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y, int anchor4BarsAgo, double anchor4Y, int anchor5BarsAgo, double anchor5Y, int anchor6BarsAgo, double anchor6Y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Polygon Polygon(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y, DateTime anchor4Time, double anchor4Y, DateTime anchor5Time, double anchor5Y, DateTime anchor6Time, double anchor6Y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Polygon Polygon(NinjaScriptBase owner, string tag, bool isAutoScale, List<ChartAnchor> chartAnchors, Brush brush, DashStyleHelper dashStyle, Brush areaBrush, int areaOpacity)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Polygon Polygon(NinjaScriptBase owner, string tag, bool isAutoScale, List<ChartAnchor> chartAnchors, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Region Region(NinjaScriptBase owner, string tag, int startBarsAgo, DateTime startTime, int endBarsAgo, DateTime endTime, ISeries<double> series1, ISeries<double> series2, double price, Brush outlineBrush, Brush areaBrush, int areaOpacity, int displacement)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Region Region(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, ISeries<double> series, double price, Brush areaBrush, int areaOpacity, int displacement = 0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Region Region(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, ISeries<double> series1, ISeries<double> series2, Brush outlineBrush, Brush areaBrush, int areaOpacity, int displacement = 0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Region Region(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, ISeries<double> series, double price, Brush areaBrush, int areaOpacity)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Region Region(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, ISeries<double> series1, ISeries<double> series2, Brush outlineBrush, Brush areaBrush, int areaOpacity)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static T RegionHighlightCore<T>(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, Brush brush, Brush areaBrush, int areaOpacity, bool isGlobal, string templateName) where T : RegionHighlightBase
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CLSCompliant(false)]
		public static RegionHighlightX RegionHighlightX(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CLSCompliant(false)]
		public static RegionHighlightX RegionHighlightX(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CLSCompliant(false)]
		public static RegionHighlightX RegionHighlightX(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, Brush brush, Brush areaBrush, int areaOpacity)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CLSCompliant(false)]
		public static RegionHighlightX RegionHighlightX(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, Brush brush, Brush areaBrush, int areaOpacity)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CLSCompliant(false)]
		public static RegionHighlightX RegionHighlightX(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CLSCompliant(false)]
		public static RegionHighlightX RegionHighlightX(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CLSCompliant(false)]
		public static RegionHighlightY RegionHighlightY(NinjaScriptBase owner, string tag, double startY, double endY, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CLSCompliant(false)]
		public static RegionHighlightY RegionHighlightY(NinjaScriptBase owner, string tag, bool isAutoScale, double startY, double endY, Brush brush, Brush areaBrush, int areaOpacity)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CLSCompliant(false)]
		public static RegionHighlightY RegionHighlightY(NinjaScriptBase owner, string tag, double startY, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static RegressionChannel RegressionChannelCore(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, DateTime startTime, int endBarsAgo, DateTime endTime, Brush upperBrush, DashStyleHelper upperDashStyle, float? upperWidth, Brush middleBrush, DashStyleHelper middleDashStyle, float? middleWidth, Brush lowerBrush, DashStyleHelper lowerDashStyle, float? lowerWidth, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static RegressionChannel RegressionChannel(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static RegressionChannel RegressionChannel(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static RegressionChannel RegressionChannel(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, int endBarsAgo, Brush upperBrush, DashStyleHelper upperDashStyle, int upperWidth, Brush middleBrush, DashStyleHelper middleDashStyle, int middleWidth, Brush lowerBrush, DashStyleHelper lowerDashStyle, int lowerWidth)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static RegressionChannel RegressionChannel(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, DateTime endTime, Brush upperBrush, DashStyleHelper upperDashStyle, int upperWidth, Brush middleBrush, DashStyleHelper middleDashStyle, int middleWidth, Brush lowerBrush, DashStyleHelper lowerDashStyle, int lowerWidth)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static RegressionChannel RegressionChannel(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static RegressionChannel RegressionChannel(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static RiskReward RiskRewardCore(NinjaScriptBase owner, string tag, bool isAutoScale, int entryBarsAgo, DateTime entryTime, double entryY, int stopBarsAgo, DateTime stopTime, double stopY, int targetBarsAgo, DateTime targetTime, double targetY, double ratio, bool isStop, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static RiskReward RiskReward(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime entryTime, double entryY, DateTime endTime, double endY, double ratio, bool isStop)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static RiskReward RiskReward(NinjaScriptBase owner, string tag, bool isAutoScale, int entryBarsAgo, double entryY, int endBarsAgo, double endY, double ratio, bool isStop)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static RiskReward RiskReward(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime entryTime, double entryY, DateTime endTime, double endY, double ratio, bool isStop, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static RiskReward RiskReward(NinjaScriptBase owner, string tag, bool isAutoScale, int entryBarsAgo, double entryY, int endBarsAgo, double endY, double ratio, bool isStop, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Ruler RulerCore(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, int textBarsAgo, DateTime textTime, double textY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ruler Ruler(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, int textBarsAgo, double textY)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ruler Ruler(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, DateTime textTime, double textY)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ruler Ruler(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, int textBarsAgo, double textY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ruler Ruler(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, DateTime textTime, double textY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static T ShapeCore<T>(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, int endBarsAgo, DateTime startTime, DateTime endTime, double startY, double endY, Brush brush, Brush areaBrush, int areaOpacity, bool isGlobal, string templateName) where T : ShapeBase
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Triangle TriangleCore(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, int midBarsAgo, int endBarsAgo, DateTime startTime, DateTime midTime, DateTime endTime, double startY, double midY, double endY, Brush color, Brush areaColor, int areaOpacity, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ellipse Ellipse(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ellipse Ellipse(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, Brush areaBrush, int areaOpacity)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ellipse Ellipse(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ellipse Ellipse(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, Brush areaBrush, int areaOpacity)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ellipse Ellipse(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ellipse Ellipse(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, Brush areaBrush, int areaOpacity, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ellipse Ellipse(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ellipse Ellipse(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, Brush areaBrush, int areaOpacity, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ellipse Ellipse(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Ellipse Ellipse(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Rectangle Rectangle(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Rectangle Rectangle(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Rectangle Rectangle(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, Brush areaBrush, int areaOpacity)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Rectangle Rectangle(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, Brush areaBrush, int areaOpacity)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Rectangle Rectangle(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Rectangle Rectangle(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, Brush areaBrush, int areaOpacity, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Rectangle Rectangle(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, Brush areaBrush, int areaOpacity, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Rectangle Rectangle(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Rectangle Rectangle(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Triangle Triangle(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int middleBarsAgo, double middleY, int endBarsAgo, double endY, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Triangle Triangle(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime middleTime, double middleY, DateTime endTime, double endY, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Triangle Triangle(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int middleBarsAgo, double middleY, int endBarsAgo, double endY, Brush brush, Brush areaBrush, int areaOpacity)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Triangle Triangle(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime midTime, double middleY, DateTime endTime, double endY, Brush brush, Brush areaBrush, int areaOpacity)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Triangle Triangle(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int middleBarsAgo, double middleY, int endBarsAgo, double endY, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Triangle Triangle(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int middleBarsAgo, double middleY, int endBarsAgo, double endY, Brush brush, Brush areaBrush, int areaOpacity, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Triangle Triangle(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime midTime, double middleY, DateTime endTime, double endY, Brush brush, Brush areaBrush, int areaOpacity, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Triangle Triangle(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int middleBarsAgo, double middleY, int endBarsAgo, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Triangle Triangle(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime middleTime, double middleY, DateTime endTime, double endY, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Text TextCore(NinjaScriptBase owner, string tag, bool autoScale, string text, int barsAgo, DateTime time, double y, int? yPixelOffset, Brush textBrush, TextAlignment? textAlignment, SimpleFont font, Brush outlineBrush, Brush areaBrush, int? areaOpacity, bool isGlobal, string templateName, DashStyleHelper outlineDashStyle, int outlineWidth)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Text Text(NinjaScriptBase owner, string tag, string text, int barsAgo, double y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Text Text(NinjaScriptBase owner, string tag, string text, int barsAgo, double y, Brush textBrush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Text Text(NinjaScriptBase owner, string tag, string text, int barsAgo, double y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Text Text(NinjaScriptBase owner, string tag, bool isAutoScale, string text, int barsAgo, double y, int yPixelOffset, Brush textBrush, SimpleFont font, TextAlignment alignment, Brush outlineBrush, Brush areaBrush, int areaOpacity)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Text Text(NinjaScriptBase owner, string tag, bool isAutoScale, string text, DateTime time, double y, int yPixelOffset, Brush textBrush, SimpleFont font, TextAlignment alignment, Brush outlineBrush, Brush areaBrush, int areaOpacity)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Text Text(NinjaScriptBase owner, string tag, bool isAutoScale, string text, int barsAgo, double y, int yPixelOffset, Brush textBrush, SimpleFont font, TextAlignment alignment, Brush outlineBrush, Brush areaBrush, int areaOpacity, DashStyleHelper outlineDashStyle, int outlineWidth, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Text Text(NinjaScriptBase owner, string tag, bool isAutoScale, string text, DateTime time, double y, int yPixelOffset, Brush textBrush, SimpleFont font, TextAlignment alignment, Brush outlineBrush, Brush areaBrush, int areaOpacity, DashStyleHelper outlineDashStyle, int outlineWidth, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static TextFixed TextFixedCore(NinjaScriptBase owner, string tag, string text, TextPosition textPosition, Brush textBrush, SimpleFont font, Brush outlineBrush, Brush areaBrush, int? areaOpacity, bool isGlobal, string templateName, DashStyleHelper outlineDashStyle, int outlineWidth)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TextFixed TextFixed(NinjaScriptBase owner, string tag, string text, TextPosition textPosition, Brush textBrush, SimpleFont font, Brush outlineBrush, Brush areaBrush, int areaOpacity)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TextFixed TextFixed(NinjaScriptBase owner, string tag, string text, TextPosition textPosition, Brush textBrush, SimpleFont font, Brush outlineBrush, Brush areaBrush, int areaOpacity, DashStyleHelper outlineDashStyle, int outlineWidth, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TextFixed TextFixed(NinjaScriptBase owner, string tag, string text, TextPosition textPosition)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TextFixed TextFixed(NinjaScriptBase owner, string tag, string text, TextPosition textPosition, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static TimeCycles TimeCyclesCore(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, DateTime startTime, DateTime endTime, Brush brush, Brush areaBrush, int areaOpacity, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, Brush brush, Brush areaBrush, int areaOpacity)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, Brush brush)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, Brush brush, Brush areaBrush, int areaOpacity)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, Brush brush, Brush areaBrush, int areaOpacity, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, Brush brush, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, Brush brush, Brush areaBrush, int areaOpacity, bool drawOnPricePanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static TrendChannel TrendChannelCore(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, DateTime anchor1Time, double anchor1Y, int anchor2BarsAgo, DateTime anchor2Time, double anchor2Y, int anchor3BarsAgo, DateTime anchor3Time, double anchor3Y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TrendChannel TrendChannel(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TrendChannel TrendChannel(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TrendChannel TrendChannel(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y, bool isGlobal, string templateName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static TrendChannel TrendChannel(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y, bool isGlobal, string templateName)
		{
			return null;
		}

		static Draw()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
			defaultRegionBrush = Brushes.Goldenrod;
		}
	}
	public class Line : DrawingTool
	{
		protected enum ChartLineType
		{
			ArrowLine,
			ExtendedLine,
			HorizontalLine,
			Line,
			Ray,
			VerticalLine
		}

		private const double cursorSensitivity = 15.0;

		[CLSCompliant(false)]
		protected PathGeometry ArrowPathGeometry;

		private ChartAnchor editingAnchor;

		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		[Display(Order = 2)]
		public ChartAnchor EndAnchor { get; set; }

		[Display(Order = 1)]
		public ChartAnchor StartAnchor { get; set; }

		public override object Icon => Icons.DrawLineTool;

		[XmlIgnore]
		[Browsable(false)]
		protected ChartLineType LineType { get; set; }

		[Display(ResourceType = typeof(Resource), GroupName = "NinjaScriptGeneral", Name = "NinjaScriptDrawingToolLine", Order = 99)]
		public Stroke Stroke { get; set; }

		public override bool SupportsAlerts => true;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private ChartAnchor Anchor45(ChartAnchor starAnchort, ChartAnchor endAnchor, ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public sealed override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsAlertConditionTrue(AlertConditionItem conditionItem, Condition condition, ChartAlertValue[] values, ChartControl chartControl, ChartScale chartScale)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseDown(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseUp(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Line()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class Arc : Line
	{
		private PathGeometry arcGeometry;

		private Brush areaBrush;

		private readonly DeviceBrush areaBrushDevice;

		private int areaOpacity;

		private Point cachedStartPoint;

		private Point cachedEndPoint;

		[Display(ResourceType = typeof(Resource), GroupName = "NinjaScriptGeneral", Name = "NinjaScriptDrawingToolArc", Order = 99)]
		public Stroke ArcStroke { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolShapesAreaBrush", GroupName = "NinjaScriptGeneral", Order = 1)]
		[XmlIgnore]
		public Brush AreaBrush
		{
			get
			{
				return areaBrush;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Browsable(false)]
		public string AreaBrushSerialize
		{
			get
			{
				return Serialize.BrushToString(AreaBrush);
			}
			set
			{
				AreaBrush = Serialize.StringToBrush(value);
			}
		}

		[Range(0, 100)]
		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolAreaOpacity", GroupName = "NinjaScriptGeneral", Order = 2)]
		public int AreaOpacity
		{
			get
			{
				return areaOpacity;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		public override object Icon => Icons.DrawArc;

		public override bool SupportsAlerts => true;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool disposing)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<Condition> GetValidAlertConditions()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsAlertConditionTrue(AlertConditionItem conditionItem, Condition condition, ChartAlertValue[] values, ChartControl chartControl, ChartScale chartScale)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UpdateArcGeometry(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Arc()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Arc()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public abstract class ChartMarker : DrawingTool
	{
		private Brush areaBrush;

		[CLSCompliant(false)]
		protected DeviceBrush areaDeviceBrush;

		private Brush outlineBrush;

		[CLSCompliant(false)]
		protected DeviceBrush outlineDeviceBrush;

		public ChartAnchor Anchor { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolShapesAreaBrush", GroupName = "NinjaScriptGeneral", Order = 1)]
		[XmlIgnore]
		public Brush AreaBrush
		{
			get
			{
				return areaBrush;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Browsable(false)]
		public string AreaBrushSerialize
		{
			get
			{
				return Serialize.BrushToString(AreaBrush);
			}
			set
			{
				AreaBrush = Serialize.StringToBrush(value);
			}
		}

		protected double BarWidth
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return 0.0;
			}
		}

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolShapesOutlineBrush", GroupName = "NinjaScriptGeneral", Order = 2)]
		[XmlIgnore]
		public Brush OutlineBrush
		{
			get
			{
				return outlineBrush;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Browsable(false)]
		public string OutlineBrushSerialize
		{
			get
			{
				return Serialize.BrushToString(OutlineBrush);
			}
			set
			{
				OutlineBrush = Serialize.StringToBrush(value);
			}
		}

		public static float MinimumSize => 5f;

		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool disposing)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double GetSelectionSensitivity(ChartControl chartControl)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseDown(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseUp(ChartControl control, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected ChartMarker()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static ChartMarker()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class Dot : ChartMarker
	{
		public override object Icon => Icons.DrawDot;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Dot()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class Square : ChartMarker
	{
		public override object Icon => Icons.DrawSquare;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected void DrawSquare(float width, ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Square()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class Diamond : Square
	{
		public override object Icon => Icons.DrawDiamond;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Diamond()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public abstract class ArrowMarkerBase : ChartMarker
	{
		[XmlIgnore]
		[Browsable(false)]
		public bool IsUpArrow { get; protected set; }

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static ArrowMarkerBase()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class ArrowDown : ArrowMarkerBase
	{
		public override object Icon => Icons.DrawArrowDown;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static ArrowDown()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class ArrowUp : ArrowMarkerBase
	{
		public override object Icon => Icons.DrawArrowUp;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static ArrowUp()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public abstract class TriangleBase : ChartMarker
	{
		[XmlIgnore]
		[Browsable(false)]
		public bool IsUpTriangle { get; protected set; }

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static TriangleBase()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class TriangleDown : TriangleBase
	{
		public override object Icon => Icons.DrawTriangleDown;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static TriangleDown()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class TriangleUp : TriangleBase
	{
		public override object Icon => Icons.DrawTriangleUp;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static TriangleUp()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public abstract class FibonacciLevels : PriceLevelContainer
	{
		protected const int CursorSensitivity = 15;

		private int priceLevelOpacity;

		protected ChartAnchor editingAnchor;

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolFibonacciLevelsBaseAnchorLineStroke", GroupName = "NinjaScriptLines", Order = 1)]
		public Stroke AnchorLineStroke { get; set; }

		[Display(Order = 1)]
		public ChartAnchor StartAnchor { get; set; }

		[Display(Order = 2)]
		public ChartAnchor EndAnchor { get; set; }

		[Range(0, 100)]
		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolPriceLevelsOpacity", GroupName = "NinjaScriptGeneral")]
		public int PriceLevelOpacity
		{
			get
			{
				return priceLevelOpacity;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public override bool SupportsAlerts => true;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static FibonacciLevels()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class FibonacciRetracements : FibonacciLevels
	{
		public override object Icon => Icons.DrawFbRetracement;

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolFibonacciRetracementsExtendLinesRight", GroupName = "NinjaScriptLines")]
		public bool IsExtendedLinesRight { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolFibonacciRetracementsExtendLinesLeft", GroupName = "NinjaScriptLines")]
		public bool IsExtendedLinesLeft { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolFibonacciRetracementsTextLocation", GroupName = "NinjaScriptGeneral")]
		public TextLocation TextLocation { get; set; }

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected bool CheckAlertRetracementLine(Condition condition, Point lineStartPoint, Point lineEndPoint, ChartControl chartControl, ChartScale chartScale, ChartAlertValue[] values)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected void DrawPriceLevelText(ChartPanel chartPanel, ChartScale chartScale, double minX, double maxX, double y, double price, PriceLevel priceLevel)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected Tuple<Point, Point> GetPriceLevelLinePoints(PriceLevel priceLevel, ChartControl chartControl, ChartScale chartScale, bool isInverted)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private string GetPriceString(double price, PriceLevel priceLevel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsAlertConditionTrue(AlertConditionItem conditionItem, Condition condition, ChartAlertValue[] values, ChartControl chartControl, ChartScale chartScale)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseDown(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseUp(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static FibonacciRetracements()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	[TypeConverter("NinjaTrader.NinjaScript.DrawingTools.FibonacciCircleTimeTypeConverter")]
	public class FibonacciCircle : FibonacciRetracements
	{
		public override object Icon => Icons.DrawFbCircle;

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolFibonacciTimeExtensionsShowText", GroupName = "NinjaScriptGeneral")]
		public bool IsTextDisplayed { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolFibonacciTimeCircleDivideTimeSeparately", GroupName = "NinjaScriptGeneral", Order = 1)]
		public bool IsTimePriceDividedSeparately { get; set; }

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void DrawPriceLevelText(float textX, float textY, PriceLevel priceLevel, double yVal, ChartControl chartControl)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private string GetPriceString(double yVal, PriceLevel priceLevel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<Condition> GetValidAlertConditions()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsAlertConditionTrue(AlertConditionItem conditionItem, Condition condition, ChartAlertValue[] values, ChartControl chartControl, ChartScale chartScale)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static FibonacciCircle()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class FibonacciExtensions : FibonacciRetracements
	{
		private Point anchorExtensionPoint;

		[Display(Order = 3)]
		public ChartAnchor ExtensionAnchor { get; set; }

		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public override object Icon => Icons.DrawFbExtensions;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected new Tuple<Point, Point> GetPriceLevelLinePoints(PriceLevel priceLevel, ChartControl chartControl, ChartScale chartScale, bool isInverted)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private new void DrawPriceLevelText(ChartPanel chartPanel, ChartScale chartScale, double minX, double maxX, double y, double price, PriceLevel priceLevel)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Point GetEndLineMidpoint(ChartControl chartControl, ChartScale chartScale)
		{
			return default(Point);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public sealed override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private string GetPriceString(double price, PriceLevel priceLevel, ChartPanel chartPanel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Tuple<Point, Point> GetTranslatedExtensionYLine(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsAlertConditionTrue(AlertConditionItem conditionItem, Condition condition, ChartAlertValue[] values, ChartControl chartControl, ChartScale chartScale)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseDown(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static FibonacciExtensions()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	[TypeConverter("NinjaTrader.NinjaScript.DrawingTools.FibonacciCircleTimeTypeConverter")]
	public class FibonacciTimeExtensions : FibonacciRetracements
	{
		public override object Icon => Icons.DrawFbFbTimeExtensions;

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolFibonacciTimeExtensionsShowText", GroupName = "NinjaScriptGeneral")]
		public bool IsTextDisplayed { get; set; }

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<Condition> GetValidAlertConditions()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void DrawPriceLevelText(double x, PriceLevel priceLevel, ChartPanel chartPanel)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsAlertConditionTrue(AlertConditionItem conditionItem, Condition condition, ChartAlertValue[] values, ChartControl chartControl, ChartScale chartScale)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static FibonacciTimeExtensions()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class FibonacciCircleTimeTypeConverter : DrawingToolPropertiesConverter
	{
		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static FibonacciCircleTimeTypeConverter()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public abstract class GannAngleContainer : DrawingTool
	{
		[SkipOnCopyTo(true)]
		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolsGannAngles", Prompt = "NinjaScriptDrawingToolsGannAnglesPrompt", GroupName = "NinjaScriptGeneral", Order = 99)]
		[PropertyEditor("NinjaTrader.Gui.Tools.CollectionEditor")]
		public List<GannAngle> GannAngles { get; set; }

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void CopyTo(NinjaScript ninjaScript)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected GannAngleContainer()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static GannAngleContainer()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class GannFan : GannAngleContainer
	{
		[TypeConverter("NinjaTrader.Custom.ResourceEnumConverter")]
		public enum GannFanDirection
		{
			UpLeft,
			UpRight,
			DownLeft,
			DownRight
		}

		public ChartAnchor Anchor { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolGannFanFanDirection", GroupName = "NinjaScriptGeneral", Order = 3)]
		public GannFanDirection FanDirection { get; set; }

		public override object Icon => Icons.DrawGanFan;

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolGannFanDisplayText", GroupName = "NinjaScriptGeneral", Order = 2)]
		public bool IsTextDisplayed { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolGannFanPointsPerBar", GroupName = "NinjaScriptGeneral", Order = 4)]
		public double PointsPerBar { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolPriceLevelsOpacity", GroupName = "NinjaScriptGeneral")]
		public int PriceLevelOpacity { get; set; }

		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public override bool SupportsAlerts => true;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Point CalculateExtendedDataPoint(ChartPanel panel, ChartScale scale, int startX, double startPrice, Vector slope)
		{
			return default(Point);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private IEnumerable<Point> GetGannEndPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Point GetGannStepPoint(ChartScale scale, double startX, double startPrice, double deltaX, double deltaPrice)
		{
			return default(Point);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Vector GetGannStepDataVector(double deltaX, double deltaPrice)
		{
			return default(Vector);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<Condition> GetValidAlertConditions()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsAlertConditionTrue(AlertConditionItem conditionItem, Condition condition, ChartAlertValue[] values, ChartControl chartControl, ChartScale chartScale)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseDown(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		public override void OnMouseUp(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
			((DrawingTool)this).DrawingState = (DrawingState)2;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static GannFan()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	[TypeConverter("NinjaTrader.NinjaScript.DrawingTools.GannAngleTypeConverter")]
	public class GannAngle : NotifyPropertyChangedBase, IStrokeProvider, ICloneable
	{
		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolsGannAngleRatioX", GroupName = "NinjaScriptGeneral")]
		public double RatioX { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolsGannAngleRatioY", GroupName = "NinjaScriptGeneral")]
		public double RatioY { get; set; }

		[Browsable(false)]
		public string Name
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolsPriceLevelIsVisible", GroupName = "NinjaScriptGeneral")]
		public bool IsVisible { get; set; }

		[Browsable(false)]
		[XmlIgnore]
		public bool IsValueVisible { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolsPriceLevelLineStroke", GroupName = "NinjaScriptGeneral")]
		public Stroke Stroke { get; set; }

		[XmlIgnore]
		[Browsable(false)]
		public object Tag { get; set; }

		[MethodImpl(MethodImplOptions.NoInlining)]
		public object AssemblyClone(Type t)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual object Clone()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual void CopyTo(GannAngle other)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GannAngle()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public GannAngle(double ratioX, double ratioY, Brush strokeBrush)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static GannAngle()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class GannAngleTypeConverter : TypeConverter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object component, Attribute[] attrs)
		{
			return null;
		}

		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static GannAngleTypeConverter()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class ArrowLine : Line
	{
		public override object Icon => Icons.DrawArrowLine;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static ArrowLine()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class ExtendedLine : Line
	{
		public override object Icon => Icons.DrawExtendedLineTo;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static ExtendedLine()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class HorizontalLine : Line
	{
		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public override object Icon => Icons.DrawHorizLineTool;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static HorizontalLine()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class VerticalLine : Line
	{
		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public override object Icon => Icons.DrawVertLineTool;

		public override bool SupportsAlerts => false;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static VerticalLine()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class Ray : Line
	{
		public override object Icon => Icons.DrawRay;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Ray()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public abstract class PathToolSegmentContainer : DrawingTool
	{
		[Browsable(false)]
		[SkipOnCopyTo(true)]
		public List<PathToolSegment> PathToolSegments { get; set; }

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void CopyTo(NinjaScript ninjaScript)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected PathToolSegmentContainer()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static PathToolSegmentContainer()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class PathTool : PathToolSegmentContainer
	{
		[TypeConverter("NinjaTrader.Custom.ResourceEnumConverter")]
		public enum PathToolCapMode
		{
			Arrow,
			Line
		}

		private const double cursorSensitivity = 15.0;

		private PathGeometry arrowPathGeometry;

		private DispatcherTimer doubleClickTimer;

		private ChartAnchor editingAnchor;

		private bool firstTime = true;

		[Browsable(false)]
		[SkipOnCopyTo(true)]
		[ExcludeFromTemplate]
		public List<ChartAnchor> ChartAnchors { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolTextOutlineStroke", GroupName = "NinjaScriptGeneral", Order = 0)]
		public Stroke OutlineStroke { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolPathBegin", GroupName = "NinjaScriptGeneral", Order = 1)]
		public PathToolCapMode PathBegin { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolPathEnd", GroupName = "NinjaScriptGeneral", Order = 2)]
		public PathToolCapMode PathEnd { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolPathShowCount", GroupName = "NinjaScriptGeneral", Order = 3)]
		public bool ShowCount { get; set; }

		[ExcludeFromTemplate]
		[SkipOnCopyTo(true)]
		[Display(Order = 0)]
		public ChartAnchor StartAnchor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public override object Icon => Icons.DrawPath;

		public override bool SupportsAlerts => true;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void CopyTo(NinjaScript ninjaScript)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private PathGeometry CreatePathGeometry(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, double pixelAdjust)
		{
			return null;
		}

		private void DoubleClickTimerTick(object sender, EventArgs e)
		{
			doubleClickTimer.Stop();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Point[] GetPathAnchorPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		public override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return GetPathAnchorPoints(chartControl, chartScale);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<Condition> GetValidAlertConditions()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsAlertConditionTrue(AlertConditionItem conditionItem, Condition condition, ChartAlertValue[] values, ChartControl chartControl, ChartScale chartScale)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseDown(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseUp(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static PathTool()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class PathToolSegment : ICloneable
	{
		[Browsable(false)]
		public ChartAnchor EndAnchor { get; set; }

		[Browsable(false)]
		public string Name { get; set; }

		[Browsable(false)]
		public ChartAnchor StartAnchor { get; set; }

		[MethodImpl(MethodImplOptions.NoInlining)]
		public object AssemblyClone(Type t)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual object Clone()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual void CopyTo(PathToolSegment other)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PathToolSegment()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PathToolSegment(ChartAnchor startAnchor, ChartAnchor endAnchor, string name)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static PathToolSegment()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class Polygon : DrawingTool
	{
		private const double cursorSensitivity = 15.0;

		private Brush areaBrush;

		private readonly DeviceBrush areaBrushDevice;

		private int areaOpacity;

		private ChartAnchor editingAnchor;

		private bool firstTime;

		private DateTime lastClick;

		[XmlIgnore]
		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolShapesAreaBrush", GroupName = "NinjaScriptGeneral", Order = 0)]
		public Brush AreaBrush
		{
			get
			{
				return areaBrush;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Browsable(false)]
		public string AreaBrushSerialize
		{
			get
			{
				return Serialize.BrushToString(AreaBrush);
			}
			set
			{
				AreaBrush = Serialize.StringToBrush(value);
			}
		}

		[Range(0, 100)]
		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolAreaOpacity", GroupName = "NinjaScriptGeneral", Order = 1)]
		public int AreaOpacity
		{
			get
			{
				return areaOpacity;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		public override object Icon => Icons.DrawPolygon;

		[Browsable(false)]
		[SkipOnCopyTo(true)]
		[ExcludeFromTemplate]
		public List<ChartAnchor> ChartAnchors { get; set; }

		[Display(Order = 0)]
		[ExcludeFromTemplate]
		[SkipOnCopyTo(true)]
		public ChartAnchor StartAnchor
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolTextOutlineStroke", GroupName = "NinjaScriptGeneral", Order = 2)]
		public Stroke OutlineStroke { get; set; }

		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public override bool SupportsAlerts => true;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void CopyTo(NinjaScript ninjaScript)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private PathGeometry CreatePolygonGeometry(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, double pixelAdjust)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool disposing)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Point[] GetPolygonAnchorPoints(ChartControl chartControl, ChartScale chartScale, bool includeCentroid)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Point[] GetCentroid(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<Condition> GetValidAlertConditions()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsAlertConditionTrue(AlertConditionItem conditionItem, Condition condition, ChartAlertValue[] values, ChartControl chartControl, ChartScale chartScale)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool IsPointInsidePolygon(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point p)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseDown(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseUp(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Polygon()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Polygon()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	[XmlInclude(typeof(GannAngle))]
	[XmlInclude(typeof(TrendLevel))]
	[CategoryDefaultExpanded(true)]
	[TypeConverter("NinjaTrader.NinjaScript.DrawingTools.PriceLevelTypeConverter")]
	public class PriceLevel : NotifyPropertyChangedBase, IStrokeProvider, ICloneable
	{
		private double value;

		private string name;

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolsPriceLevelIsVisible", GroupName = "NinjaScriptGeneral")]
		public bool IsVisible { get; set; }

		[XmlIgnore]
		[Browsable(false)]
		public bool IsValueVisible { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolsPriceLevelLineStroke", GroupName = "NinjaScriptGeneral")]
		public Stroke Stroke { get; set; }

		[Browsable(false)]
		[XmlIgnore]
		public object Tag { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolsPriceLevelValue", GroupName = "NinjaScriptGeneral")]
		public double Value
		{
			get
			{
				return value;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Browsable(false)]
		[XmlIgnore]
		public Func<double, string> ValueFormatFunc { get; set; }

		[Browsable(false)]
		public string Name
		{
			get
			{
				return name;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual object Clone()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public object AssemblyClone(Type t)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual void CopyTo(PriceLevel other)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double GetPrice(double startPrice, double totalPriceRange, bool isInverted)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public float GetY(ChartScale chartScale, double startPrice, double totalPriceRange, bool isInverted)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PriceLevel()
		{
		}

		public PriceLevel(double value, Brush brush)
			: this(value, brush, 2f)
		{
		}

		public PriceLevel(double value, Brush brush, float strokeWidth)
			: this(value, brush, strokeWidth, (DashStyleHelper)0, 100)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PriceLevel(double value, Brush brush, float strokeWidth, DashStyleHelper dashStyle, int opacity)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static PriceLevel()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class PriceLevelTypeConverter : TypeConverter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object component, Attribute[] attrs)
		{
			return null;
		}

		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static PriceLevelTypeConverter()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class Region : DrawingTool
	{
		private int areaOpacity;

		private Brush areaBrush;

		private readonly DeviceBrush areaBrushDevice;

		public ChartAnchor StartAnchor { get; set; }

		public ChartAnchor EndAnchor { get; set; }

		[XmlIgnore]
		[Browsable(false)]
		public ISeries<double> Series1 { get; set; }

		[Browsable(false)]
		[XmlIgnore]
		public ISeries<double> Series2 { get; set; }

		[Browsable(false)]
		public double Price { get; set; }

		[Browsable(false)]
		public int Displacement { get; set; }

		[XmlIgnore]
		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolShapesAreaBrush", GroupName = "NinjaScriptGeneral", Order = 4)]
		public Brush AreaBrush
		{
			get
			{
				return areaBrush;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Browsable(false)]
		public string AreaBrushSerialize
		{
			get
			{
				return Serialize.BrushToString(AreaBrush);
			}
			set
			{
				AreaBrush = Serialize.StringToBrush(value);
			}
		}

		[Range(0, 100)]
		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolAreaOpacity", GroupName = "NinjaScriptGeneral", Order = 5)]
		public int AreaOpacity
		{
			get
			{
				return areaOpacity;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolTextOutlineStroke", GroupName = "NinjaScriptGeneral", Order = 6)]
		public Stroke OutlineStroke { get; set; }

		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool disposing)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Region()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Region()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	internal enum RegionHighlightMode
	{
		Time,
		Price
	}
	[CLSCompliant(false)]
	public abstract class RegionHighlightBase : DrawingTool
	{
		private const double cursorSensitivity = 15.0;

		private int areaOpacity;

		private Brush areaBrush;

		private readonly DeviceBrush areaBrushDevice;

		private ChartAnchor editingAnchor;

		private bool hasSetZOrder;

		public override bool SupportsAlerts => true;

		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRiskRewardAnchorLineStroke", GroupName = "NinjaScriptGeneral", Order = 5)]
		public Stroke AnchorLineStroke { get; set; }

		[XmlIgnore]
		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolShapesAreaBrush", GroupName = "NinjaScriptGeneral", Order = 3)]
		public Brush AreaBrush
		{
			get
			{
				return areaBrush;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Browsable(false)]
		public string AreaBrushSerialize
		{
			get
			{
				return Serialize.BrushToString(AreaBrush);
			}
			set
			{
				AreaBrush = Serialize.StringToBrush(value);
			}
		}

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolAreaOpacity", GroupName = "NinjaScriptGeneral", Order = 4)]
		[Range(0, 100)]
		public int AreaOpacity
		{
			get
			{
				return areaOpacity;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Display(Order = 2)]
		public ChartAnchor EndAnchor { get; set; }

		[XmlIgnore]
		[Browsable(false)]
		internal RegionHighlightMode Mode { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolTextOutlineStroke", GroupName = "NinjaScriptGeneral", Order = 6)]
		public Stroke OutlineStroke { get; set; }

		[Display(Order = 1)]
		public ChartAnchor StartAnchor { get; set; }

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool disposing)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<Condition> GetValidAlertConditions()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsAlertConditionTrue(AlertConditionItem conditionItem, Condition condition, ChartAlertValue[] values, ChartControl chartControl, ChartScale chartScale)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseDown(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseUp(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected RegionHighlightBase()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static RegionHighlightBase()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	[CLSCompliant(false)]
	public class RegionHighlightX : RegionHighlightBase
	{
		public override object Icon => Icons.DrawRegionHighlightX;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static RegionHighlightX()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	[CLSCompliant(false)]
	public class RegionHighlightY : RegionHighlightBase
	{
		public override object Icon => Icons.DrawRegionHighlightY;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static RegionHighlightY()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class RegressionChannelTypeConverter : DrawingToolPropertiesConverter
	{
		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static RegressionChannelTypeConverter()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	[TypeConverter("NinjaTrader.NinjaScript.DrawingTools.RegressionChannelTypeConverter")]
	public class RegressionChannel : DrawingTool
	{
		[TypeConverter("NinjaTrader.Custom.ResourceEnumConverter")]
		public enum RegressionChannelType
		{
			Segment,
			StandardDeviation
		}

		private ChartControl cControl;

		private ChartScale cScale;

		private ChartAnchor editingAnchor;

		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRegressionChannelType", GroupName = "NinjaScriptGeneral", Order = 2)]
		public RegressionChannelType ChannelType { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRegressionChannelStandardDeviationExtendLeft", GroupName = "NinjaScriptLines")]
		public bool ExtendLeft { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRegressionChannelStandardDeviationExtendRight", GroupName = "NinjaScriptLines")]
		public bool ExtendRight { get; set; }

		[Display(Order = 2)]
		public ChartAnchor EndAnchor { get; set; }

		public override object Icon => Icons.DrawRegressionChannel;

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRegressionChannelLowerChannel", GroupName = "NinjaScriptLines", Order = 3)]
		public Stroke LowerChannelStroke { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRegressionChannelRegressionChannel", GroupName = "NinjaScriptLines", Order = 2)]
		public Stroke RegressionStroke { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRegressionChannelPriceType", GroupName = "NinjaScriptGeneral", Order = 1)]
		public PriceType PriceType { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRegressionChannelStandardDeviationUpperDistance", GroupName = "NinjaScriptGeneral", Order = 3)]
		public double StandardDeviationUpperDistance { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRegressionChannelStandardDeviationLowerDistance", GroupName = "NinjaScriptGeneral", Order = 4)]
		public double StandardDeviationLowerDistance { get; set; }

		[Display(Order = 1)]
		public ChartAnchor StartAnchor { get; set; }

		public override bool SupportsAlerts => true;

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRegressionChannelUpperChannel", GroupName = "NinjaScriptLines", Order = 1)]
		public Stroke UpperChannelStroke { get; set; }

		public override void AddPastedOffset(ChartPanel panel, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double[] CalculateRegressionPriceValues(Bars baseBars, int startIndex, int endIndex)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Point[] CreateRegressionPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double GetBarPrice(Bars barObject, int barIndex)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsAlertConditionTrue(AlertConditionItem conditionItem, Condition condition, ChartAlertValue[] values, ChartControl chartControl, ChartScale chartScale)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnBarsChanged()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseDown(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseUp(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void SetAnchorsToRegression(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static RegressionChannel()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class RiskReward : DrawingTool
	{
		private const int cursorSensitivity = 15;

		private ChartAnchor editingAnchor;

		private double entryPrice;

		private bool needsRatioUpdate;

		private double ratio;

		private double risk;

		private double reward;

		private double stopPrice;

		private double targetPrice;

		private double textleftPoint;

		private double textRightPoint;

		[Browsable(false)]
		private bool DrawTarget
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return false;
			}
		}

		[Display(Order = 1)]
		public ChartAnchor EntryAnchor { get; set; }

		[Display(Order = 2)]
		public ChartAnchor RiskAnchor { get; set; }

		[Browsable(false)]
		public ChartAnchor RewardAnchor { get; set; }

		public override object Icon => Icons.DrawRiskReward;

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRiskRewardRatio", GroupName = "NinjaScriptGeneral", Order = 1)]
		[NinjaScriptProperty]
		[Range(0.0, double.MaxValue)]
		public double Ratio
		{
			get
			{
				return ratio;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolAnchor", GroupName = "NinjaScriptLines", Order = 3)]
		public Stroke AnchorLineStroke { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRiskRewardLineStrokeEntry", GroupName = "NinjaScriptLines", Order = 6)]
		public Stroke EntryLineStroke { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRiskRewardLineStrokeRisk", GroupName = "NinjaScriptLines", Order = 4)]
		public Stroke StopLineStroke { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRiskRewardLineStrokeReward", GroupName = "NinjaScriptLines", Order = 5)]
		public Stroke TargetLineStroke { get; set; }

		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolFibonacciRetracementsExtendLinesRight", GroupName = "NinjaScriptLines", Order = 2)]
		public bool IsExtendedLinesRight { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolFibonacciRetracementsExtendLinesLeft", GroupName = "NinjaScriptLines", Order = 1)]
		public bool IsExtendedLinesLeft { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolTextAlignment", GroupName = "NinjaScriptGeneral", Order = 2)]
		public TextLocation TextAlignment { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRulerYValueDisplayUnit", GroupName = "NinjaScriptGeneral", Order = 3)]
		public ValueUnit DisplayUnit { get; set; }

		public override bool SupportsAlerts => true;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void DrawPriceText(ChartAnchor anchor, Point point, double price, ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private string GetPriceString(double price, ChartBars chartBars)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsAlertConditionTrue(AlertConditionItem conditionItem, Condition condition, ChartAlertValue[] values, ChartControl chartControl, ChartScale chartScale)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseDown(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseUp(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetReward()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetRisk()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public RiskReward()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static RiskReward()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class Ruler : DrawingTool
	{
		private const int cursorSensitivity = 15;

		private const float textMargin = 3f;

		private ChartAnchor editingAnchor;

		private bool isTextCreated;

		private TextFormat textFormat;

		private TextLayout textLayout;

		private Brush textBrush;

		private readonly DeviceBrush textDeviceBrush;

		private readonly DeviceBrush textBackgroundDeviceBrush;

		private string yValueString;

		private string timeText;

		private ValueUnit yValueDisplayUnit;

		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		[Display(Order = 1)]
		public ChartAnchor StartAnchor { get; set; }

		[Display(Order = 2)]
		public ChartAnchor EndAnchor { get; set; }

		[Display(Order = 3)]
		public ChartAnchor TextAnchor { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolAnchor", GroupName = "NinjaScriptGeneral", Order = 2)]
		public Stroke LineColor { get; set; }

		private bool ShouldDrawText
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return false;
			}
		}

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolText", GroupName = "NinjaScriptGeneral", Order = 1)]
		[XmlIgnore]
		public Brush TextColor
		{
			get
			{
				return textBrush;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Browsable(false)]
		public string TextColorSerialize
		{
			get
			{
				return Serialize.BrushToString(TextColor);
			}
			set
			{
				TextColor = Serialize.StringToBrush(value);
			}
		}

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRulerYValueDisplayUnit", GroupName = "NinjaScriptGeneral", Order = 3)]
		public ValueUnit YValueDisplayUnit
		{
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return yValueDisplayUnit;
			}
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				yValueDisplayUnit = value;
				isTextCreated = false;
			}
		}

		public override object Icon => Icons.DrawRuler;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool disposing)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public sealed override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		public override void OnBarsChanged()
		{
			isTextCreated = false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseDown(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseUp(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UpdateTextLayout(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Ruler()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Ruler()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public abstract class ShapeBase : DrawingTool
	{
		protected enum ChartShapeType
		{
			Unset,
			Ellipse,
			Rectangle,
			Triangle
		}

		protected enum ResizeMode
		{
			None,
			TopLeft,
			TopRight,
			BottomLeft,
			BottomRight,
			MoveAll
		}

		private const double cursorSensitivity = 15.0;

		private int areaOpacity;

		private Brush areaBrush;

		private readonly DeviceBrush areaBrushDevice;

		private ChartAnchor editingAnchor;

		private ChartAnchor editingLeftAnchor;

		private ChartAnchor editingTopAnchor;

		private ChartAnchor editingBottomAnchor;

		private ChartAnchor editingRightAnchor;

		private ChartAnchor lastMouseMoveDataPoint;

		private ResizeMode resizeMode;

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolShapesAreaBrush", GroupName = "NinjaScriptGeneral", Order = 1)]
		[XmlIgnore]
		public Brush AreaBrush
		{
			get
			{
				return areaBrush;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Browsable(false)]
		public string AreaBrushSerialize
		{
			get
			{
				return Serialize.BrushToString(AreaBrush);
			}
			set
			{
				AreaBrush = Serialize.StringToBrush(value);
			}
		}

		[Range(0, 100)]
		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolAreaOpacity", GroupName = "NinjaScriptGeneral", Order = 2)]
		public int AreaOpacity
		{
			get
			{
				return areaOpacity;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolTextOutlineStroke", GroupName = "NinjaScriptGeneral", Order = 3)]
		public Stroke OutlineStroke { get; set; }

		[Display(Order = 2)]
		public ChartAnchor EndAnchor { get; set; }

		[Display(Order = 3)]
		public ChartAnchor MiddleAnchor { get; set; }

		[Display(Order = 1)]
		public ChartAnchor StartAnchor { get; set; }

		[Browsable(false)]
		protected ChartShapeType ShapeType { get; set; }

		public override bool SupportsAlerts => true;

		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private PathGeometry CreateTriangleGeometry(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, double pixelAdjust)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool disposing)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Rect GetAnchorsRect(ChartControl chartControl, ChartScale chartScale)
		{
			return default(Rect);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Point? GetClosestPoint(IEnumerable<Point> inputPoints, Point desired, bool useSensitivity)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Point[] GetEllipseAnchorPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private ResizeMode GetResizeModeForPoint(Point pt, ChartControl chartControl, ChartScale chartScale, bool useCursorSens)
		{
			return default(ResizeMode);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public sealed override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Point[] GetTriangleAnchorPoints(ChartControl chartControl, ChartScale chartScale, bool includeCentroid)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<Condition> GetValidAlertConditions()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsAlertConditionTrue(AlertConditionItem conditionItem, Condition condition, ChartAlertValue[] values, ChartControl chartControl, ChartScale chartScale)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseDown(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseUp(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected ShapeBase()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static ShapeBase()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class Ellipse : ShapeBase
	{
		public override object Icon => Icons.DrawElipse;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Ellipse()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class Rectangle : ShapeBase
	{
		public override object Icon => Icons.DrawRectangle;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Rectangle()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class Triangle : ShapeBase
	{
		public override object Icon => Icons.DrawTriangle;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Triangle()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class Text : DrawingTool
	{
		private Brush areaBrush;

		private DeviceBrush areaBrushDevice;

		private int areaOpacity;

		private TextAlignment alignment;

		[CLSCompliant(false)]
		protected TextLayout cachedTextLayout;

		private SimpleFont font;

		private Rect layoutRect;

		private bool needsLayoutUpdate;

		private readonly float outlinePadding;

		private Brush textBrush;

		private DeviceBrush textBrushDevice;

		private string text;

		private Popup popup;

		public override object Icon => Icons.DrawText;

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolTextAlignment", GroupName = "NinjaScriptGeneral", Order = 7)]
		public TextAlignment Alignment
		{
			get
			{
				return alignment;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Browsable(false)]
		[XmlIgnore]
		public bool UseChartTextBrush { get; set; }

		[Browsable(false)]
		public bool UseChartTextBrushSerialize
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return false;
			}
			set
			{
				UseChartTextBrush = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ManuallyDrawn { get; set; }

		[Browsable(false)]
		[XmlIgnore]
		public Brush LastBrush { get; set; }

		public ChartAnchor Anchor { get; set; }

		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolShapesAreaBrush", GroupName = "NinjaScriptGeneral", Order = 1)]
		[XmlIgnore]
		public Brush AreaBrush
		{
			get
			{
				return areaBrush;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Browsable(false)]
		public string AreaBrushSerialize
		{
			get
			{
				return Serialize.BrushToString(AreaBrush);
			}
			set
			{
				AreaBrush = Serialize.StringToBrush(value);
			}
		}

		[Range(0, 100)]
		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolAreaOpacity", GroupName = "NinjaScriptGeneral", Order = 2)]
		public int AreaOpacity
		{
			get
			{
				return areaOpacity;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolTextFont", GroupName = "NinjaScriptGeneral", Order = 4)]
		public SimpleFont Font
		{
			get
			{
				return font;
			}
			set
			{
				font = value;
				needsLayoutUpdate = true;
			}
		}

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolTextOutlineStroke", GroupName = "NinjaScriptGeneral", Order = 3)]
		public Stroke OutlineStroke { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolText", GroupName = "NinjaScriptGeneral", Order = 5)]
		[ExcludeFromTemplate]
		[PropertyEditor("NinjaTrader.Gui.Tools.MultilineEditor")]
		public string DisplayText
		{
			get
			{
				return text;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[XmlIgnore]
		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolTextBrush", GroupName = "NinjaScriptGeneral", Order = 1)]
		public Brush TextBrush
		{
			get
			{
				return textBrush;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Browsable(false)]
		public string TextBrushSerialize
		{
			get
			{
				return Serialize.BrushToString(TextBrush);
			}
			set
			{
				TextBrush = Serialize.StringToBrush(value);
			}
		}

		[Browsable(false)]
		public int YPixelOffset { get; set; }

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool disposing)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void DrawText(ChartControl chartControl)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected virtual Rect GetCurrentRect(Rect pLayoutRect, double pOutlinePadding)
		{
			return default(Rect);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static float GetPadding()
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected virtual Point GetTextDrawingPosition(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale)
		{
			return default(Point);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseDown(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void OnChartMouseDown(object sender, MouseButtonEventArgs e)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		public override void OnMouseUp(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
			((DrawingTool)this).DrawingState = (DrawingState)2;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UpdateTextLayout(float maxWidth)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Text()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Text()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	[TypeConverter("NinjaTrader.Custom.ResourceEnumConverter")]
	public enum TextPosition
	{
		BottomLeft,
		BottomRight,
		Center,
		TopLeft,
		TopRight
	}
	public class TextFixed : Text
	{
		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolTextFixedTextPosition", GroupName = "NinjaScriptGeneral")]
		public TextPosition TextPosition { get; set; }

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private int PaddingMultiplier(ChartControl chartControl, ChartPanel panel, bool top)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override Point GetTextDrawingPosition(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale)
		{
			return default(Point);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override Rect GetCurrentRect(Rect layoutRect, double outlinePadding)
		{
			return default(Rect);
		}

		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static TextFixed()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class TimeCycles : DrawingTool
	{
		private const int cursorSensitivity = 15;

		private Brush areaBrush;

		private readonly DeviceBrush areaBrushDevice;

		private int areaOpacity;

		private List<int> anchorBars;

		private int diameter;

		private bool firstTime;

		private int radius;

		[XmlIgnore]
		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolShapesAreaBrush", GroupName = "NinjaScriptGeneral", Order = 0)]
		public Brush AreaBrush
		{
			get
			{
				return areaBrush;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Browsable(false)]
		public string AreaBrushSerialize
		{
			get
			{
				return Serialize.BrushToString(AreaBrush);
			}
			set
			{
				AreaBrush = Serialize.StringToBrush(value);
			}
		}

		[Range(0, 100)]
		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolAreaOpacity", GroupName = "NinjaScriptGeneral", Order = 1)]
		public int AreaOpacity
		{
			get
			{
				return areaOpacity;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		public override object Icon => Icons.DrawTimeCycles;

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolTextOutlineStroke", GroupName = "NinjaScriptGeneral", Order = 2)]
		public Stroke OutlineStroke { get; set; }

		[Browsable(false)]
		public ChartAnchor StartAnchor { get; set; }

		[Browsable(false)]
		public ChartAnchor EndAnchor { get; set; }

		[Display(ResourceType = typeof(ChartResources), GroupName = "GuiChartsCategoryData", Name = "GuiChartsChartAnchorStartTime", Order = 0)]
		[PropertyEditor("NinjaTrader.Gui.Tools.ChartAnchorTimeEditor")]
		public DateTime StartTime
		{
			get
			{
				return StartAnchor.Time;
			}
			set
			{
				StartAnchor.Time = value;
			}
		}

		[PropertyEditor("NinjaTrader.Gui.Tools.ChartAnchorTimeEditor")]
		[Display(ResourceType = typeof(ChartResources), GroupName = "GuiChartsCategoryData", Name = "GuiChartsChartAnchorEndTime", Order = 1)]
		public DateTime EndTime
		{
			get
			{
				return EndAnchor.Time;
			}
			set
			{
				EndAnchor.Time = value;
			}
		}

		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public override bool SupportsAlerts => true;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool disposing)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private ChartBars GetChartBars()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private int GetClosestBarAnchor(ChartControl chartControl, Point p, bool ignoreHitTest)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<Condition> GetValidAlertConditions()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsAlertConditionTrue(AlertConditionItem conditionItem, Condition condition, ChartAlertValue[] values, ChartControl chartControl, ChartScale chartScale)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool IsPointInsideTimeCycles(ChartPanel chartPanel, Point p)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool IsPointOnTimeCyclesOutline(ChartControl chartControl, ChartPanel chartPanel, Point p)
		{
			return false;
		}

		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseDown(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseUp(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UpdateAnchors(ChartControl chartControl, int startX)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TimeCycles()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static TimeCycles()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class TrendChannel : PriceLevelContainer
	{
		private const double cursorSensitivity = 15.0;

		private int areaOpacity;

		private Brush areaBrush;

		private readonly DeviceBrush areaDeviceBrush;

		private ChartAnchor editingAnchor;

		private PathGeometry fillMainGeometry;

		private Vector2[] fillMainFig;

		private PathGeometry fillLeftGeometry;

		private Vector2[] fillLeftFig;

		private PathGeometry fillRightGeometry;

		private Vector2[] fillRightFig;

		private bool isReadyForMovingSecondLeg;

		private bool updateEndAnc;

		public override object Icon => Icons.DrawTrendChannel;

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolShapesAreaBrush", GroupName = "NinjaScriptGeneral", Order = 1)]
		[XmlIgnore]
		public Brush AreaBrush
		{
			get
			{
				return areaBrush;
			}
			set
			{
				areaBrush = BrushExtensions.ToFrozenBrush(value);
			}
		}

		[Browsable(false)]
		public string AreaBrushSerialize
		{
			get
			{
				return Serialize.BrushToString(AreaBrush);
			}
			set
			{
				AreaBrush = Serialize.StringToBrush(value);
			}
		}

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolAreaOpacity", GroupName = "NinjaScriptGeneral", Order = 2)]
		[Range(0, 100)]
		public int AreaOpacity
		{
			get
			{
				return areaOpacity;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		public override IEnumerable<ChartAnchor> Anchors
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolFibonacciRetracementsExtendLinesRight", GroupName = "NinjaScriptLines")]
		public bool IsExtendedLinesRight { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolFibonacciRetracementsExtendLinesLeft", GroupName = "NinjaScriptLines")]
		public bool IsExtendedLinesLeft { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolTrendChannelTrendStroke", GroupName = "NinjaScriptLines", Order = 1)]
		public Stroke Stroke { get; set; }

		[Display(Order = 10)]
		[ExcludeFromTemplate]
		public ChartAnchor TrendEndAnchor { get; set; }

		[ExcludeFromTemplate]
		[Display(Order = 0)]
		public ChartAnchor TrendStartAnchor { get; set; }

		[Display(Order = 20)]
		[ExcludeFromTemplate]
		public ChartAnchor ParallelStartAnchor { get; set; }

		[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolTrendChannelParallelStroke", GroupName = "NinjaScriptLines", Order = 2)]
		public Stroke ParallelStroke { get; set; }

		public override bool SupportsAlerts => true;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void CopyTo(NinjaScript ninjaScript)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool disposing)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsAlertConditionTrue(AlertConditionItem conditionItem, Condition condition, ChartAlertValue[] values, ChartControl chartControl, ChartScale chartScale)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnCalculateMinMax()
		{
		}

		public override void OnEdited(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, DrawingTool oldinstance)
		{
			SetParallelLine(chartControl, initialSet: false);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseDown(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnMouseUp(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void SetParallelLine(ChartControl chartControl, bool initialSet)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TrendChannel()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static TrendChannel()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class TrendLevel : PriceLevel
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		static TrendLevel()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
}
namespace NinjaTrader.NinjaScript.Indicators._FPLEME_
{
	public class StopAbsV : Indicator
	{
		private Series<double> negative;

		private Series<double> positive;

		private Series<double> stops;

		private SUM sumNegative;

		private SUM sumPositive;

		private double vol0;

		private double sumPV;

		private double sumV;

		private double VWAP;

		private double priceSTOP;

		private double vwapConstant;

		private EMA emaVol;

		private Series<double> vols;

		private double vol0_ABS;

		private double sumPV_ABS;

		private double sumV_ABS;

		private double VWAP_ABS;

		private double priceABS;

		private double vwapABSConstant;

		[NinjaScriptProperty]
		[Display(Name = "SHOW_ABS", Description = "Mostrar ABS", Order = 1, GroupName = "Parameters")]
		public bool SHOW_ABS { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "SHOW_STOPS", Description = "Mostrar grandes agressões. ", Order = 2, GroupName = "Parameters")]
		public bool SHOW_STOPS { get; set; }

		[Display(Name = "CHECK", Description = "Identifique locais de provaveis inversões. ", Order = 3, GroupName = "Parameters")]
		[NinjaScriptProperty]
		public bool CHECK { get; set; }

		[XmlIgnore]
		[Browsable(false)]
		public Series<double> STOP_LINE => ((NinjaScriptBase)this).Values[0];

		[Browsable(false)]
		[XmlIgnore]
		public Series<double> ABS_LINE => ((NinjaScriptBase)this).Values[1];

		[MethodImpl(MethodImplOptions.NoInlining)]
		public StopAbsV()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnBarUpdate()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static StopAbsV()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
}
namespace NinjaTrader.NinjaScript.Indicators
{
	public class SUM : Indicator
	{
		[Display(ResourceType = typeof(Resource), Name = "Period", GroupName = "NinjaScriptParameters", Order = 0)]
		[NinjaScriptProperty]
		[Range(1, int.MaxValue)]
		public int Period { get; set; }

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnBarUpdate()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static SUM()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
	public class EMA : Indicator
	{
		private double constant1;

		private double constant2;

		[Display(ResourceType = typeof(Resource), Name = "Period", GroupName = "NinjaScriptParameters", Order = 0)]
		[Range(1, int.MaxValue)]
		[NinjaScriptProperty]
		public int Period { get; set; }

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnStateChange()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnBarUpdate()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static EMA()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
}
namespace Azs=
{
	internal class Cjs=
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[Obfuscation]
		public static void Vee(bool throwOnError)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static object[] Czs=(Type attType, bool throwOnError)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void DDs=(bool throwOnError)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Cjs=()
		{
			<AgileDotNetRTPro>.Initialize();
			<AgileDotNetRTPro>.PostInitialize();
		}
	}
}
internal delegate int InitializeDelegate(IntPtr P_0);
internal delegate void ExitDelegate();
[SecuritySafeCritical]
internal class <AgileDotNetRTPro>
{
	private static bool inited;

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
	[MethodImpl(MethodImplOptions.ForwardRef)]
	private static extern IntPtr LoadLibraryA(string P_0);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
	[MethodImpl(MethodImplOptions.ForwardRef)]
	private static extern IntPtr GetProcAddress(IntPtr P_0, string P_1);

	[DllImport("AgileDotNetRTPro.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
	[MethodImpl(MethodImplOptions.ForwardRef)]
	private static extern int _Initialize(IntPtr P_0);

	[DllImport("AgileDotNetRT64Pro.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
	[MethodImpl(MethodImplOptions.ForwardRef)]
	private static extern int _Initialize64(IntPtr P_0);

	[DllImport("AgileDotNetRTPro.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
	[MethodImpl(MethodImplOptions.ForwardRef)]
	private static extern void _AtExit();

	[DllImport("AgileDotNetRT64Pro.dll", CharSet = CharSet.Ansi, EntryPoint = "_AtExit", ExactSpelling = true)]
	[MethodImpl(MethodImplOptions.ForwardRef)]
	private static extern void _AtExit64();

	internal static IntPtr Load()
	{
		WindowsImpersonationContext windowsImpersonationContext = WindowsIdentity.Impersonate(IntPtr.Zero);
		Type typeFromHandle;
		Monitor.Enter(typeFromHandle = typeof(<AgileDotNetRTPro>));
		string text = ((IntPtr.Size != 4) ? "AgileDotNetRT64Pro.dll" : "AgileDotNetRTPro.dll");
		string text2 = Path.Combine(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath), text);
		if (!File.Exists(text2))
		{
			text2 = text;
		}
		IntPtr result = LoadLibraryA(text2);
		windowsImpersonationContext.Undo();
		Monitor.Exit(typeFromHandle);
		return result;
	}

	internal static int InitializeThroughDelegate(IntPtr P_0)
	{
		IntPtr intPtr = Load();
		IntPtr procAddress = GetProcAddress(intPtr, "_Initialize");
		InitializeDelegate initializeDelegate = (InitializeDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(InitializeDelegate));
		return initializeDelegate(P_0);
	}

	internal static int InitializeThroughDelegate64(IntPtr P_0)
	{
		IntPtr intPtr = Load();
		IntPtr procAddress = GetProcAddress(intPtr, "_Initialize64");
		InitializeDelegate initializeDelegate = (InitializeDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(InitializeDelegate));
		return initializeDelegate(P_0);
	}

	internal static void ExitThroughDelegate()
	{
		IntPtr intPtr = Load();
		IntPtr procAddress = GetProcAddress(intPtr, "_AtExit");
		ExitDelegate exitDelegate = (ExitDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(ExitDelegate));
		exitDelegate();
	}

	internal static void ExitThroughDelegate64()
	{
		IntPtr intPtr = Load();
		IntPtr procAddress = GetProcAddress(intPtr, "_AtExit64");
		ExitDelegate exitDelegate = (ExitDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(ExitDelegate));
		exitDelegate();
	}

	internal static void DomainUnload(object P_0, EventArgs P_1)
	{
		if (IntPtr.Size == 4)
		{
			ExitThroughDelegate();
		}
		else
		{
			ExitThroughDelegate64();
		}
	}

	internal static void Initialize()
	{
		if (!inited)
		{
			RuntimeMethodHandle methodHandle = new StackTrace().GetFrame(0).GetMethod().MethodHandle;
			if (((IntPtr.Size != 4) ? InitializeThroughDelegate64(methodHandle.Value) : InitializeThroughDelegate(methodHandle.Value)) == 1)
			{
				AppDomain.CurrentDomain.DomainUnload += DomainUnload;
			}
			inited = true;
		}
	}

	internal static void PostInitialize()
	{
	}
}
