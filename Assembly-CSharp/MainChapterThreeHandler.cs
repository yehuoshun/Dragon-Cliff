using System;
using System.Collections.Generic;

// Token: 0x020004CC RID: 1228
public class MainChapterThreeHandler : MainQuestHandlerBase
{
	// Token: 0x060024DF RID: 9439 RVA: 0x0010CA4F File Offset: 0x0010AE4F
	public MainChapterThreeHandler()
	{
	}

	// Token: 0x1700027B RID: 635
	// (get) Token: 0x060024E0 RID: 9440 RVA: 0x0010CA5E File Offset: 0x0010AE5E
	public override QuestChainIdentifier ChainIdentifier
	{
		get
		{
			return this._chainIdentifier;
		}
	}

	// Token: 0x060024E1 RID: 9441 RVA: 0x0010CA66 File Offset: 0x0010AE66
	public override void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		MainChapterThreeHandler.Main31(evt, data);
		MainChapterThreeHandler.Main32(evt, data);
	}

	// Token: 0x060024E2 RID: 9442 RVA: 0x0010CA78 File Offset: 0x0010AE78
	private static void Main31(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main2_2)
			{
				GameWorld.instance.PlayerProfile.EnableDungeonRecord(AdventureType.SnowMountain);
				AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.SnowMountain.GetAdventureLevelConfiguration(8).NakedDuplicate();
				adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
				{
					new MonsterAppearance(100, UnitClass.GreedyMouth)
				};
				adventureLevelConfiguration.NumberOfRounds = 4;
				adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 5;
				adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
				adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>
				{
					new DungeonScaleUndeadEffectData
					{
						RevivedUnitsInCurrentEncounter = new List<IBattleUnit>(),
						ReviveRate = 1.0
					}
				};
				adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
				double value = 28.0;
				Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main3_1, new List<QuestRewardBase>
				{
					GuaranteedDirectResourceReward.CreateDirectResourceReward(6000.0, ResourceType.Money, 1, null),
					GuaranteedDirectResourceReward.CreateDirectResourceReward(3500.0, ResourceType.PracticePoints, 1, null)
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
		}
	}

	// Token: 0x060024E3 RID: 9443 RVA: 0x0010CC18 File Offset: 0x0010B018
	private static void Main32(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main3_1)
			{
				GameWorld.instance.PlayerProfile.EnableDungeonRecord(AdventureType.SnowMountain);
				MainChapterThreeHandler.AddQuest32();
			}
		}
	}

	// Token: 0x060024E4 RID: 9444 RVA: 0x0010CC68 File Offset: 0x0010B068
	public static void AddQuest32()
	{
		AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.SnowMountain.GetAdventureLevelConfiguration(20).NakedDuplicate();
		adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.Death)
		};
		adventureLevelConfiguration.NumberOfRounds = 2;
		adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 5;
		adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
		adventureLevelConfiguration.NumberOfMinionsPerRound = 2;
		adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>
		{
			new DarknessData
			{
				MonsterDepression = 0.5,
				HealDepression = 0.5
			}
		};
		adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
		double value = 40.0;
		Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main3_2, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(8000.0, ResourceType.Money, 1, null),
			GuaranteedDirectResourceReward.CreateDirectResourceReward(4500.0, ResourceType.PracticePoints, 1, null)
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

	// Token: 0x04001FAE RID: 8110
	private readonly QuestChainIdentifier _chainIdentifier = QuestChainIdentifier.MainChapterThree;
}
