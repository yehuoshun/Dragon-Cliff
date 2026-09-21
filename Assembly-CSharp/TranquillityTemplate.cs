using System;

// Token: 0x02000658 RID: 1624
public class TranquillityTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002BA6 RID: 11174 RVA: 0x00120DA4 File Offset: 0x0011F1A4
	public TranquillityTemplate()
	{
	}

	// Token: 0x17000545 RID: 1349
	// (get) Token: 0x06002BA7 RID: 11175 RVA: 0x00120DBF File Offset: 0x0011F1BF
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000546 RID: 1350
	// (get) Token: 0x06002BA8 RID: 11176 RVA: 0x00120DC7 File Offset: 0x0011F1C7
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x040022AA RID: 8874
	private ResourceType _itemType = ResourceType.Tranquility;

	// Token: 0x040022AB RID: 8875
	private int _itemTierNumber = 14;
}
