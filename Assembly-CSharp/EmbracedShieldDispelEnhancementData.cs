using System;

// Token: 0x020007F3 RID: 2035
[Serializable]
public class EmbracedShieldDispelEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003B04 RID: 15108 RVA: 0x001790AF File Offset: 0x001774AF
	public EmbracedShieldDispelEnhancementData()
	{
	}

	// Token: 0x06003B05 RID: 15109 RVA: 0x001790B7 File Offset: 0x001774B7
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.EmbracedShieldDispelEnhancement;
	}

	// Token: 0x06003B06 RID: 15110 RVA: 0x001790C0 File Offset: 0x001774C0
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.NumberOfDispels.ToString());
		return description;
	}

	// Token: 0x06003B07 RID: 15111 RVA: 0x00179101 File Offset: 0x00177501
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B08 RID: 15112 RVA: 0x00179109 File Offset: 0x00177509
	public double GetEffectPowerValue()
	{
		return (double)this.NumberOfDispels;
	}

	// Token: 0x04002D7A RID: 11642
	public int NumberOfDispels;

	// Token: 0x04002D7B RID: 11643
	public bool IsStar;
}
