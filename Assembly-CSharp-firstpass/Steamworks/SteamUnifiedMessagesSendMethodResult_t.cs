using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000FA RID: 250
	[CallbackIdentity(2501)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamUnifiedMessagesSendMethodResult_t
	{
		// Token: 0x04000416 RID: 1046
		public const int k_iCallback = 2501;

		// Token: 0x04000417 RID: 1047
		public ClientUnifiedMessageHandle m_hHandle;

		// Token: 0x04000418 RID: 1048
		public ulong m_unContext;

		// Token: 0x04000419 RID: 1049
		public EResult m_eResult;

		// Token: 0x0400041A RID: 1050
		public uint m_unResponseSize;
	}
}
