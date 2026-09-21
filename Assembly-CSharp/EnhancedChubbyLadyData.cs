using System;

// Token: 0x020007F7 RID: 2039
[Serializable]
public class EnhancedChubbyLadyData : ISpecialEffectDataLoad
{
	// Token: 0x06003B18 RID: 15128 RVA: 0x0017922E File Offset: 0x0017762E
	public EnhancedChubbyLadyData()
	{
	}

	// Token: 0x06003B19 RID: 15129 RVA: 0x00179236 File Offset: 0x00177636
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.EnhancedChubbyLady;
	}

	// Token: 0x06003B1A RID: 15130 RVA: 0x00179240 File Offset: 0x00177640
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{boost}", this.ShieldBoost.ToExpressionMultiply100()).Replace("{damage}", this.DamageRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003B1B RID: 15131 RVA: 0x00179290 File Offset: 0x00177690
	public bool IsStarEffect()
	{
		return true;
	}

	// Token: 0x06003B1C RID: 15132 RVA: 0x00179293 File Offset: 0x00177693
	public double GetEffectPowerValue()
	{
		return (1.0 + this.ShieldBoost) * (1.0 + this.DamageRate);
	}

	// Token: 0x04002D81 RID: 11649
	public double ShieldBoost;

	// Token: 0x04002D82 RID: 11650
	public double DamageRate;
}
