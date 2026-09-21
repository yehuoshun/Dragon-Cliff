using System;
using System.Collections.Generic;

// Token: 0x020004D7 RID: 1239
public class Side6QuestHandler : StaticSideQuestHandlerBase
{
	// Token: 0x06002533 RID: 9523 RVA: 0x0010F7B9 File Offset: 0x0010DBB9
	public Side6QuestHandler()
	{
	}

	// Token: 0x17000285 RID: 645
	// (get) Token: 0x06002534 RID: 9524 RVA: 0x0010F7C1 File Offset: 0x0010DBC1
	public override QuestChainIdentifier ChainIdentifier
	{
		get
		{
			return QuestChainIdentifier.SchoolLevel3;
		}
	}

	// Token: 0x06002535 RID: 9525 RVA: 0x0010F7C8 File Offset: 0x0010DBC8
	public override void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.GameDaysChanged && GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main5_3, GameWorld.instance.PlayerProfile.GetStarRating()) && !QuestIdentifier.Side_6.QuestHasBeenIssued(GameWorld.instance.PlayerProfile.GetStarRating()))
		{
			AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.BuriedTemple.GetAdventureLevelConfiguration(8).NakedDuplicate();
			adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
			{
				new MonsterAppearance(100, UnitClass.Trainer)
			};
			adventureLevelConfiguration.NumberOfRounds = 5;
			adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 6;
			adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
			adventureLevelConfiguration.NumberOfMinionsPerRound = 2;
			adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>();
			adventureLevelConfiguration.BossFormations = new List<FormationPresence>();
			adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
			Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Side_6, new List<QuestRewardBase>
			{
				GuaranteedDirectResourceReward.CreateDirectResourceReward(20000.0, ResourceType.Money, 1, null),
				GuaranteedDirectResourceReward.CreateDirectResourceReward(20000.0, ResourceType.PracticePoints, 1, null)
			}, new List<QuestRequirementBase>
			{
				new CustomizedDungeonThroughRequirementLogic
				{
					fullfilled = false,
					DungeonType = AdventureType.ShadowPath,
					Configuration = adventureLevelConfiguration,
					DifficultyMeasurement = new double?(130.0),
					IsTwistedTimeDungeon = true
				}
			});
			GameWorld.instance.PlayerProfile.AddQuest(quest);
		}
	}
}
