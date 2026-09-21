using System;
using System.Collections.Generic;

// Token: 0x02000A8C RID: 2700
public class RedHighMage : SnowMountainBossConfiguration
{
	// Token: 0x0600495F RID: 18783 RVA: 0x001E4A02 File Offset: 0x001E2E02
	public RedHighMage()
	{
	}

	// Token: 0x17000F2D RID: 3885
	// (get) Token: 0x06004960 RID: 18784 RVA: 0x001E4A0A File Offset: 0x001E2E0A
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedHighMage;
		}
	}

	// Token: 0x17000F2E RID: 3886
	// (get) Token: 0x06004961 RID: 18785 RVA: 0x001E4A11 File Offset: 0x001E2E11
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x06004962 RID: 18786 RVA: 0x001E4A14 File Offset: 0x001E2E14
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new DivineBlindnessData
				{
					IsStarEf = new bool?(false),
					ChargeCap = 4,
					PushPercentage = 0.3,
					ChargeCounter = 0
				}
			};
		}
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06004963 RID: 18787 RVA: 0x001E4A70 File Offset: 0x001E2E70
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Shock,
			SkillType.Swift
		};
	}
}
