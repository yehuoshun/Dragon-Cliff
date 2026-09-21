using System;

// Token: 0x02000854 RID: 2132
[Serializable]
public class RestrictionOfTimeData : ISpecialEffectDataLoad
{
	// Token: 0x06003CE3 RID: 15587 RVA: 0x0017C2A3 File Offset: 0x0017A6A3
	public RestrictionOfTimeData()
	{
	}

	// Token: 0x06003CE4 RID: 15588 RVA: 0x0017C2AB File Offset: 0x0017A6AB
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.RestrictionOfTime;
	}

	// Token: 0x06003CE5 RID: 15589 RVA: 0x0017C2B4 File Offset: 0x0017A6B4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{dodge}", this.DodgeRateBoost.ToExpressionMultiply100()).Replace("{heal}", this.HealRate.ToExpressionMultiply100()).Replace("{seconds}", this.HealSeconds.ToString()).ToString();
		return description;
	}

	// Token: 0x06003CE6 RID: 15590 RVA: 0x0017C324 File Offset: 0x0017A724
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003CE7 RID: 15591 RVA: 0x0017C32C File Offset: 0x0017A72C
	public double GetEffectPowerValue()
	{
		return (1.0 + this.DodgeRateBoost) * (this.HealRate + 1.0) * ((double)this.HealSeconds + 1.0);
	}

	// Token: 0x04002E79 RID: 11897
	public double DodgeRateBoost;

	// Token: 0x04002E7A RID: 11898
	public double HealRate;

	// Token: 0x04002E7B RID: 11899
	public int HealSeconds;

	// Token: 0x04002E7C RID: 11900
	public bool IsStar;
}
