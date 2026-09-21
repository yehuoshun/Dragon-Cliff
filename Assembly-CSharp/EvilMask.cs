using System;
using System.Collections.Generic;

// Token: 0x02000A7F RID: 2687
public class EvilMask : BuriedTempleBossConfigurationBase
{
	// Token: 0x0600491D RID: 18717 RVA: 0x001E3C81 File Offset: 0x001E2081
	public EvilMask()
	{
	}

	// Token: 0x17000F13 RID: 3859
	// (get) Token: 0x0600491E RID: 18718 RVA: 0x001E3C89 File Offset: 0x001E2089
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.EvilMask;
		}
	}

	// Token: 0x17000F14 RID: 3860
	// (get) Token: 0x0600491F RID: 18719 RVA: 0x001E3C90 File Offset: 0x001E2090
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004920 RID: 18720 RVA: 0x001E3C94 File Offset: 0x001E2094
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.MultiStrike,
			SkillType.Rebirth
		};
	}

	// Token: 0x06004921 RID: 18721 RVA: 0x001E3CC0 File Offset: 0x001E20C0
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
					Extra = 4
				}
			};
		}
		return new List<ISpecialEffectDataLoad>();
	}
}
