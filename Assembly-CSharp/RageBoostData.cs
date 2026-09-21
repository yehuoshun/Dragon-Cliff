using System;

// Token: 0x0200084A RID: 2122
[Serializable]
public class RageBoostData : ISpecialEffectDataLoad
{
	// Token: 0x06003CB1 RID: 15537 RVA: 0x0017BE40 File Offset: 0x0017A240
	public RageBoostData()
	{
	}

	// Token: 0x06003CB2 RID: 15538 RVA: 0x0017BE48 File Offset: 0x0017A248
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.RageBoost;
	}

	// Token: 0x06003CB3 RID: 15539 RVA: 0x0017BE4C File Offset: 0x0017A24C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{value}", this.SuctionValue.ToExpression());
		return description;
	}

	// Token: 0x06003CB4 RID: 15540 RVA: 0x0017BE87 File Offset: 0x0017A287
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003CB5 RID: 15541 RVA: 0x0017BE8F File Offset: 0x0017A28F
	public double GetEffectPowerValue()
	{
		return this.SuctionValue;
	}

	// Token: 0x04002E64 RID: 11876
	public double SuctionValue;

	// Token: 0x04002E65 RID: 11877
	public bool IsStar;
}
