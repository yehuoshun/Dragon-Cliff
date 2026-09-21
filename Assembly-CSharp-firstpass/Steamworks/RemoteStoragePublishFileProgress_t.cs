using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E3 RID: 227
	[CallbackIdentity(1329)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStoragePublishFileProgress_t
	{
		// Token: 0x040003C1 RID: 961
		public const int k_iCallback = 1329;

		// Token: 0x040003C2 RID: 962
		public double m_dPercentFile;

		// Token: 0x040003C3 RID: 963
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bPreview;
	}
}
