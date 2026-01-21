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
		
		private _FPLEME_.MAPS_M7[] cacheMAPS_M7;

		
		public _FPLEME_.MAPS_M7 MAPS_M7(bool cENTRAIS, bool iNTERMEDIARIOS, bool cLEAN_MODE, bool tHE_WALL, bool fORCE_LINES, bool pULLBACKS)
		{
			return MAPS_M7(Input, cENTRAIS, iNTERMEDIARIOS, cLEAN_MODE, tHE_WALL, fORCE_LINES, pULLBACKS);
		}


		
		public _FPLEME_.MAPS_M7 MAPS_M7(ISeries<double> input, bool cENTRAIS, bool iNTERMEDIARIOS, bool cLEAN_MODE, bool tHE_WALL, bool fORCE_LINES, bool pULLBACKS)
		{
			if (cacheMAPS_M7 != null)
				for (int idx = 0; idx < cacheMAPS_M7.Length; idx++)
					if (cacheMAPS_M7[idx].CENTRAIS == cENTRAIS && cacheMAPS_M7[idx].INTERMEDIARIOS == iNTERMEDIARIOS && cacheMAPS_M7[idx].CLEAN_MODE == cLEAN_MODE && cacheMAPS_M7[idx].THE_WALL == tHE_WALL && cacheMAPS_M7[idx].FORCE_LINES == fORCE_LINES && cacheMAPS_M7[idx].PULLBACKS == pULLBACKS && cacheMAPS_M7[idx].EqualsInput(input))
						return cacheMAPS_M7[idx];
			return CacheIndicator<_FPLEME_.MAPS_M7>(new _FPLEME_.MAPS_M7(){ CENTRAIS = cENTRAIS, INTERMEDIARIOS = iNTERMEDIARIOS, CLEAN_MODE = cLEAN_MODE, THE_WALL = tHE_WALL, FORCE_LINES = fORCE_LINES, PULLBACKS = pULLBACKS }, input, ref cacheMAPS_M7);
		}

	}
}

namespace NinjaTrader.NinjaScript.MarketAnalyzerColumns
{
	public partial class MarketAnalyzerColumn : MarketAnalyzerColumnBase
	{
		
		public Indicators._FPLEME_.MAPS_M7 MAPS_M7(bool cENTRAIS, bool iNTERMEDIARIOS, bool cLEAN_MODE, bool tHE_WALL, bool fORCE_LINES, bool pULLBACKS)
		{
			return indicator.MAPS_M7(Input, cENTRAIS, iNTERMEDIARIOS, cLEAN_MODE, tHE_WALL, fORCE_LINES, pULLBACKS);
		}


		
		public Indicators._FPLEME_.MAPS_M7 MAPS_M7(ISeries<double> input , bool cENTRAIS, bool iNTERMEDIARIOS, bool cLEAN_MODE, bool tHE_WALL, bool fORCE_LINES, bool pULLBACKS)
		{
			return indicator.MAPS_M7(input, cENTRAIS, iNTERMEDIARIOS, cLEAN_MODE, tHE_WALL, fORCE_LINES, pULLBACKS);
		}
	
	}
}

namespace NinjaTrader.NinjaScript.Strategies
{
	public partial class Strategy : NinjaTrader.Gui.NinjaScript.StrategyRenderBase
	{
		
		public Indicators._FPLEME_.MAPS_M7 MAPS_M7(bool cENTRAIS, bool iNTERMEDIARIOS, bool cLEAN_MODE, bool tHE_WALL, bool fORCE_LINES, bool pULLBACKS)
		{
			return indicator.MAPS_M7(Input, cENTRAIS, iNTERMEDIARIOS, cLEAN_MODE, tHE_WALL, fORCE_LINES, pULLBACKS);
		}


		
		public Indicators._FPLEME_.MAPS_M7 MAPS_M7(ISeries<double> input , bool cENTRAIS, bool iNTERMEDIARIOS, bool cLEAN_MODE, bool tHE_WALL, bool fORCE_LINES, bool pULLBACKS)
		{
			return indicator.MAPS_M7(input, cENTRAIS, iNTERMEDIARIOS, cLEAN_MODE, tHE_WALL, fORCE_LINES, pULLBACKS);
		}

	}
}

#endregion
