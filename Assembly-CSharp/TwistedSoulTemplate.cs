using System;

// Token: 0x02000641 RID: 1601
public class TwistedSoulTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B4F RID: 11087 RVA: 0x00120773 File Offset: 0x0011EB73
	public TwistedSoulTemplate()
	{
	}

	// Token: 0x17000517 RID: 1303
	// (get) Token: 0x06002B50 RID: 11088 RVA: 0x0012078E File Offset: 0x0011EB8E
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000518 RID: 1304
	// (get) Token: 0x06002B51 RID: 11089 RVA: 0x00120796 File Offset: 0x0011EB96
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0400229C RID: 8860
	private ResourceType _itemType = ResourceType.TwistedSoul;

	// Token: 0x0400229D RID: 8861
	private int _itemTierNumber = 24;
}
