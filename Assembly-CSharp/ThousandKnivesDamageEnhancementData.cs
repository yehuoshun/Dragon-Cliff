using System;

// Token: 0x02000899 RID: 2201
[Serializable]
public class ThousandKnivesDamageEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003E63 RID: 15971 RVA: 0x001823A7 File Offset: 0x001807A7
	public ThousandKnivesDamageEnhancementData()
	{
	}

	// Token: 0x06003E64 RID: 15972 RVA: 0x001823AF File Offset: 0x001807AF
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ThousandKnivesDamageEnhancement;
	}

	// Token: 0x06003E65 RID: 15973 RVA: 0x001823B8 File Offset: 0x001807B8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.DamageRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003E66 RID: 15974 RVA: 0x001823F3 File Offset: 0x001807F3
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E67 RID: 15975 RVA: 0x001823FB File Offset: 0x001807FB
	public double GetEffectPowerValue()
	{
		return this.DamageRate;
	}

	// Token: 0x04002F2D RID: 12077
	public double DamageRate;

	// Token: 0x04002F2E RID: 12078
	public bool IsStar;
}
