using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000A2 RID: 162
	[CallbackIdentity(4524)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_ShowToolTip_t
	{
		// Token: 0x040002D2 RID: 722
		public const int k_iCallback = 4524;

		// Token: 0x040002D3 RID: 723
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040002D4 RID: 724
		public string pchMsg;
	}
}
