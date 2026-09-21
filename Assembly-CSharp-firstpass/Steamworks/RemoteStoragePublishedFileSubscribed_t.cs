using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000DB RID: 219
	[CallbackIdentity(1321)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStoragePublishedFileSubscribed_t
	{
		// Token: 0x040003A1 RID: 929
		public const int k_iCallback = 1321;

		// Token: 0x040003A2 RID: 930
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x040003A3 RID: 931
		public AppId_t m_nAppID;
	}
}
