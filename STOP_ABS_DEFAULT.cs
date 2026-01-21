#region Using declarations
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.SuperDom;
using NinjaTrader.Gui.Tools;
using NinjaTrader.Data;
using NinjaTrader.NinjaScript;
using NinjaTrader.Core.FloatingPoint;

#endregion



#region NinjaScript generated code. Neither change nor remove.

namespace NinjaTrader.NinjaScript.Indicators
{
	public partial class Indicator : NinjaTrader.Gui.NinjaScript.IndicatorRenderBase
	{
		
		private _FPLEME_.StopAbsV[] cacheStopAbsV;

		
		public _FPLEME_.StopAbsV StopAbsV(bool sHOW_ABS, bool sHOW_STOPS, bool cHECK)
		{
			return StopAbsV(Input, sHOW_ABS, sHOW_STOPS, cHECK);
		}


		
		public _FPLEME_.StopAbsV StopAbsV(ISeries<double> input, bool sHOW_ABS, bool sHOW_STOPS, bool cHECK)
		{
			if (cacheStopAbsV != null)
				for (int idx = 0; idx < cacheStopAbsV.Length; idx++)
					if (cacheStopAbsV[idx].SHOW_ABS == sHOW_ABS && cacheStopAbsV[idx].SHOW_STOPS == sHOW_STOPS && cacheStopAbsV[idx].CHECK == cHECK && cacheStopAbsV[idx].EqualsInput(input))
						return cacheStopAbsV[idx];
			return CacheIndicator<_FPLEME_.StopAbsV>(new _FPLEME_.StopAbsV(){ SHOW_ABS = sHOW_ABS, SHOW_STOPS = sHOW_STOPS, CHECK = cHECK }, input, ref cacheStopAbsV);
		}

	}
}

namespace NinjaTrader.NinjaScript.MarketAnalyzerColumns
{
	public partial class MarketAnalyzerColumn : MarketAnalyzerColumnBase
	{
		
		public Indicators._FPLEME_.StopAbsV StopAbsV(bool sHOW_ABS, bool sHOW_STOPS, bool cHECK)
		{
			return indicator.StopAbsV(Input, sHOW_ABS, sHOW_STOPS, cHECK);
		}


		
		public Indicators._FPLEME_.StopAbsV StopAbsV(ISeries<double> input , bool sHOW_ABS, bool sHOW_STOPS, bool cHECK)
		{
			return indicator.StopAbsV(input, sHOW_ABS, sHOW_STOPS, cHECK);
		}
	
	}
}

namespace NinjaTrader.NinjaScript.Strategies
{
	public partial class Strategy : NinjaTrader.Gui.NinjaScript.StrategyRenderBase
	{
		
		public Indicators._FPLEME_.StopAbsV StopAbsV(bool sHOW_ABS, bool sHOW_STOPS, bool cHECK)
		{
			return indicator.StopAbsV(Input, sHOW_ABS, sHOW_STOPS, cHECK);
		}


		
		public Indicators._FPLEME_.StopAbsV StopAbsV(ISeries<double> input , bool sHOW_ABS, bool sHOW_STOPS, bool cHECK)
		{
			return indicator.StopAbsV(input, sHOW_ABS, sHOW_STOPS, cHECK);
		}

	}
}

#endregion
