using System;
using System.Collections.Generic;
using Core.Battle.RunePower;
using UnityEngine;

// Token: 0x02000A0E RID: 2574
public static class FilePath
{
	// Token: 0x06004632 RID: 17970 RVA: 0x001C60C8 File Offset: 0x001C44C8
	public static Sprite GetTownEffectIcon(TownEffectBase effect)
	{
		switch (effect.Type)
		{
		case TownEffectType.AdventurerAttributeBoost:
		{
			AdventurerAttributeBoostEffect adventurerAttributeBoostEffect = effect as AdventurerAttributeBoostEffect;
			if (adventurerAttributeBoostEffect == null)
			{
				return FilePath.ResourceIcons[27];
			}
			AttributeType attributeType = adventurerAttributeBoostEffect.AttributeType;
			switch (attributeType)
			{
			case AttributeType.Strength:
				return FilePath.ResourceIcons[95];
			case AttributeType.Intelligience:
				return FilePath.ResourceIcons[118];
			case AttributeType.Agility:
				return FilePath.DghzSprites[243];
			case AttributeType.CritRate:
				return FilePath.DghzSprites[195];
			case AttributeType.Vitality:
				return FilePath.DghzSprites[244];
			case AttributeType.CritDamage:
				return FilePath.DghzSprites[196];
			case AttributeType.PhysicalResistance:
			case AttributeType.FireResistanceResistance:
			case AttributeType.ShadowResistance:
			case AttributeType.IceResistance:
			case AttributeType.PoisonResistance:
			case AttributeType.DivineResistance:
			case AttributeType.LightningResistance:
			case AttributeType.Allresistances:
				return FilePath.DghzSprites[252];
			default:
				switch (attributeType)
				{
				case AttributeType.LifeOnHit:
					return FilePath.DghzSprites[240];
				case AttributeType.TauntOnHit:
					return FilePath.DghzSprites[263];
				case AttributeType.StunOnHit:
					return FilePath.DghzSprites[231];
				case AttributeType.ReflectiveDamage:
					return FilePath.DghzSprites[260];
				default:
					switch (attributeType)
					{
					case AttributeType.SkillRageEfficiencyRate:
						return FilePath.PutumnoIcons[152];
					case AttributeType.HealingAbsorbRate:
						return FilePath.PutumnoIcons[333];
					case AttributeType.EffectMastery:
						return FilePath.PutumnoIcons[338];
					case AttributeType.HitRateAdjustment:
						return FilePath.PutumnoIcons[306];
					case AttributeType.DodgeRateAdjustment:
						return FilePath.PutumnoIcons[312];
					default:
						if (attributeType == AttributeType.Resilience)
						{
							return FilePath.PutumnoIcons[68];
						}
						if (attributeType != AttributeType.DamageReduction)
						{
							return FilePath.DghzSprites[9];
						}
						return FilePath.PutumnoIcons[142];
					}
					break;
				case AttributeType.Mining:
					return FilePath.DghzSprites[292];
				case AttributeType.Logging:
					return FilePath.DghzSprites[277];
				case AttributeType.Hunting:
					return FilePath.DghzSprites[259];
				}
				break;
			}
			break;
		}
		case TownEffectType.GearPriceBoost:
			return FilePath.DghzSprites[3305];
		case TownEffectType.ArmoryMasteryEffect:
			return FilePath.DghzSprites[3005];
		case TownEffectType.RecruitmentQualityBoost:
			return FilePath.DghzSprites[2038];
		case TownEffectType.FlyingBladeEffect:
			return FilePath.DghzSprites[2523];
		case TownEffectType.DodgeProtectionEffect:
			return FilePath.DghzSprites[2031];
		case TownEffectType.LuckyChestEffect:
			return FilePath.DghzSprites[2023];
		case TownEffectType.SpiritualHeartEffect:
			return FilePath.PutumnoIcons[178];
		case TownEffectType.TigerRoarEffect:
			return FilePath.DghzSprites[262];
		case TownEffectType.StopperEffect:
			return FilePath.DghzSprites[239];
		case TownEffectType.WarmFlowEffect:
			return FilePath.DghzSprites[218];
		case TownEffectType.OutputBoost:
			return FilePath.DghzSprites[226];
		default:
			return FilePath.ResourceIcons[27];
		}
	}

	// Token: 0x06004633 RID: 17971 RVA: 0x001C6378 File Offset: 0x001C4778
	public static Sprite GetTownEventTypeIcon(TownEventType eventType)
	{
		switch (eventType)
		{
		case TownEventType.TeaParty:
			return FilePath.ResourceIcons[48];
		case TownEventType.Banquet:
			return FilePath.DghzSprites[2144];
		case TownEventType.Drumming:
			return FilePath.ResourceIcons[227];
		case TownEventType.Meditation:
			return FilePath.DghzSprites[2020];
		case TownEventType.PoetryParty:
			return FilePath.DghzSprites[2453];
		case TownEventType.Trade:
			return FilePath.DghzSprites[2021];
		case TownEventType.Alchemy:
			return FilePath.DghzSprites[2143];
		case TownEventType.ArmoryResearch:
			return FilePath.DghzSprites[2022];
		default:
			return FilePath.DghzSprites[2454];
		}
	}

	// Token: 0x06004634 RID: 17972 RVA: 0x001C641C File Offset: 0x001C481C
	public static Sprite GetRunePowerIcon(RunePowerType type)
	{
		switch (type)
		{
		case RunePowerType.PrismLight:
			return FilePath.PutumnoIcons[818];
		case RunePowerType.GhostBreaths:
			return FilePath.DghzSprites[819];
		case RunePowerType.VitalEnergy:
			return FilePath.DghzSprites[820];
		case RunePowerType.ChaoticSpirit:
			return FilePath.DghzSprites[821];
		default:
			return FilePath.DghzSprites[818];
		}
	}

	// Token: 0x06004635 RID: 17973 RVA: 0x001C6484 File Offset: 0x001C4884
	public static Sprite GetAdventurerTalentIcon(AdventurerTalentType talent)
	{
		switch (talent)
		{
		case AdventurerTalentType.ElementalDamageIncrease:
			return FilePath.DghzSprites[226];
		case AdventurerTalentType.AttributeDebuffByRateOnHit:
			return FilePath.DghzSprites[230];
		case AdventurerTalentType.DispelPositiveEffectsOnHit:
			return FilePath.DghzSprites[115];
		case AdventurerTalentType.FireBreathFireSeedEnhancement:
			return FilePath.DghzSprites[43];
		case AdventurerTalentType.NegativeEffectsRefresh:
			return FilePath.DghzSprites[72];
		case AdventurerTalentType.AttributeBoostOnKillByRate:
			return FilePath.DghzSprites[89];
		case AdventurerTalentType.PushOnHit:
			return FilePath.DghzSprites[154];
		case AdventurerTalentType.FireBreathAbsorbShield:
			return FilePath.DghzSprites[34];
		case AdventurerTalentType.AttributeDebuffByValueOnHit:
			return FilePath.DghzSprites[149];
		case AdventurerTalentType.SkillExtraTarget:
			return FilePath.DghzSprites[119];
		case AdventurerTalentType.FreezeEnhancement:
			return FilePath.DghzSprites[233];
		case AdventurerTalentType.ArcaneCritEnhancement:
			return FilePath.DghzSprites[128];
		case AdventurerTalentType.SelfHealOnKill:
			return FilePath.DghzSprites[264];
		case AdventurerTalentType.ShadowSacrificeExplosionEnhancement:
			return FilePath.DghzSprites[164];
		case AdventurerTalentType.ShadowSacrificeStunEnhancement:
			return FilePath.DghzSprites[165];
		case AdventurerTalentType.ShadowSacrificeHealOnExplo:
			return FilePath.DghzSprites[160];
		case AdventurerTalentType.SeedsOfSinPetPush:
			return FilePath.DghzSprites[163];
		case AdventurerTalentType.DivineHammerDamage:
			return FilePath.DghzSprites[153];
		case AdventurerTalentType.AttributeBoostOnHealByRate:
			return FilePath.DghzSprites[250];
		case AdventurerTalentType.PrayDispelEnhancement:
			return FilePath.DghzSprites[152];
		case AdventurerTalentType.GodSeedStablize:
			return FilePath.DghzSprites[9];
		case AdventurerTalentType.StunOnHit:
			return FilePath.DghzSprites[231];
		case AdventurerTalentType.AssassinDispelEnhancement:
			return FilePath.DghzSprites[212];
		case AdventurerTalentType.ShieldOnKill:
			return FilePath.DghzSprites[251];
		case AdventurerTalentType.StealSoulDispelEnhancement:
			return FilePath.DghzSprites[181];
		case AdventurerTalentType.ShadowlessDamageEnhancement:
			return FilePath.DghzSprites[171];
		case AdventurerTalentType.AttributeBoostAllMemberOnKillBasedOnSelfRate:
			return FilePath.DghzSprites[104];
		case AdventurerTalentType.TauntDamageEnhancement:
			return FilePath.DghzSprites[219];
		case AdventurerTalentType.TauntTimeEnhancement:
			return FilePath.DghzSprites[263];
		case AdventurerTalentType.TauntDebuff:
			return FilePath.DghzSprites[259];
		case AdventurerTalentType.RoarTargetEnhancement:
			return FilePath.DghzSprites[262];
		case AdventurerTalentType.ScornChanceEnhancement:
			return FilePath.DghzSprites[91];
		case AdventurerTalentType.BrightCircleBoostEnhancement:
			return FilePath.DghzSprites[75];
		case AdventurerTalentType.BrightCircleDispelEnhancement:
			return FilePath.DghzSprites[71];
		case AdventurerTalentType.BurningHeartStrengthBurnEnhancement:
			return FilePath.DghzSprites[40];
		case AdventurerTalentType.BurningHeartDispelEnhancement:
			return FilePath.DghzSprites[38];
		case AdventurerTalentType.GrandStrategyDamageEnhancement:
			return FilePath.DghzSprites[119];
		case AdventurerTalentType.GrandStrategyDispelEnhancement:
			return FilePath.DghzSprites[117];
		case AdventurerTalentType.EmbraceShieldMemberOnKill:
			return FilePath.DghzSprites[69];
		case AdventurerTalentType.DodgeEnhancement:
			return FilePath.PutumnoIcons[573];
		case AdventurerTalentType.LifeRegen:
			return FilePath.PutumnoIcons[656];
		case AdventurerTalentType.VitalityEnhancement:
			return FilePath.PutumnoIcons[541];
		case AdventurerTalentType.TauntEnhancement:
			return FilePath.PutumnoIcons[651];
		case AdventurerTalentType.FurySpeed:
			return FilePath.PutumnoIcons[512];
		case AdventurerTalentType.KillerPower:
			return FilePath.PutumnoIcons[478];
		case AdventurerTalentType.EnhancedEffects:
			return FilePath.PutumnoIcons[474];
		case AdventurerTalentType.EnhancedResistances:
			return FilePath.PutumnoIcons[486];
		case AdventurerTalentType.HitRateEnhancement:
			return FilePath.PutumnoIcons[516];
		case AdventurerTalentType.NegativeEffectResistanceBoost:
			return FilePath.PutumnoIcons[616];
		case AdventurerTalentType.ElementDamageEnhancement:
			return FilePath.DghzSprites[1840];
		case AdventurerTalentType.FireShield:
			return FilePath.PutumnoIcons[221];
		case AdventurerTalentType.ShadowOfGhost:
			return FilePath.PutumnoIcons[352];
		case AdventurerTalentType.ProtectorTalent:
			return FilePath.PutumnoIcons[540];
		case AdventurerTalentType.RestrictionOfTime:
			return FilePath.PutumnoIcons[6];
		case AdventurerTalentType.PoisonEnhancement:
			return FilePath.PutumnoIcons[343];
		case AdventurerTalentType.BlackBlood:
			return FilePath.PutumnoIcons[341];
		case AdventurerTalentType.DivineHeart:
			return FilePath.PutumnoIcons[712];
		case AdventurerTalentType.PhysicalEnhancement:
			return FilePath.PutumnoIcons[153];
		case AdventurerTalentType.ShadowEnhancement:
			return FilePath.PutumnoIcons[408];
		case AdventurerTalentType.IceEnhancement:
			return FilePath.PutumnoIcons[247];
		case AdventurerTalentType.DivineEnhancement:
			return FilePath.PutumnoIcons[356];
		case AdventurerTalentType.LightningShield:
			return FilePath.PutumnoIcons[117];
		case AdventurerTalentType.ActiveTargetDebuff:
			return FilePath.PutumnoIcons[684];
		case AdventurerTalentType.CritDamageBoost:
			return FilePath.PutumnoIcons[547];
		case AdventurerTalentType.EfficiencyBoost:
			return FilePath.PutumnoIcons[768];
		case AdventurerTalentType.StunEnhancement:
			return FilePath.PutumnoIcons[769];
		case AdventurerTalentType.RecoveryEnhancement:
			return FilePath.PutumnoIcons[662];
		case AdventurerTalentType.TargetSelectionBuff:
			return FilePath.PutumnoIcons[663];
		case AdventurerTalentType.SpellOfHolinessDispelHeal:
			return FilePath.DghzSprites[2004];
		case AdventurerTalentType.SpellOfHolinessDamage:
			return FilePath.DghzSprites[2005];
		case AdventurerTalentType.SpiritOfDemonBoost:
			return FilePath.DghzSprites[1988];
		case AdventurerTalentType.ArmorOfWindExtraHit:
			return FilePath.DghzSprites[1941];
		case AdventurerTalentType.ArmorOfWindAttributeBuff:
			return FilePath.DghzSprites[1940];
		case AdventurerTalentType.EmbracedShieldExtraHit:
			return FilePath.DghzSprites[1972];
		case AdventurerTalentType.EmbracedShieldDispel:
			return FilePath.DghzSprites[1973];
		case AdventurerTalentType.EmbracedStun:
			return FilePath.DghzSprites[1974];
		case AdventurerTalentType.BloodCurseDispelAllMember:
			return FilePath.DghzSprites[1989];
		case AdventurerTalentType.BloodCurseDispelOnHit:
			return FilePath.DghzSprites[1990];
		case AdventurerTalentType.BloodCurseOutputDepression:
			return FilePath.DghzSprites[1991];
		case AdventurerTalentType.HeartlessTrigger:
			return FilePath.DghzSprites[1860];
		case AdventurerTalentType.HeartlessSeedEnhancement:
			return FilePath.DghzSprites[1861];
		case AdventurerTalentType.HeartlessSingleHit:
			return FilePath.DghzSprites[1862];
		case AdventurerTalentType.CurseOfTheDeadDamageBoost:
			return FilePath.DghzSprites[1956];
		case AdventurerTalentType.FormlessAttributeDecay:
			return FilePath.DghzSprites[1957];
		case AdventurerTalentType.FormlessExtraHit:
			return FilePath.DghzSprites[1959];
		case AdventurerTalentType.FormlessDispel:
			return FilePath.DghzSprites[1958];
		case AdventurerTalentType.GhostlySmokeConfusionEnhancement:
			return FilePath.DghzSprites[1942];
		case AdventurerTalentType.SpitFireProtectionEnhancement:
			return FilePath.DghzSprites[1877];
		case AdventurerTalentType.SpitFireFocusEnhancement:
			return FilePath.DghzSprites[1878];
		case AdventurerTalentType.SpitFireDispelEnhancement:
			return FilePath.DghzSprites[1879];
		case AdventurerTalentType.PoisonMistDispelEnhancement:
			return FilePath.DghzSprites[1924];
		case AdventurerTalentType.SunderDepressionEnhancement:
			return FilePath.DghzSprites[1892];
		case AdventurerTalentType.SunderTauntEnhancement:
			return FilePath.DghzSprites[1893];
		case AdventurerTalentType.SwiftWindDamageSwitchEnhancement:
			return FilePath.DghzSprites[1925];
		case AdventurerTalentType.SwiftWindAgilityBoostEnhancement:
			return FilePath.DghzSprites[1926];
		case AdventurerTalentType.SwiftWindPushBoostEnhancement:
			return FilePath.DghzSprites[1927];
		case AdventurerTalentType.DrunknessExtraTargetEnhancement:
			return FilePath.DghzSprites[1908];
		case AdventurerTalentType.ThousandKnivesDepressionEnhancement:
			return FilePath.DghzSprites[2006];
		case AdventurerTalentType.ThousandKnivesDamageEnhancement:
			return FilePath.DghzSprites[1975];
		case AdventurerTalentType.ThousandKnivesDispelEnhancement:
			return FilePath.DghzSprites[2007];
		case AdventurerTalentType.RotationShieldEnhancement:
			return FilePath.DghzSprites[1844];
		case AdventurerTalentType.RotationDispelEnhancement:
			return FilePath.DghzSprites[1845];
		case AdventurerTalentType.RotationAttributeDecay:
			return FilePath.DghzSprites[1846];
		case AdventurerTalentType.TacticRageCostChange:
			return FilePath.DghzSprites[1909];
		case AdventurerTalentType.ActiveTargetPushProgress:
			return FilePath.PutumnoIcons[409];
		case AdventurerTalentType.GrandMeteoroliteElementalChange:
			return FilePath.DghzSprites[1910];
		case AdventurerTalentType.FrenzyDispelEnhancement:
			return FilePath.DghzSprites[1736];
		case AdventurerTalentType.FrenzyPushEnhancemednt:
			return FilePath.DghzSprites[1735];
		case AdventurerTalentType.FrenzyStunEnhancement:
			return FilePath.DghzSprites[1737];
		case AdventurerTalentType.SeductionExtraTarget:
			return FilePath.DghzSprites[1719];
		case AdventurerTalentType.SeductionAttributeDecayEnhancement:
			return FilePath.DghzSprites[1720];
		case AdventurerTalentType.SeductionSelfCleanEnhancement:
			return FilePath.DghzSprites[1721];
		case AdventurerTalentType.ActiveTargetAttributeDecayPriorCast:
			return FilePath.PutumnoIcons[672];
		case AdventurerTalentType.ActiveTargetDispelPositivePriorCast:
			return FilePath.PutumnoIcons[720];
		case AdventurerTalentType.CrashExtraDamage:
			return FilePath.DghzSprites[1911];
		case AdventurerTalentType.CrashExtraHit:
			return FilePath.DghzSprites[1894];
		case AdventurerTalentType.CrashDispel:
			return FilePath.DghzSprites[1895];
		}
		return FilePath.DghzSprites[1799];
	}

	// Token: 0x06004636 RID: 17974 RVA: 0x001C6BD0 File Offset: 0x001C4FD0
	public static Sprite GetUnitClassStyleIcon(UnitClassStyle style)
	{
		switch (style)
		{
		case UnitClassStyle.PhysicalKiller:
			return FilePath.DghzSprites[2488];
		case UnitClassStyle.SpellKiller:
			return FilePath.DghzSprites[2799];
		case UnitClassStyle.PhysicalWarrior:
			return FilePath.DghzSprites[2552];
		case UnitClassStyle.SpellWarrior:
			return FilePath.DghzSprites[2801];
		case UnitClassStyle.PhysicalDefender:
			return FilePath.DghzSprites[2564];
		case UnitClassStyle.SpellDefender:
			return FilePath.DghzSprites[2772];
		case UnitClassStyle.Protector:
			return FilePath.DghzSprites[3438];
		case UnitClassStyle.SpellSupporter:
			return FilePath.DghzSprites[3437];
		case UnitClassStyle.PhysicalSupporter:
			return FilePath.DghzSprites[3436];
		case UnitClassStyle.Healer:
			return FilePath.DghzSprites[3439];
		case UnitClassStyle.Statue:
			return FilePath.ResourceIcons[285];
		}
		return FilePath.DghzSprites[2374];
	}

	// Token: 0x06004637 RID: 17975 RVA: 0x001C6CAC File Offset: 0x001C50AC
	public static Sprite GetVehicleSprite(VehicleType type)
	{
		switch (type)
		{
		case VehicleType.ExplorationBoatLevelOne:
			return FilePath.WhiteShips[0];
		case VehicleType.ExplorationBoatLevelTwo:
			return FilePath.WhiteShips[1];
		case VehicleType.ExplorationBoatLevelThree:
			return FilePath.WhiteShips[2];
		case VehicleType.ExplorationBoatLevelFour:
			return FilePath.WhiteShips[3];
		case VehicleType.ExplorationBoatLevelFive:
			return FilePath.WhiteShips[4];
		case VehicleType.ExplorationBoatLevelSix:
			return FilePath.WhiteShips[5];
		default:
			return FilePath.WhiteShips[0];
		}
	}

	// Token: 0x06004638 RID: 17976 RVA: 0x001C6D18 File Offset: 0x001C5118
	public static Sprite GetTravelContributionIcon(JourneyContributeType type)
	{
		switch (type)
		{
		case JourneyContributeType.BattleSkill:
			return FilePath.DghzSprites[2488];
		case JourneyContributeType.TradeSkill:
			return FilePath.DghzSprites[3306];
		case JourneyContributeType.CultureSkill:
			return FilePath.DghzSprites[2242];
		case JourneyContributeType.ResearchSkill:
			return FilePath.DghzSprites[2283];
		case JourneyContributeType.CollectionSkill:
			return FilePath.DghzSprites[2230];
		default:
			return FilePath.DghzSprites[2230];
		}
	}

