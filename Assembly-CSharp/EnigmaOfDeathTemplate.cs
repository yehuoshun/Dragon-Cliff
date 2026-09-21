using System;
using System.Collections.Generic;

// Token: 0x020005C0 RID: 1472
public class EnigmaOfDeathTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600292E RID: 10542 RVA: 0x0011B740 File Offset: 0x00119B40
	public EnigmaOfDeathTemplate()
	{
	}

	// Token: 0x17000414 RID: 1044
	// (get) Token: 0x0600292F RID: 10543 RVA: 0x0011B75B File Offset: 0x00119B5B
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000415 RID: 1045
	// (get) Token: 0x06002930 RID: 10544 RVA: 0x0011B763 File Offset: 0x00119B63
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002931 RID: 10545 RVA: 0x0011B76C File Offset: 0x00119B6C
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.TurnStartHeal
		};
	}

	// Token: 0x04002222 RID: 8738
	private ResourceType _itemType = ResourceType.EnigmaOfDeath;

	// Token: 0x04002223 RID: 8739
	private int _itemTierNumber = 18;
}
