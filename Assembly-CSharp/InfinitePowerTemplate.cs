using System;

// Token: 0x02000584 RID: 1412
public class InfinitePowerTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002861 RID: 10337 RVA: 0x0011AB6D File Offset: 0x00118F6D
	public InfinitePowerTemplate()
	{
	}

	// Token: 0x1700039C RID: 924
	// (get) Token: 0x06002862 RID: 10338 RVA: 0x0011AB75 File Offset: 0x00118F75
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.InfinitePower;
		}
	}

	// Token: 0x1700039D RID: 925
	// (get) Token: 0x06002863 RID: 10339 RVA: 0x0011AB7C File Offset: 0x00118F7C
	public override int ItemTierNumber
	{
		get
		{
			return 27;
		}
	}
}
