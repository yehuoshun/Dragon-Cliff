using System;

// Token: 0x020007EF RID: 2031
[Serializable]
public class EffectSealData : ISpecialEffectDataLoad
{
	// Token: 0x06003AF0 RID: 15088 RVA: 0x00178F15 File Offset: 0x00177315
	public EffectSealData()
	{
	}

	// Token: 0x06003AF1 RID: 15089 RVA: 0x00178F1D File Offset: 0x0017731D
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.EffectSeal;
	}

	// Token: 0x06003AF2 RID: 15090 RVA: 0x00178F24 File Offset: 0x00177324
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003AF3 RID: 15091 RVA: 0x00178F5F File Offset: 0x0017735F
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003AF4 RID: 15092 RVA: 0x00178F67 File Offset: 0x00177367
	public double GetEffectPowerValue()
	{
		return this.Chance;
	}

	// Token: 0x04002D72 RID: 11634
	public double Chance;

	// Token: 0x04002D73 RID: 11635
	public bool IsStar;
}
