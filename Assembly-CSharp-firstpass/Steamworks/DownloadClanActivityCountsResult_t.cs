using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000079 RID: 121
	[CallbackIdentity(341)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct DownloadClanActivityCountsResult_t
	{
		// Token: 0x04000227 RID: 551
		public const int k_iCallback = 341;

		// Token: 0x04000228 RID: 552
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bSuccess;
	}
}
