using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000107 RID: 263
	[CallbackIdentity(1101)]
	[StructLayout(LayoutKind.Explicit, Pack = 8)]
	public struct UserStatsReceived_t
	{
		// Token: 0x0400043B RID: 1083
		public const int k_iCallback = 1101;

		// Token: 0x0400043C RID: 1084
		[FieldOffset(0)]
		public ulong m_nGameID;

		// Token: 0x0400043D RID: 1085
		[FieldOffset(8)]
		public EResult m_eResult;

		// Token: 0x0400043E RID: 1086
		[FieldOffset(12)]
		public CSteamID m_steamIDUser;
	}
}
