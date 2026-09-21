using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000101 RID: 257
	[CallbackIdentity(143)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct ValidateAuthTicketResponse_t
	{
		// Token: 0x0400042A RID: 1066
		public const int k_iCallback = 143;

		// Token: 0x0400042B RID: 1067
		public CSteamID m_SteamID;

		// Token: 0x0400042C RID: 1068
		public EAuthSessionResponse m_eAuthSessionResponse;

		// Token: 0x0400042D RID: 1069
		public CSteamID m_OwnerSteamID;
	}
}
