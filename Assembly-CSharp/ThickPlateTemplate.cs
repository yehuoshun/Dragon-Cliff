using System;

// Token: 0x020005B5 RID: 1461
public class ThickPlateTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002909 RID: 10505 RVA: 0x0011B52F File Offset: 0x0011992F
	public ThickPlateTemplate()
	{
	}

	// Token: 0x170003FE RID: 1022
	// (get) Token: 0x0600290A RID: 10506 RVA: 0x0011B537 File Offset: 0x00119937
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.ThickPlate;
		}
	}

	// Token: 0x170003FF RID: 1023
	// (get) Token: 0x0600290B RID: 10507 RVA: 0x0011B53E File Offset: 0x0011993E
	public override int ItemTierNumber
	{
		get
		{
			return 7;
		}
	}
}