	// Token: 0x06004639 RID: 17977 RVA: 0x001C6D90 File Offset: 0x001C5190
	public static Sprite GetSpecialEffectIcon(SpecialEffectType type)
	{
		switch (type)
		{
		case SpecialEffectType.None:
			return FilePath.PutumnoIcons[0];
		case SpecialEffectType.Growth:
			return FilePath.PutumnoIcons[201];
		case SpecialEffectType.Possession:
			return FilePath.PutumnoIcons[99];
		case SpecialEffectType.AttributeStealing:
			return FilePath.PutumnoIcons[51];
		case SpecialEffectType.Starfall:
			return FilePath.PutumnoIcons[68];
		case SpecialEffectType.AttributeDestroy:
			return FilePath.PutumnoIcons[196];
		case SpecialEffectType.CowardTimely:
			return FilePath.PutumnoIcons[103];
		case SpecialEffectType.LifePotion:
			return FilePath.PutumnoIcons[333];
		case SpecialEffectType.DeadMatch:
			return FilePath.PutumnoIcons[262];
		case SpecialEffectType.Phenix:
			return FilePath.PutumnoIcons[220];
		case SpecialEffectType.SoulCollection:
			return FilePath.PutumnoIcons[400];
		case SpecialEffectType.ClearWater:
			return FilePath.PutumnoIcons[238];
		case SpecialEffectType.ExtraTargetting:
			return FilePath.PutumnoIcons[187];
		case SpecialEffectType.Fadeout:
			return FilePath.PutumnoIcons[394];
		case SpecialEffectType.TauntRecovery:
			return FilePath.PutumnoIcons[320];
		case SpecialEffectType.Charge:
			return FilePath.PutumnoIcons[64];
		case SpecialEffectType.Sufferless:
			return FilePath.PutumnoIcons[219];
		case SpecialEffectType.SpiritOfDeadGeneralEffect:
			return FilePath.PutumnoIcons[397];
		case SpecialEffectType.FairyStoneEffect:
			return FilePath.PutumnoIcons[183];
		case SpecialEffectType.EmeraldOfClearHeartEffect:
			return FilePath.PutumnoIcons[228];
		case SpecialEffectType.BoneOfRaptureEffect:
			return FilePath.PutumnoIcons[409];
		case SpecialEffectType.UndeadAshEffect:
			return FilePath.PutumnoIcons[322];
		case SpecialEffectType.MonksEyesEffect:
			return FilePath.PutumnoIcons[190];
		case SpecialEffectType.StoneOfSoulbringerEffect:
			return FilePath.PutumnoIcons[172];
		case SpecialEffectType.SavageHeartEffect:
			return FilePath.PutumnoIcons[195];
		case SpecialEffectType.FlyingFeatherEffect:
			return FilePath.PutumnoIcons[62];
		case SpecialEffectType.GodsMoralEffect:
			return FilePath.PutumnoIcons[290];
		case SpecialEffectType.DemonicFireEffect:
			return FilePath.PutumnoIcons[217];
		case SpecialEffectType.ElementEffects:
			return FilePath.PutumnoIcons[6];
		case SpecialEffectType.ElementReplacement:
			return FilePath.PutumnoIcons[48];
		case SpecialEffectType.DarkKnightRage:
			return FilePath.PutumnoIcons[376];
		case SpecialEffectType.RageHeal:
			return FilePath.PutumnoIcons[167];
		case SpecialEffectType.DarknessRevengeEffect:
			return FilePath.PutumnoIcons[169];
		case SpecialEffectType.LavaBeastEffect:
			return FilePath.PutumnoIcons[260];
		case SpecialEffectType.InversedMandate:
			return FilePath.PutumnoIcons[53];
		case SpecialEffectType.PoisonMist:
			return FilePath.PutumnoIcons[340];
		case SpecialEffectType.DemonSkullEffect:
			return FilePath.PutumnoIcons[169];
		case SpecialEffectType.CorruptedHornEffect:
			return FilePath.PutumnoIcons[297];
		case SpecialEffectType.DungeonScaleUndeadEffect:
			return FilePath.PutumnoIcons[309];
		case SpecialEffectType.ThousandWarmsNest:
			return FilePath.PutumnoIcons[347];
		case SpecialEffectType.DarknessEffect:
			return FilePath.PutumnoIcons[385];
		case SpecialEffectType.DeathShadowEffect:
			return FilePath.PutumnoIcons[276];
		case SpecialEffectType.BlessedSinEffect:
			return FilePath.PutumnoIcons[156];
		case SpecialEffectType.BloodEyeSelfProtectionEffect:
			return FilePath.PutumnoIcons[139];
		case SpecialEffectType.DivineBlindnessEffect:
			return FilePath.PutumnoIcons[123];
		case SpecialEffectType.HydraSpiritEffect:
			return FilePath.PutumnoIcons[218];
		case SpecialEffectType.DemonDragonEffect:
			return FilePath.PutumnoIcons[60];
		case SpecialEffectType.NegativeEffectSpeedup:
			return FilePath.PutumnoIcons[47];
		case SpecialEffectType.TrickyDefence:
			return FilePath.PutumnoIcons[291];
		case SpecialEffectType.MagicBreadEffect:
			return FilePath.DghzSprites[2152];
		case SpecialEffectType.FieryTaleEffect:
			return FilePath.PutumnoIcons[206];
		case SpecialEffectType.Transcendence:
			return FilePath.PutumnoIcons[232];
		case SpecialEffectType.Enlightment:
			return FilePath.PutumnoIcons[230];
		case SpecialEffectType.ProtectorsPride:
			return FilePath.PutumnoIcons[228];
		case SpecialEffectType.KillingIntent:
			return FilePath.PutumnoIcons[137];
		case SpecialEffectType.Rejuvenation:
			return FilePath.PutumnoIcons[325];
		case SpecialEffectType.Sacrifice:
			return FilePath.PutumnoIcons[419];
		case SpecialEffectType.FirstHand:
			return FilePath.PutumnoIcons[423];
		case SpecialEffectType.LifeGen:
			return FilePath.PutumnoIcons[358];
		case SpecialEffectType.StoneGuard:
			return FilePath.PutumnoIcons[339];
		case SpecialEffectType.Victious:
			return FilePath.PutumnoIcons[344];
		case SpecialEffectType.ImmortalShield:
			return FilePath.PutumnoIcons[109];
		case SpecialEffectType.TattoringFoes:
			return FilePath.PutumnoIcons[122];
		case SpecialEffectType.ShiftShield:
			return FilePath.PutumnoIcons[97];
		case SpecialEffectType.CommonEnemy:
			return FilePath.PutumnoIcons[313];
		case SpecialEffectType.Purification:
			return FilePath.PutumnoIcons[243];
		case SpecialEffectType.ConfidentHealer:
			return FilePath.PutumnoIcons[310];
		case SpecialEffectType.DispelOnHit:
			return FilePath.PutumnoIcons[64];
		case SpecialEffectType.PushOnHit:
			return FilePath.PutumnoIcons[397];
		case SpecialEffectType.ReviveDamage:
			return FilePath.PutumnoIcons[414];
		case SpecialEffectType.OutputResistanceBoost:
			return FilePath.PutumnoIcons[420];
		case SpecialEffectType.SoulCollectionUnDispellable:
			return FilePath.PutumnoIcons[391];
		case SpecialEffectType.ClearWaterDispelShield:
			return FilePath.PutumnoIcons[421];
		case SpecialEffectType.BossMaterialDrop:
			return FilePath.PutumnoIcons[411];
		case SpecialEffectType.ExcessiveDamageToOtherUnit:
			return FilePath.PutumnoIcons[416];
		case SpecialEffectType.ExcessiveHealToOtherUnit:
			return FilePath.PutumnoIcons[402];
		case SpecialEffectType.PositiveEffectBoost:
			return FilePath.PutumnoIcons[372];
		case SpecialEffectType.NegativeEffectBoost:
			return FilePath.PutumnoIcons[363];
		case SpecialEffectType.StrongMan:
			return FilePath.PutumnoIcons[68];
		case SpecialEffectType.HardLife:
			return FilePath.PutumnoIcons[63];
		case SpecialEffectType.StrongGuard:
			return FilePath.PutumnoIcons[361];
		case SpecialEffectType.Mindless:
			return FilePath.PutumnoIcons[87];
		case SpecialEffectType.StandingKiller:
			return FilePath.PutumnoIcons[73];
		case SpecialEffectType.HealingStrength:
			return FilePath.PutumnoIcons[185];
		case SpecialEffectType.StandingGun:
			return FilePath.PutumnoIcons[190];
		case SpecialEffectType.ThugPower:
			return FilePath.PutumnoIcons[191];
		case SpecialEffectType.TimeLockResistance:
			return FilePath.PutumnoIcons[188];
		case SpecialEffectType.TurnResistance:
			return FilePath.PutumnoIcons[409];
		case SpecialEffectType.EffectSeal:
			return FilePath.PutumnoIcons[241];
		case SpecialEffectType.PoisonSeed:
			return FilePath.PutumnoIcons[254];
		case SpecialEffectType.CourageBlessing:
			return FilePath.PutumnoIcons[167];
		case SpecialEffectType.PowerThirst:
			return FilePath.PutumnoIcons[163];
		case SpecialEffectType.ReflectionBoost:
			return FilePath.PutumnoIcons[183];
		case SpecialEffectType.DecayBlade:
			return FilePath.PutumnoIcons[151];
		case SpecialEffectType.Outrage:
			return FilePath.PutumnoIcons[220];
		case SpecialEffectType.Respite:
			return FilePath.PutumnoIcons[55];
		case SpecialEffectType.ClearUp:
			return FilePath.PutumnoIcons[238];
		case SpecialEffectType.Swallow:
			return FilePath.PutumnoIcons[295];
		case SpecialEffectType.ExtremeTaunt:
			return FilePath.PutumnoIcons[263];
		case SpecialEffectType.ElementalMaster:
			return FilePath.PutumnoIcons[228];
		case SpecialEffectType.Disease:
			return FilePath.PutumnoIcons[308];
		case SpecialEffectType.Agility:
			return FilePath.PutumnoIcons[313];
		case SpecialEffectType.RageBoost:
			return FilePath.PutumnoIcons[317];
		case SpecialEffectType.IceHeart:
			return FilePath.PutumnoIcons[318];
		case SpecialEffectType.LifeBind:
			return FilePath.PutumnoIcons[322];
		case SpecialEffectType.Fear:
			return FilePath.PutumnoIcons[170];
		case SpecialEffectType.ResistanceKillBoost:
			return FilePath.PutumnoIcons[241];
		case SpecialEffectType.GrowthPerAdventure:
			return FilePath.PutumnoIcons[247];
		case SpecialEffectType.AgilityIdleBoost:
			return FilePath.PutumnoIcons[245];
		case SpecialEffectType.EyeOfPrecisionEffect:
			return FilePath.GemSprites[20];
		case SpecialEffectType.MissHaste:
			return FilePath.PutumnoIcons[44];
		case SpecialEffectType.DispelOnHeal:
			return FilePath.PutumnoIcons[44];
		case SpecialEffectType.HealOverTimeBoost:
			return FilePath.PutumnoIcons[92];
		case SpecialEffectType.LifeRegen:
			return FilePath.PutumnoIcons[656];
		case SpecialEffectType.CommandmentOfSpell:
			return FilePath.GemSprites[62];
		case SpecialEffectType.FlyingBlade:
			return FilePath.DghzSprites[2523];
		case SpecialEffectType.DodgeProtection:
			return FilePath.DghzSprites[2031];
		case SpecialEffectType.WarmFlow:
			return FilePath.DghzSprites[218];
		case SpecialEffectType.SpiritualHeart:
			return FilePath.PutumnoIcons[178];
		case SpecialEffectType.TigerRoar:
			return FilePath.DghzSprites[262];
		case SpecialEffectType.Stopper:
			return FilePath.DghzSprites[239];
		case SpecialEffectType.GodBlessing:
			return FilePath.DghzSprites[2023];
		case SpecialEffectType.AttributeBoostOnStart:
			return FilePath.DghzSprites[9];
		case SpecialEffectType.OutputBoostOnStart:
			return FilePath.DghzSprites[226];
		case SpecialEffectType.EvilHeart:
			return FilePath.GemSprites[117];
		case SpecialEffectType.FireShield:
			return FilePath.PutumnoIcons[221];
		case SpecialEffectType.ShadowOfGhost:
			return FilePath.PutumnoIcons[352];
		case SpecialEffectType.RestrictionOfTime:
			return FilePath.PutumnoIcons[6];
		case SpecialEffectType.Protector:
			return FilePath.PutumnoIcons[540];
		case SpecialEffectType.PoisonEffectEnhancement:
			return FilePath.PutumnoIcons[343];
		case SpecialEffectType.BlackBlood:
			return FilePath.PutumnoIcons[341];
		case SpecialEffectType.DivineHeart:
			return FilePath.PutumnoIcons[712];
		case SpecialEffectType.PhysicalEffectEnhancement:
			return FilePath.PutumnoIcons[153];
		case SpecialEffectType.ShadowEffectEnhancement:
			return FilePath.PutumnoIcons[408];
		case SpecialEffectType.IceEffectEnhancement:
			return FilePath.PutumnoIcons[247];
		case SpecialEffectType.DivineEffectEnhancement:
			return FilePath.PutumnoIcons[356];
		case SpecialEffectType.LightningShield:
			return FilePath.PutumnoIcons[117];
		case SpecialEffectType.BrokenIce:
			return FilePath.PutumnoIcons[249];
		case SpecialEffectType.Timeless:
			return FilePath.PutumnoIcons[229];
		case SpecialEffectType.LightningEnhancement:
			return FilePath.PutumnoIcons[55];
		case SpecialEffectType.StreetManEnhancement:
			return FilePath.DghzSprites[209];
		case SpecialEffectType.DrunkReaderEnhancement:
			return FilePath.PutumnoIcons[293];
		case SpecialEffectType.Arrogance:
			return FilePath.DghzSprites[91];
		case SpecialEffectType.KillerEnhancement:
			return FilePath.PutumnoIcons[239];
		case SpecialEffectType.SnowMaideEnhancement:
			return FilePath.PutumnoIcons[246];
		case SpecialEffectType.FashionEnhancement:
			return FilePath.PutumnoIcons[211];
		case SpecialEffectType.AttributeDepression:
			return FilePath.PutumnoIcons[278];
		case SpecialEffectType.Curse:
			return FilePath.PutumnoIcons[262];
		case SpecialEffectType.UnitLock:
			return FilePath.PutumnoIcons[276];
		case SpecialEffectType.EvilLust:
			return FilePath.PutumnoIcons[301];
		case SpecialEffectType.ActiveStrategyTargetBoost:
		case SpecialEffectType.ActiveStrategyTargetDebuff:
		case SpecialEffectType.SpellOfHolinessHeal:
		case SpecialEffectType.SpellOfHolinessDamage:
		case SpecialEffectType.ConjourerPetEnhancement:
		case SpecialEffectType.RageOccupy:
		case SpecialEffectType.ArmorOfWindNumberEnhancement:
		case SpecialEffectType.ArmorOfWindAttributeEnhancement:
		case SpecialEffectType.EmbracedShieldNumberEnhancement:
		case SpecialEffectType.EmbracedShieldDispelEnhancement:
		case SpecialEffectType.EmbracedShieldStunEnhancement:
		case SpecialEffectType.BloodCurseDispelPartyEnhancement:
		case SpecialEffectType.BloodCurseDispelOnHitEnhancement:
		case SpecialEffectType.BloodCurseOutputDepressionEnhancement:
		case SpecialEffectType.HeartlessTrigger:
		case SpecialEffectType.HeartlessSeedEnhancement:
		case SpecialEffectType.HeartlessSingleHit:
		case SpecialEffectType.CurseOfTheDeadDamageBoost:
		case SpecialEffectType.FormlessAttributeDecay:
		case SpecialEffectType.FormlessExtraHit:
		case SpecialEffectType.FormlessDispel:
		case SpecialEffectType.GhostlySmokeConfusionEnhancement:
		case SpecialEffectType.SpitFireProtectionEnhancement:
		case SpecialEffectType.SpitFireFocusEnhancement:
		case SpecialEffectType.SpitFireDispelEnhancement:
		case SpecialEffectType.PoisonMistDispelEnhancement:
		case SpecialEffectType.SunderDepressionEnhancement:
		case SpecialEffectType.SunderTauntEnhancement:
		case SpecialEffectType.SwiftWindDamageSwitchEnhancement:
		case SpecialEffectType.SwiftWindAgilityBoostEnhancement:
		case SpecialEffectType.SwiftWindPushBoostEnhancement:
		case SpecialEffectType.DrunknessExtraTargetEnhancement:
		case SpecialEffectType.ThousandKnivesDepressionEnhancement:
		case SpecialEffectType.ThousandKnivesDamageEnhancement:
		case SpecialEffectType.ThousandKnivesDispelEnhancement:
		case SpecialEffectType.RotationShieldEnhancement:
		case SpecialEffectType.RotationDispelEnhancement:
		case SpecialEffectType.RotationAttributeDecay:
		case SpecialEffectType.TacticRageCostChange:
		case SpecialEffectType.ActiveTargetPushProgress:
		case SpecialEffectType.GrandMeteoroliteElementalChange:
		case SpecialEffectType.FrenzyDispelEnhancement:
		case SpecialEffectType.FrenzyPushEnhancemednt:
		case SpecialEffectType.FrenzyStunEnhancement:
		case SpecialEffectType.SeductionExtraTarget:
		case SpecialEffectType.SeductionAttributeDecayEnhancement:
		case SpecialEffectType.SeductionSelfCleanEnhancement:
		case SpecialEffectType.ActiveTargetAttributeDecayPriorCast:
		case SpecialEffectType.ActiveTargetDispelPositivePriorCast:
		case SpecialEffectType.CrashExtraDamage:
		case SpecialEffectType.CrashExtraHit:
		case SpecialEffectType.CrashDispel:
		case SpecialEffectType.RedBlade:
		case SpecialEffectType.PoisonMistBoost:
		case SpecialEffectType.DeathBoost:
		case SpecialEffectType.BunBoost:
		case SpecialEffectType.DuelistIronBloodBoost:
		case SpecialEffectType.BunAura:
		case SpecialEffectType.GhostSmokeBoost:
		case SpecialEffectType.DevilSpell:
		case SpecialEffectType.RageCloth:
		case SpecialEffectType.RageDepression:
		case SpecialEffectType.CriticalHitDepression:
			return FilePath.PutumnoIcons[14];
		case SpecialEffectType.DuplicatedUnit:
			return FilePath.PutumnoIcons[404];
		case SpecialEffectType.RestrictedAccess:
			return FilePath.PutumnoIcons[5];
		case SpecialEffectType.LifePotionPercentage:
			return FilePath.DghzSprites[264];
		case SpecialEffectType.StrengthOfTheGhost:
			return FilePath.PutumnoIcons[386];
		case SpecialEffectType.EnhancedNightBlade:
			return FilePath.PutumnoIcons[150];
		case SpecialEffectType.EnhancedChubbyLady:
			return FilePath.PutumnoIcons[109];
		case SpecialEffectType.Reincarnation:
			return FilePath.PutumnoIcons[141];
		case SpecialEffectType.Thorns:
			return FilePath.PutumnoIcons[400];
		case SpecialEffectType.Guilt:
			return FilePath.PutumnoIcons[413];
		case SpecialEffectType.Annihilation:
			return FilePath.PutumnoIcons[336];
		case SpecialEffectType.Focus:
			return FilePath.PutumnoIcons[412];
		case SpecialEffectType.HealResistanceBoost:
			return FilePath.PutumnoIcons[177];
		case SpecialEffectType.DamageAttributeReductionByValue:
			return FilePath.PutumnoIcons[537];
		case SpecialEffectType.HealOutputBoost:
			return FilePath.PutumnoIcons[663];
		case SpecialEffectType.TauntResistanceBoost:
			return FilePath.PutumnoIcons[635];
		case SpecialEffectType.AdventureEnergyBoostByValue:
			return FilePath.PutumnoIcons[656];
		case SpecialEffectType.OffensiveDamageIgnoreByAttacker:
			return FilePath.PutumnoIcons[382];
		case SpecialEffectType.TauntBoost:
			return FilePath.PutumnoIcons[113];
		case SpecialEffectType.DamageReductionByHealth:
			return FilePath.PutumnoIcons[372];
		case SpecialEffectType.AdventureEnergyRecollection:
			return FilePath.PutumnoIcons[92];
		case SpecialEffectType.Domineering:
			return FilePath.PutumnoIcons[399];
		}
		return FilePath.PutumnoIcons[14];
	}

	// Token: 0x0600463A RID: 17978 RVA: 0x001C7940 File Offset: 0x001C5D40
	public static Sprite GetWeatherImage(Weather weather)
	{
		switch (weather)
		{
		case Weather.Rainy:
			return FilePath.ResourceIcons[33];
		case Weather.Sunny:
			return FilePath.DghzSprites[3441];
		case Weather.Snow:
			return FilePath.ResourceIcons[34];
		case Weather.Windy:
			return FilePath.DghzSprites[3443];
		default:
			return FilePath.DghzSprites[3341];
		}
	}

	// Token: 0x0600463B RID: 17979 RVA: 0x001C799D File Offset: 0x001C5D9D
	public static GameObject GetBattleDialogPre()
	{
		return Resources.Load("Prefabs/CharactersCombat/Dialog") as GameObject;
	}

	// Token: 0x0600463C RID: 17980 RVA: 0x001C79AE File Offset: 0x001C5DAE
	public static Sprite GetMapEffectiveness(int starLevel)
	{
		if (starLevel == 1)
		{
			return FilePath.UiElements[50];
		}
		if (starLevel == 2)
		{
			return FilePath.UiElements[164];
		}
		return FilePath.UiElements[50];
	}

	// Token: 0x0600463D RID: 17981 RVA: 0x001C79DC File Offset: 0x001C5DDC
	public static Sprite GetUpgradeCardImage(UpgradeCardType type)
	{
		string text = FilePath.UpgradeCardPath;
		switch (type)
		{
		case UpgradeCardType.Tactics:
			text += "Tactic";
			break;
		case UpgradeCardType.OutputBoost:
			text += "OutputBoost";
			break;
		case UpgradeCardType.ElementalEnhancement:
			text += "ElementalEnhancement";
			break;
		case UpgradeCardType.ElementalResistance:
			text += "ElementResistance";
			break;
		case UpgradeCardType.ElementalEffects:
			text += "ElementalEffects";
			break;
		case UpgradeCardType.CritDamageBoost:
			text += "CritDamageBoost";
			break;
		case UpgradeCardType.TauntBoost:
			text += "TauntBoost";
			break;
		case UpgradeCardType.ElementEffectBoost:
			text += "ElementalEffects";
			break;
		case UpgradeCardType.Speedness:
			text += "Speedness";
			break;
		case UpgradeCardType.RagePower:
			text += "RagePower";
			break;
		case UpgradeCardType.Revenge:
			text += "Revenge";
			break;
		case UpgradeCardType.Vitality:
			text += "Vitality";
			break;
		case UpgradeCardType.Stun:
			text += "Stun";
			break;
		case UpgradeCardType.Reflection:
			text += "Reflection";
			break;
		case UpgradeCardType.Absorb:
			text += "Absorb";
			break;
		default:
			text += "Absorb";
			break;
		}
		return Resources.Load<Sprite>(text);
	}

	// Token: 0x0600463E RID: 17982 RVA: 0x001C7B50 File Offset: 0x001C5F50
	public static AudioClip GetAudioClip(global::AudioType type)
	{
		switch (type)
		{
		case global::AudioType.NormalButtonClick:
			return Resources.Load<AudioClip>(FilePath.SoundPathUi + "Normal_Button_Click");
		case global::AudioType.QuestCompleted:
			return Resources.Load<AudioClip>(FilePath.SoundPathMusicEffect + "MUSIC_EFFECT_Solo_Xylophone_Positive_16_stereo");
		case global::AudioType.ItemLock:
			return Resources.Load<AudioClip>(FilePath.SoundPathUi + "Item_Lock");
		case global::AudioType.ItemUnlock:
			return Resources.Load<AudioClip>(FilePath.SoundPathUi + "Item_Unlock");
		case global::AudioType.ItemBreak:
			return Resources.Load<AudioClip>(FilePath.SoundPathUi + "Item_Break");
		case global::AudioType.HeroUpgrade:
			return Resources.Load<AudioClip>(FilePath.SoundPathUi + "Hero_Upgrade");
		case global::AudioType.BuildingClick:
			return Resources.Load<AudioClip>(FilePath.SoundPathUi + "Building_Click");
		case global::AudioType.HeroSelect:
			return Resources.Load<AudioClip>(FilePath.SoundPathUi + "Hero_Select");
		case global::AudioType.RecipeMade:
			return Resources.Load<AudioClip>(FilePath.SoundPathUi + "Recipe_Made");
		case global::AudioType.WorldMapMapClick:
			return Resources.Load<AudioClip>(FilePath.SoundPathUi + "WorldMap_Map_Click");
		case global::AudioType.CapableRecipeClick:
			return Resources.Load<AudioClip>(FilePath.SoundPathUi + "Capable_Recipe_Click");
		case global::AudioType.TabClick:
			return Resources.Load<AudioClip>(FilePath.SoundPathUi + "Tab_Click");
		default:
			throw new Exception("Type " + type + " has not been assigned yet.");
		}
	}

	// Token: 0x0600463F RID: 17983 RVA: 0x001C7CB0 File Offset: 0x001C60B0
	public static Sprite GetResourceCategroy(ResourceCategory cate)
	{
		switch (cate)
		{
		case ResourceCategory.None:
			return FilePath.ResourceIcons[6];
		case ResourceCategory.Sword:
			return FilePath.ResourceIcons[6];
		case ResourceCategory.Knife:
			return FilePath.ResourceIcons[99];
		case ResourceCategory.Staff:
			return FilePath.ResourceIcons[113];
		case ResourceCategory.Axe:
			return FilePath.ResourceIcons[102];
		case ResourceCategory.Spear:
			return FilePath.ResourceIcons[106];
		case ResourceCategory.Robe:
			return FilePath.ResourceIcons[152];
		case ResourceCategory.Leather:
			return FilePath.ResourceIcons[248];
		case ResourceCategory.Plate:
			return FilePath.ResourceIcons[153];
		case ResourceCategory.Gem:
			return FilePath.ResourceIcons[31];
		case ResourceCategory.Ore:
			return FilePath.ResourceIcons[256];
		case ResourceCategory.Timber:
			return FilePath.ResourceIcons[278];
		case ResourceCategory.Hides:
			return FilePath.ResourceIcons[248];
		case ResourceCategory.Accessory:
			return FilePath.ResourceIcons[216];
		case ResourceCategory.GameItem:
			return FilePath.ResourceIcons[22];
		case ResourceCategory.CoreResource:
			return FilePath.ResourceIcons[8];
		case ResourceCategory.Consumable:
			return FilePath.ResourceIcons[56];
		case ResourceCategory.ProductionRecipe:
			return FilePath.ResourceIcons[182];
		case ResourceCategory.AdventurerInvitation:
			return FilePath.ResourceIcons[187];
		case ResourceCategory.BuildingPermit:
			return FilePath.ResourceIcons[190];
		default:
			return FilePath.ResourceIcons[22];
		}
	}

	// Token: 0x06004640 RID: 17984 RVA: 0x001C7DF0 File Offset: 0x001C61F0
	public static string GetSocketImageText(SocketType type)
	{
		string text = "<sprite=\"Gem sockets\" ";
		int num;
		switch (type)
		{
		case SocketType.All:
			num = 4;
			break;
		case SocketType.Red:
			num = 1;
			break;
		case SocketType.Blue:
			num = 0;
			break;
		case SocketType.Green:
			num = 2;
			break;
		case SocketType.Yellow:
			num = 3;
			break;
		default:
			throw new ArgumentOutOfRangeException("type", type, null);
		}
		return string.Concat(new object[]
		{
			text,
			"index=",
			num,
			">"
		});
	}

	// Token: 0x06004641 RID: 17985 RVA: 0x001C7E84 File Offset: 0x001C6284
	public static Sprite GetSocketImage(SocketType type)
	{
		switch (type)
		{
		case SocketType.All:
			return FilePath.DghzSprites[3639];
		case SocketType.Red:
			return FilePath.DghzSprites[3636];
		case SocketType.Blue:
			return FilePath.DghzSprites[3635];
		case SocketType.Green:
			return FilePath.DghzSprites[3637];
		case SocketType.Yellow:
			return FilePath.DghzSprites[3638];
		default:
			return FilePath.DghzSprites[3639];
		}
	}

	// Token: 0x06004642 RID: 17986 RVA: 0x001C7EF8 File Offset: 0x001C62F8
	public static string GetSocketTypeText(SocketType type)
	{
		string title = type.GetDescription().Title;
		switch (type)
		{
		case SocketType.All:
			return ColorPicker.GetHaxString(ColorPicker.White, title);
		case SocketType.Red:
			return ColorPicker.GetHaxString(ColorPicker.NagetiveRed, title);
		case SocketType.Blue:
			return ColorPicker.GetHaxString(ColorPicker.Blue, title);
		case SocketType.Green:
			return ColorPicker.GetHaxString(ColorPicker.PositiveGreen, title);
		case SocketType.Yellow:
			return ColorPicker.GetHaxString(ColorPicker.Legendary, title);
		default:
			throw new ArgumentOutOfRangeException("type", type, null);
		}
	}

	// Token: 0x06004643 RID: 17987 RVA: 0x001C7F80 File Offset: 0x001C6380
	public static Sprite GetGemImage(ResourceType type)
	{
		switch (type)
		{
		case ResourceType.NoneGem:
			return FilePath.GemSprites[0];
		case ResourceType.SpiritOfDeadGeneral:
			return FilePath.GemSprites[22];
		case ResourceType.FairyStone:
			return FilePath.GemSprites[12];
		case ResourceType.EmeraldOfClearHeart:
			return FilePath.GemSprites[131];
		case ResourceType.BoneOfRapture:
			return FilePath.GemSprites[47];
		case ResourceType.UndeadAsh:
			return FilePath.GemSprites[89];
		case ResourceType.MonksEyes:
			return FilePath.GemSprites[88];
		case ResourceType.StoneOfSoulbringer:
			return FilePath.GemSprites[24];
		case ResourceType.SavageHeart:
			return FilePath.GemSprites[13];
		case ResourceType.FlyingFeather:
			return FilePath.GemSprites[109];
		case ResourceType.GodsMoral:
			return FilePath.GemSprites[35];
		case ResourceType.DemonicFire:
			return FilePath.GemSprites[78];
		case ResourceType.EyeOfPrecision:
			return FilePath.GemSprites[20];
		case ResourceType.StoneOfExorcism:
			return FilePath.GemSprites[119];
		case ResourceType.CommandmentOfSpell:
			return FilePath.GemSprites[62];
		case ResourceType.EvilHeart:
			return FilePath.GemSprites[117];
		default:
			return FilePath.ResourceIcons[27];
		}
	}

	// Token: 0x06004644 RID: 17988 RVA: 0x001C8078 File Offset: 0x001C6478
	public static Sprite GetTownTitleType(TownTitleType type)
	{
		switch (type)
		{
		case TownTitleType.None:
			return FilePath.DghzSprites[2271];
		case TownTitleType.SilientPursuit:
			return FilePath.DghzSprites[2272];
		case TownTitleType.VillagersChat:
			return FilePath.DghzSprites[2262];
		case TownTitleType.WindyCrisp:
			return FilePath.DghzSprites[2257];
		case TownTitleType.SolidFruit:
			return FilePath.DghzSprites[2270];
		case TownTitleType.RomaticRumors:
			return FilePath.DghzSprites[2265];
		case TownTitleType.FairysCrooning:
			return FilePath.DghzSprites[2264];
		case TownTitleType.DevoutBelievers:
			return FilePath.DghzSprites[2256];
		case TownTitleType.WonderlandsWhispers:
			return FilePath.DghzSprites[2267];
		case TownTitleType.TheHerosExplorations:
			return FilePath.DghzSprites[2263];
		case TownTitleType.ProudAdventures:
			return FilePath.DghzSprites[2269];
		case TownTitleType.WonderfulFuture:
			return FilePath.DghzSprites[2266];
		case TownTitleType.StyleOfTheEmpire:
			return FilePath.DghzSprites[2258];
		case TownTitleType.DragonsBlessing:
			return FilePath.DghzSprites[2259];
		case TownTitleType.TheDragonCliffsTorch:
			return FilePath.DghzSprites[2260];
		case TownTitleType.TheSacredDragonMessenger:
			return FilePath.DghzSprites[2268];
		case TownTitleType.SalvationOfHeaven:
			return FilePath.DghzSprites[2261];
		default:
			return FilePath.DghzSprites[2271];
		}
	}

	// Token: 0x06004645 RID: 17989 RVA: 0x001C81AC File Offset: 0x001C65AC
	public static Sprite GetCompetitionRankImage(int rank)
	{
		if (rank > 3000)
		{
			return FilePath.DghzSprites[491];
		}
		if (500 < rank && rank <= 3000)
		{
			return FilePath.DghzSprites[490];
		}
		return FilePath.DghzSprites[489];
	}

