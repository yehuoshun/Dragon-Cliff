using System;
using System.Collections.Generic;

// Token: 0x02000AAB RID: 2731
public class RedGrassFaceConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x060049E2 RID: 18914 RVA: 0x001E7FB2 File Offset: 0x001E63B2
	public RedGrassFaceConfiguration()
	{
	}

	// Token: 0x17000F67 RID: 3943
	// (get) Token: 0x060049E3 RID: 18915 RVA: 0x001E7FBA File Offset: 0x001E63BA
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedGrassFace;
		}
	}

	// Token: 0x17000F68 RID: 3944
	// (get) Token: 0x060049E4 RID: 18916 RVA: 0x001E7FC1 File Offset: 0x001E63C1
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.Healer;
		}
	}

	// Token: 0x060049E5 RID: 18917 RVA: 0x001E7FC8 File Offset: 0x001E63C8
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.SeedsOfSin
		};
	}
}
