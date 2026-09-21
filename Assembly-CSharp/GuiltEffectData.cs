using System;

// Token: 0x02000817 RID: 2071
[Serializable]
public class GuiltEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003BB4 RID: 15284 RVA: 0x0017A14C File Offset: 0x0017854C
	public GuiltEffectData()
	{
	}

	// Token: 0x06003BB5 RID: 15285 RVA: 0x0017A154 File Offset: 0x00178554
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Guilt;
	}

	// Token: 0x06003BB6 RID: 15286 RVA: 0x0017A15C File Offset: 0x0017855C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{directrate}", this.DirectDamageBoostRate.ToExpressionMultiply100()).Replace("{hitrating}", this.HitRatingBoost.ToExpressionMultiply100()).Replace("{reduction}", this.EffectHitReduction.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003BB7 RID: 15287 RVA: 0x0017A1C1 File Offset: 0x001785C1
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x06003BB8 RID: 15288 RVA: 0x0017A1C4 File Offset: 0x001785C4
	public double GetEffectPowerValue()
	{
		return (1.0 + this.DirectDamageBoostRate) * (1.0 + this.HitRatingBoost);
	}

	// Token: 0x04002DDA RID: 11738
	public double DirectDamageBoostRate;

	// Token: 0x04002DDB RID: 11739
	public double HitRatingBoost;

	// Token: 0x04002DDC RID: 11740
	public double EffectHitReduction;
}
