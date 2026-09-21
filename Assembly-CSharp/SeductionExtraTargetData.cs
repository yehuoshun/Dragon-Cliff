using System;

// Token: 0x02000872 RID: 2162
[Serializable]
public class SeductionExtraTargetData : ISpecialEffectDataLoad
{
	// Token: 0x06003DA4 RID: 15780 RVA: 0x0018114A File Offset: 0x0017F54A
	public SeductionExtraTargetData()
	{
	}

	// Token: 0x06003DA5 RID: 15781 RVA: 0x00181152 File Offset: 0x0017F552
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SeductionExtraTarget;
	}

	// Token: 0x06003DA6 RID: 15782 RVA: 0x0018115C File Offset: 0x0017F55C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003DA7 RID: 15783 RVA: 0x00181197 File Offset: 0x0017F597
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003DA8 RID: 15784 RVA: 0x0018119F File Offset: 0x0017F59F
	public double GetEffectPowerValue()
	{
		return this.Chance;
	}

	// Token: 0x04002EC5 RID: 11973
	public double Chance;

	// Token: 0x04002EC6 RID: 11974
	public bool IsStar;
}
