using System;
using System.Collections.Generic;

// Token: 0x020005B4 RID: 1460
public class SupremeGodsPlateTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002905 RID: 10501 RVA: 0x0011B4FC File Offset: 0x001198FC
	public SupremeGodsPlateTemplate()
	{
	}

	// Token: 0x170003FC RID: 1020
	// (get) Token: 0x06002906 RID: 10502 RVA: 0x0011B504 File Offset: 0x00119904
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.SupremeGodsPlate;
		}
	}

	// Token: 0x170003FD RID: 1021
	// (get) Token: 0x06002907 RID: 10503 RVA: 0x0011B50B File Offset: 0x0011990B
	public override int ItemTierNumber
	{
		get
		{
			return 31;
		}
	}

	// Token: 0x06002908 RID: 10504 RVA: 0x0011B510 File Offset: 0x00119910
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.EffectHitRating
		};
	}
}
