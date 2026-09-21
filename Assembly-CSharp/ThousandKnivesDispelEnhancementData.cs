using System;

// Token: 0x0200089B RID: 2203
[Serializable]
public class ThousandKnivesDispelEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003E6D RID: 15981 RVA: 0x0018247A File Offset: 0x0018087A
	public ThousandKnivesDispelEnhancementData()
	{
	}

	// Token: 0x06003E6E RID: 15982 RVA: 0x00182482 File Offset: 0x00180882
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ThousandKnivesDispelEnhancement;
	}

	// Token: 0x06003E6F RID: 15983 RVA: 0x0018248C File Offset: 0x0018088C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.NumberOfDispels.ToString()).Replace("{rate}", this.DamageReductionRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003E70 RID: 15984 RVA: 0x001824E2 File Offset: 0x001808E2
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E71 RID: 15985 RVA: 0x001824EA File Offset: 0x001808EA
	public double GetEffectPowerValue()
	{
		return (1.0 + (double)this.NumberOfDispels) * (1.0 + this.DamageReductionRate);
	}

	// Token: 0x04002F32 RID: 12082
	public int NumberOfDispels;

	// Token: 0x04002F33 RID: 12083
	public bool IsStar;

	// Token: 0x04002F34 RID: 12084
	public double DamageReductionRate;
}
