using System;
using System.Collections.Generic;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000795 RID: 1941
	[Serializable]
	public class SnowMaidenStarEffectData : ISpecialEffectDataLoad, IAttributeModifierSpecialEffect
	{
		// Token: 0x06003927 RID: 14631 RVA: 0x0017325A File Offset: 0x0017165A
		public SnowMaidenStarEffectData()
		{
		}

		// Token: 0x06003928 RID: 14632 RVA: 0x00173262 File Offset: 0x00171662
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.SnowMaidenStarEffect;
		}

		// Token: 0x06003929 RID: 14633 RVA: 0x0017326C File Offset: 0x0017166C
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{levelrate}", this.PerLevelRate.ToString()).Replace("{extrarate}", this.ExtraRate.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x0600392A RID: 14634 RVA: 0x001732C2 File Offset: 0x001716C2
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x0600392B RID: 14635 RVA: 0x001732C5 File Offset: 0x001716C5
		public double GetEffectPowerValue()
		{
			return (double)this.PerLevelRate;
		}

		// Token: 0x0600392C RID: 14636 RVA: 0x001732D0 File Offset: 0x001716D0
		public List<AttributeModifier> GetModifiers(AdventurerProfile profile)
		{
			if (profile.UnitClass == UnitClass.SnowMaiden)
			{
				return new List<AttributeModifier>
				{
					new AttributeModifier
					{
						Value = (double)(this.PerLevelRate * profile.GetLevel()),
						AttributeModifierType = AttributeModifierType.Normal,
						ModificationType = ModificationType.Addition,
						AttributeType = AttributeType.EffectHitRating,
						Key = string.Empty
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.EffectHitRating,
						ModificationType = ModificationType.Multiplication,
						Value = this.ExtraRate,
						AttributeModifierType = AttributeModifierType.Gear,
						Key = string.Empty
					}
				};
			}
			return new List<AttributeModifier>();
		}

		// Token: 0x04002C65 RID: 11365
		public int PerLevelRate;

		// Token: 0x04002C66 RID: 11366
		public double ExtraRate;
	}
}
