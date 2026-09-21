using System;
using System.Collections.Generic;

// Token: 0x02000649 RID: 1609
public class DevilsSpiritTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B6D RID: 11117 RVA: 0x00120914 File Offset: 0x0011ED14
	public DevilsSpiritTemplate()
	{
	}

	// Token: 0x17000527 RID: 1319
	// (get) Token: 0x06002B6E RID: 11118 RVA: 0x0012091C File Offset: 0x0011ED1C
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.DevilsSpirit;
		}
	}

	// Token: 0x17000528 RID: 1320
	// (get) Token: 0x06002B6F RID: 11119 RVA: 0x00120923 File Offset: 0x0011ED23
	public override int ItemTierNumber
	{
		get
		{
			return 17;
		}
	}

	// Token: 0x06002B70 RID: 11120 RVA: 0x00120928 File Offset: 0x0011ED28
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealLightningDamageEffectivenessChangeRate,
			AttributeType.DealIceDamageEffectivenessChangeRate,
			AttributeType.DealPoisonDamageEffectivenessChangeRate
		};
	}
}
