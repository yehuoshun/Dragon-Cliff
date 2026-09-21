using System;

// Token: 0x02000825 RID: 2085
[Serializable]
public class InversedMandateData : ISpecialEffectDataLoad
{
	// Token: 0x06003BF6 RID: 15350 RVA: 0x0017A67D File Offset: 0x00178A7D
	public InversedMandateData()
	{
	}

	// Token: 0x06003BF7 RID: 15351 RVA: 0x0017A685 File Offset: 0x00178A85
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003BF8 RID: 15352 RVA: 0x0017A6A5 File Offset: 0x00178AA5
	public double GetEffectPowerValue()
	{
		return this.ChargeRate;
	}

	// Token: 0x06003BF9 RID: 15353 RVA: 0x0017A6AD File Offset: 0x00178AAD
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.InversedMandate;
	}

	// Token: 0x06003BFA RID: 15354 RVA: 0x0017A6B4 File Offset: 0x00178AB4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{chargerate}", this.ChargeRate.ToExpressionMultiply100()).Replace("{seconds}", this.LastingSeconds.FloatToString()).Replace("{damagerate}", this.DamageRate.ToExpressionMultiply100()).Replace("{damagetype}", this.DamageType.GetDescription().Title).ToString();
		return description;
	}

	// Token: 0x04002DF5 RID: 11765
	public double ChargeRate;

	// Token: 0x04002DF6 RID: 11766
	public float LastingSeconds;

	// Token: 0x04002DF7 RID: 11767
	public double DamageRate;

	// Token: 0x04002DF8 RID: 11768
	public OutputType DamageType;

	// Token: 0x04002DF9 RID: 11769
	public double Charged;

	// Token: 0x04002DFA RID: 11770
	public bool? IsStarEf;
}
