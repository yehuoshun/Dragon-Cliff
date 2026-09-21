using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E7 RID: 231
	[CallbackIdentity(2301)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct ScreenshotReady_t
	{
		// Token: 0x040003CF RID: 975
		public const int k_iCallback = 2301;

		// Token: 0x040003D0 RID: 976
		public ScreenshotHandle m_hLocal;

		// Token: 0x040003D1 RID: 977
		public EResult m_eResult;
	}
}
