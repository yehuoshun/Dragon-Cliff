using System;

// Token: 0x020005A6 RID: 1446
public class HeavyPlateTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028D7 RID: 10455 RVA: 0x0011B25F File Offset: 0x0011965F
	public HeavyPlateTemplate()
	{
	}

	// Token: 0x170003E0 RID: 992
	// (get) Token: 0x060028D8 RID: 10456 RVA: 0x0011B267 File Offset: 0x00119667
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.HeavyPlate;
		}
	}

	// Token: 0x170003E1 RID: 993
	// (get) Token: 0x060028D9 RID: 10457 RVA: 0x0011B26E File Offset: 0x0011966E
	public override int ItemTierNumber
	{
		get
		{
			return 12;
		}
	}
}
