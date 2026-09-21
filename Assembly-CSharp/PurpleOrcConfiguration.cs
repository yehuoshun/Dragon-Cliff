using System;
using System.Collections.Generic;

// Token: 0x02000A89 RID: 2697
public class PurpleOrcConfiguration : WoodenForestBossConfigurationBase
{
	// Token: 0x0600494F RID: 18767 RVA: 0x001E455C File Offset: 0x001E295C
	public PurpleOrcConfiguration()
	{
	}

	// Token: 0x17000F27 RID: 3879
	// (get) Token: 0x06004950 RID: 18768 RVA: 0x001E4564 File Offset: 0x001E2964
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleOrc;
		}
	}

	// Token: 0x17000F28 RID: 3880
	// (get) Token: 0x06004951 RID: 18769 RVA: 0x001E456B File Offset: 0x001E296B
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004952 RID: 18770 RVA: 0x001E456E File Offset: 0x001E296E
	protected override UnitGrowthProfile FurtherProfileModification(UnitGrowthProfile originalGrowthProfile, DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating != 1)
		{
			originalGrowthProfile.SetValue(AttributeType.StunOnHit, 0.6, false);
		}
		return originalGrowthProfile;
	}

	// Token: 0x06004953 RID: 18771 RVA: 0x001E4594 File Offset: 0x001E2994
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new ChargeData
				{
					IsStarEf = new bool?(false),
					ChargeCap = 3000.0,
					BoostAttributeType = AttributeType.Strength,
					ChargingDamageTypes = new List<OutputType>
					{
						OutputType.Fire,
						OutputType.Ice
					}
				},
				new ExtraTargetingData
				{
					IsStarEf = new bool?(false),
					CandidateTypes = new List<TargetCandidateType>
					{
						TargetCandidateType.HostileAlive
					},
					Extra = 2
				},
				new MonksEyesData
				{
					IsStarEf = new bool?(false),
					MaxLoss = 0.1
				}
			};
		}
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06004954 RID: 18772 RVA: 0x001E4668 File Offset: 0x001E2A68
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating == 1)
		{
			return new List<SkillType>
			{
				SkillType.Taunt,
				SkillType.Rebirth,
				SkillType.BloodThirst
			};
		}
		if (measurement.StarRating == 2)
		{
			return new List<SkillType>
			{
				SkillType.MultiStrike,
				SkillType.BloodThirst,
				SkillType.Rebirth
			};
		}
		return new List<SkillType>();
	}
}
