using System;

// Token: 0x0200083B RID: 2107
[Serializable]
public class PhenixData : ISpecialEffectDataLoad
{
	// Token: 0x06003C66 RID: 15462 RVA: 0x0017B1AF File Offset: 0x001795AF
	public PhenixData()
	{
	}

	// Token: 0x06003C67 RID: 15463 RVA: 0x0017B1B7 File Offset: 0x001795B7
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003C68 RID: 15464 RVA: 0x0017B1D7 File Offset: 0x001795D7
	public double GetEffectPowerValue()
	{
		return (1.0 + this.ReburnChance) * (1.0 + this.ReburnLifeRecoveryRate);
	}

	// Token: 0x06003C69 RID: 15465 RVA: 0x0017B1FA File Offset: 0x001795FA
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Phenix;
	}

	// Token: 0x06003C6A RID: 15466 RVA: 0x0017B200 File Offset: 0x00179600
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{chance}", this.ReburnChance.ToExpressionMultiply100()).Replace("{heal}", this.ReburnLifeRecoveryRate.ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x04002E35 RID: 11829
	public double ReburnChance;

	// Token: 0x04002E36 RID: 11830
	public double ReburnLifeRecoveryRate;

	// Token: 0x04002E37 RID: 11831
	public bool? IsStarEf;
}
