using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000072 RID: 114
	[CallbackIdentity(334)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct AvatarImageLoaded_t
	{
		// Token: 0x0400020C RID: 524
		public const int k_iCallback = 334;

		// Token: 0x0400020D RID: 525
		public CSteamID m_steamID;

		// Token: 0x0400020E RID: 526
		public int m_iImage;

		// Token: 0x0400020F RID: 527
		public int m_iWide;

		// Token: 0x04000210 RID: 528
		public int m_iTall;
	}
}
