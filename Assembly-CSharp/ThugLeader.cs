using System;
using System.Collections.Generic;

// Token: 0x02000ADA RID: 2778
public class ThugLeader : MajorQuestBossConfiguration
{
	// Token: 0x06004AE2 RID: 19170 RVA: 0x001EA93A File Offset: 0x001E8D3A
	public ThugLeader()
	{
	}

	// Token: 0x17000FBF RID: 4031
	// (get) Token: 0x06004AE3 RID: 19171 RVA: 0x001EA942 File Offset: 0x001E8D42
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.ThugLeaderBoss;
		}
	}

	// Token: 0x17000FC0 RID: 4032
	// (get) Token: 0x06004AE4 RID: 19172 RVA: 0x001EA949 File Offset: 0x001E8D49
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004AE5 RID: 19173 RVA: 0x001EA94C File Offset: 0x001E8D4C
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Swift,
			SkillType.Stun
		};
	}

	// Token: 0x06004AE6 RID: 19174 RVA: 0x001EA978 File Offset: 0x001E8D78
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (!ResourceType.GrindingTable.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.GrindingTable,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return list;
	}

	// Token: 0x06004AE7 RID: 19175 RVA: 0x001EA9D0 File Offset: 0x001E8DD0
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ThugPowerData
			{
				IsStar = false
			},
			new TimeLockResistanceData
			{
				IsStar = false,
				Chance = 1.0
			},
			new TurnResistanceData
			{
				IsStar = false,
				Rate = 1.0
			},
			new EffectSealData
			{
				IsStar = false,
				Chance = 0.4
			},
			new ExtraTargetingData
			{
				IsStarEf = new bool?(false),
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				},
				Extra = 4
			}
		};
	}
}
