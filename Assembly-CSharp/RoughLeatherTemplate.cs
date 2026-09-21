using System;

// Token: 0x02000590 RID: 1424
public class RoughLeatherTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600288B RID: 10379 RVA: 0x0011AE45 File Offset: 0x00119245
	public RoughLeatherTemplate()
	{
	}

	// Token: 0x170003B4 RID: 948
	// (get) Token: 0x0600288C RID: 10380 RVA: 0x0011AE4D File Offset: 0x0011924D
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.RoughLeather;
		}
	}

	// Token: 0x170003B5 RID: 949
	// (get) Token: 0x0600288D RID: 10381 RVA: 0x0011AE54 File Offset: 0x00119254
	public override int ItemTierNumber
	{
		get
		{
			return 1;
		}
	}
}
