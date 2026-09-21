using System;
using System.Collections.Generic;

// Token: 0x020005F7 RID: 1527
public class SpearRootDefault : ItemCategoryRootDefault
{
	// Token: 0x06002A08 RID: 10760 RVA: 0x0011DA91 File Offset: 0x0011BE91
	public SpearRootDefault()
	{
	}

	// Token: 0x1700047D RID: 1149
	// (get) Token: 0x06002A09 RID: 10761 RVA: 0x0011DA99 File Offset: 0x0011BE99
	public override ResourceCategory Category
	{
		get
		{
			return ResourceCategory.Spear;
		}
	}

	// Token: 0x1700047E RID: 1150
	// (get) Token: 0x06002A0A RID: 10762 RVA: 0x0011DA9C File Offset: 0x0011BE9C
	public override List<AttributePotentialDescriptor> Descriptors
	{
		get
		{
			return new List<AttributePotentialDescriptor>
			{
				new AttributePotentialDescriptor(AttributeType.Strength, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.EffectMastery, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.HitRateAdjustment, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DodgeRateAdjustment, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Vitality, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Agility, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
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
				new AttributePotentialDescriptor(AttributeType.StunOnHit, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.LifeOnHit, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.TauntOnHit, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.ReflectiveDamage, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.BattleStartHeal, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.TurnStartHeal, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Hunting, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Logging, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Mining, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Resilience, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DamageReduction, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.ReceivedHealEffectivenessChangeRate, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealFireDamageEffectivenessChangeRate, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealPhysicalDamageEffectivenessChangeRate, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealIceDamageEffectivenessChangeRate, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealShadowDamageEffectivenessChangeRate, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealPoisonDamageEffectivenessChangeRate, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealDivineDamageEffectivenessChangeRate, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealLightningDamageEffectivenessChangeRate, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.SkillRageEfficiencyRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.HealingAbsorbRate, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.EffectHitRating, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
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

	// Token: 0x06002A0B RID: 10763 RVA: 0x0011DDC0 File Offset: 0x0011C1C0
	public override List<AttributeType> GetDefaultPrimaryAttributes(int itemTierNumber)
	{
		if (itemTierNumber <= 35)
		{
			return new List<AttributeType>
			{
				AttributeType.Strength
			};
		}
		return new List<AttributeType>
		{
			AttributeType.Strength,
			AttributeType.HitRateAdjustment
		};
	}

	// Token: 0x06002A0C RID: 10764 RVA: 0x0011DDFD File Offset: 0x0011C1FD
	public override List<AttributeType> GetDefaultGurranteedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>();
	}
}
