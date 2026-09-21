using System;
using System.Collections.Generic;

// Token: 0x02000AAE RID: 2734
public class RedShadowKillerConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x060049EE RID: 18926 RVA: 0x001E80A3 File Offset: 0x001E64A3
	public RedShadowKillerConfiguration()
	{
	}

	// Token: 0x17000F6D RID: 3949
	// (get) Token: 0x060049EF RID: 18927 RVA: 0x001E80AB File Offset: 0x001E64AB
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedShadowKiller;
		}
	}

	// Token: 0x17000F6E RID: 3950
	// (get) Token: 0x060049F0 RID: 18928 RVA: 0x001E80B2 File Offset: 0x001E64B2
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x060049F1 RID: 18929 RVA: 0x001E80B8 File Offset: 0x001E64B8
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.SeedsOfSin,
			SkillType.Rebirth
		};
	}
}
