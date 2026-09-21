using System;

// Token: 0x020008A0 RID: 2208
[Serializable]
public class TimelessData : ISpecialEffectDataLoad
{
	// Token: 0x06003E86 RID: 16006 RVA: 0x00182743 File Offset: 0x00180B43
	public TimelessData()
	{
	}

	// Token: 0x06003E87 RID: 16007 RVA: 0x0018274B File Offset: 0x00180B4B
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Timeless;
	}

	// Token: 0x06003E88 RID: 16008 RVA: 0x00182754 File Offset: 0x00180B54
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{hit}", this.HitRate.ToExpressionMultiply100()).Replace("{effect}", this.EffectMastery.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003E89 RID: 16009 RVA: 0x001827A4 File Offset: 0x00180BA4
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E8A RID: 16010 RVA: 0x001827AC File Offset: 0x00180BAC
	public double GetEffectPowerValue()
	{
		return (1.0 + this.HitRate) * (1.0 + this.EffectMastery);
	}

	// Token: 0x04002F46 RID: 12102
	public double HitRate;

	// Token: 0x04002F47 RID: 12103
	public double EffectMastery;

	// Token: 0x04002F48 RID: 12104
	public bool IsStar;
}
