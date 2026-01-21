using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using NinjaTrader.Gui.Chart;

namespace NinjaTrader.NinjaScript.DrawingTools;

public abstract class TriangleBase : ChartMarker
{
	[XmlIgnore]
	[Browsable(false)]
	public bool IsUpTriangle { get; protected set; }

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRender(ChartControl chartControl, ChartScale chartScale)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static TriangleBase()
	{
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
