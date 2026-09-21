using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000FF RID: 255
	[CallbackIdentity(117)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct IPCFailure_t
	{
		// Token: 0x04000427 RID: 1063
		public const int k_iCallback = 117;

		// Token: 0x04000428 RID: 1064
		public byte m_eFailureType;
	}
}
