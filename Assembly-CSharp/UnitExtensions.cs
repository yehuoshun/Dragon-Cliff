using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using Assets.Scripts.Core.SpecialEffect.Dataload.AdventurerStarEffects;
using UnityEngine;

// Token: 0x0200049E RID: 1182
public static class UnitExtensions
{
	// Token: 0x0600231F RID: 8991 RVA: 0x0010146D File Offset: 0x000FF86D
	public static AffixAttachmentRuleBase GetAffixRule(this AffixType type)
	{
		return UnitExtensions.UnitAffixRules[type];
	}

	// Token: 0x06002320 RID: 8992 RVA: 0x0010147A File Offset: 0x000FF87A
	public static UnitStyleConfigurationBase GetStyleConfig(this UnitClassStyle style)
	{
		return UnitExtensions.UnitStyleBases[style];
	}

	// Token: 0x06002321 RID: 8993 RVA: 0x00101487 File Offset: 0x000FF887
	public static CardUpgradeProcessorBase GetUpgradeProcess(this UpgradeCardType type)
	{
		return UnitExtensions.AdventurerCardUpgradeProcessor[type];
	}

	// Token: 0x06002322 RID: 8994 RVA: 0x00101494 File Offset: 0x000FF894
	public static double GetToughnessValue(this IBattleUnit unit, AttributeRetrievalLevel level)
	{
		double num = unit.GetAttributeValue_Final(AttributeType.Vitality, level) * ((unit.GetAttributeValue_Final(AttributeType.PhysicalResistance, AttributeRetrievalLevel.Skill) + unit.GetAttributeValue_Final(AttributeType.FireResistanceResistance, AttributeRetrievalLevel.Skill) + unit.GetAttributeValue_Final(AttributeType.ShadowResistance, AttributeRetrievalLevel.Skill) + unit.GetAttributeValue_Final(AttributeType.LightningResistance, AttributeRetrievalLevel.Skill) + unit.GetAttributeValue_Final(AttributeType.IceResistance, AttributeRetrievalLevel.Skill) + unit.GetAttributeValue_Final(AttributeType.PoisonResistance, AttributeRetrievalLevel.Skill) + unit.GetAttributeValue_Final(AttributeType.DivineResistance, AttributeRetrievalLevel.Skill)) / 7.0) * (1.0 + unit.GetAttributeValue_Final(AttributeType.DamageReduction, AttributeRetrievalLevel.Skill));
		if (num <= 0.0 || double.IsNaN(num))
		{
			return 0.0;
		}
		return num;
	}

	// Token: 0x06002323 RID: 8995 RVA: 0x00101534 File Offset: 0x000FF934
	public static EnemyBattleUnit CreateEnemyUnit(this UnitClass enemyClass, double powerLevel, int level, int skillLevel, Adventure adventure, List<SkillType> overrideSkills)
	{
		MonsterUnitConfigurationBase config = enemyClass.GetConfiguration() as MonsterUnitConfigurationBase;
		return config.CreateEnemyUnit(powerLevel, level, skillLevel, adventure, overrideSkills);
	}

	// Token: 0x06002324 RID: 8996 RVA: 0x0010155C File Offset: 0x000FF95C
	public static EnemyBattleUnit CreateEnemyUnit(this MonsterUnitConfigurationBase config, double powerLevel, int level, int skillLevel, Adventure adventure, List<SkillType> overrideSkills)
	{
		List<Skill> list = new List<Skill>();
		if (overrideSkills != null && overrideSkills.Count > 0)
		{
			list = (from s in overrideSkills
			select s.CreateMonsterSkill(skillLevel)).ToList<Skill>();
		}
		else
		{
			list.AddRange(config.GenerateSkills(adventure.CorrespondingDifficultyMeasurement, skillLevel));
		}
		List<Skill> list2 = list;
		EnemyBattleUnit enemyBattleUnit = new EnemyBattleUnit(config, new List<AdventureUnitSkill>(), powerLevel, Guid.NewGuid().ToString(), adventure, level);
		List<AdventureUnitSkill> list3 = new List<AdventureUnitSkill>();
		foreach (Skill skill in list2)
		{
			list3.Add(skill.InitializeBattleUnitSkill(enemyBattleUnit));
		}
		enemyBattleUnit.Skills = list3;
		return enemyBattleUnit;
	}

	// Token: 0x06002325 RID: 8997 RVA: 0x00101654 File Offset: 0x000FFA54
	public static Dictionary<AttributeRetrievalLevel, Dictionary<AttributeType, Dictionary<ModificationType, double?>>> GetValues(this List<AttributeModifier> modifiers)
	{
		Dictionary<AttributeRetrievalLevel, Dictionary<AttributeType, Dictionary<ModificationType, double?>>> dictionary = new Dictionary<AttributeRetrievalLevel, Dictionary<AttributeType, Dictionary<ModificationType, double?>>>();
		List<AttributeModifier> modifiers2 = (from m in modifiers
		where m.AttributeModifierType == AttributeModifierType.Normal
		select m).ToList<AttributeModifier>();
		UnitExtensions.RetrieveValues(AttributeRetrievalLevel.Naked, modifiers2, dictionary);
		List<AttributeModifier> modifiers3 = (from a in modifiers
		where a.AttributeModifierType == AttributeModifierType.Gear || a.AttributeModifierType == AttributeModifierType.Embeded || a.AttributeModifierType == AttributeModifierType.Growth
		select a).ToList<AttributeModifier>();
		UnitExtensions.RetrieveValues(AttributeRetrievalLevel.Gear, modifiers3, dictionary);
		List<AttributeModifier> modifiers4 = (from a in modifiers
		where a.AttributeModifierType == AttributeModifierType.SetBonus
		select a).ToList<AttributeModifier>();
		UnitExtensions.RetrieveValues(AttributeRetrievalLevel.Bonus, modifiers4, dictionary);
		return dictionary;
	}

