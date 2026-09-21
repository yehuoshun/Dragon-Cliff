using System;

// Token: 0x02000834 RID: 2100
[Serializable]
public class NegativeEffectBoostData : ISpecialEffectDataLoad
{
	// Token: 0x06003C42 RID: 15426 RVA: 0x0017AE1B File Offset: 0x0017921B
	public NegativeEffectBoostData()
	{
	}

	// Token: 0x06003C43 RID: 15427 RVA: 0x0017AE23 File Offset: 0x00179223
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.NegativeEffectBoost;
	}

	// Token: 0x06003C44 RID: 15428 RVA: 0x0017AE28 File Offset: 0x00179228
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003C45 RID: 15429 RVA: 0x0017AE63 File Offset: 0x00179263
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003C46 RID: 15430 RVA: 0x0017AE6B File Offset: 0x0017926B
	public double GetEffectPowerValue()
	{
		return this.Chance;
	}

	// Token: 0x04002E25 RID: 11813
	public double Chance;

	// Token: 0x04002E26 RID: 11814
	public bool IsStar;
}
