using System;
using System.Collections.Generic;

// Token: 0x02000643 RID: 1603
public class AgileWandTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B55 RID: 11093 RVA: 0x001207B0 File Offset: 0x0011EBB0
	public AgileWandTemplate()
	{
	}

	// Token: 0x1700051B RID: 1307
	// (get) Token: 0x06002B56 RID: 11094 RVA: 0x001207B8 File Offset: 0x0011EBB8
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.AgileWand;
		}
	}

	// Token: 0x1700051C RID: 1308
	// (get) Token: 0x06002B57 RID: 11095 RVA: 0x001207BF File Offset: 0x0011EBBF
	public override int ItemTierNumber
	{
		get
		{
			return 9;
		}
	}

	// Token: 0x06002B58 RID: 11096 RVA: 0x001207C4 File Offset: 0x0011EBC4
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		if (itemTierNumber <= 35)
		{
			return new List<AttributeType>
			{
				AttributeType.CritRate
			};
		}
		return new List<AttributeType>
		{
			AttributeType.HitRateAdjustment
		};
	}
}
