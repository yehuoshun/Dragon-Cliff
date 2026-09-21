using System;

// Token: 0x020005B9 RID: 1465
public class BloodRobeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002916 RID: 10518 RVA: 0x0011B59A File Offset: 0x0011999A
	public BloodRobeTemplate()
	{
	}

	// Token: 0x17000406 RID: 1030
	// (get) Token: 0x06002917 RID: 10519 RVA: 0x0011B5A2 File Offset: 0x001199A2
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.BloodRobe;
		}
	}

	// Token: 0x17000407 RID: 1031
	// (get) Token: 0x06002918 RID: 10520 RVA: 0x0011B5A9 File Offset: 0x001199A9
	public override int ItemTierNumber
	{
		get
		{
			return 21;
		}
	}
}
