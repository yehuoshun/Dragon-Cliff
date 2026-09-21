using System;

// Token: 0x020007B6 RID: 1974
[Serializable]
public class AttributeDepressionData : ISpecialEffectDataLoad
{
	// Token: 0x060039CE RID: 14798 RVA: 0x00176EF0 File Offset: 0x001752F0
	public AttributeDepressionData()
	{
	}

	// Token: 0x060039CF RID: 14799 RVA: 0x00176EF8 File Offset: 0x001752F8
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.AttributeDepression;
	}

	// Token: 0x060039D0 RID: 14800 RVA: 0x00176F00 File Offset: 0x00175300
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{type}", this.Type.GetDescription().Title).Replace("{rate}", this.ReductionRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x060039D1 RID: 14801 RVA: 0x00176F55 File Offset: 0x00175355
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x060039D2 RID: 14802 RVA: 0x00176F5D File Offset: 0x0017535D
	public double GetEffectPowerValue()
	{
		return this.ReductionRate;
	}

	// Token: 0x04002CB2 RID: 11442
	public double ReductionRate;

	// Token: 0x04002CB3 RID: 11443
	public AttributeType Type;

	// Token: 0x04002CB4 RID: 11444
	public bool IsStar;
}
