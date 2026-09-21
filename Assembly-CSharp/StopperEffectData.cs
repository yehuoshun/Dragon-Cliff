using System;

// Token: 0x02000887 RID: 2183
[Serializable]
public class StopperEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003E09 RID: 15881 RVA: 0x00181B64 File Offset: 0x0017FF64
	public StopperEffectData()
	{
	}

	// Token: 0x06003E0A RID: 15882 RVA: 0x00181B6C File Offset: 0x0017FF6C
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Stopper;
	}

	// Token: 0x06003E0B RID: 15883 RVA: 0x00181B70 File Offset: 0x0017FF70
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{seconds}", this.LastingSeconds.ToString());
		return description;
	}

	// Token: 0x06003E0C RID: 15884 RVA: 0x00181BC6 File Offset: 0x0017FFC6
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E0D RID: 15885 RVA: 0x00181BCE File Offset: 0x0017FFCE
	public double GetEffectPowerValue()
	{
		return (1.0 + this.Chance) * (1.0 + (double)this.LastingSeconds);
	}

	// Token: 0x04002F00 RID: 12032
	public double Chance;

	// Token: 0x04002F01 RID: 12033
	public int LastingSeconds;

	// Token: 0x04002F02 RID: 12034
	public bool IsStar;
}
