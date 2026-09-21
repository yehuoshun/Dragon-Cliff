using System;

// Token: 0x020007E1 RID: 2017
[Serializable]
public class DiseaseData : ISpecialEffectDataLoad
{
	// Token: 0x06003AA9 RID: 15017 RVA: 0x001786BF File Offset: 0x00176ABF
	public DiseaseData()
	{
	}

	// Token: 0x06003AAA RID: 15018 RVA: 0x001786C7 File Offset: 0x00176AC7
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Disease;
	}

	// Token: 0x06003AAB RID: 15019 RVA: 0x001786CC File Offset: 0x00176ACC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{damagerate}", this.DamageRate.ToExpressionMultiply100()).Replace("{damagetype}", this.DamageType.GetDescription().Title).Replace("{resistancevalue}", this.ResistanceReductionStartingValue.ToExpression()).Replace("{seconds}", this.DamageLastingSeconds.ToString()).Replace("{resistancerate}", this.ResistanceReductionRateValue.ToExpression()).ToString();
		return description;
	}

	// Token: 0x06003AAC RID: 15020 RVA: 0x0017876B File Offset: 0x00176B6B
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003AAD RID: 15021 RVA: 0x00178773 File Offset: 0x00176B73
	public double GetEffectPowerValue()
	{
		return (double)this.DamageLastingSeconds;
	}

	// Token: 0x04002D4E RID: 11598
	public double DamageRate;

	// Token: 0x04002D4F RID: 11599
	public OutputType DamageType;

	// Token: 0x04002D50 RID: 11600
	public int DamageLastingSeconds;

	// Token: 0x04002D51 RID: 11601
	public double ResistanceReductionStartingValue;

	// Token: 0x04002D52 RID: 11602
	public double ResistanceReductionRateValue;

	// Token: 0x04002D53 RID: 11603
	public bool IsStar;
}
