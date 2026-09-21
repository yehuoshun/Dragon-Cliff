using System;
using System.Collections.Generic;

// Token: 0x02000A93 RID: 2707
public class YellowDragonPrayerConfiguration : SnowMountainBossConfiguration
{
	// Token: 0x0600497F RID: 18815 RVA: 0x001E4E22 File Offset: 0x001E3222
	public YellowDragonPrayerConfiguration()
	{
	}

	// Token: 0x17000F3B RID: 3899
	// (get) Token: 0x06004980 RID: 18816 RVA: 0x001E4E2A File Offset: 0x001E322A
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowDragonPrayer;
		}
	}

	// Token: 0x17000F3C RID: 3900
	// (get) Token: 0x06004981 RID: 18817 RVA: 0x001E4E31 File Offset: 0x001E3231
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004982 RID: 18818 RVA: 0x001E4E34 File Offset: 0x001E3234
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Divine;
	}

	// Token: 0x06004983 RID: 18819 RVA: 0x001E4E38 File Offset: 0x001E3238
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.CurseOfCube,
			SkillType.Flame
		};
	}
}
