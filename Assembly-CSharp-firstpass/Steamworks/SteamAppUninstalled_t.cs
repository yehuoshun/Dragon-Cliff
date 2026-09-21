using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000068 RID: 104
	[CallbackIdentity(3902)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamAppUninstalled_t
	{
		// Token: 0x040001EF RID: 495
		public const int k_iCallback = 3902;

		// Token: 0x040001F0 RID: 496
		public AppId_t m_nAppID;
	}
}
