using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000104 RID: 260
	[CallbackIdentity(163)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GetAuthSessionTicketResponse_t
	{
		// Token: 0x04000434 RID: 1076
		public const int k_iCallback = 163;

		// Token: 0x04000435 RID: 1077
		public HAuthTicket m_hAuthTicket;

		// Token: 0x04000436 RID: 1078
		public EResult m_eResult;
	}
}
