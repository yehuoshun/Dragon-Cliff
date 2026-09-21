using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E0 RID: 224
	[CallbackIdentity(1326)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageEnumerateUserSharedWorkshopFilesResult_t
	{
		// Token: 0x040003B1 RID: 945
		public const int k_iCallback = 1326;

		// Token: 0x040003B2 RID: 946
		public EResult m_eResult;

		// Token: 0x040003B3 RID: 947
		public int m_nResultsReturned;

		// Token: 0x040003B4 RID: 948
		public int m_nTotalResultCount;

		// Token: 0x040003B5 RID: 949
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public PublishedFileId_t[] m_rgPublishedFileId;
	}
}
