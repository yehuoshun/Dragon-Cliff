using System;
using System.Collections.Generic;

// Token: 0x02000AAF RID: 2735
public class RedShamanConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x060049F2 RID: 18930 RVA: 0x001E80E2 File Offset: 0x001E64E2
	public RedShamanConfiguration()
	{
	}

	// Token: 0x17000F6F RID: 3951
	// (get) Token: 0x060049F3 RID: 18931 RVA: 0x001E80EA File Offset: 0x001E64EA
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedShaman;
		}
	}

	// Token: 0x17000F70 RID: 3952
	// (get) Token: 0x060049F4 RID: 18932 RVA: 0x001E80F1 File Offset: 0x001E64F1
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellDefender;
		}
	}

	// Token: 0x060049F5 RID: 18933 RVA: 0x001E80F4 File Offset: 0x001E64F4
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.DivineLight,
			SkillType.Principle
		};
	}
}
