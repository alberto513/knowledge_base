using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Xml.Serialization;
using NinjaTrader.Custom;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;

namespace NinjaTrader.NinjaScript.DrawingTools;

[XmlInclude(typeof(TrendLevel))]
[TypeConverter("NinjaTrader.NinjaScript.DrawingTools.PriceLevelTypeConverter")]
[XmlInclude(typeof(GannAngle))]
[CategoryDefaultExpanded(true)]
public class PriceLevel : NotifyPropertyChangedBase, IStrokeProvider, ICloneable
{
	private double value;

	private string name;

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolsPriceLevelIsVisible", GroupName = "NinjaScriptGeneral")]
	public bool IsVisible { get; set; }

	[XmlIgnore]
	[Browsable(false)]
	public bool IsValueVisible { get; set; }

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolsPriceLevelLineStroke", GroupName = "NinjaScriptGeneral")]
	public Stroke Stroke { get; set; }

	[XmlIgnore]
	[Browsable(false)]
	public object Tag { get; set; }

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolsPriceLevelValue", GroupName = "NinjaScriptGeneral")]
	public double Value
	{
		get
		{
			return value;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[XmlIgnore]
	[Browsable(false)]
	public Func<double, string> ValueFormatFunc { get; set; }

	[Browsable(false)]
	public string Name
	{
		get
		{
			return name;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual object Clone()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object AssemblyClone(Type t)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void CopyTo(PriceLevel other)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public double GetPrice(double startPrice, double totalPriceRange, bool isInverted)
	{
		return 0.0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetY(ChartScale chartScale, double startPrice, double totalPriceRange, bool isInverted)
	{
		return 0f;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PriceLevel()
	{
	}

	public PriceLevel(double value, Brush brush)
		: this(value, brush, 2f)
	{
	}

	public PriceLevel(double value, Brush brush, float strokeWidth)
		: this(value, brush, strokeWidth, (DashStyleHelper)0, 100)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PriceLevel(double value, Brush brush, float strokeWidth, DashStyleHelper dashStyle, int opacity)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static PriceLevel()
	{
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
