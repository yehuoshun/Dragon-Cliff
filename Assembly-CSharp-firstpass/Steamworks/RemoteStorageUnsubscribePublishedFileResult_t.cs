using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D5 RID: 213
	[CallbackIdentity(1315)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageUnsubscribePublishedFileResult_t
	{
		// Token: 0x0400036E RID: 878
		public const int k_iCallback = 1315;

		// Token: 0x0400036F RID: 879
		public EResult m_eResult;

		// Token: 0x04000370 RID: 880
		public PublishedFileId_t m_nPublishedFileId;
	}
}
