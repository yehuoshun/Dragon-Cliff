using System;

// Token: 0x020005AD RID: 1453
public class PlateOfTheCataclysmTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028EE RID: 10478 RVA: 0x0011B383 File Offset: 0x00119783
	public PlateOfTheCataclysmTemplate()
	{
	}

	// Token: 0x170003EE RID: 1006
	// (get) Token: 0x060028EF RID: 10479 RVA: 0x0011B39E File Offset: 0x0011979E
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003EF RID: 1007
	// (get) Token: 0x060028F0 RID: 10480 RVA: 0x0011B3A6 File Offset: 0x001197A6
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x04002216 RID: 8726
	private ResourceType _itemType = ResourceType.PlateOfTheCataclysm;

	// Token: 0x04002217 RID: 8727
	private int _itemTierNumber = 24;
}
