using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C4 RID: 196
	[CallbackIdentity(4012)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct MusicPlayerSelectsQueueEntry_t
	{
		// Token: 0x04000333 RID: 819
		public const int k_iCallback = 4012;

		// Token: 0x04000334 RID: 820
		public int nID;
	}
}
