using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000084 RID: 132
	[CallbackIdentity(203)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct GSClientKick_t
	{
		// Token: 0x0400024A RID: 586
		public const int k_iCallback = 203;

		// Token: 0x0400024B RID: 587
		public CSteamID m_SteamID;

		// Token: 0x0400024C RID: 588
		public EDenyReason m_eDenyReason;
	}
}
