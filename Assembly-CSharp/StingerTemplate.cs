using System;
using System.Collections.Generic;

// Token: 0x0200061F RID: 1567
public class StingerTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002AC7 RID: 10951 RVA: 0x0011FB0D File Offset: 0x0011DF0D
	public StingerTemplate()
	{
	}

	// Token: 0x170004D3 RID: 1235
	// (get) Token: 0x06002AC8 RID: 10952 RVA: 0x0011FB28 File Offset: 0x0011DF28
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170004D4 RID: 1236
	// (get) Token: 0x06002AC9 RID: 10953 RVA: 0x0011FB30 File Offset: 0x0011DF30
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002ACA RID: 10954 RVA: 0x0011FB38 File Offset: 0x0011DF38
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.EffectResistanceRating
		};
	}

	// Token: 0x04002289 RID: 8841
	private ResourceType _itemType = ResourceType.Stinger;

	// Token: 0x0400228A RID: 8842
	private int _itemTierNumber = 13;
}
