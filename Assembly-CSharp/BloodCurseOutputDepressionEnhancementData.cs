using System;

// Token: 0x020007BD RID: 1981
[Serializable]
public class BloodCurseOutputDepressionEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x060039F2 RID: 14834 RVA: 0x0017734A File Offset: 0x0017574A
	public BloodCurseOutputDepressionEnhancementData()
	{
	}

	// Token: 0x060039F3 RID: 14835 RVA: 0x00177352 File Offset: 0x00175752
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.BloodCurseOutputDepressionEnhancement;
	}

	// Token: 0x060039F4 RID: 14836 RVA: 0x0017735C File Offset: 0x0017575C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100()).Replace("{seconds}", this.Seconds.ToString());
		return description;
	}

	// Token: 0x060039F5 RID: 14837 RVA: 0x001773B2 File Offset: 0x001757B2
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x060039F6 RID: 14838 RVA: 0x001773BA File Offset: 0x001757BA
	public double GetEffectPowerValue()
	{
		return this.Rate;
	}

	// Token: 0x04002CCB RID: 11467
	public double Rate;

	// Token: 0x04002CCC RID: 11468
	public int Seconds;

	// Token: 0x04002CCD RID: 11469
	public bool IsStar;
}