	// Token: 0x06002326 RID: 8998 RVA: 0x001016FC File Offset: 0x000FFAFC
	private static void RetrieveValues(AttributeRetrievalLevel level, List<AttributeModifier> modifiers, Dictionary<AttributeRetrievalLevel, Dictionary<AttributeType, Dictionary<ModificationType, double?>>> values)
	{
		values[level] = new Dictionary<AttributeType, Dictionary<ModificationType, double?>>();
		foreach (AttributeType type2 in ItemExtensions.AllAttributeTypes)
		{
			AttributeType type = type2;
			List<AttributeModifier> source = (from a in modifiers
			where a.AttributeType == type
			select a).ToList<AttributeModifier>();
			values[level][type] = new Dictionary<ModificationType, double?>();
			values[level][type][ModificationType.Addition] = new double?((from a in source
			where a.ModificationType == ModificationType.Addition
			select a).Sum((AttributeModifier a) => a.Value));
			values[level][type][ModificationType.Multiplication] = new double?((from a in source
			where a.ModificationType == ModificationType.Multiplication
			select a).Sum((AttributeModifier a) => a.Value));
			List<AttributeModifier> source2 = (from a in source
			where a.ModificationType == ModificationType.Replacement
			select a).ToList<AttributeModifier>();
			if (source2.Any<AttributeModifier>())
			{
				values[level][type][ModificationType.Replacement] = new double?(source2.Last<AttributeModifier>().Value);
			}
			else
			{
				values[level][type][ModificationType.Replacement] = null;
			}
		}
	}

	// Token: 0x06002327 RID: 8999 RVA: 0x001018F0 File Offset: 0x000FFCF0
	public static UnitConfigurationBase GetConfiguration(this UnitClass type)
	{
		return UnitExtensions.UnitConfigurations[type];
	}

	// Token: 0x06002328 RID: 9000 RVA: 0x00101900 File Offset: 0x000FFD00
	public static Action<AdventurerProfile, GameWorldEvent, object> GetUnitGameWorldEventLogic(this UnitClass unitClass)
	{
		if (UnitExtensions.UnitConfigurations.ContainsKey(unitClass))
		{
			return new Action<AdventurerProfile, GameWorldEvent, object>(UnitExtensions.UnitConfigurations[unitClass].TownProcess);
		}
		if (UnitExtensions.<>f__mg$cache0 == null)
		{
			UnitExtensions.<>f__mg$cache0 = new Action<AdventurerProfile, GameWorldEvent, object>(UnitExtensions.EmptyTownLogicFun);
		}
		return UnitExtensions.<>f__mg$cache0;
	}

	// Token: 0x06002329 RID: 9001 RVA: 0x00101954 File Offset: 0x000FFD54
	public static ClassCategory GetClassCategory(this UnitClassStyle style)
	{
		Dictionary<UnitClassStyle, ClassCategory> dictionary = new Dictionary<UnitClassStyle, ClassCategory>
		{
			{
				UnitClassStyle.None,
				ClassCategory.MeleeTank
			},
			{
				UnitClassStyle.PhysicalKiller,
				ClassCategory.MeleeAssassin
			},
			{
				UnitClassStyle.PhysicalWarrior,
				ClassCategory.MeleeWarrior
			},
			{
				UnitClassStyle.PhysicalDefender,
				ClassCategory.MeleeTank
			},
			{
				UnitClassStyle.Protector,
				ClassCategory.MeleeTank
			},
			{
				UnitClassStyle.PhysicalSupporter,
				ClassCategory.MeleeSupport
			},
			{
				UnitClassStyle.Healer,
				ClassCategory.Healer
			},
			{
				UnitClassStyle.SpellWarrior,
				ClassCategory.CasterWarrior
			},
			{
				UnitClassStyle.SpellDefender,
				ClassCategory.CasterTank
			},
			{
				UnitClassStyle.SpellSupporter,
				ClassCategory.CasterSupport
			},
			{
				UnitClassStyle.SpellKiller,
				ClassCategory.CasterAssassin
			},
			{
				UnitClassStyle.Statue,
				ClassCategory.Statue
			}
		};
		return dictionary[style];
	}

	// Token: 0x0600232A RID: 9002 RVA: 0x001019D6 File Offset: 0x000FFDD6
	public static bool IsAdventurerLayout(this UnitClass unitClass)
	{
		return unitClass < (UnitClass)10000;
	}

	// Token: 0x0600232B RID: 9003 RVA: 0x001019E0 File Offset: 0x000FFDE0
	public static List<UnitLevelConfiguration> SetupLevelConfigurations()
	{
		int num = 150;
		int num2 = 100;
		int num3 = 10000;
		int num4 = -1;
		List<UnitLevelConfiguration> list = new List<UnitLevelConfiguration>();
		for (int i = 0; i <= 91; i++)
		{
			list.Add(new UnitLevelConfiguration
			{
				Level = i + 1,
				FromExp = num4 + 1,
				ToExp = num4 + num
			});
			num4 += num;
			if (i < 59)
			{
				num += num2;
			}
			else
			{
				num += num3;
				num3 += num3 / 4;
			}
		}
		return list;
	}