	// Token: 0x06004646 RID: 17990 RVA: 0x001C8200 File Offset: 0x001C6600
	public static Sprite GetEffectIconBy(BattleEffectType type)
	{
		switch (type)
		{
		case BattleEffectType.TurnDamage:
			return FilePath.DghzSprites[216];
		case BattleEffectType.BrightCircle:
			return FilePath.DghzSprites[68];
		case BattleEffectType.Chill:
			return FilePath.DghzSprites[55];
		case BattleEffectType.ArcaneFocused:
			return FilePath.DghzSprites[60];
		case BattleEffectType.MultiStrikeFocused:
			return FilePath.DghzSprites[51];
		case BattleEffectType.Exhausted:
			return FilePath.DghzSprites[168];
		case BattleEffectType.StrengthBoost:
			return FilePath.DghzSprites[232];
		case BattleEffectType.FireSeed:
			return FilePath.DghzSprites[0];
		case BattleEffectType.Flourish:
			return FilePath.DghzSprites[105];
		case BattleEffectType.Frozen:
			return FilePath.PutumnoIcons[233];
		case BattleEffectType.GodSeed:
			return FilePath.DghzSprites[9];
		case BattleEffectType.Harmony:
			return FilePath.DghzSprites[257];
		case BattleEffectType.EffectImmune:
			return FilePath.DghzSprites[195];
		case BattleEffectType.LighteningSpeed:
			return FilePath.DghzSprites[153];
		case BattleEffectType.MoraleReduction:
			return FilePath.DghzSprites[46];
		case BattleEffectType.PoisonSeed:
			return FilePath.DghzSprites[96];
		case BattleEffectType.Principle:
			return FilePath.DghzSprites[200];
		case BattleEffectType.Relentless:
			return FilePath.DghzSprites[212];
		case BattleEffectType.Roar:
			return FilePath.DghzSprites[2078];
		case BattleEffectType.ShadowSpirit:
			return FilePath.DghzSprites[132];
		case BattleEffectType.CorruptedPowerEffect:
			return FilePath.DghzSprites[167];
		case BattleEffectType.Rage:
			return FilePath.DghzSprites[263];
		case BattleEffectType.Stamina:
			return FilePath.DghzSprites[87];
		case BattleEffectType.Stone:
			return FilePath.DghzSprites[3];
		case BattleEffectType.BurningHeartEffect:
			return FilePath.DghzSprites[40];
		case BattleEffectType.StrengthDecay:
			return FilePath.DghzSprites[230];
		case BattleEffectType.Stun:
			return FilePath.DghzSprites[231];
		case BattleEffectType.Taunt:
			return FilePath.DghzSprites[263];
		case BattleEffectType.FierySoul:
			return FilePath.DghzSprites[39];
		case BattleEffectType.DamagePerSecond:
			return FilePath.DghzSprites[107];
		case BattleEffectType.ShieldBurn:
		case BattleEffectType.ArmorReduction:
			return FilePath.DghzSprites[272];
		case BattleEffectType.ReturnedSoul:
			return FilePath.DghzSprites[164];
		case BattleEffectType.Empowerment:
			return FilePath.DghzSprites[148];
		case BattleEffectType.AttributeStolen:
			return FilePath.DghzSprites[230];
		case BattleEffectType.AttributeObtain:
			return FilePath.DghzSprites[218];
		case BattleEffectType.AttributeReplacement:
			return FilePath.DghzSprites[253];
		case BattleEffectType.TimelyCoward:
			return FilePath.DghzSprites[215];
		case BattleEffectType.BattlePressure:
			return FilePath.DghzSprites[238];
		case BattleEffectType.SoulCollectedBoost:
			return FilePath.DghzSprites[180];
		case BattleEffectType.Fade:
			return FilePath.DghzSprites[177];
		case BattleEffectType.Charged:
			return FilePath.DghzSprites[169];
		case BattleEffectType.DamageImmune:
			return FilePath.DghzSprites[178];
		case BattleEffectType.SufferlessPenalty:
			return FilePath.DghzSprites[236];
		case BattleEffectType.SpiritOfDemon:
			return FilePath.DghzSprites[163];
		case BattleEffectType.DamageReduction:
			return FilePath.DghzSprites[200];
		case BattleEffectType.DamageNeutrualization:
			return FilePath.DghzSprites[155];
		case BattleEffectType.ReflectiveShield:
			return FilePath.DghzSprites[171];
		case BattleEffectType.BloodCurseEffect:
			return FilePath.DghzSprites[139];
		case BattleEffectType.CritRateBoost:
			return FilePath.DghzSprites[219];
		case BattleEffectType.Confusion:
			return FilePath.DghzSprites[75];
		case BattleEffectType.FireSpiritEffect:
			return FilePath.DghzSprites[39];
		case BattleEffectType.HealingReduction:
			return FilePath.DghzSprites[107];
		case BattleEffectType.AgilityBoost:
			return FilePath.DghzSprites[117];
		case BattleEffectType.ArmorEnhancement:
			return FilePath.PutumnoIcons[228];
		case BattleEffectType.AdditionalTarget:
			return FilePath.PutumnoIcons[119];
		case BattleEffectType.IntelligienceBoost:
			return FilePath.DghzSprites[186];
		case BattleEffectType.Frenzy:
			return FilePath.DghzSprites[169];
		case BattleEffectType.UndeadAsh:
			return FilePath.DghzSprites[138];
		case BattleEffectType.FlyingFeatherEffect:
			return FilePath.DghzSprites[217];
		case BattleEffectType.BrokenArmor:
			return FilePath.DghzSprites[272];
		case BattleEffectType.DivineShine:
			return FilePath.DghzSprites[210];
		case BattleEffectType.Constraint:
			return FilePath.DghzSprites[103];
		case BattleEffectType.Slowdown:
			return FilePath.DghzSprites[57];
		case BattleEffectType.FrozenHeart:
			return FilePath.DghzSprites[51];
		case BattleEffectType.EnhancedAttributes:
			return FilePath.PutumnoIcons[163];
		case BattleEffectType.DarknessRevenge:
			return FilePath.PutumnoIcons[151];
		case BattleEffectType.SinisterRage:
			return FilePath.PutumnoIcons[169];
		case BattleEffectType.BleedingPerSecond:
			return FilePath.DghzSprites[216];
		case BattleEffectType.PoisonWarm:
			return FilePath.PutumnoIcons[347];
		case BattleEffectType.ThousandSwarmSoulCollection:
			return FilePath.PutumnoIcons[378];
		case BattleEffectType.DarknessOutputDepression:
			return FilePath.PutumnoIcons[176];
		case BattleEffectType.DarknessHealDepression:
			return FilePath.PutumnoIcons[171];
		case BattleEffectType.InversedKill:
			return FilePath.PutumnoIcons[311];
		case BattleEffectType.StrangeGhost:
			return FilePath.PutumnoIcons[304];
		case BattleEffectType.LifeLink:
			return FilePath.PutumnoIcons[373];
		case BattleEffectType.HealPerTurn:
			return FilePath.DghzSprites[247];
		case BattleEffectType.HealPerSecond:
			return FilePath.DghzSprites[248];
		case BattleEffectType.DamageIncreased:
			return FilePath.DghzSprites[226];
		case BattleEffectType.GreatGodnessProtection:
			return FilePath.DghzSprites[251];
		case BattleEffectType.TargettedEffect:
			return FilePath.PutumnoIcons[249];
		case BattleEffectType.PoisonBait:
			return FilePath.PutumnoIcons[254];
		case BattleEffectType.AttributeWeakened:
			return FilePath.PutumnoIcons[193];
		case BattleEffectType.KillingIntent:
			return FilePath.PutumnoIcons[195];
		case BattleEffectType.DamageAbsorbShield:
			return FilePath.PutumnoIcons[317];
		case BattleEffectType.TurnFrozen:
			return FilePath.PutumnoIcons[192];
		case BattleEffectType.Targetted:
			return FilePath.PutumnoIcons[96];
		case BattleEffectType.Sealed:
			return FilePath.PutumnoIcons[198];
		case BattleEffectType.CourageBlessed:
			return FilePath.PutumnoIcons[258];
		case BattleEffectType.DecayBlade:
			return FilePath.PutumnoIcons[151];
		case BattleEffectType.Silienced:
			return FilePath.PutumnoIcons[231];
		case BattleEffectType.ArrogancePunishement:
			return FilePath.PutumnoIcons[390];
		case BattleEffectType.RespiteShield:
			return FilePath.PutumnoIcons[35];
		case BattleEffectType.Fear:
			return FilePath.PutumnoIcons[170];
		case BattleEffectType.EvilThirst:
			return FilePath.PutumnoIcons[72];
		case BattleEffectType.ResistanceReductionPerSecond:
			return FilePath.PutumnoIcons[324];
		case BattleEffectType.RageThirst:
			return FilePath.PutumnoIcons[215];
		case BattleEffectType.BlackBlood:
			return FilePath.PutumnoIcons[341];
		case BattleEffectType.FreeCast:
			return FilePath.PutumnoIcons[89];
		case BattleEffectType.CrashExtra:
			return FilePath.PutumnoIcons[92];
		case BattleEffectType.Undead:
			return FilePath.PutumnoIcons[339];
		case BattleEffectType.FashionEnhanced:
			return FilePath.PutumnoIcons[211];
		case BattleEffectType.ProtectionOfTheDead:
			return FilePath.PutumnoIcons[328];
		case BattleEffectType.GuiltEffect:
			return FilePath.PutumnoIcons[413];
		case BattleEffectType.AnnihilationEffect:
			return FilePath.PutumnoIcons[336];
		case BattleEffectType.Focused:
			return FilePath.PutumnoIcons[412];
		case BattleEffectType.TauntBoost:
			return FilePath.PutumnoIcons[113];
		case BattleEffectType.DamageReductionByValue:
			return FilePath.PutumnoIcons[137];
		}
		return FilePath.DghzSprites[2085];
	}

	// Token: 0x06004647 RID: 17991 RVA: 0x001C88A8 File Offset: 0x001C6CA8
	public static string GetOutputTypeRepresentations(OutputType type)
	{
		switch (type)
		{
		case OutputType.Physical:
			return "Prefabs/OutputEffects/Physical/Physical";
		case OutputType.Fire:
			return "Prefabs/OutputEffects/Fire/Fire";
		case OutputType.Ice:
			return "Prefabs/OutputEffects/Ice/Ice";
		case OutputType.Shadow:
			return "Prefabs/OutputEffects/Shadow/Shadow";
		case OutputType.Poison:
			return "Prefabs/OutputEffects/Poison/Poison";
		case OutputType.Divine:
			return "Prefabs/OutputEffects/Divine/Divine";
		case OutputType.Lightening:
			return "Prefabs/OutputEffects/Lightening/Lightening";
		case OutputType.RealDamage:
			return "Prefabs/OutputEffects/RealDamage/RealDamage";
		}
		return string.Empty;
	}

	// Token: 0x06004648 RID: 17992 RVA: 0x001C8924 File Offset: 0x001C6D24
	public static GameObject GetAdventurerUIEffect(UnitClass unit)
	{
		switch (unit)
		{
		case UnitClass.FirePlayer:
			return Resources.Load(FilePath.AdventurerUiEffectPath + "FirePlayer/FirePlayerPre") as GameObject;
		default:
			if (unit != UnitClass.DrunkReader)
			{
				return null;
			}
			return Resources.Load(FilePath.AdventurerUiEffectPath + "Sleep/SleepPre") as GameObject;
		case UnitClass.Conjurer:
			return Resources.Load(FilePath.AdventurerUiEffectPath + "GhostFire/GhostFirePre") as GameObject;
		case UnitClass.Cube:
			return Resources.Load(FilePath.AdventurerUiEffectPath + "Cube/CubePre") as GameObject;
		}
	}

	// Token: 0x06004649 RID: 17993 RVA: 0x001C89D0 File Offset: 0x001C6DD0
	public static Sprite GetAdventurerGradeBackground(QualityGrade grade, bool isStar)
	{
		if (isStar)
		{
			return Resources.Load<Sprite>("Images/GradeBackgrounds/star");
		}
		switch (grade)
		{
		case QualityGrade.Normal:
			return Resources.Load<Sprite>("Images/GradeBackgrounds/avatar_normal");
		case QualityGrade.Rare:
			return Resources.Load<Sprite>("Images/GradeBackgrounds/avatar_rare");
		case QualityGrade.Epic:
			return Resources.Load<Sprite>("Images/GradeBackgrounds/avatar_epic");
		case QualityGrade.Legendary:
			return Resources.Load<Sprite>("Images/GradeBackgrounds/avatar_legendary");
		case QualityGrade.Ancient:
			return Resources.Load<Sprite>("Images/GradeBackgrounds/avatar_ancient");
		default:
			return Resources.Load<Sprite>("Images/GradeBackgrounds/avatar_normal");
		}
	}

	// Token: 0x0600464A RID: 17994 RVA: 0x001C8A50 File Offset: 0x001C6E50
	public static Sprite GetItemGradeBackground(QualityGrade grade, bool isStar)
	{
		if (isStar)
		{
			return Resources.Load<Sprite>("Images/GradeBackgrounds/star");
		}
		switch (grade)
		{
		case QualityGrade.Normal:
			return Resources.Load<Sprite>("Images/GradeBackgrounds/transparent");
		case QualityGrade.Rare:
			return Resources.Load<Sprite>("Images/GradeBackgrounds/rare");
		case QualityGrade.Epic:
			return Resources.Load<Sprite>("Images/GradeBackgrounds/epic");
		case QualityGrade.Legendary:
			return Resources.Load<Sprite>("Images/GradeBackgrounds/legendary");
		case QualityGrade.Ancient:
			return Resources.Load<Sprite>("Images/GradeBackgrounds/ancient");
		default:
			return Resources.Load<Sprite>("Images/GradeBackgrounds/transparent");
		}
	}

	// Token: 0x0600464B RID: 17995 RVA: 0x001C8AD0 File Offset: 0x001C6ED0
	public static Color GetGradeColor(string grade)
	{
		QualityGrade grade2 = (QualityGrade)Enum.Parse(typeof(QualityGrade), grade);
		return FilePath.GetGradeColor(grade2);
	}

	// Token: 0x0600464C RID: 17996 RVA: 0x001C8AFC File Offset: 0x001C6EFC
	public static Color GetGradeColor(QualityGrade grade)
	{
		switch (grade)
		{
		case QualityGrade.Normal:
			return ColorPicker.Normal;
		case QualityGrade.Rare:
			return ColorPicker.Rare;
		case QualityGrade.Epic:
			return ColorPicker.Epic;
		case QualityGrade.Legendary:
			return ColorPicker.Legendary;
		case QualityGrade.Ancient:
			return ColorPicker.Ancient;
		default:
			return Color.white;
		}
	}

	// Token: 0x0600464D RID: 17997 RVA: 0x001C8B4D File Offset: 0x001C6F4D
	public static Sprite GetAdventuererAvatarSprite(UnitClass unitClass)
	{
		return FilePath.GetCharacterBasicAppearance(unitClass, false).GetStandSprite();
	}

	// Token: 0x0600464E RID: 17998 RVA: 0x001C8B5C File Offset: 0x001C6F5C
	public static Sprite GetBuildingImage(BuildingType type)
	{
		string path = string.Empty;
		switch (type)
		{
		case BuildingType.WeaponShop:
			path = FilePath.BuildingImage + "WeaponShop";
			break;
		case BuildingType.RecruitmentFacility:
			path = FilePath.BuildingImage + "Recruitment";
			break;
		case BuildingType.ArmorShop:
			path = FilePath.BuildingImage + "ArmorShop";
			break;
		case BuildingType.Shop:
			path = FilePath.BuildingImage + "Shop";
			break;
		case BuildingType.Shrine:
			path = FilePath.BuildingImage + "building2";
			break;
		case BuildingType.School:
			path = FilePath.BuildingImage + "School";
			break;
		case BuildingType.CityTown:
			path = FilePath.BuildingImage + "CityTown";
			break;
		case BuildingType.Casino:
			path = FilePath.BuildingImage + "Casino";
			break;
		case BuildingType.BarrackYard:
			path = FilePath.BuildingImage + "building2";
			break;
		case BuildingType.ForgingFacility:
			path = FilePath.BuildingImage + "Furnace";
			break;
		default:
			path = FilePath.BuildingImage + "building2";
			break;
		}
		return Resources.Load<Sprite>(path);
	}

	// Token: 0x0600464F RID: 17999 RVA: 0x001C8C94 File Offset: 0x001C7094
	public static string GetPreSkillEffect(SkillType skillType)
	{
		if (skillType == SkillType.BladeRain)
		{
			return FilePath.SkillEffectPath + "BladeRain/BladeRainPre";
		}
		if (skillType == SkillType.Lightning)
		{
			return FilePath.SkillEffectPath + "Lightening/MultiLighteningsPre";
		}
		if (skillType != SkillType.DivineLight)
		{
			return null;
		}
		return FilePath.SkillEffectPath + "DivineLight/DivineLightPre";
	}

	// Token: 0x06004650 RID: 18000 RVA: 0x001C8CF8 File Offset: 0x001C70F8
	public static string GetPreActiveSkill(SkillType skilltype)
	{
		switch (skilltype)
		{
		case SkillType.CurseOfTheDead:
			return FilePath.ActiveSkillEffectPath + "CurseOfTheDead/CurseOfTheDead";
		default:
			if (skilltype == SkillType.SpiritOfDemon)
			{
				return FilePath.ActiveSkillEffectPath + "SpiritOfDemon/SpiritOfDemon";
			}
			if (skilltype != SkillType.GrandMeteorolite)
			{
				return string.Empty;
			}
			return FilePath.ActiveSkillEffectPath + "GrandMeteorolite/GrandMeteorolite";
		case SkillType.GhostlySmoke:
			return FilePath.ActiveSkillEffectPath + "GhostlySmoke/GhostlySmoke";
		case SkillType.PoisonousMist:
			return FilePath.ActiveSkillEffectPath + "PoisonousMist/PoisonousMist";
		case SkillType.Crash:
			return FilePath.ActiveSkillEffectPath + "Crash/Crash";
		case SkillType.ThousandKnives:
			return FilePath.ActiveSkillEffectPath + "ThousandKnives";
		}
	}

	// Token: 0x06004651 RID: 18001 RVA: 0x001C8DC9 File Offset: 0x001C71C9
	public static string GetDamageActiveSkillEffect(SkillType SkillType)
	{
		if (SkillType != SkillType.Formless)
		{
			return string.Empty;
		}
		return FilePath.ActiveSkillEffectPath + "Formless/Formless";
	}

	// Token: 0x06004652 RID: 18002 RVA: 0x001C8DF0 File Offset: 0x001C71F0
	public static string GetSingalTargetableActiveSkillEffect(SkillType type)
	{
		switch (type)
		{
		case SkillType.Dummy:
		case SkillType.GodsFire:
			return FilePath.ActiveSkillEffectPath + "GodsFire/GodsFire";
		case SkillType.SpellOfHoliness:
			return FilePath.ActiveSkillEffectPath + "SpellOfHoliness";
		case SkillType.IronBlood:
			return FilePath.ActiveSkillEffectPath + "IronBlood/IronBlood";
		case SkillType.ArmorOfWind:
			return FilePath.ActiveSkillEffectPath + "ArmorOfWind/ArmorOfWind";
		case SkillType.EmbracedShield:
			return FilePath.ActiveSkillEffectPath + "EmbracedShield/EmbracedShield";
		case SkillType.BloodCurse:
			return FilePath.ActiveSkillEffectPath + "BloodCurse/BloodCurse";
		case SkillType.HeartlessFire:
			return FilePath.ActiveSkillEffectPath + "HeartlessFire/HeartlessFireSeed";
		case SkillType.Formless:
			return FilePath.ActiveSkillEffectPath + "Formless/Formless";
		case SkillType.Sunder:
			return FilePath.ActiveSkillEffectPath + "Sunder/Sunder";
		case SkillType.SwiftWind:
			return FilePath.ActiveSkillEffectPath + "Swiftwind/Swiftwind";
		case SkillType.Drunkenness:
			return FilePath.ActiveSkillEffectPath + "Drunkenness/Drunkenness";
		case SkillType.Encouragement:
			return FilePath.ActiveSkillEffectPath + "Encouragement/Encouragement";
		case SkillType.Rotation:
			return FilePath.ActiveSkillEffectPath + "Rotation/Rotation";
		case SkillType.Punishment:
			return FilePath.ActiveSkillEffectPath + "Punishment";
		case SkillType.Frenzy:
			return FilePath.ActiveSkillEffectPath + "Frenzy/Frenzy";
		case SkillType.Seduction:
			return FilePath.ActiveSkillEffectPath + "Seduction/Seduction";
		case SkillType.DivineRemedy:
			return FilePath.ActiveSkillEffectPath + "DivineRemedy";
		case SkillType.Brutality:
			return FilePath.ActiveSkillEffectPath + "Brutality/Brutality";
		}
		return string.Empty;
	}

	// Token: 0x06004653 RID: 18003 RVA: 0x001C8F9B File Offset: 0x001C739B
	public static string GetActiveSkillSourceUnitEffect(SkillType SkillType)
	{
		if (SkillType != SkillType.HeartlessFire)
		{
			if (SkillType != SkillType.Dummy)
			{
			}
			return string.Empty;
		}
		return "Prefabs/BattleEffects/SpitFire/FireTornado";
	}

	// Token: 0x06004654 RID: 18004 RVA: 0x001C8FC3 File Offset: 0x001C73C3
	public static string GetNormalAttackPre()
	{
		return FilePath.SkillEffectPath + "Attack/Attack";
	}

	// Token: 0x06004655 RID: 18005 RVA: 0x001C8FD4 File Offset: 0x001C73D4
	public static string GetRegularSkillEffect(SkillType skillType)
	{
		switch (skillType)
		{
		case SkillType.Assassination:
			return FilePath.SkillEffectPath + "Slice/SlicePre";
		case SkillType.BladeRain:
			return FilePath.SkillEffectPath + "BloodSplatter/BloodSplatterPre";
		case SkillType.DeadlyBlade:
			return FilePath.SkillEffectPath + "CircleAttack/CircleAttackPre";
		case SkillType.Strike:
			return FilePath.SkillEffectPath + "StonePillar/StonePillarPre";
		case SkillType.MultiStrike:
			return FilePath.SkillEffectPath + "StonePillar/MultiStonePillarPre";
		case SkillType.StealSoul:
		case SkillType.Nightmare:
			return FilePath.SkillEffectPath + "StealSoul/StealSoulPre";
		case SkillType.Stun:
			return FilePath.SkillEffectPath + "Bite/BiteAttackPre";
		case SkillType.Taunt:
			return FilePath.SkillEffectPath + "Smoke1/SmokePre";
		case SkillType.Roar:
			return FilePath.SkillEffectPath + "Slash/SlashesPre";
		case SkillType.Relentless:
			return FilePath.SkillEffectPath + "WaterAttack1/WaterAttack1Pre";
		case SkillType.Scorn:
			return FilePath.SkillEffectPath + "StoneBreak/StoneBreakPre";
		case SkillType.FireBall:
			return FilePath.SkillEffectPath + "Fireball/FireballPre";
		case SkillType.Meteorolite:
			return FilePath.SkillEffectPath + "Arrow/MultiArrowPre";
		case SkillType.Lightning:
		case SkillType.Stray:
		case SkillType.Swift:
		case SkillType.LightFire:
		case SkillType.SoulSeeker:
		case SkillType.Undead:
		case SkillType.ReturningSoul:
		case SkillType.GhostlySmoke:
		case SkillType.PoisonousMist:
		case SkillType.Crash:
		case SkillType.ThousandKnives:
		case SkillType.Punishment:
		case SkillType.GrandMeteorolite:
			break;
		case SkillType.Freeze:
			return FilePath.SkillEffectPath + "Freeze/FreezePre";
		case SkillType.Arcane:
			return FilePath.SkillEffectPath + "Slice/SlicePre";
		case SkillType.DivineHammer:
			return FilePath.SkillEffectPath + "DivineHammer/DivineHammer";
		default:
			if (skillType != SkillType.None && skillType != SkillType.WeaponEnchantment)
			{
				return string.Empty;
			}
			break;
		case SkillType.Pray:
			return FilePath.SkillEffectPath + "Pray/PrayPre";
		case SkillType.BloodThirst:
			return FilePath.SkillEffectPath + "BloodAttack2/BloodAttack2Pre";
		case SkillType.Rage:
		case SkillType.Principle:
		case SkillType.Harmony:
		case SkillType.Flame:
		case SkillType.Flourish:
		case SkillType.LightningSpeed:
		case SkillType.Stamina:
			return FilePath.SkillEffectPath + "Consume/ConsumePre3";
		case SkillType.Rebirth:
			return FilePath.SkillEffectPath + "Consume/ConsumePre1";
		case SkillType.FleshToStone:
			return FilePath.SkillEffectPath + "StonePillar/StonePillarPre";
		case SkillType.Wave:
			return FilePath.SkillEffectPath + "WaterAttack3/WaterAttackPre";
		case SkillType.SwallowFire:
			return FilePath.SkillEffectPath + "ColoredExplosion/OrangeExplosion";
		case SkillType.Shadowless:
			return FilePath.SkillEffectPath + "DarkAttack/Shadowless1";
		case SkillType.WillOfFight:
			return FilePath.SkillEffectPath + "CircleAttack/CircleAttackPre";
		case SkillType.CorruptedPower:
			return FilePath.SkillEffectPath + "SpellBurn/SpellBurnPre";
		case SkillType.BurningHeart:
			return FilePath.SkillEffectPath + "BurnningHeart/BurnningHeart";
		case SkillType.GrandStrategy:
			return FilePath.SkillEffectPath + "ColoredExplosion/BlueExplosion";
		case SkillType.PoisonBlade:
			return FilePath.SkillEffectPath + "PoisonBlade/PoisonBlade";
		case SkillType.Pierce:
			return FilePath.SkillEffectPath + "Arrow/ArrowPre";
		case SkillType.SpellSlayer:
			return FilePath.SkillEffectPath + "WaterAttack2/WaterAttack2Pre";
		case SkillType.ShadowSacrifice:
			return FilePath.SkillEffectPath + "DarkAttack/DarkAttackPre";
		case SkillType.SeedsOfSin:
			return FilePath.SkillEffectPath + "Heal3/HealPre";
		case SkillType.Confusion:
			return FilePath.SkillEffectPath + "SlimeSplatter/SlimeSplatter2Pre";
		case SkillType.CurseOfCube:
			return FilePath.SkillEffectPath + "FireWarp/FireWarp2Pre";
		case SkillType.Shock:
			return FilePath.SkillEffectPath + "FireWarp/FireWarpPre";
		case SkillType.FireBreath:
			return FilePath.SkillEffectPath + "FireBreath/FireBreathPre";
		case SkillType.FireBlast:
			return FilePath.SkillEffectPath + "Bomb/BombPre";
		case SkillType.FistPunch:
			return FilePath.SkillEffectPath + "Bite/BitePre";
		case SkillType.Dance:
			return FilePath.SkillEffectPath + "Claw/Dance";
		case SkillType.FrenzeSpike:
			return FilePath.SkillEffectPath + "StoneAttack/StoneAttackPre3";
		case SkillType.ChargedBolt:
			return FilePath.SkillEffectPath + "EnergyExplosion/EnergyExplosionPre";
		case SkillType.Cleaning:
			return FilePath.SkillEffectPath + "DivineLight/EnemyLight2Pre";
		case SkillType.Purify:
			return FilePath.SkillEffectPath + "DivineLight/EnemyLightPre";
		case SkillType.ShieldBurn:
			return FilePath.SkillEffectPath + "FireWarp/FireWarpPre";
		case SkillType.FireBurst:
			return FilePath.SkillEffectPath + "Explosion3/Explosion3Pre";
		case SkillType.Swordmanship:
			return FilePath.SkillEffectPath + "BladeRain/SwordAttackEffect";
		}
		return string.Empty;
	}

	// Token: 0x06004656 RID: 18006 RVA: 0x001C9464 File Offset: 0x001C7864
	public static Sprite GetDefaultResourceImage()
	{
		Sprite[] array = Resources.LoadAll<Sprite>("Images/Tilesets/Pixel tileset -TopDown Town-/OutSideItem");
		return array[187];
	}

	// Token: 0x06004657 RID: 18007 RVA: 0x001C9483 File Offset: 0x001C7883
	public static Sprite GetDeadAvatarImage()
	{
		return FilePath.ResourceIcons[5];
	}

	// Token: 0x06004658 RID: 18008 RVA: 0x001C948C File Offset: 0x001C788C
	public static Sprite GetTransparnentImage()
	{
		Sprite[] array = Resources.LoadAll<Sprite>("Images/fantasy-sidescroller-game-kit/Tiles and Objects/Tiles");
		return array[89];
	}

