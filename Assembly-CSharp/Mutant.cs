using System;
using System.Collections.Generic;

// Token: 0x02000AD1 RID: 2769
public class Mutant : MajorQuestBossConfiguration
{
	// Token: 0x06004AAF RID: 19119 RVA: 0x001EA197 File Offset: 0x001E8597
	public Mutant()
	{
	}

	// Token: 0x17000FAD RID: 4013
	// (get) Token: 0x06004AB0 RID: 19120 RVA: 0x001EA19F File Offset: 0x001E859F
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Mutant;
		}
	}

	// Token: 0x17000FAE RID: 4014
	// (get) Token: 0x06004AB1 RID: 19121 RVA: 0x001EA1A6 File Offset: 0x001E85A6
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}

	// Token: 0x06004AB2 RID: 19122 RVA: 0x001EA1AC File Offset: 0x001E85AC
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (!ResourceType.MysticStone.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.MysticStone,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return list;
	}

	// Token: 0x06004AB3 RID: 19123 RVA: 0x001EA204 File Offset: 0x001E8604
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new ExtraTargetingData
				{
					Extra = 3,
					CandidateTypes = new List<TargetCandidateType>
					{
						TargetCandidateType.HostileAlive
					}
				},
				new AttributeDestroyData
				{
					Chance = 0.6,
					ReplaceAttribute = AttributeType.Agility,
					ReplacementValue = 1.0
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new ExtraTargetingData
			{
				Extra = 1,
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				}
			},
			new AttributeDestroyData
			{
				Chance = 0.3,
				ReplaceAttribute = AttributeType.Agility,
				ReplacementValue = 1.0
			}
		};
	}
}
