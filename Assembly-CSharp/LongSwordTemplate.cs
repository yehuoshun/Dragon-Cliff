using System;

// Token: 0x0200066A RID: 1642
public class LongSwordTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002BE9 RID: 11241 RVA: 0x0012126B File Offset: 0x0011F66B
	public LongSwordTemplate()
	{
	}

	// Token: 0x17000569 RID: 1385
	// (get) Token: 0x06002BEA RID: 11242 RVA: 0x00121273 File Offset: 0x0011F673
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.LongSword;
		}
	}

	// Token: 0x1700056A RID: 1386
	// (get) Token: 0x06002BEB RID: 11243 RVA: 0x0012127A File Offset: 0x0011F67A
	public override int ItemTierNumber
	{
		get
		{
			return 3;
		}
	}
}
