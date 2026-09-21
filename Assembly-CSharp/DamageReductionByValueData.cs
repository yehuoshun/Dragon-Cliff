using System;

// Token: 0x020007D5 RID: 2005
[Serializable]
public class DamageReductionByValueData : ISpecialEffectDataLoad
{
	// Token: 0x06003A6B RID: 14955 RVA: 0x00177E6E File Offset: 0x0017626E
	public DamageReductionByValueData()
	{
	}

	// Token: 0x06003A6C RID: 14956 RVA: 0x00177E76 File Offset: 0x00176276
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DamageReductionByHealth;
	}

	// Token: 0x06003A6D RID: 14957 RVA: 0x00177E80 File Offset: 0x00176280
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Percentage.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003A6E RID: 14958 RVA: 0x00177EBB File Offset: 0x001762BB
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x06003A6F RID: 14959 RVA: 0x00177EBE File Offset: 0x001762BE
	public double GetEffectPowerValue()
	{
		return this.Percentage;
	}

	// Token: 0x04002D0A RID: 11530
	public double Percentage;
}
