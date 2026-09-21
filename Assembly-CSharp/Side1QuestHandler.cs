using System;
using System.Collections.Generic;

// Token: 0x020004D2 RID: 1234
public class Side1QuestHandler : StaticSideQuestHandlerBase
{
	// Token: 0x0600250D RID: 9485 RVA: 0x0010DD8E File Offset: 0x0010C18E
	public Side1QuestHandler()
	{
	}

	// Token: 0x17000280 RID: 640
	// (get) Token: 0x0600250E RID: 9486 RVA: 0x0010DD96 File Offset: 0x0010C196
	public override QuestChainIdentifier ChainIdentifier
	{
		get
		{
			return QuestChainIdentifier.PrincessOfLu;
		}
	}

	// Token: 0x0600250F RID: 9487 RVA: 0x0010DD9C File Offset: 0x0010C19C
	public override void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		bool flag = false;
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main4_1)
			{
				flag = true;
			}
		}
		if (evt == GameWorldEvent.GameDaysChanged && !QuestIdentifier.Side_1_p1.QuestHasBeenIssued(GameWorld.instance.PlayerProfile.GetStarRating()) && GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main4_1, GameWorld.instance.PlayerProfile.GetStarRating()))
		{
			flag = true;
		}
		if (flag)
		{
			Side1QuestHandler.AddSide1P1();
		}
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent2 = data as QuestCompletedEvent;
			if (questCompletedEvent2.Quest.QuestIdentifier == QuestIdentifier.Side_1_p1)
			{
				Side1QuestHandler.AddSide1P2();
			}
			if (questCompletedEvent2.Quest.QuestIdentifier == QuestIdentifier.Side_1_p2)
			{
				Side1QuestHandler.AddSide1P3();
			}
			if (questCompletedEvent2.Quest.QuestIdentifier == QuestIdentifier.Side_1_p3)
			{
				AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.ImperialMausoleum.GetAdventureLevelConfiguration(1).NakedDuplicate();
				adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
				{
					new MonsterAppearance(100, UnitClass.Puppet)
				};
				adventureLevelConfiguration.BossFormations = new List<FormationPresence>
				{
					new FormationPresence
					{
						Presence = 100,
						Minions = new List<UnitClass>
						{
							UnitClass.RedMask,
							UnitClass.RedMask,
							UnitClass.RedMask,
							UnitClass.RedMask,
							UnitClass.RedMask,
							UnitClass.RedMask,
							UnitClass.Puppet
						}
					}
				};
				adventureLevelConfiguration.NumberOfRounds = 5;
				adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 6;
				adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
				adventureLevelConfiguration.NumberOfMinionsPerRound = 2;
				adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>();
				adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
				Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Side_1_p4, new List<QuestRewardBase>
				{
					GuaranteedDirectResourceReward.CreateDirectResourceReward(20000.0, ResourceType.Money, 1, null),
					GuaranteedDirectResourceReward.CreateDirectResourceReward(20000.0, ResourceType.PracticePoints, 1, null)
				}, new List<QuestRequirementBase>
				{
					new CustomizedDungeonThroughRequirementLogic
					{
						fullfilled = false,
						DungeonType = AdventureType.SilientPalace,
						Configuration = adventureLevelConfiguration,
						DifficultyMeasurement = new double?(120.0),
						IsTwistedTimeDungeon = true
					}
				});
				GameWorld.instance.PlayerProfile.AddQuest(quest);
			}
		}
	}

	// Token: 0x06002510 RID: 9488 RVA: 0x0010E040 File Offset: 0x0010C440
	private static void AddSide1P3()
	{
		AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.BuriedTemple.GetAdventureLevelConfiguration(8).NakedDuplicate();
		adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.YellowHeartEater)
		};
		adventureLevelConfiguration.BossFormations = new List<FormationPresence>();
		adventureLevelConfiguration.NumberOfRounds = 5;
		adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 6;
		adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
		adventureLevelConfiguration.NumberOfMinionsPerRound = 2;
		adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>();
		adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
		Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Side_1_p3, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(15000.0, ResourceType.Money, 1, null),
			GuaranteedDirectResourceReward.CreateDirectResourceReward(15000.0, ResourceType.PracticePoints, 1, null)
		}, new List<QuestRequirementBase>
		{
			new CustomizedDungeonThroughRequirementLogic
			{
				fullfilled = false,
				DungeonType = AdventureType.BuriedTemple,
				Configuration = adventureLevelConfiguration,
				DifficultyMeasurement = new double?(85.0),
				IsTwistedTimeDungeon = false
			}
		});
		GameWorld.instance.PlayerProfile.AddQuest(quest);
	}

	// Token: 0x06002511 RID: 9489 RVA: 0x0010E180 File Offset: 0x0010C580
	private static void AddSide1P2()
	{
		AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.MistForest.GetAdventureLevelConfiguration(8).NakedDuplicate();
		adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.RedHeartEater)
		};
		adventureLevelConfiguration.NumberOfRounds = 5;
		adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 6;
		adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
		adventureLevelConfiguration.NumberOfMinionsPerRound = 2;
		adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>();
		adventureLevelConfiguration.BossFormations = new List<FormationPresence>();
		adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
		Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Side_1_p2, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(10000.0, ResourceType.Money, 1, null),
			GuaranteedDirectResourceReward.CreateDirectResourceReward(10000.0, ResourceType.PracticePoints, 1, null)
		}, new List<QuestRequirementBase>
		{
			new CustomizedDungeonThroughRequirementLogic
			{
				fullfilled = false,
				DungeonType = AdventureType.MistForest,
				Configuration = adventureLevelConfiguration,
				DifficultyMeasurement = new double?(75.0),
				IsTwistedTimeDungeon = false
			}
		});
		GameWorld.instance.PlayerProfile.AddQuest(quest);
	}

	// Token: 0x06002512 RID: 9490 RVA: 0x0010E2C0 File Offset: 0x0010C6C0
	private static void AddSide1P1()
	{
		AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.WoodenForest.GetAdventureLevelConfiguration(8).NakedDuplicate();
		adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.BlueHeartEater)
		};
		adventureLevelConfiguration.NumberOfRounds = 5;
		adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 6;
		adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
		adventureLevelConfiguration.NumberOfMinionsPerRound = 2;
		adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>();
		adventureLevelConfiguration.BossFormations = new List<FormationPresence>();
		adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
		Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Side_1_p1, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(5000.0, ResourceType.Money, 1, null),
			GuaranteedDirectResourceReward.CreateDirectResourceReward(5000.0, ResourceType.PracticePoints, 1, null)
		}, new List<QuestRequirementBase>
		{
			new CustomizedDungeonThroughRequirementLogic
			{
				fullfilled = false,
				DungeonType = AdventureType.WoodenForest,
				Configuration = adventureLevelConfiguration,
				DifficultyMeasurement = new double?(65.0),
				IsTwistedTimeDungeon = false
			}
		});
		GameWorld.instance.PlayerProfile.AddQuest(quest);
	}
}
