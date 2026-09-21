using System;

// Token: 0x020007BC RID: 1980
[Serializable]
public class BloodCurseDispelPartyEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x060039ED RID: 14829 RVA: 0x001772E6 File Offset: 0x001756E6
	public BloodCurseDispelPartyEnhancementData()
	{
	}

	// Token: 0x060039EE RID: 14830 RVA: 0x001772EE File Offset: 0x001756EE
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.BloodCurseDispelPartyEnhancement;
	}

	// Token: 0x060039EF RID: 14831 RVA: 0x001772F8 File Offset: 0x001756F8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.NumberOfDispels.ToString());
		return description;
	}

	// Token: 0x060039F0 RID: 14832 RVA: 0x00177339 File Offset: 0x00175739
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x060039F1 RID: 14833 RVA: 0x00177341 File Offset: 0x00175741
	public double GetEffectPowerValue()
	{
		return (double)this.NumberOfDispels;
	}

	// Token: 0x04002CC9 RID: 11465
	public int NumberOfDispels;

	// Token: 0x04002CCA RID: 11466
	public bool IsStar;
}
