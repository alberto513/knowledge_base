using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NinjaTrader.Gui.DrawingTools;

namespace NinjaTrader.NinjaScript.DrawingTools;

public class RegressionChannelTypeConverter : DrawingToolPropertiesConverter
{
	public override bool GetPropertiesSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static RegressionChannelTypeConverter()
	{
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
