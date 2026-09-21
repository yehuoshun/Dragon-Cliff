using System;
using System.Collections.Generic;

// Token: 0x02000A83 RID: 2691
public class HeartEater : BuriedTempleBossConfigurationBase
{
	// Token: 0x06004931 RID: 18737 RVA: 0x001E3FD2 File Offset: 0x001E23D2
	public HeartEater()
	{
	}

	// Token: 0x17000F1B RID: 3867
	// (get) Token: 0x06004932 RID: 18738 RVA: 0x001E3FDA File Offset: 0x001E23DA
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.HeartEater;
		}
	}

	// Token: 0x06004933 RID: 18739 RVA: 0x001E3FE4 File Offset: 0x001E23E4
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new PossessionData
				{
					IsStarEf = new bool?(false),
					Chance = 0.7,
					TriggerEventType = AdventureEventType.UnitPostReceivesDamage,
					LastingTurns = 2,
					PossessionEffectSourceIdentityCode = "hearteater",
					Boosts = new List<BoostSetting>
					{
						new BoostSetting
						{
							BoostValue = 0.7,
							BoostAttribute = AttributeType.CritRate
						}
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
				}
			};
		}
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x17000F1C RID: 3868
	// (get) Token: 0x06004934 RID: 18740 RVA: 0x001E40B8 File Offset: 0x001E24B8
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x06004935 RID: 18741 RVA: 0x001E40BC File Offset: 0x001E24BC
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.ShieldBurn,
			SkillType.ReturningSoul
		};
	}
}
