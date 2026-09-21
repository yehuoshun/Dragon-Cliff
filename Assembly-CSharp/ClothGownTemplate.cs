using System;

// Token: 0x020005BA RID: 1466
public class ClothGownTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002919 RID: 10521 RVA: 0x0011B5AD File Offset: 0x001199AD
	public ClothGownTemplate()
	{
	}

	// Token: 0x17000408 RID: 1032
	// (get) Token: 0x0600291A RID: 10522 RVA: 0x0011B5B5 File Offset: 0x001199B5
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.ClothGown;
		}
	}

	// Token: 0x17000409 RID: 1033
	// (get) Token: 0x0600291B RID: 10523 RVA: 0x0011B5BC File Offset: 0x001199BC
	public override int ItemTierNumber
	{
		get
		{
			return 1;
		}
	}
}
