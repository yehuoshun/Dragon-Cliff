using System;

// Token: 0x020007CF RID: 1999
[Serializable]
public class CrashDispelData : ISpecialEffectDataLoad
{
	// Token: 0x06003A4D RID: 14925 RVA: 0x00177B9D File Offset: 0x00175F9D
	public CrashDispelData()
	{
	}

	// Token: 0x06003A4E RID: 14926 RVA: 0x00177BA5 File Offset: 0x00175FA5
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.CrashDispel;
	}

	// Token: 0x06003A4F RID: 14927 RVA: 0x00177BAC File Offset: 0x00175FAC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.NumberOfDispel.ToString());
		return description;
	}

	// Token: 0x06003A50 RID: 14928 RVA: 0x00177BED File Offset: 0x00175FED
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003A51 RID: 14929 RVA: 0x00177BF5 File Offset: 0x00175FF5
	public double GetEffectPowerValue()
	{
		return (double)this.NumberOfDispel;
	}

	// Token: 0x04002CFB RID: 11515
	public int NumberOfDispel;

	// Token: 0x04002CFC RID: 11516
	public bool IsStar;
}
