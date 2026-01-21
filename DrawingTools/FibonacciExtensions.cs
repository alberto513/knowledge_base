using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.Tools;

namespace NinjaTrader.NinjaScript.DrawingTools;

public class FibonacciExtensions : FibonacciRetracements
{
	private Point anchorExtensionPoint;

	[Display(Order = 3)]
	public ChartAnchor ExtensionAnchor { get; set; }

	public override IEnumerable<ChartAnchor> Anchors
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return null;
		}
	}

	public override object Icon => Icons.DrawFbExtensions;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected new Tuple<Point, Point> GetPriceLevelLinePoints(PriceLevel priceLevel, ChartControl chartControl, ChartScale chartScale, bool isInverted)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private new void DrawPriceLevelText(ChartPanel chartPanel, ChartScale chartScale, double minX, double maxX, double y, double price, PriceLevel priceLevel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Point GetEndLineMidpoint(ChartControl chartControl, ChartScale chartScale)
	{
		return default(Point);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sealed override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetPriceString(double price, PriceLevel priceLevel, ChartPanel chartPanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Tuple<Point, Point> GetTranslatedExtensionYLine(ChartControl chartControl, ChartScale chartScale)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsAlertConditionTrue(AlertConditionItem conditionItem, Condition condition, ChartAlertValue[] values, ChartControl chartControl, ChartScale chartScale)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMouseDown(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnStateChange()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRender(ChartControl chartControl, ChartScale chartScale)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static FibonacciExtensions()
	{
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
