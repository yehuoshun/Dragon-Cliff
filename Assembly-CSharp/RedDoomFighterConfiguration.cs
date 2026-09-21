using System;
using System.Collections.Generic;

// Token: 0x02000A8B RID: 2699
public class RedDoomFighterConfiguration : MistForestBossConfigurationBase
{
	// Token: 0x0600495A RID: 18778 RVA: 0x001E47A1 File Offset: 0x001E2BA1
	public RedDoomFighterConfiguration()
	{
	}

	// Token: 0x17000F2B RID: 3883
	// (get) Token: 0x0600495B RID: 18779 RVA: 0x001E47A9 File Offset: 0x001E2BA9
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedDoomFighter;
		}
	}

	// Token: 0x17000F2C RID: 3884
	// (get) Token: 0x0600495C RID: 18780 RVA: 0x001E47B0 File Offset: 0x001E2BB0
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}

	// Token: 0x0600495D RID: 18781 RVA: 0x001E47B4 File Offset: 0x001E2BB4
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new AttributeDestroyData
				{
					IsStarEf = new bool?(false),
					Chance = 0.7,
					ReplaceAttribute = AttributeType.Intelligience,
					ReplacementValue = 1.0
				},
				new ExtraTargetingData
				{
					IsStarEf = new bool?(false),
					CandidateTypes = new List<TargetCandidateType>
					{
						TargetCandidateType.HostileAlive
					},
					Extra = 2
				}
			};
		}
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x0600495E RID: 18782 RVA: 0x001E484C File Offset: 0x001E2C4C
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.SpellSlayer,
			SkillType.Stray
		};
	}
}
