using System;
using System.Collections.Generic;

// Token: 0x02000A8D RID: 2701
public class RedMudConfiguration : MistForestBossConfigurationBase
{
	// Token: 0x06004964 RID: 18788 RVA: 0x001E4A9A File Offset: 0x001E2E9A
	public RedMudConfiguration()
	{
	}

	// Token: 0x17000F2F RID: 3887
	// (get) Token: 0x06004965 RID: 18789 RVA: 0x001E4AA2 File Offset: 0x001E2EA2
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedMud;
		}
	}

	// Token: 0x17000F30 RID: 3888
	// (get) Token: 0x06004966 RID: 18790 RVA: 0x001E4AA9 File Offset: 0x001E2EA9
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalDefender;
		}
	}

	// Token: 0x06004967 RID: 18791 RVA: 0x001E4AAC File Offset: 0x001E2EAC
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.BrightCircle,
			SkillType.Rebirth
		};
	}

	// Token: 0x06004968 RID: 18792 RVA: 0x001E4AD8 File Offset: 0x001E2ED8
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new ImmortalShieldEffectData
				{
					IsStarEf = new bool?(false),
					NumberOfShields = 2
				},
				new SacrificeEffectData
				{
					IsStarEf = new bool?(false),
					HealRate = 2.0,
					SacrificeRate = 0.2,
					MinimumSelfRate = 0.3
				}
			};
		}
		return new List<ISpecialEffectDataLoad>();
	}
}
