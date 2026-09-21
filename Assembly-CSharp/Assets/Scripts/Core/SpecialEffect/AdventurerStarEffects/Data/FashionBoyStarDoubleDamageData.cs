using System;
using System.Collections.Generic;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000787 RID: 1927
	[Serializable]
	public class FashionBoyStarDoubleDamageData : ISpecialEffectDataLoad, IAttributeModifierSpecialEffect
	{
		// Token: 0x060038DF RID: 14559 RVA: 0x00172C62 File Offset: 0x00171062
		public FashionBoyStarDoubleDamageData()
		{
		}

		// Token: 0x060038E0 RID: 14560 RVA: 0x00172C6A File Offset: 0x0017106A
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.FashionBoyStarDoubleDamage;
		}

		// Token: 0x060038E1 RID: 14561 RVA: 0x00172C74 File Offset: 0x00171074
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x060038E2 RID: 14562 RVA: 0x00172CAF File Offset: 0x001710AF
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x060038E3 RID: 14563 RVA: 0x00172CB2 File Offset: 0x001710B2
		public double GetEffectPowerValue()
		{
			return this.Chance;
		}

		// Token: 0x060038E4 RID: 14564 RVA: 0x00172CBC File Offset: 0x001710BC
		public List<AttributeModifier> GetModifiers(AdventurerProfile profile)
		{
			if (profile.UnitClass == UnitClass.FashionBoy)
			{
				return new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.HitRateAdjustment,
						ModificationType = ModificationType.Addition,
						Value = 0.2,
						AttributeModifierType = AttributeModifierType.Gear,
						Key = string.Empty
					}
				};
			}
			return new List<AttributeModifier>();
		}

		// Token: 0x04002C53 RID: 11347
		public double Chance;
	}
}
