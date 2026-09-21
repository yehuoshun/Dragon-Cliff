using System;

// Token: 0x02000822 RID: 2082
[Serializable]
public class IceEffectEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003BE7 RID: 15335 RVA: 0x0017A57E File Offset: 0x0017897E
	public IceEffectEnhancementData()
	{
	}

	// Token: 0x06003BE8 RID: 15336 RVA: 0x0017A586 File Offset: 0x00178986
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.IceEffectEnhancement;
	}

	// Token: 0x06003BE9 RID: 15337 RVA: 0x0017A590 File Offset: 0x00178990
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.AdditionalRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003BEA RID: 15338 RVA: 0x0017A5CB File Offset: 0x001789CB
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003BEB RID: 15339 RVA: 0x0017A5D3 File Offset: 0x001789D3
	public double GetEffectPowerValue()
	{
		return this.AdditionalRate;
	}

	// Token: 0x04002DF0 RID: 11760
	public double AdditionalRate;

	// Token: 0x04002DF1 RID: 11761
	public bool IsStar;
}
