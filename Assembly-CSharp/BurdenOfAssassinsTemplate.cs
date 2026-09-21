using System;

// Token: 0x0200057C RID: 1404
public class BurdenOfAssassinsTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002847 RID: 10311 RVA: 0x0011A9EB File Offset: 0x00118DEB
	public BurdenOfAssassinsTemplate()
	{
	}

	// Token: 0x1700038C RID: 908
	// (get) Token: 0x06002848 RID: 10312 RVA: 0x0011AA05 File Offset: 0x00118E05
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700038D RID: 909
	// (get) Token: 0x06002849 RID: 10313 RVA: 0x0011AA0D File Offset: 0x00118E0D
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x040021E8 RID: 8680
	private ResourceType _itemType = ResourceType.BurdenOfAssassins;

	// Token: 0x040021E9 RID: 8681
	private int _itemTierNumber = 5;
}
