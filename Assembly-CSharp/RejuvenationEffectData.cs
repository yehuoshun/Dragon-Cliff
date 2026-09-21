using System;

// Token: 0x02000850 RID: 2128
[Serializable]
public class RejuvenationEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003CCF RID: 15567 RVA: 0x0017C0B2 File Offset: 0x0017A4B2
	public RejuvenationEffectData()
	{
	}

	// Token: 0x06003CD0 RID: 15568 RVA: 0x0017C0BA File Offset: 0x0017A4BA
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003CD1 RID: 15569 RVA: 0x0017C0DA File Offset: 0x0017A4DA
	public double GetEffectPowerValue()
	{
		return this.Rate;
	}

	// Token: 0x06003CD2 RID: 15570 RVA: 0x0017C0E2 File Offset: 0x0017A4E2
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Rejuvenation;
	}

	// Token: 0x06003CD3 RID: 15571 RVA: 0x0017C0E8 File Offset: 0x0017A4E8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x04002E6F RID: 11887
	public double Rate;

	// Token: 0x04002E70 RID: 11888
	public bool? IsStarEf;
}
