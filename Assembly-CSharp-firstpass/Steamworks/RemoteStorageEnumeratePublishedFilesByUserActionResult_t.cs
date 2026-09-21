using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E2 RID: 226
	[CallbackIdentity(1328)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageEnumeratePublishedFilesByUserActionResult_t
	{
		// Token: 0x040003BA RID: 954
		public const int k_iCallback = 1328;

		// Token: 0x040003BB RID: 955
		public EResult m_eResult;

		// Token: 0x040003BC RID: 956
		public EWorkshopFileAction m_eAction;

		// Token: 0x040003BD RID: 957
		public int m_nResultsReturned;

		// Token: 0x040003BE RID: 958
		public int m_nTotalResultCount;

		// Token: 0x040003BF RID: 959
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public PublishedFileId_t[] m_rgPublishedFileId;

		// Token: 0x040003C0 RID: 960
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public uint[] m_rgRTimeUpdated;
	}
}
