using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000F5 RID: 245
	[CallbackIdentity(3413)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoveUGCDependencyResult_t
	{
		// Token: 0x04000401 RID: 1025
		public const int k_iCallback = 3413;

		// Token: 0x04000402 RID: 1026
		public EResult m_eResult;

		// Token: 0x04000403 RID: 1027
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x04000404 RID: 1028
		public PublishedFileId_t m_nChildPublishedFileId;
	}
}
