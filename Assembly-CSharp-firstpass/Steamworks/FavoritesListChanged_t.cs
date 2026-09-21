using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000AC RID: 172
	[CallbackIdentity(502)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct FavoritesListChanged_t
	{
		// Token: 0x040002F3 RID: 755
		public const int k_iCallback = 502;

		// Token: 0x040002F4 RID: 756
		public uint m_nIP;

		// Token: 0x040002F5 RID: 757
		public uint m_nQueryPort;

		// Token: 0x040002F6 RID: 758
		public uint m_nConnPort;

		// Token: 0x040002F7 RID: 759
		public uint m_nAppID;

		// Token: 0x040002F8 RID: 760
		public uint m_nFlags;

		// Token: 0x040002F9 RID: 761
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bAdd;

		// Token: 0x040002FA RID: 762
		public AccountID_t m_unAccountId;
	}
}
