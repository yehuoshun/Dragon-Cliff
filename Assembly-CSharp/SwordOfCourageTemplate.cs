using System;
using System.Collections.Generic;

// Token: 0x02000676 RID: 1654
public class SwordOfCourageTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002C14 RID: 11284 RVA: 0x0012158A File Offset: 0x0011F98A
	public SwordOfCourageTemplate()
	{
	}

	// Token: 0x17000581 RID: 1409
	// (get) Token: 0x06002C15 RID: 11285 RVA: 0x001215A4 File Offset: 0x0011F9A4
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000582 RID: 1410
	// (get) Token: 0x06002C16 RID: 11286 RVA: 0x001215AC File Offset: 0x0011F9AC
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002C17 RID: 11287 RVA: 0x001215B4 File Offset: 0x0011F9B4
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealIceDamageEffectivenessChangeRate,
			AttributeType.DealFireDamageEffectivenessChangeRate
		};
	}

	// Token: 0x040022C3 RID: 8899
	private ResourceType _itemType = ResourceType.SwordOfCourage;

	// Token: 0x040022C4 RID: 8900
	private int _itemTierNumber = 6;
}
