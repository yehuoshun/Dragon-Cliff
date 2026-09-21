using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000097 RID: 151
	[CallbackIdentity(4509)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_SearchResults_t
	{
		// Token: 0x0400029D RID: 669
		public const int k_iCallback = 4509;

		// Token: 0x0400029E RID: 670
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x0400029F RID: 671
		public uint unResults;

		// Token: 0x040002A0 RID: 672
		public uint unCurrentMatch;
	}
}
