using System;

// Token: 0x020007CB RID: 1995
[Serializable]
public class ConjourerPetEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003A39 RID: 14905 RVA: 0x001779F6 File Offset: 0x00175DF6
	public ConjourerPetEnhancementData()
	{
	}

	// Token: 0x06003A3A RID: 14906 RVA: 0x001779FE File Offset: 0x00175DFE
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ConjourerPetEnhancement;
	}

	// Token: 0x06003A3B RID: 14907 RVA: 0x00177A08 File Offset: 0x00175E08
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{type}", this.Type.GetDescription().Title);
		return description;
	}

	// Token: 0x06003A3C RID: 14908 RVA: 0x00177A48 File Offset: 0x00175E48
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003A3D RID: 14909 RVA: 0x00177A50 File Offset: 0x00175E50
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x04002CF3 RID: 11507
	public UnitClass Type;

	// Token: 0x04002CF4 RID: 11508
	public bool IsStar;
}
