using System;
using System.Collections.Generic;

// Token: 0x020005A2 RID: 1442
public class DragonProtectorTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028CA RID: 10442 RVA: 0x0011B1DB File Offset: 0x001195DB
	public DragonProtectorTemplate()
	{
	}

	// Token: 0x170003D8 RID: 984
	// (get) Token: 0x060028CB RID: 10443 RVA: 0x0011B1E3 File Offset: 0x001195E3
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.DragonProtector;
		}
	}

	// Token: 0x170003D9 RID: 985
	// (get) Token: 0x060028CC RID: 10444 RVA: 0x0011B1EA File Offset: 0x001195EA
	public override int ItemTierNumber
	{
		get
		{
			return 30;
		}
	}

	// Token: 0x060028CD RID: 10445 RVA: 0x0011B1F0 File Offset: 0x001195F0
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.EffectResistanceRating
		};
	}
}
