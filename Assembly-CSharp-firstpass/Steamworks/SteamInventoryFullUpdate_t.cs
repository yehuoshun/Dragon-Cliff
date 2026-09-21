using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000A9 RID: 169
	[CallbackIdentity(4701)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamInventoryFullUpdate_t
	{
		// Token: 0x040002EB RID: 747
		public const int k_iCallback = 4701;

		// Token: 0x040002EC RID: 748
		public SteamInventoryResult_t m_handle;
	}
}
