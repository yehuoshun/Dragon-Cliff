using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000092 RID: 146
	[CallbackIdentity(4504)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_CloseBrowser_t
	{
		// Token: 0x0400028A RID: 650
		public const int k_iCallback = 4504;

		// Token: 0x0400028B RID: 651
		public HHTMLBrowser unBrowserHandle;
	}
}
