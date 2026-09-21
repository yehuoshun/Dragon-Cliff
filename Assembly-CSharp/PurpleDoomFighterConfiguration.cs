using System;
using System.Collections.Generic;

// Token: 0x02000AA2 RID: 2722
public class PurpleDoomFighterConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x060049BE RID: 18878 RVA: 0x001E7D61 File Offset: 0x001E6161
	public PurpleDoomFighterConfiguration()
	{
	}

	// Token: 0x17000F55 RID: 3925
	// (get) Token: 0x060049BF RID: 18879 RVA: 0x001E7D69 File Offset: 0x001E6169
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleDoomFighter;
		}
	}

	// Token: 0x17000F56 RID: 3926
	// (get) Token: 0x060049C0 RID: 18880 RVA: 0x001E7D70 File Offset: 0x001E6170
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalDefender;
		}
	}

	// Token: 0x060049C1 RID: 18881 RVA: 0x001E7D74 File Offset: 0x001E6174
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Taunt,
			SkillType.Stray
		};
	}
}
