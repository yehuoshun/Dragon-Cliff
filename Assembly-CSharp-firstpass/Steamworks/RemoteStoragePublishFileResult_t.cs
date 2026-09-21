using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D0 RID: 208
	[CallbackIdentity(1309)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStoragePublishFileResult_t
	{
		// Token: 0x04000359 RID: 857
		public const int k_iCallback = 1309;

		// Token: 0x0400035A RID: 858
		public EResult m_eResult;

		// Token: 0x0400035B RID: 859
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x0400035C RID: 860
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;
	}
}
