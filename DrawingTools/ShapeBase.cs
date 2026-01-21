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
using SharpDX.Direct2D1;

namespace NinjaTrader.NinjaScript.DrawingTools;

public abstract class ShapeBase : DrawingTool
{
	protected enum ChartShapeType
	{
		Unset,
		Ellipse,
		Rectangle,
		Triangle
	}

	protected enum ResizeMode
	{
		None,
		TopLeft,
		TopRight,
		BottomLeft,
		BottomRight,
		MoveAll
	}

	[CompilerGenerated]
	private sealed class _003CGetAlertConditionItems_003Ed__56 : IEnumerable<AlertConditionItem>, IEnumerable, IEnumerator<AlertConditionItem>, IDisposable, IEnumerator
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
		public _003CGetAlertConditionItems_003Ed__56(int _003C_003E1__state)
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
		static _003CGetAlertConditionItems_003Ed__56()
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

	private ChartAnchor editingLeftAnchor;

	private ChartAnchor editingTopAnchor;

	private ChartAnchor editingBottomAnchor;

	private ChartAnchor editingRightAnchor;

	private ChartAnchor lastMouseMoveDataPoint;

	private ResizeMode resizeMode;

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolShapesAreaBrush", GroupName = "NinjaScriptGeneral", Order = 1)]
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

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolAreaOpacity", GroupName = "NinjaScriptGeneral", Order = 2)]
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

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolTextOutlineStroke", GroupName = "NinjaScriptGeneral", Order = 3)]
	public Stroke OutlineStroke { get; set; }

	[Display(Order = 2)]
	public ChartAnchor EndAnchor { get; set; }

	[Display(Order = 3)]
	public ChartAnchor MiddleAnchor { get; set; }

	[Display(Order = 1)]
	public ChartAnchor StartAnchor { get; set; }

	[Browsable(false)]
	protected ChartShapeType ShapeType { get; set; }

	public override bool SupportsAlerts => true;

	public override IEnumerable<ChartAnchor> Anchors
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCalculateMinMax()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PathGeometry CreateTriangleGeometry(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, double pixelAdjust)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Rect GetAnchorsRect(ChartControl chartControl, ChartScale chartScale)
	{
		return default(Rect);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Point? GetClosestPoint(IEnumerable<Point> inputPoints, Point desired, bool useSensitivity)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Point[] GetEllipseAnchorPoints(ChartControl chartControl, ChartScale chartScale)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ResizeMode GetResizeModeForPoint(Point pt, ChartControl chartControl, ChartScale chartScale, bool useCursorSens)
	{
		return default(ResizeMode);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sealed override Point[] GetSelectionPoints(ChartControl chartControl, ChartScale chartScale)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Point[] GetTriangleAnchorPoints(ChartControl chartControl, ChartScale chartScale, bool includeCentroid)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CGetAlertConditionItems_003Ed__56))]
	public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
	{
		//yield-return decompiler failed: Could not find stateField
		return new _003CGetAlertConditionItems_003Ed__56(-2);
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
	protected ShapeBase()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ShapeBase()
	{
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
