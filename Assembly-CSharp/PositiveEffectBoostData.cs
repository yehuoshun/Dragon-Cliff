using System;

// Token: 0x02000843 RID: 2115
[Serializable]
public class PositiveEffectBoostData : ISpecialEffectDataLoad
{
	// Token: 0x06003C8F RID: 15503 RVA: 0x0017B9DA File Offset: 0x00179DDA
	public PositiveEffectBoostData()
	{
	}

	// Token: 0x06003C90 RID: 15504 RVA: 0x0017B9E2 File Offset: 0x00179DE2
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.PositiveEffectBoost;
	}

	// Token: 0x06003C91 RID: 15505 RVA: 0x0017B9E8 File Offset: 0x00179DE8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003C92 RID: 15506 RVA: 0x0017BA23 File Offset: 0x00179E23
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003C93 RID: 15507 RVA: 0x0017BA2B File Offset: 0x00179E2B
	public double GetEffectPowerValue()
	{
		return this.Chance;
	}

	// Token: 0x04002E4E RID: 11854
	public double Chance;

	// Token: 0x04002E4F RID: 11855
	public bool IsStar;
}
