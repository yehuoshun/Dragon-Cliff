using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D7 RID: 215
	[CallbackIdentity(1317)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageDownloadUGCResult_t
	{
		// Token: 0x04000375 RID: 885
		public const int k_iCallback = 1317;

		// Token: 0x04000376 RID: 886
		public EResult m_eResult;

		// Token: 0x04000377 RID: 887
		public UGCHandle_t m_hFile;

		// Token: 0x04000378 RID: 888
		public AppId_t m_nAppID;

		// Token: 0x04000379 RID: 889
		public int m_nSizeInBytes;

		// Token: 0x0400037A RID: 890
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string m_pchFileName;

		// Token: 0x0400037B RID: 891
		public ulong m_ulSteamIDOwner;
	}
}
