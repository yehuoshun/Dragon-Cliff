using System;
using System.Collections.Generic;

// Token: 0x02000588 RID: 1416
public class LeatherOfRegretsTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600286F RID: 10351 RVA: 0x0011AC43 File Offset: 0x00119043
	public LeatherOfRegretsTemplate()
	{
	}

	// Token: 0x170003A4 RID: 932
	// (get) Token: 0x06002870 RID: 10352 RVA: 0x0011AC5E File Offset: 0x0011905E
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003A5 RID: 933
	// (get) Token: 0x06002871 RID: 10353 RVA: 0x0011AC66 File Offset: 0x00119066
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002872 RID: 10354 RVA: 0x0011AC70 File Offset: 0x00119070
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Hunting,
			AttributeType.Mining
		};
	}

	// Token: 0x040021F3 RID: 8691
	private ResourceType _itemType = ResourceType.LeatherOfRegrets;

	// Token: 0x040021F4 RID: 8692
	private int _itemTierNumber = 23;
}
