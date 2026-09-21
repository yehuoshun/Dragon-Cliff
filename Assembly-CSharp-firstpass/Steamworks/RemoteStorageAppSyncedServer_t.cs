using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000CC RID: 204
	[CallbackIdentity(1302)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageAppSyncedServer_t
	{
		// Token: 0x04000348 RID: 840
		public const int k_iCallback = 1302;

		// Token: 0x04000349 RID: 841
		public AppId_t m_nAppID;

		// Token: 0x0400034A RID: 842
		public EResult m_eResult;

		// Token: 0x0400034B RID: 843
		public int m_unNumUploads;
	}
}
