using System;

namespace Steamworks
{
	// Token: 0x02000126 RID: 294
	[Flags]
	public enum EFriendFlags
	{
		// Token: 0x0400061D RID: 1565
		k_EFriendFlagNone = 0,
		// Token: 0x0400061E RID: 1566
		k_EFriendFlagBlocked = 1,
		// Token: 0x0400061F RID: 1567
		k_EFriendFlagFriendshipRequested = 2,
		// Token: 0x04000620 RID: 1568
		k_EFriendFlagImmediate = 4,
		// Token: 0x04000621 RID: 1569
		k_EFriendFlagClanMember = 8,
		// Token: 0x04000622 RID: 1570
		k_EFriendFlagOnGameServer = 16,
		// Token: 0x04000623 RID: 1571
		k_EFriendFlagRequestingFriendship = 128,
		// Token: 0x04000624 RID: 1572
		k_EFriendFlagRequestingInfo = 256,
		// Token: 0x04000625 RID: 1573
		k_EFriendFlagIgnored = 512,
		// Token: 0x04000626 RID: 1574
		k_EFriendFlagIgnoredFriend = 1024,
		// Token: 0x04000627 RID: 1575
		k_EFriendFlagChatMember = 4096,
		// Token: 0x04000628 RID: 1576
		k_EFriendFlagAll = 65535
	}
}
