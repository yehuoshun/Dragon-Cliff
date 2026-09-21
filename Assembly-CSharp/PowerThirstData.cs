using System;

// Token: 0x02000846 RID: 2118
[Serializable]
public class PowerThirstData : ISpecialEffectDataLoad
{
	// Token: 0x06003C9D RID: 15517 RVA: 0x0017BC58 File Offset: 0x0017A058
	public PowerThirstData()
	{
	}

	// Token: 0x06003C9E RID: 15518 RVA: 0x0017BC60 File Offset: 0x0017A060
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.PowerThirst;
	}

	// Token: 0x06003C9F RID: 15519 RVA: 0x0017BC64 File Offset: 0x0017A064
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.SuctionRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003CA0 RID: 15520 RVA: 0x0017BC9F File Offset: 0x0017A09F
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003CA1 RID: 15521 RVA: 0x0017BCA7 File Offset: 0x0017A0A7
	public double GetEffectPowerValue()
	{
		return this.SuctionRate;
	}

	// Token: 0x04002E5A RID: 11866
	public double SuctionRate;

	// Token: 0x04002E5B RID: 11867
	public bool IsStar;
}
