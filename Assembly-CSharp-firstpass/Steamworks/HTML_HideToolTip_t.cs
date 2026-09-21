using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000A4 RID: 164
	[CallbackIdentity(4526)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_HideToolTip_t
	{
		// Token: 0x040002D8 RID: 728
		public const int k_iCallback = 4526;

		// Token: 0x040002D9 RID: 729
		public HHTMLBrowser unBrowserHandle;
	}
}
