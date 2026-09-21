using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000102 RID: 258
	[CallbackIdentity(152)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct MicroTxnAuthorizationResponse_t
	{
		// Token: 0x0400042E RID: 1070
		public const int k_iCallback = 152;

		// Token: 0x0400042F RID: 1071
		public uint m_unAppID;

		// Token: 0x04000430 RID: 1072
		public ulong m_ulOrderID;

		// Token: 0x04000431 RID: 1073
		public byte m_bAuthorized;
	}
}
