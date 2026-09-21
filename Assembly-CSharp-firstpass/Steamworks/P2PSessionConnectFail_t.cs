using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C8 RID: 200
	[CallbackIdentity(1203)]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct P2PSessionConnectFail_t
	{
		// Token: 0x0400033B RID: 827
		public const int k_iCallback = 1203;

		// Token: 0x0400033C RID: 828
		public CSteamID m_steamIDRemote;

		// Token: 0x0400033D RID: 829
		public byte m_eP2PSessionError;
	}
}
