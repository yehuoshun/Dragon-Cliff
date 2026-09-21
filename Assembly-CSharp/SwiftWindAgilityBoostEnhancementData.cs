using System;

// Token: 0x02000890 RID: 2192
[Serializable]
public class SwiftWindAgilityBoostEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003E36 RID: 15926 RVA: 0x00181FF6 File Offset: 0x001803F6
	public SwiftWindAgilityBoostEnhancementData()
	{
	}

	// Token: 0x06003E37 RID: 15927 RVA: 0x00181FFE File Offset: 0x001803FE
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SwiftWindAgilityBoostEnhancement;
	}

	// Token: 0x06003E38 RID: 15928 RVA: 0x00182008 File Offset: 0x00180408
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.AgilityBoostRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003E39 RID: 15929 RVA: 0x00182043 File Offset: 0x00180443
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E3A RID: 15930 RVA: 0x0018204B File Offset: 0x0018044B
	public double GetEffectPowerValue()
	{
		return this.AgilityBoostRate;
	}

	// Token: 0x04002F1B RID: 12059
	public double AgilityBoostRate;

	// Token: 0x04002F1C RID: 12060
	public bool IsStar;
}
