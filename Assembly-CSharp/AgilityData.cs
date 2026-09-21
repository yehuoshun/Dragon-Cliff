using System;

// Token: 0x020007AF RID: 1967
[Serializable]
public class AgilityData : ISpecialEffectDataLoad
{
	// Token: 0x060039A6 RID: 14758 RVA: 0x00176999 File Offset: 0x00174D99
	public AgilityData()
	{
	}

	// Token: 0x060039A7 RID: 14759 RVA: 0x001769A1 File Offset: 0x00174DA1
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Agility;
	}

	// Token: 0x060039A8 RID: 14760 RVA: 0x001769A8 File Offset: 0x00174DA8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.IncreaseRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x060039A9 RID: 14761 RVA: 0x001769E3 File Offset: 0x00174DE3
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x060039AA RID: 14762 RVA: 0x001769EB File Offset: 0x00174DEB
	public double GetEffectPowerValue()
	{
		return this.IncreaseRate;
	}

	// Token: 0x04002C9A RID: 11418
	public double IncreaseRate;

	// Token: 0x04002C9B RID: 11419
	public bool IsStar;
}
