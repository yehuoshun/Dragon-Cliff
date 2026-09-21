using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200006C RID: 108
	[CallbackIdentity(1021)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct AppProofOfPurchaseKeyResponse_t
	{
		// Token: 0x040001F7 RID: 503
		public const int k_iCallback = 1021;

		// Token: 0x040001F8 RID: 504
		public EResult m_eResult;

		// Token: 0x040001F9 RID: 505
		public uint m_nAppID;

		// Token: 0x040001FA RID: 506
		public uint m_cchKeyLength;

		// Token: 0x040001FB RID: 507
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 240)]
		public string m_rgchKey;
	}
}
