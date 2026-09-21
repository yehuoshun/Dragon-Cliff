using System;
using System.Collections.Generic;

// Token: 0x02000675 RID: 1653
public class SoulStealerSwordTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002C10 RID: 11280 RVA: 0x00121533 File Offset: 0x0011F933
	public SoulStealerSwordTemplate()
	{
	}

	// Token: 0x1700057F RID: 1407
	// (get) Token: 0x06002C11 RID: 11281 RVA: 0x0012154E File Offset: 0x0011F94E
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000580 RID: 1408
	// (get) Token: 0x06002C12 RID: 11282 RVA: 0x00121556 File Offset: 0x0011F956
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002C13 RID: 11283 RVA: 0x00121560 File Offset: 0x0011F960
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealPhysicalDamageEffectivenessChangeRate,
			AttributeType.DealPoisonDamageEffectivenessChangeRate
		};
	}

	// Token: 0x040022C1 RID: 8897
	private ResourceType _itemType = ResourceType.SoulstealerSword;

	// Token: 0x040022C2 RID: 8898
	private int _itemTierNumber = 26;
}
