using System;

// Token: 0x0200083E RID: 2110
[Serializable]
public class PoisonEffectEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003C75 RID: 15477 RVA: 0x0017B667 File Offset: 0x00179A67
	public PoisonEffectEnhancementData()
	{
	}

	// Token: 0x06003C76 RID: 15478 RVA: 0x0017B66F File Offset: 0x00179A6F
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.PoisonEffectEnhancement;
	}

	// Token: 0x06003C77 RID: 15479 RVA: 0x0017B678 File Offset: 0x00179A78
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.ExtraRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003C78 RID: 15480 RVA: 0x0017B6B3 File Offset: 0x00179AB3
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003C79 RID: 15481 RVA: 0x0017B6BB File Offset: 0x00179ABB
	public double GetEffectPowerValue()
	{
		return this.ExtraRate;
	}

	// Token: 0x04002E3C RID: 11836
	public double ExtraRate;

	// Token: 0x04002E3D RID: 11837
	public bool IsStar;
}
