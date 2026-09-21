using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000454 RID: 1108
public class GenericMonsterKillResolver : AdventureResolverBase
{
	// Token: 0x06001F6D RID: 8045 RVA: 0x000DD1C0 File Offset: 0x000DB5C0
	public GenericMonsterKillResolver()
	{
	}

	// Token: 0x06001F6E RID: 8046 RVA: 0x000DD1C8 File Offset: 0x000DB5C8
	private MonsterKillRequirementLogic GetRelevantRequirmentLogic(AdventureStartParameter parameter)
	{
		DungeonRecord record = GameWorld.instance.PlayerProfile.GetDungeonRecord(parameter.AdventureType);
		List<MonsterKillRequirementLogic> source = (from r in GameWorld.instance.PlayerProfile.GetQuestRequirements<MonsterKillRequirementLogic>(true)
		where r.IsGurranteedSpawn && !r.fullfilled && r.RequiredDungeons.Any((AdventureType d) => d == parameter.AdventureType) && r.RequiredLevels.Any((int l) => l == record.CurrentSelectedLevel)
		select r).ToList<MonsterKillRequirementLogic>();
		return source.FirstOrDefault<MonsterKillRequirementLogic>();
	}

	// Token: 0x06001F6F RID: 8047 RVA: 0x000DD230 File Offset: 0x000DB630
	public override bool CanBeResolved(AdventureStartParameter parameter)
	{
		return GameWorld.instance.PlayerProfile.GetProgress(null).DungeonRecords.Any((DungeonRecord d) => d.AdventureType == parameter.AdventureType) && this.GetRelevantRequirmentLogic(parameter) != null;
	}

	// Token: 0x06001F70 RID: 8048 RVA: 0x000DD294 File Offset: 0x000DB694
	protected override Adventure ResolveLogic(AdventureStartParameter parameter)
	{
		DungeonRecord dungeonRecord = GameWorld.instance.PlayerProfile.GetDungeonRecord(parameter.AdventureType);
		AdventureLevelConfiguration adventureLevelConfiguration = parameter.AdventureType.GetAdventureLevelConfiguration(dungeonRecord.CurrentSelectedLevel);
		MonsterKillRequirementLogic relevantRequirment = this.GetRelevantRequirmentLogic(parameter);
		if (relevantRequirment.MonsterSlotType == AdventureEncounterSlotType.Boss)
		{
			adventureLevelConfiguration.BossFormations = new List<FormationPresence>();
			adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
			{
				new MonsterAppearance(100, relevantRequirment.MonsterClass)
			};
		}
		if (relevantRequirment.MonsterSlotType == AdventureEncounterSlotType.MiniBoss)
		{
			adventureLevelConfiguration.MiniBossSpawnTable = new List<MonsterAppearance>
			{
				new MonsterAppearance(100, relevantRequirment.MonsterClass)
			};
		}
		if (relevantRequirment.MonsterSlotType == AdventureEncounterSlotType.Minion)
		{
			adventureLevelConfiguration.MinionSpawnTable = new List<MonsterAppearance>
			{
				new MonsterAppearance(100, relevantRequirment.MonsterClass)
			};
		}
		Quest quest = GameWorld.instance.PlayerProfile.GetProgress(null).Quests.FirstOrDefault((Quest q) => q.QuestRequirements.Any((QuestRequirementBase r) => r == relevantRequirment));
		DifficultyLevelMeasurement difficultyLevelMeasurement = DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByDungeonLevel(dungeonRecord.CurrentSelectedLevel, parameter.AdventureType, GameWorld.instance.PlayerProfile.GetStarRating());
		if (quest != null)
		{
			QualityGrade grade = quest.Grade;
			difficultyLevelMeasurement = DifficultyLevelMeasurement.GetDifficultyLevelMeasurementForDungeonRelated(new double?(difficultyLevelMeasurement.DifficultyValue + (Convert.ToDouble((int)grade) - 1.0) / 2.0));
		}
		return Adventure.InitializeAdventureBaseOnLevel(parameter, adventureLevelConfiguration, difficultyLevelMeasurement);
	}

