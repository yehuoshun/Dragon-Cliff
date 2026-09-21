using System;

namespace Steamworks
{
	// Token: 0x02000132 RID: 306
	[Flags]
	public enum EChatMemberStateChange
	{
		// Token: 0x04000695 RID: 1685
		k_EChatMemberStateChangeEntered = 1,
		// Token: 0x04000696 RID: 1686
		k_EChatMemberStateChangeLeft = 2,
		// Token: 0x04000697 RID: 1687
		k_EChatMemberStateChangeDisconnected = 4,
		// Token: 0x04000698 RID: 1688
		k_EChatMemberStateChangeKicked = 8,
		// Token: 0x04000699 RID: 1689
		k_EChatMemberStateChangeBanned = 16
	}
}
