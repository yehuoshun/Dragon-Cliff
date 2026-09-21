using System;
using System.Collections.Generic;

// Token: 0x02000604 RID: 1540
public class IcebreakerTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002A4A RID: 10826 RVA: 0x0011F01F File Offset: 0x0011D41F
	public IcebreakerTemplate()
	{
	}

	// Token: 0x17000499 RID: 1177
	// (get) Token: 0x06002A4B RID: 10827 RVA: 0x0011F040 File Offset: 0x0011D440
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700049A RID: 1178
	// (get) Token: 0x06002A4C RID: 10828 RVA: 0x0011F048 File Offset: 0x0011D448
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002A4D RID: 10829 RVA: 0x0011F050 File Offset: 0x0011D450
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealIceDamageEffectivenessChangeRate
		};
	}

	// Token: 0x0400226F RID: 8815
	private ResourceType _itemType = ResourceType.Icebreaker;

	// Token: 0x04002270 RID: 8816
	private int _itemLevel = 2;

	// Token: 0x04002271 RID: 8817
	private int _itemTierNumber = 6;
}
