using System;
using System.Collections.Generic;

// Token: 0x0200066D RID: 1645
public class MercyTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002BF4 RID: 11252 RVA: 0x00121342 File Offset: 0x0011F742
	public MercyTemplate()
	{
	}

	// Token: 0x1700056F RID: 1391
	// (get) Token: 0x06002BF5 RID: 11253 RVA: 0x0012135D File Offset: 0x0011F75D
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000570 RID: 1392
	// (get) Token: 0x06002BF6 RID: 11254 RVA: 0x00121365 File Offset: 0x0011F765
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002BF7 RID: 11255 RVA: 0x00121370 File Offset: 0x0011F770
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Allresistances
		};
	}

	// Token: 0x040022B8 RID: 8888
	private ResourceType _itemType = ResourceType.Mercy;

	// Token: 0x040022B9 RID: 8889
	private int _itemTierNumber = 15;
}
