using System;

// Token: 0x020007B9 RID: 1977
[Serializable]
public class BlackBloodData : ISpecialEffectDataLoad
{
	// Token: 0x060039DD RID: 14813 RVA: 0x001770F3 File Offset: 0x001754F3
	public BlackBloodData()
	{
	}

	// Token: 0x060039DE RID: 14814 RVA: 0x001770FB File Offset: 0x001754FB
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.BlackBlood;
	}

	// Token: 0x060039DF RID: 14815 RVA: 0x00177104 File Offset: 0x00175504
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{dodge}", this.DodgeDecayRate.ToExpressionMultiply100()).Replace("{resistance}", this.ResistanceDecayRate.ToExpressionMultiply100()).Replace("{seconds}", this.Seconds.ToString());
		return description;
	}

	// Token: 0x060039E0 RID: 14816 RVA: 0x0017716F File Offset: 0x0017556F
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x060039E1 RID: 14817 RVA: 0x00177177 File Offset: 0x00175577
	public double GetEffectPowerValue()
	{
		return this.ResistanceDecayRate + this.DodgeDecayRate;
	}

	// Token: 0x04002CBE RID: 11454
	public double ResistanceDecayRate;

	// Token: 0x04002CBF RID: 11455
	public double DodgeDecayRate;

	// Token: 0x04002CC0 RID: 11456
	public int Seconds;

	// Token: 0x04002CC1 RID: 11457
	public bool IsStar;
}
