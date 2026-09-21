using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200011C RID: 284
	[CallbackIdentity(4624)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GetOPFSettingsResult_t
	{
		// Token: 0x0400047D RID: 1149
		public const int k_iCallback = 4624;

		// Token: 0x0400047E RID: 1150
		public EResult m_eResult;

		// Token: 0x0400047F RID: 1151
		public AppId_t m_unVideoAppID;
	}
}
