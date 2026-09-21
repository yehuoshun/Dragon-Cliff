using System;

// Token: 0x0200082A RID: 2090
[Serializable]
public class LifeGenData : ISpecialEffectDataLoad
{
	// Token: 0x06003C10 RID: 15376 RVA: 0x0017AA07 File Offset: 0x00178E07
	public LifeGenData()
	{
	}

	// Token: 0x06003C11 RID: 15377 RVA: 0x0017AA0F File Offset: 0x00178E0F
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003C12 RID: 15378 RVA: 0x0017AA2F File Offset: 0x00178E2F
	public double GetEffectPowerValue()
	{
		return this.HealRate;
	}

	// Token: 0x06003C13 RID: 15379 RVA: 0x0017AA37 File Offset: 0x00178E37
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.LifeGen;
	}

	// Token: 0x06003C14 RID: 15380 RVA: 0x0017AA3C File Offset: 0x00178E3C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.HealRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x04002E0C RID: 11788
	public double HealRate;

	// Token: 0x04002E0D RID: 11789
	public bool? IsStarEf;
}
