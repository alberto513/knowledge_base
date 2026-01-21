using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Xml.Serialization;
using NinjaTrader.Custom;
using NinjaTrader.Gui;

namespace NinjaTrader.NinjaScript.DrawingTools;

[TypeConverter("NinjaTrader.NinjaScript.DrawingTools.GannAngleTypeConverter")]
public class GannAngle : NotifyPropertyChangedBase, IStrokeProvider, ICloneable
{
	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolsGannAngleRatioX", GroupName = "NinjaScriptGeneral")]
	public double RatioX { get; set; }

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolsGannAngleRatioY", GroupName = "NinjaScriptGeneral")]
	public double RatioY { get; set; }

	[Browsable(false)]
	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return null;
		}
	}

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolsPriceLevelIsVisible", GroupName = "NinjaScriptGeneral")]
	public bool IsVisible { get; set; }

	[Browsable(false)]
	[XmlIgnore]
	public bool IsValueVisible { get; set; }

	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolsPriceLevelLineStroke", GroupName = "NinjaScriptGeneral")]
	public Stroke Stroke { get; set; }

	[Browsable(false)]
	[XmlIgnore]
	public object Tag { get; set; }

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object AssemblyClone(Type t)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual object Clone()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void CopyTo(GannAngle other)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GannAngle()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GannAngle(double ratioX, double ratioY, Brush strokeBrush)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static GannAngle()
	{
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
