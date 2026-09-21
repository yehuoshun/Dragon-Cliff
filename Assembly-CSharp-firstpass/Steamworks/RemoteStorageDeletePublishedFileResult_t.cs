using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D1 RID: 209
	[CallbackIdentity(1311)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageDeletePublishedFileResult_t
	{
		// Token: 0x0400035D RID: 861
		public const int k_iCallback = 1311;

		// Token: 0x0400035E RID: 862
		public EResult m_eResult;

		// Token: 0x0400035F RID: 863
		public PublishedFileId_t m_nPublishedFileId;
	}
}
