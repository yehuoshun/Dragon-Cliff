using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000F8 RID: 248
	[CallbackIdentity(3416)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GetAppDependenciesResult_t
	{
		// Token: 0x0400040D RID: 1037
		public const int k_iCallback = 3416;

		// Token: 0x0400040E RID: 1038
		public EResult m_eResult;

		// Token: 0x0400040F RID: 1039
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x04000410 RID: 1040
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public AppId_t[] m_rgAppIDs;

		// Token: 0x04000411 RID: 1041
		public uint m_nNumAppDependencies;

		// Token: 0x04000412 RID: 1042
		public uint m_nTotalNumAppDependencies;
	}
}
