using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000447 RID: 1095
[Serializable]
public class AdventureLevelConfiguration
{
	// Token: 0x06001E9E RID: 7838 RVA: 0x000D551D File Offset: 0x000D391D
	public AdventureLevelConfiguration()
	{
	}

	// Token: 0x06001E9F RID: 7839 RVA: 0x000D5528 File Offset: 0x000D3928
	public AdventureLevelConfiguration NakedDuplicate()
	{
		AdventureLevelConfiguration adventureLevelConfiguration = new AdventureLevelConfiguration();
		adventureLevelConfiguration.NumberOfRounds = this.NumberOfRounds;
		adventureLevelConfiguration.LevelNumber = this.LevelNumber;
		adventureLevelConfiguration.NumberOfMinionsPerRound = this.NumberOfMinionsPerRound;
		adventureLevelConfiguration.CustomizedIdentityCode = this.CustomizedIdentityCode;
		adventureLevelConfiguration.BossFormations = this.BossFormations.Select(delegate(FormationPresence f)
		{
			FormationPresence formationPresence = new FormationPresence();
			formationPresence.Presence = f.Presence;
			formationPresence.Minions = (from m in f.Minions
			select m).ToList<UnitClass>();
			return formationPresence;
		}).ToList<FormationPresence>();
		adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>();
		adventureLevelConfiguration.MiniBossSpawnTable = (from t in this.MiniBossSpawnTable
		select new MonsterAppearance(t.Presence, t.UnitClass)).ToList<MonsterAppearance>();
		adventureLevelConfiguration.MinionSpawnTable = (from t in this.MinionSpawnTable
		select new MonsterAppearance(t.Presence, t.UnitClass)).ToList<MonsterAppearance>();
		adventureLevelConfiguration.BossSpawnTable = (from t in this.BossSpawnTable
		select new MonsterAppearance(t.Presence, t.UnitClass)).ToList<MonsterAppearance>();
		adventureLevelConfiguration.EnemyAmountInBattleToExclusive = this.EnemyAmountInBattleToExclusive;
		adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = this.EnemyAmountInBattleFromInclusive;
		adventureLevelConfiguration.CompletionReputation = this.CompletionReputation;
		AdventureLevelConfiguration adventureLevelConfiguration2 = adventureLevelConfiguration;
		List<FormationPresence> minionFormation;
		if (this.MinionFormation != null)
		{
			minionFormation = this.MinionFormation.Select(delegate(FormationPresence f)
			{
				FormationPresence formationPresence = new FormationPresence();
				formationPresence.Presence = f.Presence;
				formationPresence.Minions = (from m in f.Minions
				select m).ToList<UnitClass>();
				return formationPresence;
			}).ToList<FormationPresence>();
		}
		else
		{
			minionFormation = new List<FormationPresence>();
		}
		adventureLevelConfiguration2.MinionFormation = minionFormation;
		AdventureLevelConfiguration adventureLevelConfiguration3 = adventureLevelConfiguration;
		List<FormationPresence> miniBossFormation;
		if (this.MiniBossFormation != null)
		{
			miniBossFormation = this.MiniBossFormation.Select(delegate(FormationPresence f)
			{
				FormationPresence formationPresence = new FormationPresence();
				formationPresence.Presence = f.Presence;
				formationPresence.Minions = (from m in f.Minions
				select m).ToList<UnitClass>();
				return formationPresence;
			}).ToList<FormationPresence>();
		}
		else
		{
			miniBossFormation = new List<FormationPresence>();
		}
		adventureLevelConfiguration3.MiniBossFormation = miniBossFormation;
		return adventureLevelConfiguration;
	}

