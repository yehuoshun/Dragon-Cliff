using System;

// Token: 0x020007C7 RID: 1991
[Serializable]
public class ClearWaterDispelShieldData : ISpecialEffectDataLoad
{
	// Token: 0x06003A25 RID: 14885 RVA: 0x0017781F File Offset: 0x00175C1F
	public ClearWaterDispelShieldData()
	{
	}

	// Token: 0x06003A26 RID: 14886 RVA: 0x00177827 File Offset: 0x00175C27
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ClearWaterDispelShield;
	}

	// Token: 0x06003A27 RID: 14887 RVA: 0x0017782C File Offset: 0x00175C2C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.HealRate.ToExpressionMultiply100()).Replace("{seconds}", this.ShieldSeconds.ToString());
		return description;
	}

	// Token: 0x06003A28 RID: 14888 RVA: 0x00177882 File Offset: 0x00175C82
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003A29 RID: 14889 RVA: 0x0017788A File Offset: 0x00175C8A
	public double GetEffectPowerValue()
	{
		return (1.0 + this.HealRate) * (1.0 + (double)this.ShieldSeconds);
	}

	// Token: 0x04002CE7 RID: 11495
	public double HealRate;

	// Token: 0x04002CE8 RID: 11496
	public int ShieldSeconds;

	// Token: 0x04002CE9 RID: 11497
	public bool IsStar;
}
