using System;
using System.Collections.Generic;

// Token: 0x02000AA6 RID: 2726
public class PurpleShadowBatConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x060049CE RID: 18894 RVA: 0x001E7E66 File Offset: 0x001E6266
	public PurpleShadowBatConfiguration()
	{
	}

	// Token: 0x17000F5D RID: 3933
	// (get) Token: 0x060049CF RID: 18895 RVA: 0x001E7E6E File Offset: 0x001E626E
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleShadowBat;
		}
	}

	// Token: 0x17000F5E RID: 3934
	// (get) Token: 0x060049D0 RID: 18896 RVA: 0x001E7E75 File Offset: 0x001E6275
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x060049D1 RID: 18897 RVA: 0x001E7E78 File Offset: 0x001E6278
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.FireBlast,
			SkillType.Harmony
		};
	}
}
