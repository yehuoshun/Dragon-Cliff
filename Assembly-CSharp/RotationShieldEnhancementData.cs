using System;

// Token: 0x02000858 RID: 2136
[Serializable]
public class RotationShieldEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003CF7 RID: 15607 RVA: 0x0017C4FE File Offset: 0x0017A8FE
	public RotationShieldEnhancementData()
	{
	}

	// Token: 0x06003CF8 RID: 15608 RVA: 0x0017C506 File Offset: 0x0017A906
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.RotationShieldEnhancement;
	}

	// Token: 0x06003CF9 RID: 15609 RVA: 0x0017C510 File Offset: 0x0017A910
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.ShieldRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003CFA RID: 15610 RVA: 0x0017C54B File Offset: 0x0017A94B
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003CFB RID: 15611 RVA: 0x0017C553 File Offset: 0x0017A953
	public double GetEffectPowerValue()
	{
		return this.ShieldRate;
	}

	// Token: 0x04002E87 RID: 11911
	public double ShieldRate;

	// Token: 0x04002E88 RID: 11912
	public bool IsStar;
}
