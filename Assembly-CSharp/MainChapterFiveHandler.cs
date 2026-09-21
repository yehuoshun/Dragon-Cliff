using System;
using System.Collections.Generic;

// Token: 0x020004C9 RID: 1225
public class MainChapterFiveHandler : MainQuestHandlerBase
{
	// Token: 0x060024C1 RID: 9409 RVA: 0x0010B162 File Offset: 0x00109562
	public MainChapterFiveHandler()
	{
	}

	// Token: 0x17000278 RID: 632
	// (get) Token: 0x060024C2 RID: 9410 RVA: 0x0010B172 File Offset: 0x00109572
	public override QuestChainIdentifier ChainIdentifier
	{
		get
		{
			return this._chainIdentifier;
		}
	}

	// Token: 0x060024C3 RID: 9411 RVA: 0x0010B17A File Offset: 0x0010957A
	public override void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		MainChapterFiveHandler.Main51(evt, data);
		MainChapterFiveHandler.Main52(evt, data);
		MainChapterFiveHandler.Main53(evt, data);
	}

	// Token: 0x060024C4 RID: 9412 RVA: 0x0010B194 File Offset: 0x00109594
	private static void Main51(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main4_2)
			{
				GameWorld.instance.PlayerProfile.EnableDungeonRecord(AdventureType.HellishPath);
				AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.HellishPath.GetAdventureLevelConfiguration(10).NakedDuplicate();
				adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
				{
					new MonsterAppearance(100, UnitClass.Golem)
				};
				adventureLevelConfiguration.NumberOfRounds = 3;
				adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 5;
				adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
				adventureLevelConfiguration.NumberOfMinionsPerRound = 2;
				adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>();
				adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
				double value = 65.0;
				Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main5_1, new List<QuestRewardBase>
				{
					GuaranteedDirectResourceReward.CreateDirectResourceReward(18000.0, ResourceType.Money, 1, null),
					GuaranteedDirectResourceReward.CreateDirectResourceReward(10000.0, ResourceType.PracticePoints, 1, null)
				}, new List<QuestRequirementBase>
				{
					new CustomizedDungeonThroughRequirementLogic
					{
						fullfilled = false,
						DungeonType = AdventureType.HellishPath,
						Configuration = adventureLevelConfiguration,
						DifficultyMeasurement = new double?(value),
						IsTwistedTimeDungeon = false
					}
				});
				GameWorld.instance.PlayerProfile.AddQuest(quest);
			}
		}
	}

	// Token: 0x060024C5 RID: 9413 RVA: 0x0010B30C File Offset: 0x0010970C
	private static void Main52(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main5_1)
			{
				AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.HellishPath.GetAdventureLevelConfiguration(20).NakedDuplicate();
				adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>();
				adventureLevelConfiguration.BossFormations = new List<FormationPresence>
				{
					new FormationPresence
					{
						Presence = 100,
						Minions = new List<UnitClass>
						{
							UnitClass.IceMage,
							UnitClass.IceMage,
							UnitClass.IceMage,
							UnitClass.IceMage,
							UnitClass.IceMage,
							UnitClass.Hydra
						}
					}
				};
				adventureLevelConfiguration.NumberOfRounds = 3;
				adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 5;
				adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
				adventureLevelConfiguration.NumberOfMinionsPerRound = 2;
				adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>();
				adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
				double value = 75.0;
				Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main5_2, new List<QuestRewardBase>
				{
					GuaranteedDirectResourceReward.CreateDirectResourceReward(20000.0, ResourceType.Money, 1, null),
					GuaranteedDirectResourceReward.CreateDirectResourceReward(12000.0, ResourceType.PracticePoints, 1, null)
				}, new List<QuestRequirementBase>
				{
					new CustomizedDungeonThroughRequirementLogic
					{
						fullfilled = false,
						DungeonType = AdventureType.HellishPath,
						Configuration = adventureLevelConfiguration,
						DifficultyMeasurement = new double?(value),
						IsTwistedTimeDungeon = false
					}
				});
				GameWorld.instance.PlayerProfile.AddQuest(quest);
			}
		}
	}

	// Token: 0x060024C6 RID: 9414 RVA: 0x0010B4DC File Offset: 0x001098DC
	private static void Main53(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main5_2)
			{
				MainChapterFiveHandler.AddQuest53();
			}
		}
	}

	// Token: 0x060024C7 RID: 9415 RVA: 0x0010B51C File Offset: 0x0010991C
	public static void AddQuest53()
	{
		AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.HellishPath.GetAdventureLevelConfiguration(27).NakedDuplicate();
		adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.DemonDragon)
		};
		adventureLevelConfiguration.NumberOfRounds = 3;
		adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 5;
		adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
		adventureLevelConfiguration.NumberOfMinionsPerRound = 2;
		adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>();
		adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
		double value = 82.0;
		Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main5_3, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(25000.0, ResourceType.Money, 1, null),
			GuaranteedDirectResourceReward.CreateDirectResourceReward(15000.0, ResourceType.PracticePoints, 1, null)
		}, new List<QuestRequirementBase>
		{
			new CustomizedDungeonThroughRequirementLogic
			{
				fullfilled = false,
				DungeonType = AdventureType.HellishPath,
				Configuration = adventureLevelConfiguration,
				DifficultyMeasurement = new double?(value),
				IsTwistedTimeDungeon = false
			}
		});
		GameWorld.instance.PlayerProfile.AddQuest(quest);
	}

	// Token: 0x04001FAB RID: 8107
	private QuestChainIdentifier _chainIdentifier = QuestChainIdentifier.MainChapterFive;
}
