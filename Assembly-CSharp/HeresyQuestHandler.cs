using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020004D1 RID: 1233
public class HeresyQuestHandler : StaticSideQuestHandlerBase
{
	// Token: 0x060024FC RID: 9468 RVA: 0x0010D42C File Offset: 0x0010B82C
	public HeresyQuestHandler()
	{
	}

	// Token: 0x1700027F RID: 639
	// (get) Token: 0x060024FD RID: 9469 RVA: 0x0010D434 File Offset: 0x0010B834
	public override QuestChainIdentifier ChainIdentifier
	{
		get
		{
			return QuestChainIdentifier.Heresy;
		}
	}

	// Token: 0x060024FE RID: 9470 RVA: 0x0010D438 File Offset: 0x0010B838
	private int GetNumberOfDungeonResource()
	{
		if (GameWorld.instance.PlayerProfile.GetStarRating() == 1)
		{
			int num = 5;
			if (GameWorld.instance.PlayerProfile.GetProgress(null).MaxAchievedDifficultyValue > 100.0)
			{
				num += (int)((GameWorld.instance.PlayerProfile.GetProgress(null).MaxAchievedDifficultyValue - 100.0) / 20.0);
			}
			if (num > 10)
			{
				num = 10;
			}
			return num;
		}
		int num2 = 10;
		if (GameWorld.instance.PlayerProfile.GetProgress(null).MaxAchievedDifficultyValue > 100.0)
		{
			num2 += (int)((GameWorld.instance.PlayerProfile.GetProgress(null).MaxAchievedDifficultyValue - 100.0) / 20.0);
		}
		if (num2 > 20)
		{
			num2 = 20;
		}
		return num2;
	}

