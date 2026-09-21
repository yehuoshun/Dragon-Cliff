using System;
using System.Collections.Generic;

// Token: 0x02000A9A RID: 2714
public class BlueCyclops : MiniBossUnitConfigurationBase
{
	// Token: 0x0600499E RID: 18846 RVA: 0x001E7ADF File Offset: 0x001E5EDF
	public BlueCyclops()
	{
	}

	// Token: 0x17000F45 RID: 3909
	// (get) Token: 0x0600499F RID: 18847 RVA: 0x001E7AE7 File Offset: 0x001E5EE7
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueCyclops;
		}
	}

	// Token: 0x17000F46 RID: 3910
	// (get) Token: 0x060049A0 RID: 18848 RVA: 0x001E7AEE File Offset: 0x001E5EEE
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x060049A1 RID: 18849 RVA: 0x001E7AF4 File Offset: 0x001E5EF4
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.BurningHeart,
			SkillType.Stray
		};
	}

	// Token: 0x060049A2 RID: 18850 RVA: 0x001E7B20 File Offset: 0x001E5F20
	public override List<ISpecialEffectDataLoad> FurtherSpecialEffectsFilter(List<ISpecialEffectDataLoad> original, DifficultyLevelMeasurement relevantDifficultyLevelMeasurement)
	{
		original.AddRange(new List<ISpecialEffectDataLoad>
		{
			new ExtraTargetingData
			{
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				},
				Extra = 3,
				IsStarEf = new bool?(false)
			},
			new FirstHandEffectData
			{
				IsStarEf = new bool?(false),
				StartProgress = 1.0
			}
		});
		return original;
	}
}
