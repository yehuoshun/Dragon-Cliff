using System;
using System.Collections.Generic;

// Token: 0x02000A79 RID: 2681
public class Berserker : MistForestBossConfigurationBase
{
	// Token: 0x060048FE RID: 18686 RVA: 0x001E33D8 File Offset: 0x001E17D8
	public Berserker()
	{
	}

	// Token: 0x17000F07 RID: 3847
	// (get) Token: 0x060048FF RID: 18687 RVA: 0x001E33E0 File Offset: 0x001E17E0
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Berserker;
		}
	}

	// Token: 0x17000F08 RID: 3848
	// (get) Token: 0x06004900 RID: 18688 RVA: 0x001E33E7 File Offset: 0x001E17E7
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004901 RID: 18689 RVA: 0x001E33EC File Offset: 0x001E17EC
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.SwallowFire,
			SkillType.Swift,
			SkillType.LightFire
		};
	}

	// Token: 0x06004902 RID: 18690 RVA: 0x001E3424 File Offset: 0x001E1824
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
				new MonksEyesData
				{
					IsStarEf = new bool?(false),
					MaxLoss = 0.1
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new DivineBlindnessData
			{
				ChargeCap = 3,
				PushPercentage = 0.3
			}
		};
	}
}
