using System;
using System.Collections.Generic;

// Token: 0x02000A94 RID: 2708
public class YellowHighMage : SnowMountainBossConfiguration
{
	// Token: 0x06004984 RID: 18820 RVA: 0x001E4E62 File Offset: 0x001E3262
	public YellowHighMage()
	{
	}

	// Token: 0x17000F3D RID: 3901
	// (get) Token: 0x06004985 RID: 18821 RVA: 0x001E4E6A File Offset: 0x001E326A
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowHighMage;
		}
	}

	// Token: 0x17000F3E RID: 3902
	// (get) Token: 0x06004986 RID: 18822 RVA: 0x001E4E71 File Offset: 0x001E3271
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x06004987 RID: 18823 RVA: 0x001E4E74 File Offset: 0x001E3274
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
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06004988 RID: 18824 RVA: 0x001E4ED0 File Offset: 0x001E32D0
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.SeedsOfSin,
			SkillType.SoulSeeker
		};
	}
}
