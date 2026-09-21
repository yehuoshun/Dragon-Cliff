using System;

// Token: 0x0200063C RID: 1596
public class MoonlightTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B3F RID: 11071 RVA: 0x0012065B File Offset: 0x0011EA5B
	public MoonlightTemplate()
	{
	}

	// Token: 0x1700050D RID: 1293
	// (get) Token: 0x06002B40 RID: 11072 RVA: 0x00120676 File Offset: 0x0011EA76
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700050E RID: 1294
	// (get) Token: 0x06002B41 RID: 11073 RVA: 0x0012067E File Offset: 0x0011EA7E
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x04002298 RID: 8856
	private ResourceType _itemType = ResourceType.Moonlight;

	// Token: 0x04002299 RID: 8857
	private int _itemTierNumber = 18;
}
