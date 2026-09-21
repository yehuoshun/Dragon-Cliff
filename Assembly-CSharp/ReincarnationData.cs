using System;

// Token: 0x0200084F RID: 2127
[Serializable]
public class ReincarnationData : ISpecialEffectDataLoad
{
	// Token: 0x06003CCA RID: 15562 RVA: 0x0017C02B File Offset: 0x0017A42B
	public ReincarnationData()
	{
	}

	// Token: 0x06003CCB RID: 15563 RVA: 0x0017C033 File Offset: 0x0017A433
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Reincarnation;
	}

	// Token: 0x06003CCC RID: 15564 RVA: 0x0017C03C File Offset: 0x0017A43C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{healrate}", this.HealRate.ToExpressionMultiply100()).Replace("{damagerate}", this.DamageSuctionRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003CCD RID: 15565 RVA: 0x0017C08C File Offset: 0x0017A48C
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x06003CCE RID: 15566 RVA: 0x0017C08F File Offset: 0x0017A48F
	public double GetEffectPowerValue()
	{
		return (1.0 + this.HealRate) * (1.0 + this.DamageSuctionRate);
	}

	// Token: 0x04002E6D RID: 11885
	public double HealRate;

	// Token: 0x04002E6E RID: 11886
	public double DamageSuctionRate;
}
