using System;
using System.Collections.Generic;

// Token: 0x02000598 RID: 1432
public class WrapsOfBrokenSoulsTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028A5 RID: 10405 RVA: 0x0011AF61 File Offset: 0x00119361
	public WrapsOfBrokenSoulsTemplate()
	{
	}

	// Token: 0x170003C4 RID: 964
	// (get) Token: 0x060028A6 RID: 10406 RVA: 0x0011AF7C File Offset: 0x0011937C
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003C5 RID: 965
	// (get) Token: 0x060028A7 RID: 10407 RVA: 0x0011AF84 File Offset: 0x00119384
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060028A8 RID: 10408 RVA: 0x0011AF8C File Offset: 0x0011938C
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.TurnStartHeal
		};
	}

	// Token: 0x04002201 RID: 8705
	private ResourceType _itemType = ResourceType.WrapsOfBrokenSouls;

	// Token: 0x04002202 RID: 8706
	private int _itemTierNumber = 19;
}
