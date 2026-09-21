using System;
using System.Collections.Generic;

// Token: 0x02000A84 RID: 2692
public class IceSkull : HellishPathBossConfigurationBase
{
	// Token: 0x06004936 RID: 18742 RVA: 0x001E40E6 File Offset: 0x001E24E6
	public IceSkull()
	{
	}

	// Token: 0x17000F1D RID: 3869
	// (get) Token: 0x06004937 RID: 18743 RVA: 0x001E40EE File Offset: 0x001E24EE
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.IceSkull;
		}
	}

	// Token: 0x17000F1E RID: 3870
	// (get) Token: 0x06004938 RID: 18744 RVA: 0x001E40F5 File Offset: 0x001E24F5
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}

	// Token: 0x06004939 RID: 18745 RVA: 0x001E40F8 File Offset: 0x001E24F8
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Ice;
	}

	// Token: 0x0600493A RID: 18746 RVA: 0x001E40FC File Offset: 0x001E24FC
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating == 2)
		{
			return new List<SkillType>
			{
				SkillType.Stun,
				SkillType.FleshToStone
			};
		}
		return new List<SkillType>
		{
			SkillType.Stun
		};
	}

	// Token: 0x0600493B RID: 18747 RVA: 0x001E4148 File Offset: 0x001E2548
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
					Extra = 4
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new ExtraTargetingData
			{
				Extra = 2,
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				}
			}
		};
	}
}
