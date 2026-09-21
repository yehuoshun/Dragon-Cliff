using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000091 RID: 145
	[CallbackIdentity(4503)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_StartRequest_t
	{
		// Token: 0x04000284 RID: 644
		public const int k_iCallback = 4503;

		// Token: 0x04000285 RID: 645
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x04000286 RID: 646
		public string pchURL;

		// Token: 0x04000287 RID: 647
		public string pchTarget;

		// Token: 0x04000288 RID: 648
		public string pchPostData;

		// Token: 0x04000289 RID: 649
		[MarshalAs(UnmanagedType.I1)]
		public bool bIsRedirect;
	}
}
