using System;

// Token: 0x02000880 RID: 2176
[Serializable]
public class SpitFireFocusEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003DE6 RID: 15846 RVA: 0x00181762 File Offset: 0x0017FB62
	public SpitFireFocusEnhancementData()
	{
	}

	// Token: 0x06003DE7 RID: 15847 RVA: 0x0018176A File Offset: 0x0017FB6A
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SpitFireFocusEnhancement;
	}

	// Token: 0x06003DE8 RID: 15848 RVA: 0x00181774 File Offset: 0x0017FB74
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{seconds}", this.LastingSeconds.ToString()).Replace("{damagerate}", this.DamageBoostRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003DE9 RID: 15849 RVA: 0x001817CA File Offset: 0x0017FBCA
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003DEA RID: 15850 RVA: 0x001817D2 File Offset: 0x0017FBD2
	public double GetEffectPowerValue()
	{
		return this.DamageBoostRate;
	}

	// Token: 0x04002EE9 RID: 12009
	public int LastingSeconds;

	// Token: 0x04002EEA RID: 12010
	public double DamageBoostRate;

	// Token: 0x04002EEB RID: 12011
	public bool IsStar;
}
