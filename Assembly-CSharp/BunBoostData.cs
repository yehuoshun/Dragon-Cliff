using System;

// Token: 0x020007C3 RID: 1987
[Serializable]
public class BunBoostData : ISpecialEffectDataLoad
{
	// Token: 0x06003A10 RID: 14864 RVA: 0x001775D3 File Offset: 0x001759D3
	public BunBoostData()
	{
	}

	// Token: 0x06003A11 RID: 14865 RVA: 0x001775DB File Offset: 0x001759DB
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.BunBoost;
	}

	// Token: 0x06003A12 RID: 14866 RVA: 0x001775E4 File Offset: 0x001759E4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{vitality}", this.VitalityBoostRate.ToExpressionMultiply100()).Replace("{reflection}", this.DamageReflectionRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003A13 RID: 14867 RVA: 0x00177634 File Offset: 0x00175A34
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003A14 RID: 14868 RVA: 0x0017763C File Offset: 0x00175A3C
	public double GetEffectPowerValue()
	{
		return (1.0 + this.VitalityBoostRate) * (1.0 + this.DamageReflectionRate);
	}

	// Token: 0x04002CDB RID: 11483
	public double VitalityBoostRate;

	// Token: 0x04002CDC RID: 11484
	public double DamageReflectionRate;

	// Token: 0x04002CDD RID: 11485
	public bool IsStar;
}
