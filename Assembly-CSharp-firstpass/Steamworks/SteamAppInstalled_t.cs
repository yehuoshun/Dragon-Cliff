using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000067 RID: 103
	[CallbackIdentity(3901)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamAppInstalled_t
	{
		// Token: 0x040001ED RID: 493
		public const int k_iCallback = 3901;

		// Token: 0x040001EE RID: 494
		public AppId_t m_nAppID;
	}
}