	// Token: 0x0600232C RID: 9004 RVA: 0x00101A70 File Offset: 0x000FFE70
	public static UnitLevelConfiguration GetAdventurerLevelConfig(long exp)
	{
		return UnitExtensions.LevelConfigs.First((UnitLevelConfiguration l) => (long)l.FromExp <= exp && (long)l.ToExp >= exp);
	}

	// Token: 0x0600232D RID: 9005 RVA: 0x00101AA0 File Offset: 0x000FFEA0
	public static bool CanAdventurerLevelUp(long currentExp, long nextExp)
	{
		UnitLevelConfiguration adventurerLevelConfig = UnitExtensions.GetAdventurerLevelConfig(currentExp);
		UnitLevelConfiguration adventurerLevelConfig2 = UnitExtensions.GetAdventurerLevelConfig(nextExp);
		return adventurerLevelConfig != adventurerLevelConfig2;
	}

	// Token: 0x0600232E RID: 9006 RVA: 0x00101AC4 File Offset: 0x000FFEC4
	public static bool IsCoreAttributes(this AttributeType type)
	{
		return type >= AttributeType.Strength && type <= (AttributeType)200;
	}

	// Token: 0x0600232F RID: 9007 RVA: 0x00101AE8 File Offset: 0x000FFEE8
	public static bool IsProcessingAttributes(this AttributeType type)
	{
		return type >= (AttributeType)201 && type <= (AttributeType)300;
	}

	// Token: 0x06002330 RID: 9008 RVA: 0x00101B10 File Offset: 0x000FFF10
	public static AdventurerProfile GenerateAdventurerProfileWithDefinedQuality(this UnitClass @class, float quality)
	{
		QualityGrade grade = QualityGrade.Normal;
		if ((double)quality <= 0.2)
		{
			grade = QualityGrade.Normal;
		}
		if ((double)quality > 0.2 && (double)quality <= 0.4)
		{
			grade = QualityGrade.Rare;
		}
		if ((double)quality > 0.4 && (double)quality <= 0.7)
		{
			grade = QualityGrade.Epic;
		}
		if ((double)quality > 0.7 && (double)quality <= 1.2)
		{
			grade = QualityGrade.Legendary;
		}
		if ((double)quality > 1.2)
		{
			grade = QualityGrade.Ancient;
		}
		return UnitExtensions.CreateAdventurer(@class, quality, grade);
	}

	// Token: 0x06002331 RID: 9009 RVA: 0x00101BB4 File Offset: 0x000FFFB4
	public static AdventurerProfile RandomGenerateAdventurerProfileWithStarChance(this UnitClass @class, double starchance)
	{
		GenerationDistribution generationDistribution = ItemExtensions.DefaultAdventurerSpawnDistribution();
		double adventurerSpawnBoost = GameWorld.instance.PlayerProfile.GetAdventurerSpawnBoost();
		if (adventurerSpawnBoost > 0.0)
		{
			generationDistribution.BoostDrop(adventurerSpawnBoost);
			foreach (RecruitmentQualityBoostEffect recruitmentQualityBoostEffect in GameWorld.instance.PlayerProfile.GetTownEffects().OfType<RecruitmentQualityBoostEffect>().ToList<RecruitmentQualityBoostEffect>())
			{
				recruitmentQualityBoostEffect.RemoveTrigger(1);
			}
		}
		QualityGrade grade = generationDistribution.GetGrade();
		float quality = UnitExtensions.GenerateGradeQualitySettingValueForAdventurer(grade, starchance);
		return UnitExtensions.CreateAdventurer(@class, quality, grade);
	}

