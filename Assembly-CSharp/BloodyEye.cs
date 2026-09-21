using System;
using System.Collections.Generic;

// Token: 0x02000AC2 RID: 2754
public class BloodyEye : MajorQuestBossConfiguration
{
	// Token: 0x06004A43 RID: 19011 RVA: 0x001E8F40 File Offset: 0x001E7340
	public BloodyEye()
	{
	}

	// Token: 0x17000F91 RID: 3985
	// (get) Token: 0x06004A44 RID: 19012 RVA: 0x001E8F48 File Offset: 0x001E7348
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BloodyEye;
		}
	}

	// Token: 0x17000F92 RID: 3986
	// (get) Token: 0x06004A45 RID: 19013 RVA: 0x001E8F4F File Offset: 0x001E734F
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004A46 RID: 19014 RVA: 0x001E8F52 File Offset: 0x001E7352
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Shadow;
	}

	// Token: 0x06004A47 RID: 19015 RVA: 0x001E8F58 File Offset: 0x001E7358
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Confusion,
			SkillType.ReturningSoul,
			SkillType.FleshToStone
		};
	}

	// Token: 0x06004A48 RID: 19016 RVA: 0x001E8F90 File Offset: 0x001E7390
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new BloodEyeSelfProtectionData
				{
					HealPerGhost = 5000.0,
					GhostLastingSeconds = 3f,
					MaxNumberOfGhostsPerTarget = 10
				},
				new MonksEyesData
				{
					IsStarEf = new bool?(false),
					MaxLoss = 0.2
				},
				new ExtraTargetingData
				{
					IsStarEf = new bool?(false),
					Extra = 4,
					CandidateTypes = new List<TargetCandidateType>
					{
						TargetCandidateType.HostileAlive
					}
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new BloodEyeSelfProtectionData
			{
				HealPerGhost = 300.0,
				GhostLastingSeconds = 3f,
				MaxNumberOfGhostsPerTarget = 5
			},
			new ExtraTargetingData
			{
				IsStarEf = new bool?(false),
				Extra = 2,
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				}
			}
		};
	}
}
