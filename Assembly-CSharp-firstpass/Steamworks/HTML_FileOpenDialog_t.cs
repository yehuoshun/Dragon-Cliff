using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200009E RID: 158
	[CallbackIdentity(4516)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_FileOpenDialog_t
	{
		// Token: 0x040002C0 RID: 704
		public const int k_iCallback = 4516;

		// Token: 0x040002C1 RID: 705
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040002C2 RID: 706
		public string pchTitle;

		// Token: 0x040002C3 RID: 707
		public string pchInitialFile;
	}
}
