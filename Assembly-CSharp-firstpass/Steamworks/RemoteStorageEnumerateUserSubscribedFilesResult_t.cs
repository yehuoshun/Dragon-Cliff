using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D4 RID: 212
	[CallbackIdentity(1314)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageEnumerateUserSubscribedFilesResult_t
	{
		// Token: 0x04000368 RID: 872
		public const int k_iCallback = 1314;

		// Token: 0x04000369 RID: 873
		public EResult m_eResult;

		// Token: 0x0400036A RID: 874
		public int m_nResultsReturned;

		// Token: 0x0400036B RID: 875
		public int m_nTotalResultCount;

		// Token: 0x0400036C RID: 876
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public PublishedFileId_t[] m_rgPublishedFileId;

		// Token: 0x0400036D RID: 877
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public uint[] m_rgRTimeSubscribed;
	}
}
