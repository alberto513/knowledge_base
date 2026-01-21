using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using NinjaTrader.Custom;
using NinjaTrader.Gui;

namespace NinjaTrader.NinjaScript.DrawingTools;

public abstract class PriceLevelContainer : DrawingTool
{
	[Display(ResourceType = typeof(Resource), Name = "NinjaScriptDrawingToolsPriceLevels", Prompt = "NinjaScriptDrawingToolsPriceLevelsPrompt", GroupName = "NinjaScriptLines", Order = 99)]
	[SkipOnCopyTo(true)]
	[PropertyEditor("NinjaTrader.Gui.Tools.CollectionEditor")]
	public List<PriceLevel> PriceLevels { get; set; }

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CopyTo(NinjaScript ninjaScript)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected PriceLevelContainer()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAllPriceLevelsRenderTarget()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static PriceLevelContainer()
	{
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
