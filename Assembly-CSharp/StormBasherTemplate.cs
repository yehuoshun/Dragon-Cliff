using System;
using System.Collections.Generic;

// Token: 0x02000606 RID: 1542
public class StormBasherTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002A52 RID: 10834 RVA: 0x0011F0BB File Offset: 0x0011D4BB
	public StormBasherTemplate()
	{
	}

	// Token: 0x1700049D RID: 1181
	// (get) Token: 0x06002A53 RID: 10835 RVA: 0x0011F0DD File Offset: 0x0011D4DD
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700049E RID: 1182
	// (get) Token: 0x06002A54 RID: 10836 RVA: 0x0011F0E5 File Offset: 0x0011D4E5
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002A55 RID: 10837 RVA: 0x0011F0F0 File Offset: 0x0011D4F0
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealFireDamageEffectivenessChangeRate
		};
	}

	// Token: 0x04002274 RID: 8820
	private ResourceType _itemType = ResourceType.StormBasher;

	// Token: 0x04002275 RID: 8821
	private int _itemLevel = 3;

	// Token: 0x04002276 RID: 8822
	private int _itemTierNumber = 15;
}
