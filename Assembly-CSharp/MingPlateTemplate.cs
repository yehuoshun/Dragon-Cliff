using System;

// Token: 0x020005A8 RID: 1448
public class MingPlateTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028DD RID: 10461 RVA: 0x0011B285 File Offset: 0x00119685
	public MingPlateTemplate()
	{
	}

	// Token: 0x170003E4 RID: 996
	// (get) Token: 0x060028DE RID: 10462 RVA: 0x0011B28D File Offset: 0x0011968D
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.MingPlate;
		}
	}

	// Token: 0x170003E5 RID: 997
	// (get) Token: 0x060028DF RID: 10463 RVA: 0x0011B294 File Offset: 0x00119694
	public override int ItemTierNumber
	{
		get
		{
			return 8;
		}
	}
}
