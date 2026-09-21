using System;
using System.Collections.Generic;

// Token: 0x02000A9B RID: 2715
public class BlueStoneGuard : MiniBossUnitConfigurationBase
{
	// Token: 0x060049A3 RID: 18851 RVA: 0x001E7B97 File Offset: 0x001E5F97
	public BlueStoneGuard()
	{
	}

	// Token: 0x17000F47 RID: 3911
	// (get) Token: 0x060049A4 RID: 18852 RVA: 0x001E7B9F File Offset: 0x001E5F9F
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueStoneGuard;
		}
	}

	// Token: 0x17000F48 RID: 3912
	// (get) Token: 0x060049A5 RID: 18853 RVA: 0x001E7BA6 File Offset: 0x001E5FA6
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}

	// Token: 0x060049A6 RID: 18854 RVA: 0x001E7BAC File Offset: 0x001E5FAC
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Shadowless,
			SkillType.Swift
		};
	}

	// Token: 0x060049A7 RID: 18855 RVA: 0x001E7BD8 File Offset: 0x001E5FD8
	public override List<ISpecialEffectDataLoad> FurtherSpecialEffectsFilter(List<ISpecialEffectDataLoad> original, DifficultyLevelMeasurement relevantDifficultyLevelMeasurement)
	{
		if (relevantDifficultyLevelMeasurement.DifficultyValue > 100.0 || relevantDifficultyLevelMeasurement.StarRating != 1)
		{
			original.Add(new ExtraTargetingData
			{
				IsStarEf = new bool?(false),
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				},
				Extra = 2
			});
		}
		return original;
	}
}
