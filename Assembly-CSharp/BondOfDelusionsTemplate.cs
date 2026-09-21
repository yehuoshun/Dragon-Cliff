using System;
using System.Collections.Generic;

// Token: 0x0200059A RID: 1434
public class BondOfDelusionsTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028AD RID: 10413 RVA: 0x0011AFFF File Offset: 0x001193FF
	public BondOfDelusionsTemplate()
	{
	}

	// Token: 0x170003C8 RID: 968
	// (get) Token: 0x060028AE RID: 10414 RVA: 0x0011B01A File Offset: 0x0011941A
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003C9 RID: 969
	// (get) Token: 0x060028AF RID: 10415 RVA: 0x0011B022 File Offset: 0x00119422
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060028B0 RID: 10416 RVA: 0x0011B02C File Offset: 0x0011942C
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Resilience
		};
	}

	// Token: 0x04002206 RID: 8710
	private ResourceType _itemType = ResourceType.BondOfDelusions;

	// Token: 0x04002207 RID: 8711
	private int _itemTierNumber = 14;
}
