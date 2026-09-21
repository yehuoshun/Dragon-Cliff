using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000093 RID: 147
	[CallbackIdentity(4505)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_URLChanged_t
	{
		// Token: 0x0400028C RID: 652
		public const int k_iCallback = 4505;

		// Token: 0x0400028D RID: 653
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x0400028E RID: 654
		public string pchURL;

		// Token: 0x0400028F RID: 655
		public string pchPostData;

		// Token: 0x04000290 RID: 656
		[MarshalAs(UnmanagedType.I1)]
		public bool bIsRedirect;

		// Token: 0x04000291 RID: 657
		public string pchPageTitle;

		// Token: 0x04000292 RID: 658
		[MarshalAs(UnmanagedType.I1)]
		public bool bNewNavigation;
	}
}
