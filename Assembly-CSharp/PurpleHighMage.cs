using System;
using System.Collections.Generic;

// Token: 0x02000AA4 RID: 2724
public class PurpleHighMage : MiniBossUnitConfigurationBase
{
	// Token: 0x060049C6 RID: 18886 RVA: 0x001E7DF4 File Offset: 0x001E61F4
	public PurpleHighMage()
	{
	}

	// Token: 0x17000F59 RID: 3929
	// (get) Token: 0x060049C7 RID: 18887 RVA: 0x001E7DFC File Offset: 0x001E61FC
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleHighMage;
		}
	}

	// Token: 0x17000F5A RID: 3930
	// (get) Token: 0x060049C8 RID: 18888 RVA: 0x001E7E03 File Offset: 0x001E6203
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.Healer;
		}
	}

	// Token: 0x060049C9 RID: 18889 RVA: 0x001E7E08 File Offset: 0x001E6208
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Lightning
		};
	}
}
