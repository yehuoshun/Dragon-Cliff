using System;

// Token: 0x020005AB RID: 1451
public class PlateOfGiantslayingTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028E8 RID: 10472 RVA: 0x0011B347 File Offset: 0x00119747
	public PlateOfGiantslayingTemplate()
	{
	}

	// Token: 0x170003EA RID: 1002
	// (get) Token: 0x060028E9 RID: 10473 RVA: 0x0011B361 File Offset: 0x00119761
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003EB RID: 1003
	// (get) Token: 0x060028EA RID: 10474 RVA: 0x0011B369 File Offset: 0x00119769
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x04002214 RID: 8724
	private ResourceType _itemType = ResourceType.PlateOfGiantslaying;

	// Token: 0x04002215 RID: 8725
	private int _itemTierNumber = 4;
}
