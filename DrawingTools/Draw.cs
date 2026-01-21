using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Tools;

namespace NinjaTrader.NinjaScript.DrawingTools;

public static class Draw
{
	private static readonly Brush defaultRegionBrush;

	private const int defaultRegionOpacity = 25;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static AndrewsPitchfork AndrewsPitchforkCore(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, DateTime anchor1Time, double anchor1Y, int anchor2BarsAgo, DateTime anchor2Time, double anchor2Y, int anchor3BarsAgo, DateTime anchor3Time, double anchor3Y, Brush brush, DashStyleHelper dashStyle, int width, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AndrewsPitchfork AndrewsPitchfork(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AndrewsPitchfork AndrewsPitchfork(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AndrewsPitchfork AndrewsPitchfork(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AndrewsPitchfork AndrewsPitchfork(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Arc ArcCore(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Arc Arc(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Arc Arc(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Arc Arc(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Arc Arc(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Arc Arc(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Arc Arc(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Arc Arc(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Arc Arc(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static T ChartMarkerCore<T>(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, DateTime time, double yVal, Brush brush, bool isGlobal, string templateName) where T : ChartMarker
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowDown ArrowDown(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowDown ArrowDown(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowDown ArrowDown(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowDown ArrowDown(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowDown ArrowDown(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowDown ArrowDown(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowUp ArrowUp(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowUp ArrowUp(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowUp ArrowUp(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowUp ArrowUp(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowUp ArrowUp(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowUp ArrowUp(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Diamond Diamond(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Diamond Diamond(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Diamond Diamond(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Diamond Diamond(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Diamond Diamond(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Diamond Diamond(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Dot Dot(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Dot Dot(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Dot Dot(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Dot Dot(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Dot Dot(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Dot Dot(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Square Square(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Square Square(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Square Square(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Square Square(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Square Square(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Square Square(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TriangleDown TriangleDown(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TriangleDown TriangleDown(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TriangleDown TriangleDown(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TriangleDown TriangleDown(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TriangleDown TriangleDown(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TriangleDown TriangleDown(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TriangleUp TriangleUp(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TriangleUp TriangleUp(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TriangleUp TriangleUp(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TriangleUp TriangleUp(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TriangleUp TriangleUp(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TriangleUp TriangleUp(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static T FibonacciCore<T>(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, bool isGlobal, string templateName) where T : FibonacciLevels
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static FibonacciExtensions FibonacciExtensionsCore(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, int extensionBarsAgo, DateTime extensionTime, double extensionY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FibonacciCircle FibonacciCircle(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FibonacciCircle FibonacciCircle(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FibonacciCircle FibonacciCircle(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FibonacciCircle FibonacciCircle(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FibonacciExtensions FibonacciExtensions(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, int extensionBarsAgo, double extensionY)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FibonacciExtensions FibonacciExtensions(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, DateTime extensionTime, double extensionY)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FibonacciExtensions FibonacciExtensions(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, DateTime extensionTime, double extensionY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FibonacciExtensions FibonacciExtensions(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, int extensionBarsAgo, double extensionY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FibonacciRetracements FibonacciRetracements(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FibonacciRetracements FibonacciRetracements(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FibonacciRetracements FibonacciRetracements(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FibonacciRetracements FibonacciRetracements(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FibonacciTimeExtensions FibonacciTimeExtensions(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FibonacciTimeExtensions FibonacciTimeExtensions(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FibonacciTimeExtensions FibonacciTimeExtensions(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static FibonacciTimeExtensions FibonacciTimeExtensions(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static GannFan GannFanCore(NinjaScriptBase owner, bool isAutoScale, string tag, int barsAgo, DateTime time, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static GannFan GannFan(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static GannFan GannFan(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static GannFan GannFan(NinjaScriptBase owner, string tag, bool isAutoScale, int barsAgo, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static GannFan GannFan(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime time, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static T DrawLineTypeCore<T>(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool isGlobal, string templateName) where T : Line
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static ArrowLine ArrowLineCore(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowLine ArrowLine(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowLine ArrowLine(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowLine ArrowLine(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowLine ArrowLine(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowLine ArrowLine(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowLine ArrowLine(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ArrowLine ArrowLine(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static ExtendedLine ExtendedLineCore(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ExtendedLine ExtendedLine(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static HorizontalLine HorizontalLineCore(NinjaScriptBase owner, bool isAutoScale, string tag, double y, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	public static HorizontalLine HorizontalLine(NinjaScriptBase owner, string tag, double y, Brush brush)
	{
		return HorizontalLineCore(owner, isAutoScale: false, tag, y, brush, (DashStyleHelper)0, 1);
	}

	public static HorizontalLine HorizontalLine(NinjaScriptBase owner, string tag, double y, Brush brush, DashStyleHelper dashStyle, int width)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		return HorizontalLineCore(owner, isAutoScale: false, tag, y, brush, dashStyle, width);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static HorizontalLine HorizontalLine(NinjaScriptBase owner, string tag, double y, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static HorizontalLine HorizontalLine(NinjaScriptBase owner, string tag, double y, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static HorizontalLine HorizontalLine(NinjaScriptBase owner, string tag, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static HorizontalLine HorizontalLine(NinjaScriptBase owner, string tag, bool isAutoScale, double y, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static HorizontalLine HorizontalLine(NinjaScriptBase owner, string tag, bool isAutoscale, double y, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Line Line(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Line Line(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Line Line(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Line Line(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Line Line(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Line Line(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Line Line(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Line Line(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Line Line(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Line Line(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static VerticalLine VerticalLineCore(NinjaScriptBase owner, bool isAutoScale, string tag, int barsAgo, DateTime time, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static VerticalLine VerticalLine(NinjaScriptBase owner, string tag, DateTime time, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static VerticalLine VerticalLine(NinjaScriptBase owner, string tag, DateTime time, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static VerticalLine VerticalLine(NinjaScriptBase owner, string tag, int barsAgo, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static VerticalLine VerticalLine(NinjaScriptBase owner, string tag, int barsAgo, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static VerticalLine VerticalLine(NinjaScriptBase owner, string tag, DateTime time, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static VerticalLine VerticalLine(NinjaScriptBase owner, string tag, int barsAgo, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static VerticalLine VerticalLine(NinjaScriptBase owner, string tag, int barsAgo, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static VerticalLine VerticalLine(NinjaScriptBase owner, string tag, DateTime time, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Ray RayCore(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ray Ray(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ray Ray(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ray Ray(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ray Ray(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ray Ray(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ray Ray(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, DashStyleHelper dashStyle, int width, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ray Ray(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ray Ray(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static PathTool PathCore(NinjaScriptBase owner, string tag, bool isAutoScale, List<ChartAnchor> chartAnchors, Brush brush, DashStyleHelper dashStyle, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static PathTool PathBasic(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, DateTime anchor1Time, double anchor1Y, int anchor2BarsAgo, DateTime anchor2Time, double anchor2Y, int anchor3BarsAgo, DateTime anchor3Time, double anchor3Y, int anchor4BarsAgo, DateTime anchor4Time, double anchor4Y, int anchor5BarsAgo, DateTime anchor5Time, double anchor5Y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PathTool PathTool(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PathTool PathTool(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PathTool PathTool(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y, int anchor4BarsAgo, double anchor4Y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PathTool PathTool(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y, DateTime anchor4Time, double anchor4Y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PathTool PathTool(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y, int anchor4BarsAgo, double anchor4Y, int anchor5BarsAgo, double anchor5Y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PathTool PathTool(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y, DateTime anchor4Time, double anchor4Y, DateTime anchor5Time, double anchor5Y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PathTool PathTool(NinjaScriptBase owner, string tag, bool isAutoScale, List<ChartAnchor> chartAnchors, Brush brush, DashStyleHelper dashStyle)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PathTool PathTool(NinjaScriptBase owner, string tag, bool isAutoScale, List<ChartAnchor> chartAnchors, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Polygon PolygonCore(NinjaScriptBase owner, string tag, bool isAutoScale, List<ChartAnchor> chartAnchors, Brush brush, DashStyleHelper dashStyle, Brush areaBrush, int areaOpacity, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Polygon PolygonBasic(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, DateTime anchor1Time, double anchor1Y, int anchor2BarsAgo, DateTime anchor2Time, double anchor2Y, int anchor3BarsAgo, DateTime anchor3Time, double anchor3Y, int anchor4BarsAgo, DateTime anchor4Time, double anchor4Y, int anchor5BarsAgo, DateTime anchor5Time, double anchor5Y, int anchor6BarsAgo, DateTime anchor6Time, double anchor6Y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Polygon Polygon(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y, int anchor4BarsAgo, double anchor4Y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Polygon Polygon(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y, DateTime anchor4Time, double anchor4Y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Polygon Polygon(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y, int anchor4BarsAgo, double anchor4Y, int anchor5BarsAgo, double anchor5Y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Polygon Polygon(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y, DateTime anchor4Time, double anchor4Y, DateTime anchor5Time, double anchor5Y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Polygon Polygon(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y, int anchor4BarsAgo, double anchor4Y, int anchor5BarsAgo, double anchor5Y, int anchor6BarsAgo, double anchor6Y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Polygon Polygon(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y, DateTime anchor4Time, double anchor4Y, DateTime anchor5Time, double anchor5Y, DateTime anchor6Time, double anchor6Y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Polygon Polygon(NinjaScriptBase owner, string tag, bool isAutoScale, List<ChartAnchor> chartAnchors, Brush brush, DashStyleHelper dashStyle, Brush areaBrush, int areaOpacity)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Polygon Polygon(NinjaScriptBase owner, string tag, bool isAutoScale, List<ChartAnchor> chartAnchors, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Region Region(NinjaScriptBase owner, string tag, int startBarsAgo, DateTime startTime, int endBarsAgo, DateTime endTime, ISeries<double> series1, ISeries<double> series2, double price, Brush outlineBrush, Brush areaBrush, int areaOpacity, int displacement)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Region Region(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, ISeries<double> series, double price, Brush areaBrush, int areaOpacity, int displacement = 0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Region Region(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, ISeries<double> series1, ISeries<double> series2, Brush outlineBrush, Brush areaBrush, int areaOpacity, int displacement = 0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Region Region(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, ISeries<double> series, double price, Brush areaBrush, int areaOpacity)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Region Region(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, ISeries<double> series1, ISeries<double> series2, Brush outlineBrush, Brush areaBrush, int areaOpacity)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static T RegionHighlightCore<T>(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, Brush brush, Brush areaBrush, int areaOpacity, bool isGlobal, string templateName) where T : RegionHighlightBase
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CLSCompliant(false)]
	public static RegionHighlightX RegionHighlightX(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CLSCompliant(false)]
	public static RegionHighlightX RegionHighlightX(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CLSCompliant(false)]
	public static RegionHighlightX RegionHighlightX(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, Brush brush, Brush areaBrush, int areaOpacity)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CLSCompliant(false)]
	public static RegionHighlightX RegionHighlightX(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, Brush brush, Brush areaBrush, int areaOpacity)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CLSCompliant(false)]
	public static RegionHighlightX RegionHighlightX(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CLSCompliant(false)]
	public static RegionHighlightX RegionHighlightX(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CLSCompliant(false)]
	public static RegionHighlightY RegionHighlightY(NinjaScriptBase owner, string tag, double startY, double endY, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CLSCompliant(false)]
	public static RegionHighlightY RegionHighlightY(NinjaScriptBase owner, string tag, bool isAutoScale, double startY, double endY, Brush brush, Brush areaBrush, int areaOpacity)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CLSCompliant(false)]
	public static RegionHighlightY RegionHighlightY(NinjaScriptBase owner, string tag, double startY, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static RegressionChannel RegressionChannelCore(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, DateTime startTime, int endBarsAgo, DateTime endTime, Brush upperBrush, DashStyleHelper upperDashStyle, float? upperWidth, Brush middleBrush, DashStyleHelper middleDashStyle, float? middleWidth, Brush lowerBrush, DashStyleHelper lowerDashStyle, float? lowerWidth, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static RegressionChannel RegressionChannel(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static RegressionChannel RegressionChannel(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static RegressionChannel RegressionChannel(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, int endBarsAgo, Brush upperBrush, DashStyleHelper upperDashStyle, int upperWidth, Brush middleBrush, DashStyleHelper middleDashStyle, int middleWidth, Brush lowerBrush, DashStyleHelper lowerDashStyle, int lowerWidth)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static RegressionChannel RegressionChannel(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, DateTime endTime, Brush upperBrush, DashStyleHelper upperDashStyle, int upperWidth, Brush middleBrush, DashStyleHelper middleDashStyle, int middleWidth, Brush lowerBrush, DashStyleHelper lowerDashStyle, int lowerWidth)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static RegressionChannel RegressionChannel(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static RegressionChannel RegressionChannel(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static RiskReward RiskRewardCore(NinjaScriptBase owner, string tag, bool isAutoScale, int entryBarsAgo, DateTime entryTime, double entryY, int stopBarsAgo, DateTime stopTime, double stopY, int targetBarsAgo, DateTime targetTime, double targetY, double ratio, bool isStop, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static RiskReward RiskReward(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime entryTime, double entryY, DateTime endTime, double endY, double ratio, bool isStop)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static RiskReward RiskReward(NinjaScriptBase owner, string tag, bool isAutoScale, int entryBarsAgo, double entryY, int endBarsAgo, double endY, double ratio, bool isStop)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static RiskReward RiskReward(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime entryTime, double entryY, DateTime endTime, double endY, double ratio, bool isStop, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static RiskReward RiskReward(NinjaScriptBase owner, string tag, bool isAutoScale, int entryBarsAgo, double entryY, int endBarsAgo, double endY, double ratio, bool isStop, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Ruler RulerCore(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, DateTime startTime, double startY, int endBarsAgo, DateTime endTime, double endY, int textBarsAgo, DateTime textTime, double textY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ruler Ruler(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, int textBarsAgo, double textY)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ruler Ruler(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, DateTime textTime, double textY)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ruler Ruler(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, int textBarsAgo, double textY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ruler Ruler(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, DateTime textTime, double textY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static T ShapeCore<T>(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, int endBarsAgo, DateTime startTime, DateTime endTime, double startY, double endY, Brush brush, Brush areaBrush, int areaOpacity, bool isGlobal, string templateName) where T : ShapeBase
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Triangle TriangleCore(NinjaScriptBase owner, bool isAutoScale, string tag, int startBarsAgo, int midBarsAgo, int endBarsAgo, DateTime startTime, DateTime midTime, DateTime endTime, double startY, double midY, double endY, Brush color, Brush areaColor, int areaOpacity, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ellipse Ellipse(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ellipse Ellipse(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, Brush areaBrush, int areaOpacity)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ellipse Ellipse(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ellipse Ellipse(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, Brush areaBrush, int areaOpacity)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ellipse Ellipse(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ellipse Ellipse(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, Brush areaBrush, int areaOpacity, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ellipse Ellipse(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ellipse Ellipse(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, Brush areaBrush, int areaOpacity, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ellipse Ellipse(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Ellipse Ellipse(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Rectangle Rectangle(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Rectangle Rectangle(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Rectangle Rectangle(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, Brush areaBrush, int areaOpacity)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Rectangle Rectangle(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, Brush areaBrush, int areaOpacity)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Rectangle Rectangle(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Rectangle Rectangle(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int endBarsAgo, double endY, Brush brush, Brush areaBrush, int areaOpacity, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Rectangle Rectangle(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime endTime, double endY, Brush brush, Brush areaBrush, int areaOpacity, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Rectangle Rectangle(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int endBarsAgo, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Rectangle Rectangle(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime endTime, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Triangle Triangle(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int middleBarsAgo, double middleY, int endBarsAgo, double endY, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Triangle Triangle(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime middleTime, double middleY, DateTime endTime, double endY, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Triangle Triangle(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int middleBarsAgo, double middleY, int endBarsAgo, double endY, Brush brush, Brush areaBrush, int areaOpacity)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Triangle Triangle(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime midTime, double middleY, DateTime endTime, double endY, Brush brush, Brush areaBrush, int areaOpacity)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Triangle Triangle(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int middleBarsAgo, double middleY, int endBarsAgo, double endY, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Triangle Triangle(NinjaScriptBase owner, string tag, bool isAutoScale, int startBarsAgo, double startY, int middleBarsAgo, double middleY, int endBarsAgo, double endY, Brush brush, Brush areaBrush, int areaOpacity, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Triangle Triangle(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime startTime, double startY, DateTime midTime, double middleY, DateTime endTime, double endY, Brush brush, Brush areaBrush, int areaOpacity, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Triangle Triangle(NinjaScriptBase owner, string tag, int startBarsAgo, double startY, int middleBarsAgo, double middleY, int endBarsAgo, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Triangle Triangle(NinjaScriptBase owner, string tag, DateTime startTime, double startY, DateTime middleTime, double middleY, DateTime endTime, double endY, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Text TextCore(NinjaScriptBase owner, string tag, bool autoScale, string text, int barsAgo, DateTime time, double y, int? yPixelOffset, Brush textBrush, TextAlignment? textAlignment, SimpleFont font, Brush outlineBrush, Brush areaBrush, int? areaOpacity, bool isGlobal, string templateName, DashStyleHelper outlineDashStyle, int outlineWidth)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Text Text(NinjaScriptBase owner, string tag, string text, int barsAgo, double y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Text Text(NinjaScriptBase owner, string tag, string text, int barsAgo, double y, Brush textBrush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Text Text(NinjaScriptBase owner, string tag, string text, int barsAgo, double y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Text Text(NinjaScriptBase owner, string tag, bool isAutoScale, string text, int barsAgo, double y, int yPixelOffset, Brush textBrush, SimpleFont font, TextAlignment alignment, Brush outlineBrush, Brush areaBrush, int areaOpacity)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Text Text(NinjaScriptBase owner, string tag, bool isAutoScale, string text, DateTime time, double y, int yPixelOffset, Brush textBrush, SimpleFont font, TextAlignment alignment, Brush outlineBrush, Brush areaBrush, int areaOpacity)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Text Text(NinjaScriptBase owner, string tag, bool isAutoScale, string text, int barsAgo, double y, int yPixelOffset, Brush textBrush, SimpleFont font, TextAlignment alignment, Brush outlineBrush, Brush areaBrush, int areaOpacity, DashStyleHelper outlineDashStyle, int outlineWidth, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Text Text(NinjaScriptBase owner, string tag, bool isAutoScale, string text, DateTime time, double y, int yPixelOffset, Brush textBrush, SimpleFont font, TextAlignment alignment, Brush outlineBrush, Brush areaBrush, int areaOpacity, DashStyleHelper outlineDashStyle, int outlineWidth, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static TextFixed TextFixedCore(NinjaScriptBase owner, string tag, string text, TextPosition textPosition, Brush textBrush, SimpleFont font, Brush outlineBrush, Brush areaBrush, int? areaOpacity, bool isGlobal, string templateName, DashStyleHelper outlineDashStyle, int outlineWidth)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextFixed TextFixed(NinjaScriptBase owner, string tag, string text, TextPosition textPosition, Brush textBrush, SimpleFont font, Brush outlineBrush, Brush areaBrush, int areaOpacity)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextFixed TextFixed(NinjaScriptBase owner, string tag, string text, TextPosition textPosition, Brush textBrush, SimpleFont font, Brush outlineBrush, Brush areaBrush, int areaOpacity, DashStyleHelper outlineDashStyle, int outlineWidth, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextFixed TextFixed(NinjaScriptBase owner, string tag, string text, TextPosition textPosition)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextFixed TextFixed(NinjaScriptBase owner, string tag, string text, TextPosition textPosition, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static TimeCycles TimeCyclesCore(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, DateTime startTime, DateTime endTime, Brush brush, Brush areaBrush, int areaOpacity, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, Brush brush, Brush areaBrush, int areaOpacity)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, Brush brush)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, Brush brush, Brush areaBrush, int areaOpacity)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, Brush brush, Brush areaBrush, int areaOpacity, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, Brush brush, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, Brush brush, Brush areaBrush, int areaOpacity, bool drawOnPricePanel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, int startBarsAgo, int endBarsAgo, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TimeCycles TimeCycles(NinjaScriptBase owner, string tag, DateTime startTime, DateTime endTime, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static TrendChannel TrendChannelCore(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, DateTime anchor1Time, double anchor1Y, int anchor2BarsAgo, DateTime anchor2Time, double anchor2Y, int anchor3BarsAgo, DateTime anchor3Time, double anchor3Y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TrendChannel TrendChannel(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TrendChannel TrendChannel(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TrendChannel TrendChannel(NinjaScriptBase owner, string tag, bool isAutoScale, int anchor1BarsAgo, double anchor1Y, int anchor2BarsAgo, double anchor2Y, int anchor3BarsAgo, double anchor3Y, bool isGlobal, string templateName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TrendChannel TrendChannel(NinjaScriptBase owner, string tag, bool isAutoScale, DateTime anchor1Time, double anchor1Y, DateTime anchor2Time, double anchor2Y, DateTime anchor3Time, double anchor3Y, bool isGlobal, string templateName)
	{
		return null;
	}

	static Draw()
	{
		_003CAgileDotNetRT_003E.Initialize();
		_003CAgileDotNetRT_003E.PostInitialize();
		defaultRegionBrush = Brushes.Goldenrod;
	}
}
