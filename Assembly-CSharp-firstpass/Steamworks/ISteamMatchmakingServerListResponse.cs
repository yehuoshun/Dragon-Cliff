using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200003B RID: 59
	public class ISteamMatchmakingServerListResponse
	{
		// Token: 0x06000337 RID: 823 RVA: 0x0000FA60 File Offset: 0x0000DE60
		public ISteamMatchmakingServerListResponse(ISteamMatchmakingServerListResponse.ServerResponded onServerResponded, ISteamMatchmakingServerListResponse.ServerFailedToRespond onServerFailedToRespond, ISteamMatchmakingServerListResponse.RefreshComplete onRefreshComplete)
		{
			if (onServerResponded == null || onServerFailedToRespond == null || onRefreshComplete == null)
			{
				throw new ArgumentNullException();
			}
			this.m_ServerResponded = onServerResponded;
			this.m_ServerFailedToRespond = onServerFailedToRespond;
			this.m_RefreshComplete = onRefreshComplete;
			this.m_VTable = new ISteamMatchmakingServerListResponse.VTable
			{
				m_VTServerResponded = new ISteamMatchmakingServerListResponse.InternalServerResponded(this.InternalOnServerResponded),
				m_VTServerFailedToRespond = new ISteamMatchmakingServerListResponse.InternalServerFailedToRespond(this.InternalOnServerFailedToRespond),
				m_VTRefreshComplete = new ISteamMatchmakingServerListResponse.InternalRefreshComplete(this.InternalOnRefreshComplete)
			};
			this.m_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ISteamMatchmakingServerListResponse.VTable)));
			Marshal.StructureToPtr(this.m_VTable, this.m_pVTable, false);
			this.m_pGCHandle = GCHandle.Alloc(this.m_pVTable, GCHandleType.Pinned);
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0000FB28 File Offset: 0x0000DF28
		~ISteamMatchmakingServerListResponse()
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

		// Token: 0x06000339 RID: 825 RVA: 0x0000FB8C File Offset: 0x0000DF8C
		private void InternalOnServerResponded(HServerListRequest hRequest, int iServer)
		{
			this.m_ServerResponded(hRequest, iServer);
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000FB9B File Offset: 0x0000DF9B
		private void InternalOnServerFailedToRespond(HServerListRequest hRequest, int iServer)
		{
			this.m_ServerFailedToRespond(hRequest, iServer);
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0000FBAA File Offset: 0x0000DFAA
		private void InternalOnRefreshComplete(HServerListRequest hRequest, EMatchMakingServerResponse response)
		{
			this.m_RefreshComplete(hRequest, response);
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0000FBB9 File Offset: 0x0000DFB9
		public static explicit operator IntPtr(ISteamMatchmakingServerListResponse that)
		{
			return that.m_pGCHandle.AddrOfPinnedObject();
		}

		// Token: 0x0400019B RID: 411
		private ISteamMatchmakingServerListResponse.VTable m_VTable;

		// Token: 0x0400019C RID: 412
		private IntPtr m_pVTable;

		// Token: 0x0400019D RID: 413
		private GCHandle m_pGCHandle;

		// Token: 0x0400019E RID: 414
		private ISteamMatchmakingServerListResponse.ServerResponded m_ServerResponded;

		// Token: 0x0400019F RID: 415
		private ISteamMatchmakingServerListResponse.ServerFailedToRespond m_ServerFailedToRespond;

		// Token: 0x040001A0 RID: 416
		private ISteamMatchmakingServerListResponse.RefreshComplete m_RefreshComplete;

		// Token: 0x0200003C RID: 60
		// (Invoke) Token: 0x0600033E RID: 830
		public delegate void ServerResponded(HServerListRequest hRequest, int iServer);

		// Token: 0x0200003D RID: 61
		// (Invoke) Token: 0x06000342 RID: 834
		public delegate void ServerFailedToRespond(HServerListRequest hRequest, int iServer);

		// Token: 0x0200003E RID: 62
		// (Invoke) Token: 0x06000346 RID: 838
		public delegate void RefreshComplete(HServerListRequest hRequest, EMatchMakingServerResponse response);

		// Token: 0x0200003F RID: 63
		// (Invoke) Token: 0x0600034A RID: 842
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalServerResponded(HServerListRequest hRequest, int iServer);

		// Token: 0x02000040 RID: 64
		// (Invoke) Token: 0x0600034E RID: 846
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalServerFailedToRespond(HServerListRequest hRequest, int iServer);

		// Token: 0x02000041 RID: 65
		// (Invoke) Token: 0x06000352 RID: 850
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalRefreshComplete(HServerListRequest hRequest, EMatchMakingServerResponse response);

		// Token: 0x02000042 RID: 66
		[StructLayout(LayoutKind.Sequential)]
		private class VTable
		{
			// Token: 0x06000355 RID: 853 RVA: 0x0000FBC6 File Offset: 0x0000DFC6
			public VTable()
			{
			}

			// Token: 0x040001A1 RID: 417
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingServerListResponse.InternalServerResponded m_VTServerResponded;

			// Token: 0x040001A2 RID: 418
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingServerListResponse.InternalServerFailedToRespond m_VTServerFailedToRespond;

			// Token: 0x040001A3 RID: 419
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingServerListResponse.InternalRefreshComplete m_VTRefreshComplete;
		}
	}
}
