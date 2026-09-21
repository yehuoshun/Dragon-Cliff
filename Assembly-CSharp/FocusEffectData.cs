using System;

// Token: 0x02000809 RID: 2057
[Serializable]
public class FocusEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003B73 RID: 15219 RVA: 0x00179AD3 File Offset: 0x00177ED3
	public FocusEffectData()
	{
	}

	// Token: 0x06003B74 RID: 15220 RVA: 0x00179ADB File Offset: 0x00177EDB
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Focus;
	}

	// Token: 0x06003B75 RID: 15221 RVA: 0x00179AE4 File Offset: 0x00177EE4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{damage}", this.DamageBoostRate.ToExpressionMultiply100()).Replace("{reduction}", this.DamageReductionRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003B76 RID: 15222 RVA: 0x00179B34 File Offset: 0x00177F34
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x06003B77 RID: 15223 RVA: 0x00179B37 File Offset: 0x00177F37
	public double GetEffectPowerValue()
	{
		return this.DamageBoostRate;
	}

	// Token: 0x04002DAE RID: 11694
	public double DamageBoostRate;

	// Token: 0x04002DAF RID: 11695
	public double DamageReductionRate;
}
