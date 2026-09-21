using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x0200041C RID: 1052
public static class TalentExtensions
{
	// Token: 0x06001CE3 RID: 7395 RVA: 0x000C4B6C File Offset: 0x000C2F6C
	public static bool IsAvaliable(this IAdventurerTalent talent, AdventurerProfile profile)
	{
		AdventurerTalentTier tier = talent.GetTier();
		if (tier == AdventurerTalentTier.First)
		{
			return (from t in profile.Talents
			where t.GetTier() == AdventurerTalentTier.First
			select t).Sum((IAdventurerTalent t) => t.GetCurrentLevel()) < 10;
		}
		if (tier == AdventurerTalentTier.Second)
		{
			bool result;
			if ((from t in profile.Talents
			where t.GetTier() == AdventurerTalentTier.First
			select t).Sum((IAdventurerTalent t) => t.GetCurrentLevel()) >= 10)
			{
				result = ((from t in profile.Talents
				where t.GetTier() == AdventurerTalentTier.Second
				select t).Sum((IAdventurerTalent t) => t.GetCurrentLevel()) == 0);
			}
			else
			{
				result = false;
			}
			return result;
		}
		if (tier == AdventurerTalentTier.Third)
		{
			bool result2;
			if ((from t in profile.Talents
			where t.GetTier() == AdventurerTalentTier.Second
			select t).Sum((IAdventurerTalent t) => t.GetCurrentLevel()) >= 1)
			{
				result2 = ((from t in profile.Talents
				where t.GetTier() == AdventurerTalentTier.Third
				select t).Sum((IAdventurerTalent t) => t.GetCurrentLevel()) < 5);
			}
			else
			{
				result2 = false;
			}
			return result2;
		}
		if (tier == AdventurerTalentTier.Forth)
		{
			bool result3;
			if ((from t in profile.Talents
			where t.GetTier() == AdventurerTalentTier.Third
			select t).Sum((IAdventurerTalent t) => t.GetCurrentLevel()) >= 5)
			{
				result3 = ((from t in profile.Talents
				where t.GetTier() == AdventurerTalentTier.Forth
				select t).Sum((IAdventurerTalent t) => t.GetCurrentLevel()) < 1);
			}
			else
			{
				result3 = false;
			}
			return result3;
		}
		return false;
	}

	// Token: 0x06001CE4 RID: 7396 RVA: 0x000C4DD0 File Offset: 0x000C31D0
	public static int GetTalentCostPerLevel(this IAdventurerTalent talent)
	{
		AdventurerTalentTier tier = talent.GetTier();
		if (tier == AdventurerTalentTier.First || tier == AdventurerTalentTier.Third)
		{
			return 1;
		}
		if (tier == AdventurerTalentTier.Second)
		{
			return 1;
		}
		return 1;
	}

	// Token: 0x06001CE5 RID: 7397 RVA: 0x000C4DFE File Offset: 0x000C31FE
	public static bool CostMet(this IAdventurerTalent talent, AdventurerProfile profile)
	{
		return profile.TalentPoints >= talent.GetTalentCostPerLevel();
	}

	// Token: 0x06001CE6 RID: 7398 RVA: 0x000C4E14 File Offset: 0x000C3214
	public static void Upgrade(this IAdventurerTalent talent, AdventurerProfile profile)
	{
		if (talent.IsAvaliable(profile) && talent.CostMet(profile) && talent.GetCurrentLevel() < talent.GetMaxLevel())
		{
			profile.TalentPoints -= talent.GetTalentCostPerLevel();
			talent.UpgradeLogic(profile);
		}
	}

	// Token: 0x06001CE7 RID: 7399 RVA: 0x000C4E64 File Offset: 0x000C3264
	public static void Downgrade(this IAdventurerTalent talent, AdventurerProfile profile)
	{
		if (talent.GetCurrentLevel() > 0)
		{
			profile.TalentPoints += talent.GetTalentCostPerLevel();
			talent.DowngradeLogic(profile);
		}
	}

	// Token: 0x06001CE8 RID: 7400 RVA: 0x000C4E8C File Offset: 0x000C328C
	public static void Reset(this IAdventurerTalent talent, AdventurerProfile profile)
	{
		if (talent.GetCurrentLevel() > 0)
		{
			profile.TalentPoints += talent.GetTalentCostPerLevel() * talent.GetCurrentLevel();
			talent.ResetLogic(profile);
		}
	}

	// Token: 0x06001CE9 RID: 7401 RVA: 0x000C4EBC File Offset: 0x000C32BC
	public static double GetMainSkillDamageBoostRate(this IBattleEffectSource effectSource)
	{
		if (effectSource is AdventureUnitSkill)
		{
			AdventureUnitSkill adventureUnitSkill = effectSource as AdventureUnitSkill;
			if (adventureUnitSkill.Skill.CommandType == SkillCommandType.Main && adventureUnitSkill.GetActiveTalents().OfType<ElementalDamageIncreaseTalent>().Any<ElementalDamageIncreaseTalent>())
			{
				return adventureUnitSkill.GetActiveTalents().OfType<ElementalDamageIncreaseTalent>().Sum((ElementalDamageIncreaseTalent t) => t.GetRate());
			}
		}
		return 0.0;
	}

