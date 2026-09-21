using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000A6 RID: 166
	[CallbackIdentity(2102)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTTPRequestHeadersReceived_t
	{
		// Token: 0x040002E0 RID: 736
		public const int k_iCallback = 2102;

		// Token: 0x040002E1 RID: 737
		public HTTPRequestHandle m_hRequest;

		// Token: 0x040002E2 RID: 738
		public ulong m_ulContextValue;
	}
}
