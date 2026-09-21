using System;
using System.Collections.Generic;

// Token: 0x020005BC RID: 1468
public class CryOfNecromancyTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600291F RID: 10527 RVA: 0x0011B5D2 File Offset: 0x001199D2
	public CryOfNecromancyTemplate()
	{
	}

	// Token: 0x1700040C RID: 1036
	// (get) Token: 0x06002920 RID: 10528 RVA: 0x0011B5ED File Offset: 0x001199ED
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700040D RID: 1037
	// (get) Token: 0x06002921 RID: 10529 RVA: 0x0011B5F5 File Offset: 0x001199F5
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002922 RID: 10530 RVA: 0x0011B600 File Offset: 0x00119A00
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.ReflectiveDamage
		};
	}

	// Token: 0x0400221E RID: 8734
	private ResourceType _itemType = ResourceType.CryOfNecromancy;

	// Token: 0x0400221F RID: 8735
	private int _itemTierNumber = 9;
}
