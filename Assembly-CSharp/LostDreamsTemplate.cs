using System;
using System.Collections.Generic;

// Token: 0x020005C8 RID: 1480
public class LostDreamsTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600294B RID: 10571 RVA: 0x0011B9A5 File Offset: 0x00119DA5
	public LostDreamsTemplate()
	{
	}

	// Token: 0x17000424 RID: 1060
	// (get) Token: 0x0600294C RID: 10572 RVA: 0x0011B9AD File Offset: 0x00119DAD
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.LostDreams;
		}
	}

	// Token: 0x17000425 RID: 1061
	// (get) Token: 0x0600294D RID: 10573 RVA: 0x0011B9B4 File Offset: 0x00119DB4
	public override int ItemTierNumber
	{
		get
		{
			return 31;
		}
	}

	// Token: 0x0600294E RID: 10574 RVA: 0x0011B9B8 File Offset: 0x00119DB8
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.BattleStartHeal
		};
	}
}
