using System;

// Token: 0x020005C7 RID: 1479
public class JuniorMonksRobeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002948 RID: 10568 RVA: 0x0011B993 File Offset: 0x00119D93
	public JuniorMonksRobeTemplate()
	{
	}

	// Token: 0x17000422 RID: 1058
	// (get) Token: 0x06002949 RID: 10569 RVA: 0x0011B99B File Offset: 0x00119D9B
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.JuniorMonksRobe;
		}
	}

	// Token: 0x17000423 RID: 1059
	// (get) Token: 0x0600294A RID: 10570 RVA: 0x0011B9A2 File Offset: 0x00119DA2
	public override int ItemTierNumber
	{
		get
		{
			return 2;
		}
	}
}
