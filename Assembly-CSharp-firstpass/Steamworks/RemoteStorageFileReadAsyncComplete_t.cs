using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E6 RID: 230
	[CallbackIdentity(1332)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageFileReadAsyncComplete_t
	{
		// Token: 0x040003CA RID: 970
		public const int k_iCallback = 1332;

		// Token: 0x040003CB RID: 971
		public SteamAPICall_t m_hFileReadAsync;

		// Token: 0x040003CC RID: 972
		public EResult m_eResult;

		// Token: 0x040003CD RID: 973
		public uint m_nOffset;

		// Token: 0x040003CE RID: 974
		public uint m_cubRead;
	}
}
