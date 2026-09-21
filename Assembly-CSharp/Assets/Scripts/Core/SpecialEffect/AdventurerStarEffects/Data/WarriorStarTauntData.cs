using System;
using System.Collections.Generic;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x0200079C RID: 1948
	[Serializable]
	public class WarriorStarTauntData : ISpecialEffectDataLoad, IAttributeModifierSpecialEffect
	{
		// Token: 0x0600394B RID: 14667 RVA: 0x0017358E File Offset: 0x0017198E
		public WarriorStarTauntData()
		{
		}

		// Token: 0x0600394C RID: 14668 RVA: 0x00173596 File Offset: 0x00171996
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.WarriorStarTaunt;
		}

		// Token: 0x0600394D RID: 14669 RVA: 0x001735A0 File Offset: 0x001719A0
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{taunt}", this.TauntRate.ToExpressionMultiply100()).Replace("{rate}", this.NonResistRate.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x0600394E RID: 14670 RVA: 0x001735F0 File Offset: 0x001719F0
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x0600394F RID: 14671 RVA: 0x001735F3 File Offset: 0x001719F3
		public double GetEffectPowerValue()
		{
			return this.NonResistRate * this.TauntRate;
		}

		// Token: 0x06003950 RID: 14672 RVA: 0x00173604 File Offset: 0x00171A04
		public List<AttributeModifier> GetModifiers(AdventurerProfile profile)
		{
			if (profile.UnitClass == UnitClass.Warrior)
			{
				return new List<AttributeModifier>
				{
					new AttributeModifier
					{
						ModificationType = ModificationType.Addition,
						Value = this.TauntRate,
						AttributeModifierType = AttributeModifierType.Normal,
						AttributeType = AttributeType.TauntOnHit,
						Key = string.Empty
					}
				};
			}
			return new List<AttributeModifier>();
		}

		// Token: 0x04002C6D RID: 11373
		public double TauntRate;

		// Token: 0x04002C6E RID: 11374
		public double NonResistRate;
	}
}
