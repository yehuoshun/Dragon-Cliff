using System;
using System.Collections.Generic;

// Token: 0x02000459 RID: 1113
public class NorthernTerritoryConfiguration : LevelConfigurationBase
{
	// Token: 0x06001F95 RID: 8085 RVA: 0x000DE3F4 File Offset: 0x000DC7F4
	public NorthernTerritoryConfiguration()
	{
	}

	// Token: 0x170001D5 RID: 469
	// (get) Token: 0x06001F96 RID: 8086 RVA: 0x000DE3FC File Offset: 0x000DC7FC
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return AdventureType.NorthernTerritory;
		}
	}

	// Token: 0x170001D6 RID: 470
	// (get) Token: 0x06001F97 RID: 8087 RVA: 0x000DE400 File Offset: 0x000DC800
	public override double StartingDifficultyLevel
	{
		get
		{
			return 135.0;
		}
	}

	// Token: 0x170001D7 RID: 471
	// (get) Token: 0x06001F98 RID: 8088 RVA: 0x000DE40B File Offset: 0x000DC80B
	public override double EndingDifficultyLevel
	{
		get
		{
			return 250.0;
		}
	}

	// Token: 0x06001F99 RID: 8089 RVA: 0x000DE418 File Offset: 0x000DC818
	public override List<MonsterAppearance> GetPossibleMinionClasses(int dungeonLevel)
	{
		return new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.Thug1),
			new MonsterAppearance(100, UnitClass.Thug2),
			new MonsterAppearance(100, UnitClass.Thug3),
			new MonsterAppearance(100, UnitClass.Thug4),
			new MonsterAppearance(100, UnitClass.Thug5),
			new MonsterAppearance(100, UnitClass.Thug6)
		};
	}

	// Token: 0x06001F9A RID: 8090 RVA: 0x000DE498 File Offset: 0x000DC898
	public override List<MonsterAppearance> GetPossibleMinibossClasses(int dungeonLevel)
	{
		return new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.ThugLeader1),
			new MonsterAppearance(100, UnitClass.ThugLeader2),
			new MonsterAppearance(100, UnitClass.ThugLeader3)
		};
	}

	// Token: 0x06001F9B RID: 8091 RVA: 0x000DE4E4 File Offset: 0x000DC8E4
	public override List<MonsterAppearance> GetPossibleBossClasses(int dungeonLevel)
	{
		return new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.ThugBoss1),
			new MonsterAppearance(100, UnitClass.ThugBoss2)
		};
	}
}
