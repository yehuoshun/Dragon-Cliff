using System;
using System.Collections.Generic;

// Token: 0x02000AA3 RID: 2723
public class PurpleGrassFaceConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x060049C2 RID: 18882 RVA: 0x001E7D9E File Offset: 0x001E619E
	public PurpleGrassFaceConfiguration()
	{
	}

	// Token: 0x17000F57 RID: 3927
	// (get) Token: 0x060049C3 RID: 18883 RVA: 0x001E7DA6 File Offset: 0x001E61A6
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleGrassFace;
		}
	}

	// Token: 0x17000F58 RID: 3928
	// (get) Token: 0x060049C4 RID: 18884 RVA: 0x001E7DAD File Offset: 0x001E61AD
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x060049C5 RID: 18885 RVA: 0x001E7DB0 File Offset: 0x001E61B0
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		if (measurement.DifficultyValue < 5.0)
		{
			return new List<SkillType>();
		}
		return new List<SkillType>
		{
			SkillType.Lightning,
			SkillType.Rage
		};
	}
}
