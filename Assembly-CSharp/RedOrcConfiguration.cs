using System;
using System.Collections.Generic;

// Token: 0x02000A8E RID: 2702
public class RedOrcConfiguration : WoodenForestBossConfigurationBase
{
	// Token: 0x06004969 RID: 18793 RVA: 0x001E4B64 File Offset: 0x001E2F64
	public RedOrcConfiguration()
	{
	}

	// Token: 0x17000F31 RID: 3889
	// (get) Token: 0x0600496A RID: 18794 RVA: 0x001E4B6C File Offset: 0x001E2F6C
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedOrc;
		}
	}

	// Token: 0x0600496B RID: 18795 RVA: 0x001E4B74 File Offset: 0x001E2F74
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
					Extra = 2
				}
			};
		}
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x17000F32 RID: 3890
	// (get) Token: 0x0600496C RID: 18796 RVA: 0x001E4BCE File Offset: 0x001E2FCE
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x0600496D RID: 18797 RVA: 0x001E4BD4 File Offset: 0x001E2FD4
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.MultiStrike,
			SkillType.Rage,
			SkillType.BloodThirst
		};
	}
}
