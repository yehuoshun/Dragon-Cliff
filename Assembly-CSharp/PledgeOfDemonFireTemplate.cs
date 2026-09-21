using System;

// Token: 0x020005CE RID: 1486
public class PledgeOfDemonFireTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600295E RID: 10590 RVA: 0x0011BA4B File Offset: 0x00119E4B
	public PledgeOfDemonFireTemplate()
	{
	}

	// Token: 0x17000430 RID: 1072
	// (get) Token: 0x0600295F RID: 10591 RVA: 0x0011BA66 File Offset: 0x00119E66
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000431 RID: 1073
	// (get) Token: 0x06002960 RID: 10592 RVA: 0x0011BA6E File Offset: 0x00119E6E
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0400222C RID: 8748
	private ResourceType _itemType = ResourceType.PledgeOfDemonFire;

	// Token: 0x0400222D RID: 8749
	private int _itemTierNumber = 14;
}
