using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000080 RID: 128
	[CallbackIdentity(1701)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GCMessageAvailable_t
	{
		// Token: 0x04000240 RID: 576
		public const int k_iCallback = 1701;

		// Token: 0x04000241 RID: 577
		public uint m_nMessageSize;
	}
}
