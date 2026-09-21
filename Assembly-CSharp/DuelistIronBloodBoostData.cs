using System;

// Token: 0x020007EB RID: 2027
[Serializable]
public class DuelistIronBloodBoostData : ISpecialEffectDataLoad
{
	// Token: 0x06003ADB RID: 15067 RVA: 0x00178B72 File Offset: 0x00176F72
	public DuelistIronBloodBoostData()
	{
	}

	// Token: 0x06003ADC RID: 15068 RVA: 0x00178B7A File Offset: 0x00176F7A
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DuelistIronBloodBoost;
	}

	// Token: 0x06003ADD RID: 15069 RVA: 0x00178B84 File Offset: 0x00176F84
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{resilience}", this.ResilienceRate.ToExpressionMultiply100()).Replace("{reflection}", this.DamageReflectionRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003ADE RID: 15070 RVA: 0x00178BD4 File Offset: 0x00176FD4
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003ADF RID: 15071 RVA: 0x00178BDC File Offset: 0x00176FDC
	public double GetEffectPowerValue()
	{
		return (1.0 + this.ResilienceRate) * (1.0 + this.DamageReflectionRate);
	}

	// Token: 0x04002D69 RID: 11625
	public double ResilienceRate;

	// Token: 0x04002D6A RID: 11626
	public double DamageReflectionRate;

	// Token: 0x04002D6B RID: 11627
	public bool IsStar;
}