	// Token: 0x06001CEA RID: 7402 RVA: 0x000C4F38 File Offset: 0x000C3338
	public static Description GetDescription(this IAdventurerTalent talent)
	{
		TalentLocalization talent2 = LocalizationSession.instance.LocalizationManager.GetTalent(talent.GetCorrespondingType());
		if (talent is ElementalDamageIncreaseTalent)
		{
			ElementalDamageIncreaseTalent elementalDamageIncreaseTalent = talent as ElementalDamageIncreaseTalent;
			talent2.Description = talent2.Description.Replace("{rate}", elementalDamageIncreaseTalent.GetRate().ToExpressionMultiply100());
		}
		if (talent is AttributeDebuffByRateOnHitTalent)
		{
			AttributeDebuffByRateOnHitTalent attributeDebuffByRateOnHitTalent = talent as AttributeDebuffByRateOnHitTalent;
			if (attributeDebuffByRateOnHitTalent.GetDebuffs().Any<BoostSetting>())
			{
				BoostSetting boostSetting = attributeDebuffByRateOnHitTalent.GetDebuffs().First<BoostSetting>();
				talent2.Description = talent2.Description.ReplaceToBuilder("{type}", boostSetting.BoostAttribute.GetDescription().Title).Replace("{rate}", boostSetting.BoostValue.ToExpressionMultiply100()).Replace("{stack}", attributeDebuffByRateOnHitTalent.GetMaxStack().ToString()).Replace("{seconds}", attributeDebuffByRateOnHitTalent.GetLastingSeconds().ToString()).ToString();
			}
		}
		if (talent is DispelPositiveEffectOnHitTalent)
		{
			DispelPositiveEffectOnHitTalent dispelPositiveEffectOnHitTalent = talent as DispelPositiveEffectOnHitTalent;
			talent2.Description = talent2.Description.Replace("{chance}", dispelPositiveEffectOnHitTalent.GetChance().ToExpressionMultiply100()).Replace("{number}", dispelPositiveEffectOnHitTalent.GetNumberOfDispels().ToString());
		}
		if (talent is FireBreathFireSeedEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", FireBreathFireSeedEnhancementTalent.Rate.ToExpressionMultiply100());
		}
		if (talent is NegativeEffectsRefreshTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", NegativeEffectsRefreshTalent.Counts.ToString());
		}
		if (talent is AttributeBoostOnKillTalentByRate)
		{
			AttributeBoostOnKillTalentByRate attributeBoostOnKillTalentByRate = talent as AttributeBoostOnKillTalentByRate;
			BoostSetting boostSetting2 = attributeBoostOnKillTalentByRate.GetBoosts().FirstOrDefault<BoostSetting>();
			if (boostSetting2 != null)
			{
				talent2.Description = talent2.Description.ReplaceToBuilder("{type}", boostSetting2.BoostAttribute.GetDescription().Title).Replace("{rate}", boostSetting2.BoostValue.ToExpressionMultiply100()).Replace("{stack}", attributeBoostOnKillTalentByRate.GetMaxStack().ToString()).ToString();
			}
		}
		if (talent is PushOnHitTalent)
		{
			PushOnHitTalent pushOnHitTalent = talent as PushOnHitTalent;
			talent2.Description = talent2.Description.Replace("{rate}", pushOnHitTalent.GetRate().ToExpressionMultiply100());
		}
		if (talent is FirebreathDamageAbsorbTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", FirebreathDamageAbsorbTalent.Rate.ToExpressionMultiply100());
		}
		if (talent is AttributeDebuffByValueOnHitTalent)
		{
			AttributeDebuffByValueOnHitTalent attributeDebuffByValueOnHitTalent = talent as AttributeDebuffByValueOnHitTalent;
			BoostSetting boostSetting3 = attributeDebuffByValueOnHitTalent.GetDebuffs().FirstOrDefault<BoostSetting>();
			if (boostSetting3 != null)
			{
				talent2.Description = talent2.Description.ReplaceToBuilder("{type}", boostSetting3.BoostAttribute.GetDescription().Title).Replace("{rate}", (!boostSetting3.BoostAttribute.IsPercentageValue()) ? boostSetting3.BoostValue.ToExpression() : (boostSetting3.BoostValue.ToExpressionMultiply100() + "%")).Replace("{stack}", attributeDebuffByValueOnHitTalent.GetMaxStack().ToString()).Replace("{seconds}", attributeDebuffByValueOnHitTalent.GetLastingSeconds().ToString()).ToString();
			}
		}
		if (talent is SkillExtraTargetTalent)
		{
			SkillExtraTargetTalent skillExtraTargetTalent = talent as SkillExtraTargetTalent;
			talent2.Description = talent2.Description.Replace("{number}", skillExtraTargetTalent.GetExtra().ToString());
		}
		if (talent is FreezeEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{seconds}", FreezeEnhancementTalent.LastingSecondsToReplace.ToString());
		}
		if (talent is ArcaneCritEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", ArcaneCritEnhancementTalent.Rate.ToExpressionMultiply100());
		}
		if (talent is SelfHealOnKillTalent)
		{
			SelfHealOnKillTalent selfHealOnKillTalent = talent as SelfHealOnKillTalent;
			talent2.Description = talent2.Description.Replace("{rate}", selfHealOnKillTalent.GetHealrate().ToExpressionMultiply100());
		}
		if (talent is ShadowSacrificeExplosionEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", ShadowSacrificeExplosionEnhancementTalent.ExtraRate.ToExpressionMultiply100());
		}
		if (talent is ShadowSacrificeStunEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{seconds}", ShadowSacrificeStunEnhancementTalent.StunSeconds.ToString());
		}
		if (talent is ShadowSacrificeHealOnExpTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", ShadowSacrificeHealOnExpTalent.HealRate.ToExpressionMultiply100());
		}
		if (talent is SeedsOfSinPetPushTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", SeedsOfSinPetPushTalent.PushRate.ToExpressionMultiply100());
		}
		if (talent is DivineHammerDamageShiftTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", DivineHammerDamageShiftTalent.ExtraDamageRate.ToExpressionMultiply100());
		}
		if (talent is AttributeBoostOnHealByRateTalent)
		{
			AttributeBoostOnHealByRateTalent attributeBoostOnHealByRateTalent = talent as AttributeBoostOnHealByRateTalent;
			BoostSetting boostSetting4 = attributeBoostOnHealByRateTalent.GetBoosts().FirstOrDefault<BoostSetting>();
			if (boostSetting4 != null)
			{
				talent2.Description = talent2.Description.ReplaceToBuilder("{type}", boostSetting4.BoostAttribute.GetDescription().Title).Replace("{rate}", boostSetting4.BoostValue.ToExpressionMultiply100()).Replace("{stack}", attributeBoostOnHealByRateTalent.GetMaxStack().ToString()).ToString();
			}
		}
		if (talent is PrayDispelEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{chance}", PrayDispelEnhancementTalent.Chance.ToExpressionMultiply100()).Replace("{number}", PrayDispelEnhancementTalent.DispelCounts.ToString());
		}
		if (talent is StunOnDamageTalent)
		{
			StunOnDamageTalent stunOnDamageTalent = talent as StunOnDamageTalent;
			talent2.Description = talent2.Description.Replace("{seconds}", stunOnDamageTalent.GetStunSeconds().ToString());
		}
		if (talent is AssassinDispelEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", AssassinDispelEnhancementTalent.NumberOfDispel.ToString());
		}
		if (talent is ShieldOnKillTalent)
		{
			ShieldOnKillTalent shieldOnKillTalent = talent as ShieldOnKillTalent;
			talent2.Description = talent2.Description.Replace("{number}", shieldOnKillTalent.GetNumberOfShields().ToString());
		}
		if (talent is StealSoulDispelEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", StealSoulDispelEnhancementTalent.NumberOfDispels.ToString());
		}
		if (talent is ShadowlessDamageEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", ShadowlessDamageEnhancementTalent.ExtraRate.ToExpressionMultiply100());
		}
		if (talent is AttributeBoostMemberOnKillBasedOnSelfRateTalent)
		{
			AttributeBoostMemberOnKillBasedOnSelfRateTalent attributeBoostMemberOnKillBasedOnSelfRateTalent = talent as AttributeBoostMemberOnKillBasedOnSelfRateTalent;
			talent2.Description = talent2.Description.Replace("{type}", attributeBoostMemberOnKillBasedOnSelfRateTalent.GetBoostType().GetDescription().Title).Replace("{rate}", attributeBoostMemberOnKillBasedOnSelfRateTalent.GetBoostRate().ToExpressionMultiply100());
		}
		if (talent is TauntDamageEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", TauntDamageEnhancementTalent.DamageIncreaseRate.ToExpressionMultiply100());
		}
		if (talent is TauntTimeEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{seconds}", TauntTimeEnhancementTalent.TauntTime.ToString());
		}
		if (talent is TauntDebuffTalent)
		{
			talent2.Description = talent2.Description.Replace("{type}", TauntDebuffTalent.Type.GetDescription().Title).Replace("{rate}", TauntDebuffTalent.ReductionRate.ToExpressionMultiply100());
		}
		if (talent is RoarTargetEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", RoarTargetEnhancementTalent.PenetrationDecayRate.ToExpressionMultiply100());
		}
		if (talent is ScornChanceEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{chance}", ScornChanceEnhancementTalent.Rate.ToExpressionMultiply100());
		}
		if (talent is BrightCircleBoostEnhancementTalent)
		{
			BrightCircleBoostEnhancementTalent brightCircleBoostEnhancementTalent = talent as BrightCircleBoostEnhancementTalent;
			talent2.Description = talent2.Description.Replace("{type}", brightCircleBoostEnhancementTalent.GetAttributeType().GetDescription().Title).Replace("{rate}", brightCircleBoostEnhancementTalent.GetRate().ToExpressionMultiply100());
		}
		if (talent is BrightCircleDispelEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", BrightCircleDispelEnhancementTalent.NumberOfDispels.ToString());
		}
		if (talent is BurningHeartDispelEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{chance}", BurningHeartDispelEnhancementTalent.Chance.ToExpressionMultiply100()).Replace("{number}", BurningHeartDispelEnhancementTalent.NumberOfDispels.ToString());
		}
		if (talent is GrandStrategyDamageEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", GrandStrategyDamageEnhancementTalent.ExtraDamageRate.ToExpressionMultiply100());
		}
		if (talent is GrandStrategyDispelEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{chance}", GrandStrategyDispelEnhancementTalent.Chance.ToExpressionMultiply100()).Replace("{number}", GrandStrategyDispelEnhancementTalent.Dispels.ToString());
		}
		if (talent is EmbraceShieldMemberOnKillTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", EmbraceShieldMemberOnKillTalent.NumberOfShields.ToString());
		}
		if (talent is DodgeEnhancementTalent)
		{
			DodgeEnhancementTalent dodgeEnhancementTalent = talent as DodgeEnhancementTalent;
			talent2.Description = talent2.Description.Replace("{rate}", DodgeEnhancementTalent.Rate.ToExpressionMultiply100()).Replace("{total}", (DodgeEnhancementTalent.Rate * (double)dodgeEnhancementTalent.GetCurrentLevel()).ToExpressionMultiply100());
		}
		if (talent is LifeRegenTalent)
		{
			LifeRegenTalent lifeRegenTalent = talent as LifeRegenTalent;
			talent2.Description = talent2.Description.ReplaceToBuilder("{minimum}", LifeRegenTalent.MinimumLife.ToExpressionMultiply100()).Replace("{total}", (LifeRegenTalent.RegenRate * (double)lifeRegenTalent.GetCurrentLevel()).ToExpressionMultiply100()).Replace("{rate}", LifeRegenTalent.RegenRate.ToExpressionMultiply100()).Replace("{seconds}", LifeRegenTalent.RegenSeconds.ToString()).ToString();
		}
		if (talent is VitalityEnhancementTalent)
		{
			VitalityEnhancementTalent vitalityEnhancementTalent = talent as VitalityEnhancementTalent;
			talent2.Description = talent2.Description.Replace("{rate}", VitalityEnhancementTalent.Rate.ToExpressionMultiply100()).Replace("{total}", (VitalityEnhancementTalent.Rate * (double)vitalityEnhancementTalent.GetCurrentLevel()).ToExpressionMultiply100());
		}
		if (talent is TauntEnhancementTalent)
		{
			TauntEnhancementTalent tauntEnhancementTalent = talent as TauntEnhancementTalent;
			talent2.Description = talent2.Description.Replace("{rate}", TauntEnhancementTalent.Rate.ToExpressionMultiply100()).Replace("{total}", (TauntEnhancementTalent.Rate * (double)tauntEnhancementTalent.GetCurrentLevel()).ToExpressionMultiply100());
		}
		if (talent is FurySpeedTalent)
		{
			FurySpeedTalent furySpeedTalent = talent as FurySpeedTalent;
			talent2.Description = talent2.Description.Replace("{rate}", FurySpeedTalent.Rate.ToExpressionMultiply100()).Replace("{total}", (FurySpeedTalent.Rate * (double)furySpeedTalent.GetCurrentLevel()).ToExpressionMultiply100());
		}
		if (talent is KillerPowerTalent)
		{
			KillerPowerTalent killerPowerTalent = talent as KillerPowerTalent;
			talent2.Description = talent2.Description.Replace("{rate}", KillerPowerTalent.Rate.ToExpressionMultiply100()).Replace("{total}", (KillerPowerTalent.Rate * (double)killerPowerTalent.GetCurrentLevel()).ToExpressionMultiply100());
		}
		if (talent is EnhancedEffectMasteryTalent)
		{
			EnhancedEffectMasteryTalent enhancedEffectMasteryTalent = talent as EnhancedEffectMasteryTalent;
			talent2.Description = talent2.Description.Replace("{rate}", EnhancedEffectMasteryTalent.Rate.ToExpressionMultiply100()).Replace("{total}", (EnhancedEffectMasteryTalent.Rate * (double)enhancedEffectMasteryTalent.GetCurrentLevel()).ToExpressionMultiply100());
		}
		if (talent is EnhancedResistancesTalent)
		{
			EnhancedResistancesTalent enhancedResistancesTalent = talent as EnhancedResistancesTalent;
			talent2.Description = talent2.Description.Replace("{rate}", EnhancedResistancesTalent.Rate.ToExpressionMultiply100()).Replace("{total}", (EnhancedResistancesTalent.Rate * (double)enhancedResistancesTalent.GetCurrentLevel()).ToExpressionMultiply100());
		}
		if (talent is HitRateEnhancementTalent)
		{
			HitRateEnhancementTalent hitRateEnhancementTalent = talent as HitRateEnhancementTalent;
			talent2.Description = talent2.Description.Replace("{rate}", HitRateEnhancementTalent.Rate.ToExpressionMultiply100()).Replace("{total}", (HitRateEnhancementTalent.Rate * (double)hitRateEnhancementTalent.CurrentLevel).ToExpressionMultiply100());
		}
		if (talent is NegativeEffectEnhancementTalent)
		{
			NegativeEffectEnhancementTalent negativeEffectEnhancementTalent = talent as NegativeEffectEnhancementTalent;
			talent2.Description = talent2.Description.Replace("{rate}", NegativeEffectEnhancementTalent.Rate.ToExpressionMultiply100()).Replace("{total}", (NegativeEffectEnhancementTalent.Rate * (double)negativeEffectEnhancementTalent.CurrentLevel).ToExpressionMultiply100());
		}
		if (talent is ElementDamageEnhancementTalent)
		{
			ElementDamageEnhancementTalent elementDamageEnhancementTalent = talent as ElementDamageEnhancementTalent;
			talent2.Description = talent2.Description.Replace("{rate}", ElementDamageEnhancementTalent.Rate.ToExpressionMultiply100()).Replace("{total}", (ElementDamageEnhancementTalent.Rate * (double)elementDamageEnhancementTalent.CurrentLevel).ToExpressionMultiply100());
		}
		if (talent is FireShieldTalent)
		{
			FireShieldTalent fireShieldTalent = talent as FireShieldTalent;
			talent2.Description = talent2.Description.Replace("{rate}", FireShieldTalent.Rate.ToExpressionMultiply100()).Replace("{total}", (FireShieldTalent.Rate * (double)fireShieldTalent.CurrentLevel).ToExpressionMultiply100());
		}
		if (talent is RestrictionOfTimeTalent)
		{
			RestrictionOfTimeTalent restrictionOfTimeTalent = talent as RestrictionOfTimeTalent;
			talent2.Description = talent2.Description.ReplaceToBuilder("{seconds}", RestrictionOfTimeTalent.HealSeconds.ToString()).Replace("{dodgerate}", RestrictionOfTimeTalent.DodgeRateBoost.ToExpressionMultiply100()).Replace("{dodgetotal}", (RestrictionOfTimeTalent.DodgeRateBoost * (double)restrictionOfTimeTalent.CurrentLevel).ToExpressionMultiply100()).Replace("{healrate}", RestrictionOfTimeTalent.HealRate.ToExpressionMultiply100()).Replace("{healtotal}", (RestrictionOfTimeTalent.HealRate * (double)restrictionOfTimeTalent.CurrentLevel).ToExpressionMultiply100()).ToString();
		}
		if (talent is ShadowOfGhostTalent)
		{
			ShadowOfGhostTalent shadowOfGhostTalent = talent as ShadowOfGhostTalent;
			talent2.Description = talent2.Description.Replace("{seconds}", ShadowOfGhostTalent.Seconds.ToString()).Replace("{rate}", ShadowOfGhostTalent.Rate.ToExpressionMultiply100()).Replace("{total}", (ShadowOfGhostTalent.Rate * (double)shadowOfGhostTalent.CurrentLevel).ToExpressionMultiply100());
		}
		if (talent is ProtectorTalent)
		{
			ProtectorTalent protectorTalent = talent as ProtectorTalent;
			talent2.Description = talent2.Description.Replace("{reduction}", ProtectorTalent.DamageShareRate.ToExpressionMultiply100()).Replace("{rate}", ProtectorTalent.DamageRateReductionPerLevel.ToExpressionMultiply100()).Replace("{total}", (protectorTalent.CurrentLevel <= 0) ? "0" : (ProtectorTalent.DamageRateStart - ProtectorTalent.DamageRateReductionPerLevel * (double)protectorTalent.CurrentLevel).ToExpressionMultiply100());
		}
		if (talent is PoisonEnhancementTalent)
		{
			PoisonEnhancementTalent poisonEnhancementTalent = talent as PoisonEnhancementTalent;
			talent2.Description = talent2.Description.Replace("{rate}", PoisonEnhancementTalent.DamagePerLevel.ToExpressionMultiply100()).Replace("{total}", (poisonEnhancementTalent.CurrentLevel <= 0) ? "0" : (PoisonEnhancementTalent.DamageStart + PoisonEnhancementTalent.DamagePerLevel * (double)poisonEnhancementTalent.CurrentLevel).ToExpressionMultiply100()).Replace("{start}", PoisonEnhancementTalent.DamageStart.ToExpressionMultiply100());
		}
		if (talent is BlackBloodTalent)
		{
			BlackBloodTalent blackBloodTalent = talent as BlackBloodTalent;
			talent2.Description = talent2.Description.Replace("{resistancetotal}", (BlackBloodTalent.ResistanceDecayRate * (double)blackBloodTalent.CurrentLevel).ToExpressionMultiply100()).Replace("{resistancerate}", BlackBloodTalent.ResistanceDecayRate.ToExpressionMultiply100()).Replace("{dodgerate}", BlackBloodTalent.DodgeDecayRate.ToExpressionMultiply100()).Replace("{dodgetotal}", (BlackBloodTalent.DodgeDecayRate * (double)blackBloodTalent.CurrentLevel).ToExpressionMultiply100());
		}
		if (talent is DivineHeartTalent)
		{
			DivineHeartTalent divineHeartTalent = talent as DivineHeartTalent;
			talent2.Description = talent2.Description.Replace("{rate}", DivineHeartTalent.RatePerLevel.ToExpressionMultiply100()).Replace("{start}", DivineHeartTalent.StartRate.ToExpressionMultiply100()).Replace("{total}", (divineHeartTalent.CurrentLevel <= 0) ? "0" : (DivineHeartTalent.StartRate + DivineHeartTalent.RatePerLevel * (double)divineHeartTalent.CurrentLevel).ToExpressionMultiply100());
		}
		if (talent is PhysicalEnhancementTalent)
		{
			PhysicalEnhancementTalent physicalEnhancementTalent = talent as PhysicalEnhancementTalent;
			talent2.Description = talent2.Description.Replace("{rate}", PhysicalEnhancementTalent.RatePerLevel.ToExpressionMultiply100()).Replace("{start}", PhysicalEnhancementTalent.StartRate.ToExpressionMultiply100()).Replace("{total}", (physicalEnhancementTalent.CurrentLevel <= 0) ? "0" : (PhysicalEnhancementTalent.StartRate + PhysicalEnhancementTalent.RatePerLevel * (double)physicalEnhancementTalent.CurrentLevel).ToExpressionMultiply100());
		}
		if (talent is ShadowEffectEnhancementTalent)
		{
			ShadowEffectEnhancementTalent shadowEffectEnhancementTalent = talent as ShadowEffectEnhancementTalent;
			talent2.Description = talent2.Description.Replace("{number}", (ShadowEffectEnhancementTalent.Triggers * shadowEffectEnhancementTalent.CurrentLevel).ToString()).Replace("{rate}", ShadowEffectEnhancementTalent.Triggers.ToString());
		}
		if (talent is IceEnhancementTalent)
		{
			IceEnhancementTalent iceEnhancementTalent = talent as IceEnhancementTalent;
			talent2.Description = talent2.Description.Replace("{rate}", IceEnhancementTalent.Rate.ToExpressionMultiply100()).Replace("{total}", (IceEnhancementTalent.Rate * (double)iceEnhancementTalent.CurrentLevel).ToExpressionMultiply100());
		}
		if (talent is DivineEnhancementTalent)
		{
			DivineEnhancementTalent divineEnhancementTalent = talent as DivineEnhancementTalent;
			talent2.Description = talent2.Description.Replace("{rate}", DivineEnhancementTalent.Rate.ToExpressionMultiply100()).Replace("{total}", (DivineEnhancementTalent.Rate * (double)divineEnhancementTalent.CurrentLevel).ToExpressionMultiply100());
		}
		if (talent is LightningShieldTalent)
		{
			LightningShieldTalent lightningShieldTalent = talent as LightningShieldTalent;
			talent2.Description = talent2.Description.Replace("{totalresilience}", (LightningShieldTalent.ResilienceRate * (double)lightningShieldTalent.CurrentLevel).ToExpressionMultiply100()).Replace("{rateresilience}", LightningShieldTalent.ResilienceRate.ToExpressionMultiply100()).Replace("{totalnegative}", (LightningShieldTalent.NegativeResistancerate * (double)lightningShieldTalent.CurrentLevel).ToExpressionMultiply100()).Replace("{ratenegative}", LightningShieldTalent.NegativeResistancerate.ToExpressionMultiply100());
		}
		if (talent is TacticTargetAttributeDebuffTalent)
		{
			TacticTargetAttributeDebuffTalent tacticTargetAttributeDebuffTalent = talent as TacticTargetAttributeDebuffTalent;
			AttributeBuff buff = tacticTargetAttributeDebuffTalent.GetBuff();
			talent2.Description = talent2.Description.Replace("{type}", buff.AttributeType.GetDescription().Title).Replace("{rate}", (buff.ModificationType != ModificationType.Multiplication && !buff.AttributeType.IsPercentageValue()) ? buff.Value.ToExpression() : (buff.Value.ToExpressionMultiply100() + "%")).Replace("{seconds}", buff.Seconds.ToString());
		}
		if (talent is CritDamageBoostTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", CritDamageBoostTalent.Rate.ToExpressionMultiply100()).Replace("{total}", (CritDamageBoostTalent.Rate * (double)talent.GetCurrentLevel()).ToExpressionMultiply100());
		}
		if (talent is EfficiencyTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", EfficiencyTalent.Rate.ToExpressionMultiply100()).Replace("{total}", (EfficiencyTalent.Rate * (double)talent.GetCurrentLevel()).ToExpressionMultiply100());
		}
		if (talent is StunEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", StunEnhancementTalent.Rate.ToExpressionMultiply100()).Replace("{total}", (StunEnhancementTalent.Rate * (double)talent.GetCurrentLevel()).ToExpressionMultiply100());
		}
		if (talent is RecoveryEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", RecoveryEnhancementTalent.Rate.ToExpressionMultiply100()).Replace("{total}", (RecoveryEnhancementTalent.Rate * (double)talent.GetCurrentLevel()).ToExpressionMultiply100());
		}
		if (talent is TargetSelectionBuffTalent)
		{
			TargetSelectionBuffTalent targetSelectionBuffTalent = talent as TargetSelectionBuffTalent;
			AttributeBuff buff2 = targetSelectionBuffTalent.GetBuff();
			talent2.Description = talent2.Description.Replace("{type}", buff2.AttributeType.GetDescription().Title).Replace("{rate}", (buff2.ModificationType != ModificationType.Multiplication && !buff2.AttributeType.IsPercentageValue()) ? buff2.Value.ToExpression() : (buff2.Value.ToExpressionMultiply100() + "%")).Replace("{seconds}", buff2.Seconds.ToString());
		}
		if (talent is SpellOfHolinessDispelHealTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", SpellOfHolinessDispelHealTalent.HealRate.ToExpressionMultiply100());
		}
		if (talent is SpellOfHolinessDamageTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", SpellOfHolinessDamageTalent.DamageRate.ToExpressionMultiply100()).Replace("{number}", SpellOfHolinessDamageTalent.NumberOfDispels.ToString());
		}
		if (talent is SpiritOfDemonPetTalent)
		{
			SpiritOfDemonPetTalent spiritOfDemonPetTalent = talent as SpiritOfDemonPetTalent;
			UnitClass petType = spiritOfDemonPetTalent.GetPetType();
			talent2.Description = talent2.Description.Replace("{type}", petType.GetDescription().Title).Replace("{cost}", SpiritOfDemonPetTalent.Cost.ToString());
		}
		if (talent is ArmorOfWindExtraHitTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", ArmorOfWindExtraHitTalent.ExtraHit.ToString());
		}
		if (talent is ArmorOfWindBoostTalent)
		{
			ArmorOfWindBoostTalent armorOfWindBoostTalent = talent as ArmorOfWindBoostTalent;
			AttributeBuff buff3 = armorOfWindBoostTalent.GetBuff();
			talent2.Description = talent2.Description.Replace("{type}", buff3.AttributeType.GetDescription().Title).Replace("{rate}", (buff3.ModificationType != ModificationType.Multiplication && !buff3.AttributeType.IsPercentageValue()) ? buff3.Value.ToExpression() : (buff3.Value.ToExpressionMultiply100() + "%"));
		}
		if (talent is EmbracedShieldExtraTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", EmbracedShieldExtraTalent.Extra.ToString());
		}
		if (talent is EmbracedShieldDispelTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", EmbracedShieldDispelTalent.Dispel.ToString());
		}
		if (talent is EmbracedShieldStunTalent)
		{
			talent2.Description = talent2.Description.Replace("{seconds}", EmbracedShieldStunTalent.Seconds.ToString());
		}
		if (talent is BloodCurseDispelPartyTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", BloodCurseDispelPartyTalent.Dispel.ToString());
		}
		if (talent is BloodCurseDispelOnHitTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", BloodCurseDispelOnHitTalent.Dispel.ToString());
		}
		if (talent is BloodCurseDepressionTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", BloodCurseDepressionTalent.Rate.ToExpressionMultiply100()).Replace("{seconds}", BloodCurseDepressionTalent.Seconds.ToString());
		}
		if (talent is HeartlessExtraSeedTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", HeartlessExtraSeedTalent.ExtraRate.ToExpressionMultiply100());
		}
		if (talent is HeartlessSingleHitTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", HeartlessSingleHitTalent.Rate.ToExpressionMultiply100());
		}
		if (talent is CurseOfTheDeadEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", CurseOfTheDeadEnhancementTalent.DamageRate.ToExpressionMultiply100());
		}
		if (talent is FormlessDebuffTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", FormlessDebuffTalent.Rate.ToExpressionMultiply100()).Replace("{seconds}", FormlessDebuffTalent.Seconds.ToString());
		}
		if (talent is FormlessExtraHitTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", FormlessExtraHitTalent.Extra.ToString());
		}
		if (talent is FormlessDispelEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", FormlessDispelEnhancementTalent.Dispel.ToString());
		}
		if (talent is GhostlySmokeConfusionTalent)
		{
			talent2.Description = talent2.Description.Replace("{chance}", GhostlySmokeConfusionTalent.Chance.ToExpressionMultiply100()).Replace("{seconds}", GhostlySmokeConfusionTalent.Seconds.ToString());
		}
		if (talent is SpitFireSelfProtectionTalent)
		{
			talent2.Description = talent2.Description.Replace("{damagereduction}", SpitFireSelfProtectionTalent.DamageReduction.ToExpressionMultiply100()).Replace("{strength}", SpitFireSelfProtectionTalent.StrengthBoost.ToExpressionMultiply100());
		}
		if (talent is SpitFireFocusTalent)
		{
			talent2.Description = talent2.Description.Replace("{seconds}", SpitFireFocusTalent.Time.ToString()).Replace("{rate}", SpitFireFocusTalent.DamageBoostRate.ToExpressionMultiply100());
		}
		if (talent is SpitFireDispelTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", SpitFireDispelTalent.Dispel.ToString());
		}
		if (talent is PoisonMistDispelEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", PoisonMistDispelEnhancementTalent.Dispel.ToString());
		}
		if (talent is SunderDecayTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", SunderDecayTalent.Rate.ToExpressionMultiply100());
		}
		if (talent is SunderTauntTalent)
		{
			talent2.Description = talent2.Description.Replace("{chance}", SunderTauntTalent.Chance.ToExpressionMultiply100()).Replace("{seconds}", SunderTauntTalent.Seconds.ToString());
		}
		if (talent is SwiftwindDamageTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", SwiftwindDamageTalent.DamageRate.ToExpressionMultiply100());
		}
		if (talent is SwiftWindAgilityBoostTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", SwiftWindAgilityBoostTalent.Rate.ToExpressionMultiply100());
		}
		if (talent is SwiftWindPushEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", SwiftWindPushEnhancementTalent.Pushrate.ToExpressionMultiply100());
		}
		if (talent is DrunknessExtraEnhancementTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", DrunknessExtraEnhancementTalent.Extra.ToString());
		}
		if (talent is ThousandKnivesDebuffTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", ThousandKnivesDebuffTalent.Rate.ToExpressionMultiply100()).Replace("{seconds}", ThousandKnivesDebuffTalent.Seconds.ToString());
		}
		if (talent is ThousandKnivesDamageBoostTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", ThousandKnivesDamageBoostTalent.Rate.ToExpressionMultiply100());
		}
		if (talent is ThousandKnivesDispelTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", ThousandKnivesDispelTalent.NumberOfDispels.ToString()).Replace("{rate}", ThousandKnivesDispelTalent.DamageReductionRate.ToExpressionMultiply100());
		}
		if (talent is RotationShieldTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", RotationShieldTalent.Rate.ToExpressionMultiply100());
		}
		if (talent is RotationDispelTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", RotationDispelTalent.Dispel.ToString());
		}
		if (talent is RotationDecayTalent)
		{
			talent2.Description = talent2.Description.Replace("{type}", RotationDecayTalent.Type.GetDescription().Title).Replace("{rate}", (RotationDecayTalent.ModificationType != ModificationType.Multiplication && !RotationDecayTalent.Type.IsPercentageValue()) ? RotationDecayTalent.Rate.ToExpression() : (RotationDecayTalent.Rate.ToExpressionMultiply100() + "%")).Replace("{seconds}", RotationDecayTalent.Seconds.ToString());
		}
		if (talent is RageCostTalent)
		{
			talent2.Description = talent2.Description.Replace("{cost}", (talent as RageCostTalent).GetCost().ToString());
		}
		if (talent is PushProgressTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", (talent as PushProgressTalent).GetPushRate().ToExpressionMultiply100());
		}
		if (talent is MeteoroliteElementalTalent)
		{
			talent2.Description = talent2.Description.Replace("{type}", (talent as MeteoroliteElementalTalent).GetChangeType().GetDescription().Title).Replace("{rate}", MeteoroliteElementalTalent.Rate.ToExpressionMultiply100());
		}
		if (talent is FrenzyDispelTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", FrenzyDispelTalent.Dispel.ToString());
		}
		if (talent is FrenzyPushTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", FrenzyPushTalent.Push.ToExpressionMultiply100());
		}
		if (talent is FrenzyStunTalent)
		{
			talent2.Description = talent2.Description.Replace("{seconds}", FrenzyStunTalent.Stun.ToString());
		}
		if (talent is SeductionExtraTargetTalent)
		{
			talent2.Description = talent2.Description.Replace("{chance}", SeductionExtraTargetTalent.Chance.ToExpressionMultiply100());
		}
		if (talent is SeductionDecayTalent)
		{
			talent2.Description = talent2.Description.Replace("{type}", SeductionDecayTalent.Type.GetDescription().Title).Replace("{rate}", (SeductionDecayTalent.ModificationType != ModificationType.Multiplication && !SeductionDecayTalent.Type.IsPercentageValue()) ? SeductionDecayTalent.Rate.ToExpression() : (SeductionDecayTalent.Rate.ToExpressionMultiply100() + "%")).Replace("{seconds}", SeductionDecayTalent.Seconds.ToString());
		}
		if (talent is PriorCastDecayTalent)
		{
			AttributeBuff buff4 = (talent as PriorCastDecayTalent).GetBuff();
			talent2.Description = talent2.Description.Replace("{type}", buff4.AttributeType.GetDescription().Title).Replace("{rate}", (buff4.ModificationType != ModificationType.Multiplication && !buff4.AttributeType.IsPercentageValue()) ? buff4.Value.ToExpression() : (buff4.Value.ToExpressionMultiply100() + "%")).Replace("{seconds}", buff4.Seconds.ToString());
		}
		if (talent is PriorCastDispelTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", (talent as PriorCastDispelTalent).GetNumberOfDispel().ToString());
		}
		if (talent is CrashExtraDamageTalent)
		{
			talent2.Description = talent2.Description.Replace("{rate}", CrashExtraDamageTalent.Rate.ToExpressionMultiply100()).Replace("{type}", CrashExtraDamageTalent.Type.GetDescription().Title);
		}
		if (talent is CrashExtraHitTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", CrashExtraHitTalent.Extra.ToString());
		}
		if (talent is CrashDispelTalent)
		{
			talent2.Description = talent2.Description.Replace("{number}", CrashDispelTalent.Dispel.ToString());
		}
		return new Description
		{
			Details1 = talent2.Description,
			Title = talent2.Name,
			Details2 = string.Empty
		};
	}

