using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020004D8 RID: 1240
public class Side7QuestHandler : StaticSideQuestHandlerBase
{
	// Token: 0x06002536 RID: 9526 RVA: 0x0010F94E File Offset: 0x0010DD4E
	public Side7QuestHandler()
	{
	}

	// Token: 0x17000286 RID: 646
	// (get) Token: 0x06002537 RID: 9527 RVA: 0x0010F956 File Offset: 0x0010DD56
	public override QuestChainIdentifier ChainIdentifier
	{
		get
		{
			return QuestChainIdentifier.Remnants;
		}
	}

	// Token: 0x06002538 RID: 9528 RVA: 0x0010F95C File Offset: 0x0010DD5C
	public override void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.AdventureCompleted && data is Adventure && GameWorld.instance.PlayerProfile.GetProgress(null).Reputation >= 5000.0 && !GameWorld.instance.PlayerProfile.QuestIsActive(QuestIdentifier.Side_7))
		{
			Adventure adventure = data as Adventure;
			if (adventure.Survivied == Adventure.SurvivalStatus.Surviving && adventure.AdventureType != AdventureType.TwistedPalace && adventure.CorrespondingDifficultyMeasurement.StarRating != -1)
			{
				string key = "remnants" + adventure.CorrespondingDifficultyMeasurement.StarRating;
				if (!GameWorld.instance.PlayerProfile.AdditionalData.ContainsInt(key))
				{
					GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(key, 0);
				}
				GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(key, GameWorld.instance.PlayerProfile.AdditionalData.GetInt(key) + 1);
				int @int = GameWorld.instance.PlayerProfile.AdditionalData.GetInt(key);
				double num = (double)@int * 0.03;
				if ((double)UnityEngine.Random.value <= num)
				{
					GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(key, 0);
					Side7QuestHandler.AddSide7();
				}
			}
		}
	}

	// Token: 0x06002539 RID: 9529 RVA: 0x0010FAB0 File Offset: 0x0010DEB0
	public static void AddSide7()
	{
		List<UnitClass> list = new List<UnitClass>
		{
			UnitClass.BlacksmithBrother_Remnants,
			UnitClass.BloodEye_Remnants,
			UnitClass.CorruptedHorn_Remnants,
			UnitClass.DarkKnight_Remnants
		};
		UnitClass unitClass = list[UnityEngine.Random.Range(0, list.Count)];
		DifficultyLevelMeasurement difficultyLevelMeasurement_CurrentRating = GameWorld.instance.PlayerProfile.GetDifficultyLevelMeasurement_CurrentRating();
		List<UnitClass> possibleMinibossUnits = difficultyLevelMeasurement_CurrentRating.GetPossibleMinibossUnits();
		List<UnitClass> possibleMinionUnits = difficultyLevelMeasurement_CurrentRating.GetPossibleMinionUnits();
		possibleMinionUnits.Shuffle<UnitClass>();
		possibleMinibossUnits.Shuffle<UnitClass>();
		AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.BuriedTemple.GetAdventureLevelConfiguration(8).NakedDuplicate();
		adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
		{
			new MonsterAppearance(100, unitClass)
		};
		adventureLevelConfiguration.MiniBossSpawnTable = (from b in possibleMinibossUnits.Take(3)
		select new MonsterAppearance(100, b)).ToList<MonsterAppearance>();
		adventureLevelConfiguration.MinionSpawnTable = (from b in possibleMinionUnits.Take(5)
		select new MonsterAppearance(100, b)).ToList<MonsterAppearance>();
		adventureLevelConfiguration.NumberOfRounds = 6;
		adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 6;
		adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 7;
		adventureLevelConfiguration.NumberOfMinionsPerRound = 1;
		adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>();
		adventureLevelConfiguration.BossFormations = ((unitClass == UnitClass.BloodEye_Remnants) ? new List<FormationPresence>
		{
			new FormationPresence
			{
				Presence = 100,
				Minions = new List<UnitClass>
				{
					UnitClass.BloodEye_Remnants,
					UnitClass.Savagery,
					UnitClass.Savagery,
					UnitClass.Savagery,
					UnitClass.Savagery,
					UnitClass.Savagery,
					UnitClass.Savagery
				}
			}
		} : new List<FormationPresence>());
		adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
		Quest quest = Quest.CreateCustomQuest(QuestIdentifier.Side_7, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(20000.0, ResourceType.Money, 1, null),
			GuaranteedDirectResourceReward.CreateDirectResourceReward(20000.0, ResourceType.PracticePoints, 1, null)
		}, new List<QuestRequirementBase>
		{
			new CustomizedDungeonThroughRequirementLogic
			{
				fullfilled = false,
				DungeonType = AdventureType.TwistedPalace,
				Configuration = adventureLevelConfiguration,
				DifficultyMeasurement = new double?(GameWorld.instance.PlayerProfile.GetProgress(null).MaxAchievedDifficultyValue),
				IsTwistedTimeDungeon = true
			}
		}, QualityGrade.Ancient, 30);
		GameWorld.instance.PlayerProfile.AddQuest(quest);
	}

	// Token: 0x0600253A RID: 9530 RVA: 0x0010FD80 File Offset: 0x0010E180
	[CompilerGenerated]
	private static MonsterAppearance <AddSide7>m__0(UnitClass b)
	{
		return new MonsterAppearance(100, b);
	}

	// Token: 0x0600253B RID: 9531 RVA: 0x0010FD8A File Offset: 0x0010E18A
	[CompilerGenerated]
	private static MonsterAppearance <AddSide7>m__1(UnitClass b)
	{
		return new MonsterAppearance(100, b);
	}

	// Token: 0x04001FC0 RID: 8128
	[CompilerGenerated]
	private static Func<UnitClass, MonsterAppearance> <>f__am$cache0;

	// Token: 0x04001FC1 RID: 8129
	[CompilerGenerated]
	private static Func<UnitClass, MonsterAppearance> <>f__am$cache1;
}
