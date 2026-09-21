using System;
using System.Collections.Generic;

// Token: 0x02000AA7 RID: 2727
public class PurpleShamanConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x060049D2 RID: 18898 RVA: 0x001E7EA2 File Offset: 0x001E62A2
	public PurpleShamanConfiguration()
	{
	}

	// Token: 0x17000F5F RID: 3935
	// (get) Token: 0x060049D3 RID: 18899 RVA: 0x001E7EAA File Offset: 0x001E62AA
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleShaman;
		}
	}

	// Token: 0x17000F60 RID: 3936
	// (get) Token: 0x060049D4 RID: 18900 RVA: 0x001E7EB1 File Offset: 0x001E62B1
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x060049D5 RID: 18901 RVA: 0x001E7EB4 File Offset: 0x001E62B4
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		if (measurement.DifficultyValue < 5.0)
		{
			return new List<SkillType>();
		}
		return new List<SkillType>
		{
			SkillType.FireBurst,
			SkillType.LightFire
		};
	}
}