	// Token: 0x06004659 RID: 18009 RVA: 0x001C94A8 File Offset: 0x001C78A8
	public static string GetCombatUnit(UnitClass @class)
	{
		switch (@class)
		{
		case UnitClass.PurpleOrc:
			return FilePath.CombatMonsterPath + "Pack1/Orc Purple";
		default:
			switch (@class)
			{
			case UnitClass.GreenGoblin:
				return FilePath.CombatMonsterPath + "Pack1/Goblin Green";
			case UnitClass.RedOrc:
				return FilePath.CombatMonsterPath + "Pack1/Orc Red";
			case UnitClass.YellowOrc:
				return FilePath.CombatMonsterPath + "Pack1/Orc Yellow";
			case UnitClass.SharpTeeth:
				return FilePath.CombatMonsterPath + "Pack1/Sharp Teeth Green";
			case UnitClass.GreenOrc:
				return FilePath.CombatMonsterPath + "Pack1/Orc Green";
			case UnitClass.PurpleSharpTeeth:
				return FilePath.CombatMonsterPath + "Pack1/Sharp Teeth Purple";
			default:
				switch (@class)
				{
				case UnitClass.DemonSkull:
					return FilePath.NewlyDownloadMonsters + "Bosses/boss_demon_skull/DemonSkull";
				case UnitClass.DevilMan:
					return FilePath.NewlyDownloadMonsters + "Bosses/boss_devil_man/DevilMan";
				case UnitClass.DemonDragon:
					return FilePath.NewlyDownloadMonsters + "Bosses/boss_fire_dragon/FireDragon";
				case UnitClass.Golem:
					return FilePath.NewlyDownloadMonsters + "Bosses/boss_golem/Golem";
				case UnitClass.GreedyMouth:
					return FilePath.NewlyDownloadMonsters + "Bosses/boss_greedy_mouth_1/GreedyMonth";
				case UnitClass.LavaBeast:
					return FilePath.NewlyDownloadMonsters + "Bosses/lava_beast/LavaBeast";
				case UnitClass.BloodyEye:
					return FilePath.NewlyDownloadMonsters + "Bosses/boss_bloody_eye/BloodyEye";
				case UnitClass.Death:
					return FilePath.NewlyDownloadMonsters + "Bosses/boss_death/BossDeath";
				case UnitClass.CorruptedHorn:
					return FilePath.NewlyDownloadMonsters + "Bosses/boss_devil_woman/DevilWoman";
				case UnitClass.Hydra:
					return FilePath.NewlyDownloadMonsters + "Bosses/boss_hydra/Hydra";
				case UnitClass.PurpleBerserker:
					return FilePath.NewlyDownloadMonsters + "berserker/PurpleBerserker";
				case UnitClass.BlueBerserker:
					return FilePath.NewlyDownloadMonsters + "berserker/BlueBerserker";
				case UnitClass.GreenBerserker:
					return FilePath.NewlyDownloadMonsters + "berserker/GreenBerserker";
				case UnitClass.ConjourerSpiritRed:
					return FilePath.CombatMonsterPath + "Pack3/Sprite Red";
				case UnitClass.ConjourerSpiritGreen:
					return FilePath.CombatMonsterPath + "Pack3/Sprite Green";
				case UnitClass.ConjourerSpiritBlue:
					return FilePath.CombatMonsterPath + "Pack3/Sprite Blue";
				case UnitClass.Thug1:
					return FilePath.CombatMonsterPath + "Villagers/Villager1";
				case UnitClass.Thug2:
					return FilePath.CombatMonsterPath + "Villagers/Villager4";
				case UnitClass.Thug3:
					return FilePath.CombatMonsterPath + "Villagers/Villager2";
				case UnitClass.Thug4:
					return FilePath.CombatMonsterPath + "Villagers/Villager5";
				case UnitClass.Thug5:
					return FilePath.CombatMonsterPath + "Villagers/Villager3";
				case UnitClass.Thug6:
					return FilePath.CombatMonsterPath + "Villagers/Villager6";
				case UnitClass.ThugLeader1:
					return FilePath.CombatMonsterPath + "Villagers/Villager_MiniBoss1";
				case UnitClass.ThugLeader2:
					return FilePath.CombatMonsterPath + "Villagers/Villager_MiniBoss2";
				case UnitClass.ThugLeader3:
					return FilePath.CombatMonsterPath + "Villagers/Villager_MiniBoss3";
				case UnitClass.ThugLeaderBoss:
					return FilePath.CombatMonsterPath + "Villagers/Villager_Boss4";
				case UnitClass.Nameless:
					return FilePath.CombatMonsterPath + "Villagers/Villager_Boss2";
				case UnitClass.ThugBoss1:
					return FilePath.CombatMonsterPath + "Villagers/Villager_Boss3";
				case UnitClass.ThugBoss2:
					return FilePath.CombatMonsterPath + "Villagers/Villager_Boss1";
				case UnitClass.BlueDemonDragon:
					return FilePath.NewlyDownloadMonsters + "Bosses/boss_fire_dragon/FireDragon2";
				default:
					switch (@class)
					{
					case UnitClass.YellowGoblin:
						return FilePath.CombatMonsterPath + "Pack1/Goblin Yellow";
					case UnitClass.RedSharpTeeth:
						return FilePath.CombatMonsterPath + "Pack1/Sharp Teeth Red";
					default:
						switch (@class)
						{
						case UnitClass.FirePlayer:
						case UnitClass.YoungWarlock:
						case UnitClass.Conjurer:
						case UnitClass.ElementalWizard:
						case UnitClass.RedMage:
						case UnitClass.Cube:
						case UnitClass.Missionary:
						case UnitClass.Killer:
						case UnitClass.FashionBoy:
						case UnitClass.SnowMaiden:
						case UnitClass.FireCharger:
						case UnitClass.GoldenShaman:
						case UnitClass.BunSister:
						case UnitClass.IronSolider:
						case UnitClass.DrunkReader:
							break;
						default:
							switch (@class)
							{
							case UnitClass.SoulThief:
							case UnitClass.FireAssassin:
							case UnitClass.NightBlade:
							case UnitClass.ToughWoman:
							case UnitClass.ChubbyLady:
							case UnitClass.RedHorn:
								break;
							default:
								switch (@class)
								{
								case UnitClass.Warrior:
								case UnitClass.Duelist:
								case UnitClass.Tactician:
								case UnitClass.Paladin:
								case UnitClass.StreetMan:
									break;
								default:
									if (@class == UnitClass.BlueOrc)
									{
										return FilePath.CombatMonsterPath + "Pack1/Orc Blue";
									}
									if (@class == UnitClass.BlueSharpTeeth)
									{
										return FilePath.CombatMonsterPath + "Pack1/Sharp Teeth Blue";
									}
									if (@class != UnitClass.StrangeSuperGuy)
									{
										return FilePath.CombatMonsterPath + "Pack1/Sharp Teeth Purple";
									}
									break;
								}
								break;
							}
							break;
						}
						return "Prefabs/CharactersCombat/AdventurerCombat";
					case UnitClass.RedGrassFace:
						return FilePath.CombatMonsterPath + "Pack1/Grass Face Red";
					case UnitClass.YellowGrassFace:
						return FilePath.CombatMonsterPath + "Pack1/Grass Face Yellow";
					case UnitClass.RedArcher:
						return FilePath.CombatMonsterPath + "Pack1/Archer Red";
					case UnitClass.BlueArcher:
						return FilePath.CombatMonsterPath + "Pack1/Archer Blue";
					case UnitClass.PurpleArcher:
						return FilePath.CombatMonsterPath + "Pack1/Archer Purple";
					case UnitClass.YellowArcher:
						return FilePath.CombatMonsterPath + "Pack1/Archer Yellow";
					case UnitClass.RedMud:
						return FilePath.CombatMonsterPath + "Pack1/Mud Red";
					case UnitClass.GreenMud:
						return FilePath.CombatMonsterPath + "Pack1/Mud Green";
					case UnitClass.PurpleMud:
						return FilePath.CombatMonsterPath + "Pack1/Mud Purple";
					case UnitClass.YellowMud:
						return FilePath.CombatMonsterPath + "Pack1/Mud Yellow";
					case UnitClass.BlueShadowKiller:
						return FilePath.CombatMonsterPath + "Pack1/Shadow Killer Blue";
					case UnitClass.YellowShadowKiller:
						return FilePath.CombatMonsterPath + "Pack1/Shadow Killer Yellow";
					case UnitClass.RedShadowKiller:
						return FilePath.CombatMonsterPath + "Pack1/Shadow Killer Red";
					case UnitClass.PurpleShadowKiller:
						return FilePath.CombatMonsterPath + "Pack1/Shadow Killer Purple";
					case UnitClass.Cyclops:
						return FilePath.NewlyDownloadMonsters + "cyclops/Cyclops";
					case UnitClass.ShadowSkinner:
						return FilePath.NewlyDownloadMonsters + "explorer/Explorer";
					case UnitClass.Parasite:
						return FilePath.NewlyDownloadMonsters + "parasite/Parasite";
					case UnitClass.Piper:
						return FilePath.NewlyDownloadMonsters + "piper/Piper";
					case UnitClass.Puppet:
						return FilePath.NewlyDownloadMonsters + "puppet/Puppet";
					case UnitClass.Ghoul:
						return FilePath.NewlyDownloadMonsters + "ghoul/Ghoul";
					case UnitClass.IceSkull:
						return FilePath.NewlyDownloadMonsters + "ice_skull/IceSkull";
					case UnitClass.Pharmacist:
						return FilePath.NewlyDownloadMonsters + "pharmacist/Pharmacist";
					case UnitClass.BlueCyclops:
						return FilePath.NewlyDownloadMonsters + "cyclops/BlueCyclops";
					case UnitClass.GreenCyclops:
						return FilePath.NewlyDownloadMonsters + "cyclops/GreenCyclops";
					case UnitClass.PurpleCyclops:
						return FilePath.NewlyDownloadMonsters + "cyclops/PurpleCyclops";
					case UnitClass.RedCyclops:
						return FilePath.NewlyDownloadMonsters + "cyclops/RedCyclops";
					}
					break;
				}
				break;
			case UnitClass.GreenSpearer:
				return FilePath.CombatMonsterPath + "Pack1/Spearer Green";
			case UnitClass.RedSpearer:
				return FilePath.CombatMonsterPath + "Pack1/Spearer Red";
			case UnitClass.PurpleSpearer:
				return FilePath.CombatMonsterPath + "Pack1/Spearer Purple";
			case UnitClass.YellowSpearer:
				return FilePath.CombatMonsterPath + "Pack1/Spearer Yellow";
			case UnitClass.GreenDoomFighter:
				return FilePath.CombatMonsterPath + "Pack1/Doom Fighter Green";
			case UnitClass.RedDoomFighter:
				return FilePath.CombatMonsterPath + "Pack1/Doom Fighter Red";
			case UnitClass.PurpleDoomFighter:
				return FilePath.CombatMonsterPath + "Pack1/Doom Fighter Purple";
			case UnitClass.BlueDoomFighter:
				return FilePath.CombatMonsterPath + "Pack1/Doom Fighter Blue";
			case UnitClass.GreenReaper:
				return FilePath.CombatMonsterPath + "Pack1/Reaper Green";
			case UnitClass.YellowReaper:
				return FilePath.CombatMonsterPath + "Pack1/Reaper Yellow";
			case UnitClass.RedReaper:
				return FilePath.CombatMonsterPath + "Pack1/Reaper Red";
			case UnitClass.PurpleReaper:
				return FilePath.CombatMonsterPath + "Pack1/Reaper Purple";
			case UnitClass.Berserker:
				return FilePath.NewlyDownloadMonsters + "berserker/RedBerserker";
			case UnitClass.DarkKnight:
				return FilePath.NewlyDownloadMonsters + "black_knight/BlackKnight";
			case UnitClass.CannibalBear:
				return FilePath.NewlyDownloadMonsters + "cannibal_bear/CannibalBear";
			case UnitClass.Devil:
				return FilePath.NewlyDownloadMonsters + "devil/Devil";
			case UnitClass.FireImp:
				return FilePath.NewlyDownloadMonsters + "flame_imp/FireImp";
			case UnitClass.HeartEater:
				return FilePath.NewlyDownloadMonsters + "magic_creature/MagicCreature";
			case UnitClass.EvilMask:
				return FilePath.NewlyDownloadMonsters + "mask/Mask";
			case UnitClass.Polymer:
				return FilePath.NewlyDownloadMonsters + "polymer/Polymer";
			case UnitClass.Werewolf:
				return FilePath.NewlyDownloadMonsters + "werewolf/Werewolf";
			case UnitClass.BloodDevil:
				return FilePath.NewlyDownloadMonsters + "blood_devil/BloodDevil";
			case UnitClass.BloodyCreature:
				return FilePath.NewlyDownloadMonsters + "bloody_creature/BloodyCreature";
			case UnitClass.Mutant:
				return FilePath.NewlyDownloadMonsters + "mutant/Mutant";
			case UnitClass.Ogre:
				return FilePath.NewlyDownloadMonsters + "ogre/Ogre";
			case UnitClass.Predator:
				return FilePath.NewlyDownloadMonsters + "predator/Predator";
			case UnitClass.Puppeteer:
				return FilePath.NewlyDownloadMonsters + "puppeteer/Puppeteer";
			case UnitClass.Savagery:
				return FilePath.NewlyDownloadMonsters + "savagery/Savagery";
			case UnitClass.BlacksmithBrother:
				return FilePath.NewlyDownloadMonsters + "swordsman/ZombieSwordsman";
			case UnitClass.ZombieWarrior:
				return FilePath.NewlyDownloadMonsters + "zombie_warrior/ZombieWarrior";
			case UnitClass.BlueDevil:
				return FilePath.NewlyDownloadMonsters + "devil/BlueDevilPre";
			case UnitClass.GreenDevil:
				return FilePath.NewlyDownloadMonsters + "devil/GreenDevilPre";
			case UnitClass.PurpleDevil:
				return FilePath.NewlyDownloadMonsters + "devil/PurpleDevilPre";
			case UnitClass.RedDevil:
				return FilePath.NewlyDownloadMonsters + "devil/RedDevilPre";
			case UnitClass.YellowDevil:
				return FilePath.NewlyDownloadMonsters + "devil/YellowDevilPre";
			case UnitClass.BlueCannibalBear:
				return FilePath.NewlyDownloadMonsters + "cannibal_bear/BlueCannibalBear";
			case UnitClass.GreenCannibalBear:
				return FilePath.NewlyDownloadMonsters + "cannibal_bear/GreenCannibalBear";
			case UnitClass.PurpleCannibalBear:
				return FilePath.NewlyDownloadMonsters + "cannibal_bear/PurpleCannibalBear";
			case UnitClass.RedCannibalBear:
				return FilePath.NewlyDownloadMonsters + "cannibal_bear/RedCannibalBear";
			case UnitClass.YellowCannibalBear:
				return FilePath.NewlyDownloadMonsters + "cannibal_bear/YellowCannibalBear";
			case UnitClass.BlueHeartEater:
				return FilePath.NewlyDownloadMonsters + "magic_creature/BlueMagicCreature";
			case UnitClass.GreenHeartEater:
				return FilePath.NewlyDownloadMonsters + "magic_creature/GreenMagicCreature";
			case UnitClass.RedHeartEater:
				return FilePath.NewlyDownloadMonsters + "magic_creature/RedMagicCreature";
			case UnitClass.YellowHeartEater:
				return FilePath.NewlyDownloadMonsters + "magic_creature/YellowMagicCreature";
			case UnitClass.RedMask:
				return FilePath.NewlyDownloadMonsters + "mask/RedMask";
			case UnitClass.BlacksmithBrother_Remnants:
				return FilePath.NewlyDownloadMonsters + "swordsman/ZombieSwordsman";
			case UnitClass.BloodEye_Remnants:
				return FilePath.NewlyDownloadMonsters + "Bosses/boss_bloody_eye/BloodyEye";
			case UnitClass.CorruptedHorn_Remnants:
				return FilePath.NewlyDownloadMonsters + "Bosses/boss_devil_woman/DevilWoman";
			case UnitClass.DarkKnight_Remnants:
				return FilePath.NewlyDownloadMonsters + "black_knight/BlackKnight";
			case UnitClass.Death_Remnants:
				return FilePath.NewlyDownloadMonsters + "Bosses/boss_death/BossDeath";
			case UnitClass.DemonDragon_Remnants:
				return FilePath.NewlyDownloadMonsters + "Bosses/boss_fire_dragon/FireDragon";
			case UnitClass.DemonSkull_Remnants:
				return FilePath.NewlyDownloadMonsters + "Bosses/boss_demon_skull/DemonSkull";
			case UnitClass.DevilMan_Remnants:
				return FilePath.NewlyDownloadMonsters + "Bosses/boss_devil_man/DevilMan";
			case UnitClass.Pharmacist_Remnants:
				return FilePath.NewlyDownloadMonsters + "pharmacist/Pharmacist";
			}
			break;
		case UnitClass.GrassFace:
			return FilePath.CombatMonsterPath + "Pack1/Grass Face Green";
		case UnitClass.ScreamingShaman:
			return FilePath.CombatMonsterPath + "Pack1/Shaman Green";
		case UnitClass.BlueShaman:
			return FilePath.CombatMonsterPath + "Pack1/Shaman Blue";
		case UnitClass.RedShaman:
			return FilePath.CombatMonsterPath + "Pack1/Shaman Red";
		case UnitClass.PurpleShaman:
			return FilePath.CombatMonsterPath + "Pack1/Shaman Purple";
		case UnitClass.YellowShaman:
			return FilePath.CombatMonsterPath + "Pack1/Shaman Yellow";
		case UnitClass.YellowSharpTeeth:
			return FilePath.CombatMonsterPath + "Pack1/Sharp Teeth Yellow";
		case UnitClass.BlueGrassFace:
			return FilePath.CombatMonsterPath + "Pack1/Grass Face Blue";
		case UnitClass.PurpleGrassFace:
			return FilePath.CombatMonsterPath + "Pack1/Grass Face Purple";
		case UnitClass.GreenDragonPrayer:
			return FilePath.CombatMonsterPath + "Pack1/Wizard Green";
		case UnitClass.YellowDragonPrayer:
			return FilePath.CombatMonsterPath + "Pack1/Wizard Yellow";
		case UnitClass.RedDragonPrayer:
			return FilePath.CombatMonsterPath + "Pack1/Wizard Red";
		case UnitClass.PurpleDragonPrayer:
			return FilePath.CombatMonsterPath + "Pack1/Wizard Purple";
		case UnitClass.RedShadowBat:
			return FilePath.CombatMonsterPath + "Pack1/Shadow Bat Red";
		case UnitClass.PurpleShadowBat:
			return FilePath.CombatMonsterPath + "Pack1/Shadow Bat Purple";
		case UnitClass.YellowShadowBat:
			return FilePath.CombatMonsterPath + "Pack1/Shadow Bat Yellow";
		case UnitClass.GreenShadowBat:
			return FilePath.CombatMonsterPath + "Pack1/Shadow Bat Green";
		case UnitClass.BlueShadowBat:
			return FilePath.CombatMonsterPath + "Pack1/Shadow Bat Blue";
		case UnitClass.RedBirdMonster:
			return FilePath.CombatMonsterPath + "Pack1/Bird Monster Red";
		case UnitClass.PurpleBirdMonster:
			return FilePath.CombatMonsterPath + "Pack1/Bird Monster Purple";
		case UnitClass.YellowBirdMonster:
			return FilePath.CombatMonsterPath + "Pack1/Bird Monster Yellow";
		case UnitClass.BlueBirdMonster:
			return FilePath.CombatMonsterPath + "Pack1/Bird Monster Blue";
		case UnitClass.GreenBirdMonster:
			return FilePath.CombatMonsterPath + "Pack1/Bird Monster Green";
		case UnitClass.BlueDragonPrayer:
			return FilePath.CombatMonsterPath + "Pack1/Wizard Blue";
		case UnitClass.BlueBat:
			return FilePath.CombatMonsterPath + "Pack3/Bat Blue";
		case UnitClass.GreenBat:
			return FilePath.CombatMonsterPath + "Pack3/Bat Green";
		case UnitClass.PurpleBat:
			return FilePath.CombatMonsterPath + "Pack3/Bat Purple";
		case UnitClass.RedBat:
			return FilePath.CombatMonsterPath + "Pack3/Bat Red";
		case UnitClass.YellowBat:
			return FilePath.CombatMonsterPath + "Pack3/Bat Yellow";
		case UnitClass.BlueGoblinWizard:
			return FilePath.CombatMonsterPath + "Pack3/GoblinWizard Blue";
		case UnitClass.GreenGoblinWizard:
			return FilePath.CombatMonsterPath + "Pack3/GoblinWizard Green";
		case UnitClass.PurpleGoblinWizard:
			return FilePath.CombatMonsterPath + "Pack3/GoblinWizard Purple";
		case UnitClass.RedGoblinWizard:
			return FilePath.CombatMonsterPath + "Pack3/GoblinWizard Red";
		case UnitClass.YellowGoblinWizard:
			return FilePath.CombatMonsterPath + "Pack3/GoblinWizard Yellow";
		case UnitClass.BlueHighMage:
			return FilePath.CombatMonsterPath + "Pack3/HighMage Blue";
		case UnitClass.GreenHighMage:
			return FilePath.CombatMonsterPath + "Pack3/HighMage Green";
		case UnitClass.PurpleHighMage:
			return FilePath.CombatMonsterPath + "Pack3/HighMage Purple";
		case UnitClass.RedHighMage:
			return FilePath.CombatMonsterPath + "Pack3/HighMage Red";
		case UnitClass.YellowHighMage:
			return FilePath.CombatMonsterPath + "Pack3/HighMage Yellow";
		case UnitClass.BlueScorpion:
			return FilePath.CombatMonsterPath + "Pack3/Scorpion Blue";
		case UnitClass.GreenScorpion:
			return FilePath.CombatMonsterPath + "Pack3/Scorpion Green";
		case UnitClass.PurpleScorpion:
			return FilePath.CombatMonsterPath + "Pack3/Scorpion Purple";
		case UnitClass.RedScorpion:
			return FilePath.CombatMonsterPath + "Pack3/Scorpion Red";
		case UnitClass.YellowScorpion:
			return FilePath.CombatMonsterPath + "Pack3/Scorpion Yellow";
		case UnitClass.BlueStoneGuard:
			return FilePath.CombatMonsterPath + "Pack3/StoneGuard Blue";
		case UnitClass.GreenStoneGuard:
			return FilePath.CombatMonsterPath + "Pack3/StoneGuard Green";
		case UnitClass.PurpleStoneGuard:
			return FilePath.CombatMonsterPath + "Pack3/StoneGuard Purple";
		case UnitClass.RedStoneGuard:
			return FilePath.CombatMonsterPath + "Pack3/StoneGuard Red";
		case UnitClass.YellowStoneGuard:
			return FilePath.CombatMonsterPath + "Pack3/StoneGuard Yellow";
		case UnitClass.BlueVampire:
			return FilePath.CombatMonsterPath + "Pack3/VampireLee Blue";
		case UnitClass.GreenVampire:
			return FilePath.CombatMonsterPath + "Pack3/VampireLee Green";
		case UnitClass.PurpleVampire:
			return FilePath.CombatMonsterPath + "Pack3/VampireLee Purple";
		case UnitClass.RedVampire:
			return FilePath.CombatMonsterPath + "Pack3/VampireLee Red";
		case UnitClass.YellowVampire:
			return FilePath.CombatMonsterPath + "Pack3/VampireLee Yellow";
		case UnitClass.Alchemist:
			return FilePath.NewlyDownloadMonsters + "Alchemist/alchemist/Alchemist";
		case UnitClass.FireMage:
			return FilePath.NewlyDownloadMonsters + "fire_mage/FireMage";
		case UnitClass.ImmortalSeeker:
			return FilePath.NewlyDownloadMonsters + "howling/Howling";
		case UnitClass.IceBeast:
			return FilePath.NewlyDownloadMonsters + "ice_beast/IceBeast";
		case UnitClass.MagicAmor:
			return FilePath.NewlyDownloadMonsters + "magic_armor/MagicArmor";
		case UnitClass.PoisonMage:
			return FilePath.NewlyDownloadMonsters + "poison_mage/PoisonMage";
		case UnitClass.SkeletonMage:
			return FilePath.NewlyDownloadMonsters + "skeleton_mage/SkeletonMage";
		case UnitClass.Trainer:
			return FilePath.NewlyDownloadMonsters + "trainer/Trainer";
		case UnitClass.BlackMage:
			return FilePath.NewlyDownloadMonsters + "black_mage/BlackMage";
		case UnitClass.DivineMage:
			return FilePath.NewlyDownloadMonsters + "divine_mage/DivineMage";
		case UnitClass.Glutton:
			return FilePath.NewlyDownloadMonsters + "glutton/Glutton";
		case UnitClass.IceMage:
			return FilePath.NewlyDownloadMonsters + "ice_mage/IceMage";
		case UnitClass.Skeleton:
			return FilePath.NewlyDownloadMonsters + "skeleton/Skeleton";
		case UnitClass.Stringy:
			return FilePath.NewlyDownloadMonsters + "stingy/Stringy";
		case UnitClass.RedImmortalSeeker:
			return FilePath.NewlyDownloadMonsters + "howling/RedHowling";
		case UnitClass.HealingStone:
			return FilePath.CombatMonsterPath + "Pack4/Stone/Stone_Heal";
		case UnitClass.FireStone:
			return FilePath.CombatMonsterPath + "Pack4/Stone/Stone_Fire";
		case UnitClass.LightningStone:
			return FilePath.CombatMonsterPath + "Pack4/Stone/Stone_Lightening";
		case UnitClass.PoisonStone:
			return FilePath.CombatMonsterPath + "Pack4/Stone/Stone_Poison";
		case UnitClass.BirdMonsterRed:
			return FilePath.NewlyDownloadMonsters + "pharmacist/pharmacist_red";
		case UnitClass.PurpleBloodEye:
			return FilePath.NewlyDownloadMonsters + "Bosses/boss_bloody_eye/BloodyEye_purple";
		case UnitClass.PurpleIceBeast:
			return FilePath.NewlyDownloadMonsters + "ice_beast/PurpleIceBeast";
		case UnitClass.RedIceBeast:
			return FilePath.NewlyDownloadMonsters + "ice_beast/RedIceBeast";
		}
	}

	// Token: 0x0600465A RID: 18010 RVA: 0x001CA5E8 File Offset: 0x001C89E8
	public static Sprite GetResidentEffectIcon(ResidentEffectType type)
	{
		switch (type)
		{
		case ResidentEffectType.Production:
			return FilePath.ResourceIcons[192];
		case ResidentEffectType.WeaponSale:
			return FilePath.ResourceIcons[95];
		case ResidentEffectType.ArmorSale:
			return FilePath.ResourceIcons[144];
		case ResidentEffectType.Luck:
			return FilePath.ResourceIcons[199];
		case ResidentEffectType.Practice:
			return FilePath.ResourceIcons[13];
		case ResidentEffectType.MysticStone:
			return FilePath.ResourceIcons[31];
		case ResidentEffectType.DivineHeart:
			return FilePath.ResourceIcons[187];
		case ResidentEffectType.Determination:
			return FilePath.ResourceIcons[200];
		case ResidentEffectType.Wealth:
			return FilePath.ResourceIcons[211];
		case ResidentEffectType.Recruitment:
			return FilePath.ResourceIcons[202];
		}
		return FilePath.ResourceIcons[27];
	}

	// Token: 0x0600465B RID: 18011 RVA: 0x001CA6A7 File Offset: 0x001C8AA7
	public static string GetEquipmentInfoDetails()
	{
		return FilePath.UiPath + "EquipmentInfoDetails";
	}

	// Token: 0x0600465C RID: 18012 RVA: 0x001CA6B8 File Offset: 0x001C8AB8
	public static string GetHealthDetails()
	{
		return FilePath.CombatScenePath + "HealthDetails";
	}

	// Token: 0x0600465D RID: 18013 RVA: 0x001CA6C9 File Offset: 0x001C8AC9
	public static string GetSelectedItemBackground()
	{
		return FilePath.UiPath + "SelectedItemBackground";
	}

