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
using NinjaTrader.Gui.Tools;
using SharpDX.Direct2D1;

namespace NinjaTrader.NinjaScript.DrawingTools;

public class Arc : Line
{
	[CompilerGenerated]
	private sealed class _003CGetAlertConditionItems_003Ed__20 : IEnumerable<AlertConditionItem>, IEnumerable, IEnumerator<AlertConditionItem>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private AlertConditionItem _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public Arc _003C_003E4__this;

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
		public _003CGetAlertConditionItems_003Ed__20(int _003C_003E1__state)
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
		static _003CGetAlertConditionItems_003Ed__20()
		{
			_003CAgileDotNetRT_003E.Initialize();
			_003CAgileDotNetRT_003E.PostInitialize();
		}
	}

	private PathGeometry arcGeometry;

	private Brush areaBrush;

	private readonly DeviceBrush areaBrushDevice;

	private int areaOpacity;

	private Point cachedStartPoint;

	private Point cachedEndPoint;

	[Display(ResourceType = typeof(Resource), GroupName = "NinjaScriptGeneral", Name = "NinjaScriptDrawingToolArc", Order = 99)]
	public Stroke ArcStroke { get; set; }

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

	public override object Icon => Icons.DrawArc;

	public override bool SupportsAlerts => true;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
	}

	[IteratorStateMachine(typeof(_003CGetAlertConditionItems_003Ed__20))]
	public override IEnumerable<AlertConditionItem> GetAlertConditionItems()
	{
		//yield-return decompiler failed: Could not find stateField
		return new _003CGetAlertConditionItems_003Ed__20(-2)
		{
			_003C_003E4__this = this
		};
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
	public override Cursor GetCursor(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale, Point point)
	{
		return null;
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
	private void UpdateArcGeometry(ChartControl chartControl, ChartPanel chartPanel, ChartScale chartScale)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Arc()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Arc()
	{
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
