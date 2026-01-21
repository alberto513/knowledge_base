using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.AccessControl;
using System.Security.Principal;

[SecuritySafeCritical]
internal class _003CAgileDotNetRT_003E
{
	private static bool inited;

	private static Assembly runtimeAssembly;

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
	[MethodImpl(MethodImplOptions.ForwardRef)]
	private static extern IntPtr LoadLibraryA(string P_0);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
	[MethodImpl(MethodImplOptions.ForwardRef)]
	private static extern IntPtr GetProcAddress(IntPtr P_0, string P_1);

	[DllImport("AgileDotNetRT.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
	[MethodImpl(MethodImplOptions.ForwardRef)]
	private static extern int _Initialize(IntPtr P_0);

	[DllImport("AgileDotNetRT64.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
	[MethodImpl(MethodImplOptions.ForwardRef)]
	private static extern int _Initialize64(IntPtr P_0);

	[DllImport("AgileDotNetRT.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
	[MethodImpl(MethodImplOptions.ForwardRef)]
	private static extern void _AtExit();

	[DllImport("AgileDotNetRT64.dll", CharSet = CharSet.Ansi, EntryPoint = "_AtExit", ExactSpelling = true)]
	[MethodImpl(MethodImplOptions.ForwardRef)]
	private static extern void _AtExit64();

	internal static IntPtr Load()
	{
		lock (typeof(_003CAgileDotNetRT_003E))
		{
			WindowsImpersonationContext windowsImpersonationContext = default(WindowsImpersonationContext);
			try
			{
				windowsImpersonationContext = WindowsIdentity.Impersonate(IntPtr.Zero);
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				Stream stream = null;
				string text = null;
				string text2 = null;
				if (IntPtr.Size == 4)
				{
					text = "b74340b8-7d11-472e-8296-f9cd7d2323b5";
					text2 = "AgileDotNetRT";
				}
				else
				{
					text = "9546e718-9fd0-456d-8930-096ad0dd26ea";
					text2 = "AgileDotNetRT64";
				}
				stream = executingAssembly.GetManifestResourceStream(text);
				GZipStream input = new GZipStream(stream, CompressionMode.Decompress);
				BinaryReader binaryReader = new BinaryReader(input);
				byte[] array = binaryReader.ReadBytes(binaryReader.ReadInt32());
				string text3 = $"{Path.GetTempPath()}{text}\\";
				Directory.CreateDirectory(text3);
				string text4 = text3 + text2 + ".dll";
				if (!File.Exists(text4))
				{
					FileStream fileStream = File.OpenWrite(text4);
					fileStream.Write(array, 0, array.Length);
					fileStream.Close();
					FileSystemAccessRule rule = new FileSystemAccessRule(new SecurityIdentifier("S-1-1-0"), FileSystemRights.ReadAndExecute, AccessControlType.Allow);
					FileSecurity accessControl = File.GetAccessControl(text4);
					accessControl.AddAccessRule(rule);
					File.SetAccessControl(text4, accessControl);
				}
				return LoadLibraryA(text4);
			}
			finally
			{
				windowsImpersonationContext.Undo();
			}
		}
	}

	internal static int InitializeThroughDelegate(IntPtr P_0)
	{
		IntPtr intPtr = Load();
		IntPtr procAddress = GetProcAddress(intPtr, "_Initialize");
		InitializeDelegate initializeDelegate = (InitializeDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(InitializeDelegate));
		return initializeDelegate(P_0);
	}

	internal static int InitializeThroughDelegate64(IntPtr P_0)
	{
		IntPtr intPtr = Load();
		IntPtr procAddress = GetProcAddress(intPtr, "_Initialize64");
		InitializeDelegate initializeDelegate = (InitializeDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(InitializeDelegate));
		return initializeDelegate(P_0);
	}

	internal static void ExitThroughDelegate()
	{
		IntPtr intPtr = Load();
		IntPtr procAddress = GetProcAddress(intPtr, "_AtExit");
		ExitDelegate exitDelegate = (ExitDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(ExitDelegate));
		exitDelegate();
	}

	internal static void ExitThroughDelegate64()
	{
		IntPtr intPtr = Load();
		IntPtr procAddress = GetProcAddress(intPtr, "_AtExit64");
		ExitDelegate exitDelegate = (ExitDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(ExitDelegate));
		exitDelegate();
	}

	internal static void DomainUnload(object P_0, EventArgs P_1)
	{
		if (IntPtr.Size == 4)
		{
			ExitThroughDelegate();
		}
		else
		{
			ExitThroughDelegate64();
		}
	}

	internal static void Initialize()
	{
		if (!inited)
		{
			RuntimeMethodHandle methodHandle = new StackTrace().GetFrame(0).GetMethod().MethodHandle;
			if (((IntPtr.Size != 4) ? InitializeThroughDelegate64(methodHandle.Value) : InitializeThroughDelegate(methodHandle.Value)) == 1)
			{
				AppDomain.CurrentDomain.DomainUnload += DomainUnload;
			}
			inited = true;
		}
	}

	internal static void PostInitialize()
	{
	}
}
