using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000115 RID: 277
	[CallbackIdentity(703)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamAPICallCompleted_t
	{
		// Token: 0x0400046C RID: 1132
		public const int k_iCallback = 703;

		// Token: 0x0400046D RID: 1133
		public SteamAPICall_t m_hAsyncCall;

		// Token: 0x0400046E RID: 1134
		public int m_iCallback;

		// Token: 0x0400046F RID: 1135
		public uint m_cubParam;
	}
}
