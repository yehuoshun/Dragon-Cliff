using System;

// Token: 0x020007DA RID: 2010
[Serializable]
public class DeathBoostData : ISpecialEffectDataLoad
{
	// Token: 0x06003A85 RID: 14981 RVA: 0x00178179 File Offset: 0x00176579
	public DeathBoostData()
	{
	}

	// Token: 0x06003A86 RID: 14982 RVA: 0x00178181 File Offset: 0x00176581
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DeathBoost;
	}

	// Token: 0x06003A87 RID: 14983 RVA: 0x00178188 File Offset: 0x00176588
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.NumberOfLayersPerDeath.ToString()).Replace("{rate}", this.DamageRatePerLayer.ToExpressionMultiply100()).Replace("{revive}", this.ReviveRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003A88 RID: 14984 RVA: 0x001781F3 File Offset: 0x001765F3
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003A89 RID: 14985 RVA: 0x001781FB File Offset: 0x001765FB
	public double GetEffectPowerValue()
	{
		return (1.0 + (double)this.NumberOfLayersPerDeath) * (1.0 + this.DamageRatePerLayer) * (1.0 + this.ReviveRate);
	}

	// Token: 0x04002D1B RID: 11547
	public double DamageRatePerLayer;

	// Token: 0x04002D1C RID: 11548
	public bool IsStar;

	// Token: 0x04002D1D RID: 11549
	public int NumberOfLayersPerDeath;

	// Token: 0x04002D1E RID: 11550
	public double ReviveRate;
}
