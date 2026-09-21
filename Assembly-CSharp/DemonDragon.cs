using System;
using System.Collections.Generic;

// Token: 0x02000AC7 RID: 2759
public class DemonDragon : MajorQuestBossConfiguration
{
	// Token: 0x06004A60 RID: 19040 RVA: 0x001E951A File Offset: 0x001E791A
	public DemonDragon()
	{
	}

	// Token: 0x17000F9B RID: 3995
	// (get) Token: 0x06004A61 RID: 19041 RVA: 0x001E9522 File Offset: 0x001E7922
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.DemonDragon;
		}
	}

	// Token: 0x17000F9C RID: 3996
	// (get) Token: 0x06004A62 RID: 19042 RVA: 0x001E9529 File Offset: 0x001E7929
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004A63 RID: 19043 RVA: 0x001E952C File Offset: 0x001E792C
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Fire;
	}

	// Token: 0x06004A64 RID: 19044 RVA: 0x001E9530 File Offset: 0x001E7930
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.FireBall,
			SkillType.SoulSeeker,
			SkillType.Harmony,
			SkillType.Flame
		};
	}

	// Token: 0x06004A65 RID: 19045 RVA: 0x001E9570 File Offset: 0x001E7970
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new DemonDragonEffectData
				{
					PowerChargeSecondCounter = 0,
					ChangeCounter = 0,
					PossibleImmunityTypes = UnitExtensions.GetAllDamageElements(),
					CurrentStackCounter = 0,
					PowerChargeSecondsCap = 2,
					StunLastingSeconds = 1f,
					ExplosionDamageRate = 3.0,
					ExplosionDamageType = OutputType.Fire,
					ChangeCap = 2,
					HealRatePerSecond = 0.02,
					ExplosionStackSize = 4,
					DamgeIncreasePossibleElements = UnitExtensions.GetAllDamageElements(),
					DamageIncreaseRatePerElement = 0.3,
					DamageIncreaseLastingSeconds = 2f,
					PowerChargePushBackTick = 1,
					PowerBoostRate = 0.1
				},
				new ExtraTargetingData
				{
					IsStarEf = new bool?(false),
					Extra = 3,
					CandidateTypes = new List<TargetCandidateType>
					{
						TargetCandidateType.HostileAlive
					}
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new DemonDragonEffectData
			{
				PowerChargeSecondCounter = 0,
				ChangeCounter = 0,
				PossibleImmunityTypes = UnitExtensions.GetAllDamageElements(),
				CurrentStackCounter = 0,
				PowerChargeSecondsCap = 3,
				StunLastingSeconds = 1f,
				ExplosionDamageRate = 3.0,
				ExplosionDamageType = OutputType.Fire,
				ChangeCap = 2,
				HealRatePerSecond = 0.02,
				ExplosionStackSize = 5,
				DamgeIncreasePossibleElements = UnitExtensions.GetAllDamageElements(),
				DamageIncreaseRatePerElement = 0.3,
				DamageIncreaseLastingSeconds = 2f,
				PowerChargePushBackTick = 1,
				PowerBoostRate = 0.1
			},
			new ExtraTargetingData
			{
				IsStarEf = new bool?(false),
				Extra = 3,
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				}
			}
		};
	}
}
