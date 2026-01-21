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
		
		private _FPLEME_.VXM7[] cacheVXM7;

		
		public _FPLEME_.VXM7 VXM7(bool tHE_WALL, bool fORCE_LINES, bool pULLBACKS)
		{
			return VXM7(Input, tHE_WALL, fORCE_LINES, pULLBACKS);
		}


		
		public _FPLEME_.VXM7 VXM7(ISeries<double> input, bool tHE_WALL, bool fORCE_LINES, bool pULLBACKS)
		{
			if (cacheVXM7 != null)
				for (int idx = 0; idx < cacheVXM7.Length; idx++)
					if (cacheVXM7[idx].THE_WALL == tHE_WALL && cacheVXM7[idx].FORCE_LINES == fORCE_LINES && cacheVXM7[idx].PULLBACKS == pULLBACKS && cacheVXM7[idx].EqualsInput(input))
						return cacheVXM7[idx];
			return CacheIndicator<_FPLEME_.VXM7>(new _FPLEME_.VXM7(){ THE_WALL = tHE_WALL, FORCE_LINES = fORCE_LINES, PULLBACKS = pULLBACKS }, input, ref cacheVXM7);
		}

	}
}

namespace NinjaTrader.NinjaScript.MarketAnalyzerColumns
{
	public partial class MarketAnalyzerColumn : MarketAnalyzerColumnBase
	{
		
		public Indicators._FPLEME_.VXM7 VXM7(bool tHE_WALL, bool fORCE_LINES, bool pULLBACKS)
		{
			return indicator.VXM7(Input, tHE_WALL, fORCE_LINES, pULLBACKS);
		}


		
		public Indicators._FPLEME_.VXM7 VXM7(ISeries<double> input , bool tHE_WALL, bool fORCE_LINES, bool pULLBACKS)
		{
			return indicator.VXM7(input, tHE_WALL, fORCE_LINES, pULLBACKS);
		}
	
	}
}

namespace NinjaTrader.NinjaScript.Strategies
{
	public partial class Strategy : NinjaTrader.Gui.NinjaScript.StrategyRenderBase
	{
		
		public Indicators._FPLEME_.VXM7 VXM7(bool tHE_WALL, bool fORCE_LINES, bool pULLBACKS)
		{
			return indicator.VXM7(Input, tHE_WALL, fORCE_LINES, pULLBACKS);
		}


		
		public Indicators._FPLEME_.VXM7 VXM7(ISeries<double> input , bool tHE_WALL, bool fORCE_LINES, bool pULLBACKS)
		{
			return indicator.VXM7(input, tHE_WALL, fORCE_LINES, pULLBACKS);
		}

	}
}

#endregion
