using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000ED RID: 237
	[CallbackIdentity(3405)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct ItemInstalled_t
	{
		// Token: 0x040003E4 RID: 996
		public const int k_iCallback = 3405;

		// Token: 0x040003E5 RID: 997
		public AppId_t m_unAppID;

		// Token: 0x040003E6 RID: 998
		public PublishedFileId_t m_nPublishedFileId;
	}
}
