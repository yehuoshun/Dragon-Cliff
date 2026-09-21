using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000F7 RID: 247
	[CallbackIdentity(3415)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoveAppDependencyResult_t
	{
		// Token: 0x04000409 RID: 1033
		public const int k_iCallback = 3415;

		// Token: 0x0400040A RID: 1034
		public EResult m_eResult;

		// Token: 0x0400040B RID: 1035
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x0400040C RID: 1036
		public AppId_t m_nAppID;
	}
}
