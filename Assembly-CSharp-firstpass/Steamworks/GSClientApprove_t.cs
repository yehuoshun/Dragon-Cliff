using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000082 RID: 130
	[CallbackIdentity(201)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GSClientApprove_t
	{
		// Token: 0x04000243 RID: 579
		public const int k_iCallback = 201;

		// Token: 0x04000244 RID: 580
		public CSteamID m_SteamID;

		// Token: 0x04000245 RID: 581
		public CSteamID m_OwnerSteamID;
	}
}
