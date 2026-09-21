using System;
using System.Collections.Generic;

// Token: 0x02000ABA RID: 2746
public class YellowReaperConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x06004A20 RID: 18976 RVA: 0x001E84C6 File Offset: 0x001E68C6
	public YellowReaperConfiguration()
	{
	}

	// Token: 0x17000F85 RID: 3973
	// (get) Token: 0x06004A21 RID: 18977 RVA: 0x001E84CE File Offset: 0x001E68CE
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowReaper;
		}
	}

	// Token: 0x17000F86 RID: 3974
	// (get) Token: 0x06004A22 RID: 18978 RVA: 0x001E84D5 File Offset: 0x001E68D5
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}

	// Token: 0x06004A23 RID: 18979 RVA: 0x001E84D8 File Offset: 0x001E68D8
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.MultiStrike,
			SkillType.Rage
		};
	}
}
