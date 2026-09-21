using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B1 RID: 177
	[CallbackIdentity(507)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LobbyChatMsg_t
	{
		// Token: 0x0400030D RID: 781
		public const int k_iCallback = 507;

		// Token: 0x0400030E RID: 782
		public ulong m_ulSteamIDLobby;

		// Token: 0x0400030F RID: 783
		public ulong m_ulSteamIDUser;

		// Token: 0x04000310 RID: 784
		public byte m_eChatEntryType;

		// Token: 0x04000311 RID: 785
		public uint m_iChatID;
	}
}
