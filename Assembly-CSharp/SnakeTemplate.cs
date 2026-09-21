using System;

// Token: 0x02000594 RID: 1428
public class SnakeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002899 RID: 10393 RVA: 0x0011AF17 File Offset: 0x00119317
	public SnakeTemplate()
	{
	}

	// Token: 0x170003BC RID: 956
	// (get) Token: 0x0600289A RID: 10394 RVA: 0x0011AF1F File Offset: 0x0011931F
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Snake;
		}
	}

	// Token: 0x170003BD RID: 957
	// (get) Token: 0x0600289B RID: 10395 RVA: 0x0011AF26 File Offset: 0x00119326
	public override int ItemTierNumber
	{
		get
		{
			return 16;
		}
	}
}
