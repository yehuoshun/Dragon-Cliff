using System;
using System.Collections.Generic;

// Token: 0x0200058E RID: 1422
public class ProtectorOfFeralTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002884 RID: 10372 RVA: 0x0011AE01 File Offset: 0x00119201
	public ProtectorOfFeralTemplate()
	{
	}

	// Token: 0x170003B0 RID: 944
	// (get) Token: 0x06002885 RID: 10373 RVA: 0x0011AE1C File Offset: 0x0011921C
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003B1 RID: 945
	// (get) Token: 0x06002886 RID: 10374 RVA: 0x0011AE24 File Offset: 0x00119224
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002887 RID: 10375 RVA: 0x0011AE2C File Offset: 0x0011922C
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>();
	}

	// Token: 0x040021FD RID: 8701
	private ResourceType _itemType = ResourceType.ProtectorOfFeral;

	// Token: 0x040021FE RID: 8702
	private int _itemTierNumber = 18;
}
