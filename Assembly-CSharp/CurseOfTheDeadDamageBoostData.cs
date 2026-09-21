using System;

// Token: 0x020007D3 RID: 2003
[Serializable]
public class CurseOfTheDeadDamageBoostData : ISpecialEffectDataLoad
{
	// Token: 0x06003A61 RID: 14945 RVA: 0x00177D97 File Offset: 0x00176197
	public CurseOfTheDeadDamageBoostData()
	{
	}

	// Token: 0x06003A62 RID: 14946 RVA: 0x00177D9F File Offset: 0x0017619F
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.CurseOfTheDeadDamageBoost;
	}

	// Token: 0x06003A63 RID: 14947 RVA: 0x00177DA8 File Offset: 0x001761A8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.ExtraDamageRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003A64 RID: 14948 RVA: 0x00177DE3 File Offset: 0x001761E3
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003A65 RID: 14949 RVA: 0x00177DEB File Offset: 0x001761EB
	public double GetEffectPowerValue()
	{
		return this.ExtraDamageRate;
	}

	// Token: 0x04002D06 RID: 11526
	public double ExtraDamageRate;

	// Token: 0x04002D07 RID: 11527
	public bool IsStar;
}
