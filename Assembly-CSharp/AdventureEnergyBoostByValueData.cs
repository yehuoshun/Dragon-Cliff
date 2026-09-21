using System;
using System.Collections.Generic;

// Token: 0x020007AD RID: 1965
[Serializable]
public class AdventureEnergyBoostByValueData : ISpecialEffectDataLoad, IAttributeModifierSpecialEffect
{
	// Token: 0x0600399B RID: 14747 RVA: 0x0017682C File Offset: 0x00174C2C
	public AdventureEnergyBoostByValueData()
	{
	}

	// Token: 0x0600399C RID: 14748 RVA: 0x00176834 File Offset: 0x00174C34
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.AdventureEnergyBoostByValue;
	}

	// Token: 0x0600399D RID: 14749 RVA: 0x0017683C File Offset: 0x00174C3C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{value}", (this.Value * 4.0).ToExpression()).Replace("{boost}", (this.Value * 50.0).ToExpression());
		return description;
	}

	// Token: 0x0600399E RID: 14750 RVA: 0x001768A0 File Offset: 0x00174CA0
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x0600399F RID: 14751 RVA: 0x001768A3 File Offset: 0x00174CA3
	public double GetEffectPowerValue()
	{
		return this.Value;
	}

	// Token: 0x060039A0 RID: 14752 RVA: 0x001768AC File Offset: 0x00174CAC
	public List<AttributeModifier> GetModifiers(AdventurerProfile profile)
	{
		if (profile.UnitClass.GetConfiguration().CorrespondingClassStyle == UnitClassStyle.PhysicalSupporter || profile.UnitClass.GetConfiguration().CorrespondingClassStyle == UnitClassStyle.SpellSupporter)
		{
			return new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.EffectHitRating,
					ModificationType = ModificationType.Addition,
					Value = this.Value * 50.0,
					AttributeModifierType = AttributeModifierType.Gear,
					Key = string.Empty
				}
			};
		}
		return new List<AttributeModifier>();
	}

	// Token: 0x04002C98 RID: 11416
	public double Value;
}
