using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C5 RID: 197
	[CallbackIdentity(4013)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct MusicPlayerSelectsPlaylistEntry_t
	{
		// Token: 0x04000335 RID: 821
		public const int k_iCallback = 4013;

		// Token: 0x04000336 RID: 822
		public int nID;
	}
}
