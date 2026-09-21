using System;
using System.Collections.Generic;

// Token: 0x02000618 RID: 1560
public class GrasscutterTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002AAC RID: 10924 RVA: 0x0011F98B File Offset: 0x0011DD8B
	public GrasscutterTemplate()
	{
	}

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06002AAD RID: 10925 RVA: 0x0011F9A6 File Offset: 0x0011DDA6
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170004C6 RID: 1222
	// (get) Token: 0x06002AAE RID: 10926 RVA: 0x0011F9AE File Offset: 0x0011DDAE
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002AAF RID: 10927 RVA: 0x0011F9B8 File Offset: 0x0011DDB8
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.CritRate
		};
	}

	// Token: 0x04002285 RID: 8837
	private ResourceType _itemType = ResourceType.Grasscutter;

	// Token: 0x04002286 RID: 8838
	private int _itemTierNumber = 19;
}
