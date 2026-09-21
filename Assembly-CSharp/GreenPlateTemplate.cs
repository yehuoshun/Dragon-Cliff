using System;

// Token: 0x020005A4 RID: 1444
public class GreenPlateTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028D1 RID: 10449 RVA: 0x0011B23A File Offset: 0x0011963A
	public GreenPlateTemplate()
	{
	}

	// Token: 0x170003DC RID: 988
	// (get) Token: 0x060028D2 RID: 10450 RVA: 0x0011B242 File Offset: 0x00119642
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.GreenPlate;
		}
	}

	// Token: 0x170003DD RID: 989
	// (get) Token: 0x060028D3 RID: 10451 RVA: 0x0011B249 File Offset: 0x00119649
	public override int ItemTierNumber
	{
		get
		{
			return 11;
		}
	}
}
