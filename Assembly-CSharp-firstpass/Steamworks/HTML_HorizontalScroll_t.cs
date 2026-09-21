using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000099 RID: 153
	[CallbackIdentity(4511)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_HorizontalScroll_t
	{
		// Token: 0x040002A5 RID: 677
		public const int k_iCallback = 4511;

		// Token: 0x040002A6 RID: 678
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040002A7 RID: 679
		public uint unScrollMax;

		// Token: 0x040002A8 RID: 680
		public uint unScrollCurrent;

		// Token: 0x040002A9 RID: 681
		public float flPageScale;

		// Token: 0x040002AA RID: 682
		[MarshalAs(UnmanagedType.I1)]
		public bool bVisible;

		// Token: 0x040002AB RID: 683
		public uint unPageSize;
	}
}
