using System;
using System.Collections.Generic;

// Token: 0x02000455 RID: 1109
public class BuriedTempleConfiguration : LevelConfigurationBase
{
	// Token: 0x06001F73 RID: 8051 RVA: 0x000DD689 File Offset: 0x000DBA89
	public BuriedTempleConfiguration()
	{
	}

	// Token: 0x170001C9 RID: 457
	// (get) Token: 0x06001F74 RID: 8052 RVA: 0x000DD6A0 File Offset: 0x000DBAA0
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return AdventureType.BuriedTemple;
		}
	}

	// Token: 0x170001CA RID: 458
	// (get) Token: 0x06001F75 RID: 8053 RVA: 0x000DD6A3 File Offset: 0x000DBAA3
	public override double StartingDifficultyLevel
	{
		get
		{
			return 40.0;
		}
	}

	// Token: 0x170001CB RID: 459
	// (get) Token: 0x06001F76 RID: 8054 RVA: 0x000DD6AE File Offset: 0x000DBAAE
	public override double EndingDifficultyLevel
	{
		get
		{
			return this._endingDifficultyLevel;
		}
	}

	// Token: 0x06001F77 RID: 8055 RVA: 0x000DD6B8 File Offset: 0x000DBAB8
	public override List<MonsterAppearance> GetPossibleMinionClasses(int dungeonLevel)
	{
		List<MonsterAppearance> list = new List<MonsterAppearance>
		{
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.GreenBat),
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.BlueBat)
		};
		if (dungeonLevel > 2)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.PurpleVampire)
			});
		}
		if (dungeonLevel > 5)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.RedBat)
			});
		}
		if (dungeonLevel > 10)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.YellowBat)
			});
		}
		return list;
	}

	// Token: 0x06001F78 RID: 8056 RVA: 0x000DD774 File Offset: 0x000DBB74
	public override List<MonsterAppearance> GetPossibleMinibossClasses(int dungeonLevel)
	{
		List<MonsterAppearance> list = new List<MonsterAppearance>
		{
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.GreenVampire)
		};
		if (dungeonLevel > 2)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.BlueVampire)
			});
		}
		if (dungeonLevel > 5)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.PurpleBat),
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.RedVampire)
			});
		}
		if (dungeonLevel > 10)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.YellowVampire)
			});
		}
		return list;
	}

	// Token: 0x06001F79 RID: 8057 RVA: 0x000DD830 File Offset: 0x000DBC30
	public override List<MonsterAppearance> GetPossibleBossClasses(int dungeonLevel)
	{
		List<MonsterAppearance> list = new List<MonsterAppearance>
		{
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.MagicAmor)
		};
		if (dungeonLevel > 2)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.EvilMask)
			});
		}
		if (dungeonLevel > 7)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.ShadowSkinner)
			});
		}
		if (dungeonLevel > 11)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.HeartEater)
			});
		}
		return list;
	}

	// Token: 0x04001C53 RID: 7251
	private double _endingDifficultyLevel = 250.0;
}
