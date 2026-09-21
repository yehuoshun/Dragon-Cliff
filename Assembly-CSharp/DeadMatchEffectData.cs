using System;

// Token: 0x020007D9 RID: 2009
[Serializable]
public class DeadMatchEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003A80 RID: 14976 RVA: 0x001780D3 File Offset: 0x001764D3
	public DeadMatchEffectData()
	{
	}

	// Token: 0x06003A81 RID: 14977 RVA: 0x001780DB File Offset: 0x001764DB
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003A82 RID: 14978 RVA: 0x001780FB File Offset: 0x001764FB
	public double GetEffectPowerValue()
	{
		return (1.0 + this.KillLifePercentage) * (1.0 + this.KillPossibility);
	}

	// Token: 0x06003A83 RID: 14979 RVA: 0x0017811E File Offset: 0x0017651E
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DeadMatch;
	}

	// Token: 0x06003A84 RID: 14980 RVA: 0x00178124 File Offset: 0x00176524
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{chance}", this.KillPossibility.ToExpressionMultiply100()).Replace("{percentage}", this.KillLifePercentage.ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x04002D18 RID: 11544
	public double KillLifePercentage;

	// Token: 0x04002D19 RID: 11545
	public double KillPossibility;

	// Token: 0x04002D1A RID: 11546
	public bool? IsStarEf;
}
