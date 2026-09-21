using System;

// Token: 0x0200087B RID: 2171
[Serializable]
public class SpellOfHolinessDamageData : ISpecialEffectDataLoad
{
	// Token: 0x06003DCD RID: 15821 RVA: 0x001814BB File Offset: 0x0017F8BB
	public SpellOfHolinessDamageData()
	{
	}

	// Token: 0x06003DCE RID: 15822 RVA: 0x001814C3 File Offset: 0x0017F8C3
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SpellOfHolinessDamage;
	}

	// Token: 0x06003DCF RID: 15823 RVA: 0x001814CC File Offset: 0x0017F8CC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.DamageRate.ToExpressionMultiply100()).Replace("{dispel}", this.NumberOfDispels.ToString());
		return description;
	}

	// Token: 0x06003DD0 RID: 15824 RVA: 0x00181522 File Offset: 0x0017F922
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003DD1 RID: 15825 RVA: 0x0018152A File Offset: 0x0017F92A
	public double GetEffectPowerValue()
	{
		return (1.0 + this.DamageRate) * (1.0 + (double)this.NumberOfDispels);
	}

	// Token: 0x04002EDB RID: 11995
	public double DamageRate;

	// Token: 0x04002EDC RID: 11996
	public bool IsStar;

	// Token: 0x04002EDD RID: 11997
	public int NumberOfDispels;
}
