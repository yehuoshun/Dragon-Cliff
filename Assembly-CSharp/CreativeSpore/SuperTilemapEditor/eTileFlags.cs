using System;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B94 RID: 2964
	[Flags]
	public enum eTileFlags
	{
		// Token: 0x04003C83 RID: 15491
		None = 0,
		// Token: 0x04003C84 RID: 15492
		Updated = 1,
		// Token: 0x04003C85 RID: 15493
		Rot90 = 2,
		// Token: 0x04003C86 RID: 15494
		FlipV = 4,
		// Token: 0x04003C87 RID: 15495
		FlipH = 8
	}
}