	// Token: 0x06001CEB RID: 7403 RVA: 0x000C6FF0 File Offset: 0x000C53F0
	public static List<IAdventurerTalent> GetActiveTalents(this IBattleUnit unit)
	{
		if (unit is AdventurerBattleUnit)
		{
			return (from t in (unit as AdventurerBattleUnit).AdventurerProfile.Talents
			where t.GetCurrentLevel() > 0
			select t).ToList<IAdventurerTalent>();
		}
		return new List<IAdventurerTalent>();
	}

	// Token: 0x06001CEC RID: 7404 RVA: 0x000C7045 File Offset: 0x000C5445
	[CompilerGenerated]
	private static bool <IsAvaliable>m__0(IAdventurerTalent t)
	{
		return t.GetTier() == AdventurerTalentTier.First;
	}

	// Token: 0x06001CED RID: 7405 RVA: 0x000C7050 File Offset: 0x000C5450
	[CompilerGenerated]
	private static int <IsAvaliable>m__1(IAdventurerTalent t)
	{
		return t.GetCurrentLevel();
	}

	// Token: 0x06001CEE RID: 7406 RVA: 0x000C7058 File Offset: 0x000C5458
	[CompilerGenerated]
	private static bool <IsAvaliable>m__2(IAdventurerTalent t)
	{
		return t.GetTier() == AdventurerTalentTier.First;
	}

