using System;

// Token: 0x02000830 RID: 2096
[Serializable]
public class MagicBreadEffectdata : ISpecialEffectDataLoad
{
	// Token: 0x06003C2E RID: 15406 RVA: 0x0017AC5F File Offset: 0x0017905F
	public MagicBreadEffectdata()
	{
	}

	// Token: 0x06003C2F RID: 15407 RVA: 0x0017AC67 File Offset: 0x00179067
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003C30 RID: 15408 RVA: 0x0017AC87 File Offset: 0x00179087
	public double GetEffectPowerValue()
	{
		return (1.0 + this.RageOnStart) * (1.0 + this.CoolingDownReductionOnStart);
	}

	// Token: 0x06003C31 RID: 15409 RVA: 0x0017ACAA File Offset: 0x001790AA
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.MagicBreadEffect;
	}

	// Token: 0x06003C32 RID: 15410 RVA: 0x0017ACB0 File Offset: 0x001790B0
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{ragestart}", this.RageOnStart.ToExpression()).Replace("{cd}", this.CoolingDownReductionOnStart.DoubleToStringDecimal());
		return description;
	}

	// Token: 0x04002E1A RID: 11802
	public double RageOnStart;

	// Token: 0x04002E1B RID: 11803
	public double CoolingDownReductionOnStart;

	// Token: 0x04002E1C RID: 11804
	public bool? IsStarEf;
}
