using System;

// Token: 0x0200084D RID: 2125
[Serializable]
public class RedBladeData : ISpecialEffectDataLoad
{
	// Token: 0x06003CC0 RID: 15552 RVA: 0x0017BF77 File Offset: 0x0017A377
	public RedBladeData()
	{
	}

	// Token: 0x06003CC1 RID: 15553 RVA: 0x0017BF7F File Offset: 0x0017A37F
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.RedBlade;
	}

	// Token: 0x06003CC2 RID: 15554 RVA: 0x0017BF88 File Offset: 0x0017A388
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.BoostRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003CC3 RID: 15555 RVA: 0x0017BFC3 File Offset: 0x0017A3C3
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003CC4 RID: 15556 RVA: 0x0017BFCB File Offset: 0x0017A3CB
	public double GetEffectPowerValue()
	{
		return this.BoostRate;
	}

	// Token: 0x04002E69 RID: 11881
	public double BoostRate;

	// Token: 0x04002E6A RID: 11882
	public bool IsStar;
}
