using System;
using System.Collections.Generic;

// Token: 0x02000A87 RID: 2695
public class PurpleBerserker : MistForestBossConfigurationBase
{
	// Token: 0x06004946 RID: 18758 RVA: 0x001E431E File Offset: 0x001E271E
	public PurpleBerserker()
	{
	}

	// Token: 0x17000F23 RID: 3875
	// (get) Token: 0x06004947 RID: 18759 RVA: 0x001E4326 File Offset: 0x001E2726
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleBerserker;
		}
	}

	// Token: 0x17000F24 RID: 3876
	// (get) Token: 0x06004948 RID: 18760 RVA: 0x001E432D File Offset: 0x001E272D
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004949 RID: 18761 RVA: 0x001E4330 File Offset: 0x001E2730
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.BladeRain,
			SkillType.Stray
		};
	}

	// Token: 0x0600494A RID: 18762 RVA: 0x001E435C File Offset: 0x001E275C
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new AttributeDestroyData
				{
					Chance = 0.3,
					ReplaceAttribute = AttributeType.Strength,
					ReplacementValue = 1.0
				}
			};
		}
		return new List<ISpecialEffectDataLoad>();
	}
}
