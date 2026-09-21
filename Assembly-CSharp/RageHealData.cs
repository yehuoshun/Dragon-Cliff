using System;

// Token: 0x0200084B RID: 2123
[Serializable]
public class RageHealData : ISpecialEffectDataLoad
{
	// Token: 0x06003CB6 RID: 15542 RVA: 0x0017BE97 File Offset: 0x0017A297
	public RageHealData()
	{
	}

	// Token: 0x06003CB7 RID: 15543 RVA: 0x0017BE9F File Offset: 0x0017A29F
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003CB8 RID: 15544 RVA: 0x0017BEBF File Offset: 0x0017A2BF
	public double GetEffectPowerValue()
	{
		return this.HealRate;
	}

	// Token: 0x06003CB9 RID: 15545 RVA: 0x0017BEC7 File Offset: 0x0017A2C7
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.RageHeal;
	}

	// Token: 0x06003CBA RID: 15546 RVA: 0x0017BECC File Offset: 0x0017A2CC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.HealRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x04002E66 RID: 11878
	public double HealRate;

	// Token: 0x04002E67 RID: 11879
	public bool? IsStarEf;
}
