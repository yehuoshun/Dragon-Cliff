using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200009F RID: 159
	[CallbackIdentity(4521)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_NewWindow_t
	{
		// Token: 0x040002C4 RID: 708
		public const int k_iCallback = 4521;

		// Token: 0x040002C5 RID: 709
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040002C6 RID: 710
		public string pchURL;

		// Token: 0x040002C7 RID: 711
		public uint unX;

		// Token: 0x040002C8 RID: 712
		public uint unY;

		// Token: 0x040002C9 RID: 713
		public uint unWide;

		// Token: 0x040002CA RID: 714
		public uint unTall;

		// Token: 0x040002CB RID: 715
		public HHTMLBrowser unNewWindow_BrowserHandle;
	}
}
