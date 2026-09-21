using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C7 RID: 199
	[CallbackIdentity(1202)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct P2PSessionRequest_t
	{
		// Token: 0x04000339 RID: 825
		public const int k_iCallback = 1202;

		// Token: 0x0400033A RID: 826
		public CSteamID m_steamIDRemote;
	}
}
