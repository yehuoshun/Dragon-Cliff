using System;
using System.Collections.Generic;

// Token: 0x02000AAC RID: 2732
public class RedReaperConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x060049E6 RID: 18918 RVA: 0x001E7FE7 File Offset: 0x001E63E7
	public RedReaperConfiguration()
	{
	}

	// Token: 0x17000F69 RID: 3945
	// (get) Token: 0x060049E7 RID: 18919 RVA: 0x001E7FEF File Offset: 0x001E63EF
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedReaper;
		}
	}

	// Token: 0x17000F6A RID: 3946
	// (get) Token: 0x060049E8 RID: 18920 RVA: 0x001E7FF6 File Offset: 0x001E63F6
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x060049E9 RID: 18921 RVA: 0x001E7FFC File Offset: 0x001E63FC
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.WillOfFight,
			SkillType.Principle
		};
	}
}
