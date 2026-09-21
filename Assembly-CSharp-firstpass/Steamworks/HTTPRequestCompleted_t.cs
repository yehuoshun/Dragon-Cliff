using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000A5 RID: 165
	[CallbackIdentity(2101)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTTPRequestCompleted_t
	{
		// Token: 0x040002DA RID: 730
		public const int k_iCallback = 2101;

		// Token: 0x040002DB RID: 731
		public HTTPRequestHandle m_hRequest;

		// Token: 0x040002DC RID: 732
		public ulong m_ulContextValue;

		// Token: 0x040002DD RID: 733
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bRequestSuccessful;

		// Token: 0x040002DE RID: 734
		public EHTTPStatusCode m_eStatusCode;

		// Token: 0x040002DF RID: 735
		public uint m_unBodySize;
	}
}
