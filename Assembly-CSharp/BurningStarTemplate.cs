using System;
using System.Collections.Generic;

// Token: 0x02000646 RID: 1606
public class BurningStarTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B61 RID: 11105 RVA: 0x00120866 File Offset: 0x0011EC66
	public BurningStarTemplate()
	{
	}

	// Token: 0x17000521 RID: 1313
	// (get) Token: 0x06002B62 RID: 11106 RVA: 0x00120881 File Offset: 0x0011EC81
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000522 RID: 1314
	// (get) Token: 0x06002B63 RID: 11107 RVA: 0x00120889 File Offset: 0x0011EC89
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002B64 RID: 11108 RVA: 0x00120894 File Offset: 0x0011EC94
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealDivineDamageEffectivenessChangeRate,
			AttributeType.DealFireDamageEffectivenessChangeRate,
			AttributeType.DealShadowDamageEffectivenessChangeRate
		};
	}

	// Token: 0x0400229E RID: 8862
	private ResourceType _itemType = ResourceType.BurningStar;

	// Token: 0x0400229F RID: 8863
	private int _itemTierNumber = 28;
}
