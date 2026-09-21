using System;
using System.Collections.Generic;

// Token: 0x02000615 RID: 1557
public class FiresoulSwiftbladeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002A9F RID: 10911 RVA: 0x0011F851 File Offset: 0x0011DC51
	public FiresoulSwiftbladeTemplate()
	{
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06002AA0 RID: 10912 RVA: 0x0011F86C File Offset: 0x0011DC6C
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170004C0 RID: 1216
	// (get) Token: 0x06002AA1 RID: 10913 RVA: 0x0011F874 File Offset: 0x0011DC74
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002AA2 RID: 10914 RVA: 0x0011F87C File Offset: 0x0011DC7C
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealFireDamageEffectivenessChangeRate
		};
	}

	// Token: 0x04002283 RID: 8835
	private ResourceType _itemType = ResourceType.FiresoulSwiftblade;

	// Token: 0x04002284 RID: 8836
	private int _itemTierNumber = 9;
}
