using System;
using System.Collections.Generic;

// Token: 0x02000826 RID: 2086
[Serializable]
public class KillerEnhancementData : ISpecialEffectDataLoad, IAttributeModifierSpecialEffect
{
	// Token: 0x06003BFB RID: 15355 RVA: 0x0017A738 File Offset: 0x00178B38
	public KillerEnhancementData()
	{
	}

	// Token: 0x06003BFC RID: 15356 RVA: 0x0017A740 File Offset: 0x00178B40
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.KillerEnhancement;
	}

	// Token: 0x06003BFD RID: 15357 RVA: 0x0017A748 File Offset: 0x00178B48
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{killerboost}", this.KillerDodgeRateBoost.ToExpressionMultiply100()).Replace("{partyboost}", this.PartyDodgeRateBoost.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003BFE RID: 15358 RVA: 0x0017A798 File Offset: 0x00178B98
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003BFF RID: 15359 RVA: 0x0017A7A0 File Offset: 0x00178BA0
	public double GetEffectPowerValue()
	{
		return (1.0 + this.KillerDodgeRateBoost) * (1.0 + this.PartyDodgeRateBoost);
	}

	// Token: 0x06003C00 RID: 15360 RVA: 0x0017A7C4 File Offset: 0x00178BC4
	public List<AttributeModifier> GetModifiers(AdventurerProfile profile)
	{
		if (profile.UnitClass == UnitClass.Killer)
		{
			return new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.DodgeRateAdjustment,
					ModificationType = ModificationType.Addition,
					Value = this.KillerDodgeRateBoost,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Gear
				}
			};
		}
		return new List<AttributeModifier>();
	}

	// Token: 0x04002DFB RID: 11771
	public double KillerDodgeRateBoost;

	// Token: 0x04002DFC RID: 11772
	public double PartyDodgeRateBoost;

	// Token: 0x04002DFD RID: 11773
	public bool IsStar;
}
