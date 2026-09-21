using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000098 RID: 152
	[CallbackIdentity(4510)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_CanGoBackAndForward_t
	{
		// Token: 0x040002A1 RID: 673
		public const int k_iCallback = 4510;

		// Token: 0x040002A2 RID: 674
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040002A3 RID: 675
		[MarshalAs(UnmanagedType.I1)]
		public bool bCanGoBack;

		// Token: 0x040002A4 RID: 676
		[MarshalAs(UnmanagedType.I1)]
		public bool bCanGoForward;
	}
}
