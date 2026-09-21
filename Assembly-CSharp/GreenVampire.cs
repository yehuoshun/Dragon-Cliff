using System;
using System.Collections.Generic;

// Token: 0x02000A9E RID: 2718
public class GreenVampire : MiniBossUnitConfigurationBase
{
	// Token: 0x060049AF RID: 18863 RVA: 0x001E7C88 File Offset: 0x001E6088
	public GreenVampire()
	{
	}

	// Token: 0x17000F4D RID: 3917
	// (get) Token: 0x060049B0 RID: 18864 RVA: 0x001E7C90 File Offset: 0x001E6090
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GreenVampire;
		}
	}

	// Token: 0x17000F4E RID: 3918
	// (get) Token: 0x060049B1 RID: 18865 RVA: 0x001E7C97 File Offset: 0x001E6097
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x060049B2 RID: 18866 RVA: 0x001E7C9C File Offset: 0x001E609C
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Arcane,
			SkillType.Flame
		};
	}
}
