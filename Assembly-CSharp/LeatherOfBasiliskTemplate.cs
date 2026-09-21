using System;

// Token: 0x02000585 RID: 1413
public class LeatherOfBasiliskTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002864 RID: 10340 RVA: 0x0011AB80 File Offset: 0x00118F80
	public LeatherOfBasiliskTemplate()
	{
	}

	// Token: 0x1700039E RID: 926
	// (get) Token: 0x06002865 RID: 10341 RVA: 0x0011AB9B File Offset: 0x00118F9B
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700039F RID: 927
	// (get) Token: 0x06002866 RID: 10342 RVA: 0x0011ABA3 File Offset: 0x00118FA3
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x040021ED RID: 8685
	private ResourceType _itemType = ResourceType.LeatherOfBasilisk;

	// Token: 0x040021EE RID: 8686
	private int _itemTierNumber = 19;
}
