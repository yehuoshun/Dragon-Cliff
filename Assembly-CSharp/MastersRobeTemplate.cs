using System;

// Token: 0x020005CA RID: 1482
public class MastersRobeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002952 RID: 10578 RVA: 0x0011B9E9 File Offset: 0x00119DE9
	public MastersRobeTemplate()
	{
	}

	// Token: 0x17000428 RID: 1064
	// (get) Token: 0x06002953 RID: 10579 RVA: 0x0011B9F1 File Offset: 0x00119DF1
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.MastersRobe;
		}
	}

	// Token: 0x17000429 RID: 1065
	// (get) Token: 0x06002954 RID: 10580 RVA: 0x0011B9F8 File Offset: 0x00119DF8
	public override int ItemTierNumber
	{
		get
		{
			return 26;
		}
	}
}