	// Token: 0x0600465E RID: 18014 RVA: 0x001CA6DC File Offset: 0x001C8ADC
	public static string GetInfoText(InfoTextType type)
	{
		switch (type)
		{
		case InfoTextType.ProfessionLevelUp:
			return FilePath.UiPath + "AdventurerLevelUp";
		case InfoTextType.SkillLevelUp:
			return FilePath.UiPath + "SkillLevelUp";
		case InfoTextType.AdventureLevelUp:
			return FilePath.UiPath + "AdventurerLevelUp";
		case InfoTextType.SucceedInfo:
			return FilePath.BattleInfoPath + type;
		case InfoTextType.FaildInfo:
			return FilePath.BattleInfoPath + type;
		case InfoTextType.NormalInfoWhite:
			return FilePath.BattleInfoPath + type;
		case InfoTextType.NormalInfoBlack:
			return FilePath.BattleInfoPath + type;
		case InfoTextType.ReceivedResource:
			return FilePath.BattleInfoPath + "ResourceReceived";
		default:
			throw new ArgumentOutOfRangeException("type", type, null);
		}
	}

	// Token: 0x0600465F RID: 18015 RVA: 0x001CA7AC File Offset: 0x001C8BAC
	public static Sprite GetStoreIcon(BuildingType type)
	{
		if (type == BuildingType.WeaponShop)
		{
			return FilePath.DghzSprites[2490];
		}
		if (type != BuildingType.ArmorShop)
		{
			throw new Exception("Building prefab has not been assigned to BuildingType: " + type + ".");
		}
		return FilePath.DghzSprites[2973];
	}

	// Token: 0x06004660 RID: 18016 RVA: 0x001CA7FE File Offset: 0x001C8BFE
	public static Sprite GetSpeedBarAvatar(AdventureEncounterSlotType enemyType)
	{
		switch (enemyType)
		{
		case AdventureEncounterSlotType.Minion:
			return FilePath.UiElements[19];
		case AdventureEncounterSlotType.MiniBoss:
			return FilePath.UiElements[17];
		case AdventureEncounterSlotType.Boss:
			return FilePath.UiElements[67];
		default:
			return FilePath.UiElements[19];
		}
	}

