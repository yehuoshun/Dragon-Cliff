using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000083 RID: 131
	[CallbackIdentity(202)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct GSClientDeny_t
	{
		// Token: 0x04000246 RID: 582
		public const int k_iCallback = 202;

		// Token: 0x04000247 RID: 583
		public CSteamID m_SteamID;

		// Token: 0x04000248 RID: 584
		public EDenyReason m_eDenyReason;

		// Token: 0x04000249 RID: 585
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string m_rgchOptionalText;
	}
}