	// Token: 0x06001CEF RID: 7407 RVA: 0x000C7063 File Offset: 0x000C5463
	[CompilerGenerated]
	private static int <IsAvaliable>m__3(IAdventurerTalent t)
	{
		return t.GetCurrentLevel();
	}

	// Token: 0x06001CF0 RID: 7408 RVA: 0x000C706B File Offset: 0x000C546B
	[CompilerGenerated]
	private static bool <IsAvaliable>m__4(IAdventurerTalent t)
	{
		return t.GetTier() == AdventurerTalentTier.Second;
	}

	// Token: 0x06001CF1 RID: 7409 RVA: 0x000C7076 File Offset: 0x000C5476
	[CompilerGenerated]
	private static int <IsAvaliable>m__5(IAdventurerTalent t)
	{
		return t.GetCurrentLevel();
	}

	// Token: 0x06001CF2 RID: 7410 RVA: 0x000C707E File Offset: 0x000C547E
	[CompilerGenerated]
	private static bool <IsAvaliable>m__6(IAdventurerTalent t)
	{
		return t.GetTier() == AdventurerTalentTier.Second;
	}

	// Token: 0x06001CF3 RID: 7411 RVA: 0x000C7089 File Offset: 0x000C5489
	[CompilerGenerated]
	private static int <IsAvaliable>m__7(IAdventurerTalent t)
	{
		return t.GetCurrentLevel();
	}

