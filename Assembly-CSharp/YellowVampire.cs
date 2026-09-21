using System;
using System.Collections.Generic;

// Token: 0x02000ABE RID: 2750
public class YellowVampire : MiniBossUnitConfigurationBase
{
	// Token: 0x06004A30 RID: 18992 RVA: 0x001E85AB File Offset: 0x001E69AB
	public YellowVampire()
	{
	}

	// Token: 0x17000F8D RID: 3981
	// (get) Token: 0x06004A31 RID: 18993 RVA: 0x001E85C5 File Offset: 0x001E69C5
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return this._correspondingUnitClass;
		}
	}

	// Token: 0x17000F8E RID: 3982
	// (get) Token: 0x06004A32 RID: 18994 RVA: 0x001E85CD File Offset: 0x001E69CD
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return this._correspondingClassStyle;
		}
	}

	// Token: 0x06004A33 RID: 18995 RVA: 0x001E85D8 File Offset: 0x001E69D8
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Stun,
			SkillType.Stray
		};
	}

	// Token: 0x04003A92 RID: 14994
	private UnitClass _correspondingUnitClass = UnitClass.YellowVampire;

	// Token: 0x04003A93 RID: 14995
	private UnitClassStyle _correspondingClassStyle = UnitClassStyle.PhysicalKiller;
}