	// Token: 0x060024FF RID: 9471 RVA: 0x0010D538 File Offset: 0x0010B938
	private List<ISpecialEffectDataLoad> GetRandomDungeonEffects(int numberOfEffects)
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>
		{
			new RestrictedAccessData
			{
				NumberOfAllowed = 4
			},
			new CurseData
			{
				IsStar = false,
				DamageRate = 0.7,
				Seconds = 3,
				SpreadNumberOfUnits = 1
			},
			new DungeonScaleUndeadEffectData
			{
				IsStarEf = new bool?(false),
				ReviveRate = 1.0,
				RevivedUnitsInCurrentEncounter = new List<IBattleUnit>()
			}
		};
		List<ISpecialEffectDataLoad> list2 = new List<ISpecialEffectDataLoad>
		{
			new AttributeDepressionData
			{
				IsStar = false,
				Type = AttributeType.Strength,
				ReductionRate = 0.8
			},
			new AttributeDepressionData
			{
				IsStar = false,
				Type = AttributeType.Intelligience,
				ReductionRate = 0.8
			},
			new AttributeDepressionData
			{
				IsStar = false,
				Type = AttributeType.CritRate,
				ReductionRate = 1.0
			},
			new AttributeDepressionData
			{
				IsStar = false,
				Type = AttributeType.Agility,
				ReductionRate = 0.6
			}
		};
		list.Add(list2[UnityEngine.Random.Range(0, list2.Count)]);
		list.Shuffle<ISpecialEffectDataLoad>();
		return list.Take(numberOfEffects).ToList<ISpecialEffectDataLoad>();
	}

	// Token: 0x06002500 RID: 9472 RVA: 0x0010D6BB File Offset: 0x0010BABB
	public static bool CanDropFinal()
	{
		return !GameWorld.instance.PlayerProfile.AdditionalData.ContainsBool(HeresyQuestHandler.FinalDropKey) || !GameWorld.instance.PlayerProfile.AdditionalData.GetBool(HeresyQuestHandler.FinalDropKey);
	}

	// Token: 0x06002501 RID: 9473 RVA: 0x0010D6FA File Offset: 0x0010BAFA
	public static void SetDropFinal()
	{
		GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(HeresyQuestHandler.FinalDropKey, true);
	}

	// Token: 0x06002502 RID: 9474 RVA: 0x0010D716 File Offset: 0x0010BB16
	public static void ResetDropFinal()
	{
		GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(HeresyQuestHandler.FinalDropKey, false);
	}

	// Token: 0x06002503 RID: 9475 RVA: 0x0010D734 File Offset: 0x0010BB34
	public override void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		if ((evt == GameWorldEvent.GameSessionInitializationCompleted || evt == GameWorldEvent.GameDaysChanged) && GameWorld.instance.PlayerProfile.GetProgress(null).Reputation >= 10000.0)
		{
			bool flag = GameWorld.instance.PlayerProfile.GetProgress(null).Quests.Any((Quest q) => q.QuestIdentifier == QuestIdentifier.Heresy_p1);
			if (!GameWorld.instance.PlayerProfile.GetProgress(null).Quests.Any((Quest q) => q.QuestIdentifier == QuestIdentifier.Heresy_p2) && !flag)
			{
				this.GenerateP1();
			}
		}
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Heresy_p2)
			{
				bool flag2 = GameWorld.instance.PlayerProfile.GetProgress(null).Quests.Any((Quest q) => q.QuestIdentifier == QuestIdentifier.Heresy_p1);
				bool flag3 = GameWorld.instance.PlayerProfile.GetProgress(null).Quests.Any((Quest q) => q.QuestIdentifier == QuestIdentifier.Heresy_p2);
				if (!flag2 && !flag3)
				{
					this.GenerateP1();
				}
			}
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Heresy_p1)
			{
				bool flag4 = GameWorld.instance.PlayerProfile.GetProgress(null).Quests.Any((Quest q) => q.QuestIdentifier == QuestIdentifier.Heresy_p1);
				bool flag5 = GameWorld.instance.PlayerProfile.GetProgress(null).Quests.Any((Quest q) => q.QuestIdentifier == QuestIdentifier.Heresy_p2);
				if (!flag4 && !flag5)
				{
					HeresyQuestHandler.ResetDropFinal();
					List<AdventureType> list = new List<AdventureType>
					{
						AdventureType.BuriedTemple,
						AdventureType.HellishPath,
						AdventureType.NorthernTerritory,
						AdventureType.ImperialMausoleum
					};
					AdventureType adventureType = list[UnityEngine.Random.Range(0, list.Count)];
					int currentAchievedLevel = GameWorld.instance.PlayerProfile.GetDungeonRecord(adventureType).CurrentAchievedLevel;
					int level = UnityEngine.Random.Range(1, currentAchievedLevel + 1);
					AdventureLevelConfiguration adventureLevelConfiguration = adventureType.GetAdventureLevelConfiguration(level).NakedDuplicate();
					adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
					{
						new MonsterAppearance(100, UnitClass.BlueDemonDragon)
					};
					adventureLevelConfiguration.NumberOfRounds = 15;
					adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 6;
					adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
					adventureLevelConfiguration.NumberOfMinionsPerRound = 0;
					adventureLevelConfiguration.DungeonEffects = this.GetRandomDungeonEffects(2);
					adventureLevelConfiguration.BossFormations = new List<FormationPresence>();
					adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
					Quest quest = Quest.CreateCustomQuest(QuestIdentifier.Heresy_p2, new List<QuestRewardBase>
					{
						GuaranteedDirectResourceReward.CreateDirectResourceReward((double)(this.GetNumberOfDungeonResource() * 8), ResourceType.FragmentOfDemon, 1, null),
						GuaranteedDirectResourceReward.CreateDirectResourceReward((double)(this.GetNumberOfDungeonResource() * 10000), ResourceType.Money, 1, null),
						GuaranteedDirectResourceReward.CreateDirectResourceReward((double)(this.GetNumberOfDungeonResource() * 8), ResourceType.InfusedPowder, 1, null)
					}, new List<QuestRequirementBase>
					{
						new CustomizedDungeonThroughRequirementLogic
						{
							fullfilled = false,
							DungeonType = adventureType,
							Configuration = adventureLevelConfiguration,
							DifficultyMeasurement = new double?(GameWorld.instance.PlayerProfile.GetProgress(null).MaxAchievedDifficultyValue - 2.0),
							IsTwistedTimeDungeon = false
						}
					}, QualityGrade.Ancient, 300);
					GameWorld.instance.PlayerProfile.AddQuest(quest);
				}
			}
		}
	}

	// Token: 0x06002504 RID: 9476 RVA: 0x0010DB70 File Offset: 0x0010BF70
	private void GenerateP1()
	{
		this.PopulateP1(AdventureType.WoodenForest, ResourceType.CrystalOfWoodenForest);
		this.PopulateP1(AdventureType.MistForest, ResourceType.InkOfMistForest);
		this.PopulateP1(AdventureType.SnowMountain, ResourceType.IceOfSnowMountain);
		this.PopulateP1(AdventureType.BuriedTemple, ResourceType.SealOfBuriedTemple);
		this.PopulateP1(AdventureType.HellishPath, ResourceType.StoneOfHellishPath);
		this.PopulateP1(AdventureType.ImperialMausoleum, ResourceType.LeafOfImperialM);
		this.PopulateP1(AdventureType.NorthernTerritory, ResourceType.SandOfNorthernTerritory);
	}

	// Token: 0x06002505 RID: 9477 RVA: 0x0010DBD8 File Offset: 0x0010BFD8
	private void PopulateP1(AdventureType dungeonType, ResourceType dungeonResource)
	{
		int currentAchievedLevel = GameWorld.instance.PlayerProfile.GetDungeonRecord(dungeonType).CurrentAchievedLevel;
		int level = UnityEngine.Random.Range(1, currentAchievedLevel + 1);
		AdventureLevelConfiguration adventureLevelConfiguration = dungeonType.GetAdventureLevelConfiguration(level).NakedDuplicate();
		adventureLevelConfiguration.NumberOfRounds = 12;
		adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 6;
		adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
		adventureLevelConfiguration.NumberOfMinionsPerRound = 0;
		adventureLevelConfiguration.DungeonEffects = this.GetRandomDungeonEffects(1);
		adventureLevelConfiguration.BossFormations = new List<FormationPresence>();
		adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
		Quest quest = Quest.CreateCustomQuest(QuestIdentifier.Heresy_p1, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward((double)this.GetNumberOfDungeonResource(), dungeonResource, 1, null),
			GuaranteedDirectResourceReward.CreateDirectResourceReward((double)(this.GetNumberOfDungeonResource() * 3), ResourceType.FragmentOfDemon, 1, null)
		}, new List<QuestRequirementBase>
		{
			new CustomizedDungeonThroughRequirementLogic
			{
				fullfilled = false,
				DungeonType = dungeonType,
				Configuration = adventureLevelConfiguration,
				DifficultyMeasurement = new double?(GameWorld.instance.PlayerProfile.GetProgress(null).MaxAchievedDifficultyValue - 1.0),
				IsTwistedTimeDungeon = false
			}
		}, QualityGrade.Ancient, 300);
		GameWorld.instance.PlayerProfile.AddQuest(quest);
	}

	// Token: 0x06002506 RID: 9478 RVA: 0x0010DD3A File Offset: 0x0010C13A
	// Note: this type is marked as 'beforefieldinit'.
	static HeresyQuestHandler()
	{
	}

	// Token: 0x06002507 RID: 9479 RVA: 0x0010DD46 File Offset: 0x0010C146
	[CompilerGenerated]
	private static bool <ProcessGameEvent>m__0(Quest q)
	{
		return q.QuestIdentifier == QuestIdentifier.Heresy_p1;
	}

	// Token: 0x06002508 RID: 9480 RVA: 0x0010DD52 File Offset: 0x0010C152
	[CompilerGenerated]
	private static bool <ProcessGameEvent>m__1(Quest q)
	{
		return q.QuestIdentifier == QuestIdentifier.Heresy_p2;
	}

	// Token: 0x06002509 RID: 9481 RVA: 0x0010DD5E File Offset: 0x0010C15E
	[CompilerGenerated]
	private static bool <ProcessGameEvent>m__2(Quest q)
	{
		return q.QuestIdentifier == QuestIdentifier.Heresy_p1;
	}

	// Token: 0x0600250A RID: 9482 RVA: 0x0010DD6A File Offset: 0x0010C16A
	[CompilerGenerated]
	private static bool <ProcessGameEvent>m__3(Quest q)
	{
		return q.QuestIdentifier == QuestIdentifier.Heresy_p2;
	}

	// Token: 0x0600250B RID: 9483 RVA: 0x0010DD76 File Offset: 0x0010C176
	[CompilerGenerated]
	private static bool <ProcessGameEvent>m__4(Quest q)
	{
		return q.QuestIdentifier == QuestIdentifier.Heresy_p1;
	}

	// Token: 0x0600250C RID: 9484 RVA: 0x0010DD82 File Offset: 0x0010C182
	[CompilerGenerated]
	private static bool <ProcessGameEvent>m__5(Quest q)
	{
		return q.QuestIdentifier == QuestIdentifier.Heresy_p2;
	}

	// Token: 0x04001FB1 RID: 8113
	private static string FinalDropKey = "finaldragon";

	// Token: 0x04001FB2 RID: 8114
	[CompilerGenerated]
	private static Func<Quest, bool> <>f__am$cache0;

	// Token: 0x04001FB3 RID: 8115
	[CompilerGenerated]
	private static Func<Quest, bool> <>f__am$cache1;

	// Token: 0x04001FB4 RID: 8116
	[CompilerGenerated]
	private static Func<Quest, bool> <>f__am$cache2;

	// Token: 0x04001FB5 RID: 8117
	[CompilerGenerated]
	private static Func<Quest, bool> <>f__am$cache3;

	// Token: 0x04001FB6 RID: 8118
	[CompilerGenerated]
	private static Func<Quest, bool> <>f__am$cache4;

	// Token: 0x04001FB7 RID: 8119
	[CompilerGenerated]
	private static Func<Quest, bool> <>f__am$cache5;
}
