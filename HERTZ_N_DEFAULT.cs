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
		
		private _FPLEME_.HERTZ[] cacheHERTZ;

		
		public _FPLEME_.HERTZ HERTZ()
		{
			return HERTZ(Input);
		}


		
		public _FPLEME_.HERTZ HERTZ(ISeries<double> input)
		{
			if (cacheHERTZ != null)
				for (int idx = 0; idx < cacheHERTZ.Length; idx++)
					if ( cacheHERTZ[idx].EqualsInput(input))
						return cacheHERTZ[idx];
			return CacheIndicator<_FPLEME_.HERTZ>(new _FPLEME_.HERTZ(), input, ref cacheHERTZ);
		}

	}
}

namespace NinjaTrader.NinjaScript.MarketAnalyzerColumns
{
	public partial class MarketAnalyzerColumn : MarketAnalyzerColumnBase
	{
		
		public Indicators._FPLEME_.HERTZ HERTZ()
		{
			return indicator.HERTZ(Input);
		}


		
		public Indicators._FPLEME_.HERTZ HERTZ(ISeries<double> input )
		{
			return indicator.HERTZ(input);
		}
	
	}
}

namespace NinjaTrader.NinjaScript.Strategies
{
	public partial class Strategy : NinjaTrader.Gui.NinjaScript.StrategyRenderBase
	{
		
		public Indicators._FPLEME_.HERTZ HERTZ()
		{
			return indicator.HERTZ(Input);
		}


		
		public Indicators._FPLEME_.HERTZ HERTZ(ISeries<double> input )
		{
			return indicator.HERTZ(input);
		}

	}
}

#endregion
