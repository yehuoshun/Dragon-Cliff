using System;
using System.Collections.Generic;

// Token: 0x02000A90 RID: 2704
public class ShadowSkinner : BuriedTempleBossConfigurationBase
{
	// Token: 0x06004973 RID: 18803 RVA: 0x001E4C6E File Offset: 0x001E306E
	public ShadowSkinner()
	{
	}

	// Token: 0x17000F35 RID: 3893
	// (get) Token: 0x06004974 RID: 18804 RVA: 0x001E4C76 File Offset: 0x001E3076
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.ShadowSkinner;
		}
	}

	// Token: 0x17000F36 RID: 3894
	// (get) Token: 0x06004975 RID: 18805 RVA: 0x001E4C7D File Offset: 0x001E307D
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}

	// Token: 0x06004976 RID: 18806 RVA: 0x001E4C80 File Offset: 0x001E3080
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.SpellSlayer,
			SkillType.Rage
		};
	}
}
