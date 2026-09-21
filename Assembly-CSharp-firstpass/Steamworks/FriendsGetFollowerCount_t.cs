using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200007C RID: 124
	[CallbackIdentity(344)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct FriendsGetFollowerCount_t
	{
		// Token: 0x0400022F RID: 559
		public const int k_iCallback = 344;

		// Token: 0x04000230 RID: 560
		public EResult m_eResult;

		// Token: 0x04000231 RID: 561
		public CSteamID m_steamID;

		// Token: 0x04000232 RID: 562
		public int m_nCount;
	}
}
