using System;
using System.Collections.Generic;

// Token: 0x0200045A RID: 1114
public class SnowMountainConfiguration : LevelConfigurationBase
{
	// Token: 0x06001F9C RID: 8092 RVA: 0x000DE51C File Offset: 0x000DC91C
	public SnowMountainConfiguration()
	{
	}

	// Token: 0x170001D8 RID: 472
	// (get) Token: 0x06001F9D RID: 8093 RVA: 0x000DE533 File Offset: 0x000DC933
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return AdventureType.SnowMountain;
		}
	}

	// Token: 0x170001D9 RID: 473
	// (get) Token: 0x06001F9E RID: 8094 RVA: 0x000DE537 File Offset: 0x000DC937
	public override double StartingDifficultyLevel
	{
		get
		{
			return 20.0;
		}
	}

	// Token: 0x170001DA RID: 474
	// (get) Token: 0x06001F9F RID: 8095 RVA: 0x000DE542 File Offset: 0x000DC942
	public override double EndingDifficultyLevel
	{
		get
		{
			return this._endingDifficultyLevel;
		}
	}

	// Token: 0x06001FA0 RID: 8096 RVA: 0x000DE54C File Offset: 0x000DC94C
	public override List<MonsterAppearance> GetPossibleMinionClasses(int dungeonLevel)
	{
		List<MonsterAppearance> list = new List<MonsterAppearance>
		{
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.GreenReaper),
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.GreenSpearer)
		};
		if (dungeonLevel > 2)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.GreenDragonPrayer),
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.BlueArcher),
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.BlueShadowKiller)
			});
		}
		if (dungeonLevel > 5)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.BlueDragonPrayer),
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.PurpleArcher)
			});
		}
		if (dungeonLevel > 10)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.PurpleReaper),
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.PurpleShadowKiller),
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.PurpleSpearer),
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.PurpleDragonPrayer)
			});
		}
		return list;
	}

	// Token: 0x06001FA1 RID: 8097 RVA: 0x000DE688 File Offset: 0x000DCA88
	public override List<MonsterAppearance> GetPossibleMinibossClasses(int dungeonLevel)
	{
		List<MonsterAppearance> list = new List<MonsterAppearance>
		{
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.RedArcher),
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.RedReaper)
		};
		if (dungeonLevel > 2)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.RedShadowKiller),
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.RedSpearer),
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.PurpleHighMage)
			});
		}
		if (dungeonLevel > 5)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.RedDragonPrayer)
			});
		}
		if (dungeonLevel > 10)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.YellowArcher),
				new MonsterAppearance(LevelConfigurationBase.HighMonsterPresence, UnitClass.YellowReaper)
			});
		}
		return list;
	}

	// Token: 0x06001FA2 RID: 8098 RVA: 0x000DE784 File Offset: 0x000DCB84
	public override List<MonsterAppearance> GetPossibleBossClasses(int dungeonLevel)
	{
		List<MonsterAppearance> list = new List<MonsterAppearance>
		{
			new MonsterAppearance(LevelConfigurationBase.LowestLevelMonsterPresence, UnitClass.RedHighMage)
		};
		if (dungeonLevel > 5)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.YellowDragonPrayer),
				new MonsterAppearance(LevelConfigurationBase.LowLevelMonsterPresence, UnitClass.YellowHighMage)
			});
		}
		if (dungeonLevel > 10)
		{
			list.AddRange(new List<MonsterAppearance>
			{
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.YellowSpearer),
				new MonsterAppearance(LevelConfigurationBase.MediumMonsterPresence, UnitClass.YellowShadowKiller)
			});
		}
		return list;
	}

	// Token: 0x04001C5C RID: 7260
	private double _endingDifficultyLevel = 250.0;
}
