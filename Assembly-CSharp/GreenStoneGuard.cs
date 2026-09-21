using System;
using System.Collections.Generic;

// Token: 0x02000A82 RID: 2690
public class GreenStoneGuard : HellishPathBossConfigurationBase
{
	// Token: 0x0600492C RID: 18732 RVA: 0x001E3F1E File Offset: 0x001E231E
	public GreenStoneGuard()
	{
	}

	// Token: 0x17000F19 RID: 3865
	// (get) Token: 0x0600492D RID: 18733 RVA: 0x001E3F26 File Offset: 0x001E2326
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GreenStoneGuard;
		}
	}

	// Token: 0x17000F1A RID: 3866
	// (get) Token: 0x0600492E RID: 18734 RVA: 0x001E3F2D File Offset: 0x001E232D
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}

	// Token: 0x0600492F RID: 18735 RVA: 0x001E3F30 File Offset: 0x001E2330
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new ExtraTargetingData
				{
					CandidateTypes = new List<TargetCandidateType>
					{
						TargetCandidateType.HostileAlive
					},
					Extra = 4
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new ExtraTargetingData
			{
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				},
				Extra = 2
			}
		};
	}

	// Token: 0x06004930 RID: 18736 RVA: 0x001E3FA8 File Offset: 0x001E23A8
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.SwallowFire,
			SkillType.LightFire
		};
	}
}
