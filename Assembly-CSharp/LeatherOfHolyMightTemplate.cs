using System;
using System.Collections.Generic;

// Token: 0x02000587 RID: 1415
public class LeatherOfHolyMightTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600286B RID: 10347 RVA: 0x0011ABF7 File Offset: 0x00118FF7
	public LeatherOfHolyMightTemplate()
	{
	}

	// Token: 0x170003A2 RID: 930
	// (get) Token: 0x0600286C RID: 10348 RVA: 0x0011AC12 File Offset: 0x00119012
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003A3 RID: 931
	// (get) Token: 0x0600286D RID: 10349 RVA: 0x0011AC1A File Offset: 0x0011901A
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0600286E RID: 10350 RVA: 0x0011AC24 File Offset: 0x00119024
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.EffectResistanceRating
		};
	}

	// Token: 0x040021F1 RID: 8689
	private ResourceType _itemType = ResourceType.LeatherOfHolyMight;

	// Token: 0x040021F2 RID: 8690
	private int _itemTierNumber = 13;
}
