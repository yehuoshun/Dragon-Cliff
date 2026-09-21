using System;

// Token: 0x02000842 RID: 2114
[Serializable]
public class PoisonSeedEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003C8A RID: 15498 RVA: 0x0017B8E6 File Offset: 0x00179CE6
	public PoisonSeedEffectData()
	{
	}

	// Token: 0x06003C8B RID: 15499 RVA: 0x0017B8EE File Offset: 0x00179CEE
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.PoisonSeed;
	}

	// Token: 0x06003C8C RID: 15500 RVA: 0x0017B8F4 File Offset: 0x00179CF4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{resistancerate}", this.ResistanceDecayValuePerSecond.ToExpression()).Replace("{healrate}", this.HealDecayPerSecond.ToExpressionMultiply100()).Replace("{seconds}", this.StablizeSeconds.ToString()).Replace("{hits}", this.NumberOfSeedPerHit.ToString()).ToString();
		return description;
	}

	// Token: 0x06003C8D RID: 15501 RVA: 0x0017B97F File Offset: 0x00179D7F
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003C8E RID: 15502 RVA: 0x0017B988 File Offset: 0x00179D88
	public double GetEffectPowerValue()
	{
		return (1.0 + this.ResistanceDecayValuePerSecond) * (1.0 + this.HealDecayPerSecond) * (1.0 + (double)this.StablizeSeconds) * (1.0 + (double)this.NumberOfSeedPerHit);
	}

	// Token: 0x04002E49 RID: 11849
	public double ResistanceDecayValuePerSecond;

	// Token: 0x04002E4A RID: 11850
	public double HealDecayPerSecond;

	// Token: 0x04002E4B RID: 11851
	public int StablizeSeconds;

	// Token: 0x04002E4C RID: 11852
	public int NumberOfSeedPerHit;

	// Token: 0x04002E4D RID: 11853
	public bool IsStar;
}
