using System;

// Token: 0x0200088F RID: 2191
[Serializable]
public class SwallowData : ISpecialEffectDataLoad
{
	// Token: 0x06003E31 RID: 15921 RVA: 0x00181F62 File Offset: 0x00180362
	public SwallowData()
	{
	}

	// Token: 0x06003E32 RID: 15922 RVA: 0x00181F6A File Offset: 0x0018036A
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Swallow;
	}

	// Token: 0x06003E33 RID: 15923 RVA: 0x00181F70 File Offset: 0x00180370
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{rate}", this.DamagePercentage.ToExpressionMultiply100()).Replace("{hits}", this.SwallowCounts.ToString()).Replace("{turns}", this.LastingTurns.ToString()).ToString();
		return description;
	}

	// Token: 0x06003E34 RID: 15924 RVA: 0x00181FE6 File Offset: 0x001803E6
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E35 RID: 15925 RVA: 0x00181FEE File Offset: 0x001803EE
	public double GetEffectPowerValue()
	{
		return this.DamagePercentage;
	}

	// Token: 0x04002F17 RID: 12055
	public int SwallowCounts;

	// Token: 0x04002F18 RID: 12056
	public double DamagePercentage;

	// Token: 0x04002F19 RID: 12057
	public int LastingTurns;

	// Token: 0x04002F1A RID: 12058
	public bool IsStar;
}
