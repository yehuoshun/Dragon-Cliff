using System;
using System.Collections.Generic;

// Token: 0x02000A91 RID: 2705
public class ThugBoss1 : NorthernTerritoryBossConfiguration
{
	// Token: 0x06004977 RID: 18807 RVA: 0x001E4DAA File Offset: 0x001E31AA
	public ThugBoss1()
	{
	}

	// Token: 0x17000F37 RID: 3895
	// (get) Token: 0x06004978 RID: 18808 RVA: 0x001E4DB2 File Offset: 0x001E31B2
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.ThugBoss1;
		}
	}

	// Token: 0x17000F38 RID: 3896
	// (get) Token: 0x06004979 RID: 18809 RVA: 0x001E4DB9 File Offset: 0x001E31B9
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x0600497A RID: 18810 RVA: 0x001E4DBC File Offset: 0x001E31BC
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Roar,
			SkillType.Stray
		};
	}
}
