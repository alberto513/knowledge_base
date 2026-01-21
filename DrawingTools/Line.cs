using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using NinjaTrader.Custom;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.Tools;
using SharpDX.Direct2D1;

namespace NinjaTrader.NinjaScript.DrawingTools;

public class Line : DrawingTool
{
	protected enum ChartLineType
	{
		ArrowLine,
		ExtendedLine,
		HorizontalLine,
		Line,
		Ray,
		VerticalLine
	}

	[CompilerGenerated]
	private sealed class _003CGetAlertConditionItems_003Ed__29 : IEnumerable<AlertConditionItem>, IEnumerable, IEnumerator<AlertConditionItem>, IDisposable, IEnumerator
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
		public _003CGetAlertConditionItems_003Ed__29(int _003C_003E1__state)
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
		static _003CGetAlertConditionItems_003Ed__29()
		{
			_003CAgileDotNetRT_003E.Initialize();
			_003CAgileDotNetRT_003E.PostInitialize();
		}
	}

	[CLSCompliant(false)]
	protected PathGeometry ArrowPathGeometry;

	private ChartAnchor cursorAnchor;

	private const double cursorSensitivity = 15.0;

	private ChartAnchor editingAnchor;

	public override IEnumerable<ChartAnchor> Anchors
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return null;
		}
	}

	[Display(Order = 2)]
	public ChartAnchor EndAnchor { get; set; }

	[Display(Order = 1)]
	public ChartAnchor StartAnchor { get; set; }

	public override object Icon => Icons.DrawLineTool;

	[XmlIgnore]
	[Browsable(false)]
	protected ChartLineType LineType { get; set; }

	[Display(ResourceType = typeof(Resource), GroupName = "NinjaScriptGeneral", Name = "NinjaScriptDrawingToolLine", Order = 99)]
	public Stroke Stroke { get; set; }

	public override bool SupportsAlerts => true;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ChartAnchor Anchor45(ChartAnchor startAnchor, ChartAnchor endAnchor, ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CGetAlertConditionItems_003Ed__29))]
	public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
	{
		//yield-return decompiler failed: Could not find stateField
		return new _003CGetAlertConditionItems_003Ed__29(-2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sealed override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
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
	public override void OnCalculateMinMax()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnKeyDown(ChartControl chartControl, ChartPanel chartPanel, KeyEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnKeyUp(ChartControl chartControl, ChartPanel chartPanel, KeyEventArgs e)
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
	static Line()
	{
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
