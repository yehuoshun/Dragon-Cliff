using System;
using System.Collections.Generic;

// Token: 0x0200083F RID: 2111
[Serializable]
public class PoisonMistBoostData : ISpecialEffectDataLoad, IAttributeModifierSpecialEffect
{
	// Token: 0x06003C7A RID: 15482 RVA: 0x0017B6C3 File Offset: 0x00179AC3
	public PoisonMistBoostData()
	{
	}

	// Token: 0x06003C7B RID: 15483 RVA: 0x0017B6CB File Offset: 0x00179ACB
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.PoisonMistBoost;
	}

	// Token: 0x06003C7C RID: 15484 RVA: 0x0017B6D4 File Offset: 0x00179AD4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{boost}", this.EffectRatingBoostValue.ToExpression()).Replace("{damage}", this.DamageBoost.ToExpressionMultiply100()).Replace("{rate}", this.DodgeDeductionRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003C7D RID: 15485 RVA: 0x0017B739 File Offset: 0x00179B39
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003C7E RID: 15486 RVA: 0x0017B741 File Offset: 0x00179B41
	public double GetEffectPowerValue()
	{
		return (1.0 + this.EffectRatingBoostValue) * (1.0 + this.DamageBoost) * (1.0 + this.DodgeDeductionRate);
	}

	// Token: 0x06003C7F RID: 15487 RVA: 0x0017B778 File Offset: 0x00179B78
	public List<AttributeModifier> GetModifiers(AdventurerProfile profile)
	{
		if (profile.UnitClass == UnitClass.NightBlade)
		{
			return new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.EffectHitRating,
					ModificationType = ModificationType.Addition,
					Value = this.EffectRatingBoostValue,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Gear
				}
			};
		}
		return new List<AttributeModifier>();
	}

	// Token: 0x04002E3E RID: 11838
	public double EffectRatingBoostValue;

	// Token: 0x04002E3F RID: 11839
	public double DamageBoost;

	// Token: 0x04002E40 RID: 11840
	public double DodgeDeductionRate;

	// Token: 0x04002E41 RID: 11841
	public bool IsStar;
}
