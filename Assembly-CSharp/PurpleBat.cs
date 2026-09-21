using System;
using System.Collections.Generic;

// Token: 0x02000A9F RID: 2719
public class PurpleBat : MiniBossUnitConfigurationBase
{
	// Token: 0x060049B3 RID: 18867 RVA: 0x001E7CC6 File Offset: 0x001E60C6
	public PurpleBat()
	{
	}

	// Token: 0x17000F4F RID: 3919
	// (get) Token: 0x060049B4 RID: 18868 RVA: 0x001E7CCE File Offset: 0x001E60CE
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleBat;
		}
	}

	// Token: 0x17000F50 RID: 3920
	// (get) Token: 0x060049B5 RID: 18869 RVA: 0x001E7CD5 File Offset: 0x001E60D5
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x060049B6 RID: 18870 RVA: 0x001E7CD8 File Offset: 0x001E60D8
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.ShadowSacrifice,
			SkillType.Harmony
		};
	}
}
