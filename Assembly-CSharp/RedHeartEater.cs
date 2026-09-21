using System;
using System.Collections.Generic;

// Token: 0x02000AD6 RID: 2774
public class RedHeartEater : MajorQuestBossConfiguration
{
	// Token: 0x06004ACC RID: 19148 RVA: 0x001EA70D File Offset: 0x001E8B0D
	public RedHeartEater()
	{
	}

	// Token: 0x17000FB7 RID: 4023
	// (get) Token: 0x06004ACD RID: 19149 RVA: 0x001EA715 File Offset: 0x001E8B15
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedHeartEater;
		}
	}

	// Token: 0x17000FB8 RID: 4024
	// (get) Token: 0x06004ACE RID: 19150 RVA: 0x001EA71C File Offset: 0x001E8B1C
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004ACF RID: 19151 RVA: 0x001EA71F File Offset: 0x001E8B1F
	protected override UnitGrowthProfile FurtherProfileModification(UnitGrowthProfile originalGrowthProfile, DifficultyLevelMeasurement measurement)
	{
		originalGrowthProfile.SetValue(AttributeType.TauntOnHit, 0.7, false);
		return originalGrowthProfile;
	}

	// Token: 0x06004AD0 RID: 19152 RVA: 0x001EA738 File Offset: 0x001E8B38
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Taunt,
			SkillType.BloodThirst
		};
	}

	// Token: 0x06004AD1 RID: 19153 RVA: 0x001EA764 File Offset: 0x001E8B64
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new MonksEyesData
			{
				IsStarEf = new bool?(false),
				MaxLoss = 0.2
			},
			new RejuvenationEffectData
			{
				IsStarEf = new bool?(false),
				Rate = 0.02
			}
		};
	}

	// Token: 0x06004AD2 RID: 19154 RVA: 0x001EA7C8 File Offset: 0x001E8BC8
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (!ResourceType.ForeheadOfPrincess.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.ForeheadOfPrincess,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return list;
	}
}