	// Token: 0x06001EA0 RID: 7840 RVA: 0x000D56F8 File Offset: 0x000D3AF8
	public List<IEncounter> GetEncounters(List<IBattleUnit> playerUnits, Adventure adventure)
	{
		DifficultyLevelMeasurement correspondingDifficultyMeasurement = adventure.CorrespondingDifficultyMeasurement;
		List<AdventureEncounterSlotType> list = new List<AdventureEncounterSlotType>();
		List<IEncounter> list2 = new List<IEncounter>();
		for (int i = 0; i < this.NumberOfRounds - 1; i++)
		{
			for (int j = 0; j < this.NumberOfMinionsPerRound; j++)
			{
				list.Add(AdventureEncounterSlotType.Minion);
			}
			list.Add(AdventureEncounterSlotType.MiniBoss);
		}
		for (int k = 0; k < this.NumberOfMinionsPerRound; k++)
		{
			list.Add(AdventureEncounterSlotType.Minion);
		}
		list.Add(AdventureEncounterSlotType.Boss);
		foreach (AdventureEncounterSlotType adventureEncounterSlotType in list)
		{
			int num = UnityEngine.Random.Range(this.EnemyAmountInBattleFromInclusive, this.EnemyAmountInBattleToExclusive);
			List<IBattleUnit> list3 = new List<IBattleUnit>();
			if (adventureEncounterSlotType == AdventureEncounterSlotType.Boss)
			{
				if (this.BossFormations.Any<FormationPresence>())
				{
					FormationPresence formationPresence = this.BossFormations.WeightedRandomSelect<FormationPresence>();
					foreach (UnitClass unitClass in formationPresence.Minions)
					{
						MonsterAppearance monsterConfig = this.GetMonsterConfig(unitClass);
						list3.Add(monsterConfig.UnitClass.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.Minion), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					}
					if (formationPresence.Boss != (UnitClass)0)
					{
						MonsterAppearance monsterConfig2 = this.GetMonsterConfig(formationPresence.Boss);
						list3.Add(monsterConfig2.UnitClass.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.Boss), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					}
				}
				else
				{
					num--;
					MonsterAppearance monsterAppearance = this.BossSpawnTable.WeightedRandomSelect<MonsterAppearance>();
					list3.Add(monsterAppearance.UnitClass.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.Boss), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					for (int l = 0; l < num; l++)
					{
						MonsterAppearance monsterAppearance2 = this.MinionSpawnTable.WeightedRandomSelect<MonsterAppearance>();
						list3.Add(monsterAppearance2.UnitClass.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.Minion), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					}
				}
			}
			if (adventureEncounterSlotType == AdventureEncounterSlotType.MiniBoss)
			{
				if (this.MiniBossFormation != null && this.MiniBossFormation.Any<FormationPresence>())
				{
					FormationPresence formationPresence2 = this.MiniBossFormation.WeightedRandomSelect<FormationPresence>();
					foreach (UnitClass unitClass2 in formationPresence2.Minions)
					{
						MonsterAppearance monsterConfig3 = this.GetMonsterConfig(unitClass2);
						list3.Add(monsterConfig3.UnitClass.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.Minion), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					}
					if (formationPresence2.Boss != (UnitClass)0)
					{
						MonsterAppearance monsterConfig4 = this.GetMonsterConfig(formationPresence2.Boss);
						list3.Add(monsterConfig4.UnitClass.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.MiniBoss), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					}
				}
				else
				{
					num--;
					MonsterAppearance monsterAppearance3 = this.MiniBossSpawnTable.WeightedRandomSelect<MonsterAppearance>();
					list3.Add(monsterAppearance3.UnitClass.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.MiniBoss), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					for (int m = 0; m < num; m++)
					{
						MonsterAppearance monsterAppearance4 = this.MinionSpawnTable.WeightedRandomSelect<MonsterAppearance>();
						list3.Add(monsterAppearance4.UnitClass.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.Minion), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					}
				}
			}
			if (adventureEncounterSlotType == AdventureEncounterSlotType.Minion)
			{
				if (this.MinionFormation != null && this.MinionFormation.Any<FormationPresence>())
				{
					FormationPresence formationPresence3 = this.MinionFormation.WeightedRandomSelect<FormationPresence>();
					foreach (UnitClass unitClass3 in formationPresence3.Minions)
					{
						MonsterAppearance monsterConfig5 = this.GetMonsterConfig(unitClass3);
						list3.Add(monsterConfig5.UnitClass.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.Minion), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					}
				}
				else
				{
					for (int n = 0; n < num; n++)
					{
						MonsterAppearance monsterAppearance5 = this.MinionSpawnTable.WeightedRandomSelect<MonsterAppearance>();
						list3.Add(monsterAppearance5.UnitClass.CreateEnemyUnit(correspondingDifficultyMeasurement.MosnterPowerLevel, correspondingDifficultyMeasurement.GetMonsterLevel(AdventureEncounterSlotType.Minion), correspondingDifficultyMeasurement.MonsterSkillLevel, adventure, new List<SkillType>()));
					}
				}
			}
			list2.Add(new BattleEncounter(playerUnits, list3, adventure));
		}
		return list2;
	}

