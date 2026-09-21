using System;
using System.Collections.Generic;

// Token: 0x020005CF RID: 1487
public class PromisedRobeOfRedemptionTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002961 RID: 10593 RVA: 0x0011BA76 File Offset: 0x00119E76
	public PromisedRobeOfRedemptionTemplate()
	{
	}

	// Token: 0x17000432 RID: 1074
	// (get) Token: 0x06002962 RID: 10594 RVA: 0x0011BA91 File Offset: 0x00119E91
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000433 RID: 1075
	// (get) Token: 0x06002963 RID: 10595 RVA: 0x0011BA99 File Offset: 0x00119E99
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002964 RID: 10596 RVA: 0x0011BAA4 File Offset: 0x00119EA4
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Mining,
			AttributeType.Hunting
		};
	}

	// Token: 0x0400222E RID: 8750
	private ResourceType _itemType = ResourceType.PromisedRobeOfRedemption;

	// Token: 0x0400222F RID: 8751
	private int _itemTierNumber = 28;
}
