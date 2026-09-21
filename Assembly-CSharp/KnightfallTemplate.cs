using System;
using System.Collections.Generic;

// Token: 0x02000669 RID: 1641
public class KnightfallTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002BE5 RID: 11237 RVA: 0x0012121F File Offset: 0x0011F61F
	public KnightfallTemplate()
	{
	}

	// Token: 0x17000567 RID: 1383
	// (get) Token: 0x06002BE6 RID: 11238 RVA: 0x0012123A File Offset: 0x0011F63A
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000568 RID: 1384
	// (get) Token: 0x06002BE7 RID: 11239 RVA: 0x00121242 File Offset: 0x0011F642
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002BE8 RID: 11240 RVA: 0x0012124C File Offset: 0x0011F64C
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.HitRateAdjustment
		};
	}

	// Token: 0x040022B6 RID: 8886
	private ResourceType _itemType = ResourceType.Knightfall;

	// Token: 0x040022B7 RID: 8887
	private int _itemTierNumber = 9;
}
