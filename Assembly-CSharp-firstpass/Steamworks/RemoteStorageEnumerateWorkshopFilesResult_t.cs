using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D9 RID: 217
	[CallbackIdentity(1319)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageEnumerateWorkshopFilesResult_t
	{
		// Token: 0x04000392 RID: 914
		public const int k_iCallback = 1319;

		// Token: 0x04000393 RID: 915
		public EResult m_eResult;

		// Token: 0x04000394 RID: 916
		public int m_nResultsReturned;

		// Token: 0x04000395 RID: 917
		public int m_nTotalResultCount;

		// Token: 0x04000396 RID: 918
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public PublishedFileId_t[] m_rgPublishedFileId;

		// Token: 0x04000397 RID: 919
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public float[] m_rgScore;

		// Token: 0x04000398 RID: 920
		public AppId_t m_nAppId;

		// Token: 0x04000399 RID: 921
		public uint m_unStartIndex;
	}
}
