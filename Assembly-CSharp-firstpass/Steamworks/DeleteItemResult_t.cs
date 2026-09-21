using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000F9 RID: 249
	[CallbackIdentity(3417)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct DeleteItemResult_t
	{
		// Token: 0x04000413 RID: 1043
		public const int k_iCallback = 3417;

		// Token: 0x04000414 RID: 1044
		public EResult m_eResult;

		// Token: 0x04000415 RID: 1045
		public PublishedFileId_t m_nPublishedFileId;
	}
}
