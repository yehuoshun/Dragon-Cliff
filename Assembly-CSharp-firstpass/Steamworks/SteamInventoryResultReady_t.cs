using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000A8 RID: 168
	[CallbackIdentity(4700)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamInventoryResultReady_t
	{
		// Token: 0x040002E8 RID: 744
		public const int k_iCallback = 4700;

		// Token: 0x040002E9 RID: 745
		public SteamInventoryResult_t m_handle;

		// Token: 0x040002EA RID: 746
		public EResult m_result;
	}
}
