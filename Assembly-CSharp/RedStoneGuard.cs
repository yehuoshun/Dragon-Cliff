using System;
using System.Collections.Generic;

// Token: 0x02000AB2 RID: 2738
public class RedStoneGuard : MiniBossUnitConfigurationBase
{
	// Token: 0x060049FD RID: 18941 RVA: 0x001E8163 File Offset: 0x001E6563
	public RedStoneGuard()
	{
	}

	// Token: 0x17000F75 RID: 3957
	// (get) Token: 0x060049FE RID: 18942 RVA: 0x001E816B File Offset: 0x001E656B
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedStoneGuard;
		}
	}

	// Token: 0x17000F76 RID: 3958
	// (get) Token: 0x060049FF RID: 18943 RVA: 0x001E8172 File Offset: 0x001E6572
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}

	// Token: 0x06004A00 RID: 18944 RVA: 0x001E8178 File Offset: 0x001E6578
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Assassination
		};
	}
}
