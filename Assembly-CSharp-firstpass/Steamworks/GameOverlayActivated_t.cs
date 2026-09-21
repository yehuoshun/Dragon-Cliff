using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200006F RID: 111
	[CallbackIdentity(331)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GameOverlayActivated_t
	{
		// Token: 0x04000204 RID: 516
		public const int k_iCallback = 331;

		// Token: 0x04000205 RID: 517
		public byte m_bActive;
	}
}