	// Token: 0x06001EA1 RID: 7841 RVA: 0x000D5C28 File Offset: 0x000D4028
	public MonsterAppearance GetMonsterConfig(UnitClass unitClass)
	{
		MonsterAppearance result;
		if ((result = this.BossSpawnTable.FirstOrDefault((MonsterAppearance b) => b.UnitClass == unitClass)) == null && (result = this.MiniBossSpawnTable.FirstOrDefault((MonsterAppearance b) => b.UnitClass == unitClass)) == null)
		{
			result = (this.MinionSpawnTable.FirstOrDefault((MonsterAppearance b) => b.UnitClass == unitClass) ?? new MonsterAppearance(100, unitClass));
		}
		return result;
	}

	// Token: 0x06001EA2 RID: 7842 RVA: 0x000D5CAC File Offset: 0x000D40AC
	[CompilerGenerated]
	private static FormationPresence <NakedDuplicate>m__0(FormationPresence f)
	{
		FormationPresence formationPresence = new FormationPresence();
		formationPresence.Presence = f.Presence;
		formationPresence.Minions = (from m in f.Minions
		select m).ToList<UnitClass>();
		return formationPresence;
	}

	// Token: 0x06001EA3 RID: 7843 RVA: 0x000D5CFF File Offset: 0x000D40FF
	[CompilerGenerated]
	private static MonsterAppearance <NakedDuplicate>m__1(MonsterAppearance t)
	{
		return new MonsterAppearance(t.Presence, t.UnitClass);
	}

	// Token: 0x06001EA4 RID: 7844 RVA: 0x000D5D12 File Offset: 0x000D4112
	[CompilerGenerated]
	private static MonsterAppearance <NakedDuplicate>m__2(MonsterAppearance t)
	{
		return new MonsterAppearance(t.Presence, t.UnitClass);
	}

	// Token: 0x06001EA5 RID: 7845 RVA: 0x000D5D25 File Offset: 0x000D4125
	[CompilerGenerated]
	private static MonsterAppearance <NakedDuplicate>m__3(MonsterAppearance t)
	{
		return new MonsterAppearance(t.Presence, t.UnitClass);
	}

	// Token: 0x06001EA6 RID: 7846 RVA: 0x000D5D38 File Offset: 0x000D4138
	[CompilerGenerated]
	private static FormationPresence <NakedDuplicate>m__4(FormationPresence f)
	{
		FormationPresence formationPresence = new FormationPresence();
		formationPresence.Presence = f.Presence;
		formationPresence.Minions = (from m in f.Minions
		select m).ToList<UnitClass>();
		return formationPresence;
	}

	// Token: 0x06001EA7 RID: 7847 RVA: 0x000D5D8C File Offset: 0x000D418C
	[CompilerGenerated]
	private static FormationPresence <NakedDuplicate>m__5(FormationPresence f)
	{
		FormationPresence formationPresence = new FormationPresence();
		formationPresence.Presence = f.Presence;
		formationPresence.Minions = (from m in f.Minions
		select m).ToList<UnitClass>();
		return formationPresence;
	}

	// Token: 0x06001EA8 RID: 7848 RVA: 0x000D5DDF File Offset: 0x000D41DF
	[CompilerGenerated]
	private static UnitClass <NakedDuplicate>m__6(UnitClass m)
	{
		return m;
	}

	// Token: 0x06001EA9 RID: 7849 RVA: 0x000D5DE2 File Offset: 0x000D41E2
	[CompilerGenerated]
	private static UnitClass <NakedDuplicate>m__7(UnitClass m)
	{
		return m;
	}

