using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NinjaTrader.NinjaScript.DrawingTools;

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
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
