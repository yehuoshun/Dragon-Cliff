using System;
using System.Collections.Generic;

// Token: 0x02000AA9 RID: 2729
public class RedArcherConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x060049DA RID: 18906 RVA: 0x001E7F36 File Offset: 0x001E6336
	public RedArcherConfiguration()
	{
	}

	// Token: 0x17000F63 RID: 3939
	// (get) Token: 0x060049DB RID: 18907 RVA: 0x001E7F3E File Offset: 0x001E633E
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedArcher;
		}
	}

	// Token: 0x17000F64 RID: 3940
	// (get) Token: 0x060049DC RID: 18908 RVA: 0x001E7F45 File Offset: 0x001E6345
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}

	// Token: 0x060049DD RID: 18909 RVA: 0x001E7F48 File Offset: 0x001E6348
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.StealSoul,
			SkillType.Rebirth
		};
	}
}
