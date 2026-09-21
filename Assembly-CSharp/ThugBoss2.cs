using System;
using System.Collections.Generic;

// Token: 0x02000A92 RID: 2706
public class ThugBoss2 : NorthernTerritoryBossConfiguration
{
	// Token: 0x0600497B RID: 18811 RVA: 0x001E4DE6 File Offset: 0x001E31E6
	public ThugBoss2()
	{
	}

	// Token: 0x17000F39 RID: 3897
	// (get) Token: 0x0600497C RID: 18812 RVA: 0x001E4DEE File Offset: 0x001E31EE
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.ThugBoss2;
		}
	}

	// Token: 0x17000F3A RID: 3898
	// (get) Token: 0x0600497D RID: 18813 RVA: 0x001E4DF5 File Offset: 0x001E31F5
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x0600497E RID: 18814 RVA: 0x001E4DF8 File Offset: 0x001E31F8
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Scorn,
			SkillType.Stray
		};
	}
}
