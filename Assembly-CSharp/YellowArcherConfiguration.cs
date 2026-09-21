using System;
using System.Collections.Generic;

// Token: 0x02000AB8 RID: 2744
public class YellowArcherConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x06004A18 RID: 18968 RVA: 0x001E844D File Offset: 0x001E684D
	public YellowArcherConfiguration()
	{
	}

	// Token: 0x17000F81 RID: 3969
	// (get) Token: 0x06004A19 RID: 18969 RVA: 0x001E8455 File Offset: 0x001E6855
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowArcher;
		}
	}

	// Token: 0x17000F82 RID: 3970
	// (get) Token: 0x06004A1A RID: 18970 RVA: 0x001E845C File Offset: 0x001E685C
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004A1B RID: 18971 RVA: 0x001E8460 File Offset: 0x001E6860
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Relentless,
			SkillType.Principle
		};
	}
}
