using System;

// Token: 0x020005D7 RID: 1495
public class RobeOfStealthTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600297F RID: 10623 RVA: 0x0011BDBF File Offset: 0x0011A1BF
	public RobeOfStealthTemplate()
	{
	}

	// Token: 0x17000442 RID: 1090
	// (get) Token: 0x06002980 RID: 10624 RVA: 0x0011BDDA File Offset: 0x0011A1DA
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000443 RID: 1091
	// (get) Token: 0x06002981 RID: 10625 RVA: 0x0011BDE2 File Offset: 0x0011A1E2
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0400223D RID: 8765
	private ResourceType _itemType = ResourceType.RobeOfStealth;

	// Token: 0x0400223E RID: 8766
	private int _itemTierNumber = 13;
}
