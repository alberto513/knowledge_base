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
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.Tools;

namespace NinjaTrader.NinjaScript.DrawingTools;

public class GannFan : GannAngleContainer
{
	[TypeConverter("NinjaTrader.Custom.ResourceEnumConverter")]
	public enum GannFanDirection
	{
		UpLeft,
		UpRight,
		DownLeft,
		DownRight
	}

	[CompilerGenerated]
	private sealed class _003CGetAlertConditionItems_003Ed__30 : IEnumerable<AlertConditionItem>, IEnumerable, IEnumerator<AlertConditionItem>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private AlertConditionItem _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public GannFan _003C_003E4__this;

		private List<GannAngle>.Enumerator _003C_003E7__wrap1;

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
		public _003CGetAlertConditionItems_003Ed__30(int _003C_003E1__state)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally1()
		{
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
		static _003CGetAlertConditionItems_003Ed__30()
		{
			_003CAgileDotNetRT_003E.Initialize();
			_003CAgileDotNetRT_003E.PostInitialize();
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetGannEndPoints_003Ed__31 : IEnumerable<Point>, IEnumerable, IEnumerator<Point>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private Point _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private ChartControl chartControl;

		public ChartControl _003C_003E3__chartControl;

		public GannFan _003C_003E4__this;

		private ChartScale chartScale;

		public ChartScale _003C_003E3__chartScale;

		private Point _003CanchorPoint_003E5__2;

		private IEnumerator<GannAngle> _003C_003E7__wrap2;

		Point IEnumerator<Point>.Current
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
		public _003CGetGannEndPoints_003Ed__31(int _003C_003E1__state)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<Point> IEnumerable<Point>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Point>)this).GetEnumerator();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _003CGetGannEndPoints_003Ed__31()
		{
			_003CAgileDotNetRT_003E.Initialize();
			_003CAgileDotNetRT_003E.PostInitialize();
		}
	}

	public ChartAnchor Anchor { get; set; }

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolGannFanFanDirection", GroupName = "NinjaScriptGeneral", Order = 3)]
	public GannFanDirection FanDirection { get; set; }

	public override object Icon => Icons.DrawGanFan;

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolGannFanDisplayText", GroupName = "NinjaScriptGeneral", Order = 2)]
	public bool IsTextDisplayed { get; set; }

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolGannFanPointsPerBar", GroupName = "NinjaScriptGeneral", Order = 4)]
	public double PointsPerBar { get; set; }

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolPriceLevelsOpacity", GroupName = "NinjaScriptGeneral")]
	public int PriceLevelOpacity { get; set; }

	public override IEnumerable<ChartAnchor> Anchors
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return null;
		}
	}

	public override bool SupportsAlerts => true;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCalculateMinMax()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Point CalculateExtendedDataPoint(ChartPanel panel, ChartScale scale, int startX, double startPrice, Vector slope)
	{
		return default(Point);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CGetAlertConditionItems_003Ed__30))]
	public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
	{
		//yield-return decompiler failed: Could not find stateField
		return new _003CGetAlertConditionItems_003Ed__30(-2)
		{
			_003C_003E4__this = this
		};
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetGannEndPoints_003Ed__31))]
	private IEnumerable<Point> GetGannEndPoints(ChartControl chartControl, ChartScale chartScale)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Point GetGannStepPoint(ChartScale scale, double startX, double startPrice, double deltaX, double deltaPrice)
	{
		return default(Point);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Vector GetGannStepDataVector(double deltaX, double deltaPrice)
	{
		return default(Vector);
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
	public override void OnMouseDown(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMouseMove(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
	{
	}

	public override void OnMouseUp(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, ChartAnchor dataPoint)
	{
		((DrawingTool)this).DrawingState = (DrawingState)2;
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
	static GannFan()
	{
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
