using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000DD RID: 221
	[CallbackIdentity(1323)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStoragePublishedFileDeleted_t
	{
		// Token: 0x040003A7 RID: 935
		public const int k_iCallback = 1323;

		// Token: 0x040003A8 RID: 936
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x040003A9 RID: 937
		public AppId_t m_nAppID;
	}
}
