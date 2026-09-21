using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200006A RID: 106
	[CallbackIdentity(1008)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RegisterActivationCodeResponse_t
	{
		// Token: 0x040001F3 RID: 499
		public const int k_iCallback = 1008;

		// Token: 0x040001F4 RID: 500
		public ERegisterActivationCodeResult m_eResult;

		// Token: 0x040001F5 RID: 501
		public uint m_unPackageRegistered;
	}
}
