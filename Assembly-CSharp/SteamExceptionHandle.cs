using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Steamworks;
using UnityEngine;

// Token: 0x02000942 RID: 2370
internal class SteamExceptionHandle
{
	// Token: 0x06004164 RID: 16740 RVA: 0x001AD9F0 File Offset: 0x001ABDF0
	public SteamExceptionHandle()
	{
	}

	// Token: 0x06004165 RID: 16741 RVA: 0x001AD9F8 File Offset: 0x001ABDF8
	public static void Handle(Exception exception, uint buildId = 0u)
	{
		if (SteamManager.Initialized)
		{
			Thread thread = new Thread(delegate()
			{
				SteamExceptionHandle.Process(exception, buildId);
			});
			thread.Start();
		}
		Debug.LogError(exception.Message);
		if (TestingProcessor.InDiagnose)
		{
			throw exception;
		}
	}

	// Token: 0x06004166 RID: 16742 RVA: 0x001ADA5C File Offset: 0x001ABE5C
	private static void Process(Exception exception, uint buildId)
	{
		uint uStructuredExceptionCode = 3221225477u;
		string str = exception.ToString() + "/n" + exception.StackTrace;
		SteamExceptionHandle.EXCEPTION_RECORD32 exception_RECORD = default(SteamExceptionHandle.EXCEPTION_RECORD32);
		IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SteamExceptionHandle.EXCEPTION_RECORD32)));
		Marshal.StructureToPtr(exception_RECORD, intPtr, false);
		SteamExceptionHandle.CONTEXT_X86 context_X = default(SteamExceptionHandle.CONTEXT_X86);
		IntPtr intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SteamExceptionHandle.CONTEXT_X86)));
		Marshal.StructureToPtr(context_X, intPtr2, false);
		SteamExceptionHandle.EXCEPTION_POINTERS exception_POINTERS = default(SteamExceptionHandle.EXCEPTION_POINTERS);
		exception_POINTERS.ExceptionRecord = intPtr;
		exception_POINTERS.ContextRecord = intPtr2;
		IntPtr intPtr3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SteamExceptionHandle.EXCEPTION_POINTERS)));
		Marshal.StructureToPtr(exception_POINTERS, intPtr3, false);
		NativeMethods.SteamAPI_SetMiniDumpComment(new InteropHelp.UTF8StringHandle(str));
		NativeMethods.SteamAPI_WriteMiniDump(uStructuredExceptionCode, intPtr3, buildId);
		Marshal.FreeHGlobal(intPtr3);
		Marshal.FreeHGlobal(intPtr2);
		Marshal.FreeHGlobal(intPtr);
	}

	// Token: 0x02000943 RID: 2371
	private struct EXCEPTION_POINTERS
	{
		// Token: 0x040030ED RID: 12525
		public IntPtr ExceptionRecord;

		// Token: 0x040030EE RID: 12526
		public IntPtr ContextRecord;
	}

	// Token: 0x02000944 RID: 2372
	private struct EXCEPTION_RECORD32
	{
		// Token: 0x040030EF RID: 12527
		public uint ExceptionCode;

		// Token: 0x040030F0 RID: 12528
		public uint ExceptionFlags;

		// Token: 0x040030F1 RID: 12529
		public IntPtr ExceptionRecord;

		// Token: 0x040030F2 RID: 12530
		public IntPtr ExceptionAddress;

		// Token: 0x040030F3 RID: 12531
		public uint NumberParameters;

		// Token: 0x040030F4 RID: 12532
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
		public IntPtr[] ExceptionInformation;
	}

	// Token: 0x02000945 RID: 2373
	private struct CONTEXT_X86
	{
		// Token: 0x040030F5 RID: 12533
		public uint ContextFlags;

		// Token: 0x040030F6 RID: 12534
		public uint Dr0;

		// Token: 0x040030F7 RID: 12535
		public uint Dr1;

		// Token: 0x040030F8 RID: 12536
		public uint Dr2;

		// Token: 0x040030F9 RID: 12537
		public uint Dr3;

		// Token: 0x040030FA RID: 12538
		public uint Dr6;

		// Token: 0x040030FB RID: 12539
		public uint Dr7;

		// Token: 0x040030FC RID: 12540
		public uint FloatSave_ControlWord;

		// Token: 0x040030FD RID: 12541
		public uint FloatSave_StatusWord;

		// Token: 0x040030FE RID: 12542
		public uint FloatSave_TagWord;

		// Token: 0x040030FF RID: 12543
		public uint FloatSave_ErrorOffset;

		// Token: 0x04003100 RID: 12544
		public uint FloatSave_ErrorSelector;

		// Token: 0x04003101 RID: 12545
		public uint FloatSave_DataOffset;

		// Token: 0x04003102 RID: 12546
		public uint FloatSave_DataSelector;

		// Token: 0x04003103 RID: 12547
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
		public byte[] FloatSave_RegisterArea;

		// Token: 0x04003104 RID: 12548
		public uint FloatSave_Cr0NpxState;

		// Token: 0x04003105 RID: 12549
		public uint SegGs;

		// Token: 0x04003106 RID: 12550
		public uint SegFs;

		// Token: 0x04003107 RID: 12551
		public uint SegEs;

		// Token: 0x04003108 RID: 12552
		public uint SegDs;

		// Token: 0x04003109 RID: 12553
		public uint Edi;

		// Token: 0x0400310A RID: 12554
		public uint Esi;

		// Token: 0x0400310B RID: 12555
		public uint Ebx;

		// Token: 0x0400310C RID: 12556
		public uint Edx;

		// Token: 0x0400310D RID: 12557
		public uint Ecx;

		// Token: 0x0400310E RID: 12558
		public uint Eax;

		// Token: 0x0400310F RID: 12559
		public uint Ebp;

		// Token: 0x04003110 RID: 12560
		public uint Eip;

		// Token: 0x04003111 RID: 12561
		public uint SegCs;

		// Token: 0x04003112 RID: 12562
		public uint EFlags;

		// Token: 0x04003113 RID: 12563
		public uint Esp;

		// Token: 0x04003114 RID: 12564
		public uint SegSs;

		// Token: 0x04003115 RID: 12565
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
		public byte[] ExtendedRegisters;
	}

	// Token: 0x02000FED RID: 4077
	[CompilerGenerated]
	private sealed class <Handle>c__AnonStorey0
	{
		// Token: 0x0600674D RID: 26445 RVA: 0x001ADB43 File Offset: 0x001ABF43
		public <Handle>c__AnonStorey0()
		{
		}

		// Token: 0x0600674E RID: 26446 RVA: 0x001ADB4B File Offset: 0x001ABF4B
		internal void <>m__0()
		{
			SteamExceptionHandle.Process(this.exception, this.buildId);
		}

		// Token: 0x0400612B RID: 24875
		internal Exception exception;

		// Token: 0x0400612C RID: 24876
		internal uint buildId;
	}
}
