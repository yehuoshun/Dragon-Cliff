using System;

// Token: 0x020005B8 RID: 1464
public class AromaticRobeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002913 RID: 10515 RVA: 0x0011B587 File Offset: 0x00119987
	public AromaticRobeTemplate()
	{
	}

	// Token: 0x17000404 RID: 1028
	// (get) Token: 0x06002914 RID: 10516 RVA: 0x0011B58F File Offset: 0x0011998F
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.AromaticRobe;
		}
	}

	// Token: 0x17000405 RID: 1029
	// (get) Token: 0x06002915 RID: 10517 RVA: 0x0011B596 File Offset: 0x00119996
	public override int ItemTierNumber
	{
		get
		{
			return 11;
		}
	}
}
