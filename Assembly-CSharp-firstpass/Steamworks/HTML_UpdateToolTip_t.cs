using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000A3 RID: 163
	[CallbackIdentity(4525)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_UpdateToolTip_t
	{
		// Token: 0x040002D5 RID: 725
		public const int k_iCallback = 4525;

		// Token: 0x040002D6 RID: 726
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040002D7 RID: 727
		public string pchMsg;
	}
}
