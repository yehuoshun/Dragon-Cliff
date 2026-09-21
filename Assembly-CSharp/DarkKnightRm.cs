using System;
using System.Collections.Generic;

// Token: 0x02000AE0 RID: 2784
public class DarkKnightRm : RemnantsBossBase
{
	// Token: 0x06004B07 RID: 19207 RVA: 0x001EB4F6 File Offset: 0x001E98F6
	public DarkKnightRm()
	{
	}

	// Token: 0x17000FCB RID: 4043
	// (get) Token: 0x06004B08 RID: 19208 RVA: 0x001EB4FE File Offset: 0x001E98FE
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.DarkKnight_Remnants;
		}
	}

	// Token: 0x17000FCC RID: 4044
	// (get) Token: 0x06004B09 RID: 19209 RVA: 0x001EB505 File Offset: 0x001E9905
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004B0A RID: 19210 RVA: 0x001EB508 File Offset: 0x001E9908
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.SwallowFire,
			SkillType.Flame
		};
	}

	// Token: 0x06004B0B RID: 19211 RVA: 0x001EB532 File Offset: 0x001E9932
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Fire;
	}

	// Token: 0x06004B0C RID: 19212 RVA: 0x001EB538 File Offset: 0x001E9938
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new DarkRageData
				{
					ChargeRate = 2.0,
					ChargeAttributeTypes = new List<AttributeType>
					{
						AttributeType.Strength,
						AttributeType.Agility
					}
				},
				new ExtraTargetingData
				{
					IsStarEf = new bool?(false),
					CandidateTypes = new List<TargetCandidateType>
					{
						TargetCandidateType.HostileAlive
					},
					Extra = 2
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new DarkRageData
			{
				ChargeRate = 1.0,
				ChargeAttributeTypes = new List<AttributeType>
				{
					AttributeType.Strength,
					AttributeType.Agility
				}
			},
			new ExtraTargetingData
			{
				IsStarEf = new bool?(false),
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				},
				Extra = 2
			}
		};
	}
}
