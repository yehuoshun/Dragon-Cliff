using System;
using System.Collections.Generic;

// Token: 0x02000A95 RID: 2709
public class YellowOrcConfiguration : WoodenForestBossConfigurationBase
{
	// Token: 0x06004989 RID: 18825 RVA: 0x001E4EFA File Offset: 0x001E32FA
	public YellowOrcConfiguration()
	{
	}

	// Token: 0x17000F3F RID: 3903
	// (get) Token: 0x0600498A RID: 18826 RVA: 0x001E4F02 File Offset: 0x001E3302
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowOrc;
		}
	}

	// Token: 0x0600498B RID: 18827 RVA: 0x001E4F0C File Offset: 0x001E330C
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
				},
				new AttributeStealData
				{
					IsStarEf = new bool?(false),
					StealAttributeType = AttributeType.Strength,
					MaximumStolenValue = 1000.0,
					SteamPercentage = 0.5
				}
			};
		}
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x17000F40 RID: 3904
	// (get) Token: 0x0600498C RID: 18828 RVA: 0x001E4FA4 File Offset: 0x001E33A4
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x0600498D RID: 18829 RVA: 0x001E4FA8 File Offset: 0x001E33A8
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Stun,
			SkillType.ReturningSoul
		};
	}
}
