using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000CE RID: 206
	[CallbackIdentity(1305)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageAppSyncStatusCheck_t
	{
		// Token: 0x04000352 RID: 850
		public const int k_iCallback = 1305;

		// Token: 0x04000353 RID: 851
		public AppId_t m_nAppID;

		// Token: 0x04000354 RID: 852
		public EResult m_eResult;
	}
}
