using System;

// Token: 0x020007BB RID: 1979
[Serializable]
public class BloodCurseDispelOnHitData : ISpecialEffectDataLoad
{
	// Token: 0x060039E8 RID: 14824 RVA: 0x00177285 File Offset: 0x00175685
	public BloodCurseDispelOnHitData()
	{
	}

	// Token: 0x060039E9 RID: 14825 RVA: 0x0017728D File Offset: 0x0017568D
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.BloodCurseDispelOnHitEnhancement;
	}

	// Token: 0x060039EA RID: 14826 RVA: 0x00177294 File Offset: 0x00175694
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.NumberOfDispels.ToString());
		return description;
	}

	// Token: 0x060039EB RID: 14827 RVA: 0x001772D5 File Offset: 0x001756D5
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x060039EC RID: 14828 RVA: 0x001772DD File Offset: 0x001756DD
	public double GetEffectPowerValue()
	{
		return (double)this.NumberOfDispels;
	}

	// Token: 0x04002CC7 RID: 11463
	public int NumberOfDispels;

	// Token: 0x04002CC8 RID: 11464
	public bool IsStar;
}
