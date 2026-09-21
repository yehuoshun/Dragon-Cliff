using System;

// Token: 0x02000851 RID: 2129
[Serializable]
public class ResistanceKillBoostData : ISpecialEffectDataLoad
{
	// Token: 0x06003CD4 RID: 15572 RVA: 0x0017C123 File Offset: 0x0017A523
	public ResistanceKillBoostData()
	{
	}

	// Token: 0x06003CD5 RID: 15573 RVA: 0x0017C12B File Offset: 0x0017A52B
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ResistanceKillBoost;
	}

	// Token: 0x06003CD6 RID: 15574 RVA: 0x0017C130 File Offset: 0x0017A530
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.BoostRate.ToExpressionMultiply100()).Replace("{max}", this.MaxRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003CD7 RID: 15575 RVA: 0x0017C180 File Offset: 0x0017A580
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003CD8 RID: 15576 RVA: 0x0017C188 File Offset: 0x0017A588
	public double GetEffectPowerValue()
	{
		return (1.0 + this.BoostRate) * (1.0 + this.MaxRate);
	}

	// Token: 0x04002E71 RID: 11889
	public double BoostRate;

	// Token: 0x04002E72 RID: 11890
	public double MaxRate;

	// Token: 0x04002E73 RID: 11891
	public bool IsStar;
}
