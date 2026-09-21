using System;

// Token: 0x02000807 RID: 2055
[Serializable]
public class FlyingBladeData : ISpecialEffectDataLoad
{
	// Token: 0x06003B69 RID: 15209 RVA: 0x00179A07 File Offset: 0x00177E07
	public FlyingBladeData()
	{
	}

	// Token: 0x06003B6A RID: 15210 RVA: 0x00179A0F File Offset: 0x00177E0F
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.FlyingBlade;
	}

	// Token: 0x06003B6B RID: 15211 RVA: 0x00179A14 File Offset: 0x00177E14
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{rate}", this.DamageRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003B6C RID: 15212 RVA: 0x00179A64 File Offset: 0x00177E64
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B6D RID: 15213 RVA: 0x00179A6C File Offset: 0x00177E6C
	public double GetEffectPowerValue()
	{
		return (1.0 + this.DamageRate) * (1.0 + this.Chance);
	}

	// Token: 0x04002DAA RID: 11690
	public double Chance;

	// Token: 0x04002DAB RID: 11691
	public double DamageRate;

	// Token: 0x04002DAC RID: 11692
	public bool IsStar;
}
