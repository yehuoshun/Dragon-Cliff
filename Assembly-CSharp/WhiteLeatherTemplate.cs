using System;

// Token: 0x02000597 RID: 1431
public class WhiteLeatherTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028A2 RID: 10402 RVA: 0x0011AF4F File Offset: 0x0011934F
	public WhiteLeatherTemplate()
	{
	}

	// Token: 0x170003C2 RID: 962
	// (get) Token: 0x060028A3 RID: 10403 RVA: 0x0011AF57 File Offset: 0x00119357
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.WhiteLeather;
		}
	}

	// Token: 0x170003C3 RID: 963
	// (get) Token: 0x060028A4 RID: 10404 RVA: 0x0011AF5E File Offset: 0x0011935E
	public override int ItemTierNumber
	{
		get
		{
			return 6;
		}
	}
}
