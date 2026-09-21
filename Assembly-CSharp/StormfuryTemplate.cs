using System;

// Token: 0x020005B3 RID: 1459
public class StormfuryTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002902 RID: 10498 RVA: 0x0011B4E9 File Offset: 0x001198E9
	public StormfuryTemplate()
	{
	}

	// Token: 0x170003FA RID: 1018
	// (get) Token: 0x06002903 RID: 10499 RVA: 0x0011B4F1 File Offset: 0x001198F1
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Stormfury;
		}
	}

	// Token: 0x170003FB RID: 1019
	// (get) Token: 0x06002904 RID: 10500 RVA: 0x0011B4F8 File Offset: 0x001198F8
	public override int ItemTierNumber
	{
		get
		{
			return 26;
		}
	}
}
