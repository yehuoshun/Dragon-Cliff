using System;

// Token: 0x02000581 RID: 1409
public class GuardOfAshesTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002858 RID: 10328 RVA: 0x0011AB17 File Offset: 0x00118F17
	public GuardOfAshesTemplate()
	{
	}

	// Token: 0x17000396 RID: 918
	// (get) Token: 0x06002859 RID: 10329 RVA: 0x0011AB39 File Offset: 0x00118F39
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000397 RID: 919
	// (get) Token: 0x0600285A RID: 10330 RVA: 0x0011AB41 File Offset: 0x00118F41
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x040021EA RID: 8682
	private ResourceType _itemType = ResourceType.GuardOfAshes;

	// Token: 0x040021EB RID: 8683
	private int _itemLevel = 6;

	// Token: 0x040021EC RID: 8684
	private int _itemTierNumber = 28;
}