	// Token: 0x06002332 RID: 9010 RVA: 0x00101C74 File Offset: 0x00100074
	private static AdventurerProfile CreateAdventurer(UnitClass @class, float quality, QualityGrade grade)
	{
		UnitGrowthProfile adventurerGrowthProfile = (@class.GetConfiguration() as AdventurerUnitConfigurationBase).AdventurerGrowthProfile;
		List<ISpecialEffectDataLoad> specialEffects = (@class.GetConfiguration() as AdventurerUnitConfigurationBase).GetSpecialEffects();
		if ((double)quality >= 2.5)
		{
			if (quality < 5f)
			{
				if (@class == UnitClass.FirePlayer)
				{
					specialEffects.Add(new FirePlayerStarDoubleHitData
					{
						Chance = (double)UnityEngine.Random.Range(0.1f, 0.2f),
						NumberOfAdditionalHitCheck = 1
					});
				}
				if (@class == UnitClass.YoungWarlock)
				{
					specialEffects.Add(new YoungWarlockStarIntStealData
					{
						Chance = (double)UnityEngine.Random.Range(0.4f, 0.8f),
						Rate = 0.3
					});
				}
				if (@class == UnitClass.Conjurer)
				{
					specialEffects.Add(new ConjurerStarTeamBuffData
					{
						HitRate = (double)UnityEngine.Random.Range(0.05f, 0.1f),
						DodgeRate = (double)UnityEngine.Random.Range(0.05f, 0.1f),
						ReflectionRate = (double)UnityEngine.Random.Range(0.2f, 0.4f)
					});
				}
				if (@class == UnitClass.ElementalWizard)
				{
					specialEffects.Add(new ElementalWizardStarHealShieldData
					{
						Rate = (double)UnityEngine.Random.Range(0.05f, 0.08f),
						Chance = (double)UnityEngine.Random.Range(0.5f, 0.8f)
					});
				}
				if (@class == UnitClass.Cube)
				{
					specialEffects.Add(new CubeStarSkillBoostData
					{
						Extra = UnityEngine.Random.Range(1, 3)
					});
				}
				if (@class == UnitClass.SoulThief)
				{
					specialEffects.Add(new SoulThiefStarEffectBoostData
					{
						Chance = (double)UnityEngine.Random.Range(0.2f, 0.55f)
					});
				}
				if (@class == UnitClass.FireAssassin)
				{
					specialEffects.Add(new FireAssassinStarImmuneData
					{
						Chance = (double)UnityEngine.Random.Range(0.2f, 0.4f),
						NumberOfShields = 2
					});
				}
				if (@class == UnitClass.NightBlade)
				{
					specialEffects.Add(new NightBladeStarHealReductionBoostData());
				}
				if (@class == UnitClass.Warrior)
				{
					specialEffects.Add(new WarriorStarTauntData
					{
						TauntRate = (double)UnityEngine.Random.Range(0.3f, 0.6f),
						NonResistRate = (double)UnityEngine.Random.Range(0.3f, 0.6f)
					});
				}
				if (@class == UnitClass.Duelist)
				{
					specialEffects.Add(new DuelistStarSkillBoostData
					{
						Rate = (double)UnityEngine.Random.Range(0.05f, 0.1f)
					});
				}
				if (@class == UnitClass.Tactician)
				{
					specialEffects.Add(new TacticianStarSkillBoostData
					{
						Rate = (double)UnityEngine.Random.Range(0.8f, 1.6f)
					});
				}
				if (@class == UnitClass.ToughWoman)
				{
					specialEffects.Add(new ToughWomanStarAgileBoostData
					{
						Rate = (double)UnityEngine.Random.Range(0.04f, 0.1f)
					});
				}
				if (@class == UnitClass.StreetMan)
				{
					specialEffects.Add(new StreetManStarHitBoostData
					{
						Extra = UnityEngine.Random.Range(1, 3)
					});
				}
				if (@class == UnitClass.DrunkReader)
				{
					specialEffects.Add(new DrunkReaderStarUndeadData
					{
						Chance = (double)UnityEngine.Random.Range(0.2f, 0.5f),
						Cost = 25000,
						RevivieRate = 0.3
					});
				}
				if (@class == UnitClass.Missionary)
				{
					specialEffects.Add(new MissionaryStarReflectionData
					{
						Rate = (double)UnityEngine.Random.Range(10f, 30f)
					});
				}
				if (@class == UnitClass.Killer)
				{
					specialEffects.Add(new KillerStarReflectionData
					{
						Chance = (double)UnityEngine.Random.Range(0.3f, 0.55f)
					});
				}
				if (@class == UnitClass.Paladin)
				{
					specialEffects.Add(new PaladinStarTauntEnhanceData
					{
						Chance = (double)UnityEngine.Random.Range(0.3f, 0.5f)
					});
				}
				if (@class == UnitClass.ChubbyLady)
				{
					specialEffects.Add(new ChubbyLadyStarHealerEnhanceData());
				}
				if (@class == UnitClass.BunSister)
				{
					specialEffects.Add(new BunsisterStarMultipleHitData
					{
						Chance = (double)UnityEngine.Random.Range(0.1f, 0.2f)
					});
				}
				if (@class == UnitClass.FashionBoy)
				{
					specialEffects.Add(new FashionBoyStarDoubleDamageData
					{
						Chance = (double)UnityEngine.Random.Range(0.03f, 0.7f)
					});
				}
				if (@class == UnitClass.IronSolider)
				{
					specialEffects.Add(new IronSoilderStarHitBoostData
					{
						Chance = (double)UnityEngine.Random.Range(0.3f, 0.6f),
						DodgeBoost = (double)UnityEngine.Random.Range(0.1f, 0.15f),
						HitBoost = (double)UnityEngine.Random.Range(0.1f, 0.15f)
					});
				}
				if (@class == UnitClass.SnowMaiden)
				{
					specialEffects.Add(new SnowMaidenStarEffectData
					{
						ExtraRate = (double)UnityEngine.Random.Range(0.05f, 0.1f),
						PerLevelRate = UnityEngine.Random.Range(10, 20)
					});
				}
				if (@class == UnitClass.FireCharger)
				{
					specialEffects.Add(new FireChargerStarElementData());
				}
				if (@class == UnitClass.GoldenShaman)
				{
					specialEffects.Add(new GoldenShamanStarHealData
					{
						Rate = (double)UnityEngine.Random.Range(0.01f, 0.05f)
					});
				}
				if (@class == UnitClass.RedHorn)
				{
					specialEffects.Add(new RedHornStarDamageBoostData
					{
						Rate = (double)UnityEngine.Random.Range(3f, 6f)
					});
				}
			}
			else
			{
				if (@class == UnitClass.FirePlayer)
				{
					specialEffects.Add(new FirePlayerStarDoubleHitData
					{
						Chance = (double)UnityEngine.Random.Range(0.25f, 0.3f),
						NumberOfAdditionalHitCheck = 2
					});
				}
				if (@class == UnitClass.YoungWarlock)
				{
					specialEffects.Add(new YoungWarlockStarIntStealData
					{
						Chance = (double)UnityEngine.Random.Range(0.7f, 1f),
						Rate = 0.45
					});
				}
				if (@class == UnitClass.Conjurer)
				{
					specialEffects.Add(new ConjurerStarTeamBuffData
					{
						HitRate = (double)UnityEngine.Random.Range(0.1f, 0.18f),
						DodgeRate = (double)UnityEngine.Random.Range(0.1f, 0.18f),
						ReflectionRate = (double)UnityEngine.Random.Range(0.5f, 0.7f)
					});
				}
				if (@class == UnitClass.ElementalWizard)
				{
					specialEffects.Add(new ElementalWizardStarHealShieldData
					{
						Rate = (double)UnityEngine.Random.Range(0.15f, 0.2f),
						Chance = (double)UnityEngine.Random.Range(0.75f, 1f)
					});
				}
				if (@class == UnitClass.Cube)
				{
					specialEffects.Add(new CubeStarSkillBoostData
					{
						Extra = UnityEngine.Random.Range(2, 5)
					});
				}
				if (@class == UnitClass.SoulThief)
				{
					specialEffects.Add(new SoulThiefStarEffectBoostData
					{
						Chance = (double)UnityEngine.Random.Range(0.5f, 0.85f)
					});
				}
				if (@class == UnitClass.FireAssassin)
				{
					specialEffects.Add(new FireAssassinStarImmuneData
					{
						Chance = (double)UnityEngine.Random.Range(0.4f, 0.55f),
						NumberOfShields = 3
					});
				}
				if (@class == UnitClass.NightBlade)
				{
					specialEffects.Add(new NightBladeStarHealReductionBoostData());
				}
				if (@class == UnitClass.Warrior)
				{
					specialEffects.Add(new WarriorStarTauntData
					{
						TauntRate = (double)UnityEngine.Random.Range(0.55f, 0.8f),
						NonResistRate = (double)UnityEngine.Random.Range(0.65f, 0.9f)
					});
				}
				if (@class == UnitClass.Duelist)
				{
					specialEffects.Add(new DuelistStarSkillBoostData
					{
						Rate = (double)UnityEngine.Random.Range(0.15f, 0.2f)
					});
				}
				if (@class == UnitClass.Tactician)
				{
					specialEffects.Add(new TacticianStarSkillBoostData
					{
						Rate = (double)UnityEngine.Random.Range(2f, 3.5f)
					});
				}
				if (@class == UnitClass.ToughWoman)
				{
					specialEffects.Add(new ToughWomanStarAgileBoostData
					{
						Rate = (double)UnityEngine.Random.Range(0.1f, 0.15f)
					});
				}
				if (@class == UnitClass.StreetMan)
				{
					specialEffects.Add(new StreetManStarHitBoostData
					{
						Extra = UnityEngine.Random.Range(3, 6)
					});
				}
				if (@class == UnitClass.DrunkReader)
				{
					specialEffects.Add(new DrunkReaderStarUndeadData
					{
						Chance = (double)UnityEngine.Random.Range(0.6f, 0.9f),
						Cost = 25000,
						RevivieRate = 0.5
					});
				}
				if (@class == UnitClass.Missionary)
				{
					specialEffects.Add(new MissionaryStarReflectionData
					{
						Rate = (double)UnityEngine.Random.Range(40f, 50f)
					});
				}
				if (@class == UnitClass.Killer)
				{
					specialEffects.Add(new KillerStarReflectionData
					{
						Chance = (double)UnityEngine.Random.Range(0.6f, 0.9f)
					});
				}
				if (@class == UnitClass.Paladin)
				{
					specialEffects.Add(new PaladinStarTauntEnhanceData
					{
						Chance = (double)UnityEngine.Random.Range(0.6f, 0.9f)
					});
				}
				if (@class == UnitClass.ChubbyLady)
				{
					specialEffects.Add(new ChubbyLadyStarHealerEnhanceData());
				}
				if (@class == UnitClass.BunSister)
				{
					specialEffects.Add(new BunsisterStarMultipleHitData
					{
						Chance = (double)UnityEngine.Random.Range(0.2f, 0.3f)
					});
				}
				if (@class == UnitClass.FashionBoy)
				{
					specialEffects.Add(new FashionBoyStarDoubleDamageData
					{
						Chance = (double)UnityEngine.Random.Range(0.1f, 0.18f)
					});
				}
				if (@class == UnitClass.IronSolider)
				{
					specialEffects.Add(new IronSoilderStarHitBoostData
					{
						Chance = (double)UnityEngine.Random.Range(0.75f, 1f),
						DodgeBoost = (double)UnityEngine.Random.Range(0.15f, 0.2f),
						HitBoost = (double)UnityEngine.Random.Range(0.15f, 0.2f)
					});
				}
				if (@class == UnitClass.SnowMaiden)
				{
					specialEffects.Add(new SnowMaidenStarEffectData
					{
						ExtraRate = (double)UnityEngine.Random.Range(0.2f, 0.3f),
						PerLevelRate = UnityEngine.Random.Range(35, 51)
					});
				}
				if (@class == UnitClass.FireCharger)
				{
					specialEffects.Add(new FireChargerStarElementData());
				}
				if (@class == UnitClass.GoldenShaman)
				{
					specialEffects.Add(new GoldenShamanStarHealData
					{
						Rate = (double)UnityEngine.Random.Range(0.06f, 0.12f)
					});
				}
				if (@class == UnitClass.RedHorn)
				{
					specialEffects.Add(new RedHornStarDamageBoostData
					{
						Rate = (double)UnityEngine.Random.Range(8f, 10f)
					});
				}
			}
		}
		foreach (ISpecialEffectDataLoad specialEffectDataLoad in specialEffects)
		{
			GameWorld.instance.PlayerProfile.UnlockEffect(specialEffectDataLoad.GetSpecialEffectType());
		}
		return new AdventurerProfile
		{
			Experience = 0L,
			NakedAttributes = adventurerGrowthProfile.GetInitializedAttributes((double)(1f + quality)),
			Attributes = new List<AttributeModifier>(),
			UnitClass = @class,
			Id = Guid.NewGuid().ToString(),
			WorkingBuilding = (TownSlot)0,
			Equipments = new List<string>(),
			Skills = (@class.GetConfiguration() as AdventurerUnitConfigurationBase).GenerateSkills(),
			SkillSlots = UnitExtensions.AdventurerSkillSlots,
			QualityCoefficient = (double)quality,
			Grade = grade,
			SpecialEffects = specialEffects,
			OutputType = ((!(@class.GetConfiguration() is AdventurerUnitConfigurationBase)) ? OutputType.Physical : (@class.GetConfiguration() as AdventurerUnitConfigurationBase).OutputType),
			UpgradedCards = new List<CardUpgrade>(),
			AvaliableUpgradeOptions = new List<CardUpgrade>(),
			RecentReRollPrice = 0.0,
			EquippedItems = new List<Item>(),
			Talents = (@class.GetConfiguration() as AdventurerUnitConfigurationBase).GenerateTalents(),
			TalentVersionDetails = PlayerProfile.TalentVersionDetails
		};
	}

