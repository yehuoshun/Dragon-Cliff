using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000087 RID: 135
	[CallbackIdentity(207)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GSGameplayStats_t
	{
		// Token: 0x04000253 RID: 595
		public const int k_iCallback = 207;

		// Token: 0x04000254 RID: 596
		public EResult m_eResult;

		// Token: 0x04000255 RID: 597
		public int m_nRank;

		// Token: 0x04000256 RID: 598
		public uint m_unTotalConnects;

		// Token: 0x04000257 RID: 599
		public uint m_unTotalMinutesPlayed;
	}
}
