using System;
using System.Collections.Generic;

// Token: 0x02000A8A RID: 2698
public class RedBirdMonsterConfiguration : MistForestBossConfigurationBase
{
	// Token: 0x06004955 RID: 18773 RVA: 0x001E46E4 File Offset: 0x001E2AE4
	public RedBirdMonsterConfiguration()
	{
	}

	// Token: 0x17000F29 RID: 3881
	// (get) Token: 0x06004956 RID: 18774 RVA: 0x001E46EC File Offset: 0x001E2AEC
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedBirdMonster;
		}
	}

	// Token: 0x17000F2A RID: 3882
	// (get) Token: 0x06004957 RID: 18775 RVA: 0x001E46F3 File Offset: 0x001E2AF3
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x06004958 RID: 18776 RVA: 0x001E46F8 File Offset: 0x001E2AF8
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Nightmare,
			SkillType.Swift
		};
	}

	// Token: 0x06004959 RID: 18777 RVA: 0x001E4724 File Offset: 0x001E2B24
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new StarfallData
				{
					IsStarEf = new bool?(false),
					Chance = 0.7,
					DamageType = OutputType.Poison,
					DamagePercentage = 1.2
				},
				new SavageHeartData
				{
					IsStarEf = new bool?(false)
				}
			};
		}
		return new List<ISpecialEffectDataLoad>();
	}
}
