using System.Runtime.CompilerServices;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.Tools;

namespace NinjaTrader.NinjaScript.DrawingTools;

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
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
