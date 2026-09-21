using System;

// Token: 0x02000673 RID: 1651
public class SerratedSwordTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002C09 RID: 11273 RVA: 0x001214D6 File Offset: 0x0011F8D6
	public SerratedSwordTemplate()
	{
	}

	// Token: 0x1700057B RID: 1403
	// (get) Token: 0x06002C0A RID: 11274 RVA: 0x001214DE File Offset: 0x0011F8DE
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.SerratedSword;
		}
	}

	// Token: 0x1700057C RID: 1404
	// (get) Token: 0x06002C0B RID: 11275 RVA: 0x001214E5 File Offset: 0x0011F8E5
	public override int ItemTierNumber
	{
		get
		{
			return 2;
		}
	}
}
