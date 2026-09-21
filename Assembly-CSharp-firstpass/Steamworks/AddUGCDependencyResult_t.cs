using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000F4 RID: 244
	[CallbackIdentity(3412)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct AddUGCDependencyResult_t
	{
		// Token: 0x040003FD RID: 1021
		public const int k_iCallback = 3412;

		// Token: 0x040003FE RID: 1022
		public EResult m_eResult;

		// Token: 0x040003FF RID: 1023
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x04000400 RID: 1024
		public PublishedFileId_t m_nChildPublishedFileId;
	}
}
