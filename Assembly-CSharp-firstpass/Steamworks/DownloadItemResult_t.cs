using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000EE RID: 238
	[CallbackIdentity(3406)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct DownloadItemResult_t
	{
		// Token: 0x040003E7 RID: 999
		public const int k_iCallback = 3406;

		// Token: 0x040003E8 RID: 1000
		public AppId_t m_unAppID;

		// Token: 0x040003E9 RID: 1001
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x040003EA RID: 1002
		public EResult m_eResult;
	}
}
