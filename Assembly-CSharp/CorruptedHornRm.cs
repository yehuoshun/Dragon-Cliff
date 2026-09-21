using System;
using System.Collections.Generic;

// Token: 0x02000ADF RID: 2783
public class CorruptedHornRm : RemnantsBossBase
{
	// Token: 0x06004B01 RID: 19201 RVA: 0x001EB380 File Offset: 0x001E9780
	public CorruptedHornRm()
	{
	}

	// Token: 0x17000FC9 RID: 4041
	// (get) Token: 0x06004B02 RID: 19202 RVA: 0x001EB388 File Offset: 0x001E9788
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.CorruptedHorn_Remnants;
		}
	}

	// Token: 0x17000FCA RID: 4042
	// (get) Token: 0x06004B03 RID: 19203 RVA: 0x001EB38F File Offset: 0x001E978F
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004B04 RID: 19204 RVA: 0x001EB394 File Offset: 0x001E9794
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
					Extra = 2
				},
				new UndeadAshData
				{
					PerLossRate = 0.1,
					PerIncreaseRate = 0.5,
					PreviousLossLayers = 0,
					DamageSoFar = 0.0
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new UndeadAshData
			{
				PerLossRate = 0.1,
				PerIncreaseRate = 0.5,
				PreviousLossLayers = 0,
				DamageSoFar = 0.0
			}
		};
	}

	// Token: 0x06004B05 RID: 19205 RVA: 0x001EB474 File Offset: 0x001E9874
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (!ResourceType.DragonBloodStone.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.DragonBloodStone,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return list;
	}

	// Token: 0x06004B06 RID: 19206 RVA: 0x001EB4CC File Offset: 0x001E98CC
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.CorruptedPower,
			SkillType.Flame
		};
	}
}
