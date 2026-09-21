using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200009D RID: 157
	[CallbackIdentity(4515)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_JSConfirm_t
	{
		// Token: 0x040002BD RID: 701
		public const int k_iCallback = 4515;

		// Token: 0x040002BE RID: 702
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040002BF RID: 703
		public string pchMessage;
	}
}
