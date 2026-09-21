using System;

// Token: 0x020005A5 RID: 1445
public class HardenedPlateTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028D4 RID: 10452 RVA: 0x0011B24D File Offset: 0x0011964D
	public HardenedPlateTemplate()
	{
	}

	// Token: 0x170003DE RID: 990
	// (get) Token: 0x060028D5 RID: 10453 RVA: 0x0011B255 File Offset: 0x00119655
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.HardenedPlate;
		}
	}

	// Token: 0x170003DF RID: 991
	// (get) Token: 0x060028D6 RID: 10454 RVA: 0x0011B25C File Offset: 0x0011965C
	public override int ItemTierNumber
	{
		get
		{
			return 2;
		}
	}
}
