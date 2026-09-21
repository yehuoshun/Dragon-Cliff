using System;
using System.Collections.Generic;

// Token: 0x02000A7D RID: 2685
public class BlueOrcConfiguration : WoodenForestBossConfigurationBase
{
	// Token: 0x06004913 RID: 18707 RVA: 0x001E3ACD File Offset: 0x001E1ECD
	public BlueOrcConfiguration()
	{
	}

	// Token: 0x17000F0F RID: 3855
	// (get) Token: 0x06004914 RID: 18708 RVA: 0x001E3AD5 File Offset: 0x001E1ED5
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueOrc;
		}
	}

	// Token: 0x06004915 RID: 18709 RVA: 0x001E3ADC File Offset: 0x001E1EDC
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating == 2)
		{
			return new List<SkillType>
			{
				SkillType.DeadlyBlade,
				SkillType.Stray,
				SkillType.BloodThirst
			};
		}
		return new List<SkillType>
		{
			SkillType.DeadlyBlade,
			SkillType.Stray
		};
	}

	// Token: 0x06004916 RID: 18710 RVA: 0x001E3B3C File Offset: 0x001E1F3C
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

	// Token: 0x17000F10 RID: 3856
	// (get) Token: 0x06004917 RID: 18711 RVA: 0x001E3B8A File Offset: 0x001E1F8A
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}
}
