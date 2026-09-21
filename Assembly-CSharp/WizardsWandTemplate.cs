using System;

// Token: 0x0200065A RID: 1626
public class WizardsWandTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002BAD RID: 11181 RVA: 0x00120E53 File Offset: 0x0011F253
	public WizardsWandTemplate()
	{
	}

	// Token: 0x17000549 RID: 1353
	// (get) Token: 0x06002BAE RID: 11182 RVA: 0x00120E5B File Offset: 0x0011F25B
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.WizardsWand;
		}
	}

	// Token: 0x1700054A RID: 1354
	// (get) Token: 0x06002BAF RID: 11183 RVA: 0x00120E62 File Offset: 0x0011F262
	public override int ItemTierNumber
	{
		get
		{
			return 3;
		}
	}
}
