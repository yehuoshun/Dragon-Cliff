using System;

// Token: 0x0200058F RID: 1423
public class RedLeatherTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002888 RID: 10376 RVA: 0x0011AE33 File Offset: 0x00119233
	public RedLeatherTemplate()
	{
	}

	// Token: 0x170003B2 RID: 946
	// (get) Token: 0x06002889 RID: 10377 RVA: 0x0011AE3B File Offset: 0x0011923B
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.RedLeather;
		}
	}

	// Token: 0x170003B3 RID: 947
	// (get) Token: 0x0600288A RID: 10378 RVA: 0x0011AE42 File Offset: 0x00119242
	public override int ItemTierNumber
	{
		get
		{
			return 7;
		}
	}
}
