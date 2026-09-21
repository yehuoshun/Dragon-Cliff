using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D6 RID: 214
	[CallbackIdentity(1316)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageUpdatePublishedFileResult_t
	{
		// Token: 0x04000371 RID: 881
		public const int k_iCallback = 1316;

		// Token: 0x04000372 RID: 882
		public EResult m_eResult;

		// Token: 0x04000373 RID: 883
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x04000374 RID: 884
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;
	}
}
