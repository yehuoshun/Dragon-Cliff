using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000043 RID: 67
	public class ISteamMatchmakingPingResponse
	{
		// Token: 0x06000356 RID: 854 RVA: 0x0000FBD0 File Offset: 0x0000DFD0
		public ISteamMatchmakingPingResponse(ISteamMatchmakingPingResponse.ServerResponded onServerResponded, ISteamMatchmakingPingResponse.ServerFailedToRespond onServerFailedToRespond)
		{
			if (onServerResponded == null || onServerFailedToRespond == null)
			{
				throw new ArgumentNullException();
			}
			this.m_ServerResponded = onServerResponded;
			this.m_ServerFailedToRespond = onServerFailedToRespond;
			this.m_VTable = new ISteamMatchmakingPingResponse.VTable
			{
				m_VTServerResponded = new ISteamMatchmakingPingResponse.InternalServerResponded(this.InternalOnServerResponded),
				m_VTServerFailedToRespond = new ISteamMatchmakingPingResponse.InternalServerFailedToRespond(this.InternalOnServerFailedToRespond)
			};
			this.m_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ISteamMatchmakingPingResponse.VTable)));
			Marshal.StructureToPtr(this.m_VTable, this.m_pVTable, false);
			this.m_pGCHandle = GCHandle.Alloc(this.m_pVTable, GCHandleType.Pinned);
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0000FC78 File Offset: 0x0000E078
		~ISteamMatchmakingPingResponse()
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

		// Token: 0x06000358 RID: 856 RVA: 0x0000FCDC File Offset: 0x0000E0DC
		private void InternalOnServerResponded(gameserveritem_t server)
		{
			this.m_ServerResponded(server);
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0000FCEA File Offset: 0x0000E0EA
		private void InternalOnServerFailedToRespond()
		{
			this.m_ServerFailedToRespond();
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0000FCF7 File Offset: 0x0000E0F7
		public static explicit operator IntPtr(ISteamMatchmakingPingResponse that)
		{
			return that.m_pGCHandle.AddrOfPinnedObject();
		}

		// Token: 0x040001A4 RID: 420
		private ISteamMatchmakingPingResponse.VTable m_VTable;

		// Token: 0x040001A5 RID: 421
		private IntPtr m_pVTable;

		// Token: 0x040001A6 RID: 422
		private GCHandle m_pGCHandle;

		// Token: 0x040001A7 RID: 423
		private ISteamMatchmakingPingResponse.ServerResponded m_ServerResponded;

		// Token: 0x040001A8 RID: 424
		private ISteamMatchmakingPingResponse.ServerFailedToRespond m_ServerFailedToRespond;

		// Token: 0x02000044 RID: 68
		// (Invoke) Token: 0x0600035C RID: 860
		public delegate void ServerResponded(gameserveritem_t server);

		// Token: 0x02000045 RID: 69
		// (Invoke) Token: 0x06000360 RID: 864
		public delegate void ServerFailedToRespond();

		// Token: 0x02000046 RID: 70
		// (Invoke) Token: 0x06000364 RID: 868
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalServerResponded(gameserveritem_t server);

		// Token: 0x02000047 RID: 71
		// (Invoke) Token: 0x06000368 RID: 872
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalServerFailedToRespond();

		// Token: 0x02000048 RID: 72
		[StructLayout(LayoutKind.Sequential)]
		private class VTable
		{
			// Token: 0x0600036B RID: 875 RVA: 0x0000FD04 File Offset: 0x0000E104
			public VTable()
			{
			}

			// Token: 0x040001A9 RID: 425
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingPingResponse.InternalServerResponded m_VTServerResponded;

			// Token: 0x040001AA RID: 426
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingPingResponse.InternalServerFailedToRespond m_VTServerFailedToRespond;
		}
	}
}
