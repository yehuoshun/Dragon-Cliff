using System;
using System.Collections.Generic;

// Token: 0x02000A9C RID: 2716
public class BlueVampire : MiniBossUnitConfigurationBase
{
	// Token: 0x060049A8 RID: 18856 RVA: 0x001E7C3A File Offset: 0x001E603A
	public BlueVampire()
	{
	}

	// Token: 0x17000F49 RID: 3913
	// (get) Token: 0x060049A9 RID: 18857 RVA: 0x001E7C42 File Offset: 0x001E6042
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueVampire;
		}
	}

	// Token: 0x17000F4A RID: 3914
	// (get) Token: 0x060049AA RID: 18858 RVA: 0x001E7C49 File Offset: 0x001E6049
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x060049AB RID: 18859 RVA: 0x001E7C4C File Offset: 0x001E604C
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.ChargedBolt,
			SkillType.ReturningSoul
		};
	}
}
