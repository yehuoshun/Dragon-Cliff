using System;
using System.Collections.Generic;

// Token: 0x02000AAD RID: 2733
public class RedScorpion : MiniBossUnitConfigurationBase
{
	// Token: 0x060049EA RID: 18922 RVA: 0x001E8026 File Offset: 0x001E6426
	public RedScorpion()
	{
	}

	// Token: 0x17000F6B RID: 3947
	// (get) Token: 0x060049EB RID: 18923 RVA: 0x001E802E File Offset: 0x001E642E
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedScorpion;
		}
	}

	// Token: 0x17000F6C RID: 3948
	// (get) Token: 0x060049EC RID: 18924 RVA: 0x001E8035 File Offset: 0x001E6435
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}

	// Token: 0x060049ED RID: 18925 RVA: 0x001E8038 File Offset: 0x001E6438
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		if (measurement.DifficultyValue < 5.0)
		{
			return new List<SkillType>();
		}
		if (measurement.DifficultyValue < 16.0)
		{
			return new List<SkillType>
			{
				SkillType.Strike
			};
		}
		return new List<SkillType>
		{
			SkillType.Strike,
			SkillType.BloodThirst
		};
	}
}