	// Token: 0x06001CF4 RID: 7412 RVA: 0x000C7091 File Offset: 0x000C5491
	[CompilerGenerated]
	private static bool <IsAvaliable>m__8(IAdventurerTalent t)
	{
		return t.GetTier() == AdventurerTalentTier.Third;
	}

	// Token: 0x06001CF5 RID: 7413 RVA: 0x000C709C File Offset: 0x000C549C
	[CompilerGenerated]
	private static int <IsAvaliable>m__9(IAdventurerTalent t)
	{
		return t.GetCurrentLevel();
	}

	// Token: 0x06001CF6 RID: 7414 RVA: 0x000C70A4 File Offset: 0x000C54A4
	[CompilerGenerated]
	private static bool <IsAvaliable>m__A(IAdventurerTalent t)
	{
		return t.GetTier() == AdventurerTalentTier.Third;
	}

	// Token: 0x06001CF7 RID: 7415 RVA: 0x000C70AF File Offset: 0x000C54AF
	[CompilerGenerated]
	private static int <IsAvaliable>m__B(IAdventurerTalent t)
	{
		return t.GetCurrentLevel();
	}

	// Token: 0x06001CF8 RID: 7416 RVA: 0x000C70B7 File Offset: 0x000C54B7
	[CompilerGenerated]
	private static bool <IsAvaliable>m__C(IAdventurerTalent t)
	{
		return t.GetTier() == AdventurerTalentTier.Forth;
	}

