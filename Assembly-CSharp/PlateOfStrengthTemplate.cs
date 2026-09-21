using System;

// Token: 0x020005AC RID: 1452
public class PlateOfStrengthTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028EB RID: 10475 RVA: 0x0011B371 File Offset: 0x00119771
	public PlateOfStrengthTemplate()
	{
	}

	// Token: 0x170003EC RID: 1004
	// (get) Token: 0x060028EC RID: 10476 RVA: 0x0011B379 File Offset: 0x00119779
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.PlateOfStrength;
		}
	}

	// Token: 0x170003ED RID: 1005
	// (get) Token: 0x060028ED RID: 10477 RVA: 0x0011B380 File Offset: 0x00119780
	public override int ItemTierNumber
	{
		get
		{
			return 6;
		}
	}
}
