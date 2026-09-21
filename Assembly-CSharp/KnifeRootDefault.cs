using System;
using System.Collections.Generic;

// Token: 0x020005F3 RID: 1523
public class KnifeRootDefault : ItemCategoryRootDefault
{
	// Token: 0x060029F4 RID: 10740 RVA: 0x0011CCDA File Offset: 0x0011B0DA
	public KnifeRootDefault()
	{
	}

	// Token: 0x17000475 RID: 1141
	// (get) Token: 0x060029F5 RID: 10741 RVA: 0x0011CCE2 File Offset: 0x0011B0E2
	public override ResourceCategory Category
	{
		get
		{
			return ResourceCategory.Knife;
		}
	}

	// Token: 0x17000476 RID: 1142
	// (get) Token: 0x060029F6 RID: 10742 RVA: 0x0011CCE8 File Offset: 0x0011B0E8
	public override List<AttributePotentialDescriptor> Descriptors
	{
		get
		{
			return new List<AttributePotentialDescriptor>
			{
				new AttributePotentialDescriptor(AttributeType.Strength, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.EffectMastery, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.HitRateAdjustment, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DodgeRateAdjustment, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Vitality, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Agility, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.PhysicalResistance, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.FireResistanceResistance, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.PoisonResistance, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.IceResistance, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.ShadowResistance, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.LightningResistance, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DivineResistance, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Allresistances, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.CritRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.CritDamage, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.LifeOnHit, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.StunOnHit, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.TauntOnHit, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.ReflectiveDamage, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.BattleStartHeal, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.TurnStartHeal, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Mining, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Logging, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Hunting, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Resilience, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DamageReduction, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.ReceivedHealEffectivenessChangeRate, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealFireDamageEffectivenessChangeRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealPhysicalDamageEffectivenessChangeRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealIceDamageEffectivenessChangeRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealShadowDamageEffectivenessChangeRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealPoisonDamageEffectivenessChangeRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealDivineDamageEffectivenessChangeRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealLightningDamageEffectivenessChangeRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.SkillRageEfficiencyRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.HealingAbsorbRate, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.EffectHitRating, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.EffectResistanceRating, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.PhysicalPenetration, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.FirePenetration, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.IcePenetration, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.ShadowPenetration, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.PoisonPenetration, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DivinePenetration, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.LighteningPenetration, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial)
			};
		}
	}

	// Token: 0x060029F7 RID: 10743 RVA: 0x0011D00C File Offset: 0x0011B40C
	public override List<AttributeType> GetDefaultGurranteedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Agility
		};
	}

	// Token: 0x060029F8 RID: 10744 RVA: 0x0011D028 File Offset: 0x0011B428
	public override List<AttributeType> GetDefaultPrimaryAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Strength
		};
	}
}
