using System;

// Token: 0x02000839 RID: 2105
[Serializable]
public class OutputResistanceBoostData : ISpecialEffectDataLoad
{
	// Token: 0x06003C5C RID: 15452 RVA: 0x0017B0FD File Offset: 0x001794FD
	public OutputResistanceBoostData()
	{
	}

	// Token: 0x06003C5D RID: 15453 RVA: 0x0017B105 File Offset: 0x00179505
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.OutputResistanceBoost;
	}

	// Token: 0x06003C5E RID: 15454 RVA: 0x0017B10C File Offset: 0x0017950C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.BoostRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003C5F RID: 15455 RVA: 0x0017B147 File Offset: 0x00179547
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003C60 RID: 15456 RVA: 0x0017B14F File Offset: 0x0017954F
	public double GetEffectPowerValue()
	{
		return this.BoostRate;
	}

	// Token: 0x04002E31 RID: 11825
	public double BoostRate;

	// Token: 0x04002E32 RID: 11826
	public bool IsStar;
}
