using System;
using System.Collections.Generic;

// Token: 0x02000ACC RID: 2764
public class GreedyMouth : MajorQuestBossConfiguration
{
	// Token: 0x06004A7F RID: 19071 RVA: 0x001E9CDA File Offset: 0x001E80DA
	public GreedyMouth()
	{
	}

	// Token: 0x17000FA5 RID: 4005
	// (get) Token: 0x06004A80 RID: 19072 RVA: 0x001E9CE2 File Offset: 0x001E80E2
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GreedyMouth;
		}
	}

	// Token: 0x17000FA6 RID: 4006
	// (get) Token: 0x06004A81 RID: 19073 RVA: 0x001E9CE9 File Offset: 0x001E80E9
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004A82 RID: 19074 RVA: 0x001E9CEC File Offset: 0x001E80EC
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Nightmare
		};
	}

	// Token: 0x06004A83 RID: 19075 RVA: 0x001E9D0C File Offset: 0x001E810C
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
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
			new ThousandWarmsNestData
			{
				ThousandSwarmChagedCounter = 0,
				ThousandSwarmLastingSeconds = 3f,
				ThousandSwarmChargeCapSeconds = 8,
				SelfStunSeconds = 2f,
				SwarmChancePerSecond = 1.0,
				MaxNumberOfSwarmsPerTarget = 6,
				SwarmDamageType = OutputType.Poison,
				LifeDrinkRate = 0.7,
				DamageRatePerWarm = 0.3
			}
		};
	}

	// Token: 0x06004A84 RID: 19076 RVA: 0x001E9DB4 File Offset: 0x001E81B4
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Poison;
	}

	// Token: 0x06004A85 RID: 19077 RVA: 0x001E9DB8 File Offset: 0x001E81B8
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (!ResourceType.BloodThirstBook.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.BloodThirstBook,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		if (!ResourceType.SnowMaidenInvitation.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.SnowMaidenInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return list;
	}
}
