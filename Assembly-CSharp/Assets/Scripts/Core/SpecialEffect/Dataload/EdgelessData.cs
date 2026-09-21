using System;
using System.Collections.Generic;

namespace Assets.Scripts.Core.SpecialEffect.Dataload
{
	// Token: 0x020007EE RID: 2030
	[Serializable]
	public class EdgelessData : ISpecialEffectDataLoad, IAttributeModifierSpecialEffect
	{
		// Token: 0x06003AEA RID: 15082 RVA: 0x00178CCD File Offset: 0x001770CD
		public EdgelessData()
		{
		}

		// Token: 0x06003AEB RID: 15083 RVA: 0x00178CD5 File Offset: 0x001770D5
		public SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.Edgeless;
		}

		// Token: 0x06003AEC RID: 15084 RVA: 0x00178CDC File Offset: 0x001770DC
		public Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{penetration}", this.PenetrationRate.ToExpressionMultiply100()).Replace("{boost}", this.BoostRate.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x06003AED RID: 15085 RVA: 0x00178D2C File Offset: 0x0017712C
		public bool IsStarEffect()
		{
			return true;
		}

		// Token: 0x06003AEE RID: 15086 RVA: 0x00178D2F File Offset: 0x0017712F
		public double GetEffectPowerValue()
		{
			return this.BoostRate * this.PenetrationRate;
		}

		// Token: 0x06003AEF RID: 15087 RVA: 0x00178D40 File Offset: 0x00177140
		public List<AttributeModifier> GetModifiers(AdventurerProfile profile)
		{
			if (profile.UnitClass == UnitClass.Cube)
			{
				return new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.PhysicalPenetration,
						Value = this.PenetrationRate,
						ModificationType = ModificationType.Addition,
						AttributeModifierType = AttributeModifierType.Gear,
						Key = string.Empty
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.FirePenetration,
						Value = this.PenetrationRate,
						ModificationType = ModificationType.Addition,
						AttributeModifierType = AttributeModifierType.Gear,
						Key = string.Empty
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.IcePenetration,
						Value = this.PenetrationRate,
						ModificationType = ModificationType.Addition,
						AttributeModifierType = AttributeModifierType.Gear,
						Key = string.Empty
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.ShadowPenetration,
						Value = this.PenetrationRate,
						ModificationType = ModificationType.Addition,
						AttributeModifierType = AttributeModifierType.Gear,
						Key = string.Empty
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.PoisonPenetration,
						Value = this.PenetrationRate,
						ModificationType = ModificationType.Addition,
						AttributeModifierType = AttributeModifierType.Gear,
						Key = string.Empty
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.DivinePenetration,
						Value = this.PenetrationRate,
						ModificationType = ModificationType.Addition,
						AttributeModifierType = AttributeModifierType.Gear,
						Key = string.Empty
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.LighteningPenetration,
						Value = this.PenetrationRate,
						ModificationType = ModificationType.Addition,
						AttributeModifierType = AttributeModifierType.Gear,
						Key = string.Empty
					}
				};
			}
			return new List<AttributeModifier>();
		}

		// Token: 0x04002D70 RID: 11632
		public double PenetrationRate;

		// Token: 0x04002D71 RID: 11633
		public double BoostRate;
	}
}
