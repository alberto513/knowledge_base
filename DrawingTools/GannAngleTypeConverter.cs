using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NinjaTrader.NinjaScript.DrawingTools;

public class GannAngleTypeConverter : TypeConverter
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object component, Attribute[] attrs)
	{
		return null;
	}

	public override bool GetPropertiesSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static GannAngleTypeConverter()
	{
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
	}
}
