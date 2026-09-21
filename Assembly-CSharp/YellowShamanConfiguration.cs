using System;
using System.Collections.Generic;

// Token: 0x02000ABC RID: 2748
public class YellowShamanConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x06004A28 RID: 18984 RVA: 0x001E853E File Offset: 0x001E693E
	public YellowShamanConfiguration()
	{
	}

	// Token: 0x17000F89 RID: 3977
	// (get) Token: 0x06004A29 RID: 18985 RVA: 0x001E8546 File Offset: 0x001E6946
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowShaman;
		}
	}

	// Token: 0x17000F8A RID: 3978
	// (get) Token: 0x06004A2A RID: 18986 RVA: 0x001E854D File Offset: 0x001E694D
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x06004A2B RID: 18987 RVA: 0x001E8550 File Offset: 0x001E6950
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Freeze,
			SkillType.Flame
		};
	}
}