	// Token: 0x06002333 RID: 9011 RVA: 0x0010288C File Offset: 0x00100C8C
	public static bool IsStarAdventurerEffect(this SpecialEffectType type)
	{
		List<SpecialEffectType> source = new List<SpecialEffectType>
		{
			SpecialEffectType.FirePlayerStarDoubleHit,
			SpecialEffectType.YoungWarlockStarIntSteal,
			SpecialEffectType.ConjurerStarTeamBoost,
			SpecialEffectType.ElementalWizardStarHeal,
			SpecialEffectType.CubeStarSkillBoost,
			SpecialEffectType.SoulThiefStarEffectBoost,
			SpecialEffectType.FireAssassinStarImmune,
			SpecialEffectType.NightbladeStarHealReduceBoost,
			SpecialEffectType.WarriorStarTaunt,
			SpecialEffectType.DuelistStarSkillBoost,
			SpecialEffectType.TacticianStarSkillBoost,
			SpecialEffectType.ToughWomanStarAgileBoost,
			SpecialEffectType.StreetManStarHitBoost,
			SpecialEffectType.DrunkReaderStarUndead,
			SpecialEffectType.MissionaryStarReflection,
			SpecialEffectType.KillerStarReflection,
			SpecialEffectType.PaladinStarTauntEnhance,
			SpecialEffectType.ChubbyLadyStarHealerEnhance,
			SpecialEffectType.BunSisterStarMultipleHit,
			SpecialEffectType.FashionBoyStarDoubleDamage,
			SpecialEffectType.IronSoilderStarHitBoost,
			SpecialEffectType.SnowMaidenStarEffect,
			SpecialEffectType.FireChargerStarElement,
			SpecialEffectType.GoldenShamanStarHeal,
			SpecialEffectType.RedHornStarDamageBoost
		};
		return source.Any((SpecialEffectType t) => t == type);
	}

