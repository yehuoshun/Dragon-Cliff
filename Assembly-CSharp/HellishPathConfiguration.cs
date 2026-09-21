using System;
using System.Collections.Generic;

// Token: 0x02000456 RID: 1110
public class HellishPathConfiguration : LevelConfigurationBase
{
	// Token: 0x06001F7A RID: 8058 RVA: 0x000DD8D7 File Offset: 0x000DBCD7
	public HellishPathConfiguration()
	{
	}

	// Token: 0x170001CC RID: 460
	// (get) Token: 0x06001F7B RID: 8059 RVA: 0x000DD8EE File Offset: 0x000DBCEE
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return AdventureType.HellishPath;
		}
	}

	// Token: 0x170001CD RID: 461
	// (get) Token: 0x06001F7C RID: 8060 RVA: 0x000DD8F2 File Offset: 0x000DBCF2
	public override double StartingDifficultyLevel
	{
		get
		{
			return 55.0;
		}
	}

	// Token: 0x170001CE RID: 462
	// (get) Token: 0x06001F7D RID: 8061 RVA: 0x000DD8FD File Offset: 0x000DBCFD
	public override double EndingDifficultyLevel
	{
		get
		{
			return this._endingDifficultyLevel;
		}
	}

	// Token: 0x06001F7E RID: 8062 RVA: 0x000DD908 File Offset: 0x000DBD08
	public override List<MonsterAppearance> GetPossibleMinionClasses(int dungeonLevel)
	{
		List<MonsterAppearance> list = new List<MonsterAppearance>
		{
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.GreenGoblinWizard),
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.BlackMage),
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.GreenDevil)
		};
		if (dungeonLevel > 2)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.BlueGoblinWizard),
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.Alchemist)
			});
		}
		if (dungeonLevel > 5)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.PurpleGoblinWizard)
			});
		}
		if (dungeonLevel > 10)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.RedGoblinWizard)
			});
		}
		return list;
	}

	// Token: 0x06001F7F RID: 8063 RVA: 0x000DD9F0 File Offset: 0x000DBDF0
	public override List<MonsterAppearance> GetPossibleMinibossClasses(int dungeonLevel)
	{
		List<MonsterAppearance> list = new List<MonsterAppearance>
		{
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.YellowGoblinWizard)
		};
		if (dungeonLevel > 2)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.BlueStoneGuard)
			});
		}
		if (dungeonLevel > 5)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.PurpleStoneGuard)
			});
		}
		if (dungeonLevel > 10)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.RedStoneGuard),
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.YellowStoneGuard)
			});
		}
		return list;
	}

	// Token: 0x06001F80 RID: 8064 RVA: 0x000DDAAC File Offset: 0x000DBEAC
	public override List<MonsterAppearance> GetPossibleBossClasses(int dungeonLevel)
	{
		List<MonsterAppearance> list = new List<MonsterAppearance>
		{
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.GreenStoneGuard)
		};
		if (dungeonLevel > 5)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.BloodDevil)
			});
		}
		if (dungeonLevel > 15)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.DivineMage)
			});
		}
		if (dungeonLevel > 25)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.HighestMonsterPresence, UnitClass.IceSkull)
			});
		}
		return list;
	}

	// Token: 0x04001C54 RID: 7252
	private double _endingDifficultyLevel = 250.0;
}
