using System;
using System.Collections.Generic;

// Token: 0x020005F1 RID: 1521
public class AxeRootDefault : ItemCategoryRootDefault
{
	// Token: 0x060029E9 RID: 10729 RVA: 0x0011C96C File Offset: 0x0011AD6C
	public AxeRootDefault()
	{
	}

	// Token: 0x17000471 RID: 1137
	// (get) Token: 0x060029EA RID: 10730 RVA: 0x0011C974 File Offset: 0x0011AD74
	public override ResourceCategory Category
	{
		get
		{
			return ResourceCategory.Axe;
		}
	}

	// Token: 0x17000472 RID: 1138
	// (get) Token: 0x060029EB RID: 10731 RVA: 0x0011C978 File Offset: 0x0011AD78
	public override List<AttributePotentialDescriptor> Descriptors
	{
		get
		{
			return new List<AttributePotentialDescriptor>
			{
				new AttributePotentialDescriptor(AttributeType.Strength, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.EffectMastery, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.HitRateAdjustment, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DodgeRateAdjustment, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Vitality, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Agility, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.PhysicalResistance, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.FireResistanceResistance, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.PoisonResistance, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.IceResistance, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.ShadowResistance, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.LightningResistance, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DivineResistance, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Allresistances, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.CritRate, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.CritDamage, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.LifeOnHit, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.TauntOnHit, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.StunOnHit, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.ReflectiveDamage, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.BattleStartHeal, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.TurnStartHeal, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Mining, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Logging, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Hunting, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Resilience, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DamageReduction, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.ReceivedHealEffectivenessChangeRate, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealFireDamageEffectivenessChangeRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealPhysicalDamageEffectivenessChangeRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealIceDamageEffectivenessChangeRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealShadowDamageEffectivenessChangeRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealPoisonDamageEffectivenessChangeRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealDivineDamageEffectivenessChangeRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealLightningDamageEffectivenessChangeRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
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

	// Token: 0x060029EC RID: 10732 RVA: 0x0011CC9C File Offset: 0x0011B09C
	public override List<AttributeType> GetDefaultPrimaryAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Strength
		};
	}

	// Token: 0x060029ED RID: 10733 RVA: 0x0011CCB8 File Offset: 0x0011B0B8
	public override List<AttributeType> GetDefaultGurranteedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Vitality,
			AttributeType.CritRate
		};
	}
}