	// Token: 0x06002334 RID: 9012 RVA: 0x001029D4 File Offset: 0x00100DD4
	public static float GenerateGradeQualitySettingValueForAdventurer(QualityGrade grade, double starchance)
	{
		float result = 0f;
		if (grade == QualityGrade.Normal)
		{
			result = UnityEngine.Random.Range(0.001f, 0.2f);
		}
		if (grade == QualityGrade.Rare)
		{
			result = UnityEngine.Random.Range(0.2f, 0.4f);
		}
		if (grade == QualityGrade.Epic)
		{
			result = UnityEngine.Random.Range(0.4f, 0.7f);
		}
		if (grade == QualityGrade.Legendary)
		{
			result = UnityEngine.Random.Range(0.7f, 1.2f);
		}
		if (grade == QualityGrade.Ancient)
		{
			if ((double)UnityEngine.Random.value < starchance)
			{
				if ((double)UnityEngine.Random.value <= 0.3)
				{
					result = UnityEngine.Random.Range(5f, 7f);
				}
				else
				{
					result = UnityEngine.Random.Range(2.5f, 5f);
				}
			}
			else if ((double)UnityEngine.Random.value <= 0.85)
			{
				result = UnityEngine.Random.Range(1.2f, 1.8f);
			}
			else
			{
				result = UnityEngine.Random.Range(1.8f, 2f);
			}
		}
		return result;
	}

	// Token: 0x06002335 RID: 9013 RVA: 0x00102AD0 File Offset: 0x00100ED0
	public static List<OutputType> GetAllDamageElements()
	{
		return new List<OutputType>
		{
			OutputType.Fire,
			OutputType.Poison,
			OutputType.Physical,
			OutputType.Lightening,
			OutputType.Ice,
			OutputType.Shadow,
			OutputType.Divine
		};
	}

	// Token: 0x06002336 RID: 9014 RVA: 0x00102B18 File Offset: 0x00100F18
	public static List<AttributeType> GetAllResistances()
	{
		return new List<AttributeType>
		{
			AttributeType.FireResistanceResistance,
			AttributeType.PoisonResistance,
			AttributeType.PhysicalResistance,
			AttributeType.LightningResistance,
			AttributeType.IceResistance,
			AttributeType.ShadowResistance,
			AttributeType.DivineResistance
		};
	}

	// Token: 0x06002337 RID: 9015 RVA: 0x00102B62 File Offset: 0x00100F62
	private static void EmptyTownLogicFun(AdventurerProfile adventurer, GameWorldEvent evt, object data)
	{
	}

