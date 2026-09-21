using System;

// Token: 0x020007CA RID: 1994
[Serializable]
public class ConfidentHealerData : ISpecialEffectDataLoad
{
	// Token: 0x06003A34 RID: 14900 RVA: 0x0017795F File Offset: 0x00175D5F
	public ConfidentHealerData()
	{
	}

	// Token: 0x06003A35 RID: 14901 RVA: 0x00177967 File Offset: 0x00175D67
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ConfidentHealer;
	}

	// Token: 0x06003A36 RID: 14902 RVA: 0x0017796C File Offset: 0x00175D6C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{boost}", this.HealBoostRate.ToExpressionMultiply100()).Replace("{seconds}", this.AfterHealSeconds.ToString()).Replace("{after}", this.AfterHealRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003A37 RID: 14903 RVA: 0x001779D7 File Offset: 0x00175DD7
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003A38 RID: 14904 RVA: 0x001779DF File Offset: 0x00175DDF
	public double GetEffectPowerValue()
	{
		return this.HealBoostRate + this.AfterHealRate * (double)this.AfterHealSeconds;
	}

	// Token: 0x04002CEF RID: 11503
	public double HealBoostRate;

	// Token: 0x04002CF0 RID: 11504
	public int AfterHealSeconds;

	// Token: 0x04002CF1 RID: 11505
	public double AfterHealRate;

	// Token: 0x04002CF2 RID: 11506
	public bool IsStar;
}
