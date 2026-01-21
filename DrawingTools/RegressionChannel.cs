using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using NinjaTrader.Custom;
using NinjaTrader.Data;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.Tools;

namespace NinjaTrader.NinjaScript.DrawingTools;

[TypeConverter("NinjaTrader.NinjaScript.DrawingTools.RegressionChannelTypeConverter")]
public class RegressionChannel : DrawingTool
{
	[TypeConverter("NinjaTrader.Custom.ResourceEnumConverter")]
	public enum RegressionChannelType
	{
		Segment,
		StandardDeviation
	}

	[CompilerGenerated]
	private sealed class _003CGetAlertConditionItems_003Ed__58 : IEnumerable<AlertConditionItem>, IEnumerable, IEnumerator<AlertConditionItem>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private AlertConditionItem _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		AlertConditionItem IEnumerator<AlertConditionItem>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CGetAlertConditionItems_003Ed__58(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<AlertConditionItem> IEnumerable<AlertConditionItem>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<AlertConditionItem>)this).GetEnumerator();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _003CGetAlertConditionItems_003Ed__58()
		{
			_003CAgileDotNetRT_003E.Initialize();
			_003CAgileDotNetRT_003E.PostInitialize();
		}
	}

	private ChartControl cControl;

	private ChartScale cScale;

	private ChartAnchor editingAnchor;

	public override IEnumerable<ChartAnchor> Anchors
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return null;
		}
	}

	[RefreshProperties(RefreshProperties.All)]
	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRegressionChannelType", GroupName = "NinjaScriptGeneral", Order = 2)]
	public RegressionChannelType ChannelType { get; set; }

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRegressionChannelStandardDeviationExtendLeft", GroupName = "NinjaScriptLines")]
	public bool ExtendLeft { get; set; }

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRegressionChannelStandardDeviationExtendRight", GroupName = "NinjaScriptLines")]
	public bool ExtendRight { get; set; }

	[Display(Order = 2)]
	public ChartAnchor EndAnchor { get; set; }

	public override object Icon => Icons.DrawRegressionChannel;

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRegressionChannelLowerChannel", GroupName = "NinjaScriptLines", Order = 3)]
	public Stroke LowerChannelStroke { get; set; }

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRegressionChannelRegressionChannel", GroupName = "NinjaScriptLines", Order = 2)]
	public Stroke RegressionStroke { get; set; }

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRegressionChannelPriceType", GroupName = "NinjaScriptGeneral", Order = 1)]
	public PriceType PriceType { get; set; }

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRegressionChannelStandardDeviationUpperDistance", GroupName = "NinjaScriptGeneral", Order = 3)]
	public double StandardDeviationUpperDistance { get; set; }

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRegressionChannelStandardDeviationLowerDistance", GroupName = "NinjaScriptGeneral", Order = 4)]
	public double StandardDeviationLowerDistance { get; set; }

	[Display(Order = 1)]
	public ChartAnchor StartAnchor { get; set; }

	public override bool SupportsAlerts => true;

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRegressionChannelUpperChannel", GroupName = "NinjaScriptLines", Order = 1)]
	public Stroke UpperChannelStroke { get; set; }

	public override void AddPastedOffset(ChartPanel panel, ChartScale chartScale)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public double[] CalculateRegressionPriceValues(Bars baseBars, int startIndex, int endIndex)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Point[] CreateRegressionPoints(ChartControl chartControl, ChartScale chartScale)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public double GetBarPrice(Bars barObject, int barIndex)
	{
		return 0.0;
	}

	[IteratorStateMachine(typeof(_003CGetAlertConditionItems_003Ed__58))]
	public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
	{
		//yield-return decompiler failed: Could not find stateField
		return new _003CGetAlertConditionItems_003Ed__58(-2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
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
	public override void OnBarsChanged()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCalculateMinMax()
	{
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
	public override void OnMouseUp(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
	{
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
	private void SetAnchorsToRegression(ChartControl chartControl, ChartScale chartScale)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static RegressionChannel()
	{
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
