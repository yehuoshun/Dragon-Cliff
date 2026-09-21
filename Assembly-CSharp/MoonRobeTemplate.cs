using System;

// Token: 0x020005CC RID: 1484
public class MoonRobeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002958 RID: 10584 RVA: 0x0011BA0E File Offset: 0x00119E0E
	public MoonRobeTemplate()
	{
	}

	// Token: 0x1700042C RID: 1068
	// (get) Token: 0x06002959 RID: 10585 RVA: 0x0011BA16 File Offset: 0x00119E16
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.MoonRobe;
		}
	}

	// Token: 0x1700042D RID: 1069
	// (get) Token: 0x0600295A RID: 10586 RVA: 0x0011BA1D File Offset: 0x00119E1D
	public override int ItemTierNumber
	{
		get
		{
			return 6;
		}
	}
}
