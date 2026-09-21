using System;

// Token: 0x0200081D RID: 2077
[Serializable]
public class HeartlessSeedEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003BD2 RID: 15314 RVA: 0x0017A3D7 File Offset: 0x001787D7
	public HeartlessSeedEnhancementData()
	{
	}

	// Token: 0x06003BD3 RID: 15315 RVA: 0x0017A3DF File Offset: 0x001787DF
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.HeartlessSeedEnhancement;
	}

	// Token: 0x06003BD4 RID: 15316 RVA: 0x0017A3E8 File Offset: 0x001787E8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.ExtraRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003BD5 RID: 15317 RVA: 0x0017A423 File Offset: 0x00178823
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003BD6 RID: 15318 RVA: 0x0017A42B File Offset: 0x0017882B
	public double GetEffectPowerValue()
	{
		return this.ExtraRate;
	}

	// Token: 0x04002DE6 RID: 11750
	public double ExtraRate;

	// Token: 0x04002DE7 RID: 11751
	public bool IsStar;
}
