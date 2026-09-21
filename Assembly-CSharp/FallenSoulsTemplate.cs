using System;
using System.Collections.Generic;

// Token: 0x020005C1 RID: 1473
public class FallenSoulsTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002932 RID: 10546 RVA: 0x0011B78B File Offset: 0x00119B8B
	public FallenSoulsTemplate()
	{
	}

	// Token: 0x17000416 RID: 1046
	// (get) Token: 0x06002933 RID: 10547 RVA: 0x0011B793 File Offset: 0x00119B93
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.FallenSouls;
		}
	}

	// Token: 0x17000417 RID: 1047
	// (get) Token: 0x06002934 RID: 10548 RVA: 0x0011B79A File Offset: 0x00119B9A
	public override int ItemTierNumber
	{
		get
		{
			return 29;
		}
	}

	// Token: 0x06002935 RID: 10549 RVA: 0x0011B7A0 File Offset: 0x00119BA0
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DodgeRateAdjustment
		};
	}
}
