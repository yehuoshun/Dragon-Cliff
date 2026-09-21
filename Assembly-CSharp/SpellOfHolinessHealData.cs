using System;

// Token: 0x0200087C RID: 2172
[Serializable]
public class SpellOfHolinessHealData : ISpecialEffectDataLoad
{
	// Token: 0x06003DD2 RID: 15826 RVA: 0x0018154E File Offset: 0x0017F94E
	public SpellOfHolinessHealData()
	{
	}

	// Token: 0x06003DD3 RID: 15827 RVA: 0x00181556 File Offset: 0x0017F956
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SpellOfHolinessHeal;
	}

	// Token: 0x06003DD4 RID: 15828 RVA: 0x00181560 File Offset: 0x0017F960
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{healrate}", this.HealRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003DD5 RID: 15829 RVA: 0x0018159B File Offset: 0x0017F99B
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003DD6 RID: 15830 RVA: 0x001815A3 File Offset: 0x0017F9A3
	public double GetEffectPowerValue()
	{
		return this.HealRate;
	}

	// Token: 0x04002EDE RID: 11998
	public double HealRate;

	// Token: 0x04002EDF RID: 11999
	public bool IsStar;
}
