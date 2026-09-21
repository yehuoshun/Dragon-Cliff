using System;

// Token: 0x0200088B RID: 2187
[Serializable]
public class StrongManData : ISpecialEffectDataLoad
{
	// Token: 0x06003E1D RID: 15901 RVA: 0x00181D6E File Offset: 0x0018016E
	public StrongManData()
	{
	}

	// Token: 0x06003E1E RID: 15902 RVA: 0x00181D76 File Offset: 0x00180176
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.StrongMan;
	}

	// Token: 0x06003E1F RID: 15903 RVA: 0x00181D7C File Offset: 0x0018017C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003E20 RID: 15904 RVA: 0x00181DB7 File Offset: 0x001801B7
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E21 RID: 15905 RVA: 0x00181DBF File Offset: 0x001801BF
	public double GetEffectPowerValue()
	{
		return this.Rate;
	}

	// Token: 0x04002F0B RID: 12043
	public double Rate;

	// Token: 0x04002F0C RID: 12044
	public bool IsStar;
}
