using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200009B RID: 155
	[CallbackIdentity(4513)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_LinkAtPosition_t
	{
		// Token: 0x040002B3 RID: 691
		public const int k_iCallback = 4513;

		// Token: 0x040002B4 RID: 692
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040002B5 RID: 693
		public uint x;

		// Token: 0x040002B6 RID: 694
		public uint y;

		// Token: 0x040002B7 RID: 695
		public string pchURL;

		// Token: 0x040002B8 RID: 696
		[MarshalAs(UnmanagedType.I1)]
		public bool bInput;

		// Token: 0x040002B9 RID: 697
		[MarshalAs(UnmanagedType.I1)]
		public bool bLiveLink;
	}
}
