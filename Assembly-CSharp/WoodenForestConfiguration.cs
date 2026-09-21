using System;
using System.Collections.Generic;

// Token: 0x0200045B RID: 1115
public class WoodenForestConfiguration : LevelConfigurationBase
{
	// Token: 0x06001FA3 RID: 8099 RVA: 0x000DE82C File Offset: 0x000DCC2C
	public WoodenForestConfiguration()
	{
	}

	// Token: 0x170001DB RID: 475
	// (get) Token: 0x06001FA4 RID: 8100 RVA: 0x000DE843 File Offset: 0x000DCC43
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return AdventureType.WoodenForest;
		}
	}

	// Token: 0x170001DC RID: 476
	// (get) Token: 0x06001FA5 RID: 8101 RVA: 0x000DE846 File Offset: 0x000DCC46
	public override double StartingDifficultyLevel
	{
		get
		{
			return 0.0;
		}
	}

	// Token: 0x170001DD RID: 477
	// (get) Token: 0x06001FA6 RID: 8102 RVA: 0x000DE851 File Offset: 0x000DCC51
	public override double EndingDifficultyLevel
	{
		get
		{
			return this._endingDifficultyLevel;
		}
	}

	// Token: 0x06001FA7 RID: 8103 RVA: 0x000DE85C File Offset: 0x000DCC5C
	public override List<MonsterAppearance> GetPossibleMinionClasses(int dungeonLevel)
	{
		List<MonsterAppearance> list = new List<MonsterAppearance>
		{
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.BlueShaman),
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.BlueSharpTeeth)
		};
		if (dungeonLevel > 3)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.BlueGrassFace),
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.GreenScorpion)
			});
		}
		if (dungeonLevel > 7)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.SharpTeeth),
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.BlueScorpion)
			});
		}
		if (dungeonLevel > 15)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.YellowGrassFace),
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.YellowSharpTeeth),
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.PurpleScorpion)
			});
		}
		return list;
	}

	// Token: 0x06001FA8 RID: 8104 RVA: 0x000DE96C File Offset: 0x000DCD6C
	public override List<MonsterAppearance> GetPossibleMinibossClasses(int dungeonLevel)
	{
		List<MonsterAppearance> list = new List<MonsterAppearance>
		{
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.ScreamingShaman)
		};
		if (dungeonLevel > 3)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.PurpleGrassFace),
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.PurpleShaman),
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.RedScorpion)
			});
		}
		if (dungeonLevel > 7)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.RedGrassFace),
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.RedShaman)
			});
		}
		if (dungeonLevel > 15)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.PurpleShaman),
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.YellowShaman),
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.YellowScorpion)
			});
		}
		return list;
	}

	// Token: 0x06001FA9 RID: 8105 RVA: 0x000DEA7C File Offset: 0x000DCE7C
	public override List<MonsterAppearance> GetPossibleBossClasses(int dungeonLevel)
	{
		List<MonsterAppearance> list = new List<MonsterAppearance>
		{
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.GreenOrc)
		};
		if (dungeonLevel > 7)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.PurpleOrc)
			});
		}
		if (dungeonLevel > 15)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.BlueOrc)
			});
		}
		if (dungeonLevel >= 20)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.RedOrc)
			});
		}
		if (dungeonLevel >= 25)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.HighestMonsterPresence, UnitClass.YellowOrc)
			});
		}
		return list;
	}

	// Token: 0x04001C5D RID: 7261
	private double _endingDifficultyLevel = 250.0;
}
