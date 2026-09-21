using System;
using System.Collections.Generic;

// Token: 0x02000458 RID: 1112
public class MistForestConfiguration : LevelConfigurationBase
{
	// Token: 0x06001F8E RID: 8078 RVA: 0x000DE0BC File Offset: 0x000DC4BC
	public MistForestConfiguration()
	{
	}

	// Token: 0x170001D2 RID: 466
	// (get) Token: 0x06001F8F RID: 8079 RVA: 0x000DE0D3 File Offset: 0x000DC4D3
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return AdventureType.MistForest;
		}
	}

	// Token: 0x170001D3 RID: 467
	// (get) Token: 0x06001F90 RID: 8080 RVA: 0x000DE0D7 File Offset: 0x000DC4D7
	public override double StartingDifficultyLevel
	{
		get
		{
			return 10.0;
		}
	}

	// Token: 0x170001D4 RID: 468
	// (get) Token: 0x06001F91 RID: 8081 RVA: 0x000DE0E2 File Offset: 0x000DC4E2
	public override double EndingDifficultyLevel
	{
		get
		{
			return this._endingDifficultyLevel;
		}
	}

	// Token: 0x06001F92 RID: 8082 RVA: 0x000DE0EC File Offset: 0x000DC4EC
	public override List<MonsterAppearance> GetPossibleMinionClasses(int dungeonLevel)
	{
		List<MonsterAppearance> list = new List<MonsterAppearance>
		{
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.GreenBirdMonster),
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.GreenDoomFighter),
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.GreenShadowBat)
		};
		if (dungeonLevel > 2)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.GreenMud),
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.GreenHighMage),
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.BlueHighMage)
			});
		}
		if (dungeonLevel > 7)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.BlueDoomFighter),
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.BlueBirdMonster),
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.BlueShadowBat)
			});
		}
		if (dungeonLevel > 15)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.YellowBirdMonster),
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.YellowMud),
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.YellowShadowBat)
			});
		}
		return list;
	}

	// Token: 0x06001F93 RID: 8083 RVA: 0x000DE23C File Offset: 0x000DC63C
	public override List<MonsterAppearance> GetPossibleMinibossClasses(int dungeonLevel)
	{
		List<MonsterAppearance> list = new List<MonsterAppearance>
		{
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.PurpleBirdMonster)
		};
		if (dungeonLevel > 2)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.PurpleDoomFighter)
			});
		}
		if (dungeonLevel > 7)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.PurpleMud),
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.PurpleShadowBat)
			});
		}
		if (dungeonLevel > 15)
		{
			list.AddRange(new List<MonsterAppearance>());
		}
		return list;
	}

	// Token: 0x06001F94 RID: 8084 RVA: 0x000DE2E4 File Offset: 0x000DC6E4
	public override List<MonsterAppearance> GetPossibleBossClasses(int dungeonLevel)
	{
		List<MonsterAppearance> list = new List<MonsterAppearance>
		{
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.RedBirdMonster)
		};
		if (dungeonLevel > 4)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.RedDoomFighter),
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.GreenBerserker)
			});
		}
		if (dungeonLevel > 8)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.Berserker),
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.PurpleBerserker)
			});
		}
		if (dungeonLevel > 12)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.RedMud),
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.BlueBerserker)
			});
		}
		if (dungeonLevel > 16)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.HighestMonsterPresence, UnitClass.RedShadowBat)
			});
		}
		return list;
	}

	// Token: 0x04001C5B RID: 7259
	private double _endingDifficultyLevel = 250.0;
}
