using System;
using System.Collections.Generic;

// Token: 0x020004D9 RID: 1241
public class Side8QuestHandler : StaticSideQuestHandlerBase
{
	// Token: 0x0600253C RID: 9532 RVA: 0x0010FD94 File Offset: 0x0010E194
	public Side8QuestHandler()
	{
	}

	// Token: 0x17000287 RID: 647
	// (get) Token: 0x0600253D RID: 9533 RVA: 0x0010FD9C File Offset: 0x0010E19C
	public override QuestChainIdentifier ChainIdentifier
	{
		get
		{
			return QuestChainIdentifier.Rebels;
		}
	}

	// Token: 0x0600253E RID: 9534 RVA: 0x0010FDA0 File Offset: 0x0010E1A0
	public override void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.JourneyCompleted && !QuestIdentifier.Side_8_p1.QuestHasBeenIssued(GameWorld.instance.PlayerProfile.GetStarRating()))
		{
			GameWorld.instance.PlayerProfile.EnableDungeonRecord(AdventureType.NorthernTerritory);
			Side8QuestHandler.AddSide8p1();
		}
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Side_8_p1)
			{
				Side8QuestHandler.AddSide8p2();
			}
		}
	}

	// Token: 0x0600253F RID: 9535 RVA: 0x0010FE18 File Offset: 0x0010E218
	public static void AddSide8p2()
	{
		AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.NorthernTerritory.GetAdventureLevelConfiguration(20).NakedDuplicate();
		adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.Nameless)
		};
		adventureLevelConfiguration.NumberOfRounds = 3;
		adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 6;
		adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
		adventureLevelConfiguration.NumberOfMinionsPerRound = 2;
		adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>();
		adventureLevelConfiguration.BossFormations = new List<FormationPresence>();
		adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
		Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Side_8_p2, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(80000.0, ResourceType.PracticePoints, 1, null)
		}, new List<QuestRequirementBase>
		{
			new CustomizedDungeonThroughRequirementLogic
			{
				fullfilled = false,
				DungeonType = AdventureType.NorthernTerritory,
				Configuration = adventureLevelConfiguration,
				DifficultyMeasurement = new double?(160.0),
				IsTwistedTimeDungeon = false
			}
		});
		GameWorld.instance.PlayerProfile.AddQuest(quest);
	}

	// Token: 0x06002540 RID: 9536 RVA: 0x0010FF34 File Offset: 0x0010E334
	public static void AddSide8p1()
	{
		AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.NorthernTerritory.GetAdventureLevelConfiguration(10).NakedDuplicate();
		adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.ThugLeaderBoss)
		};
		adventureLevelConfiguration.NumberOfRounds = 3;
		adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 6;
		adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
		adventureLevelConfiguration.NumberOfMinionsPerRound = 2;
		adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>();
		adventureLevelConfiguration.BossFormations = new List<FormationPresence>();
		adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
		Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Side_8_p1, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(50000.0, ResourceType.PracticePoints, 1, null)
		}, new List<QuestRequirementBase>
		{
			new CustomizedDungeonThroughRequirementLogic
			{
				fullfilled = false,
				DungeonType = AdventureType.NorthernTerritory,
				Configuration = adventureLevelConfiguration,
				DifficultyMeasurement = new double?(150.0),
				IsTwistedTimeDungeon = false
			}
		});
		GameWorld.instance.PlayerProfile.AddQuest(quest);
	}
}
