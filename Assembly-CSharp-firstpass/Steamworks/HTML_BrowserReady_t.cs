using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200008F RID: 143
	[CallbackIdentity(4501)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_BrowserReady_t
	{
		// Token: 0x04000275 RID: 629
		public const int k_iCallback = 4501;

		// Token: 0x04000276 RID: 630
		public HHTMLBrowser unBrowserHandle;
	}
}
