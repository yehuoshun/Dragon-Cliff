using System;
using System.Collections.Generic;

// Token: 0x020005D8 RID: 1496
public class RobesOfTheCorruptedTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002982 RID: 10626 RVA: 0x0011BDEA File Offset: 0x0011A1EA
	public RobesOfTheCorruptedTemplate()
	{
	}

	// Token: 0x17000444 RID: 1092
	// (get) Token: 0x06002983 RID: 10627 RVA: 0x0011BE05 File Offset: 0x0011A205
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000445 RID: 1093
	// (get) Token: 0x06002984 RID: 10628 RVA: 0x0011BE0D File Offset: 0x0011A20D
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002985 RID: 10629 RVA: 0x0011BE15 File Offset: 0x0011A215
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>();
	}

	// Token: 0x0400223F RID: 8767
	private ResourceType _itemType = ResourceType.RobeOfTheCorrupted;

	// Token: 0x04002240 RID: 8768
	private int _itemTierNumber = 19;
}
