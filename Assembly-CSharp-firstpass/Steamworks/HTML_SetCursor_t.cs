using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000A0 RID: 160
	[CallbackIdentity(4522)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_SetCursor_t
	{
		// Token: 0x040002CC RID: 716
		public const int k_iCallback = 4522;

		// Token: 0x040002CD RID: 717
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040002CE RID: 718
		public uint eMouseCursor;
	}
}
