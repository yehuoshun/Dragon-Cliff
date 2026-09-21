using System;
using System.Collections.Generic;

// Token: 0x020004CA RID: 1226
public class MainChapterFourHandler : MainQuestHandlerBase
{
	// Token: 0x060024C8 RID: 9416 RVA: 0x0010B655 File Offset: 0x00109A55
	public MainChapterFourHandler()
	{
	}

	// Token: 0x17000279 RID: 633
	// (get) Token: 0x060024C9 RID: 9417 RVA: 0x0010B664 File Offset: 0x00109A64
	public override QuestChainIdentifier ChainIdentifier
	{
		get
		{
			return this._chainIdentifier;
		}
	}

	// Token: 0x060024CA RID: 9418 RVA: 0x0010B66C File Offset: 0x00109A6C
	public override void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		MainChapterFourHandler.Main41(evt, data);
		MainChapterFourHandler.Main42(evt, data);
	}

	// Token: 0x060024CB RID: 9419 RVA: 0x0010B67C File Offset: 0x00109A7C
	private static void Main41(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main3_2)
			{
				GameWorld.instance.PlayerProfile.EnableDungeonRecord(AdventureType.BuriedTemple);
				AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.BuriedTemple.GetAdventureLevelConfiguration(5).NakedDuplicate();
				adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
				{
					new MonsterAppearance(100, UnitClass.DevilMan)
				};
				adventureLevelConfiguration.NumberOfRounds = 7;
				adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 5;
				adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
				adventureLevelConfiguration.NumberOfMinionsPerRound = 2;
				adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>();
				adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
				double value = 45.0;
				Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main4_1, new List<QuestRewardBase>
				{
					GuaranteedDirectResourceReward.CreateDirectResourceReward(10000.0, ResourceType.Money, 1, null),
					GuaranteedDirectResourceReward.CreateDirectResourceReward(6000.0, ResourceType.PracticePoints, 1, null)
				}, new List<QuestRequirementBase>
				{
					new CustomizedDungeonThroughRequirementLogic
					{
						fullfilled = false,
						DungeonType = AdventureType.BuriedTemple,
						Configuration = adventureLevelConfiguration,
						DifficultyMeasurement = new double?(value),
						IsTwistedTimeDungeon = false
					}
				});
				GameWorld.instance.PlayerProfile.AddQuest(quest);
			}
		}
	}

	// Token: 0x060024CC RID: 9420 RVA: 0x0010B7F0 File Offset: 0x00109BF0
	private static void Main42(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main4_1)
			{
				AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.BuriedTemple.GetAdventureLevelConfiguration(15).NakedDuplicate();
				adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>();
				adventureLevelConfiguration.BossFormations = new List<FormationPresence>
				{
					new FormationPresence
					{
						Presence = 100,
						Minions = new List<UnitClass>
						{
							UnitClass.Savagery,
							UnitClass.Savagery,
							UnitClass.BloodyEye
						}
					}
				};
				adventureLevelConfiguration.NumberOfRounds = 5;
				adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 5;
				adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
				adventureLevelConfiguration.NumberOfMinionsPerRound = 2;
				adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>
				{
					new BlessedSinData
					{
						LifeOnHitRate = 1.0,
						DamagePerSecondPerType = 150.0,
						DamageTypes = new List<OutputType>
						{
							OutputType.Shadow,
							OutputType.Poison
						}
					}
				};
				adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
				double value = 55.0;
				Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main4_2, new List<QuestRewardBase>
				{
					GuaranteedDirectResourceReward.CreateDirectResourceReward(15000.0, ResourceType.Money, 1, null),
					GuaranteedDirectResourceReward.CreateDirectResourceReward(8000.0, ResourceType.PracticePoints, 1, null)
				}, new List<QuestRequirementBase>
				{
					new CustomizedDungeonThroughRequirementLogic
					{
						fullfilled = false,
						DungeonType = AdventureType.BuriedTemple,
						Configuration = adventureLevelConfiguration,
						DifficultyMeasurement = new double?(value),
						IsTwistedTimeDungeon = false
					}
				});
				GameWorld.instance.PlayerProfile.AddQuest(quest);
			}
		}
	}

	// Token: 0x04001FAC RID: 8108
	private QuestChainIdentifier _chainIdentifier = QuestChainIdentifier.MainChapterFour;
}
