using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000CB RID: 203
	[CallbackIdentity(1301)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageAppSyncedClient_t
	{
		// Token: 0x04000344 RID: 836
		public const int k_iCallback = 1301;

		// Token: 0x04000345 RID: 837
		public AppId_t m_nAppID;

		// Token: 0x04000346 RID: 838
		public EResult m_eResult;

		// Token: 0x04000347 RID: 839
		public int m_unNumDownloads;
	}
}
