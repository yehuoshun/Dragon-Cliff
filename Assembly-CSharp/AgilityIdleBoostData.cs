using System;

// Token: 0x020007B0 RID: 1968
[Serializable]
public class AgilityIdleBoostData : ISpecialEffectDataLoad
{
	// Token: 0x060039AB RID: 14763 RVA: 0x001769F3 File Offset: 0x00174DF3
	public AgilityIdleBoostData()
	{
	}

	// Token: 0x060039AC RID: 14764 RVA: 0x001769FB File Offset: 0x00174DFB
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.AgilityIdleBoost;
	}

	// Token: 0x060039AD RID: 14765 RVA: 0x00176A00 File Offset: 0x00174E00
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{rate}", this.BoostRate.ToExpressionMultiply100()).Replace("{cd}", this.CoolingDownSeconds.ToString()).ToString();
		return description;
	}

	// Token: 0x060039AE RID: 14766 RVA: 0x00176A5B File Offset: 0x00174E5B
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x060039AF RID: 14767 RVA: 0x00176A63 File Offset: 0x00174E63
	public double GetEffectPowerValue()
	{
		return this.BoostRate;
	}

	// Token: 0x04002C9C RID: 11420
	public int CoolingDownSeconds;

	// Token: 0x04002C9D RID: 11421
	public double BoostRate;

	// Token: 0x04002C9E RID: 11422
	[NonSerialized]
	public int Counter;

	// Token: 0x04002C9F RID: 11423
	public bool IsStar;
}
