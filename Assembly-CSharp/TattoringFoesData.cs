using System;

// Token: 0x02000894 RID: 2196
[Serializable]
public class TattoringFoesData : ISpecialEffectDataLoad
{
	// Token: 0x06003E4A RID: 15946 RVA: 0x00182167 File Offset: 0x00180567
	public TattoringFoesData()
	{
	}

	// Token: 0x06003E4B RID: 15947 RVA: 0x0018216F File Offset: 0x0018056F
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.TattoringFoes;
	}

	// Token: 0x06003E4C RID: 15948 RVA: 0x00182174 File Offset: 0x00180574
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.DamageRate.ToExpressionMultiply100()).Replace("{type}", this.DamageType.GetDescription().Title);
		return description;
	}

	// Token: 0x06003E4D RID: 15949 RVA: 0x001821C9 File Offset: 0x001805C9
	public bool IsStarEffect()
	{
		return true;
	}

	// Token: 0x06003E4E RID: 15950 RVA: 0x001821CC File Offset: 0x001805CC
	public double GetEffectPowerValue()
	{
		return this.DamageRate;
	}

	// Token: 0x04002F23 RID: 12067
	public double DamageRate;

	// Token: 0x04002F24 RID: 12068
	public OutputType DamageType;

	// Token: 0x04002F25 RID: 12069
	public bool IsStar;
}
