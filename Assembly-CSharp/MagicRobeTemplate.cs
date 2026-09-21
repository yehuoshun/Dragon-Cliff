using System;

// Token: 0x020005C9 RID: 1481
public class MagicRobeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600294F RID: 10575 RVA: 0x0011B9D7 File Offset: 0x00119DD7
	public MagicRobeTemplate()
	{
	}

	// Token: 0x17000426 RID: 1062
	// (get) Token: 0x06002950 RID: 10576 RVA: 0x0011B9DF File Offset: 0x00119DDF
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.MagicRobe;
		}
	}

	// Token: 0x17000427 RID: 1063
	// (get) Token: 0x06002951 RID: 10577 RVA: 0x0011B9E6 File Offset: 0x00119DE6
	public override int ItemTierNumber
	{
		get
		{
			return 3;
		}
	}
}
