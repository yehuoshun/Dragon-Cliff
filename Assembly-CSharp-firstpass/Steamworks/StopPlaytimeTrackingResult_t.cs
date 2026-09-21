using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000F3 RID: 243
	[CallbackIdentity(3411)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct StopPlaytimeTrackingResult_t
	{
		// Token: 0x040003FB RID: 1019
		public const int k_iCallback = 3411;

		// Token: 0x040003FC RID: 1020
		public EResult m_eResult;
	}
}
