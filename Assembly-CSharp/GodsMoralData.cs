using System;

// Token: 0x02000813 RID: 2067
[Serializable]
public class GodsMoralData : ISpecialEffectDataLoad
{
	// Token: 0x06003BA5 RID: 15269 RVA: 0x00179EEF File Offset: 0x001782EF
	public GodsMoralData()
	{
	}

	// Token: 0x06003BA6 RID: 15270 RVA: 0x00179EF7 File Offset: 0x001782F7
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003BA7 RID: 15271 RVA: 0x00179F17 File Offset: 0x00178317
	public double GetEffectPowerValue()
	{
		return this.HealRate;
	}

	// Token: 0x06003BA8 RID: 15272 RVA: 0x00179F1F File Offset: 0x0017831F
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.GodsMoralEffect;
	}

	// Token: 0x06003BA9 RID: 15273 RVA: 0x00179F24 File Offset: 0x00178324
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{healrate}", this.HealRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x04002DC4 RID: 11716
	public double HealRate;

	// Token: 0x04002DC5 RID: 11717
	public bool? IsStarEf;
}
