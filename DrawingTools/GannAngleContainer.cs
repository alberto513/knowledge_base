using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using NinjaTrader.Custom;
using NinjaTrader.Gui;

namespace NinjaTrader.NinjaScript.DrawingTools;

public abstract class GannAngleContainer : DrawingTool
{
	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolsGannAngles", Prompt = "NinjaScriptDrawingToolsGannAnglesPrompt", GroupName = "NinjaScriptGeneral", Order = 99)]
	[PropertyEditor("NinjaTrader.Gui.Tools.CollectionEditor")]
	[SkipOnCopyTo(true)]
	public List<GannAngle> GannAngles { get; set; }

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CopyTo(NinjaScript ninjaScript)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected GannAngleContainer()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static GannAngleContainer()
	{
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
