using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000F6 RID: 246
	[CallbackIdentity(3414)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct AddAppDependencyResult_t
	{
		// Token: 0x04000405 RID: 1029
		public const int k_iCallback = 3414;

		// Token: 0x04000406 RID: 1030
		public EResult m_eResult;

		// Token: 0x04000407 RID: 1031
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x04000408 RID: 1032
		public AppId_t m_nAppID;
	}
}
