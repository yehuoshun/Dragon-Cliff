using System;

// Token: 0x020007D8 RID: 2008
[Serializable]
public class DarknessRevengeData : ISpecialEffectDataLoad
{
	// Token: 0x06003A7B RID: 14971 RVA: 0x0017801D File Offset: 0x0017641D
	public DarknessRevengeData()
	{
	}

	// Token: 0x06003A7C RID: 14972 RVA: 0x00178025 File Offset: 0x00176425
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003A7D RID: 14973 RVA: 0x00178045 File Offset: 0x00176445
	public double GetEffectPowerValue()
	{
		return this.DarkDamageRatio;
	}

	// Token: 0x06003A7E RID: 14974 RVA: 0x0017804D File Offset: 0x0017644D
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DarknessRevengeEffect;
	}

	// Token: 0x06003A7F RID: 14975 RVA: 0x00178054 File Offset: 0x00176454
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{damagepersecond}", this.DarkDamageRatio.ToExpressionMultiply100()).Replace("{chargerate}", this.RevengeChargeRatio.ToExpressionMultiply100()).Replace("{agilityrate}", this.AgilityPenaltyRatio.ToExpressionMultiply100()).Replace("{ragerate}", this.RageRatioPenaltyRatio.ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x04002D12 RID: 11538
	public double DarkDamageRatio;

	// Token: 0x04002D13 RID: 11539
	public double RevengeChargeRatio;

	// Token: 0x04002D14 RID: 11540
	public double RageRatioPenaltyRatio;

	// Token: 0x04002D15 RID: 11541
	public double AgilityPenaltyRatio;

	// Token: 0x04002D16 RID: 11542
	public double RevengeChargedSoFar;

	// Token: 0x04002D17 RID: 11543
	public bool? IsStarEf;
}
