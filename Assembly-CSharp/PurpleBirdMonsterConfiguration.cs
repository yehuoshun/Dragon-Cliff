using System;
using System.Collections.Generic;

// Token: 0x02000AA0 RID: 2720
public class PurpleBirdMonsterConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x060049B7 RID: 18871 RVA: 0x001E7D02 File Offset: 0x001E6102
	public PurpleBirdMonsterConfiguration()
	{
	}

	// Token: 0x17000F51 RID: 3921
	// (get) Token: 0x060049B8 RID: 18872 RVA: 0x001E7D0A File Offset: 0x001E610A
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleBirdMonster;
		}
	}

	// Token: 0x17000F52 RID: 3922
	// (get) Token: 0x060049B9 RID: 18873 RVA: 0x001E7D11 File Offset: 0x001E6111
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellSupporter;
		}
	}

	// Token: 0x060049BA RID: 18874 RVA: 0x001E7D18 File Offset: 0x001E6118
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Harmony
		};
	}
}
