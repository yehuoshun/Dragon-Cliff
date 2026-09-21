using System;

// Token: 0x0200081C RID: 2076
[Serializable]
public class HealingStrengthData : ISpecialEffectDataLoad
{
	// Token: 0x06003BCD RID: 15309 RVA: 0x0017A37E File Offset: 0x0017877E
	public HealingStrengthData()
	{
	}

	// Token: 0x06003BCE RID: 15310 RVA: 0x0017A386 File Offset: 0x00178786
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.HealingStrength;
	}

	// Token: 0x06003BCF RID: 15311 RVA: 0x0017A38C File Offset: 0x0017878C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.BoostRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003BD0 RID: 15312 RVA: 0x0017A3C7 File Offset: 0x001787C7
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003BD1 RID: 15313 RVA: 0x0017A3CF File Offset: 0x001787CF
	public double GetEffectPowerValue()
	{
		return this.BoostRate;
	}

	// Token: 0x04002DE4 RID: 11748
	public double BoostRate;

	// Token: 0x04002DE5 RID: 11749
	public bool IsStar;
}
