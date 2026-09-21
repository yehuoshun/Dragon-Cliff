using System;

// Token: 0x02000819 RID: 2073
[Serializable]
public class HealOutputBoostData : ISpecialEffectDataLoad
{
	// Token: 0x06003BBE RID: 15294 RVA: 0x0017A276 File Offset: 0x00178676
	public HealOutputBoostData()
	{
	}

	// Token: 0x06003BBF RID: 15295 RVA: 0x0017A27E File Offset: 0x0017867E
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.HealOutputBoost;
	}

	// Token: 0x06003BC0 RID: 15296 RVA: 0x0017A288 File Offset: 0x00178688
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{boost}", this.BoostRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003BC1 RID: 15297 RVA: 0x0017A2C3 File Offset: 0x001786C3
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x06003BC2 RID: 15298 RVA: 0x0017A2C6 File Offset: 0x001786C6
	public double GetEffectPowerValue()
	{
		return this.BoostRate;
	}

	// Token: 0x04002DE0 RID: 11744
	public double BoostRate;
}
