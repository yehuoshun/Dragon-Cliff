using System;
using System.Collections.Generic;

// Token: 0x02000599 RID: 1433
public class BlessingOfTwilightTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028A9 RID: 10409 RVA: 0x0011AFAB File Offset: 0x001193AB
	public BlessingOfTwilightTemplate()
	{
	}

	// Token: 0x170003C6 RID: 966
	// (get) Token: 0x060028AA RID: 10410 RVA: 0x0011AFCD File Offset: 0x001193CD
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003C7 RID: 967
	// (get) Token: 0x060028AB RID: 10411 RVA: 0x0011AFD5 File Offset: 0x001193D5
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060028AC RID: 10412 RVA: 0x0011AFE0 File Offset: 0x001193E0
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.TurnStartHeal
		};
	}

	// Token: 0x04002203 RID: 8707
	private ResourceType _itemType = ResourceType.BlessingOfTwilight;

	// Token: 0x04002204 RID: 8708
	private int _itemLevel = 3;

	// Token: 0x04002205 RID: 8709
	private int _itemTierNumber = 13;
}
