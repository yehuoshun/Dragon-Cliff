using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C3 RID: 195
	[CallbackIdentity(4011)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct MusicPlayerWantsVolume_t
	{
		// Token: 0x04000331 RID: 817
		public const int k_iCallback = 4011;

		// Token: 0x04000332 RID: 818
		public float m_flNewVolume;
	}
}
