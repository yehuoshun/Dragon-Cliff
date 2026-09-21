using System;

// Token: 0x02000589 RID: 1417
public class LeatherOfTimelessDreamsTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002873 RID: 10355 RVA: 0x0011AC9A File Offset: 0x0011909A
	public LeatherOfTimelessDreamsTemplate()
	{
	}

	// Token: 0x170003A6 RID: 934
	// (get) Token: 0x06002874 RID: 10356 RVA: 0x0011ACB5 File Offset: 0x001190B5
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003A7 RID: 935
	// (get) Token: 0x06002875 RID: 10357 RVA: 0x0011ACBD File Offset: 0x001190BD
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x040021F5 RID: 8693
	private ResourceType _itemType = ResourceType.LeatherOfTimelessDreams;

	// Token: 0x040021F6 RID: 8694
	private int _itemTierNumber = 24;
}
