using System;
using System.Collections.Generic;

// Token: 0x02000632 RID: 1586
public class EdgeOfInsanityTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B16 RID: 11030 RVA: 0x00120155 File Offset: 0x0011E555
	public EdgeOfInsanityTemplate()
	{
	}

	// Token: 0x170004F9 RID: 1273
	// (get) Token: 0x06002B17 RID: 11031 RVA: 0x00120170 File Offset: 0x0011E570
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170004FA RID: 1274
	// (get) Token: 0x06002B18 RID: 11032 RVA: 0x00120178 File Offset: 0x0011E578
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002B19 RID: 11033 RVA: 0x00120180 File Offset: 0x0011E580
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.LifeOnHit
		};
	}

	// Token: 0x04002292 RID: 8850
	private ResourceType _itemType = ResourceType.EdgeOfInsanity;

	// Token: 0x04002293 RID: 8851
	private int _itemTierNumber = 12;
}
