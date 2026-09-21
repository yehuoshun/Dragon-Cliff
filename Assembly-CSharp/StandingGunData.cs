using System;

// Token: 0x02000882 RID: 2178
[Serializable]
public class StandingGunData : ISpecialEffectDataLoad
{
	// Token: 0x06003DF0 RID: 15856 RVA: 0x00181867 File Offset: 0x0017FC67
	public StandingGunData()
	{
	}

	// Token: 0x06003DF1 RID: 15857 RVA: 0x0018186F File Offset: 0x0017FC6F
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.StandingGun;
	}

	// Token: 0x06003DF2 RID: 15858 RVA: 0x00181874 File Offset: 0x0017FC74
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{outputrate}", this.OutputRate.ToExpressionMultiply100()).Replace("{resistancerate}", this.ResistanceBoost.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003DF3 RID: 15859 RVA: 0x001818C4 File Offset: 0x0017FCC4
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003DF4 RID: 15860 RVA: 0x001818CC File Offset: 0x0017FCCC
	public double GetEffectPowerValue()
	{
		return (1.0 + this.OutputRate) * (1.0 + this.ResistanceBoost);
	}

	// Token: 0x04002EEF RID: 12015
	public double OutputRate;

	// Token: 0x04002EF0 RID: 12016
	public double ResistanceBoost;

	// Token: 0x04002EF1 RID: 12017
	public bool IsStar;
}
