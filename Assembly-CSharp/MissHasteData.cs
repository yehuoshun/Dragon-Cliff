using System;

// Token: 0x02000832 RID: 2098
[Serializable]
public class MissHasteData : ISpecialEffectDataLoad
{
	// Token: 0x06003C38 RID: 15416 RVA: 0x0017AD39 File Offset: 0x00179139
	public MissHasteData()
	{
	}

	// Token: 0x06003C39 RID: 15417 RVA: 0x0017AD41 File Offset: 0x00179141
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.MissHaste;
	}

	// Token: 0x06003C3A RID: 15418 RVA: 0x0017AD48 File Offset: 0x00179148
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.HasteRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003C3B RID: 15419 RVA: 0x0017AD83 File Offset: 0x00179183
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003C3C RID: 15420 RVA: 0x0017AD8B File Offset: 0x0017918B
	public double GetEffectPowerValue()
	{
		return this.HasteRate;
	}

	// Token: 0x04002E21 RID: 11809
	public double HasteRate;

	// Token: 0x04002E22 RID: 11810
	public bool IsStar;
}
