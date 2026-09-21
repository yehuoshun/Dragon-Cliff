using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000AF RID: 175
	[CallbackIdentity(505)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LobbyDataUpdate_t
	{
		// Token: 0x04000304 RID: 772
		public const int k_iCallback = 505;

		// Token: 0x04000305 RID: 773
		public ulong m_ulSteamIDLobby;

		// Token: 0x04000306 RID: 774
		public ulong m_ulSteamIDMember;

		// Token: 0x04000307 RID: 775
		public byte m_bSuccess;
	}
}
