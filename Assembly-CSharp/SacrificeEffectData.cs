using System;

// Token: 0x0200086F RID: 2159
[Serializable]
public class SacrificeEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003D95 RID: 15765 RVA: 0x00180F70 File Offset: 0x0017F370
	public SacrificeEffectData()
	{
	}

	// Token: 0x06003D96 RID: 15766 RVA: 0x00180F78 File Offset: 0x0017F378
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003D97 RID: 15767 RVA: 0x00180F98 File Offset: 0x0017F398
	public double GetEffectPowerValue()
	{
		return (1.0 + this.HealRate) / (1.0 + this.SacrificeRate);
	}

	// Token: 0x06003D98 RID: 15768 RVA: 0x00180FBB File Offset: 0x0017F3BB
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Sacrifice;
	}

	// Token: 0x06003D99 RID: 15769 RVA: 0x00180FC0 File Offset: 0x0017F3C0
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{mRate}", this.MinimumSelfRate.ToExpressionMultiply100()).Replace("{sRate}", this.SacrificeRate.ToExpressionMultiply100()).Replace("{healrate}", this.HealRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x04002EBA RID: 11962
	public double MinimumSelfRate;

	// Token: 0x04002EBB RID: 11963
	public double HealRate;

	// Token: 0x04002EBC RID: 11964
	public double SacrificeRate;

	// Token: 0x04002EBD RID: 11965
	[NonSerialized]
	public bool InTrigger;

	// Token: 0x04002EBE RID: 11966
	public bool? IsStarEf;
}
