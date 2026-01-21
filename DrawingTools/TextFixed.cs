using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Windows;
using NinjaTrader.Custom;
using NinjaTrader.Gui.Chart;

namespace NinjaTrader.NinjaScript.DrawingTools;

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
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
