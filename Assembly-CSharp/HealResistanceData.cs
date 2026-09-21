using System;

// Token: 0x0200081B RID: 2075
[Serializable]
public class HealResistanceData : ISpecialEffectDataLoad
{
	// Token: 0x06003BC8 RID: 15304 RVA: 0x0017A327 File Offset: 0x00178727
	public HealResistanceData()
	{
	}

	// Token: 0x06003BC9 RID: 15305 RVA: 0x0017A32F File Offset: 0x0017872F
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.HealResistanceBoost;
	}

	// Token: 0x06003BCA RID: 15306 RVA: 0x0017A338 File Offset: 0x00178738
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.BoostRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003BCB RID: 15307 RVA: 0x0017A373 File Offset: 0x00178773
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x06003BCC RID: 15308 RVA: 0x0017A376 File Offset: 0x00178776
	public double GetEffectPowerValue()
	{
		return this.BoostRate;
	}

	// Token: 0x04002DE3 RID: 11747
	public double BoostRate;
}
