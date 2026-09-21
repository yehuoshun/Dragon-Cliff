using System;

// Token: 0x0200084E RID: 2126
[Serializable]
public class ReflectionBoostData : ISpecialEffectDataLoad
{
	// Token: 0x06003CC5 RID: 15557 RVA: 0x0017BFD3 File Offset: 0x0017A3D3
	public ReflectionBoostData()
	{
	}

	// Token: 0x06003CC6 RID: 15558 RVA: 0x0017BFDB File Offset: 0x0017A3DB
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ReflectionBoost;
	}

	// Token: 0x06003CC7 RID: 15559 RVA: 0x0017BFE0 File Offset: 0x0017A3E0
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.ReflectionRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003CC8 RID: 15560 RVA: 0x0017C01B File Offset: 0x0017A41B
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003CC9 RID: 15561 RVA: 0x0017C023 File Offset: 0x0017A423
	public double GetEffectPowerValue()
	{
		return this.ReflectionRate;
	}

	// Token: 0x04002E6B RID: 11883
	public double ReflectionRate;

	// Token: 0x04002E6C RID: 11884
	public bool IsStar;
}
