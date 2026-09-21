using System;
using System.Collections.Generic;

// Token: 0x02000AC3 RID: 2755
public class BlueHeartEater : MajorQuestBossConfiguration
{
	// Token: 0x06004A49 RID: 19017 RVA: 0x001E90AB File Offset: 0x001E74AB
	public BlueHeartEater()
	{
	}

	// Token: 0x17000F93 RID: 3987
	// (get) Token: 0x06004A4A RID: 19018 RVA: 0x001E90B3 File Offset: 0x001E74B3
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueHeartEater;
		}
	}

	// Token: 0x17000F94 RID: 3988
	// (get) Token: 0x06004A4B RID: 19019 RVA: 0x001E90BA File Offset: 0x001E74BA
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004A4C RID: 19020 RVA: 0x001E90C0 File Offset: 0x001E74C0
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (!ResourceType.FeetOfPrincess.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.FeetOfPrincess,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return list;
	}

	// Token: 0x06004A4D RID: 19021 RVA: 0x001E9118 File Offset: 0x001E7518
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.BurningHeart,
			SkillType.Rage
		};
	}

	// Token: 0x06004A4E RID: 19022 RVA: 0x001E9144 File Offset: 0x001E7544
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
			new DivineBlindnessData
			{
				IsStarEf = new bool?(false),
				ChargeCap = 3,
				ChargeCounter = 0,
				PushPercentage = 0.1
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
			}
		};
	}
}
