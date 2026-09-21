using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C9 RID: 201
	[CallbackIdentity(1201)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct SocketStatusCallback_t
	{
		// Token: 0x0400033E RID: 830
		public const int k_iCallback = 1201;

		// Token: 0x0400033F RID: 831
		public SNetSocket_t m_hSocket;

		// Token: 0x04000340 RID: 832
		public SNetListenSocket_t m_hListenSocket;

		// Token: 0x04000341 RID: 833
		public CSteamID m_steamIDRemote;

		// Token: 0x04000342 RID: 834
		public int m_eSNetSocketState;
	}
}