	// Token: 0x06001CF9 RID: 7417 RVA: 0x000C70C2 File Offset: 0x000C54C2
	[CompilerGenerated]
	private static int <IsAvaliable>m__D(IAdventurerTalent t)
	{
		return t.GetCurrentLevel();
	}

	// Token: 0x06001CFA RID: 7418 RVA: 0x000C70CA File Offset: 0x000C54CA
	[CompilerGenerated]
	private static double <GetMainSkillDamageBoostRate>m__E(ElementalDamageIncreaseTalent t)
	{
		return t.GetRate();
	}

	// Token: 0x06001CFB RID: 7419 RVA: 0x000C70D2 File Offset: 0x000C54D2
	[CompilerGenerated]
	private static bool <GetActiveTalents>m__F(IAdventurerTalent t)
	{
		return t.GetCurrentLevel() > 0;
	}

	// Token: 0x04001AC9 RID: 6857
	[CompilerGenerated]
	private static Func<IAdventurerTalent, bool> <>f__am$cache0;

	// Token: 0x04001ACA RID: 6858
	[CompilerGenerated]
	private static Func<IAdventurerTalent, int> <>f__am$cache1;

	// Token: 0x04001ACB RID: 6859
	[CompilerGenerated]
	private static Func<IAdventurerTalent, bool> <>f__am$cache2;

