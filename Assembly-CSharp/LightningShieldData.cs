using System;

// Token: 0x0200082F RID: 2095
[Serializable]
public class LightningShieldData : ISpecialEffectDataLoad
{
	// Token: 0x06003C29 RID: 15401 RVA: 0x0017ABD2 File Offset: 0x00178FD2
	public LightningShieldData()
	{
	}

	// Token: 0x06003C2A RID: 15402 RVA: 0x0017ABDA File Offset: 0x00178FDA
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.LightningShield;
	}

	// Token: 0x06003C2B RID: 15403 RVA: 0x0017ABE4 File Offset: 0x00178FE4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{resiliencerate}", this.ResilienceReductionRate.ToExpressionMultiply100()).Replace("{negative}", this.NegativeResistance.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003C2C RID: 15404 RVA: 0x0017AC34 File Offset: 0x00179034
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003C2D RID: 15405 RVA: 0x0017AC3C File Offset: 0x0017903C
	public double GetEffectPowerValue()
	{
		return (1.0 + this.ResilienceReductionRate) * (1.0 + this.NegativeResistance);
	}

	// Token: 0x04002E17 RID: 11799
	public double ResilienceReductionRate;

	// Token: 0x04002E18 RID: 11800
	public double NegativeResistance;

	// Token: 0x04002E19 RID: 11801
	public bool IsStar;
}
