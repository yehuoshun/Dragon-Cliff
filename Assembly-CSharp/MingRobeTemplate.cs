using System;

// Token: 0x020005CB RID: 1483
public class MingRobeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002955 RID: 10581 RVA: 0x0011B9FC File Offset: 0x00119DFC
	public MingRobeTemplate()
	{
	}

	// Token: 0x1700042A RID: 1066
	// (get) Token: 0x06002956 RID: 10582 RVA: 0x0011BA04 File Offset: 0x00119E04
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.MingRobe;
		}
	}

	// Token: 0x1700042B RID: 1067
	// (get) Token: 0x06002957 RID: 10583 RVA: 0x0011BA0B File Offset: 0x00119E0B
	public override int ItemTierNumber
	{
		get
		{
			return 7;
		}
	}
}
