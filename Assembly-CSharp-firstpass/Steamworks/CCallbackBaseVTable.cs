using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000035 RID: 53
	[StructLayout(LayoutKind.Sequential)]
	internal class CCallbackBaseVTable
	{
		// Token: 0x06000325 RID: 805 RVA: 0x0000F9DB File Offset: 0x0000DDDB
		public CCallbackBaseVTable()
		{
		}

		// Token: 0x04000196 RID: 406
		private const CallingConvention cc = CallingConvention.StdCall;

		// Token: 0x04000197 RID: 407
		[NonSerialized]
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public CCallbackBaseVTable.RunCRDel m_RunCallResult;

		// Token: 0x04000198 RID: 408
		[NonSerialized]
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public CCallbackBaseVTable.RunCBDel m_RunCallback;

		// Token: 0x04000199 RID: 409
		[NonSerialized]
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public CCallbackBaseVTable.GetCallbackSizeBytesDel m_GetCallbackSizeBytes;

		// Token: 0x02000036 RID: 54
		// (Invoke) Token: 0x06000327 RID: 807
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void RunCBDel(IntPtr pvParam);

		// Token: 0x02000037 RID: 55
		// (Invoke) Token: 0x0600032B RID: 811
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void RunCRDel(IntPtr pvParam, [MarshalAs(UnmanagedType.I1)] bool bIOFailure, ulong hSteamAPICall);

		// Token: 0x02000038 RID: 56
		// (Invoke) Token: 0x0600032F RID: 815
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate int GetCallbackSizeBytesDel();
	}
}
