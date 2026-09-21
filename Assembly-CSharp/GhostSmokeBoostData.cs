using System;

// Token: 0x02000810 RID: 2064
[Serializable]
public class GhostSmokeBoostData : ISpecialEffectDataLoad
{
	// Token: 0x06003B96 RID: 15254 RVA: 0x00179DC2 File Offset: 0x001781C2
	public GhostSmokeBoostData()
	{
	}

	// Token: 0x06003B97 RID: 15255 RVA: 0x00179DCA File Offset: 0x001781CA
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.GhostSmokeBoost;
	}

	// Token: 0x06003B98 RID: 15256 RVA: 0x00179DD4 File Offset: 0x001781D4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003B99 RID: 15257 RVA: 0x00179E0F File Offset: 0x0017820F
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B9A RID: 15258 RVA: 0x00179E17 File Offset: 0x00178217
	public double GetEffectPowerValue()
	{
		return this.Rate;
	}

	// Token: 0x04002DBD RID: 11709
	public double Rate;

	// Token: 0x04002DBE RID: 11710
	public bool IsStar;
}
