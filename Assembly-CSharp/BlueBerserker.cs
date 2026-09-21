using System;
using System.Collections.Generic;

// Token: 0x02000A7C RID: 2684
public class BlueBerserker : MistForestBossConfigurationBase
{
	// Token: 0x0600490E RID: 18702 RVA: 0x001E383C File Offset: 0x001E1C3C
	public BlueBerserker()
	{
	}

	// Token: 0x17000F0D RID: 3853
	// (get) Token: 0x0600490F RID: 18703 RVA: 0x001E3844 File Offset: 0x001E1C44
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueBerserker;
		}
	}

	// Token: 0x17000F0E RID: 3854
	// (get) Token: 0x06004910 RID: 18704 RVA: 0x001E384B File Offset: 0x001E1C4B
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalSupporter;
		}
	}

	// Token: 0x06004911 RID: 18705 RVA: 0x001E3850 File Offset: 0x001E1C50
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Stun,
			SkillType.Rage
		};
	}

	// Token: 0x06004912 RID: 18706 RVA: 0x001E387C File Offset: 0x001E1C7C
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new ExtraTargetingData
				{
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
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				},
				Extra = 1
			}
		};
	}
}
