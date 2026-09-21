using System;

// Token: 0x02000833 RID: 2099
[Serializable]
public class MonksEyesData : ISpecialEffectDataLoad
{
	// Token: 0x06003C3D RID: 15421 RVA: 0x0017AD93 File Offset: 0x00179193
	public MonksEyesData()
	{
	}

	// Token: 0x06003C3E RID: 15422 RVA: 0x0017AD9B File Offset: 0x0017919B
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003C3F RID: 15423 RVA: 0x0017ADBB File Offset: 0x001791BB
	public double GetEffectPowerValue()
	{
		return 1.0 / (1.0 + Math.Abs(this.MaxLoss));
	}

	// Token: 0x06003C40 RID: 15424 RVA: 0x0017ADDC File Offset: 0x001791DC
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.MonksEyesEffect;
	}

	// Token: 0x06003C41 RID: 15425 RVA: 0x0017ADE0 File Offset: 0x001791E0
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{maxloss}", this.MaxLoss.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x04002E23 RID: 11811
	public double MaxLoss;

	// Token: 0x04002E24 RID: 11812
	public bool? IsStarEf;
}
