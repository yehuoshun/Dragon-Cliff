using System;

// Token: 0x020005BE RID: 1470
public class ElfsRobeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002927 RID: 10535 RVA: 0x0011B6D5 File Offset: 0x00119AD5
	public ElfsRobeTemplate()
	{
	}

	// Token: 0x17000410 RID: 1040
	// (get) Token: 0x06002928 RID: 10536 RVA: 0x0011B6DD File Offset: 0x00119ADD
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.ElfsRobe;
		}
	}

	// Token: 0x17000411 RID: 1041
	// (get) Token: 0x06002929 RID: 10537 RVA: 0x0011B6E4 File Offset: 0x00119AE4
	public override int ItemTierNumber
	{
		get
		{
			return 12;
		}
	}
}
