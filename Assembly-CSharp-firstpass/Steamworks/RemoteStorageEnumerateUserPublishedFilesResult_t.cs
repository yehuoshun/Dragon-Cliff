using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D2 RID: 210
	[CallbackIdentity(1312)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageEnumerateUserPublishedFilesResult_t
	{
		// Token: 0x04000360 RID: 864
		public const int k_iCallback = 1312;

		// Token: 0x04000361 RID: 865
		public EResult m_eResult;

		// Token: 0x04000362 RID: 866
		public int m_nResultsReturned;

		// Token: 0x04000363 RID: 867
		public int m_nTotalResultCount;

		// Token: 0x04000364 RID: 868
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public PublishedFileId_t[] m_rgPublishedFileId;
	}
}
