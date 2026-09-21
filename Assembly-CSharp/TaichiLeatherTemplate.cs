using System;

// Token: 0x02000595 RID: 1429
public class TaichiLeatherTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600289C RID: 10396 RVA: 0x0011AF2A File Offset: 0x0011932A
	public TaichiLeatherTemplate()
	{
	}

	// Token: 0x170003BE RID: 958
	// (get) Token: 0x0600289D RID: 10397 RVA: 0x0011AF32 File Offset: 0x00119332
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.TaichiLeather;
		}
	}

	// Token: 0x170003BF RID: 959
	// (get) Token: 0x0600289E RID: 10398 RVA: 0x0011AF39 File Offset: 0x00119339
	public override int ItemTierNumber
	{
		get
		{
			return 12;
		}
	}
}
