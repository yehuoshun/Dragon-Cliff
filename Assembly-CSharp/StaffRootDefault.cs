using System;
using System.Collections.Generic;

// Token: 0x020005F8 RID: 1528
public class StaffRootDefault : ItemCategoryRootDefault
{
	// Token: 0x06002A0D RID: 10765 RVA: 0x0011DE04 File Offset: 0x0011C204
	public StaffRootDefault()
	{
	}

	// Token: 0x1700047F RID: 1151
	// (get) Token: 0x06002A0E RID: 10766 RVA: 0x0011DE0C File Offset: 0x0011C20C
	public override ResourceCategory Category
	{
		get
		{
			return ResourceCategory.Staff;
		}
	}

	// Token: 0x17000480 RID: 1152
	// (get) Token: 0x06002A0F RID: 10767 RVA: 0x0011DE10 File Offset: 0x0011C210
	public override List<AttributePotentialDescriptor> Descriptors
	{
		get
		{
			return new List<AttributePotentialDescriptor>
			{
				new AttributePotentialDescriptor(AttributeType.Intelligience, AttributePowerLevel.ExtremeHigh, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.EffectMastery, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.HitRateAdjustment, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DodgeRateAdjustment, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Vitality, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Agility, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.PhysicalResistance, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.FireResistanceResistance, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.PoisonResistance, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.IceResistance, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.ShadowResistance, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.LightningResistance, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DivineResistance, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Allresistances, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.CritRate, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.CritDamage, AttributePowerLevel.High, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.LifeOnHit, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.StunOnHit, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.TauntOnHit, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.ReflectiveDamage, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.TurnStartHeal, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.BattleStartHeal, AttributePowerLevel.Low, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Mining, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Logging, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Hunting, AttributePowerLevel.Medium, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.Resilience, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.DamageReduction, AttributePowerLevel.ExtremeLow, AttributeStyle.Beneficial),
				new AttributePotentialDescriptor(AttributeType.ReceivedHealEffectivenessChangeRate, AttributePowerLevel.Low, AttributeStyle.Beneficial),
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

	// Token: 0x06002A10 RID: 10768 RVA: 0x0011E134 File Offset: 0x0011C534
	public override List<AttributeType> GetDefaultGurranteedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.CritDamage
		};
	}

	// Token: 0x06002A11 RID: 10769 RVA: 0x0011E150 File Offset: 0x0011C550
	public override List<AttributeType> GetDefaultPrimaryAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Intelligience
		};
	}
}
