using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000CD RID: 205
	[CallbackIdentity(1303)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageAppSyncProgress_t
	{
		// Token: 0x0400034C RID: 844
		public const int k_iCallback = 1303;

		// Token: 0x0400034D RID: 845
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string m_rgchCurrentFile;

		// Token: 0x0400034E RID: 846
		public AppId_t m_nAppID;

		// Token: 0x0400034F RID: 847
		public uint m_uBytesTransferredThisChunk;

		// Token: 0x04000350 RID: 848
		public double m_dAppPercentComplete;

		// Token: 0x04000351 RID: 849
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUploading;
	}
}
