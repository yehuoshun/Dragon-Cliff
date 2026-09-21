using System;
using System.Collections.Generic;

// Token: 0x02000621 RID: 1569
public class WrathfulBloodbladeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002ACF RID: 10959 RVA: 0x0011FB8B File Offset: 0x0011DF8B
	public WrathfulBloodbladeTemplate()
	{
	}

	// Token: 0x170004D7 RID: 1239
	// (get) Token: 0x06002AD0 RID: 10960 RVA: 0x0011FBA6 File Offset: 0x0011DFA6
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170004D8 RID: 1240
	// (get) Token: 0x06002AD1 RID: 10961 RVA: 0x0011FBAE File Offset: 0x0011DFAE
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002AD2 RID: 10962 RVA: 0x0011FBB8 File Offset: 0x0011DFB8
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		if (itemTierNumber <= 35)
		{
			return new List<AttributeType>();
		}
		return new List<AttributeType>
		{
			AttributeType.EffectHitRating
		};
	}

	// Token: 0x0400228B RID: 8843
	private ResourceType _itemType = ResourceType.WrathfulBloodblade;

	// Token: 0x0400228C RID: 8844
	private int _itemTierNumber = 21;
}
