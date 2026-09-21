using System;
using System.Collections.Generic;

// Token: 0x02000AB4 RID: 2740
public class ScreamingShamanConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x06004A05 RID: 18949 RVA: 0x001E81D6 File Offset: 0x001E65D6
	public ScreamingShamanConfiguration()
	{
	}

	// Token: 0x17000F79 RID: 3961
	// (get) Token: 0x06004A06 RID: 18950 RVA: 0x001E81DE File Offset: 0x001E65DE
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.ScreamingShaman;
		}
	}

	// Token: 0x17000F7A RID: 3962
	// (get) Token: 0x06004A07 RID: 18951 RVA: 0x001E81E5 File Offset: 0x001E65E5
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004A08 RID: 18952 RVA: 0x001E81E8 File Offset: 0x001E65E8
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		if (measurement.DifficultyValue < 5.0)
		{
			return new List<SkillType>();
		}
		if (measurement.DifficultyValue < 13.0)
		{
			return new List<SkillType>
			{
				SkillType.Arcane
			};
		}
		return new List<SkillType>
		{
			SkillType.Arcane,
			SkillType.Harmony
		};
	}
}
