using System;

// Token: 0x0200058D RID: 1421
public class PledgeOfThunderTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002881 RID: 10369 RVA: 0x0011ADD6 File Offset: 0x001191D6
	public PledgeOfThunderTemplate()
	{
	}

	// Token: 0x170003AE RID: 942
	// (get) Token: 0x06002882 RID: 10370 RVA: 0x0011ADF1 File Offset: 0x001191F1
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003AF RID: 943
	// (get) Token: 0x06002883 RID: 10371 RVA: 0x0011ADF9 File Offset: 0x001191F9
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x040021FB RID: 8699
	private ResourceType _itemType = ResourceType.PledgeOfThunder;

	// Token: 0x040021FC RID: 8700
	private int _itemTierNumber = 10;
}
