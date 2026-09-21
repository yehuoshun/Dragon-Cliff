using System;
using System.Collections.Generic;

// Token: 0x020004CD RID: 1229
public class MainChapterTwoHandler : MainQuestHandlerBase
{
	// Token: 0x060024E5 RID: 9445 RVA: 0x0010CDD1 File Offset: 0x0010B1D1
	public MainChapterTwoHandler()
	{
	}

	// Token: 0x1700027C RID: 636
	// (get) Token: 0x060024E6 RID: 9446 RVA: 0x0010CDE0 File Offset: 0x0010B1E0
	public override QuestChainIdentifier ChainIdentifier
	{
		get
		{
			return this._chainIdentifier;
		}
	}

	// Token: 0x060024E7 RID: 9447 RVA: 0x0010CDE8 File Offset: 0x0010B1E8
	public override void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		MainChapterTwoHandler.Main21(evt, data);
		MainChapterTwoHandler.Main22(evt, data);
		MainChapterTwoHandler.Main24(evt, data);
		MainChapterTwoHandler.Main25(evt, data);
	}

	// Token: 0x060024E8 RID: 9448 RVA: 0x0010CE08 File Offset: 0x0010B208
	private static void Main21(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main1_7)
			{
				MainChapterTwoHandler.AddQuest21();
			}
		}
	}

	// Token: 0x060024E9 RID: 9449 RVA: 0x0010CE48 File Offset: 0x0010B248
	public static void AddQuest21()
	{
		GameWorld.instance.PlayerProfile.EnableDungeonRecord(AdventureType.MistForest);
		AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.MistForest.GetAdventureLevelConfiguration(5).NakedDuplicate();
		adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.Pharmacist)
		};
		adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 5;
		adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
		adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
		double value = 15.5;
		Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main2_1, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(4000.0, ResourceType.Money, 1, null),
			GuaranteedDirectResourceReward.CreateDirectResourceReward(2500.0, ResourceType.PracticePoints, 1, null)
		}, new List<QuestRequirementBase>
		{
			new CustomizedDungeonThroughRequirementLogic
			{
				fullfilled = false,
				DungeonType = AdventureType.MistForest,
				Configuration = adventureLevelConfiguration,
				DifficultyMeasurement = new double?(value),
				IsTwistedTimeDungeon = false
			}
		});
		GameWorld.instance.PlayerProfile.AddQuest(quest);
	}

	// Token: 0x060024EA RID: 9450 RVA: 0x0010CF78 File Offset: 0x0010B378
	public static void Main22(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main2_1)
			{
				MainChapterTwoHandler.AddQuest22();
			}
		}
	}

	// Token: 0x060024EB RID: 9451 RVA: 0x0010CFB8 File Offset: 0x0010B3B8
	public static void AddQuest22()
	{
		AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.MistForest.GetAdventureLevelConfiguration(11).NakedDuplicate();
		adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.DemonSkull)
		};
		adventureLevelConfiguration.NumberOfRounds = 3;
		adventureLevelConfiguration.NumberOfMinionsPerRound = 2;
		adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 5;
		adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 6;
		adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>
		{
			new PoisonMistData
			{
				Chance = 0.1,
				DamageType = OutputType.Poison,
				LastingSeconds = 10f,
				DamageValue = 15.0
			}
		};
		adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
		double value = 21.0;
		Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main2_2, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(4000.0, ResourceType.Money, 1, null),
			GuaranteedDirectResourceReward.CreateDirectResourceReward(3000.0, ResourceType.PracticePoints, 1, null)
		}, new List<QuestRequirementBase>
		{
			new CustomizedDungeonThroughRequirementLogic
			{
				fullfilled = false,
				DungeonType = AdventureType.MistForest,
				Configuration = adventureLevelConfiguration,
				DifficultyMeasurement = new double?(value),
				IsTwistedTimeDungeon = false
			}
		});
		GameWorld.instance.PlayerProfile.AddQuest(quest);
	}

	// Token: 0x060024EC RID: 9452 RVA: 0x0010D134 File Offset: 0x0010B534
	private static void Main24(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main2_2)
			{
				GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
				{
					new ResourceUpdate
					{
						ResourceType = ResourceType.ForgingFacilityPermit,
						ChangeAmount = 1.0,
						RelatedItems = new List<Item>()
					}
				});
				MainChapterTwoHandler.AddQuest24();
			}
		}
	}

	// Token: 0x060024ED RID: 9453 RVA: 0x0010D1BC File Offset: 0x0010B5BC
	public static void AddQuest24()
	{
		Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main2_4, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(4000.0, ResourceType.Money, 1, null)
		}, new List<QuestRequirementBase>
		{
			new ItemCombineRequirementLogic
			{
				FFilled = false,
				RequiredAmount = 1,
				AmountSoFar = 0
			}
		});
		GameWorld.instance.PlayerProfile.AddQuest(quest);
	}

	// Token: 0x060024EE RID: 9454 RVA: 0x0010D23C File Offset: 0x0010B63C
	private static void Main25(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main2_4)
			{
				MainChapterTwoHandler.AddQuest25();
			}
		}
	}

	// Token: 0x060024EF RID: 9455 RVA: 0x0010D27C File Offset: 0x0010B67C
	public static void AddQuest25()
	{
		AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.SnowMountain.GetAdventureLevelConfiguration(15).NakedDuplicate();
		adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.CorruptedHorn)
		};
		adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 5;
		adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
		adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
		double value = 35.0;
		Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main2_5, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(5000.0, ResourceType.Money, 1, null),
			GuaranteedDirectResourceReward.CreateDirectResourceReward(3000.0, ResourceType.PracticePoints, 1, null)
		}, new List<QuestRequirementBase>
		{
			new CustomizedDungeonThroughRequirementLogic
			{
				fullfilled = false,
				DungeonType = AdventureType.SnowMountain,
				Configuration = adventureLevelConfiguration,
				DifficultyMeasurement = new double?(value),
				IsTwistedTimeDungeon = false
			}
		});
		GameWorld.instance.PlayerProfile.AddQuest(quest);
	}

	// Token: 0x04001FAF RID: 8111
	private QuestChainIdentifier _chainIdentifier = QuestChainIdentifier.MainChapterTwo;
}
