using System;

// Token: 0x020007CD RID: 1997
[Serializable]
public class CourageBlessingData : ISpecialEffectDataLoad
{
	// Token: 0x06003A43 RID: 14915 RVA: 0x00177A9F File Offset: 0x00175E9F
	public CourageBlessingData()
	{
	}

	// Token: 0x06003A44 RID: 14916 RVA: 0x00177AA7 File Offset: 0x00175EA7
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.CourageBlessing;
	}

	// Token: 0x06003A45 RID: 14917 RVA: 0x00177AAC File Offset: 0x00175EAC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{stunrate}", this.StunRate.ToExpressionMultiply100()).Replace("{outputreductionrate}", this.OutputReductionRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003A46 RID: 14918 RVA: 0x00177AFC File Offset: 0x00175EFC
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003A47 RID: 14919 RVA: 0x00177B04 File Offset: 0x00175F04
	public double GetEffectPowerValue()
	{
		return (1.0 + this.StunRate) * (1.0 + this.OutputReductionRate);
	}

	// Token: 0x04002CF6 RID: 11510
	public double StunRate;

	// Token: 0x04002CF7 RID: 11511
	public double OutputReductionRate;

	// Token: 0x04002CF8 RID: 11512
	public bool IsStar;
}
