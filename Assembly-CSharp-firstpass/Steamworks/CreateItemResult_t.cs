using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000EB RID: 235
	[CallbackIdentity(3403)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct CreateItemResult_t
	{
		// Token: 0x040003DC RID: 988
		public const int k_iCallback = 3403;

		// Token: 0x040003DD RID: 989
		public EResult m_eResult;

		// Token: 0x040003DE RID: 990
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x040003DF RID: 991
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;
	}
}
