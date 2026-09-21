using System;
using System.Collections.Generic;

// Token: 0x02000836 RID: 2102
[Serializable]
public class NightBladeEnhancementData : ISpecialEffectDataLoad, IAttributeModifierSpecialEffect
{
	// Token: 0x06003C4C RID: 15436 RVA: 0x0017AEE3 File Offset: 0x001792E3
	public NightBladeEnhancementData()
	{
	}

	// Token: 0x06003C4D RID: 15437 RVA: 0x0017AEEB File Offset: 0x001792EB
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.EnhancedNightBlade;
	}

	// Token: 0x06003C4E RID: 15438 RVA: 0x0017AEF4 File Offset: 0x001792F4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{boost}", this.EffectHitRating.ToExpression()).Replace("{decay}", this.EffectHitDecayRate.ToExpressionMultiply100()).Replace("{damage}", this.DamageRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003C4F RID: 15439 RVA: 0x0017AF59 File Offset: 0x00179359
	public bool IsStarEffect()
	{
		return true;
	}

	// Token: 0x06003C50 RID: 15440 RVA: 0x0017AF5C File Offset: 0x0017935C
	public double GetEffectPowerValue()
	{
		return (1.0 + this.DamageRate) * (1.0 + this.EffectHitRating) * (1.0 + this.EffectHitDecayRate);
	}

	// Token: 0x06003C51 RID: 15441 RVA: 0x0017AF90 File Offset: 0x00179390
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
					Value = this.EffectHitRating,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Gear
				}
			};
		}
		return new List<AttributeModifier>();
	}

	// Token: 0x04002E29 RID: 11817
	public double EffectHitRating;

	// Token: 0x04002E2A RID: 11818
	public double EffectHitDecayRate;

	// Token: 0x04002E2B RID: 11819
	public double DamageRate;
}
