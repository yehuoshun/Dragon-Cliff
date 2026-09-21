using System;
using System.Collections.Generic;

// Token: 0x02000A7B RID: 2683
public class BloodDevil : HellishPathBossConfigurationBase
{
	// Token: 0x06004909 RID: 18697 RVA: 0x001E374F File Offset: 0x001E1B4F
	public BloodDevil()
	{
	}

	// Token: 0x17000F0B RID: 3851
	// (get) Token: 0x0600490A RID: 18698 RVA: 0x001E3757 File Offset: 0x001E1B57
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BloodDevil;
		}
	}

	// Token: 0x17000F0C RID: 3852
	// (get) Token: 0x0600490B RID: 18699 RVA: 0x001E375E File Offset: 0x001E1B5E
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalSupporter;
		}
	}

	// Token: 0x0600490C RID: 18700 RVA: 0x001E3764 File Offset: 0x001E1B64
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new ExtraTargetingData
				{
					IsStarEf = new bool?(false),
					CandidateTypes = new List<TargetCandidateType>
					{
						TargetCandidateType.HostileAlive
					},
					Extra = 3
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new ExtraTargetingData
			{
				Extra = 1,
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				}
			}
		};
	}

	// Token: 0x0600490D RID: 18701 RVA: 0x001E37E8 File Offset: 0x001E1BE8
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating == 2)
		{
			return new List<SkillType>
			{
				SkillType.Strike,
				SkillType.Stray,
				SkillType.FleshToStone
			};
		}
		return new List<SkillType>
		{
			SkillType.Strike
		};
	}
}
