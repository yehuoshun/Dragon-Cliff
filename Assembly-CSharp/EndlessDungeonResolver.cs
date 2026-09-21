using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000452 RID: 1106
public class EndlessDungeonResolver : AdventureResolverBase
{
	// Token: 0x06001F5B RID: 8027 RVA: 0x000DC35D File Offset: 0x000DA75D
	public EndlessDungeonResolver()
	{
	}

	// Token: 0x06001F5C RID: 8028 RVA: 0x000DC365 File Offset: 0x000DA765
	public override bool CanBeResolved(AdventureStartParameter parameter)
	{
		return parameter.AdventureType == AdventureType.Endless_Entry && GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.MysticKey) > 0.0;
	}

	// Token: 0x06001F5D RID: 8029 RVA: 0x000DC398 File Offset: 0x000DA798
	protected override Adventure ResolveLogic(AdventureStartParameter parameter)
	{
		DungeonRecord dungeonRecord = GameWorld.instance.PlayerProfile.GetDungeonRecord(parameter.AdventureType);
		DifficultyLevelMeasurement difficultyLevelMeasurementByDungeonLevel = DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByDungeonLevel(dungeonRecord.CurrentSelectedLevel, AdventureType.Endless_Entry, -1);
		DifficultyLevelMeasurement difficultyLevelMeasurementByValue = DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(GameWorld.instance.PlayerProfile.AchievedDifficultyValue.GetValueOrDefault(), 1);
		List<AdventureType> list = new List<AdventureType>
		{
			AdventureType.Endless_N1,
			AdventureType.Endless_N2,
			AdventureType.Endless_N3,
			AdventureType.Endless_N4
		};
		parameter.ResetType(list[UnityEngine.Random.Range(0, list.Count)]);
		List<UnitClass> excludedMinions = new List<UnitClass>
		{
			UnitClass.HealingStone,
			UnitClass.PoisonStone,
			UnitClass.FireStone,
			UnitClass.LightningStone
		};
		List<UnitClass> possibleMinibossUnits = difficultyLevelMeasurementByValue.GetPossibleMinibossUnits();
		List<UnitClass> list2 = (from m in difficultyLevelMeasurementByValue.GetPossibleMinionUnits()
		where excludedMinions.All((UnitClass e) => e != m)
		select m).ToList<UnitClass>();
		List<UnitClass> possibleBossUnits = difficultyLevelMeasurementByValue.GetPossibleBossUnits();
		possibleBossUnits.Shuffle<UnitClass>();
		list2.Shuffle<UnitClass>();
		possibleMinibossUnits.Shuffle<UnitClass>();
		AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.WoodenForest.GetAdventureLevelConfiguration(1).NakedDuplicate();
		adventureLevelConfiguration.LevelNumber = dungeonRecord.CurrentSelectedLevel;
		adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 6;
		adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
		if (difficultyLevelMeasurementByDungeonLevel.DifficultyValue <= 20.0)
		{
			adventureLevelConfiguration.NumberOfRounds = 7;
		}
		else if (difficultyLevelMeasurementByDungeonLevel.DifficultyValue <= 200.0)
		{
			adventureLevelConfiguration.NumberOfRounds = 8;
		}
		else if (difficultyLevelMeasurementByDungeonLevel.DifficultyValue <= 700.0)
		{
			adventureLevelConfiguration.NumberOfRounds = 9;
		}
		else
		{
			adventureLevelConfiguration.NumberOfRounds = 12;
		}
		adventureLevelConfiguration.NumberOfMinionsPerRound = 0;
		adventureLevelConfiguration.MiniBossFormation = new List<FormationPresence>();
		adventureLevelConfiguration.BossFormations = new List<FormationPresence>();
		adventureLevelConfiguration.MiniBossSpawnTable = (from b in possibleMinibossUnits.Take(5)
		select new MonsterAppearance(100, b)).ToList<MonsterAppearance>();
		adventureLevelConfiguration.MinionSpawnTable = (from b in list2.Take(5)
		select new MonsterAppearance(100, b)).ToList<MonsterAppearance>();
		adventureLevelConfiguration.BossSpawnTable = (from b in possibleBossUnits.Take(1)
		select new MonsterAppearance(100, b)).ToList<MonsterAppearance>();
		adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>();
		GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
		{
			new ResourceUpdate
			{
				ResourceType = ResourceType.MysticKey,
				ChangeAmount = -1.0,
				RelatedItems = new List<Item>()
			}
		});
		return this.InitializeAdventureBaseOnLevel(parameter, adventureLevelConfiguration, difficultyLevelMeasurementByDungeonLevel);
	}

	// Token: 0x06001F5E RID: 8030 RVA: 0x000DC676 File Offset: 0x000DAA76
	public override List<ISpecialEffectDataLoad> GetDungeonSpecialEffects(AdventureStartParameter parameter)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001F5F RID: 8031 RVA: 0x000DC680 File Offset: 0x000DAA80
	private Adventure InitializeAdventureBaseOnLevel(AdventureStartParameter paramter, AdventureLevelConfiguration configuration, DifficultyLevelMeasurement correspondingDifficultyMeasurement)
	{
		foreach (ResourceType resourceType in paramter.Consumables)
		{
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = resourceType,
					ChangeAmount = -1.0,
					RelatedItems = new List<Item>()
				}
			});
		}
		Adventure adventure = new Adventure
		{
			LevelNumber = configuration.LevelNumber,
			Adventurers = new List<AdventurerBattleUnit>(),
			AdventureType = paramter.AdventureType,
			Encounters = new List<IEncounter>(),
			CompleteRewardList = new List<ResourceUpdate>(),
			CurrentEncounter = null,
			Chests = new List<Chest>(),
			DungeonEffects = configuration.DungeonEffects,
			PlayerEffects = new List<ISpecialEffectDataLoad>(),
			CorrespondingDifficultyMeasurement = correspondingDifficultyMeasurement,
			CorrespondingLevelConfiguration = configuration,
			AdventureCode = configuration.CustomizedIdentityCode
		};
		adventure.ActionCountSoFar = new double?(0.0);
		adventure.Adventurers = (from a in paramter.SelectedAdventurers
		select AdventurerBattleUnit.InitializeAdventurerBattleUnit(a, adventure)).ToList<AdventurerBattleUnit>();
		if (TestingProcessor.InTesting)
		{
			foreach (AdventurerBattleUnit adventurerBattleUnit in adventure.Adventurers)
			{
				adventurerBattleUnit.SpecialEffects.Add(new AgilityIdleBoostData
				{
					IsStar = false,
					BoostRate = 0.8,
					CoolingDownSeconds = 2,
					Counter = 0
				});
			}
			if (TestingProcessor.InTesting)
			{
				adventure.PlayerEffects.Add(new AnnihilationData
				{
					EffectResistanceReductionRate = 0.1,
					OutputReductionRate = 0.05
				});
			}
		}
		if (configuration.LevelNumber > 700)
		{
			adventure.ActionCountPossible = new double?(Adventure.CalculateMaxActionCounts(800.0, adventure.Adventurers));
		}
		adventure.Chests = Chest.GenerateChests(5, correspondingDifficultyMeasurement);
		adventure.Encounters.AddRange(this.GetEncounters(adventure.Adventurers.Cast<IBattleUnit>().ToList<IBattleUnit>(), adventure, configuration));
		adventure.PlayerEffects.AddRange(paramter.Consumables.SelectMany((ResourceType c) => c.GetCreationTemplate().GetNormalLevelSpecialEffectDataLoads(QualityGrade.Normal)));
		adventure.PlayerEffects.AddRange(GameWorld.instance.PlayerProfile.GetTownEffects().SelectMany((TownEffectBase ef) => ef.GetPlayerEffectsForAdventure()));
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventurePreInitialization, adventure);
		return adventure;
	}

	// Token: 0x06001F60 RID: 8032 RVA: 0x000DC9E4 File Offset: 0x000DADE4
	private List<IEncounter> GetEncounters(List<IBattleUnit> playerUnits, Adventure adventure, AdventureLevelConfiguration levelConfig)
	{
		DifficultyLevelMeasurement correspondingDifficultyMeasurement = adventure.CorrespondingDifficultyMeasurement;
		List<AdventureEncounterSlotType> list = new List<AdventureEncounterSlotType>();
		List<IEncounter> list2 = new List<IEncounter>();
		List<EndlessDungeonResolver.UnitStylePresence> presences = new List<EndlessDungeonResolver.UnitStylePresence>
		{
			new EndlessDungeonResolver.UnitStylePresence(UnitClassStyle.PhysicalDefender, 50),
			new EndlessDungeonResolver.UnitStylePresence(UnitClassStyle.PhysicalKiller, 100),
			new EndlessDungeonResolver.UnitStylePresence(UnitClassStyle.PhysicalWarrior, 100),
			new EndlessDungeonResolver.UnitStylePresence(UnitClassStyle.PhysicalSupporter, 50),
			new EndlessDungeonResolver.UnitStylePresence(UnitClassStyle.Protector, 50),
			new EndlessDungeonResolver.UnitStylePresence(UnitClassStyle.SpellWarrior, 100),
			new EndlessDungeonResolver.UnitStylePresence(UnitClassStyle.SpellKiller, 100),
			new EndlessDungeonResolver.UnitStylePresence(UnitClassStyle.SpellDefender, 50),
			new EndlessDungeonResolver.UnitStylePresence(UnitClassStyle.SpellSupporter, 100)
		};
		List<OutputType> allDamageElements = UnitExtensions.GetAllDamageElements();
		for (int i = 0; i < levelConfig.NumberOfRounds - 1; i++)
		{
			for (int j = 0; j < levelConfig.NumberOfMinionsPerRound; j++)
			{
				list.Add(AdventureEncounterSlotType.Minion);
			}
			list.Add(AdventureEncounterSlotType.MiniBoss);
		}
		for (int k = 0; k < levelConfig.NumberOfMinionsPerRound; k++)
		{
			list.Add(AdventureEncounterSlotType.Minion);
		}
		list.Add(AdventureEncounterSlotType.Boss);
		foreach (AdventureEncounterSlotType adventureEncounterSlotType in list)
		{
			int num = UnityEngine.Random.Range(levelConfig.EnemyAmountInBattleFromInclusive, levelConfig.EnemyAmountInBattleToExclusive);
			List<IBattleUnit> list3 = new List<IBattleUnit>();
			if (adventureEncounterSlotType == AdventureEncounterSlotType.Boss)
			{
				if (levelConfig.BossFormations.Any<FormationPresence>())
				{
					FormationPresence formationPresence = levelConfig.BossFormations.WeightedRandomSelect<FormationPresence>();
					foreach (UnitClass unitClass in formationPresence.Minions)
					{
						MonsterAppearance monsterConfig = levelConfig.GetMonsterConfig(unitClass);
						MonsterUnitConfigurationBase monsterUnitConfigurationBase = monsterConfig.UnitClass.GetConfiguration() as MonsterUnitConfigurationBase;
						if (monsterUnitConfigurationBase is BossUnitConfigurationBase)
						{
							monsterUnitConfigurationBase = new EndlessDungeonBossConfiguration(monsterUnitConfigurationBase.CorrespondingUnitClass, presences.WeightedRandomSelect<EndlessDungeonResolver.UnitStylePresence>().Type, new List<ISpecialEffectDataLoad>(), allDamageElements[UnityEngine.Random.Range(0, allDamageElements.Count)]);
						}
						list3.Add(monsterUnitConfigurationBase.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.Minion), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					}
					if (formationPresence.Boss != (UnitClass)0)
					{
						MonsterAppearance monsterConfig2 = levelConfig.GetMonsterConfig(formationPresence.Boss);
						list3.Add(monsterConfig2.UnitClass.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.Boss), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					}
				}
				else
				{
					num--;
					MonsterAppearance monsterAppearance = levelConfig.BossSpawnTable.WeightedRandomSelect<MonsterAppearance>();
					MonsterUnitConfigurationBase monsterUnitConfigurationBase2 = monsterAppearance.UnitClass.GetConfiguration() as MonsterUnitConfigurationBase;
					if (monsterUnitConfigurationBase2 is BossUnitConfigurationBase)
					{
						monsterUnitConfigurationBase2 = new EndlessDungeonBossConfiguration(monsterUnitConfigurationBase2.CorrespondingUnitClass, presences.WeightedRandomSelect<EndlessDungeonResolver.UnitStylePresence>().Type, new List<ISpecialEffectDataLoad>(), allDamageElements[UnityEngine.Random.Range(0, allDamageElements.Count)]);
					}
					list3.Add(monsterUnitConfigurationBase2.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.Boss), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					for (int l = 0; l < num; l++)
					{
						MonsterAppearance monsterAppearance2 = levelConfig.MinionSpawnTable.WeightedRandomSelect<MonsterAppearance>();
						list3.Add(monsterAppearance2.UnitClass.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.Minion), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					}
				}
			}
			if (adventureEncounterSlotType == AdventureEncounterSlotType.MiniBoss)
			{
				if (levelConfig.MiniBossFormation != null && levelConfig.MiniBossFormation.Any<FormationPresence>())
				{
					FormationPresence formationPresence2 = levelConfig.MiniBossFormation.WeightedRandomSelect<FormationPresence>();
					foreach (UnitClass unitClass2 in formationPresence2.Minions)
					{
						MonsterUnitConfigurationBase monsterUnitConfigurationBase3 = levelConfig.GetMonsterConfig(unitClass2).UnitClass.GetConfiguration() as MonsterUnitConfigurationBase;
						if (monsterUnitConfigurationBase3 is MiniBossUnitConfigurationBase)
						{
							monsterUnitConfigurationBase3 = new EndlessDungeonMinibossConfiguration(monsterUnitConfigurationBase3.CorrespondingUnitClass, presences.WeightedRandomSelect<EndlessDungeonResolver.UnitStylePresence>().Type, new List<ISpecialEffectDataLoad>(), allDamageElements[UnityEngine.Random.Range(0, allDamageElements.Count)]);
						}
						list3.Add(monsterUnitConfigurationBase3.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.Minion), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					}
					if (formationPresence2.Boss != (UnitClass)0)
					{
						MonsterAppearance monsterConfig3 = levelConfig.GetMonsterConfig(formationPresence2.Boss);
						list3.Add(monsterConfig3.UnitClass.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.MiniBoss), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					}
				}
				else
				{
					num--;
					MonsterUnitConfigurationBase monsterUnitConfigurationBase4 = levelConfig.MiniBossSpawnTable.WeightedRandomSelect<MonsterAppearance>().UnitClass.GetConfiguration() as MonsterUnitConfigurationBase;
					if (monsterUnitConfigurationBase4 is MiniBossUnitConfigurationBase)
					{
						monsterUnitConfigurationBase4 = new EndlessDungeonMinibossConfiguration(monsterUnitConfigurationBase4.CorrespondingUnitClass, presences.WeightedRandomSelect<EndlessDungeonResolver.UnitStylePresence>().Type, new List<ISpecialEffectDataLoad>(), allDamageElements[UnityEngine.Random.Range(0, allDamageElements.Count)]);
					}
					list3.Add(monsterUnitConfigurationBase4.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.MiniBoss), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					for (int m = 0; m < num; m++)
					{
						MonsterAppearance monsterAppearance3 = levelConfig.MinionSpawnTable.WeightedRandomSelect<MonsterAppearance>();
						list3.Add(monsterAppearance3.UnitClass.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.Minion), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					}
				}
			}
			if (adventureEncounterSlotType == AdventureEncounterSlotType.Minion)
			{
				if (levelConfig.MinionFormation != null && levelConfig.MinionFormation.Any<FormationPresence>())
				{
					FormationPresence formationPresence3 = levelConfig.MinionFormation.WeightedRandomSelect<FormationPresence>();
					foreach (UnitClass unitClass3 in formationPresence3.Minions)
					{
						MonsterAppearance monsterConfig4 = levelConfig.GetMonsterConfig(unitClass3);
						list3.Add(monsterConfig4.UnitClass.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.Minion), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					}
				}
				else
				{
					for (int n = 0; n < num; n++)
					{
						MonsterAppearance monsterAppearance4 = levelConfig.MinionSpawnTable.WeightedRandomSelect<MonsterAppearance>();
						list3.Add(monsterAppearance4.UnitClass.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.Minion), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					}
				}
			}
			list2.Add(new BattleEncounter(playerUnits, list3, adventure));
		}
		return list2;
	}

	// Token: 0x06001F61 RID: 8033 RVA: 0x000DD0DC File Offset: 0x000DB4DC
	public override int ResolverPrecedenceValue()
	{
		return 100;
	}

	// Token: 0x06001F62 RID: 8034 RVA: 0x000DD0E0 File Offset: 0x000DB4E0
	[CompilerGenerated]
	private static MonsterAppearance <ResolveLogic>m__0(UnitClass b)
	{
		return new MonsterAppearance(100, b);
	}

	// Token: 0x06001F63 RID: 8035 RVA: 0x000DD0EA File Offset: 0x000DB4EA
	[CompilerGenerated]
	private static MonsterAppearance <ResolveLogic>m__1(UnitClass b)
	{
		return new MonsterAppearance(100, b);
	}

	// Token: 0x06001F64 RID: 8036 RVA: 0x000DD0F4 File Offset: 0x000DB4F4
	[CompilerGenerated]
	private static MonsterAppearance <ResolveLogic>m__2(UnitClass b)
	{
		return new MonsterAppearance(100, b);
	}

	// Token: 0x06001F65 RID: 8037 RVA: 0x000DD0FE File Offset: 0x000DB4FE
	[CompilerGenerated]
	private static IEnumerable<ISpecialEffectDataLoad> <InitializeAdventureBaseOnLevel>m__3(ResourceType c)
	{
		return c.GetCreationTemplate().GetNormalLevelSpecialEffectDataLoads(QualityGrade.Normal);
	}

	// Token: 0x06001F66 RID: 8038 RVA: 0x000DD10C File Offset: 0x000DB50C
	[CompilerGenerated]
	private static IEnumerable<ISpecialEffectDataLoad> <InitializeAdventureBaseOnLevel>m__4(TownEffectBase ef)
	{
		return ef.GetPlayerEffectsForAdventure();
	}

	// Token: 0x04001C4C RID: 7244
	[CompilerGenerated]
	private static Func<UnitClass, MonsterAppearance> <>f__am$cache0;

	// Token: 0x04001C4D RID: 7245
	[CompilerGenerated]
	private static Func<UnitClass, MonsterAppearance> <>f__am$cache1;

	// Token: 0x04001C4E RID: 7246
	[CompilerGenerated]
	private static Func<UnitClass, MonsterAppearance> <>f__am$cache2;

	// Token: 0x04001C4F RID: 7247
	[CompilerGenerated]
	private static Func<ResourceType, IEnumerable<ISpecialEffectDataLoad>> <>f__am$cache3;

	// Token: 0x04001C50 RID: 7248
	[CompilerGenerated]
	private static Func<TownEffectBase, IEnumerable<ISpecialEffectDataLoad>> <>f__am$cache4;

	// Token: 0x02000453 RID: 1107
	private class UnitStylePresence : IPresentable
	{
		// Token: 0x06001F67 RID: 8039 RVA: 0x000DD114 File Offset: 0x000DB514
		public UnitStylePresence(UnitClassStyle type, int presence)
		{
			this.Type = type;
			this.Presence = presence;
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06001F68 RID: 8040 RVA: 0x000DD12A File Offset: 0x000DB52A
		// (set) Token: 0x06001F69 RID: 8041 RVA: 0x000DD132 File Offset: 0x000DB532
		public UnitClassStyle Type
		{
			[CompilerGenerated]
			get
			{
				return this.<Type>k__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				this.<Type>k__BackingField = value;
			}
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06001F6B RID: 8043 RVA: 0x000DD144 File Offset: 0x000DB544
		// (set) Token: 0x06001F6A RID: 8042 RVA: 0x000DD13B File Offset: 0x000DB53B
		public int Presence
		{
			[CompilerGenerated]
			get
			{
				return this.<Presence>k__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				this.<Presence>k__BackingField = value;
			}
		}

		// Token: 0x06001F6C RID: 8044 RVA: 0x000DD14C File Offset: 0x000DB54C
		public int GetPresence()
		{
			return this.Presence;
		}

		// Token: 0x04001C51 RID: 7249
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private UnitClassStyle <Type>k__BackingField;

		// Token: 0x04001C52 RID: 7250
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int <Presence>k__BackingField;
	}

	// Token: 0x02000D14 RID: 3348
	[CompilerGenerated]
	private sealed class <ResolveLogic>c__AnonStorey0
	{
		// Token: 0x060055F1 RID: 22001 RVA: 0x000DD154 File Offset: 0x000DB554
		public <ResolveLogic>c__AnonStorey0()
		{
		}

		// Token: 0x060055F2 RID: 22002 RVA: 0x000DD15C File Offset: 0x000DB55C
		internal bool <>m__0(UnitClass m)
		{
			return this.excludedMinions.All((UnitClass e) => e != m);
		}

		// Token: 0x0400447B RID: 17531
		internal List<UnitClass> excludedMinions;

		// Token: 0x02000D16 RID: 3350
		private sealed class <ResolveLogic>c__AnonStorey1
		{
			// Token: 0x060055F5 RID: 22005 RVA: 0x000DD194 File Offset: 0x000DB594
			public <ResolveLogic>c__AnonStorey1()
			{
			}

			// Token: 0x060055F6 RID: 22006 RVA: 0x000DD19C File Offset: 0x000DB59C
			internal bool <>m__0(UnitClass e)
			{
				return e != this.m;
			}

			// Token: 0x0400447D RID: 17533
			internal UnitClass m;

			// Token: 0x0400447E RID: 17534
			internal EndlessDungeonResolver.<ResolveLogic>c__AnonStorey0 <>f__ref$0;
		}
	}

	// Token: 0x02000D15 RID: 3349
	[CompilerGenerated]
	private sealed class <InitializeAdventureBaseOnLevel>c__AnonStorey2
	{
		// Token: 0x060055F3 RID: 22003 RVA: 0x000DD1AA File Offset: 0x000DB5AA
		public <InitializeAdventureBaseOnLevel>c__AnonStorey2()
		{
		}

		// Token: 0x060055F4 RID: 22004 RVA: 0x000DD1B2 File Offset: 0x000DB5B2
		internal AdventurerBattleUnit <>m__0(AdventurerProfile a)
		{
			return AdventurerBattleUnit.InitializeAdventurerBattleUnit(a, this.adventure);
		}

		// Token: 0x0400447C RID: 17532
		internal Adventure adventure;
	}
}
