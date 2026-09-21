using System;
using System.Collections.Generic;

// Token: 0x02000AD4 RID: 2772
public class Puppet : MajorQuestBossConfiguration
{
	// Token: 0x06004AC1 RID: 19137 RVA: 0x001EA567 File Offset: 0x001E8967
	public Puppet()
	{
	}

	// Token: 0x17000FB3 RID: 4019
	// (get) Token: 0x06004AC2 RID: 19138 RVA: 0x001EA56F File Offset: 0x001E896F
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Puppet;
		}
	}

	// Token: 0x17000FB4 RID: 4020
	// (get) Token: 0x06004AC3 RID: 19139 RVA: 0x001EA576 File Offset: 0x001E8976
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}

	// Token: 0x06004AC4 RID: 19140 RVA: 0x001EA579 File Offset: 0x001E8979
	protected override UnitGrowthProfile FurtherProfileModification(UnitGrowthProfile originalGrowthProfile, DifficultyLevelMeasurement measurement)
	{
		originalGrowthProfile.SetValue(AttributeType.Resilience, 17000.0, false);
		return originalGrowthProfile;
	}

	// Token: 0x06004AC5 RID: 19141 RVA: 0x001EA594 File Offset: 0x001E8994
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (!ResourceType.HarmoneyBook.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.HarmoneyBook,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return list;
	}

	// Token: 0x06004AC6 RID: 19142 RVA: 0x001EA5EB File Offset: 0x001E89EB
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Fire;
	}

	// Token: 0x06004AC7 RID: 19143 RVA: 0x001EA5F0 File Offset: 0x001E89F0
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Nightmare,
			SkillType.Swift
		};
	}

	// Token: 0x06004AC8 RID: 19144 RVA: 0x001EA61C File Offset: 0x001E8A1C
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
				Extra = 4
			},
			new FieryTaleEffectData
			{
				IsStarEf = new bool?(false),
				FiresPerHit = 2,
				StartFires = 2
			},
			new HydraSpiritData
			{
				IsStarEf = new bool?(false),
				HealRate = 0.2,
				TickCounter = 0,
				MaxFireySoulCap = 4,
				TickCap = 2
			},
			new MonksEyesData
			{
				IsStarEf = new bool?(false),
				MaxLoss = 0.2
			}
		};
	}
}
