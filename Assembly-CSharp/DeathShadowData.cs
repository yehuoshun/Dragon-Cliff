using System;

// Token: 0x020007DB RID: 2011
public class DeathShadowData : ISpecialEffectDataLoad
{
	// Token: 0x06003A8A RID: 14986 RVA: 0x00178230 File Offset: 0x00176630
	public DeathShadowData()
	{
	}

	// Token: 0x06003A8B RID: 14987 RVA: 0x00178238 File Offset: 0x00176638
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003A8C RID: 14988 RVA: 0x00178258 File Offset: 0x00176658
	public double GetEffectPowerValue()
	{
		return this.DamageRate;
	}

	// Token: 0x06003A8D RID: 14989 RVA: 0x00178260 File Offset: 0x00176660
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DeathShadowEffect;
	}

	// Token: 0x06003A8E RID: 14990 RVA: 0x00178264 File Offset: 0x00176664
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{chargeseconds}", this.CoolingDownSeconds.ToString()).Replace("{channeling}", this.ChannelingSeconds.FloatToString()).Replace("{damagerate}", this.DamageRate.ToExpressionMultiply100()).Replace("{damagetype}", this.DamageType.GetDescription().Title).Replace("{revivedchargeseconds}", this.CoolingDownSecondsAfterRebirth.ToString()).ToString();
		return description;
	}

	// Token: 0x04002D1F RID: 11551
	public int CoolingDownSeconds;

	// Token: 0x04002D20 RID: 11552
	public int CoolingDownSecondsAfterRebirth;

	// Token: 0x04002D21 RID: 11553
	public float ChannelingSeconds;

	// Token: 0x04002D22 RID: 11554
	public double DamageRate;

	// Token: 0x04002D23 RID: 11555
	public OutputType DamageType;

	// Token: 0x04002D24 RID: 11556
	public bool HaveRevived;

	// Token: 0x04002D25 RID: 11557
	public double ReviveRate;

	// Token: 0x04002D26 RID: 11558
	public int CoolingDownCounter;

	// Token: 0x04002D27 RID: 11559
	public bool? IsStarEf;
}
