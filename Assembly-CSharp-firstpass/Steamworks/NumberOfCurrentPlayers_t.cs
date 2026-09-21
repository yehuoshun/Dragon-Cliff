using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200010D RID: 269
	[CallbackIdentity(1107)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct NumberOfCurrentPlayers_t
	{
		// Token: 0x04000456 RID: 1110
		public const int k_iCallback = 1107;

		// Token: 0x04000457 RID: 1111
		public byte m_bSuccess;

		// Token: 0x04000458 RID: 1112
		public int m_cPlayers;
	}
}
