using System;

// Token: 0x02000818 RID: 2072
[Serializable]
public class HardLifeData : ISpecialEffectDataLoad
{
	// Token: 0x06003BB9 RID: 15289 RVA: 0x0017A1E7 File Offset: 0x001785E7
	public HardLifeData()
	{
	}

	// Token: 0x06003BBA RID: 15290 RVA: 0x0017A1EF File Offset: 0x001785EF
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.HardLife;
	}

	// Token: 0x06003BBB RID: 15291 RVA: 0x0017A1F4 File Offset: 0x001785F4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.DamageRate.ToExpressionMultiply100()).Replace("{shields}", this.NumberOfShields.ToString());
		return description;
	}

	// Token: 0x06003BBC RID: 15292 RVA: 0x0017A24A File Offset: 0x0017864A
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003BBD RID: 15293 RVA: 0x0017A252 File Offset: 0x00178652
	public double GetEffectPowerValue()
	{
		return (1.0 + (double)this.NumberOfShields) * (1.0 - this.DamageRate);
	}

	// Token: 0x04002DDD RID: 11741
	public double DamageRate;

	// Token: 0x04002DDE RID: 11742
	public int NumberOfShields;

	// Token: 0x04002DDF RID: 11743
	public bool IsStar;
}
