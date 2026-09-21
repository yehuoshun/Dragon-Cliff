using System;

// Token: 0x020005C3 RID: 1475
public class GoldSilkTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600293A RID: 10554 RVA: 0x0011B83B File Offset: 0x00119C3B
	public GoldSilkTemplate()
	{
	}

	// Token: 0x1700041A RID: 1050
	// (get) Token: 0x0600293B RID: 10555 RVA: 0x0011B843 File Offset: 0x00119C43
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.GoldSilk;
		}
	}

	// Token: 0x1700041B RID: 1051
	// (get) Token: 0x0600293C RID: 10556 RVA: 0x0011B84A File Offset: 0x00119C4A
	public override int ItemTierNumber
	{
		get
		{
			return 16;
		}
	}
}
