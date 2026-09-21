using System;

// Token: 0x02000847 RID: 2119
[Serializable]
public class ProtectorData : ISpecialEffectDataLoad
{
	// Token: 0x06003CA2 RID: 15522 RVA: 0x0017BCAF File Offset: 0x0017A0AF
	public ProtectorData()
	{
	}

	// Token: 0x06003CA3 RID: 15523 RVA: 0x0017BCB7 File Offset: 0x0017A0B7
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Protector;
	}

	// Token: 0x06003CA4 RID: 15524 RVA: 0x0017BCC0 File Offset: 0x0017A0C0
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{reduction}", this.DamageReductionRate.ToExpressionMultiply100()).Replace("{damagerate}", this.DamageReceivedRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003CA5 RID: 15525 RVA: 0x0017BD10 File Offset: 0x0017A110
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003CA6 RID: 15526 RVA: 0x0017BD18 File Offset: 0x0017A118
	public double GetEffectPowerValue()
	{
		return (1.0 + this.DamageReceivedRate) * (1.0 + this.DamageReductionRate);
	}

	// Token: 0x04002E5C RID: 11868
	public double DamageReductionRate;

	// Token: 0x04002E5D RID: 11869
	public double DamageReceivedRate;

	// Token: 0x04002E5E RID: 11870
	public bool IsStar;
}
