using System;
using System.Collections.Generic;

// Token: 0x02000ABD RID: 2749
public class YellowStoneGuard : MiniBossUnitConfigurationBase
{
	// Token: 0x06004A2C RID: 18988 RVA: 0x001E857A File Offset: 0x001E697A
	public YellowStoneGuard()
	{
	}

	// Token: 0x17000F8B RID: 3979
	// (get) Token: 0x06004A2D RID: 18989 RVA: 0x001E8582 File Offset: 0x001E6982
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowStoneGuard;
		}
	}

	// Token: 0x17000F8C RID: 3980
	// (get) Token: 0x06004A2E RID: 18990 RVA: 0x001E8589 File Offset: 0x001E6989
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.Protector;
		}
	}

	// Token: 0x06004A2F RID: 18991 RVA: 0x001E858C File Offset: 0x001E698C
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.StealSoul
		};
	}
}
