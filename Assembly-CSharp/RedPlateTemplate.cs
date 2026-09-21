using System;

// Token: 0x020005B0 RID: 1456
public class RedPlateTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028F8 RID: 10488 RVA: 0x0011B458 File Offset: 0x00119858
	public RedPlateTemplate()
	{
	}

	// Token: 0x170003F4 RID: 1012
	// (get) Token: 0x060028F9 RID: 10489 RVA: 0x0011B460 File Offset: 0x00119860
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.RedPlate;
		}
	}

	// Token: 0x170003F5 RID: 1013
	// (get) Token: 0x060028FA RID: 10490 RVA: 0x0011B467 File Offset: 0x00119867
	public override int ItemTierNumber
	{
		get
		{
			return 3;
		}
	}
}
