using System;

// Token: 0x0200059B RID: 1435
public class CopperCoatedPlateTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028B1 RID: 10417 RVA: 0x0011B04B File Offset: 0x0011944B
	public CopperCoatedPlateTemplate()
	{
	}

	// Token: 0x170003CA RID: 970
	// (get) Token: 0x060028B2 RID: 10418 RVA: 0x0011B053 File Offset: 0x00119453
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.CopperCoatedPlate;
		}
	}

	// Token: 0x170003CB RID: 971
	// (get) Token: 0x060028B3 RID: 10419 RVA: 0x0011B05A File Offset: 0x0011945A
	public override int ItemTierNumber
	{
		get
		{
			return 1;
		}
	}
}
