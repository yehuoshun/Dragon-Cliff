using System;

// Token: 0x0200082C RID: 2092
[Serializable]
public class LifePotionPercentageData : ISpecialEffectDataLoad
{
	// Token: 0x06003C1A RID: 15386 RVA: 0x0017AAED File Offset: 0x00178EED
	public LifePotionPercentageData()
	{
	}

	// Token: 0x06003C1B RID: 15387 RVA: 0x0017AAF5 File Offset: 0x00178EF5
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.LifePotionPercentage;
	}

	// Token: 0x06003C1C RID: 15388 RVA: 0x0017AAFC File Offset: 0x00178EFC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003C1D RID: 15389 RVA: 0x0017AB37 File Offset: 0x00178F37
	public bool IsStarEffect()
	{
		return this.IsStarEf;
	}

	// Token: 0x06003C1E RID: 15390 RVA: 0x0017AB3F File Offset: 0x00178F3F
	public double GetEffectPowerValue()
	{
		return this.Rate;
	}

	// Token: 0x04002E11 RID: 11793
	public double Rate;

	// Token: 0x04002E12 RID: 11794
	public bool IsPlayerUnit;

	// Token: 0x04002E13 RID: 11795
	public bool IsStarEf;
}
