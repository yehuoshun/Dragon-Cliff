using System;

// Token: 0x020007FF RID: 2047
[Serializable]
public class EyeOfPrecisionEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003B41 RID: 15169 RVA: 0x00179616 File Offset: 0x00177A16
	public EyeOfPrecisionEffectData()
	{
	}

	// Token: 0x06003B42 RID: 15170 RVA: 0x0017961E File Offset: 0x00177A1E
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.EyeOfPrecisionEffect;
	}

	// Token: 0x06003B43 RID: 15171 RVA: 0x00179624 File Offset: 0x00177A24
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003B44 RID: 15172 RVA: 0x0017965F File Offset: 0x00177A5F
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B45 RID: 15173 RVA: 0x00179667 File Offset: 0x00177A67
	public double GetEffectPowerValue()
	{
		return this.Rate;
	}

	// Token: 0x04002D96 RID: 11670
	public double Rate;

	// Token: 0x04002D97 RID: 11671
	public bool IsStar;
}