	// Token: 0x06004661 RID: 18017 RVA: 0x001CA83C File Offset: 0x001C8C3C
	public static Sprite GetEnemyAvatarByUnitType(UnitClass @class)
	{
		switch (@class)
		{
		case UnitClass.PurpleOrc:
			return FilePath.NewEnemyImages[333];
		default:
			switch (@class)
			{
			case UnitClass.GreenGoblin:
				return FilePath.NewEnemyImages[118];
			case UnitClass.RedOrc:
				return FilePath.NewEnemyImages[325];
			case UnitClass.YellowOrc:
				return FilePath.NewEnemyImages[538];
			case UnitClass.SharpTeeth:
				return FilePath.NewEnemyImages[133];
			case UnitClass.GreenOrc:
				return FilePath.NewEnemyImages[83];
			case UnitClass.PurpleSharpTeeth:
				return FilePath.NewEnemyImages[381];
			default:
				switch (@class)
				{
				case UnitClass.YellowGoblin:
					return FilePath.NewEnemyImages[566];
				case UnitClass.RedSharpTeeth:
					return FilePath.NewEnemyImages[373];
				default:
					switch (@class)
					{
					case UnitClass.FirePlayer:
					case UnitClass.YoungWarlock:
					case UnitClass.Conjurer:
					case UnitClass.ElementalWizard:
					case UnitClass.RedMage:
					case UnitClass.Cube:
					case UnitClass.Missionary:
					case UnitClass.Killer:
					case UnitClass.FashionBoy:
					case UnitClass.SnowMaiden:
					case UnitClass.FireCharger:
					case UnitClass.BunSister:
					case UnitClass.IronSolider:
					case UnitClass.DrunkReader:
						break;
					default:
						switch (@class)
						{
						case UnitClass.SoulThief:
						case UnitClass.FireAssassin:
						case UnitClass.NightBlade:
						case UnitClass.ToughWoman:
						case UnitClass.ChubbyLady:
						case UnitClass.RedHorn:
							break;
						default:
							switch (@class)
							{
							case UnitClass.Warrior:
							case UnitClass.Duelist:
							case UnitClass.Tactician:
							case UnitClass.Paladin:
							case UnitClass.StreetMan:
								break;
							default:
								if (@class == UnitClass.BlueOrc)
								{
									return FilePath.NewEnemyImages[93];
								}
								if (@class == UnitClass.BlueSharpTeeth)
								{
									return FilePath.NewEnemyImages[141];
								}
								if (@class != UnitClass.StrangeSuperGuy)
								{
									return Resources.LoadAll<Sprite>("Images/Monsters/erodaxia")[9];
								}
								break;
							}
							break;
						}
						break;
					case UnitClass.GoldenShaman:
						return FilePath.NewEnemyImages[4];
					}
					return FilePath.GetCharacterBasicAppearance(@class, false).GetStandSprite();
				case UnitClass.RedGrassFace:
					return FilePath.NewEnemyImages[388];
				case UnitClass.YellowGrassFace:
					return FilePath.NewEnemyImages[583];
				case UnitClass.RedArcher:
					return FilePath.NewEnemyImages[261];
				case UnitClass.BlueArcher:
					return FilePath.NewEnemyImages[28];
				case UnitClass.PurpleArcher:
					return FilePath.NewEnemyImages[269];
				case UnitClass.YellowArcher:
					return FilePath.NewEnemyImages[495];
				case UnitClass.RedMud:
					return FilePath.NewEnemyImages[405];
				case UnitClass.GreenMud:
					return FilePath.NewEnemyImages[165];
				case UnitClass.PurpleMud:
					return FilePath.NewEnemyImages[413];
				case UnitClass.YellowMud:
					return FilePath.NewEnemyImages[592];
				case UnitClass.BlueShadowKiller:
					return FilePath.NewEnemyImages[188];
				case UnitClass.YellowShadowKiller:
					return FilePath.NewEnemyImages[599];
				case UnitClass.RedShadowKiller:
					return FilePath.NewEnemyImages[420];
				case UnitClass.PurpleShadowKiller:
					return FilePath.NewEnemyImages[428];
				}
				break;
			case UnitClass.GreenSpearer:
				return FilePath.NewEnemyImages[7];
			case UnitClass.RedSpearer:
				return FilePath.NewEnemyImages[245];
			case UnitClass.PurpleSpearer:
				return FilePath.NewEnemyImages[253];
			case UnitClass.YellowSpearer:
				return FilePath.NewEnemyImages[485];
			case UnitClass.GreenDoomFighter:
				return FilePath.NewEnemyImages[53];
			case UnitClass.RedDoomFighter:
				return FilePath.NewEnemyImages[293];
			case UnitClass.PurpleDoomFighter:
				return FilePath.NewEnemyImages[300];
			case UnitClass.BlueDoomFighter:
				return FilePath.NewEnemyImages[61];
			case UnitClass.GreenReaper:
				return FilePath.NewEnemyImages[180];
			case UnitClass.YellowReaper:
				return FilePath.NewEnemyImages[571];
			case UnitClass.RedReaper:
				return FilePath.NewEnemyImages[421];
			case UnitClass.PurpleReaper:
				return FilePath.NewEnemyImages[429];
			}
			break;
		case UnitClass.GrassFace:
			return FilePath.NewEnemyImages[151];
		case UnitClass.ScreamingShaman:
			return FilePath.NewEnemyImages[102];
		case UnitClass.BlueShaman:
			return FilePath.NewEnemyImages[109];
		case UnitClass.RedShaman:
			return FilePath.NewEnemyImages[341];
		case UnitClass.PurpleShaman:
			return FilePath.NewEnemyImages[349];
		case UnitClass.YellowShaman:
			return FilePath.NewEnemyImages[552];
		case UnitClass.YellowSharpTeeth:
			return FilePath.NewEnemyImages[576];
		case UnitClass.BlueGrassFace:
			return FilePath.NewEnemyImages[156];
		case UnitClass.PurpleGrassFace:
			return FilePath.NewEnemyImages[396];
		case UnitClass.GreenDragonPrayer:
			return FilePath.NewEnemyImages[37];
		case UnitClass.YellowDragonPrayer:
			return FilePath.NewEnemyImages[501];
		case UnitClass.RedDragonPrayer:
			return FilePath.NewEnemyImages[278];
		case UnitClass.PurpleDragonPrayer:
			return FilePath.NewEnemyImages[284];
		case UnitClass.RedShadowBat:
			return FilePath.NewEnemyImages[453];
		case UnitClass.PurpleShadowBat:
			return FilePath.NewEnemyImages[461];
		case UnitClass.YellowShadowBat:
			return FilePath.NewEnemyImages[585];
		case UnitClass.GreenShadowBat:
			return FilePath.NewEnemyImages[213];
		case UnitClass.BlueShadowBat:
			return FilePath.NewEnemyImages[221];
		case UnitClass.RedBirdMonster:
			return FilePath.NewEnemyImages[469];
		case UnitClass.PurpleBirdMonster:
			return FilePath.NewEnemyImages[477];
		case UnitClass.YellowBirdMonster:
			return FilePath.NewEnemyImages[595];
		case UnitClass.BlueBirdMonster:
			return FilePath.NewEnemyImages[238];
		case UnitClass.GreenBirdMonster:
			return FilePath.NewEnemyImages[230];
		case UnitClass.BlueDragonPrayer:
			return FilePath.NewEnemyImages[46];
		case UnitClass.BlueBat:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "32x32-bat-sprite_blue")[3];
		case UnitClass.GreenBat:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "32x32-bat-sprite_green")[3];
		case UnitClass.PurpleBat:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "32x32-bat-sprite")[3];
		case UnitClass.RedBat:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "32x32-bat-sprite_red")[3];
		case UnitClass.YellowBat:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "32x32-bat-sprite_yellow")[3];
		case UnitClass.BlueGoblinWizard:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "Enemies - Fantasy_blue")[35];
		case UnitClass.GreenGoblinWizard:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "Enemies - Fantasy_green")[35];
		case UnitClass.PurpleGoblinWizard:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "Enemies - Fantasy_purple")[35];
		case UnitClass.RedGoblinWizard:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "Enemies - Fantasy_red")[35];
		case UnitClass.YellowGoblinWizard:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "Enemies - Fantasy_yellow")[35];
		case UnitClass.BlueHighMage:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "HighMage_blue")[0];
		case UnitClass.GreenHighMage:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "HighMage_green")[0];
		case UnitClass.PurpleHighMage:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "HighMage_purple")[0];
		case UnitClass.RedHighMage:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "HighMage_red")[0];
		case UnitClass.YellowHighMage:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "HighMage_yellow")[0];
		case UnitClass.BlueScorpion:
			return Resources.LoadAll<Sprite>(FilePath.AdditionalEnemyImages + "Scorpion_blue")[4];
		case UnitClass.GreenScorpion:
			return Resources.LoadAll<Sprite>(FilePath.AdditionalEnemyImages + "Scorpion_green")[4];
		case UnitClass.PurpleScorpion:
			return Resources.LoadAll<Sprite>(FilePath.AdditionalEnemyImages + "Scorpion_purple")[4];
		case UnitClass.RedScorpion:
			return Resources.LoadAll<Sprite>(FilePath.AdditionalEnemyImages + "Scorpion_red")[4];
		case UnitClass.YellowScorpion:
			return Resources.LoadAll<Sprite>(FilePath.AdditionalEnemyImages + "Scorpion_yellow")[4];
		case UnitClass.BlueStoneGuard:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "robot_idle_blue")[0];
		case UnitClass.GreenStoneGuard:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "robot_idle_green")[0];
		case UnitClass.PurpleStoneGuard:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "robot_idle_purple")[0];
		case UnitClass.RedStoneGuard:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "robot_idle_red")[0];
		case UnitClass.YellowStoneGuard:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "robot_idle_yellow")[0];
		case UnitClass.BlueVampire:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "Enemies - Fantasy_blue")[0];
		case UnitClass.GreenVampire:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "Enemies - Fantasy_green")[0];
		case UnitClass.PurpleVampire:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "Enemies - Fantasy_purple")[0];
		case UnitClass.RedVampire:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "Enemies - Fantasy_red")[0];
		case UnitClass.YellowVampire:
			return Resources.LoadAll<Sprite>(FilePath.NewPackEnemyImages + "Enemies - Fantasy_yellow")[0];
		}
	}

	// Token: 0x06004662 RID: 18018 RVA: 0x001CB0D0 File Offset: 0x001C94D0
	public static Sprite GetSkillIconImage(SkillType type)
	{
		switch (type)
		{
		case SkillType.Assassination:
			return FilePath.DghzSprites[2045];
		case SkillType.BladeRain:
			return FilePath.DghzSprites[2057];
		case SkillType.DeadlyBlade:
			return FilePath.DghzSprites[2081];
		case SkillType.Strike:
			return FilePath.DghzSprites[2056];
		case SkillType.MultiStrike:
			return FilePath.DghzSprites[2044];
		case SkillType.StealSoul:
			return FilePath.DghzSprites[1954];
		case SkillType.Stun:
			return FilePath.DghzSprites[2047];
		case SkillType.Taunt:
			return FilePath.DghzSprites[2079];
		case SkillType.Roar:
			return FilePath.DghzSprites[2078];
		case SkillType.Relentless:
			return FilePath.DghzSprites[2040];
		case SkillType.Scorn:
			return FilePath.DghzSprites[1907];
		case SkillType.FireBall:
			return FilePath.DghzSprites[1848];
		case SkillType.Meteorolite:
			return FilePath.DghzSprites[1854];
		case SkillType.Lightning:
			return FilePath.DghzSprites[66];
		case SkillType.Freeze:
			return FilePath.DghzSprites[2049];
		case SkillType.Arcane:
			return FilePath.DghzSprites[1886];
		case SkillType.DivineHammer:
			return FilePath.DghzSprites[1969];
		case SkillType.DivineLight:
			return FilePath.DghzSprites[1963];
		case SkillType.Pray:
			return FilePath.DghzSprites[1968];
		case SkillType.BloodThirst:
			return FilePath.DghzSprites[1955];
		case SkillType.Rage:
			return FilePath.DghzSprites[2019];
		case SkillType.Principle:
			return FilePath.DghzSprites[2026];
		case SkillType.Rebirth:
			return FilePath.DghzSprites[2050];
		default:
			if (type != SkillType.None)
			{
				if (type == SkillType.WeaponEnchantment)
				{
					return FilePath.DghzSprites[2087];
				}
			}
			return FilePath.DghzSprites[2085];
		case SkillType.FleshToStone:
			return FilePath.DghzSprites[2011];
		case SkillType.Harmony:
			return FilePath.DghzSprites[2073];
		case SkillType.Flame:
			return FilePath.DghzSprites[0];
		case SkillType.Flourish:
			return FilePath.DghzSprites[1912];
		case SkillType.LightningSpeed:
			return FilePath.DghzSprites[1885];
		case SkillType.Wave:
			return FilePath.DghzSprites[1865];
		case SkillType.Stamina:
			return FilePath.DghzSprites[2016];
		case SkillType.SwallowFire:
			return FilePath.DghzSprites[1853];
		case SkillType.Shadowless:
			return FilePath.DghzSprites[171];
		case SkillType.WillOfFight:
			return FilePath.DghzSprites[178];
		case SkillType.BrightCircle:
			return FilePath.DghzSprites[75];
		case SkillType.CorruptedPower:
			return FilePath.DghzSprites[167];
		case SkillType.BurningHeart:
			return FilePath.DghzSprites[40];
		case SkillType.GrandStrategy:
			return FilePath.DghzSprites[119];
		case SkillType.PoisonBlade:
			return FilePath.DghzSprites[102];
		case SkillType.Pierce:
			return FilePath.DghzSprites[133];
		case SkillType.SpellSlayer:
			return FilePath.DghzSprites[131];
		case SkillType.ShadowSacrifice:
			return FilePath.DghzSprites[164];
		case SkillType.SeedsOfSin:
			return FilePath.DghzSprites[160];
		case SkillType.Confusion:
			return FilePath.DghzSprites[75];
		case SkillType.CurseOfCube:
			return FilePath.DghzSprites[42];
		case SkillType.Shock:
			return FilePath.DghzSprites[234];
		case SkillType.FireBreath:
			return FilePath.DghzSprites[43];
		case SkillType.FireBlast:
			return FilePath.DghzSprites[33];
		case SkillType.FistPunch:
			return FilePath.DghzSprites[224];
		case SkillType.Nightmare:
			return FilePath.DghzSprites[135];
		case SkillType.Dance:
			return FilePath.DghzSprites[169];
		case SkillType.FrenzeSpike:
			return FilePath.DghzSprites[236];
		case SkillType.Stray:
			return FilePath.DghzSprites[192];
		case SkillType.Swift:
			return FilePath.DghzSprites[243];
		case SkillType.ChargedBolt:
			return FilePath.DghzSprites[71];
		case SkillType.Cleaning:
			return FilePath.DghzSprites[98];
		case SkillType.Purify:
		case SkillType.ShieldBurn:
			return FilePath.DghzSprites[34];
		case SkillType.LightFire:
			return FilePath.DghzSprites[0];
		case SkillType.SoulSeeker:
			return FilePath.DghzSprites[169];
		case SkillType.Undead:
			return FilePath.DghzSprites[148];
		case SkillType.ReturningSoul:
			return FilePath.DghzSprites[89];
		case SkillType.FireBurst:
			return FilePath.DghzSprites[37];
		case SkillType.Dummy:
			return FilePath.DghzSprites[34];
		case SkillType.SpellOfHoliness:
			return FilePath.DghzSprites[218];
		case SkillType.SpiritOfDemon:
			return FilePath.DghzSprites[163];
		case SkillType.IronBlood:
			return FilePath.DghzSprites[2012];
		case SkillType.ArmorOfWind:
			return FilePath.DghzSprites[112];
		case SkillType.EmbracedShield:
			return FilePath.DghzSprites[155];
		case SkillType.BloodCurse:
			return FilePath.DghzSprites[2032];
		case SkillType.HeartlessFire:
			return FilePath.DghzSprites[35];
		case SkillType.CurseOfTheDead:
			return FilePath.DghzSprites[2051];
		case SkillType.Formless:
			return FilePath.DghzSprites[145];
		case SkillType.GhostlySmoke:
			return FilePath.DghzSprites[134];
		case SkillType.GodsFire:
			return FilePath.DghzSprites[39];
		case SkillType.PoisonousMist:
			return FilePath.DghzSprites[104];
		case SkillType.Sunder:
			return FilePath.DghzSprites[2010];
		case SkillType.SwiftWind:
			return FilePath.DghzSprites[118];
		case SkillType.Crash:
			return FilePath.DghzSprites[209];
		case SkillType.Drunkenness:
			return FilePath.DghzSprites[2002];
		case SkillType.ThousandKnives:
			return FilePath.DghzSprites[2058];
		case SkillType.Encouragement:
			return FilePath.DghzSprites[212];
		case SkillType.Rotation:
			return FilePath.DghzSprites[201];
		case SkillType.Punishment:
			return FilePath.DghzSprites[146];
		case SkillType.GrandMeteorolite:
			return FilePath.DghzSprites[170];
		case SkillType.Frenzy:
			return FilePath.DghzSprites[2048];
		case SkillType.Seduction:
			return FilePath.DghzSprites[1997];
		case SkillType.DivineRemedy:
			return FilePath.DghzSprites[1967];
		case SkillType.Brutality:
			return FilePath.DghzSprites[228];
		case SkillType.Swordmanship:
			return FilePath.DghzSprites[2089];
		}
	}

	// Token: 0x06004663 RID: 18019 RVA: 0x001CB658 File Offset: 0x001C9A58
	public static Sprite GetDefaultEquipmentIcon(ItemType type)
	{
		switch (type)
		{
		case ItemType.Weapon:
			return FilePath.DghzSprites[2430];
		case ItemType.Armor:
			return FilePath.DghzSprites[2410];
		case ItemType.Accessory:
			return FilePath.DghzSprites[3602];
		case ItemType.Normal:
			return FilePath.DghzSprites[3602];
		default:
			return null;
		}
	}

	// Token: 0x06004664 RID: 18020 RVA: 0x001CB6B4 File Offset: 0x001C9AB4
	public static Tuple<Material, Sprite> GetAdventurerStatusMatAndSprite(AdventureCompleteType status)
	{
		switch (status)
		{
		case AdventureCompleteType.Successful:
			return new Tuple<Material, Sprite>(Resources.Load<Material>("Fonts/Chinese Mesh/UITextMat/RewardTitleGreen"), FilePath.DghzSprites[2942]);
		case AdventureCompleteType.Failure:
			return new Tuple<Material, Sprite>(Resources.Load<Material>("Fonts/Chinese Mesh/UITextMat/RewardTitleRed"), FilePath.DghzSprites[2939]);
		case AdventureCompleteType.PulledOff:
			return new Tuple<Material, Sprite>(Resources.Load<Material>("Fonts/Chinese Mesh/UITextMat/RewardTitleNormal"), FilePath.DghzSprites[2940]);
		default:
			throw new ArgumentOutOfRangeException("status", status, null);
		}
	}

	// Token: 0x06004665 RID: 18021 RVA: 0x001CB73C File Offset: 0x001C9B3C
	public static Sprite GetDefaultEquipmentIconByEquipmentType(EquipmentType type)
	{
		switch (type)
		{
		case EquipmentType.Weapon:
			return FilePath.DghzSprites[2430];
		case EquipmentType.Armor:
			return FilePath.DghzSprites[2410];
		case EquipmentType.Accessory1:
			return FilePath.DghzSprites[3602];
		case EquipmentType.Accessory2:
			return FilePath.DghzSprites[3602];
		default:
			return null;
		}
	}

	// Token: 0x06004666 RID: 18022 RVA: 0x001CB797 File Offset: 0x001C9B97
	public static Sprite GetAttackTypeIconByOutputType(AttributeType outputType)
	{
		if (outputType == AttributeType.Strength)
		{
			return FilePath.ResourceIcons[96];
		}
		if (outputType != AttributeType.Intelligience)
		{
			return FilePath.ResourceIcons[88];
		}
		return FilePath.ResourceIcons[118];
	}

	// Token: 0x06004667 RID: 18023 RVA: 0x001CB7C6 File Offset: 0x001C9BC6
	public static Sprite GetWeaponRecipeImage()
	{
		return FilePath.ResourceIcons[190];
	}

	// Token: 0x06004668 RID: 18024 RVA: 0x001CB7D3 File Offset: 0x001C9BD3
	public static Sprite GetAmorRecipeImage()
	{
		return FilePath.ResourceIcons[187];
	}

	// Token: 0x06004669 RID: 18025 RVA: 0x001CB7E0 File Offset: 0x001C9BE0
	public static Sprite GetAdventureInvitation()
	{
		return FilePath.ResourceIcons[202];
	}

	// Token: 0x0600466A RID: 18026 RVA: 0x001CB7F0 File Offset: 0x001C9BF0
	public static Sprite GetRewardInChestImage(QualityGrade type)
	{
		Sprite[] array = Resources.LoadAll<Sprite>("Prefabs/Eric/Battle/Chest/Bags/bags");
		switch (type)
		{
		case QualityGrade.Normal:
			return array[0];
		case QualityGrade.Rare:
			return array[1];
		case QualityGrade.Epic:
			return array[2];
		case QualityGrade.Legendary:
			return array[3];
		case QualityGrade.Ancient:
			return array[4];
		default:
			return array[0];
		}
	}

	// Token: 0x0600466B RID: 18027 RVA: 0x001CB840 File Offset: 0x001C9C40
	public static Sprite GetResourceCategoryIcon(ResourceCategory category)
	{
		switch (category)
		{
		case ResourceCategory.None:
			return FilePath.ResourceIcons[27];
		case ResourceCategory.Sword:
			return FilePath.ResourceIcons[97];
		case ResourceCategory.Knife:
			return FilePath.ResourceIcons[100];
		case ResourceCategory.Staff:
			return FilePath.ResourceIcons[117];
		case ResourceCategory.Axe:
			return FilePath.ResourceIcons[105];
		case ResourceCategory.Spear:
			return FilePath.ResourceIcons[107];
		case ResourceCategory.Robe:
			return FilePath.ResourceIcons[152];
		case ResourceCategory.Leather:
			return FilePath.ResourceIcons[154];
		case ResourceCategory.Plate:
			return FilePath.ResourceIcons[158];
		case ResourceCategory.Gem:
			return FilePath.ResourceIcons[31];
		case ResourceCategory.Ore:
			return FilePath.ResourceIcons[280];
		case ResourceCategory.Timber:
			return FilePath.ResourceIcons[277];
		case ResourceCategory.Hides:
			return FilePath.ResourceIcons[248];
		case ResourceCategory.Accessory:
			return FilePath.ResourceIcons[174];
		case ResourceCategory.GameItem:
			return FilePath.ResourceIcons[27];
		case ResourceCategory.CoreResource:
			return FilePath.ResourceIcons[27];
		case ResourceCategory.Consumable:
			return FilePath.DghzSprites[316];
		case ResourceCategory.ProductionRecipe:
			if (category.IsArmor())
			{
				return FilePath.GetWeaponRecipeImage();
			}
			if (category.IsWeapon())
			{
				return FilePath.GetAmorRecipeImage();
			}
			return FilePath.ResourceIcons[188];
		case ResourceCategory.AdventurerInvitation:
			return FilePath.GetAdventureInvitation();
		case ResourceCategory.BuildingPermit:
			return FilePath.DghzSprites[467];
		case ResourceCategory.Usable:
			return FilePath.DghzSprites[2172];
		}
		Debug.LogError("category   " + category);
		return FilePath.ResourceIcons[27];
	}

	// Token: 0x0600466C RID: 18028 RVA: 0x001CB9CA File Offset: 0x001C9DCA
	public static Sprite GetQuestRewardIcon(RewardType type)
	{
		return FilePath.DghzSprites[3523];
	}

	// Token: 0x0600466D RID: 18029 RVA: 0x001CB9DC File Offset: 0x001C9DDC
	public static Sprite GetCoreResourcesTypeImage(ResourceType coreResourceType)
	{
		if (coreResourceType == ResourceType.Money)
		{
			return FilePath.ResourceIcons[211];
		}
		if (coreResourceType != ResourceType.PracticePoints)
		{
			return FilePath.ResourceIcons[27];
		}
		return FilePath.DghzSprites[2136];
	}

	// Token: 0x0600466E RID: 18030 RVA: 0x001CBA1C File Offset: 0x001C9E1C
	public static Sprite GetRecipeImage(ResourceType type)
	{
		switch (type.GetResourceCategory())
		{
		case ResourceCategory.Gem:
			return FilePath.GetGemImage(type);
		case ResourceCategory.ProductionRecipe:
		{
			ResourceCategory resourceCategory = type.GetRecipeByRecipeName().ProductType.GetResourceCategory();
			if (resourceCategory.IsArmor())
			{
				return FilePath.GetWeaponRecipeImage();
			}
			if (resourceCategory.IsWeapon())
			{
				return FilePath.GetAmorRecipeImage();
			}
			break;
		}
		case ResourceCategory.AdventurerInvitation:
			return FilePath.GetAdventureInvitation();
		case ResourceCategory.BuildingPermit:
			return FilePath.DghzSprites[2283];
		case ResourceCategory.SkillBooks:
			return FilePath.ResourceIcons[184];
		}
		switch (type)
		{
		case ResourceType.WoodenWandRecipe:
		case ResourceType.SpiritualWandRecipe:
		case ResourceType.WizardsWandRecipe:
		case ResourceType.WandOfFireRecipe:
		case ResourceType.WoodenSwordRecipe:
		case ResourceType.MingSwordRecipe:
		case ResourceType.LongSwordRecipe:
		case ResourceType.MasterWusPracticeSwordRecipe:
		case ResourceType.SleekKnifeRecipe:
		case ResourceType.BlackBladeRecipe:
		case ResourceType.PrisonersBladeRecipe:
		case ResourceType.IronWandRecipe:
		case ResourceType.ShamansStaffRecipe:
		case ResourceType.RedWandRecipe:
		case ResourceType.AgileWandRecipe:
		case ResourceType.IronSwordRecipe:
		case ResourceType.RedSwordRecipe:
		case ResourceType.WaterSwordRecipe:
		case ResourceType.LightAxeRecipe:
		case ResourceType.LongSpearRecipe:
		case ResourceType.IronSpearRecipe:
		case ResourceType.LighteningSpearRecipe:
		case ResourceType.HeavySpearRecipe:
		case ResourceType.ClothGownRecipe:
		case ResourceType.JuniorMonksRobeRecipe:
		case ResourceType.MagicRobeRecipe:
		case ResourceType.RoughLeatherRecipe:
		case ResourceType.HuntersLeatherRecipe:
		case ResourceType.HuLeatherRecipe:
		case ResourceType.CopperCoatedPlateRecipe:
		case ResourceType.HardenedPlateRecipe:
		case ResourceType.RedPlateRecipe:
		case ResourceType.MoonRobeRecipe:
		case ResourceType.MingRobeRecipe:
		case ResourceType.SwiftEyeRobeRecipe:
		case ResourceType.WhiteLeatherRecipe:
		case ResourceType.RedLeatherRecipe:
		case ResourceType.ToughLeatherRecipe:
		case ResourceType.PlateOfStrengthRecipe:
		case ResourceType.ThickPlateRecipe:
		case ResourceType.MingPlateRecipe:
		case ResourceType.LifePotionOneRecipe:
		case ResourceType.FameOneRecipe:
		case ResourceType.LifePotionTwoRecipe:
		case ResourceType.LifePotionThreeRecipe:
		case ResourceType.LifePotionFourRecipe:
		case ResourceType.FameTwoRecipe:
		case ResourceType.FameThreeRecipe:
		case ResourceType.FameFourRecipe:
		case ResourceType.ExorcistsWandRecipe:
		case ResourceType.FallenRainRecipe:
		case ResourceType.DragonTeethRecipe:
		case ResourceType.SeaRecipe:
		case ResourceType.SwordOfMoonRecipe:
		case ResourceType.SwordOfSpringRecipe:
		case ResourceType.DeadEndAxeRecipe:
		case ResourceType.GoldenBladeRecipe:
		case ResourceType.AshRecipe:
		case ResourceType.WindRecipe:
		case ResourceType.GrowthRecipe:
		case ResourceType.DesperationRecipe:
		case ResourceType.HeavenRecipe:
		case ResourceType.DevilsSpiritRecipe:
		case ResourceType.ThroatCutterRecipe:
		case ResourceType.YellowRiverRecipe:
		case ResourceType.GoldenWoodRecipe:
		case ResourceType.GoldenFairyRecipe:
		case ResourceType.LightenningRecipe:
		case ResourceType.GoldenAxeRecipe:
		case ResourceType.DivineBladeRecipe:
		case ResourceType.NightmareRecipe:
		case ResourceType.HastedHeartRecipe:
		case ResourceType.DecayedEyesRecipe:
		case ResourceType.HeavyWeightRecipe:
		case ResourceType.ProtectorsSwordRecipe:
		case ResourceType.RoyalBladeRecipe:
		case ResourceType.FlyingBirdRecipe:
		case ResourceType.DragonSpearRecipe:
		case ResourceType.HeavenSongRecipe:
		case ResourceType.GodsRageRecipe:
		case ResourceType.FlyingDragonRecipe:
		case ResourceType.BarrenRecipe:
		case ResourceType.KunlunRecipe:
		case ResourceType.InsignificantThingRecipe:
		case ResourceType.GiantSwordRecipe:
		case ResourceType.MysticSwordRecipe:
		case ResourceType.WhisperRecipe:
		case ResourceType.MandateOfHeavenRecipe:
		case ResourceType.MonkeyBladeRecipe:
		case ResourceType.DevilMastersBladeRecipe:
		case ResourceType.FlyingFoxRecipe:
		case ResourceType.BloodCrystalBladeRecipe:
		case ResourceType.DesolationSpearRecipe:
		case ResourceType.DoomRecipe:
		case ResourceType.StarChaserRecipe:
		case ResourceType.SwiftAxeRecipe:
		case ResourceType.DragonSlayerRecipe:
		case ResourceType.AromaticRobeRecipe:
		case ResourceType.ElfsRobeRecipe:
		case ResourceType.BlackLeatherRecipe:
		case ResourceType.TaichiLeatherRecipe:
		case ResourceType.GreenPlateRecipe:
		case ResourceType.HeavyPlateRecipe:
		case ResourceType.GoldSilkRecipe:
		case ResourceType.RobeOfFireRecipe:
		case ResourceType.SnakeRecipe:
		case ResourceType.MistRecipe:
		case ResourceType.WarriorsPlateRecipe:
		case ResourceType.DivinePlateRecipe:
		case ResourceType.BloodRobeRecipe:
		case ResourceType.DefusedLeatherRecipe:
		case ResourceType.WildnessRecipe:
		case ResourceType.VoidRecipe:
		case ResourceType.ShadowRecipe:
		case ResourceType.SlaughterRecipe:
		case ResourceType.MastersRobeRecipe:
		case ResourceType.ConvergenceRecipe:
		case ResourceType.CursedFireRecipe:
		case ResourceType.InfinitePowerRecipe:
		case ResourceType.StormfuryRecipe:
		case ResourceType.DescerationRecipe:
		case ResourceType.IncarnationRecipe:
		case ResourceType.FallenSoulsRecipe:
		case ResourceType.EndlessFortunesRecipe:
		case ResourceType.LostDreamsRecipe:
		case ResourceType.DiligenceRecipe:
		case ResourceType.BloodDragonRecipe:
		case ResourceType.SalvationRecipe:
		case ResourceType.FadeRecipe:
		case ResourceType.HellishMailRecipe:
		case ResourceType.DivineSoulsRecipe:
		case ResourceType.DragonProtectorRecipe:
		case ResourceType.SupremeGodsPlateRecipe:
		case ResourceType.CurvedWandRecipe:
		case ResourceType.BrightWandRecipe:
		case ResourceType.DecoratedWandRecipe:
		case ResourceType.HiddenWoodRecipe:
		case ResourceType.SoakedBranchRecipe:
		case ResourceType.SerratedSwordRecipe:
		case ResourceType.SmallSwordRecipe:
		case ResourceType.BoldEdgeRecipe:
		case ResourceType.HuntersBladeRecipe:
		case ResourceType.HarvestRecipe:
		case ResourceType.CandyWandRecipe:
		case ResourceType.FireyWavesApprenticeWandRecipe:
		case ResourceType.ChaserRecipe:
		case ResourceType.SwordOfCourageRecipe:
		case ResourceType.SingingSwordRecipe:
		case ResourceType.ChaosRecipe:
		case ResourceType.FiresoulSwiftbladeRecipe:
		case ResourceType.KnightfallRecipe:
		case ResourceType.IcebreakerRecipe:
		case ResourceType.ChampionsHammerRecipe:
		case ResourceType.SpellbinderRecipe:
		case ResourceType.TranquilityRecipe:
		case ResourceType.EpilogueRecipe:
		case ResourceType.EdgeOfInsanityRecipe:
		case ResourceType.VengeanceRecipe:
		case ResourceType.CryingWarbladeRecipe:
		case ResourceType.MercyRecipe:
		case ResourceType.StormBasherRecipe:
		case ResourceType.LifeDrinkerRecipe:
		case ResourceType.StingerRecipe:
		case ResourceType.FlameGuardRecipe:
		case ResourceType.MoonlightRecipe:
		case ResourceType.MirageRecipe:
		case ResourceType.HeartseekerRecipe:
		case ResourceType.FleshrenderRecipe:
		case ResourceType.GrasscutterRecipe:
		case ResourceType.LastRitesRecipe:
		case ResourceType.OathkeeperRecipe:
		case ResourceType.BrutalityRecipe:
		case ResourceType.SwanSongRecipe:
		case ResourceType.UnholyBlightRecipe:
		case ResourceType.FireyWavesFallenSoulRecipe:
		case ResourceType.CollectorsReliefRecipe:
		case ResourceType.DragonKingsWhisperRecipe:
		case ResourceType.AncientDragonBladeRecipe:
		case ResourceType.RoyalLongSwordRecipe:
		case ResourceType.PrincesFallenSoulRecipe:
		case ResourceType.SwordOfRegretRecipe:
		case ResourceType.WrathfulBloodbladeRecipe:
		case ResourceType.TwistedSoulRecipe:
		case ResourceType.BurningStarRecipe:
		case ResourceType.SoulstealerSwordRecipe:
		case ResourceType.PrincesEtiquetteRecipe:
		case ResourceType.BetrayersBladeRecipe:
		case ResourceType.HellfireSpearRecipe:
		case ResourceType.GrandCandyWandRecipe:
		case ResourceType.CollectorsFameRecipe:
		case ResourceType.DeadMatchOneRecipe:
		case ResourceType.DeadMatchTwoRecipe:
		case ResourceType.DeadMatchThreeRecipe:
		case ResourceType.DeadMatchFourRecipe:
		case ResourceType.PhenixOneRecipe:
		case ResourceType.PhenixTwoRecipe:
		case ResourceType.PhenixThreeRecipe:
		case ResourceType.PhenixFourRecipe:
		case ResourceType.DragonSealOneRecipe:
		case ResourceType.DragonSealTwoRecipe:
		case ResourceType.DragonSealThreeRecipe:
		case ResourceType.DragonSealFourRecipe:
		case ResourceType.ClearWaterOneRecipe:
		case ResourceType.ClearWaterTwoRecipe:
		case ResourceType.ClearWaterThreeRecipe:
		case ResourceType.ClearWaterFourRecipe:
		case ResourceType.CollectorOneRecipe:
		case ResourceType.CollectorTwoRecipe:
		case ResourceType.CollectorThreeRecipe:
		case ResourceType.CollectorFourRecipe:
		case ResourceType.InsolenceOneRecipe:
		case ResourceType.InsolenceTwoRecipe:
		case ResourceType.InsolenceThreeRecipe:
		case ResourceType.InsolenceFourRecipe:
		case ResourceType.LighteningRunnerOneRecipe:
		case ResourceType.LighteningRunnerTwoRecipe:
		case ResourceType.LighteningRunnerThreeRecipe:
		case ResourceType.LighteningRunnerFourRecipe:
		case ResourceType.SoulSealOneRecipe:
		case ResourceType.SoulSealTwoRecipe:
		case ResourceType.SoulSealThreeRecipe:
		case ResourceType.SoulSealFourRecipe:
		case ResourceType.GuardOfLostComradesRecipe:
		case ResourceType.RobeOfDemonicSorrowRecipe:
		case ResourceType.ResentmentRecipe:
		case ResourceType.BurdenOfAssassinsRecipe:
		case ResourceType.SilkVestRecipe:
		case ResourceType.PlateOfGiantslayingRecipe:
		case ResourceType.CursedVestOfTheForestRecipe:
		case ResourceType.RobeOfInfiniteHopeRecipe:
		case ResourceType.RobeOfLostTormentRecipe:
		case ResourceType.CryOfNecromancyRecipe:
		case ResourceType.LeatherOfDisciplineRecipe:
		case ResourceType.PledgeOfThunderRecipe:
		case ResourceType.EnergyOfProtectionRecipe:
		case ResourceType.RobeOfStealthRecipe:
		case ResourceType.PledgeOfDemonFireRecipe:
		case ResourceType.GiftOfEternityRecipe:
		case ResourceType.RobeOfAncientMiseryRecipe:
		case ResourceType.LeatherOfHolyMightRecipe:
		case ResourceType.LeatherOfTraitorsRecipe:
		case ResourceType.LeatherOfTimelessNightmaresRecipe:
		case ResourceType.BlessingOfTwilightRecipe:
		case ResourceType.BondOfDelusionsRecipe:
		case ResourceType.PlateOfBlackFortuneRecipe:
		case ResourceType.PlateOfTheUniverseRecipe:
		case ResourceType.EnigmaOfDeathRecipe:
		case ResourceType.RobeOfTheCorruptedRecipe:
		case ResourceType.HopeOfIceRecipe:
		case ResourceType.PunishmentRecipe:
		case ResourceType.ProtectorOfFeralRecipe:
		case ResourceType.LeatherOfBasiliskRecipe:
		case ResourceType.WrapsOfBrokenSoulsRecipe:
		case ResourceType.SteelOfBloodshedRecipe:
		case ResourceType.ReachOfTerrorRecipe:
		case ResourceType.DefenseOfThePhoenixRecipe:
		case ResourceType.DawnOfTheSummonerRecipe:
		case ResourceType.LeatherOfRegretsRecipe:
		case ResourceType.DefenderOfTheDaywalkerRecipe:
		case ResourceType.PactOfMoonlightRecipe:
		case ResourceType.LeatherOfTimelessDreamsRecipe:
		case ResourceType.PlateOfTheCataclysmRecipe:
		case ResourceType.PromisedRobeOfRedemptionRecipe:
		case ResourceType.GuardOfAshesRecipe:
		case ResourceType.PlateOfBrokenBonesRecipe:
		case ResourceType.LifePotionFiveRecipe:
		case ResourceType.LifePotionSixRecipe:
		case ResourceType.MagicBreadOneRecipe:
		case ResourceType.MagicBreadTwoRecipe:
		case ResourceType.MagicBreadThreeRecipe:
		case ResourceType.MagicBreadFourRecipe:
		case ResourceType.MagicBreadFiveRecipe:
		case ResourceType.MagicBreadSixRecipe:
		case ResourceType.FameFiveRecipe:
		case ResourceType.FameSixRecipe:
		case ResourceType.FameSevenRecipe:
		case ResourceType.LightningRunnerFiveRecipe:
		case ResourceType.LightningRunnerSixRecipe:
		case ResourceType.LightningRunnerSevenRecipe:
		case ResourceType.DragonSealFiveRecipe:
		case ResourceType.DragonSealSixRecipe:
		case ResourceType.DragonSealSevenRecipe:
		case ResourceType.WarmJadeOneRecipe:
		case ResourceType.WarmJadeTwoRecipe:
		case ResourceType.WarmJadeThreeRecipe:
		case ResourceType.ClearWaterFiveRecipe:
		case ResourceType.ClearWaterSixRecipe:
		case ResourceType.ClearWaterSevenRecipe:
		case ResourceType.PhenixFiveRecipe:
		case ResourceType.PhenixSixRecipe:
		case ResourceType.PhenixSevenRecipe:
		case ResourceType.SoulSealFiveRecipe:
		case ResourceType.SoulSealSixRecipe:
		case ResourceType.SoulSealSevenRecipe:
		case ResourceType.WarmJadeFourRecipe:
		case ResourceType.WarmJadeFiveRecipe:
		case ResourceType.WarmJadeSixRecipe:
		case ResourceType.WarmJadeSevenRecipe:
		case ResourceType.InsolenceFiveRecipe:
		case ResourceType.InsolenceSixRecipe:
		case ResourceType.InsolenceSevenRecipe:
		case ResourceType.ElixirofFlyingShadowRecipe:
		case ResourceType.ElixirofAggressionRecipe:
		case ResourceType.ElixirofDeterminationRecipe:
		case ResourceType.LifePotionSevenRecipe:
			break;
		default:
			switch (type)
			{
			case ResourceType.FameOne:
				return FilePath.DghzSprites[1443];
			case ResourceType.FameTwo:
				return FilePath.DghzSprites[1443];
			case ResourceType.FameThree:
				return FilePath.DghzSprites[1443];
			case ResourceType.FameFour:
				return FilePath.DghzSprites[1443];
			case ResourceType.DeadMatchOne:
				return FilePath.DghzSprites[1423];
			case ResourceType.PhenixOne:
				return FilePath.DghzSprites[1453];
			case ResourceType.PhenixTwo:
				return FilePath.DghzSprites[1453];
			case ResourceType.DragonSealOne:
				return FilePath.DghzSprites[1429];
			case ResourceType.DragonSealTwo:
				return FilePath.DghzSprites[1429];
			case ResourceType.DragonSealThree:
				return FilePath.DghzSprites[1429];
			case ResourceType.DragonSealFour:
				return FilePath.DghzSprites[1429];
			case ResourceType.SoulSealOne:
				return FilePath.DghzSprites[1431];
			case ResourceType.SoulSealTwo:
				return FilePath.DghzSprites[1431];
			case ResourceType.SoulSealThree:
				return FilePath.DghzSprites[1431];
			case ResourceType.SoulSealFour:
				return FilePath.DghzSprites[1431];
			case ResourceType.DeadMatchTwo:
				return FilePath.DghzSprites[1423];
			case ResourceType.DeadMatchThree:
				return FilePath.DghzSprites[1423];
			case ResourceType.DeadMatchFour:
				return FilePath.DghzSprites[1423];
			case ResourceType.PhenixThree:
				return FilePath.DghzSprites[1453];
			case ResourceType.PhenixFour:
				return FilePath.DghzSprites[1453];
			case ResourceType.ClearWaterOne:
				return FilePath.DghzSprites[1447];
			case ResourceType.ClearWaterTwo:
				return FilePath.DghzSprites[1447];
			case ResourceType.ClearWaterThree:
				return FilePath.DghzSprites[1447];
			case ResourceType.ClearWaterFour:
				return FilePath.DghzSprites[1447];
			case ResourceType.CollectorOne:
				return FilePath.DghzSprites[1433];
			case ResourceType.CollectorTwo:
				return FilePath.DghzSprites[1435];
			case ResourceType.CollectorThree:
				return FilePath.DghzSprites[1425];
			case ResourceType.CollectorFour:
				return FilePath.DghzSprites[1426];
			case ResourceType.InsolenceOne:
				return FilePath.DghzSprites[1127];
			case ResourceType.InsolenceTwo:
				return FilePath.DghzSprites[1127];
			case ResourceType.InsolenceThree:
				return FilePath.DghzSprites[1127];
			case ResourceType.InsolenceFour:
				return FilePath.DghzSprites[1127];
			case ResourceType.LighteningRunnerOne:
				return FilePath.DghzSprites[1453];
			case ResourceType.LighteningRunnerTwo:
				return FilePath.DghzSprites[1453];
			case ResourceType.LighteningRunnerThree:
				return FilePath.DghzSprites[1453];
			case ResourceType.LighteningRunnerFour:
				return FilePath.DghzSprites[1453];
			case ResourceType.FameFive:
				return FilePath.DghzSprites[1443];
			case ResourceType.FameSix:
				return FilePath.DghzSprites[1443];
			case ResourceType.FameSeven:
				return FilePath.DghzSprites[1443];
			case ResourceType.LightningRunnerFive:
				return FilePath.DghzSprites[1453];
			case ResourceType.LightningRunnerSix:
				return FilePath.DghzSprites[1453];
			case ResourceType.LightningRunnerSeven:
				return FilePath.DghzSprites[1453];
			case ResourceType.DragonSealFive:
				return FilePath.DghzSprites[1429];
			case ResourceType.DragonSealSix:
				return FilePath.DghzSprites[1429];
			case ResourceType.DragonSealSeven:
				return FilePath.DghzSprites[1429];
			case ResourceType.WarmJadeOne:
				return FilePath.DghzSprites[1438];
			case ResourceType.WarmJadeTwo:
				return FilePath.DghzSprites[1438];
			case ResourceType.WarmJadeThree:
				return FilePath.DghzSprites[1438];
			case ResourceType.ClearWaterFive:
				return FilePath.DghzSprites[1447];
			case ResourceType.ClearWaterSix:
				return FilePath.DghzSprites[1447];
			case ResourceType.ClearWaterSeven:
				return FilePath.DghzSprites[1447];
			case ResourceType.PhenixFive:
				return FilePath.DghzSprites[1453];
			case ResourceType.PhenixSix:
				return FilePath.DghzSprites[1453];
			case ResourceType.PhenixSeven:
				return FilePath.DghzSprites[1453];
			case ResourceType.SoulSealFive:
				return FilePath.DghzSprites[1431];
			case ResourceType.SoulSealSix:
				return FilePath.DghzSprites[1431];
			case ResourceType.SoulSealSeven:
				return FilePath.DghzSprites[1431];
			case ResourceType.InsolenceFive:
				return FilePath.DghzSprites[1127];
			case ResourceType.InsolenceSix:
				return FilePath.DghzSprites[1127];
			case ResourceType.InsolenceSeven:
				return FilePath.DghzSprites[1127];
			case ResourceType.WarmJadeFour:
				return FilePath.DghzSprites[1438];
			case ResourceType.WarmJadeFive:
				return FilePath.DghzSprites[1438];
			case ResourceType.WarmJadeSix:
				return FilePath.DghzSprites[1438];
			case ResourceType.WarmJadeSeven:
				return FilePath.DghzSprites[1438];
			default:
				switch (type)
				{
				case ResourceType.WoodenWand:
					return FilePath.DghzSprites[1004];
				case ResourceType.SpiritualWand:
					return FilePath.DghzSprites[987];
				case ResourceType.WizardsWand:
					return FilePath.DghzSprites[991];
				case ResourceType.WandOfFire:
					return FilePath.DghzSprites[994];
				case ResourceType.IronWand:
					return FilePath.DghzSprites[1002];
				case ResourceType.ShamansStaff:
					return FilePath.DghzSprites[1000];
				case ResourceType.RedWand:
					return FilePath.DghzSprites[993];
				case ResourceType.AgileWand:
					return FilePath.DghzSprites[1008];
				case ResourceType.ExorcistsWand:
					return FilePath.DghzSprites[998];
				case ResourceType.FallenRain:
					return FilePath.DghzSprites[1015];
				case ResourceType.DragonTeeth:
					return FilePath.DghzSprites[1018];
				case ResourceType.Sea:
					return FilePath.DghzSprites[1020];
				case ResourceType.Growth:
					return FilePath.DghzSprites[1017];
				case ResourceType.DevilsSpirit:
					return FilePath.DghzSprites[1018];
				case ResourceType.GoldenWood:
					return FilePath.DghzSprites[995];
				case ResourceType.GoldenFairy:
					return FilePath.DghzSprites[1036];
				case ResourceType.Nightmare:
					return FilePath.DghzSprites[1034];
				case ResourceType.HastedHeart:
					return FilePath.DghzSprites[1019];
				case ResourceType.DecayedEyes:
					return FilePath.DghzSprites[1039];
				case ResourceType.HeavenSong:
					return FilePath.DghzSprites[1028];
				case ResourceType.GodsRage:
					return FilePath.DghzSprites[1021];
				case ResourceType.FlyingDragon:
					return FilePath.DghzSprites[1038];
				case ResourceType.Barren:
					return FilePath.DghzSprites[1035];
				case ResourceType.Kunlun:
					return FilePath.DghzSprites[1040];
				case ResourceType.InsignificantThing:
					return FilePath.DghzSprites[1042];
				case ResourceType.CurvedWand:
					return FilePath.DghzSprites[988];
				case ResourceType.BrightWand:
					return FilePath.DghzSprites[986];
				case ResourceType.DecoratedWand:
					return FilePath.DghzSprites[985];
				case ResourceType.HiddenWood:
					return FilePath.DghzSprites[1003];
				case ResourceType.SoakedBranch:
					return FilePath.DghzSprites[1005];
				case ResourceType.CandyWand:
					return FilePath.DghzSprites[1007];
				case ResourceType.FireyWavesApprenticeWand:
					return FilePath.DghzSprites[1012];
				case ResourceType.Chaser:
					return FilePath.DghzSprites[1013];
				case ResourceType.Spellbinder:
					return FilePath.DghzSprites[997];
				case ResourceType.Tranquility:
					return FilePath.DghzSprites[1009];
				case ResourceType.Epilogue:
					return FilePath.DghzSprites[1010];
				case ResourceType.EdgeOfInsanity:
					return FilePath.DghzSprites[999];
				case ResourceType.FlameGuard:
					return FilePath.DghzSprites[1014];
				case ResourceType.Moonlight:
					return FilePath.DghzSprites[1023];
				case ResourceType.Mirage:
					return FilePath.DghzSprites[1025];
				case ResourceType.UnholyBlight:
					return FilePath.DghzSprites[1031];
				case ResourceType.FireyWavesFallenSoul:
					return FilePath.DghzSprites[1029];
				case ResourceType.CollectorsRelief:
					return FilePath.DghzSprites[1027];
				case ResourceType.DragonKingsWhisper:
					return FilePath.DghzSprites[1037];
				case ResourceType.TwistedSoul:
					return FilePath.DghzSprites[1033];
				case ResourceType.BurningStar:
					return FilePath.DghzSprites[1022];
				case ResourceType.GrandCandyWand:
					return FilePath.DghzSprites[1011];
				default:
					switch (type)
					{
					case ResourceType.ClothGown:
						return FilePath.DghzSprites[1375];
					case ResourceType.JuniorMonksRobe:
						return FilePath.DghzSprites[1377];
					case ResourceType.MagicRobe:
						return FilePath.DghzSprites[1378];
					case ResourceType.MoonRobe:
						return FilePath.DghzSprites[1383];
					case ResourceType.MingRobe:
						return FilePath.DghzSprites[1382];
					case ResourceType.SwiftEyeRobe:
						return FilePath.DghzSprites[1387];
					case ResourceType.AromaticRobe:
						return FilePath.DghzSprites[1376];
					case ResourceType.ElfsRobe:
						return FilePath.DghzSprites[1388];
					case ResourceType.GoldSilk:
						return FilePath.DghzSprites[1380];
					case ResourceType.RobeOfFire:
						return FilePath.DghzSprites[1398];
					case ResourceType.BloodRobe:
						return FilePath.DghzSprites[1393];
					case ResourceType.Void:
						return FilePath.DghzSprites[1400];
					case ResourceType.MastersRobe:
						return FilePath.DghzSprites[1374];
					case ResourceType.Convergence:
						return FilePath.DghzSprites[1401];
					case ResourceType.Incarnation:
						return FilePath.DghzSprites[1404];
					case ResourceType.FallenSouls:
						return FilePath.DghzSprites[1411];
					case ResourceType.EndlessFortunes:
						return FilePath.DghzSprites[1408];
					case ResourceType.LostDreams:
						return FilePath.DghzSprites[1409];
					case ResourceType.GuardOfLostComrades:
						return FilePath.DghzSprites[1379];
					case ResourceType.RobeOfDemonicSorrow:
						return FilePath.DghzSprites[1389];
					case ResourceType.Resentment:
						return FilePath.DghzSprites[1385];
					case ResourceType.RobeOfInfiniteHope:
						return FilePath.DghzSprites[1390];
					case ResourceType.RobeOfLostTorment:
						return FilePath.DghzSprites[1402];
					case ResourceType.CryOfNecromancy:
						return FilePath.DghzSprites[1406];
					case ResourceType.RobeOfStealth:
						return FilePath.DghzSprites[1396];
					case ResourceType.PledgeOfDemonFire:
						return FilePath.DghzSprites[1405];
					case ResourceType.GiftOfEternity:
						return FilePath.DghzSprites[1410];
					case ResourceType.RobeOfAncientMisery:
						return FilePath.DghzSprites[1407];
					case ResourceType.EnigmaOfDeath:
						return FilePath.DghzSprites[1412];
					case ResourceType.RobeOfTheCorrupted:
						return FilePath.DghzSprites[1381];
					case ResourceType.HopeOfIce:
						return FilePath.DghzSprites[1413];
					case ResourceType.Punishment:
						return FilePath.DghzSprites[1386];
					case ResourceType.DawnOfTheSummoner:
						return FilePath.DghzSprites[1416];
					case ResourceType.PactOfMoonlight:
						return FilePath.DghzSprites[1415];
					case ResourceType.PromisedRobeOfRedemption:
						return FilePath.DghzSprites[1414];
					default:
						switch (type)
						{
						case ResourceType.IronSword:
							return FilePath.DghzSprites[691];
						case ResourceType.WoodenSword:
							return FilePath.DghzSprites[679];
						case ResourceType.MingSword:
							return FilePath.DghzSprites[676];
						case ResourceType.LongSword:
							return FilePath.DghzSprites[673];
						case ResourceType.MasterWusPracticeSword:
							return FilePath.DghzSprites[677];
						case ResourceType.RedSword:
							return FilePath.DghzSprites[680];
						case ResourceType.WaterSword:
							return FilePath.DghzSprites[682];
						case ResourceType.SwordOfMoon:
							return FilePath.DghzSprites[698];
						case ResourceType.SwordOfSpring:
							return FilePath.DghzSprites[696];
						case ResourceType.Heaven:
							return FilePath.DghzSprites[725];
						case ResourceType.Lightenning:
							return FilePath.DghzSprites[700];
						case ResourceType.HeavyWeight:
							return FilePath.DghzSprites[685];
						case ResourceType.ProtectorsSword:
							return FilePath.DghzSprites[714];
						case ResourceType.GiantSword:
							return FilePath.DghzSprites[717];
						case ResourceType.MysticSword:
							return FilePath.DghzSprites[724];
						case ResourceType.Whisper:
							return FilePath.DghzSprites[728];
						case ResourceType.MandateOfHeaven:
							return FilePath.DghzSprites[731];
						case ResourceType.SerratedSword:
							return FilePath.DghzSprites[672];
						case ResourceType.SmallSword:
							return FilePath.DghzSprites[671];
						case ResourceType.BoldEdge:
							return FilePath.DghzSprites[674];
						case ResourceType.SwordOfCourage:
							return FilePath.DghzSprites[684];
						case ResourceType.SingingSword:
							return FilePath.DghzSprites[687];
						case ResourceType.Knightfall:
							return FilePath.DghzSprites[681];
						case ResourceType.Vengeance:
							return FilePath.DghzSprites[697];
						case ResourceType.CryingWarblade:
							return FilePath.DghzSprites[693];
						case ResourceType.Mercy:
							return FilePath.DghzSprites[703];
						case ResourceType.Oathkeeper:
							return FilePath.DghzSprites[704];
						case ResourceType.Brutality:
							return FilePath.DghzSprites[715];
						case ResourceType.RoyalLongSword:
							return FilePath.DghzSprites[729];
						case ResourceType.SwordOfRegret:
							return FilePath.DghzSprites[730];
						case ResourceType.SoulstealerSword:
							return FilePath.DghzSprites[716];
						case ResourceType.PrincesEtiquette:
							return FilePath.DghzSprites[686];
						default:
							switch (type)
							{
							case ResourceType.RoughLeather:
								return FilePath.DghzSprites[1164];
							case ResourceType.HuntersLeather:
								return FilePath.DghzSprites[1162];
							case ResourceType.HuLeather:
								return FilePath.DghzSprites[1163];
							case ResourceType.WhiteLeather:
								return FilePath.DghzSprites[1152];
							case ResourceType.RedLeather:
								return FilePath.DghzSprites[1160];
							case ResourceType.ToughLeather:
								return FilePath.DghzSprites[1163];
							case ResourceType.BlackLeather:
								return FilePath.DghzSprites[1135];
							case ResourceType.TaichiLeather:
								return FilePath.DghzSprites[1165];
							case ResourceType.Snake:
								return FilePath.DghzSprites[1115];
							case ResourceType.Mist:
								return FilePath.DghzSprites[1116];
							case ResourceType.DefusedLeather:
								return FilePath.DghzSprites[1136];
							case ResourceType.Shadow:
								return FilePath.DghzSprites[1130];
							case ResourceType.CursedFire:
								return FilePath.DghzSprites[1137];
							case ResourceType.InfinitePower:
								return FilePath.DghzSprites[1131];
							case ResourceType.Diligence:
								return FilePath.DghzSprites[1159];
							case ResourceType.BloodDragon:
								return FilePath.DghzSprites[1151];
							case ResourceType.Salvation:
								return FilePath.DghzSprites[1301];
							case ResourceType.Fade:
								return FilePath.DghzSprites[1158];
							case ResourceType.BurdenOfAssassins:
								return FilePath.DghzSprites[1300];
							case ResourceType.SilkVest:
								return FilePath.DghzSprites[1241];
							case ResourceType.LeatherOfDiscipline:
								return FilePath.DghzSprites[1161];
							case ResourceType.PledgeOfThunder:
								return FilePath.DghzSprites[1303];
							case ResourceType.LeatherOfHolyMight:
								return FilePath.DghzSprites[1149];
							case ResourceType.LeatherOfTraitors:
								return FilePath.DghzSprites[1157];
							case ResourceType.LeatherOfTimelessNightmares:
								return FilePath.DghzSprites[1299];
							case ResourceType.ProtectorOfFeral:
								return FilePath.DghzSprites[1156];
							case ResourceType.LeatherOfBasilisk:
								return FilePath.DghzSprites[1298];
							case ResourceType.WrapsOfBrokenSouls:
								return FilePath.DghzSprites[1132];
							case ResourceType.LeatherOfRegrets:
								return FilePath.DghzSprites[1195];
							case ResourceType.LeatherOfTimelessDreams:
								return FilePath.DghzSprites[1194];
							case ResourceType.GuardOfAshes:
								return FilePath.DghzSprites[1193];
							default:
								switch (type)
								{
								case ResourceType.CopperCoatedPlate:
									return FilePath.DghzSprites[1178];
								case ResourceType.HardenedPlate:
									return FilePath.DghzSprites[1179];
								case ResourceType.RedPlate:
									return FilePath.DghzSprites[1192];
								case ResourceType.PlateOfStrength:
									return FilePath.DghzSprites[1114];
								case ResourceType.ThickPlate:
									return FilePath.DghzSprites[1148];
								case ResourceType.MingPlate:
									return FilePath.DghzSprites[1175];
								case ResourceType.GreenPlate:
									return FilePath.DghzSprites[1141];
								case ResourceType.HeavyPlate:
									return FilePath.DghzSprites[1110];
								case ResourceType.WarriorsPlate:
									return FilePath.DghzSprites[1117];
								case ResourceType.DivinePlate:
									return FilePath.DghzSprites[1174];
								case ResourceType.Wildness:
									return FilePath.DghzSprites[1173];
								case ResourceType.Slaughter:
									return FilePath.DghzSprites[1172];
								case ResourceType.Stormfury:
									return FilePath.DghzSprites[1153];
								case ResourceType.Desceration:
									return FilePath.DghzSprites[1171];
								case ResourceType.HellishMail:
									return FilePath.DghzSprites[1176];
								case ResourceType.DivineSouls:
									return FilePath.DghzSprites[1111];
								case ResourceType.DragonProtector:
									return FilePath.DghzSprites[1177];
								case ResourceType.SupremeGodsPlate:
									return FilePath.DghzSprites[1112];
								case ResourceType.PlateOfGiantslaying:
									return FilePath.DghzSprites[1128];
								case ResourceType.CursedVestOfTheForest:
									return FilePath.DghzSprites[1140];
								case ResourceType.EnergyOfProtection:
									return FilePath.DghzSprites[1189];
								case ResourceType.BlessingOfTwilight:
									return FilePath.DghzSprites[1188];
								case ResourceType.BondOfDelusions:
									return FilePath.DghzSprites[1168];
								case ResourceType.PlateOfBlackFortune:
									return FilePath.DghzSprites[1167];
								case ResourceType.PlateOfTheUniverse:
									return FilePath.DghzSprites[1166];
								case ResourceType.SteelOfBloodshed:
									return FilePath.DghzSprites[1185];
								case ResourceType.ReachOfTerror:
									return FilePath.DghzSprites[1182];
								case ResourceType.DefenseOfThePhoenix:
									return FilePath.DghzSprites[1154];
								case ResourceType.DefenderOfTheDaywalker:
									return FilePath.DghzSprites[1155];
								case ResourceType.PlateOfTheCataclysm:
									return FilePath.DghzSprites[1191];
								case ResourceType.PlateOfBrokenBones:
									return FilePath.DghzSprites[1190];
								default:
									switch (type)
									{
									case ResourceType.ScrollOfBoorishness:
										return FilePath.DghzSprites[1805];
									case ResourceType.ScrollOfHardenedLife:
										return FilePath.DghzSprites[1801];
									case ResourceType.ScrollOfElement:
										return FilePath.DghzSprites[1808];
									case ResourceType.ScrollOfAffirmation:
										return FilePath.DghzSprites[1807];
									case ResourceType.ScrollOfMasterfulness:
										return FilePath.DghzSprites[1810];
									case ResourceType.ScrollOfTaunt:
										return FilePath.DghzSprites[1800];
									case ResourceType.ScrollOfProtection:
										return FilePath.DghzSprites[1803];
									case ResourceType.ScrollOfTactics:
										return FilePath.DghzSprites[1802];
									case ResourceType.ScrollOfSharpness:
										return FilePath.DghzSprites[1811];
									case ResourceType.ScrollOfHealers:
										return FilePath.DghzSprites[1804];
									case ResourceType.ScrollOfMindless:
										return FilePath.DghzSprites[1809];
									case ResourceType.ScrollOfStrongMan:
										return FilePath.DghzSprites[1830];
									case ResourceType.ScrollOfArcane:
										return FilePath.DghzSprites[1813];
									case ResourceType.ScrollOfArrogance:
										return FilePath.DghzSprites[1814];
									case ResourceType.ScrollOfMist:
										return FilePath.DghzSprites[1815];
									case ResourceType.ScrollOfFrozenHeart:
										return FilePath.DghzSprites[1828];
									case ResourceType.ScrollOfFashion:
										return FilePath.DghzSprites[1829];
									case ResourceType.ScrollOfBlade:
										return FilePath.DghzSprites[1673];
									case ResourceType.ScrollOfNightKiller:
										return FilePath.DghzSprites[1671];
									case ResourceType.ScrollOfTheDead:
										return FilePath.DghzSprites[1672];
									case ResourceType.ScrollOfBun:
										return FilePath.DghzSprites[1674];
									case ResourceType.ScrollOfDuelist:
										break;
									case ResourceType.ScrollOfGhost:
										return FilePath.DghzSprites[1670];
									case ResourceType.ScrollOfExplosion:
										return FilePath.DghzSprites[1654];
									case ResourceType.ScrollOfSpellObsorption:
										return FilePath.DghzSprites[1655];
									case ResourceType.ScrollOfSwiftness:
										return FilePath.DghzSprites[1656];
									case ResourceType.ScrollOfRage:
										return FilePath.DghzSprites[1657];
									case ResourceType.ScrollOfReflection:
										return FilePath.DghzSprites[1658];
									default:
										switch (type)
										{
										case ResourceType.WarriorInvitation:
										case ResourceType.DuelistInvitation:
										case ResourceType.TacticianInvitation:
										case ResourceType.PleasentGuyInviation:
										case ResourceType.FirePlayerInvitation:
										case ResourceType.YoungWarlockInvitation:
										case ResourceType.ConjurerInvitation:
										case ResourceType.ElementalWizardInvitation:
										case ResourceType.RedMageInvitation:
										case ResourceType.SoulThiefInvitation:
										case ResourceType.FireAssassinInvitation:
										case ResourceType.NightBladeInvitation:
										case ResourceType.CubeInvitation:
										case ResourceType.DrunkReaderInvitation:
										case ResourceType.PaladinInvitation:
										case ResourceType.BunSisterInvitation:
										case ResourceType.IronSoliderInvitation:
										case ResourceType.StreetManInvitation:
										case ResourceType.MissionaryInvitation:
										case ResourceType.KillerInvitation:
										case ResourceType.FashionBoyInvitation:
										case ResourceType.SnowMaidenInvitation:
										case ResourceType.FireSpiritInvitation:
										case ResourceType.GoldenShamanInvitation:
										case ResourceType.ToughWomanInvitation:
										case ResourceType.ChubbyLadyInvitation:
										case ResourceType.RedHornInvitation:
											break;
										default:
											switch (type)
											{
											case ResourceType.SleekKnife:
												return FilePath.DghzSprites[675];
											case ResourceType.BlackBlade:
												return FilePath.DghzSprites[676];
											case ResourceType.PrisonersBlade:
												return FilePath.DghzSprites[689];
											case ResourceType.GoldenBlade:
												return FilePath.DghzSprites[718];
											case ResourceType.Ash:
												return FilePath.DghzSprites[719];
											case ResourceType.Wind:
												return FilePath.DghzSprites[726];
											case ResourceType.Desperation:
												return FilePath.DghzSprites[733];
											case ResourceType.ThroatCutter:
												return FilePath.DghzSprites[707];
											case ResourceType.DivineBlade:
												return FilePath.DghzSprites[690];
											case ResourceType.RoyalBlade:
												return FilePath.DghzSprites[722];
											case ResourceType.FlyingBird:
												return FilePath.DghzSprites[720];
											case ResourceType.MonkeyBlade:
												return FilePath.DghzSprites[727];
											case ResourceType.DevilMastersBlade:
												return FilePath.DghzSprites[695];
											case ResourceType.FlyingFox:
												return FilePath.DghzSprites[699];
											case ResourceType.BloodCrystalBlade:
												return FilePath.DghzSprites[723];
											case ResourceType.HuntersBlade:
												return FilePath.DghzSprites[678];
											case ResourceType.Harvest:
												return FilePath.DghzSprites[688];
											case ResourceType.Chaos:
												return FilePath.DghzSprites[694];
											case ResourceType.FiresoulSwiftblade:
												return FilePath.DghzSprites[708];
											case ResourceType.Grasscutter:
												return FilePath.DghzSprites[702];
											case ResourceType.LastRites:
												return FilePath.DghzSprites[712];
											case ResourceType.AncientDragonBlade:
												return FilePath.DghzSprites[732];
											case ResourceType.WrathfulBloodblade:
												return FilePath.DghzSprites[723];
											case ResourceType.BetrayersBlade:
												return FilePath.DghzSprites[701];
											case ResourceType.Stinger:
												return FilePath.DghzSprites[711];
											default:
												switch (type)
												{
												case ResourceType.PracticePoints:
													return FilePath.DghzSprites[2136];
												case ResourceType.BookFragments:
													return FilePath.ResourceIcons[22];
												case ResourceType.FragmentOfDemon:
													return FilePath.DghzSprites[3400];
												case ResourceType.InfusedPowder:
													return FilePath.DghzSprites[2151];
												case ResourceType.CrystalOfWoodenForest:
													return FilePath.DghzSprites[2117];
												case ResourceType.InkOfMistForest:
													return FilePath.DghzSprites[2116];
												case ResourceType.IceOfSnowMountain:
													return FilePath.DghzSprites[2118];
												case ResourceType.SealOfBuriedTemple:
													return FilePath.DghzSprites[2119];
												case ResourceType.StoneOfHellishPath:
													return FilePath.DghzSprites[2135];
												case ResourceType.LeafOfImperialM:
													return FilePath.DghzSprites[2114];
												case ResourceType.SandOfNorthernTerritory:
													return FilePath.DghzSprites[2115];
												case ResourceType.MysticKey:
													return FilePath.DghzSprites[2227];
												case ResourceType.AshOfHope:
													return FilePath.DghzSprites[2150];
												case ResourceType.AdventurerPack:
													return FilePath.DghzSprites[2282];
												case ResourceType.GreenGemPack:
													return FilePath.DghzSprites[2099];
												case ResourceType.RedGemPack:
													return FilePath.DghzSprites[2098];
												case ResourceType.BlueGemPack:
													return FilePath.DghzSprites[2097];
												case ResourceType.YellowGemPack:
													return FilePath.DghzSprites[2100];
												default:
													switch (type)
													{
													case ResourceType.NoneGem:
														return FilePath.DghzSprites[3523];
													case ResourceType.SpiritOfDeadGeneral:
													case ResourceType.FairyStone:
													case ResourceType.EmeraldOfClearHeart:
													case ResourceType.BoneOfRapture:
													case ResourceType.UndeadAsh:
													case ResourceType.MonksEyes:
													case ResourceType.StoneOfSoulbringer:
													case ResourceType.SavageHeart:
													case ResourceType.FlyingFeather:
													case ResourceType.GodsMoral:
													case ResourceType.DemonicFire:
													case ResourceType.EyeOfPrecision:
													case ResourceType.StoneOfExorcism:
													case ResourceType.CommandmentOfSpell:
													case ResourceType.EvilHeart:
														break;
													default:
														switch (type)
														{
														case ResourceType.BloodThirstBook:
														case ResourceType.FlameBook:
														case ResourceType.FleshToStoneBook:
														case ResourceType.FlourishBook:
														case ResourceType.HarmoneyBook:
														case ResourceType.LightFireBook:
														case ResourceType.LighteningSpeedBook:
														case ResourceType.PrincipleBook:
														case ResourceType.RageBook:
														case ResourceType.RebirthBook:
														case ResourceType.StaminaBook:
														case ResourceType.StrayBook:
														case ResourceType.SwiftBook:
														case ResourceType.WaveBook:
														case ResourceType.ReturnSoulBook:
														case ResourceType.SoulSeekerBook:
															break;
														default:
															switch (type)
															{
															case ResourceType.PrismLightCharger:
																return FilePath.PutumnoIcons[802];
															case ResourceType.GhostBreathCollector:
																return FilePath.PutumnoIcons[806];
															case ResourceType.VitalEnergyContainer:
																return FilePath.PutumnoIcons[810];
															case ResourceType.SpiritBox:
																return FilePath.PutumnoIcons[814];
															case ResourceType.PrismScope:
																return FilePath.PutumnoIcons[803];
															case ResourceType.SoulLocker:
																return FilePath.PutumnoIcons[804];
															case ResourceType.ShieldRemover:
																return FilePath.PutumnoIcons[805];
															case ResourceType.PoisonousNeedles:
																return FilePath.PutumnoIcons[807];
															case ResourceType.FirstAidKit:
																return FilePath.PutumnoIcons[808];
															case ResourceType.MagicShield:
																return FilePath.PutumnoIcons[809];
															case ResourceType.Pacemaker:
																return FilePath.PutumnoIcons[811];
															case ResourceType.Dispeller:
																return FilePath.PutumnoIcons[812];
															case ResourceType.DefenceBreaker:
																return FilePath.PutumnoIcons[813];
															case ResourceType.ChaoticFlowTrigger:
																return FilePath.PutumnoIcons[815];
															case ResourceType.ReflectiveShield:
																return FilePath.PutumnoIcons[816];
															case ResourceType.VitalitySuppressor:
																return FilePath.PutumnoIcons[817];
															default:
																switch (type)
																{
																case ResourceType.AshOfDeerGod:
																	return FilePath.PutumnoIcons[799];
																case ResourceType.RockOfDeerGod:
																	return FilePath.PutumnoIcons[800];
																case ResourceType.TorchOfDeerGod:
																	return FilePath.PutumnoIcons[801];
																case ResourceType.HeartOfThorns:
																	return FilePath.PutumnoIcons[798];
																case ResourceType.EyesOfThorns:
																	return FilePath.PutumnoIcons[797];
																case ResourceType.BoneOfThorns:
																	return FilePath.PutumnoIcons[796];
																case ResourceType.HatredOfPrince:
																	return FilePath.PutumnoIcons[793];
																case ResourceType.LoveOfPrince:
																	return FilePath.PutumnoIcons[794];
																case ResourceType.SinOfPrince:
																	return FilePath.PutumnoIcons[795];
																case ResourceType.DustOfCorruption:
																	return FilePath.PutumnoIcons[786];
																case ResourceType.PetalOfCorruption:
																	return FilePath.PutumnoIcons[784];
																case ResourceType.GhostOfCorruption:
																	return FilePath.PutumnoIcons[785];
																case ResourceType.CircleOfFocus:
																	return FilePath.PutumnoIcons[781];
																case ResourceType.WheelOfFocus:
																	return FilePath.PutumnoIcons[782];
																case ResourceType.SpikeOfFocus:
																	return FilePath.PutumnoIcons[783];
																default:
																	switch (type)
																	{
																	case ResourceType.MysticStone:
																		return FilePath.DghzSprites[2249];
																	case ResourceType.CrystalStone:
																		return FilePath.DghzSprites[3404];
																	case ResourceType.DragonBloodStone:
																		return FilePath.DghzSprites[2236];
																	case ResourceType.DirtyBadge:
																		return FilePath.DghzSprites[2287];
																	case ResourceType.GuideToFarm:
																		return FilePath.DghzSprites[2243];
																	case ResourceType.APileOfAshes:
																		return FilePath.DghzSprites[2291];
																	case ResourceType.BlackBead:
																		return FilePath.ResourceIcons[234];
																	case ResourceType.BookCollection:
																		return FilePath.DghzSprites[1481];
																	case ResourceType.PortBlueprint:
																		return FilePath.DghzSprites[2454];
																	case ResourceType.FeetOfPrincess:
																		return FilePath.DghzSprites[3643];
																	case ResourceType.ForeheadOfPrincess:
																		return FilePath.DghzSprites[3642];
																	case ResourceType.EarsOfPrincess:
																		return FilePath.DghzSprites[3644];
																	case ResourceType.GrindingTable:
																		return FilePath.DghzSprites[2103];
																	case ResourceType.BluePrintOfScrolls:
																		return FilePath.DghzSprites[2454];
																	default:
																		switch (type)
																		{
																		case ResourceType.LightAxe:
																			return FilePath.DghzSprites[750];
																		case ResourceType.DeadEndAxe:
																			return FilePath.DghzSprites[761];
																		case ResourceType.GoldenAxe:
																			return FilePath.DghzSprites[765];
																		case ResourceType.SwiftAxe:
																			return FilePath.DghzSprites[757];
																		case ResourceType.DragonSlayer:
																			return FilePath.DghzSprites[766];
																		case ResourceType.Icebreaker:
																			return FilePath.DghzSprites[743];
																		case ResourceType.ChampionsHammer:
																			return FilePath.DghzSprites[749];
																		case ResourceType.StormBasher:
																			return FilePath.DghzSprites[762];
																		case ResourceType.LifeDrinker:
																			return FilePath.DghzSprites[753];
																		case ResourceType.Heartseeker:
																			return FilePath.DghzSprites[772];
																		case ResourceType.Fleshrender:
																			return FilePath.DghzSprites[768];
																		case ResourceType.PrincesFallenSoul:
																			return FilePath.DghzSprites[755];
																		case ResourceType.CollectorsFame:
																			return FilePath.DghzSprites[760];
																		default:
																			switch (type)
																			{
																			case ResourceType.LongSpear:
																				return FilePath.DghzSprites[773];
																			case ResourceType.IronSpear:
																				return FilePath.DghzSprites[778];
																			case ResourceType.LighteningSpear:
																				return FilePath.DghzSprites[789];
																			case ResourceType.HeavySpear:
																				return FilePath.DghzSprites[793];
																			case ResourceType.YellowRiver:
																				return FilePath.DghzSprites[831];
																			case ResourceType.DragonSpear:
																				return FilePath.DghzSprites[817];
																			case ResourceType.DesolationSpear:
																				return FilePath.DghzSprites[828];
																			case ResourceType.Doom:
																				return FilePath.DghzSprites[833];
																			case ResourceType.StarChaser:
																				return FilePath.DghzSprites[834];
																			case ResourceType.SwanSong:
																				return FilePath.DghzSprites[808];
																			case ResourceType.HellfireSpear:
																				return FilePath.DghzSprites[824];
																			default:
																				switch (type)
																				{
																				case ResourceType.MonsterInvitation:
																				case ResourceType.WeaponShopPermit:
																				case ResourceType.ArmorShopPermit:
																				case ResourceType.RecruitmentFacilityPermit:
																				case ResourceType.ShopPermit:
																				case ResourceType.ShrinePermit:
																				case ResourceType.SchoolPermit:
																				case ResourceType.CityTownPermit:
																				case ResourceType.CasinoPermit:
																				case ResourceType.PracticePermit:
																				case ResourceType.ForgingFacilityPermit:
																					break;
																				default:
																					switch (type)
																					{
																					case ResourceType.LifePotionOne:
																					case ResourceType.LifePotionTwo:
																					case ResourceType.LifePotionThree:
																					case ResourceType.LifePotionFour:
																					case ResourceType.LifePotionFive:
																					case ResourceType.LifePotionSix:
																						return FilePath.DghzSprites[327];
																					case ResourceType.MagicBreadOne:
																						return FilePath.DghzSprites[2152];
																					default:
																						switch (type)
																						{
																						case ResourceType.RedSocketBatcher:
																							return FilePath.DghzSprites[2292];
																						case ResourceType.BlueSocketBatcher:
																							return FilePath.DghzSprites[2293];
																						case ResourceType.YellowSocketBatcher:
																							return FilePath.DghzSprites[2295];
																						case ResourceType.GreenSocketBatcher:
																							return FilePath.DghzSprites[2294];
																						case ResourceType.AllSocketBatcher:
																							return FilePath.DghzSprites[2344];
																						default:
																							if (type == ResourceType.Ore)
																							{
																								return FilePath.ResourceIcons[282];
																							}
																							if (type == ResourceType.RefinedOre)
																							{
																								return FilePath.ResourceIcons[283];
																							}
																							if (type == ResourceType.Leather)
																							{
																								return FilePath.DghzSprites[2250];
																							}
																							if (type == ResourceType.RefinedLeather)
																							{
																								return FilePath.DghzSprites[2240];
																							}
																							if (type == ResourceType.Wood)
																							{
																								return FilePath.ResourceIcons[275];
																							}
																							if (type != ResourceType.Money)
																							{
																								return FilePath.ResourceIcons[27];
																							}
																							return FilePath.ResourceIcons[211];
																						}
																						break;
																					case ResourceType.ElixirofFlyingShadow:
																						return FilePath.DghzSprites[2456];
																					case ResourceType.ElixirofAggression:
																						return FilePath.DghzSprites[2457];
																					case ResourceType.ElixirofDetermination:
																						return FilePath.DghzSprites[2458];
																					case ResourceType.LifePotionSeven:
																						return FilePath.DghzSprites[2145];
																					}
																					break;
																				}
																				break;
																			}
																			break;
																		}
																		break;
																	}
																	break;
																}
																break;
															}
															break;
														}
														break;
													}
													break;
												case ResourceType.ResidentsPack:
													return FilePath.DghzSprites[2280];
												case ResourceType.PracticePointsPack:
													return FilePath.DghzSprites[2277];
												}
												break;
											}
											break;
										}
										break;
									}
									break;
								}
								break;
							}
							break;
						}
						break;
					}
					break;
				}
				break;
			}
			break;
		}
		return FilePath.ResourceIcons[27];
	}

	// Token: 0x0600466F RID: 18031 RVA: 0x001CDB4C File Offset: 0x001CBF4C
	public static Sprite GetSkillCategoryImage(SkillCategory category)
	{
		switch (category)
		{
		case SkillCategory.Offensive:
			return FilePath.DghzSprites[3436];
		case SkillCategory.Defensive:
			return FilePath.DghzSprites[3438];
		case SkillCategory.Supportive:
			return FilePath.DghzSprites[3439];
		default:
			return FilePath.DghzSprites[27];
		}
	}

	// Token: 0x06004670 RID: 18032 RVA: 0x001CDB9E File Offset: 0x001CBF9E
	public static string GetTargetingTypeText(TargetingType type)
	{
		if (type == TargetingType.Single)
		{
			return "1";
		}
		if (type != TargetingType.Multiple)
		{
			return string.Empty;
		}
		return "M";
	}

	// Token: 0x06004671 RID: 18033 RVA: 0x001CDBC4 File Offset: 0x001CBFC4
	public static Sprite GetFailedRecipeImage()
	{
		return FilePath.DghzSprites[3521];
	}

	// Token: 0x06004672 RID: 18034 RVA: 0x001CDBD4 File Offset: 0x001CBFD4
	public static string GetBuildingPrefab(BuildingType type)
	{
		switch (type)
		{
		case BuildingType.WeaponShop:
			return FilePath.BuildingPath + "WeaponShop";
		case BuildingType.RecruitmentFacility:
			return FilePath.BuildingPath + "Recruitment";
		case BuildingType.ArmorShop:
			return FilePath.BuildingPath + "ArmorShop";
		case BuildingType.Shop:
			return FilePath.BuildingPath + "Shop";
		case BuildingType.School:
			return FilePath.BuildingPath + "School";
		case BuildingType.CityTown:
			return FilePath.BuildingPath + "CityTown";
		case BuildingType.Casino:
			return FilePath.BuildingPath + "Casino";
		case BuildingType.ForgingFacility:
			return FilePath.BuildingPath + "Furnace";
		}
		return string.Empty;
	}

	// Token: 0x06004673 RID: 18035 RVA: 0x001CDC9B File Offset: 0x001CC09B
	public static string GetUiHero(UnitClass @class)
	{
		return FilePath.UiHeroPath + "Adventurer";
	}

	// Token: 0x06004674 RID: 18036 RVA: 0x001CDCAC File Offset: 0x001CC0AC
	public static string GetQueueItem()
	{
		return FilePath.UiPath + "QueueItem";
	}

	// Token: 0x06004675 RID: 18037 RVA: 0x001CDCBD File Offset: 0x001CC0BD
	public static string GetRecipeItem()
	{
		return FilePath.UiPath + "CapableRecipeItem";
	}

	// Token: 0x06004676 RID: 18038 RVA: 0x001CDCCE File Offset: 0x001CC0CE
	public static string GetCompletedWidget()
	{
		return "Prefabs/Buildings/CompletedWidget/Widget";
	}

	// Token: 0x06004677 RID: 18039 RVA: 0x001CDCD5 File Offset: 0x001CC0D5
	public static string GetBattlePassiveEffectPathAndBattleEffectOn(Skill skill, bool isCaster)
	{
		return "Prefabs/BattleEffects/Passive";
	}

	// Token: 0x06004678 RID: 18040 RVA: 0x001CDCDC File Offset: 0x001CC0DC
	public static string GetRetainTrapPath()
	{
		return FilePath.SkillEffectPath + "Trap/Trap";
	}

	// Token: 0x06004679 RID: 18041 RVA: 0x001CDCED File Offset: 0x001CC0ED
	public static string GetDamageNeutralizedEffectIndication()
	{
		return "Prefabs/BattleEffects/DamageNeutralized/DamageNeutralizedEffect";
	}

	// Token: 0x0600467A RID: 18042 RVA: 0x001CDCF4 File Offset: 0x001CC0F4
	public static string GetBattleEffectsByBattleEffectType(BattleEffectType type)
	{
		switch (type)
		{
		case BattleEffectType.Frozen:
			return FilePath.SkillEffectPath + "Frozen/FrozenPre";
		default:
			switch (type)
			{
			case BattleEffectType.BurningHeartEffect:
				return FilePath.SkillEffectPath + "BurnningHeart/BurnningHeart";
			default:
				if (type != BattleEffectType.DamageNeutrualization)
				{
					if (type == BattleEffectType.ReflectiveShield)
					{
						return "Prefabs/BattleEffects/Shield/ReflectiveShield";
					}
					if (type == BattleEffectType.BrightCircle)
					{
						return FilePath.SkillEffectPath + "DivineLight/BrightCirclePre";
					}
					if (type != BattleEffectType.DamageImmune)
					{
						return string.Empty;
					}
				}
				return "Prefabs/BattleEffects/Shield/DamageImmueShield";
			case BattleEffectType.Taunt:
				return FilePath.SkillEffectPath + "Taunt/TauntedEffect";
			}
			break;
		case BattleEffectType.EffectImmune:
			return "Prefabs/BattleEffects/Shield/EffectImmue";
		}
	}

	// Token: 0x0600467B RID: 18043 RVA: 0x001CDDB0 File Offset: 0x001CC1B0
	public static string GetEnemyInWalkingBattle(UnitClass @class)
	{
		switch (@class)
		{
		case UnitClass.PurpleOrc:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Orc Purple";
		default:
			switch (@class)
			{
			case UnitClass.GreenGoblin:
				return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Goblin Green";
			case UnitClass.RedOrc:
				return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Orc Red";
			case UnitClass.YellowOrc:
				return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Orc Yellow";
			case UnitClass.SharpTeeth:
				return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Sharp Teeth Green";
			case UnitClass.GreenOrc:
				return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Orc Green";
			case UnitClass.PurpleSharpTeeth:
				return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Sharp Teeth Purple";
			default:
				switch (@class)
				{
				case UnitClass.YellowGoblin:
					return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Goblin Yellow";
				case UnitClass.RedSharpTeeth:
					return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Sharp Teeth Red";
				default:
					if (@class == UnitClass.BlueOrc)
					{
						return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Orc Blue";
					}
					if (@class == UnitClass.BlueSharpTeeth)
					{
						return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Sharp Teeth Blue";
					}
					if (@class != UnitClass.GoldenShaman)
					{
						Debug.Log("does not have : " + @class);
						return "Prefabs/Eric/Battle/EnemiesWalking/GreenFrog";
					}
					return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Shaman Yellow";
				case UnitClass.RedGrassFace:
					return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Grass Face Red";
				case UnitClass.YellowGrassFace:
					return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Grass Face Yellow";
				case UnitClass.RedArcher:
					return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Archer Red";
				case UnitClass.BlueArcher:
					return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Archer Blue";
				case UnitClass.PurpleArcher:
					return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Archer Purple";
				case UnitClass.YellowArcher:
					return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Archer Yellow";
				case UnitClass.RedMud:
					return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Mud Red";
				case UnitClass.GreenMud:
					return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Mub Green";
				case UnitClass.PurpleMud:
					return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Mub Purple";
				case UnitClass.YellowMud:
					return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Mud Yellow";
				case UnitClass.BlueShadowKiller:
					return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Shadow Killer Blue";
				case UnitClass.YellowShadowKiller:
					return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Shadow Killer Yellow";
				case UnitClass.RedShadowKiller:
					return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Shadow Killer Red";
				case UnitClass.PurpleShadowKiller:
					return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Shadow Killer Purple";
				}
				break;
			case UnitClass.GreenSpearer:
				return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Spearer Green";
			case UnitClass.RedSpearer:
				return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Spearer Red";
			case UnitClass.PurpleSpearer:
				return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Spearer Purple";
			case UnitClass.YellowSpearer:
				return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Spearer Yellow";
			case UnitClass.GreenDoomFighter:
				return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Doom Fighter Green";
			case UnitClass.RedDoomFighter:
				return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Doom Fighter Red";
			case UnitClass.PurpleDoomFighter:
				return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Doom Fighter Purple";
			case UnitClass.BlueDoomFighter:
				return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Doom Fighter Blue";
			case UnitClass.GreenReaper:
				return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Reaper Green";
			case UnitClass.YellowReaper:
				return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Reaper Yellow";
			case UnitClass.RedReaper:
				return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Reaper Red";
			case UnitClass.PurpleReaper:
				return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Reaper Purple";
			}
			break;
		case UnitClass.GrassFace:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Grass Face Green";
		case UnitClass.ScreamingShaman:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Shaman Green";
		case UnitClass.BlueShaman:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Shaman Blue";
		case UnitClass.RedShaman:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Shaman Red";
		case UnitClass.PurpleShaman:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Shaman Purple";
		case UnitClass.YellowShaman:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Shaman Yellow";
		case UnitClass.YellowSharpTeeth:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Sharp Teeth Yellow";
		case UnitClass.BlueGrassFace:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Grass Face Blue";
		case UnitClass.PurpleGrassFace:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Grass Face Purple";
		case UnitClass.GreenDragonPrayer:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Wizard Green";
		case UnitClass.YellowDragonPrayer:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Wizard Yellow";
		case UnitClass.RedDragonPrayer:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Wizard Red";
		case UnitClass.PurpleDragonPrayer:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Wizard Purple";
		case UnitClass.RedShadowBat:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Shadow Bat Red";
		case UnitClass.PurpleShadowBat:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Shadow Bat Purple";
		case UnitClass.YellowShadowBat:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Shadow Bat Yellow";
		case UnitClass.GreenShadowBat:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Shadow Bat Green";
		case UnitClass.BlueShadowBat:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Shadow Bat Blue";
		case UnitClass.RedBirdMonster:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Bird Monster Red";
		case UnitClass.PurpleBirdMonster:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Bird Monster Purple";
		case UnitClass.YellowBirdMonster:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Bird Monster Yellow";
		case UnitClass.BlueBirdMonster:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Bird Monster Blue";
		case UnitClass.GreenBirdMonster:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Bird Monster Green";
		case UnitClass.BlueDragonPrayer:
			return "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/Wizard Blue";
		}
	}

	// Token: 0x0600467C RID: 18044 RVA: 0x001CE0AC File Offset: 0x001CC4AC
	public static List<GameObject> GetPredefinedLayoutsByBattleLevel(Adventure adventure)
	{
		GameObject item = Resources.Load("Prefabs/Eric/Battle/Chest/ChestPre") as GameObject;
		return new List<GameObject>
		{
			item
		};
	}

	// Token: 0x0600467D RID: 18045 RVA: 0x001CE0D8 File Offset: 0x001CC4D8
	public static string GetAdventurerAvatar(UnitClass unitClass)
	{
		string str = "Images/Characters/Avatars/";
		switch (unitClass)
		{
		case UnitClass.FirePlayer:
			return str + "c2-48";
		case UnitClass.YoungWarlock:
			return str + "c2-51";
		case UnitClass.Conjurer:
			return str + "c2-54";
		case UnitClass.ElementalWizard:
			return str + "c2-57";
		case UnitClass.RedMage:
			return str + "c3-0";
		case UnitClass.Cube:
			return str + "c3-51";
		default:
			switch (unitClass)
			{
			case UnitClass.Warrior:
				return str + "c2-0";
			case UnitClass.Duelist:
				return str + "c2-3";
			case UnitClass.Tactician:
				return str + "c2-6";
			default:
				switch (unitClass)
				{
				case UnitClass.SoulThief:
					return str + "c3-6";
				case UnitClass.FireAssassin:
					return str + "c3-9";
				case UnitClass.NightBlade:
					return str + "c3-48";
				case UnitClass.ToughWoman:
					return str + "TempAva/toughWoman";
				default:
					if (unitClass != UnitClass.StrangeSuperGuy)
					{
						return str + "c3-51";
					}
					return str + "c2-9";
				}
				break;
			case UnitClass.StreetMan:
				return str + "TempAva/StreetMan";
			}
			break;
		case UnitClass.Missionary:
			return str + "TempAva/MasterWang";
		case UnitClass.Killer:
			return str + "TempAva/AmorLee";
		case UnitClass.DrunkReader:
			return str + "TempAva/DrunkReader";
		}
	}

	// Token: 0x0600467E RID: 18046 RVA: 0x001CE268 File Offset: 0x001CC668
	public static ChestLayoutImages GetChestImagesByType(ChestType type)
	{
		switch (type)
		{
		case ChestType.Level1:
			return new ChestLayoutImages("chests_shadowed", 0);
		case ChestType.Level2:
			return new ChestLayoutImages("chests_shadowed", 3);
		case ChestType.Level3:
			return new ChestLayoutImages("chests_shadowed", 6);
		case ChestType.Level4:
			return new ChestLayoutImages("chests_shadowed", 9);
		case ChestType.Level5:
			return new ChestLayoutImages("chests_shadowed", 48);
		case ChestType.Level6:
			return new ChestLayoutImages("chests_shadowed", 51);
		case ChestType.Level7:
			return new ChestLayoutImages("chests_shadowed", 54);
		case ChestType.Level8:
			return new ChestLayoutImages("chests_shadowed", 57);
		default:
			throw new ArgumentOutOfRangeException("type", type, null);
		}
	}

	// Token: 0x0600467F RID: 18047 RVA: 0x001CE318 File Offset: 0x001CC718
	public static CharacterBasicAppearance GetCharacterBasicAppearance(UnitClass adventurer, bool isSingleImg = false)
	{
		switch (adventurer)
		{
		case UnitClass.FirePlayer:
			return new CharacterBasicAppearance("chara19", 7);
		case UnitClass.YoungWarlock:
			return new CharacterBasicAppearance("chara24", 7);
		case UnitClass.Conjurer:
			return new CharacterBasicAppearance("chara19", 8);
		case UnitClass.ElementalWizard:
			return new CharacterBasicAppearance("chara19", 2);
		case UnitClass.RedMage:
			return new CharacterBasicAppearance("chara3", 1);
		case UnitClass.Cube:
			return new CharacterBasicAppearance("chara3", 6);
		default:
			switch (adventurer)
			{
			case UnitClass.Warrior:
				return new CharacterBasicAppearance("chara21", 2);
			case UnitClass.Duelist:
				return new CharacterBasicAppearance("chara35", 3);
			case UnitClass.Tactician:
				return new CharacterBasicAppearance("chara22", 5);
			default:
				switch (adventurer)
				{
				case UnitClass.SoulThief:
					return new CharacterBasicAppearance("chara26", 6);
				case UnitClass.FireAssassin:
					return new CharacterBasicAppearance("chara29", 6);
				case UnitClass.NightBlade:
					return new CharacterBasicAppearance("chara23", 6);
				case UnitClass.ToughWoman:
					return new CharacterBasicAppearance("chara18", 8);
				case UnitClass.ChubbyLady:
					return new CharacterBasicAppearance("chara32", 7);
				case UnitClass.RedHorn:
					return new CharacterBasicAppearance("chara4", 8);
				default:
					if (adventurer != UnitClass.StrangeSuperGuy)
					{
						return new CharacterBasicAppearance("chara29", 5);
					}
					return new CharacterBasicAppearance("chara8", 1);
				}
				break;
			case UnitClass.Paladin:
				return new CharacterBasicAppearance("chara27", 5);
			case UnitClass.StreetMan:
				return new CharacterBasicAppearance("chara33", 5);
			case UnitClass.OldWiseMan:
				return new CharacterBasicAppearance("chara21", 3);
			case UnitClass.ArmorShopManager:
				return new CharacterBasicAppearance("chara31", 1);
			case UnitClass.WeaponShopManager:
				return new CharacterBasicAppearance("chara31", 2);
			case UnitClass.SchoolManager:
				return new CharacterBasicAppearance("chara6", 4);
			case UnitClass.ShopManager:
				return new CharacterBasicAppearance("chara23", 1);
			case UnitClass.FurnaceManager:
				return new CharacterBasicAppearance("chara8", 7);
			case UnitClass.RecruitmentManager:
				return new CharacterBasicAppearance("chara15", 4);
			case UnitClass.TownGuardian:
				return new CharacterBasicAppearance("chara10", 2);
			}
			break;
		case UnitClass.Missionary:
			return new CharacterBasicAppearance("chara27", 1);
		case UnitClass.Killer:
			return new CharacterBasicAppearance("chara26", 2);
		case UnitClass.FashionBoy:
			return new CharacterBasicAppearance("chara19", 6);
		case UnitClass.SnowMaiden:
			return new CharacterBasicAppearance("chara23", 5);
		case UnitClass.FireCharger:
			return new CharacterBasicAppearance("chara24", 3);
		case UnitClass.GoldenShaman:
			return new CharacterBasicAppearance("chara29", 7);
		case UnitClass.BunSister:
			return new CharacterBasicAppearance("chara9", 7);
		case UnitClass.IronSolider:
			return new CharacterBasicAppearance("chara34", 6);
		case UnitClass.DrunkReader:
			return new CharacterBasicAppearance("chara22", 7);
		}
	}

	// Token: 0x06004680 RID: 18048 RVA: 0x001CE5A8 File Offset: 0x001CC9A8
	public static CharacterBasicAppearance GetResidentAppearence(ResidentType type)
	{
		switch (type)
		{
		case ResidentType.Traveller:
			return new CharacterBasicAppearance("chara29", 2);
		case ResidentType.Peasant:
			return new CharacterBasicAppearance("chara15", 8);
		case ResidentType.Ronin:
			return new CharacterBasicAppearance("chara9", 2);
		case ResidentType.Refugee:
			return new CharacterBasicAppearance("chara17", 1);
		case ResidentType.RoyalNoble:
			return new CharacterBasicAppearance("chara23", 7);
		case ResidentType.BusinessMan:
			return new CharacterBasicAppearance("chara18", 6);
		case ResidentType.Scholar:
			return new CharacterBasicAppearance("chara9", 6);
		case ResidentType.BureauOfficial:
			return new CharacterBasicAppearance("chara10", 2);
		case ResidentType.Magician:
			return new CharacterBasicAppearance("chara21", 5);
		case ResidentType.Musician:
			return new CharacterBasicAppearance("chara8", 6);
		case ResidentType.Prayer:
			return new CharacterBasicAppearance("chara23", 8);
		case ResidentType.Researcher:
			return new CharacterBasicAppearance("chara9", 5);
		case ResidentType.RetiredGoverner:
			return new CharacterBasicAppearance("chara10", 1);
		case ResidentType.General:
			return new CharacterBasicAppearance("chara11", 5);
		case ResidentType.GrandMaster:
			return new CharacterBasicAppearance("chara11", 7);
		case ResidentType.Swordman:
			return new CharacterBasicAppearance("chara13", 3);
		case ResidentType.Knight:
			return new CharacterBasicAppearance("chara10", 7);
		case ResidentType.MysteriousRoyalMember:
			return new CharacterBasicAppearance("chara10", 8);
		case ResidentType.OfficialTrader:
			return new CharacterBasicAppearance("chara18", 1);
		default:
			return new CharacterBasicAppearance("chara9", 8);
		}
	}

	// Token: 0x06004681 RID: 18049 RVA: 0x001CE6FC File Offset: 0x001CCAFC
	public static Sprite GetCharaterNormalStandSpriteBasedOnCharacterBasicAppearance(CharacterBasicAppearance Appearance)
	{
		Sprite[] array = Resources.LoadAll<Sprite>(FilePath.CharacterImagePath + Appearance.Path);
		return array[Appearance.SouthMiddle];
	}

	// Token: 0x06004682 RID: 18050 RVA: 0x001CE72C File Offset: 0x001CCB2C
	public static Sprite GetResidentGradeGem(QualityGrade grade)
	{
		string str = string.Empty;
		switch (grade)
		{
		case QualityGrade.Normal:
			return null;
		case QualityGrade.Rare:
			str = "rare_gem";
			break;
		case QualityGrade.Epic:
			str = "epic_gem";
			break;
		case QualityGrade.Legendary:
			str = "legendary_gem";
			break;
		case QualityGrade.Ancient:
			str = "ancient_gem";
			break;
		}
		return Resources.Load<Sprite>(FilePath.UpgradeCardPath + str);
	}

	// Token: 0x06004683 RID: 18051 RVA: 0x001CE7A0 File Offset: 0x001CCBA0
	public static Material GetMaterialByBattleEffectNature(BattleEffectNature nature)
	{
		switch (nature)
		{
		case BattleEffectNature.Positive:
			return Resources.Load<Material>("Prefabs/Eric/NewlyImport/TextMeshMaterial/Green");
		case BattleEffectNature.Neutral:
			return Resources.Load<Material>("Prefabs/Eric/NewlyImport/TextMeshMaterial/None");
		case BattleEffectNature.Negative:
			return Resources.Load<Material>("Prefabs/Eric/NewlyImport/TextMeshMaterial/Red");
		default:
			throw new Exception("SkillNature not found");
		}
	}

	// Token: 0x06004684 RID: 18052 RVA: 0x001CE7EF File Offset: 0x001CCBEF
	public static Sprite GetSkillEffectNatureBackground(BattleEffectNature nature)
	{
		switch (nature)
		{
		case BattleEffectNature.Positive:
			return FilePath.UiElements[5];
		case BattleEffectNature.Neutral:
			return FilePath.UiElements[3];
		case BattleEffectNature.Negative:
			return FilePath.UiElements[4];
		default:
			throw new Exception("SkillNature not found");
		}
	}

	// Token: 0x06004685 RID: 18053 RVA: 0x001CE82A File Offset: 0x001CCC2A
	public static Sprite GetFillSpriteBaseOnPercentage(float percentage)
	{
		if (percentage < 0.3f)
		{
			return FilePath.UiElements[4];
		}
		if ((double)percentage >= 0.3 && percentage <= 0.7f)
		{
			return FilePath.UiElements[3];
		}
		return FilePath.UiElements[5];
	}

	// Token: 0x06004686 RID: 18054 RVA: 0x001CE869 File Offset: 0x001CCC69
	public static Sprite GetTargetImageByNature(bool isFriendlyUnit)
	{
		return (!isFriendlyUnit) ? FilePath.DghzSprites[1615] : FilePath.DghzSprites[1614];
	}

	// Token: 0x06004687 RID: 18055 RVA: 0x001CE88C File Offset: 0x001CCC8C
	public static Sprite GetTargetSprite(bool isFriendlyUnit)
	{
		return (!isFriendlyUnit) ? FilePath.TargetHostileSprite : FilePath.TargetFriendlySprite;
	}

	// Token: 0x06004688 RID: 18056 RVA: 0x001CE8A4 File Offset: 0x001CCCA4
	// Note: this type is marked as 'beforefieldinit'.
	static FilePath()
	{
	}

	// Token: 0x04003535 RID: 13621
	public static readonly string UiPath = "Prefabs/UI/";

	// Token: 0x04003536 RID: 13622
	public static readonly string UiHeroPath = "Prefabs/CharactersUI/";

	// Token: 0x04003537 RID: 13623
	public static readonly string CombatMonsterPath = "Prefabs/Monsters/";

	// Token: 0x04003538 RID: 13624
	public static readonly string BuildingPath = "Prefabs/Buildings/";

	// Token: 0x04003539 RID: 13625
	public static readonly string CombatScenePath = "Prefabs/CombatScene/";

	// Token: 0x0400353A RID: 13626
	public static readonly string CharacterImagePath = "Images/Characters/";

	// Token: 0x0400353B RID: 13627
	public static readonly string InventoryIconPath = "Images/Inventory Icons/";

	// Token: 0x0400353C RID: 13628
	public static readonly string SkillIconPath = "Images/Skill Icons/";

	// Token: 0x0400353D RID: 13629
	public static readonly string SkillEffectPath = "Prefabs/Skill Effects/";

	// Token: 0x0400353E RID: 13630
	public static readonly string AdventurerUiEffectPath = "Prefabs/CharacterEffects/";

	// Token: 0x0400353F RID: 13631
	public static readonly string NewPartialSystemSkillEffectPath = "Prefabs/Skill Effects/NewPartialSystemSkill/";

	// Token: 0x04003540 RID: 13632
	public static readonly string UpgradeCardPath = "Images/UpgradeCard/";

	// Token: 0x04003541 RID: 13633
	public static readonly string BuildingImage = "Images/Buildings/";

	// Token: 0x04003542 RID: 13634
	public static readonly string SoundPathUi = "Sound/UI/";

	// Token: 0x04003543 RID: 13635
	public static readonly string SoundPathMusicEffect = "Sound/Music Effects/";

	// Token: 0x04003544 RID: 13636
	public const string PackAImagesPath = "Images/Pack1A/";

	// Token: 0x04003545 RID: 13637
	public const string PackBImagesPath = "Images/Pack1B/";

	// Token: 0x04003546 RID: 13638
	public const string GradeBackground = "Images/GradeBackgrounds/";

	// Token: 0x04003547 RID: 13639
	public static Sprite[] ResourceIcons = Resources.LoadAll<Sprite>("Images/Icons/ResourceIcons/tf_icon_32");

	// Token: 0x04003548 RID: 13640
	public static Sprite[] DghzSprites = Resources.LoadAll<Sprite>("Images/Icons/DGHZ icon pack/Iconset");

	// Token: 0x04003549 RID: 13641
	public static Sprite[] UiElements = Resources.LoadAll<Sprite>("Images/UI/Ultimate/fu");

	// Token: 0x0400354A RID: 13642
	public static Sprite[] GemSprites = Resources.LoadAll<Sprite>("Images/Icons/Gems");

	// Token: 0x0400354B RID: 13643
	public static Sprite[] PutumnoIcons = Resources.LoadAll<Sprite>("Images/Icons/Putumno_Cut 1");

	// Token: 0x0400354C RID: 13644
	public static Sprite[] WhiteShips = Resources.LoadAll<Sprite>("Images/Ships/boats");

	// Token: 0x0400354D RID: 13645
	public const string OutputEffectPath = "Prefabs/OutputEffects/";

	// Token: 0x0400354E RID: 13646
	public static readonly string ActiveSkillEffectPath = "Prefabs/Skill Effects/ActiveSkillEffects/";

	// Token: 0x0400354F RID: 13647
	public static string BattleInfoPath = "Prefabs/UI/BattleInfoPanel/";

	// Token: 0x04003550 RID: 13648
	public const string NewEnemyAvartarPath = "Images/Monsters/NewMonsters/";

	// Token: 0x04003551 RID: 13649
	public static Sprite[] NewEnemyImages = Resources.LoadAll<Sprite>("Images/Monsters/NewMonsters/Monster Megasheet");

	// Token: 0x04003552 RID: 13650
	public static string NewPackEnemyImages = "Images/Monsters/Pack3/";

	// Token: 0x04003553 RID: 13651
	public static string AdditionalEnemyImages = "Prefabs/Monsters/New/";

	// Token: 0x04003554 RID: 13652
	public static string NewlyDownloadMonsters = "Prefabs/Monsters/NewlyImportedMonsters/";

	// Token: 0x04003555 RID: 13653
	public static GameObject GetTargetingGameObject = Resources.Load("Prefabs/Monsters/TargetObjs/NewTarget") as GameObject;

	// Token: 0x04003556 RID: 13654
	private const string TextStatusMatPath = "Fonts/Chinese Mesh/UITextMat/";

	// Token: 0x04003557 RID: 13655
	private const string ChestPathRewardPath = "Prefabs/Eric/Battle/Chest/Bags/bags";

	// Token: 0x04003558 RID: 13656
	public const string ResourceUpdateObjPath = "Prefabs/Eric/Battle/Resources/ResourceUpdates";

	// Token: 0x04003559 RID: 13657
	public const string SkillIconObj = "Prefabs/Eric/SelectionList/SkillManagement/SkillIcon";

	// Token: 0x0400355A RID: 13658
	public const string ChestOriginalImageName = "chests_shadowed";

	// Token: 0x0400355B RID: 13659
	public const string ChestPath = "Prefabs/Eric/Battle/Chest/ChestPre";

	// Token: 0x0400355C RID: 13660
	public const string PopupRewards = "Prefabs/Eric/Battle/Chest/PopupItems/FadingReward";

	// Token: 0x0400355D RID: 13661
	public const string LevelSelectable = "Prefabs/Eric/SelectionList/LevelSelection/LevelSelectables";

	// Token: 0x0400355E RID: 13662
	public const string MultiRewardCategory = "Prefabs/Eric/SelectionList/LevelSelection/MultiRewardCate";

	// Token: 0x0400355F RID: 13663
	public const string ConsumablePrefabPath = "Prefabs/Eric/SelectionList/Consumption";

	// Token: 0x04003560 RID: 13664
	public const string BriefQuestPrefabPath = "Prefabs/Eric/Quests/Pieces/BriefQuest";

	// Token: 0x04003561 RID: 13665
	public const string EnemyInWalkingBattlePath = "Prefabs/Eric/Battle/EnemiesWalking/";

	// Token: 0x04003562 RID: 13666
	public const string NewEnemyInWalkingBattlePath = "Prefabs/Eric/Battle/EnemiesWalking/NewMonster/";

	// Token: 0x04003563 RID: 13667
	public const string HeroBattleInfoObj = "Prefabs/Eric/Battle/PanelRelatedPrefabs/HeroInBattleInfoUpdateFinal";

	// Token: 0x04003564 RID: 13668
	public const string InBattleEffectGameObject = "Prefabs/Eric/Battle/PanelRelatedPrefabs/New/NewEffect";

	// Token: 0x04003565 RID: 13669
	public const string BattleEffectsPath = "Prefabs/BattleEffects/";

	// Token: 0x04003566 RID: 13670
	public const string BattleEffectNatureMaterial = "Prefabs/Eric/NewlyImport/TextMeshMaterial/";

	// Token: 0x04003567 RID: 13671
	public static Sprite TargetFriendlySprite = Resources.Load<Sprite>("Images/UI/Ultimate/TestTargetGreen");

	// Token: 0x04003568 RID: 13672
	public static Sprite TargetHostileSprite = Resources.Load<Sprite>("Images/UI/Ultimate/TestTarget");
}
