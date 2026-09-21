using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C1 RID: 193
	[CallbackIdentity(4109)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct MusicPlayerWantsShuffled_t
	{
		// Token: 0x0400032D RID: 813
		public const int k_iCallback = 4109;

		// Token: 0x0400032E RID: 814
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bShuffled;
	}
}
