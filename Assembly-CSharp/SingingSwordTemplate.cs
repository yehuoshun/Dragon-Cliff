using System;
using System.Collections.Generic;

// Token: 0x02000674 RID: 1652
public class SingingSwordTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002C0C RID: 11276 RVA: 0x001214E8 File Offset: 0x0011F8E8
	public SingingSwordTemplate()
	{
	}

	// Token: 0x1700057D RID: 1405
	// (get) Token: 0x06002C0D RID: 11277 RVA: 0x00121502 File Offset: 0x0011F902
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700057E RID: 1406
	// (get) Token: 0x06002C0E RID: 11278 RVA: 0x0012150A File Offset: 0x0011F90A
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002C0F RID: 11279 RVA: 0x00121514 File Offset: 0x0011F914
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.EffectHitRating
		};
	}

	// Token: 0x040022BF RID: 8895
	private ResourceType _itemType = ResourceType.SingingSword;

	// Token: 0x040022C0 RID: 8896
	private int _itemTierNumber = 8;
}
