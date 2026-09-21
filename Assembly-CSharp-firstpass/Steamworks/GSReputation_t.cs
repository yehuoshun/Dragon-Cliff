using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000089 RID: 137
	[CallbackIdentity(209)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GSReputation_t
	{
		// Token: 0x0400025D RID: 605
		public const int k_iCallback = 209;

		// Token: 0x0400025E RID: 606
		public EResult m_eResult;

		// Token: 0x0400025F RID: 607
		public uint m_unReputationScore;

		// Token: 0x04000260 RID: 608
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bBanned;

		// Token: 0x04000261 RID: 609
		public uint m_unBannedIP;

		// Token: 0x04000262 RID: 610
		public ushort m_usBannedPort;

		// Token: 0x04000263 RID: 611
		public ulong m_ulBannedGameID;

		// Token: 0x04000264 RID: 612
		public uint m_unBanExpires;
	}
}
