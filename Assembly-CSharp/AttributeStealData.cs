using System;

// Token: 0x020007B8 RID: 1976
[Serializable]
public class AttributeStealData : ISpecialEffectDataLoad
{
	// Token: 0x060039D8 RID: 14808 RVA: 0x00177031 File Offset: 0x00175431
	public AttributeStealData()
	{
	}

	// Token: 0x060039D9 RID: 14809 RVA: 0x00177039 File Offset: 0x00175439
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x060039DA RID: 14810 RVA: 0x00177059 File Offset: 0x00175459
	public double GetEffectPowerValue()
	{
		return this.MaximumStolenValue;
	}

	// Token: 0x060039DB RID: 14811 RVA: 0x00177061 File Offset: 0x00175461
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.AttributeStealing;
	}

	// Token: 0x060039DC RID: 14812 RVA: 0x00177064 File Offset: 0x00175464
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{attributetype}", this.StealAttributeType.GetDescription().Title).Replace("{percentage}", this.SteamPercentage.ToExpressionMultiply100()).Replace("{max}", (!this.StealAttributeType.IsPercentageValue()) ? this.MaximumStolenValue.ToExpression() : this.MaximumStolenValue.ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x04002CB9 RID: 11449
	public AttributeType StealAttributeType;

	// Token: 0x04002CBA RID: 11450
	public double SteamPercentage;

	// Token: 0x04002CBB RID: 11451
	public double MaximumStolenValue;

	// Token: 0x04002CBC RID: 11452
	public string Key;

	// Token: 0x04002CBD RID: 11453
	public bool? IsStarEf;
}
