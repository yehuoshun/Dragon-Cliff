using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000F2 RID: 242
	[CallbackIdentity(3410)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct StartPlaytimeTrackingResult_t
	{
		// Token: 0x040003F9 RID: 1017
		public const int k_iCallback = 3410;

		// Token: 0x040003FA RID: 1018
		public EResult m_eResult;
	}
}
