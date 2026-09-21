using System;

// Token: 0x020007B7 RID: 1975
[Serializable]
public class AttributeDestroyData : ISpecialEffectDataLoad
{
	// Token: 0x060039D3 RID: 14803 RVA: 0x00176F65 File Offset: 0x00175365
	public AttributeDestroyData()
	{
	}

	// Token: 0x060039D4 RID: 14804 RVA: 0x00176F6D File Offset: 0x0017536D
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x060039D5 RID: 14805 RVA: 0x00176F8D File Offset: 0x0017538D
	public double GetEffectPowerValue()
	{
		return this.Chance;
	}

	// Token: 0x060039D6 RID: 14806 RVA: 0x00176F95 File Offset: 0x00175395
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.AttributeDestroy;
	}

	// Token: 0x060039D7 RID: 14807 RVA: 0x00176F98 File Offset: 0x00175398
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{attributetype}", this.ReplaceAttribute.GetDescription().Title).Replace("{value}", (!this.ReplaceAttribute.IsPercentageValue()) ? this.ReplacementValue.ToExpression() : (this.ReplacementValue.ToExpressionMultiply100() + "%")).ToString();
		return description;
	}

	// Token: 0x04002CB5 RID: 11445
	public double ReplacementValue;

	// Token: 0x04002CB6 RID: 11446
	public AttributeType ReplaceAttribute;

	// Token: 0x04002CB7 RID: 11447
	public double Chance;

	// Token: 0x04002CB8 RID: 11448
	public bool? IsStarEf;
}
