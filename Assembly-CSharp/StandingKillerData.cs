using System;

// Token: 0x02000883 RID: 2179
[Serializable]
public class StandingKillerData : ISpecialEffectDataLoad
{
	// Token: 0x06003DF5 RID: 15861 RVA: 0x001818EF File Offset: 0x0017FCEF
	public StandingKillerData()
	{
	}

	// Token: 0x06003DF6 RID: 15862 RVA: 0x001818F7 File Offset: 0x0017FCF7
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.StandingKiller;
	}

	// Token: 0x06003DF7 RID: 15863 RVA: 0x001818FC File Offset: 0x0017FCFC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.OutputIncrease.ToExpressionMultiply100()).Replace("{max}", 1.ToString());
		return description;
	}

	// Token: 0x06003DF8 RID: 15864 RVA: 0x00181950 File Offset: 0x0017FD50
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003DF9 RID: 15865 RVA: 0x00181958 File Offset: 0x0017FD58
	public double GetEffectPowerValue()
	{
		return this.OutputIncrease;
	}

	// Token: 0x04002EF2 RID: 12018
	public double OutputIncrease;

	// Token: 0x04002EF3 RID: 12019
	public bool IsStar;

	// Token: 0x04002EF4 RID: 12020
	public int MaxCounter;

	// Token: 0x04002EF5 RID: 12021
	[NonSerialized]
	public int Counter;
}
