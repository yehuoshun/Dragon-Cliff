using System;
using System.Collections.Generic;

// Token: 0x02000AA5 RID: 2725
public class PurpleMudConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x060049CA RID: 18890 RVA: 0x001E7E27 File Offset: 0x001E6227
	public PurpleMudConfiguration()
	{
	}

	// Token: 0x17000F5B RID: 3931
	// (get) Token: 0x060049CB RID: 18891 RVA: 0x001E7E2F File Offset: 0x001E622F
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleMud;
		}
	}

	// Token: 0x17000F5C RID: 3932
	// (get) Token: 0x060049CC RID: 18892 RVA: 0x001E7E36 File Offset: 0x001E6236
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellDefender;
		}
	}

	// Token: 0x060049CD RID: 18893 RVA: 0x001E7E3C File Offset: 0x001E623C
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Taunt,
			SkillType.Rage
		};
	}
}
