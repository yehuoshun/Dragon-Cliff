using System;

// Token: 0x020007D7 RID: 2007
[Serializable]
public class DarknessData : ISpecialEffectDataLoad
{
	// Token: 0x06003A76 RID: 14966 RVA: 0x00177F8A File Offset: 0x0017638A
	public DarknessData()
	{
	}

	// Token: 0x06003A77 RID: 14967 RVA: 0x00177F92 File Offset: 0x00176392
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003A78 RID: 14968 RVA: 0x00177FB2 File Offset: 0x001763B2
	public double GetEffectPowerValue()
	{
		return this.MonsterDepression + this.HealDepression;
	}

	// Token: 0x06003A79 RID: 14969 RVA: 0x00177FC1 File Offset: 0x001763C1
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DarknessEffect;
	}

	// Token: 0x06003A7A RID: 14970 RVA: 0x00177FC8 File Offset: 0x001763C8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{outputdepression}", this.MonsterDepression.ToExpressionMultiply100()).Replace("{healdrop}", this.HealDepression.ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x04002D0F RID: 11535
	public double MonsterDepression;

	// Token: 0x04002D10 RID: 11536
	public double HealDepression;

	// Token: 0x04002D11 RID: 11537
	public bool? IsStarEf;
}
