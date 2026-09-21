using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000086 RID: 134
	[CallbackIdentity(115)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GSPolicyResponse_t
	{
		// Token: 0x04000251 RID: 593
		public const int k_iCallback = 115;

		// Token: 0x04000252 RID: 594
		public byte m_bSecure;
	}
}
