using System;

// Token: 0x0200080F RID: 2063
[Serializable]
public class FrenzyStunEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003B91 RID: 15249 RVA: 0x00179D5F File Offset: 0x0017815F
	public FrenzyStunEnhancementData()
	{
	}

	// Token: 0x06003B92 RID: 15250 RVA: 0x00179D67 File Offset: 0x00178167
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.FrenzyStunEnhancement;
	}

	// Token: 0x06003B93 RID: 15251 RVA: 0x00179D70 File Offset: 0x00178170
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{seconds}", this.Seconds.ToString());
		return description;
	}

	// Token: 0x06003B94 RID: 15252 RVA: 0x00179DB1 File Offset: 0x001781B1
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B95 RID: 15253 RVA: 0x00179DB9 File Offset: 0x001781B9
	public double GetEffectPowerValue()
	{
		return (double)this.Seconds;
	}

	// Token: 0x04002DBB RID: 11707
	public int Seconds;

	// Token: 0x04002DBC RID: 11708
	public bool IsStar;
}
