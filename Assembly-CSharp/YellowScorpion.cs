using System;
using System.Collections.Generic;

// Token: 0x02000ABB RID: 2747
public class YellowScorpion : MiniBossUnitConfigurationBase
{
	// Token: 0x06004A24 RID: 18980 RVA: 0x001E8502 File Offset: 0x001E6902
	public YellowScorpion()
	{
	}

	// Token: 0x17000F87 RID: 3975
	// (get) Token: 0x06004A25 RID: 18981 RVA: 0x001E850A File Offset: 0x001E690A
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowScorpion;
		}
	}

	// Token: 0x17000F88 RID: 3976
	// (get) Token: 0x06004A26 RID: 18982 RVA: 0x001E8511 File Offset: 0x001E6911
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004A27 RID: 18983 RVA: 0x001E8514 File Offset: 0x001E6914
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Taunt,
			SkillType.BloodThirst
		};
	}
}
