using System;

// Token: 0x020005BB RID: 1467
public class ConvergenceTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600291C RID: 10524 RVA: 0x0011B5BF File Offset: 0x001199BF
	public ConvergenceTemplate()
	{
	}

	// Token: 0x1700040A RID: 1034
	// (get) Token: 0x0600291D RID: 10525 RVA: 0x0011B5C7 File Offset: 0x001199C7
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Convergence;
		}
	}

	// Token: 0x1700040B RID: 1035
	// (get) Token: 0x0600291E RID: 10526 RVA: 0x0011B5CE File Offset: 0x001199CE
	public override int ItemTierNumber
	{
		get
		{
			return 27;
		}
	}
}
