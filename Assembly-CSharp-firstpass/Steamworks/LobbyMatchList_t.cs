using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B3 RID: 179
	[CallbackIdentity(510)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LobbyMatchList_t
	{
		// Token: 0x04000317 RID: 791
		public const int k_iCallback = 510;

		// Token: 0x04000318 RID: 792
		public uint m_nLobbiesMatching;
	}
}
