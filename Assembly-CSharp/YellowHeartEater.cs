using System;
using System.Collections.Generic;

// Token: 0x02000ADC RID: 2780
public class YellowHeartEater : MajorQuestBossConfiguration
{
	// Token: 0x06004AEE RID: 19182 RVA: 0x001EABCF File Offset: 0x001E8FCF
	public YellowHeartEater()
	{
	}

	// Token: 0x17000FC3 RID: 4035
	// (get) Token: 0x06004AEF RID: 19183 RVA: 0x001EABD7 File Offset: 0x001E8FD7
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowHeartEater;
		}
	}

	// Token: 0x17000FC4 RID: 4036
	// (get) Token: 0x06004AF0 RID: 19184 RVA: 0x001EABDE File Offset: 0x001E8FDE
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004AF1 RID: 19185 RVA: 0x001EABE4 File Offset: 0x001E8FE4
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.StealSoul,
			SkillType.Stray
		};
	}

	// Token: 0x06004AF2 RID: 19186 RVA: 0x001EAC10 File Offset: 0x001E9010
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
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
				Extra = 3
			},
			new MonksEyesData
			{
				IsStarEf = new bool?(false),
				MaxLoss = 0.2
			},
			new RejuvenationEffectData
			{
				IsStarEf = new bool?(false),
				Rate = 0.05
			},
			new ClearWaterData
			{
				Chance = 1.0,
				IsStarEf = new bool?(false),
				NumberOfCleanUps = 3
			}
		};
	}

	// Token: 0x06004AF3 RID: 19187 RVA: 0x001EACE0 File Offset: 0x001E90E0
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (!ResourceType.EarsOfPrincess.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.EarsOfPrincess,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return list;
	}
}
