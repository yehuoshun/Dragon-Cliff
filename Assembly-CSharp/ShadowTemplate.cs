using System;

// Token: 0x02000592 RID: 1426
public class ShadowTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002892 RID: 10386 RVA: 0x0011AEBB File Offset: 0x001192BB
	public ShadowTemplate()
	{
	}

	// Token: 0x170003B8 RID: 952
	// (get) Token: 0x06002893 RID: 10387 RVA: 0x0011AEC3 File Offset: 0x001192C3
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Shadow;
		}
	}

	// Token: 0x170003B9 RID: 953
	// (get) Token: 0x06002894 RID: 10388 RVA: 0x0011AECA File Offset: 0x001192CA
	public override int ItemTierNumber
	{
		get
		{
			return 22;
		}
	}
}
