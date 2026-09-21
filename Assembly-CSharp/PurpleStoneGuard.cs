using System;
using System.Collections.Generic;

// Token: 0x02000AA8 RID: 2728
public class PurpleStoneGuard : MiniBossUnitConfigurationBase
{
	// Token: 0x060049D6 RID: 18902 RVA: 0x001E7EF8 File Offset: 0x001E62F8
	public PurpleStoneGuard()
	{
	}

	// Token: 0x17000F61 RID: 3937
	// (get) Token: 0x060049D7 RID: 18903 RVA: 0x001E7F00 File Offset: 0x001E6300
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleStoneGuard;
		}
	}

	// Token: 0x17000F62 RID: 3938
	// (get) Token: 0x060049D8 RID: 18904 RVA: 0x001E7F07 File Offset: 0x001E6307
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x060049D9 RID: 18905 RVA: 0x001E7F0C File Offset: 0x001E630C
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Scorn,
			SkillType.Swift
		};
	}
}
