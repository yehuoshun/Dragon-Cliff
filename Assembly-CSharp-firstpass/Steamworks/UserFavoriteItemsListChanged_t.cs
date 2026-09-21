using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000EF RID: 239
	[CallbackIdentity(3407)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct UserFavoriteItemsListChanged_t
	{
		// Token: 0x040003EB RID: 1003
		public const int k_iCallback = 3407;

		// Token: 0x040003EC RID: 1004
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x040003ED RID: 1005
		public EResult m_eResult;

		// Token: 0x040003EE RID: 1006
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bWasAddRequest;
	}
}
