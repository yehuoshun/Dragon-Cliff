using System;
using System.Collections.Generic;

// Token: 0x02000AB9 RID: 2745
public class YellowGoblinWizard : MiniBossUnitConfigurationBase
{
	// Token: 0x06004A1C RID: 18972 RVA: 0x001E848A File Offset: 0x001E688A
	public YellowGoblinWizard()
	{
	}

	// Token: 0x17000F83 RID: 3971
	// (get) Token: 0x06004A1D RID: 18973 RVA: 0x001E8492 File Offset: 0x001E6892
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowGoblinWizard;
		}
	}

	// Token: 0x17000F84 RID: 3972
	// (get) Token: 0x06004A1E RID: 18974 RVA: 0x001E8499 File Offset: 0x001E6899
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellDefender;
		}
	}

	// Token: 0x06004A1F RID: 18975 RVA: 0x001E849C File Offset: 0x001E689C
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Confusion,
			SkillType.LightFire
		};
	}
}
