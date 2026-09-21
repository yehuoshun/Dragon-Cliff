using System;
using System.Collections.Generic;

// Token: 0x020005D6 RID: 1494
public class RobeOfLostTormentTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600297B RID: 10619 RVA: 0x0011BD6C File Offset: 0x0011A16C
	public RobeOfLostTormentTemplate()
	{
	}

	// Token: 0x17000440 RID: 1088
	// (get) Token: 0x0600297C RID: 10620 RVA: 0x0011BD8E File Offset: 0x0011A18E
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000441 RID: 1089
	// (get) Token: 0x0600297D RID: 10621 RVA: 0x0011BD96 File Offset: 0x0011A196
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0600297E RID: 10622 RVA: 0x0011BDA0 File Offset: 0x0011A1A0
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Resilience
		};
	}

	// Token: 0x0400223A RID: 8762
	private ResourceType _itemType = ResourceType.RobeOfLostTorment;

	// Token: 0x0400223B RID: 8763
	private int _itemLevel = 2;

	// Token: 0x0400223C RID: 8764
	private int _itemTierNumber = 9;
}
