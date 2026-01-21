using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;
using NinjaTrader.Custom;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;

namespace NinjaTrader.NinjaScript.DrawingTools;

[CLSCompliant(false)]
public abstract class RegionHighlightBase : DrawingTool
{
	[CompilerGenerated]
	private sealed class _003CGetAlertConditionItems_003Ed__40 : IEnumerable<AlertConditionItem>, IEnumerable, IEnumerator<AlertConditionItem>, IDisposable, IEnumerator
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
		public _003CGetAlertConditionItems_003Ed__40(int _003C_003E1__state)
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
		static _003CGetAlertConditionItems_003Ed__40()
		{
			_003CAgileDotNetRT_003E.Initialize();
			_003CAgileDotNetRT_003E.PostInitialize();
		}
	}

	private int areaOpacity;

	private Brush areaBrush;

	private readonly DeviceBrush areaBrushDevice;

	private const double cursorSensitivity = 15.0;

	private ChartAnchor editingAnchor;

	private bool hasSetZOrder;

	public override bool SupportsAlerts => true;

	public override IEnumerable<ChartAnchor> Anchors
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return null;
		}
	}

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolRiskRewardAnchorLineStroke", GroupName = "NinjaScriptGeneral", Order = 5)]
	public Stroke AnchorLineStroke { get; set; }

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolShapesAreaBrush", GroupName = "NinjaScriptGeneral", Order = 3)]
	[XmlIgnore]
	public Brush AreaBrush
	{
		get
		{
			return areaBrush;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Browsable(false)]
	public string AreaBrushSerialize
	{
		get
		{
			return Serialize.BrushToString(AreaBrush);
		}
		set
		{
			AreaBrush = Serialize.StringToBrush(value);
		}
	}

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolAreaOpacity", GroupName = "NinjaScriptGeneral", Order = 4)]
	[Range(0, 100)]
	public int AreaOpacity
	{
		get
		{
			return areaOpacity;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Display(Order = 2)]
	public ChartAnchor EndAnchor { get; set; }

	[XmlIgnore]
	[Browsable(false)]
	internal RegionHighlightMode Mode { get; set; }

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolTextOutlineStroke", GroupName = "NinjaScriptGeneral", Order = 6)]
	public Stroke OutlineStroke { get; set; }

	[Display(Order = 1)]
	public ChartAnchor StartAnchor { get; set; }

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
	}

	[IteratorStateMachine(typeof(_003CGetAlertConditionItems_003Ed__40))]
	public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
	{
		//yield-return decompiler failed: Could not find stateField
		return new _003CGetAlertConditionItems_003Ed__40(-2);
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
	protected override void OnStateChange()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRender(ChartControl chartControl, ChartScale chartScale)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected RegionHighlightBase()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static RegionHighlightBase()
	{
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
