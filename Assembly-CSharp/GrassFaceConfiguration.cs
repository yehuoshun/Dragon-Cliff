using System;
using System.Collections.Generic;

// Token: 0x02000AE3 RID: 2787
public class GrassFaceConfiguration : BossUnitConfigurationBase
{
	// Token: 0x06004B20 RID: 19232 RVA: 0x001EBA60 File Offset: 0x001E9E60
	public GrassFaceConfiguration()
	{
	}

	// Token: 0x17000FCF RID: 4047
	// (get) Token: 0x06004B21 RID: 19233 RVA: 0x001EBA68 File Offset: 0x001E9E68
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GrassFace;
		}
	}

	// Token: 0x17000FD0 RID: 4048
	// (get) Token: 0x06004B22 RID: 19234 RVA: 0x001EBA6F File Offset: 0x001E9E6F
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalSupporter;
		}
	}

	// Token: 0x06004B23 RID: 19235 RVA: 0x001EBA74 File Offset: 0x001E9E74
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.BurningHeart,
			SkillType.Rebirth,
			SkillType.Swift
		};
	}

	// Token: 0x06004B24 RID: 19236 RVA: 0x001EBAAC File Offset: 0x001E9EAC
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		return new List<ResourceUpdate>
		{
			new ResourceUpdate
			{
				ResourceType = ResourceType.DirtyBadge,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			}
		};
	}

	// Token: 0x06004B25 RID: 19237 RVA: 0x001EBAF4 File Offset: 0x001E9EF4
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
		return new List<ISpecialEffectDataLoad>();
	}
}
