using System;
using System.Collections.Generic;

// Token: 0x02000AC6 RID: 2758
public class Death : MajorQuestBossConfiguration
{
	// Token: 0x06004A5A RID: 19034 RVA: 0x001E93BB File Offset: 0x001E77BB
	public Death()
	{
	}

	// Token: 0x17000F99 RID: 3993
	// (get) Token: 0x06004A5B RID: 19035 RVA: 0x001E93C3 File Offset: 0x001E77C3
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Death;
		}
	}

	// Token: 0x17000F9A RID: 3994
	// (get) Token: 0x06004A5C RID: 19036 RVA: 0x001E93CA File Offset: 0x001E77CA
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004A5D RID: 19037 RVA: 0x001E93CD File Offset: 0x001E77CD
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Shadow;
	}

	// Token: 0x06004A5E RID: 19038 RVA: 0x001E93D0 File Offset: 0x001E77D0
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.ShadowSacrifice
		};
	}

	// Token: 0x06004A5F RID: 19039 RVA: 0x001E93F0 File Offset: 0x001E77F0
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
					Extra = 2
				},
				new DeathShadowData
				{
					DamageType = OutputType.Shadow,
					DamageRate = 15.0,
					CoolingDownCounter = 0,
					CoolingDownSeconds = 2,
					HaveRevived = false,
					ReviveRate = 1.0,
					CoolingDownSecondsAfterRebirth = 4,
					ChannelingSeconds = 2f
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
				Extra = 1
			},
			new DeathShadowData
			{
				DamageType = OutputType.Shadow,
				DamageRate = 15.0,
				CoolingDownCounter = 0,
				CoolingDownSeconds = 2,
				HaveRevived = false,
				ReviveRate = 1.0,
				CoolingDownSecondsAfterRebirth = 4,
				ChannelingSeconds = 2f
			}
		};
	}
}
