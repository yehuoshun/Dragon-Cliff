using System;

// Token: 0x02000895 RID: 2197
[Serializable]
public class TauntBoostData : ISpecialEffectDataLoad
{
	// Token: 0x06003E4F RID: 15951 RVA: 0x001821D4 File Offset: 0x001805D4
	public TauntBoostData()
	{
	}

	// Token: 0x06003E50 RID: 15952 RVA: 0x001821DC File Offset: 0x001805DC
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.TauntBoost;
	}

	// Token: 0x06003E51 RID: 15953 RVA: 0x001821E4 File Offset: 0x001805E4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{reflection}", this.DamageReflectionBoost.ToExpressionMultiply100()).Replace("{output}", this.OutputCapacityBoost.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003E52 RID: 15954 RVA: 0x00182234 File Offset: 0x00180634
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x06003E53 RID: 15955 RVA: 0x00182237 File Offset: 0x00180637
	public double GetEffectPowerValue()
	{
		return (1.0 + this.DamageReflectionBoost) * (1.0 + this.OutputCapacityBoost);
	}

	// Token: 0x04002F26 RID: 12070
	public double DamageReflectionBoost;

	// Token: 0x04002F27 RID: 12071
	public double OutputCapacityBoost;
}
