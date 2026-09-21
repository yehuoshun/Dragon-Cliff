using System;
using System.Collections.Generic;

// Token: 0x02000AAA RID: 2730
public class RedDragonPrayerConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x060049DE RID: 18910 RVA: 0x001E7F72 File Offset: 0x001E6372
	public RedDragonPrayerConfiguration()
	{
	}

	// Token: 0x17000F65 RID: 3941
	// (get) Token: 0x060049DF RID: 18911 RVA: 0x001E7F7A File Offset: 0x001E637A
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedDragonPrayer;
		}
	}

	// Token: 0x17000F66 RID: 3942
	// (get) Token: 0x060049E0 RID: 18912 RVA: 0x001E7F81 File Offset: 0x001E6381
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.Healer;
		}
	}

	// Token: 0x060049E1 RID: 18913 RVA: 0x001E7F88 File Offset: 0x001E6388
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.DivineHammer,
			SkillType.Harmony
		};
	}
}
