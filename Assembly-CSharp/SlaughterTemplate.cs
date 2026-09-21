using System;

// Token: 0x020005B1 RID: 1457
public class SlaughterTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028FB RID: 10491 RVA: 0x0011B46A File Offset: 0x0011986A
	public SlaughterTemplate()
	{
	}

	// Token: 0x170003F6 RID: 1014
	// (get) Token: 0x060028FC RID: 10492 RVA: 0x0011B472 File Offset: 0x00119872
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Slaughter;
		}
	}

	// Token: 0x170003F7 RID: 1015
	// (get) Token: 0x060028FD RID: 10493 RVA: 0x0011B479 File Offset: 0x00119879
	public override int ItemTierNumber
	{
		get
		{
			return 22;
		}
	}
}
