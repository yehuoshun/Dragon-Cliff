using System;

// Token: 0x02000855 RID: 2133
[Serializable]
public class ReviveDamageData : ISpecialEffectDataLoad
{
	// Token: 0x06003CE8 RID: 15592 RVA: 0x0017C361 File Offset: 0x0017A761
	public ReviveDamageData()
	{
	}

	// Token: 0x06003CE9 RID: 15593 RVA: 0x0017C369 File Offset: 0x0017A769
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ReviveDamage;
	}

	// Token: 0x06003CEA RID: 15594 RVA: 0x0017C370 File Offset: 0x0017A770
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.DamageRate.ToExpressionMultiply100()).Replace("{type}", this.DamageType.GetDescription().Title);
		return description;
	}

	// Token: 0x06003CEB RID: 15595 RVA: 0x0017C3C5 File Offset: 0x0017A7C5
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003CEC RID: 15596 RVA: 0x0017C3CD File Offset: 0x0017A7CD
	public double GetEffectPowerValue()
	{
		return this.DamageRate;
	}

	// Token: 0x04002E7D RID: 11901
	public double DamageRate;

	// Token: 0x04002E7E RID: 11902
	public OutputType DamageType;

	// Token: 0x04002E7F RID: 11903
	public bool IsStar;
}
