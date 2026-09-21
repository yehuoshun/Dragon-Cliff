using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000070 RID: 112
	[CallbackIdentity(332)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GameServerChangeRequested_t
	{
		// Token: 0x04000206 RID: 518
		public const int k_iCallback = 332;

		// Token: 0x04000207 RID: 519
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		public string m_rgchServer;

		// Token: 0x04000208 RID: 520
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		public string m_rgchPassword;
	}
}
