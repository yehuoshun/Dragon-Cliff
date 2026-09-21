using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000174 RID: 372
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct CallbackMsg_t
	{
		// Token: 0x04000947 RID: 2375
		public int m_hSteamUser;

		// Token: 0x04000948 RID: 2376
		public int m_iCallback;

		// Token: 0x04000949 RID: 2377
		public IntPtr m_pubParam;

		// Token: 0x0400094A RID: 2378
		public int m_cubParam;
	}
}
