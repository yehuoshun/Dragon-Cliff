using System;
using System.Collections.Generic;

// Token: 0x020005F6 RID: 1526
public class RobeRootDefault : ItemCategoryRootDefault
{
	// Token: 0x06002A03 RID: 10755 RVA: 0x0011D71E File Offset: 0x0011BB1E
	public RobeRootDefault()
	{
	}

	// Token: 0x1700047B RID: 1147
	// (get) Token: 0x06002A04 RID: 10756 RVA: 0x0011D726 File Offset: 0x0011BB26
	public override ResourceCategory Category
	{
		get
		{
			return ResourceCategory.Robe;
		}
	}

	// Token: 0x1700047C RID: 1148
	// (get) Token: 0x06002A05 RID: 10757 RVA: 0x0011D72C File Offset: 0x0011BB2C
	public override List<AttributePotentialDescriptor> Descriptors
	{
		get
		{
			return new List<AttributePotentialDescriptor>
			{
				new AttributePotentialDescriptor(AttributeType.Intelligience, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.EffectMastery, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.HitRateAdjustment, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DodgeRateAdjustment, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Vitality, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Agility, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.PhysicalResistance, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.FireResistanceResistance, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.PoisonResistance, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.IceResistance, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.ShadowResistance, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.LightningResistance, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DivineResistance, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Allresistances, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.CritRate, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.CritDamage, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.LifeOnHit, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.TauntOnHit, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.StunOnHit, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.ReflectiveDamage, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.BattleStartHeal, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.TurnStartHeal, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Logging, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Mining, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Hunting, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Resilience, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DamageReduction, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.ReceivedHealEffectivenessChangeRate, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealFireDamageEffectivenessChangeRate, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealPhysicalDamageEffectivenessChangeRate, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealIceDamageEffectivenessChangeRate, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealShadowDamageEffectivenessChangeRate, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealPoisonDamageEffectivenessChangeRate, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealDivineDamageEffectivenessChangeRate, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DealLightningDamageEffectivenessChangeRate, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.SkillRageEfficiencyRate, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.HealingAbsorbRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.EffectHitRating, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.EffectResistanceRating, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
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

	// Token: 0x06002A06 RID: 10758 RVA: 0x0011DA50 File Offset: 0x0011BE50
	public override List<AttributeType> GetDefaultPrimaryAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Vitality
		};
	}

	// Token: 0x06002A07 RID: 10759 RVA: 0x0011DA6C File Offset: 0x0011BE6C
	public override List<AttributeType> GetDefaultGurranteedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Allresistances,
			AttributeType.Intelligience
		};
	}
}
