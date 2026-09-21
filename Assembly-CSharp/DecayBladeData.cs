using System;

// Token: 0x020007DC RID: 2012
[Serializable]
public class DecayBladeData : ISpecialEffectDataLoad
{
	// Token: 0x06003A8F RID: 14991 RVA: 0x00178309 File Offset: 0x00176709
	public DecayBladeData()
	{
	}

	// Token: 0x06003A90 RID: 14992 RVA: 0x00178311 File Offset: 0x00176711
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DecayBlade;
	}

	// Token: 0x06003A91 RID: 14993 RVA: 0x00178318 File Offset: 0x00176718
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{resistancerate}", this.ResistanceReductionValue.ToExpression()).Replace("{agilityrate}", this.AgilityReductionValue.ToExpression());
		return description;
	}

	// Token: 0x06003A92 RID: 14994 RVA: 0x00178368 File Offset: 0x00176768
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003A93 RID: 14995 RVA: 0x00178370 File Offset: 0x00176770
	public double GetEffectPowerValue()
	{
		return (1.0 + this.ResistanceReductionValue) * (1.0 + this.AgilityReductionValue);
	}

	// Token: 0x04002D28 RID: 11560
	public double ResistanceReductionValue;

	// Token: 0x04002D29 RID: 11561
	public double AgilityReductionValue;

	// Token: 0x04002D2A RID: 11562
	public bool IsStar;
}
