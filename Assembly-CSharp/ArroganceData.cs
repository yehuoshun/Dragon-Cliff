using System;
using System.Collections.Generic;

// Token: 0x020007B4 RID: 1972
[Serializable]
public class ArroganceData : ISpecialEffectDataLoad, IAttributeModifierSpecialEffect
{
	// Token: 0x060039BF RID: 14783 RVA: 0x00176C02 File Offset: 0x00175002
	public ArroganceData()
	{
	}

	// Token: 0x060039C0 RID: 14784 RVA: 0x00176C0A File Offset: 0x0017500A
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Arrogance;
	}

	// Token: 0x060039C1 RID: 14785 RVA: 0x00176C14 File Offset: 0x00175014
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{reduction}", this.HitRateDeductionRate.ToExpressionMultiply100()).Replace("{boost}", this.HitRateBoostRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x060039C2 RID: 14786 RVA: 0x00176C64 File Offset: 0x00175064
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x060039C3 RID: 14787 RVA: 0x00176C6C File Offset: 0x0017506C
	public double GetEffectPowerValue()
	{
		return (1.0 + this.HitRateBoostRate) * (1.0 + this.HitRateDeductionRate);
	}

	// Token: 0x060039C4 RID: 14788 RVA: 0x00176C90 File Offset: 0x00175090
	public List<AttributeModifier> GetModifiers(AdventurerProfile profile)
	{
		if (profile.UnitClass == UnitClass.Duelist)
		{
			return new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.HitRateAdjustment,
					ModificationType = ModificationType.Addition,
					Value = this.HitRateBoostRate,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Gear
				}
			};
		}
		return new List<AttributeModifier>();
	}

	// Token: 0x04002CA8 RID: 11432
	public double HitRateDeductionRate;

	// Token: 0x04002CA9 RID: 11433
	public double HitRateBoostRate;

	// Token: 0x04002CAA RID: 11434
	public bool IsStar;
}
