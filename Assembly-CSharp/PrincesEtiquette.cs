using System;

// Token: 0x02000670 RID: 1648
public class PrincesEtiquette : RecipeProducedGearTemplateBase
{
	// Token: 0x06002BFF RID: 11263 RVA: 0x00121455 File Offset: 0x0011F855
	public PrincesEtiquette()
	{
	}

	// Token: 0x17000575 RID: 1397
	// (get) Token: 0x06002C00 RID: 11264 RVA: 0x00121477 File Offset: 0x0011F877
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000576 RID: 1398
	// (get) Token: 0x06002C01 RID: 11265 RVA: 0x0012147F File Offset: 0x0011F87F
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x040022BC RID: 8892
	private ResourceType _itemType = ResourceType.PrincesEtiquette;

	// Token: 0x040022BD RID: 8893
	private int _itemLevel = 6;

	// Token: 0x040022BE RID: 8894
	private int _itemTierNumber = 27;
}
