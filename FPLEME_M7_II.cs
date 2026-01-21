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
		
		private _FPLEME_.FPLEME_M7[] cacheFPLEME_M7;

		
		public _FPLEME_.FPLEME_M7 FPLEME_M7(bool pAINT_BARS, bool fAST_MODE, bool tRACK_RECORD, bool sHOW_ETAPA_1, bool sHOW_ETAPA_2, bool sHOW_STOP, bool sHOW_FREQ_1, bool sHOW_FREQ_2, bool sHOW_FREQ_3, bool bREAKOUTS, bool gRAPH_BREAKOUTS)
		{
			return FPLEME_M7(Input, pAINT_BARS, fAST_MODE, tRACK_RECORD, sHOW_ETAPA_1, sHOW_ETAPA_2, sHOW_STOP, sHOW_FREQ_1, sHOW_FREQ_2, sHOW_FREQ_3, bREAKOUTS, gRAPH_BREAKOUTS);
		}


		
		public _FPLEME_.FPLEME_M7 FPLEME_M7(ISeries<double> input, bool pAINT_BARS, bool fAST_MODE, bool tRACK_RECORD, bool sHOW_ETAPA_1, bool sHOW_ETAPA_2, bool sHOW_STOP, bool sHOW_FREQ_1, bool sHOW_FREQ_2, bool sHOW_FREQ_3, bool bREAKOUTS, bool gRAPH_BREAKOUTS)
		{
			if (cacheFPLEME_M7 != null)
				for (int idx = 0; idx < cacheFPLEME_M7.Length; idx++)
					if (cacheFPLEME_M7[idx].PAINT_BARS == pAINT_BARS && cacheFPLEME_M7[idx].FAST_MODE == fAST_MODE && cacheFPLEME_M7[idx].TRACK_RECORD == tRACK_RECORD && cacheFPLEME_M7[idx].SHOW_ETAPA_1 == sHOW_ETAPA_1 && cacheFPLEME_M7[idx].SHOW_ETAPA_2 == sHOW_ETAPA_2 && cacheFPLEME_M7[idx].SHOW_STOP == sHOW_STOP && cacheFPLEME_M7[idx].SHOW_FREQ_1 == sHOW_FREQ_1 && cacheFPLEME_M7[idx].SHOW_FREQ_2 == sHOW_FREQ_2 && cacheFPLEME_M7[idx].SHOW_FREQ_3 == sHOW_FREQ_3 && cacheFPLEME_M7[idx].BREAKOUTS == bREAKOUTS && cacheFPLEME_M7[idx].GRAPH_BREAKOUTS == gRAPH_BREAKOUTS && cacheFPLEME_M7[idx].EqualsInput(input))
						return cacheFPLEME_M7[idx];
			return CacheIndicator<_FPLEME_.FPLEME_M7>(new _FPLEME_.FPLEME_M7(){ PAINT_BARS = pAINT_BARS, FAST_MODE = fAST_MODE, TRACK_RECORD = tRACK_RECORD, SHOW_ETAPA_1 = sHOW_ETAPA_1, SHOW_ETAPA_2 = sHOW_ETAPA_2, SHOW_STOP = sHOW_STOP, SHOW_FREQ_1 = sHOW_FREQ_1, SHOW_FREQ_2 = sHOW_FREQ_2, SHOW_FREQ_3 = sHOW_FREQ_3, BREAKOUTS = bREAKOUTS, GRAPH_BREAKOUTS = gRAPH_BREAKOUTS }, input, ref cacheFPLEME_M7);
		}

	}
}

namespace NinjaTrader.NinjaScript.MarketAnalyzerColumns
{
	public partial class MarketAnalyzerColumn : MarketAnalyzerColumnBase
	{
		
		public Indicators._FPLEME_.FPLEME_M7 FPLEME_M7(bool pAINT_BARS, bool fAST_MODE, bool tRACK_RECORD, bool sHOW_ETAPA_1, bool sHOW_ETAPA_2, bool sHOW_STOP, bool sHOW_FREQ_1, bool sHOW_FREQ_2, bool sHOW_FREQ_3, bool bREAKOUTS, bool gRAPH_BREAKOUTS)
		{
			return indicator.FPLEME_M7(Input, pAINT_BARS, fAST_MODE, tRACK_RECORD, sHOW_ETAPA_1, sHOW_ETAPA_2, sHOW_STOP, sHOW_FREQ_1, sHOW_FREQ_2, sHOW_FREQ_3, bREAKOUTS, gRAPH_BREAKOUTS);
		}


		
		public Indicators._FPLEME_.FPLEME_M7 FPLEME_M7(ISeries<double> input , bool pAINT_BARS, bool fAST_MODE, bool tRACK_RECORD, bool sHOW_ETAPA_1, bool sHOW_ETAPA_2, bool sHOW_STOP, bool sHOW_FREQ_1, bool sHOW_FREQ_2, bool sHOW_FREQ_3, bool bREAKOUTS, bool gRAPH_BREAKOUTS)
		{
			return indicator.FPLEME_M7(input, pAINT_BARS, fAST_MODE, tRACK_RECORD, sHOW_ETAPA_1, sHOW_ETAPA_2, sHOW_STOP, sHOW_FREQ_1, sHOW_FREQ_2, sHOW_FREQ_3, bREAKOUTS, gRAPH_BREAKOUTS);
		}
	
	}
}

namespace NinjaTrader.NinjaScript.Strategies
{
	public partial class Strategy : NinjaTrader.Gui.NinjaScript.StrategyRenderBase
	{
		
		public Indicators._FPLEME_.FPLEME_M7 FPLEME_M7(bool pAINT_BARS, bool fAST_MODE, bool tRACK_RECORD, bool sHOW_ETAPA_1, bool sHOW_ETAPA_2, bool sHOW_STOP, bool sHOW_FREQ_1, bool sHOW_FREQ_2, bool sHOW_FREQ_3, bool bREAKOUTS, bool gRAPH_BREAKOUTS)
		{
			return indicator.FPLEME_M7(Input, pAINT_BARS, fAST_MODE, tRACK_RECORD, sHOW_ETAPA_1, sHOW_ETAPA_2, sHOW_STOP, sHOW_FREQ_1, sHOW_FREQ_2, sHOW_FREQ_3, bREAKOUTS, gRAPH_BREAKOUTS);
		}


		
		public Indicators._FPLEME_.FPLEME_M7 FPLEME_M7(ISeries<double> input , bool pAINT_BARS, bool fAST_MODE, bool tRACK_RECORD, bool sHOW_ETAPA_1, bool sHOW_ETAPA_2, bool sHOW_STOP, bool sHOW_FREQ_1, bool sHOW_FREQ_2, bool sHOW_FREQ_3, bool bREAKOUTS, bool gRAPH_BREAKOUTS)
		{
			return indicator.FPLEME_M7(input, pAINT_BARS, fAST_MODE, tRACK_RECORD, sHOW_ETAPA_1, sHOW_ETAPA_2, sHOW_STOP, sHOW_FREQ_1, sHOW_FREQ_2, sHOW_FREQ_3, bREAKOUTS, gRAPH_BREAKOUTS);
		}

	}
}

#endregion