	// Token: 0x06001F71 RID: 8049 RVA: 0x000DD424 File Offset: 0x000DB824
	public override List<ISpecialEffectDataLoad> GetDungeonSpecialEffects(AdventureStartParameter parameter)
	{
		DungeonRecord dungeonRecord = GameWorld.instance.PlayerProfile.GetDungeonRecord(parameter.AdventureType);
		return parameter.AdventureType.GetAdventureLevelConfiguration(dungeonRecord.CurrentSelectedLevel).DungeonEffects;
	}

	// Token: 0x06001F72 RID: 8050 RVA: 0x000DD45D File Offset: 0x000DB85D
	public override int ResolverPrecedenceValue()
	{
		return 10;
	}

	// Token: 0x02000D17 RID: 3351
	[CompilerGenerated]
	private sealed class <GetRelevantRequirmentLogic>c__AnonStorey0
	{
		// Token: 0x060055F7 RID: 22007 RVA: 0x000DD461 File Offset: 0x000DB861
		public <GetRelevantRequirmentLogic>c__AnonStorey0()
		{
		}

		// Token: 0x060055F8 RID: 22008 RVA: 0x000DD46C File Offset: 0x000DB86C
		internal bool <>m__0(MonsterKillRequirementLogic r)
		{
			return r.IsGurranteedSpawn && !r.fullfilled && r.RequiredDungeons.Any((AdventureType d) => d == this.parameter.AdventureType) && r.RequiredLevels.Any((int l) => l == this.record.CurrentSelectedLevel);
		}

		// Token: 0x060055F9 RID: 22009 RVA: 0x000DD4C5 File Offset: 0x000DB8C5
		internal bool <>m__1(AdventureType d)
		{
			return d == this.parameter.AdventureType;
		}

		// Token: 0x060055FA RID: 22010 RVA: 0x000DD4D5 File Offset: 0x000DB8D5
		internal bool <>m__2(int l)
		{
			return l == this.record.CurrentSelectedLevel;
		}

		// Token: 0x0400447F RID: 17535
		internal AdventureStartParameter parameter;

		// Token: 0x04004480 RID: 17536
		internal DungeonRecord record;
	}

	// Token: 0x02000D18 RID: 3352
	[CompilerGenerated]
	private sealed class <CanBeResolved>c__AnonStorey1
	{
		// Token: 0x060055FB RID: 22011 RVA: 0x000DD4E5 File Offset: 0x000DB8E5
		public <CanBeResolved>c__AnonStorey1()
		{
		}

		// Token: 0x060055FC RID: 22012 RVA: 0x000DD4ED File Offset: 0x000DB8ED
		internal bool <>m__0(DungeonRecord d)
		{
			return d.AdventureType == this.parameter.AdventureType;
		}

		// Token: 0x04004481 RID: 17537
		internal AdventureStartParameter parameter;
	}

	// Token: 0x02000D19 RID: 3353
	[CompilerGenerated]
	private sealed class <ResolveLogic>c__AnonStorey2
	{
		// Token: 0x060055FD RID: 22013 RVA: 0x000DD502 File Offset: 0x000DB902
		public <ResolveLogic>c__AnonStorey2()
		{
		}

		// Token: 0x060055FE RID: 22014 RVA: 0x000DD50A File Offset: 0x000DB90A
		internal bool <>m__0(Quest q)
		{
			return q.QuestRequirements.Any((QuestRequirementBase r) => r == this.relevantRequirment);
		}

		// Token: 0x060055FF RID: 22015 RVA: 0x000DD523 File Offset: 0x000DB923
		internal bool <>m__1(QuestRequirementBase r)
		{
			return r == this.relevantRequirment;
		}

		// Token: 0x04004482 RID: 17538
		internal MonsterKillRequirementLogic relevantRequirment;
	}
}
