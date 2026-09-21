using System;
using System.Collections.Generic;

// Token: 0x02000ADD RID: 2781
public class BlacksmithBrotherRm : RemnantsBossBase
{
	// Token: 0x06004AF4 RID: 19188 RVA: 0x001EB126 File Offset: 0x001E9526
	public BlacksmithBrotherRm()
	{
	}

	// Token: 0x17000FC5 RID: 4037
	// (get) Token: 0x06004AF5 RID: 19189 RVA: 0x001EB12E File Offset: 0x001E952E
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlacksmithBrother_Remnants;
		}
	}

	// Token: 0x17000FC6 RID: 4038
	// (get) Token: 0x06004AF6 RID: 19190 RVA: 0x001EB135 File Offset: 0x001E9535
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004AF7 RID: 19191 RVA: 0x001EB138 File Offset: 0x001E9538
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Stun,
			SkillType.Stray
		};
	}

	// Token: 0x06004AF8 RID: 19192 RVA: 0x001EB162 File Offset: 0x001E9562
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Poison;
	}

	// Token: 0x06004AF9 RID: 19193 RVA: 0x001EB168 File Offset: 0x001E9568
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new MonksEyesData
				{
					MaxLoss = 0.2
				},
				new ExtraTargetingData
				{
					IsStarEf = new bool?(false),
					CandidateTypes = new List<TargetCandidateType>
					{
						TargetCandidateType.HostileAlive
					},
					Extra = 3
				},
				new DispelOnHitData
				{
					Chance = 0.6,
					IsStar = false,
					NumberOfDispels = 1
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new MonksEyesData
			{
				MaxLoss = 0.28
			}
		};
	}

	// Token: 0x06004AFA RID: 19194 RVA: 0x001EB22C File Offset: 0x001E962C
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (!ResourceType.CrystalStone.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.CrystalStone,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		if (!ResourceType.RebirthBook.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.RebirthBook,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return list;
	}
}