	// Token: 0x04001ACC RID: 6860
	[CompilerGenerated]
	private static Func<IAdventurerTalent, int> <>f__am$cache3;

	// Token: 0x04001ACD RID: 6861
	[CompilerGenerated]
	private static Func<IAdventurerTalent, bool> <>f__am$cache4;

	// Token: 0x04001ACE RID: 6862
	[CompilerGenerated]
	private static Func<IAdventurerTalent, int> <>f__am$cache5;

	// Token: 0x04001ACF RID: 6863
	[CompilerGenerated]
	private static Func<IAdventurerTalent, bool> <>f__am$cache6;

	// Token: 0x04001AD0 RID: 6864
	[CompilerGenerated]
	private static Func<IAdventurerTalent, int> <>f__am$cache7;

	// Token: 0x04001AD1 RID: 6865
	[CompilerGenerated]
	private static Func<IAdventurerTalent, bool> <>f__am$cache8;

	// Token: 0x04001AD2 RID: 6866
	[CompilerGenerated]
	private static Func<IAdventurerTalent, int> <>f__am$cache9;

	// Token: 0x04001AD3 RID: 6867
	[CompilerGenerated]
	private static Func<IAdventurerTalent, bool> <>f__am$cacheA;

	// Token: 0x04001AD4 RID: 6868
	[CompilerGenerated]
	private static Func<IAdventurerTalent, int> <>f__am$cacheB;

	// Token: 0x04001AD5 RID: 6869
	[CompilerGenerated]
	private static Func<IAdventurerTalent, bool> <>f__am$cacheC;

	// Token: 0x04001AD6 RID: 6870
	[CompilerGenerated]
	private static Func<IAdventurerTalent, int> <>f__am$cacheD;

	// Token: 0x04001AD7 RID: 6871
	[CompilerGenerated]
	private static Func<ElementalDamageIncreaseTalent, double> <>f__am$cacheE;

	// Token: 0x04001AD8 RID: 6872
	[CompilerGenerated]
	private static Func<IAdventurerTalent, bool> <>f__am$cacheF;
}
