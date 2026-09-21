using System;
using System.Collections.Generic;

// Token: 0x02000A97 RID: 2711
public class YellowSpearerConfiguration : SnowMountainBossConfiguration
{
	// Token: 0x06004993 RID: 18835 RVA: 0x001E5086 File Offset: 0x001E3486
	public YellowSpearerConfiguration()
	{
	}

	// Token: 0x17000F43 RID: 3907
	// (get) Token: 0x06004994 RID: 18836 RVA: 0x001E508E File Offset: 0x001E348E
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowSpearer;
		}
	}

	// Token: 0x17000F44 RID: 3908
	// (get) Token: 0x06004995 RID: 18837 RVA: 0x001E5095 File Offset: 0x001E3495
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}

	// Token: 0x06004996 RID: 18838 RVA: 0x001E5098 File Offset: 0x001E3498
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
				},
				new FirstHandEffectData
				{
					IsStarEf = new bool?(false),
					StartProgress = 1.0
				}
			};
		}
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06004997 RID: 18839 RVA: 0x001E511C File Offset: 0x001E351C
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.BurningHeart,
			SkillType.BloodThirst
		};
	}
}
