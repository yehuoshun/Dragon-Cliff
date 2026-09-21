using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C6 RID: 198
	[CallbackIdentity(4114)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct MusicPlayerWantsPlayingRepeatStatus_t
	{
		// Token: 0x04000337 RID: 823
		public const int k_iCallback = 4114;

		// Token: 0x04000338 RID: 824
		public int m_nPlayingRepeatStatus;
	}
}
