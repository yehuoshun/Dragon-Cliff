using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C2 RID: 194
	[CallbackIdentity(4110)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct MusicPlayerWantsLooped_t
	{
		// Token: 0x0400032F RID: 815
		public const int k_iCallback = 4110;

		// Token: 0x04000330 RID: 816
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bLooped;
	}
}
