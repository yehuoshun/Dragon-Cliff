using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000171 RID: 369
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct P2PSessionState_t
	{
		// Token: 0x04000923 RID: 2339
		public byte m_bConnectionActive;

		// Token: 0x04000924 RID: 2340
		public byte m_bConnecting;

		// Token: 0x04000925 RID: 2341
		public byte m_eP2PSessionError;

		// Token: 0x04000926 RID: 2342
		public byte m_bUsingRelay;

		// Token: 0x04000927 RID: 2343
		public int m_nBytesQueuedForSend;

		// Token: 0x04000928 RID: 2344
		public int m_nPacketsQueuedForSend;

		// Token: 0x04000929 RID: 2345
		public uint m_nRemoteIP;

		// Token: 0x0400092A RID: 2346
		public ushort m_nRemotePort;
	}
}
