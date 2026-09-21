using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000EC RID: 236
	[CallbackIdentity(3404)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SubmitItemUpdateResult_t
	{
		// Token: 0x040003E0 RID: 992
		public const int k_iCallback = 3404;

		// Token: 0x040003E1 RID: 993
		public EResult m_eResult;

		// Token: 0x040003E2 RID: 994
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;

		// Token: 0x040003E3 RID: 995
		public PublishedFileId_t m_nPublishedFileId;
	}
}
