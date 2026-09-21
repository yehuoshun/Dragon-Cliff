using System;
using System.Collections.Generic;

// Token: 0x02000A7A RID: 2682
public class BirdMonsterRed : ImperialMausoleumBossConfigurationBase
{
	// Token: 0x06004903 RID: 18691 RVA: 0x001E356D File Offset: 0x001E196D
	public BirdMonsterRed()
	{
	}

	// Token: 0x17000F09 RID: 3849
	// (get) Token: 0x06004904 RID: 18692 RVA: 0x001E3575 File Offset: 0x001E1975
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BirdMonsterRed;
		}
	}

	// Token: 0x17000F0A RID: 3850
	// (get) Token: 0x06004905 RID: 18693 RVA: 0x001E357C File Offset: 0x001E197C
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004906 RID: 18694 RVA: 0x001E357F File Offset: 0x001E197F
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Divine;
	}

	// Token: 0x06004907 RID: 18695 RVA: 0x001E3584 File Offset: 0x001E1984
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
				},
				new MonksEyesData
				{
					IsStarEf = new bool?(false),
					MaxLoss = 0.2
				},
				new InversedMandateData
				{
					IsStarEf = new bool?(false),
					DamageType = OutputType.Fire,
					DamageRate = 0.7,
					LastingSeconds = 2f,
					ChargeRate = 0.4,
					Charged = 0.0
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new InversedMandateData
			{
				DamageType = OutputType.Fire,
				DamageRate = 0.2,
				LastingSeconds = 2f,
				Charged = 0.0,
				ChargeRate = 0.4
			}
		};
	}

	// Token: 0x06004908 RID: 18696 RVA: 0x001E36BC File Offset: 0x001E1ABC
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating == 2)
		{
			return new List<SkillType>
			{
				SkillType.Arcane,
				SkillType.Harmony,
				SkillType.FleshToStone
			};
		}
		return new List<SkillType>
		{
			SkillType.Shock
		};
	}
}
