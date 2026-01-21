using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using NinjaTrader.Custom;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.Tools;

namespace NinjaTrader.NinjaScript.DrawingTools;

[TypeConverter("NinjaTrader.NinjaScript.DrawingTools.FibonacciCircleTimeTypeConverter")]
public class FibonacciCircle : FibonacciRetracements
{
	public override object Icon => Icons.DrawFbCircle;

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolFibonacciTimeExtensionsShowText", GroupName = "NinjaScriptGeneral")]
	public bool IsTextDisplayed { get; set; }

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolFibonacciTimeCircleDivideTimeSeparately", GroupName = "NinjaScriptGeneral", Order = 1)]
	public bool IsTimePriceDividedSeparately { get; set; }

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCalculateMinMax()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DrawPriceLevelText(float textX, float textY, PriceLevel priceLevel, double yVal, ChartControl chartControl)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetPriceString(double yVal, PriceLevel priceLevel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override IEnumerable<Condition> GetValidAlertConditions()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsAlertConditionTrue(AlertConditionItem conditionItem, Condition condition, ChartAlertValue[] values, ChartControl chartControl, ChartScale chartScale)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsVisibleOnChart(ChartControl chartControl, ChartScale chartScale, DateTime firstTimeOnChart, DateTime lastTimeOnChart)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRender(ChartControl chartControl, ChartScale chartScale)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnStateChange()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static FibonacciCircle()
	{
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
