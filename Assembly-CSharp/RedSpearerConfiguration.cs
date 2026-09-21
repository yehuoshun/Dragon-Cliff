using System;
using System.Collections.Generic;

// Token: 0x02000AB1 RID: 2737
public class RedSpearerConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x060049F9 RID: 18937 RVA: 0x001E8130 File Offset: 0x001E6530
	public RedSpearerConfiguration()
	{
	}

	// Token: 0x17000F73 RID: 3955
	// (get) Token: 0x060049FA RID: 18938 RVA: 0x001E8138 File Offset: 0x001E6538
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedSpearer;
		}
	}

	// Token: 0x17000F74 RID: 3956
	// (get) Token: 0x060049FB RID: 18939 RVA: 0x001E813F File Offset: 0x001E653F
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x060049FC RID: 18940 RVA: 0x001E8144 File Offset: 0x001E6544
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.BladeRain
		};
	}
}