	// Token: 0x06001EAA RID: 7850 RVA: 0x000D5DE5 File Offset: 0x000D41E5
	[CompilerGenerated]
	private static UnitClass <NakedDuplicate>m__8(UnitClass m)
	{
		return m;
	}

	// Token: 0x04001C02 RID: 7170
	public int NumberOfRounds;

	// Token: 0x04001C03 RID: 7171
	public int NumberOfMinionsPerRound;

	// Token: 0x04001C04 RID: 7172
	public List<MonsterAppearance> MinionSpawnTable;

	// Token: 0x04001C05 RID: 7173
	public List<MonsterAppearance> MiniBossSpawnTable;

	// Token: 0x04001C06 RID: 7174
	public List<MonsterAppearance> BossSpawnTable;

	// Token: 0x04001C07 RID: 7175
	public int EnemyAmountInBattleFromInclusive;

	// Token: 0x04001C08 RID: 7176
	public int EnemyAmountInBattleToExclusive;

	// Token: 0x04001C09 RID: 7177
	public double CompletionReputation;

	// Token: 0x04001C0A RID: 7178
	public List<FormationPresence> BossFormations;

	// Token: 0x04001C0B RID: 7179
	public List<FormationPresence> MiniBossFormation;

	// Token: 0x04001C0C RID: 7180
	public List<FormationPresence> MinionFormation;

	// Token: 0x04001C0D RID: 7181
	public List<ISpecialEffectDataLoad> DungeonEffects;

	// Token: 0x04001C0E RID: 7182
	public int LevelNumber;

	// Token: 0x04001C0F RID: 7183
	public string CustomizedIdentityCode;

	// Token: 0x04001C10 RID: 7184
	[CompilerGenerated]
	private static Func<FormationPresence, FormationPresence> <>f__am$cache0;

	// Token: 0x04001C11 RID: 7185
	[CompilerGenerated]
	private static Func<MonsterAppearance, MonsterAppearance> <>f__am$cache1;

	// Token: 0x04001C12 RID: 7186
	[CompilerGenerated]
	private static Func<MonsterAppearance, MonsterAppearance> <>f__am$cache2;

	// Token: 0x04001C13 RID: 7187
	[CompilerGenerated]
	private static Func<MonsterAppearance, MonsterAppearance> <>f__am$cache3;

	// Token: 0x04001C14 RID: 7188
	[CompilerGenerated]
	private static Func<FormationPresence, FormationPresence> <>f__am$cache4;

	// Token: 0x04001C15 RID: 7189
	[CompilerGenerated]
	private static Func<FormationPresence, FormationPresence> <>f__am$cache5;

	// Token: 0x04001C16 RID: 7190
	[CompilerGenerated]
	private static Func<UnitClass, UnitClass> <>f__am$cache6;

	// Token: 0x04001C17 RID: 7191
	[CompilerGenerated]
	private static Func<UnitClass, UnitClass> <>f__am$cache7;

	// Token: 0x04001C18 RID: 7192
	[CompilerGenerated]
	private static Func<UnitClass, UnitClass> <>f__am$cache8;

	// Token: 0x02000CEE RID: 3310
	[CompilerGenerated]
	private sealed class <GetMonsterConfig>c__AnonStorey0
	{
		// Token: 0x06005593 RID: 21907 RVA: 0x000D5DE8 File Offset: 0x000D41E8
		public <GetMonsterConfig>c__AnonStorey0()
		{
		}

		// Token: 0x06005594 RID: 21908 RVA: 0x000D5DF0 File Offset: 0x000D41F0
		internal bool <>m__0(MonsterAppearance b)
		{
			return b.UnitClass == this.unitClass;
		}

		// Token: 0x06005595 RID: 21909 RVA: 0x000D5E00 File Offset: 0x000D4200
		internal bool <>m__1(MonsterAppearance b)
		{
			return b.UnitClass == this.unitClass;
		}

		// Token: 0x06005596 RID: 21910 RVA: 0x000D5E10 File Offset: 0x000D4210
		internal bool <>m__2(MonsterAppearance b)
		{
			return b.UnitClass == this.unitClass;
		}

		// Token: 0x0400442C RID: 17452
		internal UnitClass unitClass;
	}
}
