using System;

// Token: 0x02000841 RID: 2113
[Serializable]
public class PoisonMistDispelEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003C85 RID: 15493 RVA: 0x0017B883 File Offset: 0x00179C83
	public PoisonMistDispelEnhancementData()
	{
	}

	// Token: 0x06003C86 RID: 15494 RVA: 0x0017B88B File Offset: 0x00179C8B
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.PoisonMistDispelEnhancement;
	}

	// Token: 0x06003C87 RID: 15495 RVA: 0x0017B894 File Offset: 0x00179C94
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.NumberOfDispelShields.ToString());
		return description;
	}

	// Token: 0x06003C88 RID: 15496 RVA: 0x0017B8D5 File Offset: 0x00179CD5
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003C89 RID: 15497 RVA: 0x0017B8DD File Offset: 0x00179CDD
	public double GetEffectPowerValue()
	{
		return (double)this.NumberOfDispelShields;
	}

	// Token: 0x04002E47 RID: 11847
	public int NumberOfDispelShields;

	// Token: 0x04002E48 RID: 11848
	public bool IsStar;
}
