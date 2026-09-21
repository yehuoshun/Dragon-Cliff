using System;

// Token: 0x020007B1 RID: 1969
[Serializable]
public class AnnihilationData : ISpecialEffectDataLoad
{
	// Token: 0x060039B0 RID: 14768 RVA: 0x00176A6B File Offset: 0x00174E6B
	public AnnihilationData()
	{
	}

	// Token: 0x060039B1 RID: 14769 RVA: 0x00176A73 File Offset: 0x00174E73
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Annihilation;
	}

	// Token: 0x060039B2 RID: 14770 RVA: 0x00176A7C File Offset: 0x00174E7C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{effectrate}", this.EffectResistanceReductionRate.ToExpressionMultiply100()).Replace("{output}", this.OutputReductionRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x060039B3 RID: 14771 RVA: 0x00176ACC File Offset: 0x00174ECC
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x060039B4 RID: 14772 RVA: 0x00176ACF File Offset: 0x00174ECF
	public double GetEffectPowerValue()
	{
		return (1.0 + this.EffectResistanceReductionRate) * (1.0 + this.OutputReductionRate);
	}

	// Token: 0x04002CA0 RID: 11424
	public double EffectResistanceReductionRate;

	// Token: 0x04002CA1 RID: 11425
	public double OutputReductionRate;
}
