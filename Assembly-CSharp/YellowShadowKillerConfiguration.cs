using System;
using System.Collections.Generic;

// Token: 0x02000A96 RID: 2710
public class YellowShadowKillerConfiguration : SnowMountainBossConfiguration
{
	// Token: 0x0600498E RID: 18830 RVA: 0x001E4FD2 File Offset: 0x001E33D2
	public YellowShadowKillerConfiguration()
	{
	}

	// Token: 0x17000F41 RID: 3905
	// (get) Token: 0x0600498F RID: 18831 RVA: 0x001E4FDA File Offset: 0x001E33DA
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowShadowKiller;
		}
	}

	// Token: 0x17000F42 RID: 3906
	// (get) Token: 0x06004990 RID: 18832 RVA: 0x001E4FE1 File Offset: 0x001E33E1
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x06004991 RID: 18833 RVA: 0x001E4FE4 File Offset: 0x001E33E4
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
				},
				new MonksEyesData
				{
					IsStarEf = new bool?(false),
					MaxLoss = 0.2
				}
			};
		}
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06004992 RID: 18834 RVA: 0x001E505C File Offset: 0x001E345C
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.FireBreath,
			SkillType.Harmony
		};
	}
}
