using System;

// Token: 0x020005D5 RID: 1493
public class RobeOfInfiniteHopeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002978 RID: 10616 RVA: 0x0011BD41 File Offset: 0x0011A141
	public RobeOfInfiniteHopeTemplate()
	{
	}

	// Token: 0x1700043E RID: 1086
	// (get) Token: 0x06002979 RID: 10617 RVA: 0x0011BD5C File Offset: 0x0011A15C
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700043F RID: 1087
	// (get) Token: 0x0600297A RID: 10618 RVA: 0x0011BD64 File Offset: 0x0011A164
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x04002238 RID: 8760
	private ResourceType _itemType = ResourceType.RobeOfInfiniteHope;

	// Token: 0x04002239 RID: 8761
	private int _itemTierNumber = 9;
}
