using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200009C RID: 156
	[CallbackIdentity(4514)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_JSAlert_t
	{
		// Token: 0x040002BA RID: 698
		public const int k_iCallback = 4514;

		// Token: 0x040002BB RID: 699
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040002BC RID: 700
		public string pchMessage;
	}
}
