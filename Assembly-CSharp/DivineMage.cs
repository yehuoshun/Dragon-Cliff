using System;
using System.Collections.Generic;

// Token: 0x02000A7E RID: 2686
public class DivineMage : HellishPathBossConfigurationBase
{
	// Token: 0x06004918 RID: 18712 RVA: 0x001E3B8D File Offset: 0x001E1F8D
	public DivineMage()
	{
	}

	// Token: 0x17000F11 RID: 3857
	// (get) Token: 0x06004919 RID: 18713 RVA: 0x001E3B95 File Offset: 0x001E1F95
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.DivineMage;
		}
	}

	// Token: 0x17000F12 RID: 3858
	// (get) Token: 0x0600491A RID: 18714 RVA: 0x001E3B9C File Offset: 0x001E1F9C
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x0600491B RID: 18715 RVA: 0x001E3BA0 File Offset: 0x001E1FA0
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.ShieldBurn,
			SkillType.Swift
		};
	}

	// Token: 0x0600491C RID: 18716 RVA: 0x001E3BCC File Offset: 0x001E1FCC
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
				},
				new SufferlessData
				{
					IsStarEf = new bool?(false),
					RecoveryRate = 0.5,
					NumberOfMaxTriggersPerBattle = 1,
					ImmuneTurns = 1,
					Counter = 0
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
}
