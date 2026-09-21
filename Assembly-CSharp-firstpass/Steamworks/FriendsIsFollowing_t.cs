using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200007D RID: 125
	[CallbackIdentity(345)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct FriendsIsFollowing_t
	{
		// Token: 0x04000233 RID: 563
		public const int k_iCallback = 345;

		// Token: 0x04000234 RID: 564
		public EResult m_eResult;

		// Token: 0x04000235 RID: 565
		public CSteamID m_steamID;

		// Token: 0x04000236 RID: 566
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bIsFollowing;
	}
}
