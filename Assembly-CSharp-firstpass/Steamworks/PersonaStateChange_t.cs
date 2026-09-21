using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200006E RID: 110
	[CallbackIdentity(304)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct PersonaStateChange_t
	{
		// Token: 0x04000201 RID: 513
		public const int k_iCallback = 304;

		// Token: 0x04000202 RID: 514
		public ulong m_ulSteamID;

		// Token: 0x04000203 RID: 515
		public EPersonaChange m_nChangeFlags;
	}
}
