using System;

// Token: 0x02000881 RID: 2177
[Serializable]
public class SpitFireProtectionEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003DEB RID: 15851 RVA: 0x001817DA File Offset: 0x0017FBDA
	public SpitFireProtectionEnhancementData()
	{
	}

	// Token: 0x06003DEC RID: 15852 RVA: 0x001817E2 File Offset: 0x0017FBE2
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SpitFireProtectionEnhancement;
	}

	// Token: 0x06003DED RID: 15853 RVA: 0x001817EC File Offset: 0x0017FBEC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{damagereductionrate}", this.DamageReductionRate.ToExpressionMultiply100()).Replace("{boostrate}", this.StrengthBoostRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003DEE RID: 15854 RVA: 0x0018183C File Offset: 0x0017FC3C
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003DEF RID: 15855 RVA: 0x00181844 File Offset: 0x0017FC44
	public double GetEffectPowerValue()
	{
		return (1.0 + this.DamageReductionRate) * (1.0 + this.StrengthBoostRate);
	}

	// Token: 0x04002EEC RID: 12012
	public double DamageReductionRate;

	// Token: 0x04002EED RID: 12013
	public double StrengthBoostRate;

	// Token: 0x04002EEE RID: 12014
	public bool IsStar;
}
