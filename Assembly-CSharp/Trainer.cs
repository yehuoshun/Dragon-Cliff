using System;
using System.Collections.Generic;

// Token: 0x02000ADB RID: 2779
public class Trainer : MajorQuestBossConfiguration
{
	// Token: 0x06004AE8 RID: 19176 RVA: 0x001EAAA1 File Offset: 0x001E8EA1
	public Trainer()
	{
	}

	// Token: 0x17000FC1 RID: 4033
	// (get) Token: 0x06004AE9 RID: 19177 RVA: 0x001EAAA9 File Offset: 0x001E8EA9
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Trainer;
		}
	}

	// Token: 0x17000FC2 RID: 4034
	// (get) Token: 0x06004AEA RID: 19178 RVA: 0x001EAAB0 File Offset: 0x001E8EB0
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}

	// Token: 0x06004AEB RID: 19179 RVA: 0x001EAAB4 File Offset: 0x001E8EB4
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (!ResourceType.BookCollection.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.BookCollection,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return list;
	}

	// Token: 0x06004AEC RID: 19180 RVA: 0x001EAB0C File Offset: 0x001E8F0C
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
			new KillingIntentEffectData
			{
				IsStarEf = new bool?(false),
				BoostRate = 0.5,
				PushRate = 0.1,
				ExtraTarget = 1,
				MaxStackSize = 3,
				TickChancePerSecond = 1.0,
				NumberOfApplicationPerTick = 1
			}
		};
	}

	// Token: 0x06004AED RID: 19181 RVA: 0x001EABB0 File Offset: 0x001E8FB0
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Meteorolite
		};
	}
}
