using System;

// Token: 0x020005B6 RID: 1462
public class WarriorsPlateTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600290C RID: 10508 RVA: 0x0011B541 File Offset: 0x00119941
	public WarriorsPlateTemplate()
	{
	}

	// Token: 0x17000400 RID: 1024
	// (get) Token: 0x0600290D RID: 10509 RVA: 0x0011B549 File Offset: 0x00119949
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.WarriorsPlate;
		}
	}

	// Token: 0x17000401 RID: 1025
	// (get) Token: 0x0600290E RID: 10510 RVA: 0x0011B550 File Offset: 0x00119950
	public override int ItemTierNumber
	{
		get
		{
			return 16;
		}
	}
}
