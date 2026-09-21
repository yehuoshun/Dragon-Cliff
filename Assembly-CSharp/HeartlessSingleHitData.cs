using System;

// Token: 0x0200081E RID: 2078
[Serializable]
public class HeartlessSingleHitData : ISpecialEffectDataLoad
{
	// Token: 0x06003BD7 RID: 15319 RVA: 0x0017A433 File Offset: 0x00178833
	public HeartlessSingleHitData()
	{
	}

	// Token: 0x06003BD8 RID: 15320 RVA: 0x0017A43B File Offset: 0x0017883B
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.HeartlessSingleHit;
	}

	// Token: 0x06003BD9 RID: 15321 RVA: 0x0017A444 File Offset: 0x00178844
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.DamageRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003BDA RID: 15322 RVA: 0x0017A47F File Offset: 0x0017887F
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003BDB RID: 15323 RVA: 0x0017A487 File Offset: 0x00178887
	public double GetEffectPowerValue()
	{
		return this.DamageRate;
	}

	// Token: 0x04002DE8 RID: 11752
	public double DamageRate;

	// Token: 0x04002DE9 RID: 11753
	public bool IsStar;
}
