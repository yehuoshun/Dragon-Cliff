using System;

// Token: 0x0200065B RID: 1627
public class WoodenWandTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002BB0 RID: 11184 RVA: 0x00120E65 File Offset: 0x0011F265
	public WoodenWandTemplate()
	{
	}

	// Token: 0x1700054B RID: 1355
	// (get) Token: 0x06002BB1 RID: 11185 RVA: 0x00120E6D File Offset: 0x0011F26D
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.WoodenWand;
		}
	}

	// Token: 0x1700054C RID: 1356
	// (get) Token: 0x06002BB2 RID: 11186 RVA: 0x00120E74 File Offset: 0x0011F274
	public override int ItemTierNumber
	{
		get
		{
			return 1;
		}
	}
}