	// Token: 0x06002338 RID: 9016 RVA: 0x00102B64 File Offset: 0x00100F64
	private static IEnumerable EmptyBattleLogicFunc(IBattleUnit ba, IBattleUnit bb, AdventureEventType type, object obj)
	{
		yield break;
	}

	// Token: 0x06002339 RID: 9017 RVA: 0x00102B80 File Offset: 0x00100F80
	// Note: this type is marked as 'beforefieldinit'.
	static UnitExtensions()
	{
	}

	// Token: 0x0600233A RID: 9018 RVA: 0x00102C2C File Offset: 0x0010102C
	[CompilerGenerated]
	private static bool <GetValues>m__0(AttributeModifier m)
	{
		return m.AttributeModifierType == AttributeModifierType.Normal;
	}

	// Token: 0x0600233B RID: 9019 RVA: 0x00102C37 File Offset: 0x00101037
	[CompilerGenerated]
	private static bool <GetValues>m__1(AttributeModifier a)
	{
		return a.AttributeModifierType == AttributeModifierType.Gear || a.AttributeModifierType == AttributeModifierType.Embeded || a.AttributeModifierType == AttributeModifierType.Growth;
	}

	// Token: 0x0600233C RID: 9020 RVA: 0x00102C5D File Offset: 0x0010105D
	[CompilerGenerated]
	private static bool <GetValues>m__2(AttributeModifier a)
	{
		return a.AttributeModifierType == AttributeModifierType.SetBonus;
	}

	// Token: 0x0600233D RID: 9021 RVA: 0x00102C68 File Offset: 0x00101068
	[CompilerGenerated]
	private static bool <RetrieveValues>m__3(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Addition;
	}

