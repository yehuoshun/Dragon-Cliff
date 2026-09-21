using System;
using System.Collections.Generic;

// Token: 0x0200045C RID: 1116
public abstract class LevelConfigurationBase
{
	// Token: 0x06001FAA RID: 8106 RVA: 0x000DD52E File Offset: 0x000DB92E
	protected LevelConfigurationBase()
	{
	}

	// Token: 0x170001DE RID: 478
	// (get) Token: 0x06001FAB RID: 8107
	public abstract AdventureType CorrespondingAdventureType { get; }

	// Token: 0x170001DF RID: 479
	// (get) Token: 0x06001FAC RID: 8108
	public abstract double StartingDifficultyLevel { get; }

	// Token: 0x170001E0 RID: 480
	// (get) Token: 0x06001FAD RID: 8109
	public abstract double EndingDifficultyLevel { get; }

	// Token: 0x06001FAE RID: 8110
	public abstract List<MonsterAppearance> GetPossibleMinionClasses(int dungeonLevel);

	// Token: 0x06001FAF RID: 8111
	public abstract List<MonsterAppearance> GetPossibleMinibossClasses(int dungeonLevel);

	// Token: 0x06001FB0 RID: 8112
	public abstract List<MonsterAppearance> GetPossibleBossClasses(int dungeonLevel);

	// Token: 0x06001FB1 RID: 8113 RVA: 0x000DD536 File Offset: 0x000DB936
	public int GetDifficultyGrade(int levelNumber)
	{
		return GameWorld.instance.PlayerProfile.GetStarRating();
	}

	// Token: 0x06001FB2 RID: 8114 RVA: 0x000DD548 File Offset: 0x000DB948
	public AdventureLevelConfiguration GetLevel(int dungeonLevel)
	{
		double difficultyValue = this.GetDifficultyValue(dungeonLevel);
		DifficultyLevelMeasurement difficultyLevelMeasurementForDungeonRelated = DifficultyLevelMeasurement.GetDifficultyLevelMeasurementForDungeonRelated(new double?(difficultyValue));
		BattleEncounterRangeConfiguration encounterRangeConfiguration = difficultyLevelMeasurementForDungeonRelated.GetEncounterRangeConfiguration();
		return new AdventureLevelConfiguration
		{
			LevelNumber = dungeonLevel,
			BossSpawnTable = this.GetPossibleBossClasses(dungeonLevel),
			BossFormations = this.GetBossFormations(difficultyLevelMeasurementForDungeonRelated),
			CompletionReputation = difficultyLevelMeasurementForDungeonRelated.CorrespondingReputation,
			MiniBossSpawnTable = this.GetPossibleMinibossClasses(dungeonLevel),
			MinionSpawnTable = this.GetPossibleMinionClasses(dungeonLevel),
			EnemyAmountInBattleToExclusive = encounterRangeConfiguration.EnemyAmountInBattleExclusiveTo,
			EnemyAmountInBattleFromInclusive = encounterRangeConfiguration.EnemyAmountInBattleInclusiveFrom,
			NumberOfRounds = encounterRangeConfiguration.NumberOfRounds,
			NumberOfMinionsPerRound = 2,
			DungeonEffects = new List<ISpecialEffectDataLoad>(),
			CustomizedIdentityCode = string.Empty,
			MiniBossFormation = this.GetMinibossFormation(difficultyLevelMeasurementForDungeonRelated),
			MinionFormation = this.GetMinionFormation(difficultyLevelMeasurementForDungeonRelated)
		};
	}

	// Token: 0x06001FB3 RID: 8115 RVA: 0x000DD619 File Offset: 0x000DBA19
	public virtual List<FormationPresence> GetBossFormations(DifficultyLevelMeasurement measurement)
	{
		return new List<FormationPresence>();
	}

	// Token: 0x06001FB4 RID: 8116 RVA: 0x000DD620 File Offset: 0x000DBA20
	public virtual List<FormationPresence> GetMinibossFormation(DifficultyLevelMeasurement measurement)
	{
		return new List<FormationPresence>();
	}

	// Token: 0x06001FB5 RID: 8117 RVA: 0x000DD627 File Offset: 0x000DBA27
	public virtual List<FormationPresence> GetMinionFormation(DifficultyLevelMeasurement measurement)
	{
		return new List<FormationPresence>();
	}

	// Token: 0x06001FB6 RID: 8118 RVA: 0x000DD62E File Offset: 0x000DBA2E
	public double GetDifficultyValue(int dungeonLevel)
	{
		return this.StartingDifficultyLevel + (double)dungeonLevel * DifficultyLevelMeasurement.DefaultDifficultyGapPerDungeonLevelIncrement;
	}

	// Token: 0x06001FB7 RID: 8119 RVA: 0x000DD63F File Offset: 0x000DBA3F
	public int GetCorrespondingMaxVisibleLevel(double difficultyValue)
	{
		if (difficultyValue <= this.StartingDifficultyLevel)
		{
			return 1;
		}
		return (int)((difficultyValue - this.StartingDifficultyLevel) / DifficultyLevelMeasurement.DefaultDifficultyGapPerDungeonLevelIncrement);
	}

	// Token: 0x06001FB8 RID: 8120 RVA: 0x000DD65E File Offset: 0x000DBA5E
	// Note: this type is marked as 'beforefieldinit'.
	static LevelConfigurationBase()
	{
	}

	// Token: 0x04001C5E RID: 7262
	protected static int LowestLevelMonsterPresence = 10;

	// Token: 0x04001C5F RID: 7263
	protected static int LowLevelMonsterPresence = 30;

	// Token: 0x04001C60 RID: 7264
	protected static int MediumMonsterPresence = 100;

	// Token: 0x04001C61 RID: 7265
	protected static int HighMonsterPresence = 200;

	// Token: 0x04001C62 RID: 7266
	protected static int HighestMonsterPresence = 500;
}
