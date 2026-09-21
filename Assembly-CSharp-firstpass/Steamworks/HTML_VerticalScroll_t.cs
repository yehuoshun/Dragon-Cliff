using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200009A RID: 154
	[CallbackIdentity(4512)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_VerticalScroll_t
	{
		// Token: 0x040002AC RID: 684
		public const int k_iCallback = 4512;

		// Token: 0x040002AD RID: 685
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040002AE RID: 686
		public uint unScrollMax;

		// Token: 0x040002AF RID: 687
		public uint unScrollCurrent;

		// Token: 0x040002B0 RID: 688
		public float flPageScale;

		// Token: 0x040002B1 RID: 689
		[MarshalAs(UnmanagedType.I1)]
		public bool bVisible;

		// Token: 0x040002B2 RID: 690
		public uint unPageSize;
	}
}
