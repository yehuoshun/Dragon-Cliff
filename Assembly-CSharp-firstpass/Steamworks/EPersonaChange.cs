using System;

namespace Steamworks
{
	// Token: 0x02000129 RID: 297
	[Flags]
	public enum EPersonaChange
	{
		// Token: 0x04000637 RID: 1591
		k_EPersonaChangeName = 1,
		// Token: 0x04000638 RID: 1592
		k_EPersonaChangeStatus = 2,
		// Token: 0x04000639 RID: 1593
		k_EPersonaChangeComeOnline = 4,
		// Token: 0x0400063A RID: 1594
		k_EPersonaChangeGoneOffline = 8,
		// Token: 0x0400063B RID: 1595
		k_EPersonaChangeGamePlayed = 16,
		// Token: 0x0400063C RID: 1596
		k_EPersonaChangeGameServer = 32,
		// Token: 0x0400063D RID: 1597
		k_EPersonaChangeAvatar = 64,
		// Token: 0x0400063E RID: 1598
		k_EPersonaChangeJoinedSource = 128,
		// Token: 0x0400063F RID: 1599
		k_EPersonaChangeLeftSource = 256,
		// Token: 0x04000640 RID: 1600
		k_EPersonaChangeRelationshipChanged = 512,
		// Token: 0x04000641 RID: 1601
		k_EPersonaChangeNameFirstSet = 1024,
		// Token: 0x04000642 RID: 1602
		k_EPersonaChangeFacebookInfo = 2048,
		// Token: 0x04000643 RID: 1603
		k_EPersonaChangeNickname = 4096,
		// Token: 0x04000644 RID: 1604
		k_EPersonaChangeSteamLevel = 8192
	}
}
