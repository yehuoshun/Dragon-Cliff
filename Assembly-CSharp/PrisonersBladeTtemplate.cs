using System;
using System.Collections.Generic;

// Token: 0x0200061C RID: 1564
public class PrisonersBladeTtemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002ABC RID: 10940 RVA: 0x0011FA93 File Offset: 0x0011DE93
	public PrisonersBladeTtemplate()
	{
	}

	// Token: 0x170004CD RID: 1229
	// (get) Token: 0x06002ABD RID: 10941 RVA: 0x0011FA9B File Offset: 0x0011DE9B
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.PrisonersBlade;
		}
	}

	// Token: 0x170004CE RID: 1230
	// (get) Token: 0x06002ABE RID: 10942 RVA: 0x0011FAA2 File Offset: 0x0011DEA2
	public override int ItemTierNumber
	{
		get
		{
			return 5;
		}
	}

	// Token: 0x06002ABF RID: 10943 RVA: 0x0011FAA8 File Offset: 0x0011DEA8
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealPoisonDamageEffectivenessChangeRate
		};
	}
}
