using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000049 RID: 73
	public class ISteamMatchmakingPlayersResponse
	{
		// Token: 0x0600036C RID: 876 RVA: 0x0000FD0C File Offset: 0x0000E10C
		public ISteamMatchmakingPlayersResponse(ISteamMatchmakingPlayersResponse.AddPlayerToList onAddPlayerToList, ISteamMatchmakingPlayersResponse.PlayersFailedToRespond onPlayersFailedToRespond, ISteamMatchmakingPlayersResponse.PlayersRefreshComplete onPlayersRefreshComplete)
		{
			if (onAddPlayerToList == null || onPlayersFailedToRespond == null || onPlayersRefreshComplete == null)
			{
				throw new ArgumentNullException();
			}
			this.m_AddPlayerToList = onAddPlayerToList;
			this.m_PlayersFailedToRespond = onPlayersFailedToRespond;
			this.m_PlayersRefreshComplete = onPlayersRefreshComplete;
			this.m_VTable = new ISteamMatchmakingPlayersResponse.VTable
			{
				m_VTAddPlayerToList = new ISteamMatchmakingPlayersResponse.InternalAddPlayerToList(this.InternalOnAddPlayerToList),
				m_VTPlayersFailedToRespond = new ISteamMatchmakingPlayersResponse.InternalPlayersFailedToRespond(this.InternalOnPlayersFailedToRespond),
				m_VTPlayersRefreshComplete = new ISteamMatchmakingPlayersResponse.InternalPlayersRefreshComplete(this.InternalOnPlayersRefreshComplete)
			};
			this.m_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ISteamMatchmakingPlayersResponse.VTable)));
			Marshal.StructureToPtr(this.m_VTable, this.m_pVTable, false);
			this.m_pGCHandle = GCHandle.Alloc(this.m_pVTable, GCHandleType.Pinned);
		}

		// Token: 0x0600036D RID: 877 RVA: 0x0000FDD4 File Offset: 0x0000E1D4
		~ISteamMatchmakingPlayersResponse()
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

		// Token: 0x0600036E RID: 878 RVA: 0x0000FE38 File Offset: 0x0000E238
		private void InternalOnAddPlayerToList(IntPtr pchName, int nScore, float flTimePlayed)
		{
			this.m_AddPlayerToList(InteropHelp.PtrToStringUTF8(pchName), nScore, flTimePlayed);
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0000FE4D File Offset: 0x0000E24D
		private void InternalOnPlayersFailedToRespond()
		{
			this.m_PlayersFailedToRespond();
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0000FE5A File Offset: 0x0000E25A
		private void InternalOnPlayersRefreshComplete()
		{
			this.m_PlayersRefreshComplete();
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0000FE67 File Offset: 0x0000E267
		public static explicit operator IntPtr(ISteamMatchmakingPlayersResponse that)
		{
			return that.m_pGCHandle.AddrOfPinnedObject();
		}

		// Token: 0x040001AB RID: 427
		private ISteamMatchmakingPlayersResponse.VTable m_VTable;

		// Token: 0x040001AC RID: 428
		private IntPtr m_pVTable;

		// Token: 0x040001AD RID: 429
		private GCHandle m_pGCHandle;

		// Token: 0x040001AE RID: 430
		private ISteamMatchmakingPlayersResponse.AddPlayerToList m_AddPlayerToList;

		// Token: 0x040001AF RID: 431
		private ISteamMatchmakingPlayersResponse.PlayersFailedToRespond m_PlayersFailedToRespond;

		// Token: 0x040001B0 RID: 432
		private ISteamMatchmakingPlayersResponse.PlayersRefreshComplete m_PlayersRefreshComplete;

		// Token: 0x0200004A RID: 74
		// (Invoke) Token: 0x06000373 RID: 883
		public delegate void AddPlayerToList(string pchName, int nScore, float flTimePlayed);

		// Token: 0x0200004B RID: 75
		// (Invoke) Token: 0x06000377 RID: 887
		public delegate void PlayersFailedToRespond();

		// Token: 0x0200004C RID: 76
		// (Invoke) Token: 0x0600037B RID: 891
		public delegate void PlayersRefreshComplete();

		// Token: 0x0200004D RID: 77
		// (Invoke) Token: 0x0600037F RID: 895
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalAddPlayerToList(IntPtr pchName, int nScore, float flTimePlayed);

		// Token: 0x0200004E RID: 78
		// (Invoke) Token: 0x06000383 RID: 899
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalPlayersFailedToRespond();

		// Token: 0x0200004F RID: 79
		// (Invoke) Token: 0x06000387 RID: 903
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalPlayersRefreshComplete();

		// Token: 0x02000050 RID: 80
		[StructLayout(LayoutKind.Sequential)]
		private class VTable
		{
			// Token: 0x0600038A RID: 906 RVA: 0x0000FE74 File Offset: 0x0000E274
			public VTable()
			{
			}

			// Token: 0x040001B1 RID: 433
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingPlayersResponse.InternalAddPlayerToList m_VTAddPlayerToList;

			// Token: 0x040001B2 RID: 434
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingPlayersResponse.InternalPlayersFailedToRespond m_VTPlayersFailedToRespond;

			// Token: 0x040001B3 RID: 435
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingPlayersResponse.InternalPlayersRefreshComplete m_VTPlayersRefreshComplete;
		}
	}
}
