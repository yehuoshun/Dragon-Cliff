using System;
using System.Collections.Generic;

// Token: 0x02000667 RID: 1639
public class CryingWarbladeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002BDD RID: 11229 RVA: 0x001211A3 File Offset: 0x0011F5A3
	public CryingWarbladeTemplate()
	{
	}

	// Token: 0x17000563 RID: 1379
	// (get) Token: 0x06002BDE RID: 11230 RVA: 0x001211BE File Offset: 0x0011F5BE
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000564 RID: 1380
	// (get) Token: 0x06002BDF RID: 11231 RVA: 0x001211C6 File Offset: 0x0011F5C6
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002BE0 RID: 11232 RVA: 0x001211D0 File Offset: 0x0011F5D0
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Agility
		};
	}

	// Token: 0x040022B4 RID: 8884
	private ResourceType _itemType = ResourceType.CryingWarblade;

	// Token: 0x040022B5 RID: 8885
	private int _itemTierNumber = 12;
}
