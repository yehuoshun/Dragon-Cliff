using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000096 RID: 150
	[CallbackIdentity(4508)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_ChangedTitle_t
	{
		// Token: 0x0400029A RID: 666
		public const int k_iCallback = 4508;

		// Token: 0x0400029B RID: 667
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x0400029C RID: 668
		public string pchTitle;
	}
}
