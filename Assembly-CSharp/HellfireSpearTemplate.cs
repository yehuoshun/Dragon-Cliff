using System;
using System.Collections.Generic;

// Token: 0x02000629 RID: 1577
public class HellfireSpearTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002AF1 RID: 10993 RVA: 0x0011FEB7 File Offset: 0x0011E2B7
	public HellfireSpearTemplate()
	{
	}

	// Token: 0x170004E7 RID: 1255
	// (get) Token: 0x06002AF2 RID: 10994 RVA: 0x0011FED9 File Offset: 0x0011E2D9
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170004E8 RID: 1256
	// (get) Token: 0x06002AF3 RID: 10995 RVA: 0x0011FEE1 File Offset: 0x0011E2E1
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002AF4 RID: 10996 RVA: 0x0011FEEC File Offset: 0x0011E2EC
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealLightningDamageEffectivenessChangeRate
		};
	}

	// Token: 0x0400228F RID: 8847
	private ResourceType _itemType = ResourceType.HellfireSpear;

	// Token: 0x04002290 RID: 8848
	private int _itemLevel = 6;

	// Token: 0x04002291 RID: 8849
	private int _itemTierNumber = 29;
}
