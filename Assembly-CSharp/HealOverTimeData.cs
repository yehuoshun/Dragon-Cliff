using System;

// Token: 0x0200081A RID: 2074
[Serializable]
public class HealOverTimeData : ISpecialEffectDataLoad
{
	// Token: 0x06003BC3 RID: 15299 RVA: 0x0017A2CE File Offset: 0x001786CE
	public HealOverTimeData()
	{
	}

	// Token: 0x06003BC4 RID: 15300 RVA: 0x0017A2D6 File Offset: 0x001786D6
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.HealOverTimeBoost;
	}

	// Token: 0x06003BC5 RID: 15301 RVA: 0x0017A2DC File Offset: 0x001786DC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.ReductionRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003BC6 RID: 15302 RVA: 0x0017A317 File Offset: 0x00178717
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003BC7 RID: 15303 RVA: 0x0017A31F File Offset: 0x0017871F
	public double GetEffectPowerValue()
	{
		return this.ReductionRate;
	}

	// Token: 0x04002DE1 RID: 11745
	public double ReductionRate;

	// Token: 0x04002DE2 RID: 11746
	public bool IsStar;
}
