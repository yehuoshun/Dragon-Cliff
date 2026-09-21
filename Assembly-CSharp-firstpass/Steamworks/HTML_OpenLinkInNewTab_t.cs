using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000095 RID: 149
	[CallbackIdentity(4507)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_OpenLinkInNewTab_t
	{
		// Token: 0x04000297 RID: 663
		public const int k_iCallback = 4507;

		// Token: 0x04000298 RID: 664
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x04000299 RID: 665
		public string pchURL;
	}
}
