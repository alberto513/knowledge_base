using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NinjaTrader.NinjaScript.DrawingTools;

public abstract class PathToolSegmentContainer : DrawingTool
{
	[SkipOnCopyTo(true)]
	[Browsable(false)]
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
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
