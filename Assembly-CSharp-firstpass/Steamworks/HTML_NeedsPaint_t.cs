using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000090 RID: 144
	[CallbackIdentity(4502)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_NeedsPaint_t
	{
		// Token: 0x04000277 RID: 631
		public const int k_iCallback = 4502;

		// Token: 0x04000278 RID: 632
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x04000279 RID: 633
		public IntPtr pBGRA;

		// Token: 0x0400027A RID: 634
		public uint unWide;

		// Token: 0x0400027B RID: 635
		public uint unTall;

		// Token: 0x0400027C RID: 636
		public uint unUpdateX;

		// Token: 0x0400027D RID: 637
		public uint unUpdateY;

		// Token: 0x0400027E RID: 638
		public uint unUpdateWide;

		// Token: 0x0400027F RID: 639
		public uint unUpdateTall;

		// Token: 0x04000280 RID: 640
		public uint unScrollX;

		// Token: 0x04000281 RID: 641
		public uint unScrollY;

		// Token: 0x04000282 RID: 642
		public float flPageScale;

		// Token: 0x04000283 RID: 643
		public uint unPageSerial;
	}
}
