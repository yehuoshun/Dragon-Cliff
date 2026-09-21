using System;

// Token: 0x0200080E RID: 2062
[Serializable]
public class FrenzyPushEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003B8C RID: 15244 RVA: 0x00179D02 File Offset: 0x00178102
	public FrenzyPushEnhancementData()
	{
	}

	// Token: 0x06003B8D RID: 15245 RVA: 0x00179D0A File Offset: 0x0017810A
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.FrenzyPushEnhancemednt;
	}

	// Token: 0x06003B8E RID: 15246 RVA: 0x00179D14 File Offset: 0x00178114
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.PushRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003B8F RID: 15247 RVA: 0x00179D4F File Offset: 0x0017814F
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B90 RID: 15248 RVA: 0x00179D57 File Offset: 0x00178157
	public double GetEffectPowerValue()
	{
		return this.PushRate;
	}

	// Token: 0x04002DB9 RID: 11705
	public double PushRate;

	// Token: 0x04002DBA RID: 11706
	public bool IsStar;
}
