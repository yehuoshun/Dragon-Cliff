using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000094 RID: 148
	[CallbackIdentity(4506)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_FinishedRequest_t
	{
		// Token: 0x04000293 RID: 659
		public const int k_iCallback = 4506;

		// Token: 0x04000294 RID: 660
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x04000295 RID: 661
		public string pchURL;

		// Token: 0x04000296 RID: 662
		public string pchPageTitle;
	}
}
