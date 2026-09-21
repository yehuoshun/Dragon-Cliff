using System;

// Token: 0x0200087F RID: 2175
[Serializable]
public class SpitFireDispelData : ISpecialEffectDataLoad
{
	// Token: 0x06003DE1 RID: 15841 RVA: 0x001816FF File Offset: 0x0017FAFF
	public SpitFireDispelData()
	{
	}

	// Token: 0x06003DE2 RID: 15842 RVA: 0x00181707 File Offset: 0x0017FB07
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SpitFireDispelEnhancement;
	}

	// Token: 0x06003DE3 RID: 15843 RVA: 0x00181710 File Offset: 0x0017FB10
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.NumberOfDispels.ToString());
		return description;
	}

	// Token: 0x06003DE4 RID: 15844 RVA: 0x00181751 File Offset: 0x0017FB51
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003DE5 RID: 15845 RVA: 0x00181759 File Offset: 0x0017FB59
	public double GetEffectPowerValue()
	{
		return (double)this.NumberOfDispels;
	}

	// Token: 0x04002EE7 RID: 12007
	public int NumberOfDispels;

	// Token: 0x04002EE8 RID: 12008
	public bool IsStar;
}
