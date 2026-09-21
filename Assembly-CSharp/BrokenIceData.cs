using System;

// Token: 0x020007C1 RID: 1985
[Serializable]
public class BrokenIceData : ISpecialEffectDataLoad
{
	// Token: 0x06003A06 RID: 14854 RVA: 0x0017751D File Offset: 0x0017591D
	public BrokenIceData()
	{
	}

	// Token: 0x06003A07 RID: 14855 RVA: 0x00177525 File Offset: 0x00175925
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.BrokenIce;
	}

	// Token: 0x06003A08 RID: 14856 RVA: 0x0017752C File Offset: 0x0017592C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{seconds}", this.Seconds.ToExpression());
		return description;
	}

	// Token: 0x06003A09 RID: 14857 RVA: 0x00177567 File Offset: 0x00175967
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003A0A RID: 14858 RVA: 0x0017756F File Offset: 0x0017596F
	public double GetEffectPowerValue()
	{
		return this.Seconds;
	}

	// Token: 0x04002CD7 RID: 11479
	public double Seconds;

	// Token: 0x04002CD8 RID: 11480
	public bool IsStar;
}
