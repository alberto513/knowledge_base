using System;
using System.Runtime.CompilerServices;
using NinjaTrader.Gui.Tools;

namespace NinjaTrader.NinjaScript.DrawingTools;

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
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
