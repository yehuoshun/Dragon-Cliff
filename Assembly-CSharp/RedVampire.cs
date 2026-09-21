using System;
using System.Collections.Generic;

// Token: 0x02000AB3 RID: 2739
public class RedVampire : MiniBossUnitConfigurationBase
{
	// Token: 0x06004A01 RID: 18945 RVA: 0x001E8197 File Offset: 0x001E6597
	public RedVampire()
	{
	}

	// Token: 0x17000F77 RID: 3959
	// (get) Token: 0x06004A02 RID: 18946 RVA: 0x001E819F File Offset: 0x001E659F
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedVampire;
		}
	}

	// Token: 0x17000F78 RID: 3960
	// (get) Token: 0x06004A03 RID: 18947 RVA: 0x001E81A6 File Offset: 0x001E65A6
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x06004A04 RID: 18948 RVA: 0x001E81AC File Offset: 0x001E65AC
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Meteorolite,
			SkillType.Flame
		};
	}
}
