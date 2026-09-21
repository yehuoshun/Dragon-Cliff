using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000A1 RID: 161
	[CallbackIdentity(4523)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_StatusText_t
	{
		// Token: 0x040002CF RID: 719
		public const int k_iCallback = 4523;

		// Token: 0x040002D0 RID: 720
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040002D1 RID: 721
		public string pchMsg;
	}
}
