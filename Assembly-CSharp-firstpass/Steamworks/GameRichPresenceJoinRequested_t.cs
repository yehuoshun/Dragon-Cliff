using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000075 RID: 117
	[CallbackIdentity(337)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GameRichPresenceJoinRequested_t
	{
		// Token: 0x04000218 RID: 536
		public const int k_iCallback = 337;

		// Token: 0x04000219 RID: 537
		public CSteamID m_steamIDFriend;

		// Token: 0x0400021A RID: 538
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_rgchConnect;
	}
}
