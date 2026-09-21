using System;

// Token: 0x020007B2 RID: 1970
[Serializable]
public class ArmorOfWindAttributeEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x060039B5 RID: 14773 RVA: 0x00176AF2 File Offset: 0x00174EF2
	public ArmorOfWindAttributeEnhancementData()
	{
	}

	// Token: 0x060039B6 RID: 14774 RVA: 0x00176AFA File Offset: 0x00174EFA
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ArmorOfWindAttributeEnhancement;
	}

	// Token: 0x060039B7 RID: 14775 RVA: 0x00176B04 File Offset: 0x00174F04
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{type}", this.Type.GetDescription().Title).Replace("{value}", (this.ModificationType != ModificationType.Addition || this.Type.IsPercentageValue()) ? (this.Value.ToExpressionMultiply100() + "%") : this.Value.ToExpression());
		return description;
	}

	// Token: 0x060039B8 RID: 14776 RVA: 0x00176B8F File Offset: 0x00174F8F
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x060039B9 RID: 14777 RVA: 0x00176B97 File Offset: 0x00174F97
	public double GetEffectPowerValue()
	{
		return this.Value;
	}

	// Token: 0x04002CA2 RID: 11426
	public AttributeType Type;

	// Token: 0x04002CA3 RID: 11427
	public double Value;

	// Token: 0x04002CA4 RID: 11428
	public ModificationType ModificationType;

	// Token: 0x04002CA5 RID: 11429
	public bool IsStar;
}
