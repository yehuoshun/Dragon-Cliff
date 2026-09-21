using System;
using System.Collections.Generic;

// Token: 0x02000A80 RID: 2688
public class GreenBerserker : MistForestBossConfigurationBase
{
	// Token: 0x06004922 RID: 18722 RVA: 0x001E3D1A File Offset: 0x001E211A
	public GreenBerserker()
	{
	}

	// Token: 0x17000F15 RID: 3861
	// (get) Token: 0x06004923 RID: 18723 RVA: 0x001E3D22 File Offset: 0x001E2122
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GreenBerserker;
		}
	}

	// Token: 0x17000F16 RID: 3862
	// (get) Token: 0x06004924 RID: 18724 RVA: 0x001E3D29 File Offset: 0x001E2129
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004925 RID: 18725 RVA: 0x001E3D2C File Offset: 0x001E212C
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.CorruptedPower
		};
	}

	// Token: 0x06004926 RID: 18726 RVA: 0x001E3D4C File Offset: 0x001E214C
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new UndeadAshData
				{
					PerIncreaseRate = 0.8,
					PerLossRate = 0.2
				},
				new AttributeDestroyData
				{
					IsStarEf = new bool?(false),
					Chance = 0.5,
					ReplaceAttribute = AttributeType.Strength,
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
		return new List<ISpecialEffectDataLoad>
		{
			new UndeadAshData
			{
				PerIncreaseRate = 0.8,
				PerLossRate = 0.2
			}
		};
	}
}
