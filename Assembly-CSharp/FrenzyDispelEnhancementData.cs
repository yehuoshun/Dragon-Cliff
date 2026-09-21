using System;

// Token: 0x0200080D RID: 2061
[Serializable]
public class FrenzyDispelEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003B87 RID: 15239 RVA: 0x00179C9E File Offset: 0x0017809E
	public FrenzyDispelEnhancementData()
	{
	}

	// Token: 0x06003B88 RID: 15240 RVA: 0x00179CA6 File Offset: 0x001780A6
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.FrenzyDispelEnhancement;
	}

	// Token: 0x06003B89 RID: 15241 RVA: 0x00179CB0 File Offset: 0x001780B0
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.NumberOfDispels.ToString());
		return description;
	}

	// Token: 0x06003B8A RID: 15242 RVA: 0x00179CF1 File Offset: 0x001780F1
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B8B RID: 15243 RVA: 0x00179CF9 File Offset: 0x001780F9
	public double GetEffectPowerValue()
	{
		return (double)this.NumberOfDispels;
	}

	// Token: 0x04002DB7 RID: 11703
	public int NumberOfDispels;

	// Token: 0x04002DB8 RID: 11704
	public bool IsStar;
}
