using System;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B8C RID: 2956
	[Flags]
	public enum eAutotilingMode
	{
		// Token: 0x04003C69 RID: 15465
		Self = 1,
		// Token: 0x04003C6A RID: 15466
		Other = 2,
		// Token: 0x04003C6B RID: 15467
		Group = 4,
		// Token: 0x04003C6C RID: 15468
		EmptyCells = 8,
		// Token: 0x04003C6D RID: 15469
		TilemapBounds = 16
	}
}
