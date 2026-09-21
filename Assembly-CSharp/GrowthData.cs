using System;

// Token: 0x02000815 RID: 2069
[Serializable]
public class GrowthData : ISpecialEffectDataLoad
{
	// Token: 0x06003BAF RID: 15279 RVA: 0x00179FD5 File Offset: 0x001783D5
	public GrowthData()
	{
	}

	// Token: 0x06003BB0 RID: 15280 RVA: 0x00179FDD File Offset: 0x001783DD
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Growth;
	}

	// Token: 0x06003BB1 RID: 15281 RVA: 0x00179FE0 File Offset: 0x001783E0
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003BB2 RID: 15282 RVA: 0x0017A000 File Offset: 0x00178400
	public double GetEffectPowerValue()
	{
		return this.MaxGrowthValue;
	}

	// Token: 0x06003BB3 RID: 15283 RVA: 0x0017A008 File Offset: 0x00178408
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		Description description2 = this.Condition.GetDescription();
		description2.Details1 = description2.Details1.ReplaceToBuilder("{value}", this.ConditionValue.ToExpression()).ToString();
		description.Details1 = description.Details1.ReplaceToBuilder("{condition}", description2.Details1).Replace("{growthrate}", (!this.GrowthAttributeType.IsPercentageValue()) ? this.GrowthRate.DoubleToStringDecimal() : (this.GrowthRate.ToExpressionMultiply100() + "%")).Replace("{currentgrowthvalue}", (!this.GrowthAttributeType.IsPercentageValue()) ? this.CurrentGrowthValue.DoubleToStringDecimal() : (this.CurrentGrowthValue.ToExpressionMultiply100() + "%")).Replace("{maxgrowthvalue}", (!this.GrowthAttributeType.IsPercentageValue()) ? this.MaxGrowthValue.DoubleToStringDecimal() : (this.MaxGrowthValue.ToExpressionMultiply100() + "%")).Replace("{attributetype}", this.GrowthAttributeType.GetDescription().Title).ToString();
		return description;
	}

	// Token: 0x04002DC9 RID: 11721
	public string Id;

	// Token: 0x04002DCA RID: 11722
	public AttributeType GrowthAttributeType;

	// Token: 0x04002DCB RID: 11723
	public double MaxGrowthValue;

	// Token: 0x04002DCC RID: 11724
	public double CurrentGrowthValue;

	// Token: 0x04002DCD RID: 11725
	public double GrowthRate;

	// Token: 0x04002DCE RID: 11726
	public double ConditionValue;

	// Token: 0x04002DCF RID: 11727
	public GrowthConditionType Condition;

	// Token: 0x04002DD0 RID: 11728
	public bool? IsStarEf;
}
