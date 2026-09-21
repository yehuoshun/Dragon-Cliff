using System;

// Token: 0x02000657 RID: 1623
public class SpiritualWandTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002BA3 RID: 11171 RVA: 0x00120D92 File Offset: 0x0011F192
	public SpiritualWandTemplate()
	{
	}

	// Token: 0x17000543 RID: 1347
	// (get) Token: 0x06002BA4 RID: 11172 RVA: 0x00120D9A File Offset: 0x0011F19A
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.SpiritualWand;
		}
	}

	// Token: 0x17000544 RID: 1348
	// (get) Token: 0x06002BA5 RID: 11173 RVA: 0x00120DA1 File Offset: 0x0011F1A1
	public override int ItemTierNumber
	{
		get
		{
			return 2;
		}
	}
}
