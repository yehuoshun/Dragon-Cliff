using System;
using System.Collections.Generic;

// Token: 0x020004D6 RID: 1238
public class Side5QuestHandler : StaticSideQuestHandlerBase
{
	// Token: 0x0600252F RID: 9519 RVA: 0x0010F5A0 File Offset: 0x0010D9A0
	public Side5QuestHandler()
	{
	}

	// Token: 0x17000284 RID: 644
	// (get) Token: 0x06002530 RID: 9520 RVA: 0x0010F5A8 File Offset: 0x0010D9A8
	public override QuestChainIdentifier ChainIdentifier
	{
		get
		{
			return QuestChainIdentifier.PortOpen;
		}
	}

	// Token: 0x06002531 RID: 9521 RVA: 0x0010F5AC File Offset: 0x0010D9AC
	public override void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		if ((evt == GameWorldEvent.GameDaysChanged || evt == GameWorldEvent.ReputationIncreased) && GameWorld.instance.PlayerProfile.GetProgress(null).Reputation >= 10000.0 && !QuestIdentifier.Side_5.QuestHasBeenIssued(GameWorld.instance.PlayerProfile.GetStarRating()))
		{
			Side5QuestHandler.AddSide5();
		}
	}

	// Token: 0x06002532 RID: 9522 RVA: 0x0010F614 File Offset: 0x0010DA14
	private static void AddSide5()
	{
		AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.MistForest.GetAdventureLevelConfiguration(1).NakedDuplicate();
		adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.FireMage)
		};
		adventureLevelConfiguration.NumberOfRounds = 5;
		adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 6;
		adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
		adventureLevelConfiguration.NumberOfMinionsPerRound = 1;
		adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>();
		adventureLevelConfiguration.BossFormations = new List<FormationPresence>();
		adventureLevelConfiguration.MiniBossFormation = new List<FormationPresence>();
		adventureLevelConfiguration.MinionFormation = new List<FormationPresence>();
		adventureLevelConfiguration.MiniBossSpawnTable = new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.RedIceBeast),
			new MonsterAppearance(100, UnitClass.PurpleIceBeast)
		};
		adventureLevelConfiguration.MinionSpawnTable = new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.IceBeast)
		};
		adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
		Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Side_5, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(10000.0, ResourceType.Money, 1, null),
			GuaranteedDirectResourceReward.CreateDirectResourceReward(10000.0, ResourceType.PracticePoints, 1, null)
		}, new List<QuestRequirementBase>
		{
			new CustomizedDungeonThroughRequirementLogic
			{
				fullfilled = false,
				DungeonType = AdventureType.RoyalWaterFall,
				Configuration = adventureLevelConfiguration,
				DifficultyMeasurement = new double?(105.0),
				IsTwistedTimeDungeon = true
			}
		});
		GameWorld.instance.PlayerProfile.AddQuest(quest);
	}
}
