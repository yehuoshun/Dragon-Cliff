using System;
using System.Collections.Generic;

// Token: 0x02000645 RID: 1605
public class BrightWandTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B5D RID: 11101 RVA: 0x0012082B File Offset: 0x0011EC2B
	public BrightWandTemplate()
	{
	}

	// Token: 0x1700051F RID: 1311
	// (get) Token: 0x06002B5E RID: 11102 RVA: 0x00120833 File Offset: 0x0011EC33
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.BrightWand;
		}
	}

	// Token: 0x17000520 RID: 1312
	// (get) Token: 0x06002B5F RID: 11103 RVA: 0x0012083A File Offset: 0x0011EC3A
	public override int ItemTierNumber
	{
		get
		{
			return 1;
		}
	}

	// Token: 0x06002B60 RID: 11104 RVA: 0x00120840 File Offset: 0x0011EC40
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Vitality,
			AttributeType.Resilience
		};
	}
}
