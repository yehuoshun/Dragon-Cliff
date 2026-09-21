using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000073 RID: 115
	[CallbackIdentity(335)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct ClanOfficerListResponse_t
	{
		// Token: 0x04000211 RID: 529
		public const int k_iCallback = 335;

		// Token: 0x04000212 RID: 530
		public CSteamID m_steamIDClan;

		// Token: 0x04000213 RID: 531
		public int m_cOfficers;

		// Token: 0x04000214 RID: 532
		public byte m_bSuccess;
	}
}
