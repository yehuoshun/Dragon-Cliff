using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E1 RID: 225
	[CallbackIdentity(1327)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageSetUserPublishedFileActionResult_t
	{
		// Token: 0x040003B6 RID: 950
		public const int k_iCallback = 1327;

		// Token: 0x040003B7 RID: 951
		public EResult m_eResult;

		// Token: 0x040003B8 RID: 952
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x040003B9 RID: 953
		public EWorkshopFileAction m_eAction;
	}
}
