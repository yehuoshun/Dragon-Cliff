using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000DC RID: 220
	[CallbackIdentity(1322)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStoragePublishedFileUnsubscribed_t
	{
		// Token: 0x040003A4 RID: 932
		public const int k_iCallback = 1322;

		// Token: 0x040003A5 RID: 933
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x040003A6 RID: 934
		public AppId_t m_nAppID;
	}
}
