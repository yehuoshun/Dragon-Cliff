using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000103 RID: 259
	[CallbackIdentity(154)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct EncryptedAppTicketResponse_t
	{
		// Token: 0x04000432 RID: 1074
		public const int k_iCallback = 154;

		// Token: 0x04000433 RID: 1075
		public EResult m_eResult;
	}
}
