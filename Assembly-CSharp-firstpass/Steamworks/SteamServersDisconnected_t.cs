using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000FD RID: 253
	[CallbackIdentity(103)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamServersDisconnected_t
	{
		// Token: 0x0400041F RID: 1055
		public const int k_iCallback = 103;

		// Token: 0x04000420 RID: 1056
		public EResult m_eResult;
	}
}
