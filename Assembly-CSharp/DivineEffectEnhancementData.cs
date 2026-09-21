using System;

// Token: 0x020007E5 RID: 2021
[Serializable]
public class DivineEffectEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003ABD RID: 15037 RVA: 0x001788FF File Offset: 0x00176CFF
	public DivineEffectEnhancementData()
	{
	}

	// Token: 0x06003ABE RID: 15038 RVA: 0x00178907 File Offset: 0x00176D07
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DivineEffectEnhancement;
	}

	// Token: 0x06003ABF RID: 15039 RVA: 0x00178910 File Offset: 0x00176D10
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Chance.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003AC0 RID: 15040 RVA: 0x0017894B File Offset: 0x00176D4B
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003AC1 RID: 15041 RVA: 0x00178953 File Offset: 0x00176D53
	public double GetEffectPowerValue()
	{
		return this.Chance;
	}

	// Token: 0x04002D5D RID: 11613
	public double Chance;

	// Token: 0x04002D5E RID: 11614
	public bool IsStar;
}
