using System;

// Token: 0x020007D4 RID: 2004
[Serializable]
public class DamageAttributeReductionByValueData : ISpecialEffectDataLoad
{
	// Token: 0x06003A66 RID: 14950 RVA: 0x00177DF3 File Offset: 0x001761F3
	public DamageAttributeReductionByValueData()
	{
	}

	// Token: 0x06003A67 RID: 14951 RVA: 0x00177DFB File Offset: 0x001761FB
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DamageAttributeReductionByValue;
	}

	// Token: 0x06003A68 RID: 14952 RVA: 0x00177E04 File Offset: 0x00176204
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{value}", this.ReductionRate.ToExpressionMultiply100() + "%").Replace("{type}", this.AttributeType.GetDescription().Title);
		return description;
	}

	// Token: 0x06003A69 RID: 14953 RVA: 0x00177E63 File Offset: 0x00176263
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x06003A6A RID: 14954 RVA: 0x00177E66 File Offset: 0x00176266
	public double GetEffectPowerValue()
	{
		return this.ReductionRate;
	}

	// Token: 0x04002D08 RID: 11528
	public double ReductionRate;

	// Token: 0x04002D09 RID: 11529
	public AttributeType AttributeType;
}
