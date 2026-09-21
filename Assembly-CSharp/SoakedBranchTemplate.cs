using System;

// Token: 0x02000656 RID: 1622
public class SoakedBranchTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002BA0 RID: 11168 RVA: 0x00120D80 File Offset: 0x0011F180
	public SoakedBranchTemplate()
	{
	}

	// Token: 0x17000541 RID: 1345
	// (get) Token: 0x06002BA1 RID: 11169 RVA: 0x00120D88 File Offset: 0x0011F188
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.SoakedBranch;
		}
	}

	// Token: 0x17000542 RID: 1346
	// (get) Token: 0x06002BA2 RID: 11170 RVA: 0x00120D8F File Offset: 0x0011F18F
	public override int ItemTierNumber
	{
		get
		{
			return 4;
		}
	}
}
