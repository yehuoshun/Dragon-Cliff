using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000051 RID: 81
	public class ISteamMatchmakingRulesResponse
	{
		// Token: 0x0600038B RID: 907 RVA: 0x0000FE7C File Offset: 0x0000E27C
		public ISteamMatchmakingRulesResponse(ISteamMatchmakingRulesResponse.RulesResponded onRulesResponded, ISteamMatchmakingRulesResponse.RulesFailedToRespond onRulesFailedToRespond, ISteamMatchmakingRulesResponse.RulesRefreshComplete onRulesRefreshComplete)
		{
			if (onRulesResponded == null || onRulesFailedToRespond == null || onRulesRefreshComplete == null)
			{
				throw new ArgumentNullException();
			}
			this.m_RulesResponded = onRulesResponded;
			this.m_RulesFailedToRespond = onRulesFailedToRespond;
			this.m_RulesRefreshComplete = onRulesRefreshComplete;
			this.m_VTable = new ISteamMatchmakingRulesResponse.VTable
			{
				m_VTRulesResponded = new ISteamMatchmakingRulesResponse.InternalRulesResponded(this.InternalOnRulesResponded),
				m_VTRulesFailedToRespond = new ISteamMatchmakingRulesResponse.InternalRulesFailedToRespond(this.InternalOnRulesFailedToRespond),
				m_VTRulesRefreshComplete = new ISteamMatchmakingRulesResponse.InternalRulesRefreshComplete(this.InternalOnRulesRefreshComplete)
			};
			this.m_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ISteamMatchmakingRulesResponse.VTable)));
			Marshal.StructureToPtr(this.m_VTable, this.m_pVTable, false);
			this.m_pGCHandle = GCHandle.Alloc(this.m_pVTable, GCHandleType.Pinned);
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0000FF44 File Offset: 0x0000E344
		~ISteamMatchmakingRulesResponse()
		{
			if (this.m_pVTable != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.m_pVTable);
			}
			if (this.m_pGCHandle.IsAllocated)
			{
				this.m_pGCHandle.Free();
			}
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0000FFA8 File Offset: 0x0000E3A8
		private void InternalOnRulesResponded(IntPtr pchRule, IntPtr pchValue)
		{
			this.m_RulesResponded(InteropHelp.PtrToStringUTF8(pchRule), InteropHelp.PtrToStringUTF8(pchValue));
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0000FFC1 File Offset: 0x0000E3C1
		private void InternalOnRulesFailedToRespond()
		{
			this.m_RulesFailedToRespond();
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0000FFCE File Offset: 0x0000E3CE
		private void InternalOnRulesRefreshComplete()
		{
			this.m_RulesRefreshComplete();
		}

		// Token: 0x06000390 RID: 912 RVA: 0x0000FFDB File Offset: 0x0000E3DB
		public static explicit operator IntPtr(ISteamMatchmakingRulesResponse that)
		{
			return that.m_pGCHandle.AddrOfPinnedObject();
		}

		// Token: 0x040001B4 RID: 436
		private ISteamMatchmakingRulesResponse.VTable m_VTable;

		// Token: 0x040001B5 RID: 437
		private IntPtr m_pVTable;

		// Token: 0x040001B6 RID: 438
		private GCHandle m_pGCHandle;

		// Token: 0x040001B7 RID: 439
		private ISteamMatchmakingRulesResponse.RulesResponded m_RulesResponded;

		// Token: 0x040001B8 RID: 440
		private ISteamMatchmakingRulesResponse.RulesFailedToRespond m_RulesFailedToRespond;

		// Token: 0x040001B9 RID: 441
		private ISteamMatchmakingRulesResponse.RulesRefreshComplete m_RulesRefreshComplete;

		// Token: 0x02000052 RID: 82
		// (Invoke) Token: 0x06000392 RID: 914
		public delegate void RulesResponded(string pchRule, string pchValue);

		// Token: 0x02000053 RID: 83
		// (Invoke) Token: 0x06000396 RID: 918
		public delegate void RulesFailedToRespond();

		// Token: 0x02000054 RID: 84
		// (Invoke) Token: 0x0600039A RID: 922
		public delegate void RulesRefreshComplete();

		// Token: 0x02000055 RID: 85
		// (Invoke) Token: 0x0600039E RID: 926
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalRulesResponded(IntPtr pchRule, IntPtr pchValue);

		// Token: 0x02000056 RID: 86
		// (Invoke) Token: 0x060003A2 RID: 930
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalRulesFailedToRespond();

		// Token: 0x02000057 RID: 87
		// (Invoke) Token: 0x060003A6 RID: 934
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalRulesRefreshComplete();

		// Token: 0x02000058 RID: 88
		[StructLayout(LayoutKind.Sequential)]
		private class VTable
		{
			// Token: 0x060003A9 RID: 937 RVA: 0x0000FFE8 File Offset: 0x0000E3E8
			public VTable()
			{
			}

			// Token: 0x040001BA RID: 442
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingRulesResponse.InternalRulesResponded m_VTRulesResponded;

			// Token: 0x040001BB RID: 443
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingRulesResponse.InternalRulesFailedToRespond m_VTRulesFailedToRespond;

			// Token: 0x040001BC RID: 444
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingRulesResponse.InternalRulesRefreshComplete m_VTRulesRefreshComplete;
		}
	}
}
