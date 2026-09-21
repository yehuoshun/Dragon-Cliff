using System;

// Token: 0x02000583 RID: 1411
public class HuntersLeatherTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600285E RID: 10334 RVA: 0x0011AB5B File Offset: 0x00118F5B
	public HuntersLeatherTemplate()
	{
	}

	// Token: 0x1700039A RID: 922
	// (get) Token: 0x0600285F RID: 10335 RVA: 0x0011AB63 File Offset: 0x00118F63
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.HuntersLeather;
		}
	}

	// Token: 0x1700039B RID: 923
	// (get) Token: 0x06002860 RID: 10336 RVA: 0x0011AB6A File Offset: 0x00118F6A
	public override int ItemTierNumber
	{
		get
		{
			return 2;
		}
	}
}