	// Token: 0x0600233E RID: 9022 RVA: 0x00102C73 File Offset: 0x00101073
	[CompilerGenerated]
	private static double <RetrieveValues>m__4(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x0600233F RID: 9023 RVA: 0x00102C7B File Offset: 0x0010107B
	[CompilerGenerated]
	private static bool <RetrieveValues>m__5(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Multiplication;
	}

	// Token: 0x06002340 RID: 9024 RVA: 0x00102C86 File Offset: 0x00101086
	[CompilerGenerated]
	private static double <RetrieveValues>m__6(AttributeModifier a)
	{
		return a.Value;
	}

	// Token: 0x06002341 RID: 9025 RVA: 0x00102C8E File Offset: 0x0010108E
	[CompilerGenerated]
	private static bool <RetrieveValues>m__7(AttributeModifier a)
	{
		return a.ModificationType == ModificationType.Replacement;
	}

	// Token: 0x06002342 RID: 9026 RVA: 0x00102C99 File Offset: 0x00101099
	[CompilerGenerated]
	private static UnitClass <UnitConfigurations>m__8(UnitConfigurationBase unit)
	{
		return unit.CorrespondingUnitClass;
	}

	// Token: 0x06002343 RID: 9027 RVA: 0x00102CA1 File Offset: 0x001010A1
	[CompilerGenerated]
	private static UnitClassStyle <UnitStyleBases>m__9(UnitStyleConfigurationBase unit)
	{
		return unit.CorrespondingStyle;
	}

	// Token: 0x06002344 RID: 9028 RVA: 0x00102CA9 File Offset: 0x001010A9
	[CompilerGenerated]
	private static AffixType <UnitAffixRules>m__A(AffixAttachmentRuleBase a)
	{
		return a.CorrespondingAffixType;
	}

	// Token: 0x06002345 RID: 9029 RVA: 0x00102CB1 File Offset: 0x001010B1
	[CompilerGenerated]
	private static UpgradeCardType <AdventurerCardUpgradeProcessor>m__B(CardUpgradeProcessorBase a)
	{
		return a.UpgradeType;
	}

	// Token: 0x06002346 RID: 9030 RVA: 0x00102CB9 File Offset: 0x001010B9
	[CompilerGenerated]
	private static SkillType <SkillBuilders>m__C(SkillLogicBase sk)
	{
		return sk.SkillType;
	}

	// Token: 0x04001E42 RID: 7746
	public static int MaxAdventurerLevel = 90;

	// Token: 0x04001E43 RID: 7747
	public static int RequiredBadgetsAmount = 1000;

	// Token: 0x04001E44 RID: 7748
	public static Dictionary<UnitClass, UnitConfigurationBase> UnitConfigurations = ItemExtensions.GetDictionaryOfAbastract<UnitClass, UnitConfigurationBase>((UnitConfigurationBase unit) => unit.CorrespondingUnitClass);

	// Token: 0x04001E45 RID: 7749
	public static Dictionary<UnitClassStyle, UnitStyleConfigurationBase> UnitStyleBases = ItemExtensions.GetDictionaryOfAbastract<UnitClassStyle, UnitStyleConfigurationBase>((UnitStyleConfigurationBase unit) => unit.CorrespondingStyle);

	// Token: 0x04001E46 RID: 7750
	public static Dictionary<AffixType, AffixAttachmentRuleBase> UnitAffixRules = ItemExtensions.GetDictionaryOfAbastract<AffixType, AffixAttachmentRuleBase>((AffixAttachmentRuleBase a) => a.CorrespondingAffixType);

	// Token: 0x04001E47 RID: 7751
	public static Dictionary<UpgradeCardType, CardUpgradeProcessorBase> AdventurerCardUpgradeProcessor = ItemExtensions.GetDictionaryOfAbastract<UpgradeCardType, CardUpgradeProcessorBase>((CardUpgradeProcessorBase a) => a.UpgradeType);

	// Token: 0x04001E48 RID: 7752
	public static readonly List<UnitLevelConfiguration> LevelConfigs = UnitExtensions.SetupLevelConfigurations();

	// Token: 0x04001E49 RID: 7753
	public static readonly int AttributeLevelUpCoefficient = 2;

	// Token: 0x04001E4A RID: 7754
	public static readonly float AttributeInitializationCoefficient = 10f;

	// Token: 0x04001E4B RID: 7755
	public static readonly int AdventurerSkillSlots = 5;

	// Token: 0x04001E4C RID: 7756
	public static readonly Dictionary<SkillType, SkillLogicBase> SkillBuilders = ItemExtensions.GetDictionaryOfAbastract<SkillType, SkillLogicBase>((SkillLogicBase sk) => sk.SkillType);

	// Token: 0x04001E4D RID: 7757
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache0;

	// Token: 0x04001E4E RID: 7758
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache1;

	// Token: 0x04001E4F RID: 7759
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache2;

	// Token: 0x04001E50 RID: 7760
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache3;

	// Token: 0x04001E51 RID: 7761
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache4;

	// Token: 0x04001E52 RID: 7762
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache5;

	// Token: 0x04001E53 RID: 7763
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache6;

	// Token: 0x04001E54 RID: 7764
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache7;

	// Token: 0x04001E55 RID: 7765
	[CompilerGenerated]
	private static Action<AdventurerProfile, GameWorldEvent, object> <>f__mg$cache0;

	// Token: 0x02000D84 RID: 3460
	[CompilerGenerated]
	private sealed class <CreateEnemyUnit>c__AnonStorey1
	{
		// Token: 0x060057F2 RID: 22514 RVA: 0x00102CC1 File Offset: 0x001010C1
		public <CreateEnemyUnit>c__AnonStorey1()
		{
		}

		// Token: 0x060057F3 RID: 22515 RVA: 0x00102CC9 File Offset: 0x001010C9
		internal Skill <>m__0(SkillType s)
		{
			return s.CreateMonsterSkill(this.skillLevel);
		}

		// Token: 0x040047B4 RID: 18356
		internal int skillLevel;
	}

	// Token: 0x02000D85 RID: 3461
	[CompilerGenerated]
	private sealed class <RetrieveValues>c__AnonStorey2
	{
		// Token: 0x060057F4 RID: 22516 RVA: 0x00102CD7 File Offset: 0x001010D7
		public <RetrieveValues>c__AnonStorey2()
		{
		}

		// Token: 0x060057F5 RID: 22517 RVA: 0x00102CDF File Offset: 0x001010DF
		internal bool <>m__0(AttributeModifier a)
		{
			return a.AttributeType == this.type;
		}

		// Token: 0x040047B5 RID: 18357
		internal AttributeType type;
	}

	// Token: 0x02000D86 RID: 3462
	[CompilerGenerated]
	private sealed class <GetAdventurerLevelConfig>c__AnonStorey3
	{
		// Token: 0x060057F6 RID: 22518 RVA: 0x00102CEF File Offset: 0x001010EF
		public <GetAdventurerLevelConfig>c__AnonStorey3()
		{
		}

		// Token: 0x060057F7 RID: 22519 RVA: 0x00102CF7 File Offset: 0x001010F7
		internal bool <>m__0(UnitLevelConfiguration l)
		{
			return (long)l.FromExp <= this.exp && (long)l.ToExp >= this.exp;
		}

		// Token: 0x040047B6 RID: 18358
		internal long exp;
	}

	// Token: 0x02000D87 RID: 3463
	[CompilerGenerated]
	private sealed class <IsStarAdventurerEffect>c__AnonStorey4
	{
		// Token: 0x060057F8 RID: 22520 RVA: 0x00102D20 File Offset: 0x00101120
		public <IsStarAdventurerEffect>c__AnonStorey4()
		{
		}

		// Token: 0x060057F9 RID: 22521 RVA: 0x00102D28 File Offset: 0x00101128
		internal bool <>m__0(SpecialEffectType t)
		{
			return t == this.type;
		}

		// Token: 0x040047B7 RID: 18359
		internal SpecialEffectType type;
	}

	// Token: 0x02000D88 RID: 3464
	[CompilerGenerated]
	private sealed class <EmptyBattleLogicFunc>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060057FA RID: 22522 RVA: 0x00102D33 File Offset: 0x00101133
		[DebuggerHidden]
		public <EmptyBattleLogicFunc>c__Iterator0()
		{
		}

		// Token: 0x060057FB RID: 22523 RVA: 0x00102D3B File Offset: 0x0010113B
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x17001274 RID: 4724
		// (get) Token: 0x060057FC RID: 22524 RVA: 0x00102D55 File Offset: 0x00101155
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001275 RID: 4725
		// (get) Token: 0x060057FD RID: 22525 RVA: 0x00102D5D File Offset: 0x0010115D
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060057FE RID: 22526 RVA: 0x00102D65 File Offset: 0x00101165
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x060057FF RID: 22527 RVA: 0x00102D67 File Offset: 0x00101167
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005800 RID: 22528 RVA: 0x00102D6E File Offset: 0x0010116E
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005801 RID: 22529 RVA: 0x00102D76 File Offset: 0x00101176
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new UnitExtensions.<EmptyBattleLogicFunc>c__Iterator0();
		}

		// Token: 0x040047B8 RID: 18360
		internal object $current;

		// Token: 0x040047B9 RID: 18361
		internal bool $disposing;

		// Token: 0x040047BA RID: 18362
		internal int $PC;
	}
}
