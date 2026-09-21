using System;

// Token: 0x0200067B RID: 1659
public class WoodenSwordTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002C29 RID: 11305 RVA: 0x00121799 File Offset: 0x0011FB99
	public WoodenSwordTemplate()
	{
	}

	// Token: 0x1700058B RID: 1419
	// (get) Token: 0x06002C2A RID: 11306 RVA: 0x001217A1 File Offset: 0x0011FBA1
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.WoodenSword;
		}
	}

	// Token: 0x1700058C RID: 1420
	// (get) Token: 0x06002C2B RID: 11307 RVA: 0x001217A8 File Offset: 0x0011FBA8
	public override int ItemTierNumber
	{
		get
		{
			return 1;
		}
	}
}
