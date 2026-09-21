using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000A7 RID: 167
	[CallbackIdentity(2103)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTTPRequestDataReceived_t
	{
		// Token: 0x040002E3 RID: 739
		public const int k_iCallback = 2103;

		// Token: 0x040002E4 RID: 740
		public HTTPRequestHandle m_hRequest;

		// Token: 0x040002E5 RID: 741
		public ulong m_ulContextValue;

		// Token: 0x040002E6 RID: 742
		public uint m_cOffset;

		// Token: 0x040002E7 RID: 743
		public uint m_cBytesReceived;
	}
}
