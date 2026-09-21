using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000069 RID: 105
	[CallbackIdentity(1005)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct DlcInstalled_t
	{
		// Token: 0x040001F1 RID: 497
		public const int k_iCallback = 1005;

		// Token: 0x040001F2 RID: 498
		public AppId_t m_nAppID;
	}
}
