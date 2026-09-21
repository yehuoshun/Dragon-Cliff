using System;
using System.Collections.Generic;

// Token: 0x02000A81 RID: 2689
public class GreenOrcConfiguration : WoodenForestBossConfigurationBase
{
	// Token: 0x06004927 RID: 18727 RVA: 0x001E3E3F File Offset: 0x001E223F
	public GreenOrcConfiguration()
	{
	}

	// Token: 0x17000F17 RID: 3863
	// (get) Token: 0x06004928 RID: 18728 RVA: 0x001E3E47 File Offset: 0x001E2247
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GreenOrc;
		}
	}

	// Token: 0x17000F18 RID: 3864
	// (get) Token: 0x06004929 RID: 18729 RVA: 0x001E3E4E File Offset: 0x001E224E
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x0600492A RID: 18730 RVA: 0x001E3E54 File Offset: 0x001E2254
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		if (measurement.DifficultyValue < 6.0 && measurement.StarRating == 1)
		{
			return new List<SkillType>();
		}
		if (measurement.StarRating == 2)
		{
			return new List<SkillType>
			{
				SkillType.BladeRain,
				SkillType.Swift,
				SkillType.BloodThirst
			};
		}
		return new List<SkillType>
		{
			SkillType.BladeRain
		};
	}

	// Token: 0x0600492B RID: 18731 RVA: 0x001E3ED0 File Offset: 0x001E22D0
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new FirstHandEffectData
				{
					IsStarEf = new bool?(false),
					StartProgress = 1.0
				}
			};
		}
		return new List<ISpecialEffectDataLoad>();
	}
}
