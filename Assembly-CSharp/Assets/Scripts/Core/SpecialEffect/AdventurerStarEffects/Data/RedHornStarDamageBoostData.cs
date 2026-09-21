using System;
using System.Collections.Generic;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data
{
	// Token: 0x02000793 RID: 1939
	[Serializable]
	public class RedHornStarDamageBoostData : ISpecialEffectDataLoad, IAttributeModifierSpecialEffect
	{
		// Token: 0x0600391C RID: 14620 RVA: 0x0017313E File Offset: 0x0017153E
		public RedHornStarDamageBoostData()
		{
		}

		// Token: 0x0600391D RID: 14621 RVA: 0x00173146 File Offset: 0x00171546
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.RedHornStarDamageBoost;
		}

		// Token: 0x0600391E RID: 14622 RVA: 0x00173150 File Offset: 0x00171550
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x0600391F RID: 14623 RVA: 0x0017318B File Offset: 0x0017158B
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x06003920 RID: 14624 RVA: 0x0017318E File Offset: 0x0017158E
		public double GetEffectPowerValue()
		{
			return this.Rate;
		}

		// Token: 0x06003921 RID: 14625 RVA: 0x00173198 File Offset: 0x00171598
		public List<AttributeModifier> GetModifiers(AdventurerProfile profile)
		{
			if (profile.UnitClass == UnitClass.RedHorn)
			{
				return new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.HitRateAdjustment,
						ModificationType = ModificationType.Addition,
						Value = 0.3,
						AttributeModifierType = AttributeModifierType.Gear,
						Key = string.Empty
					}
				};
			}
			return new List<AttributeModifier>();
		}

		// Token: 0x04002C63 RID: 11363
		public double Rate;
	}
}
