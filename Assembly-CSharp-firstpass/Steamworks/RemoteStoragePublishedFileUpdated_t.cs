using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E4 RID: 228
	[CallbackIdentity(1330)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStoragePublishedFileUpdated_t
	{
		// Token: 0x040003C4 RID: 964
		public const int k_iCallback = 1330;

		// Token: 0x040003C5 RID: 965
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x040003C6 RID: 966
		public AppId_t m_nAppID;

		// Token: 0x040003C7 RID: 967
		public ulong m_ulUnused;
	}
}
