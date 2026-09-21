using System;

// Token: 0x0200083D RID: 2109
[Serializable]
public class PhysicalEffectEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003C70 RID: 15472 RVA: 0x0017B60B File Offset: 0x00179A0B
	public PhysicalEffectEnhancementData()
	{
	}

	// Token: 0x06003C71 RID: 15473 RVA: 0x0017B613 File Offset: 0x00179A13
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.PhysicalEffectEnhancement;
	}

	// Token: 0x06003C72 RID: 15474 RVA: 0x0017B61C File Offset: 0x00179A1C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.DodgeRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003C73 RID: 15475 RVA: 0x0017B657 File Offset: 0x00179A57
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003C74 RID: 15476 RVA: 0x0017B65F File Offset: 0x00179A5F
	public double GetEffectPowerValue()
	{
		return this.DodgeRate;
	}

	// Token: 0x04002E3A RID: 11834
	public double DodgeRate;

	// Token: 0x04002E3B RID: 11835
	public bool IsStar;
}
