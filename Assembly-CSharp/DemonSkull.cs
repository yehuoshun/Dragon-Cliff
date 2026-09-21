using System;
using System.Collections.Generic;

// Token: 0x02000AC8 RID: 2760
public class DemonSkull : MajorQuestBossConfiguration
{
	// Token: 0x06004A66 RID: 19046 RVA: 0x001E975A File Offset: 0x001E7B5A
	public DemonSkull()
	{
	}

	// Token: 0x17000F9D RID: 3997
	// (get) Token: 0x06004A67 RID: 19047 RVA: 0x001E9762 File Offset: 0x001E7B62
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.DemonSkull;
		}
	}

	// Token: 0x17000F9E RID: 3998
	// (get) Token: 0x06004A68 RID: 19048 RVA: 0x001E9769 File Offset: 0x001E7B69
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004A69 RID: 19049 RVA: 0x001E976C File Offset: 0x001E7B6C
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Poison;
	}

	// Token: 0x06004A6A RID: 19050 RVA: 0x001E9770 File Offset: 0x001E7B70
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>();
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			list.Add(new ExtraTargetingData
			{
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				},
				Extra = 3
			});
			list.Add(new DemonSkullData
			{
				SoulCharged = 0.0,
				HaveRevived = false,
				ReviveRate = 1.0,
				ChargedAgilityBoostValue = 500.0,
				RebirthStrengthBoostValue = 200.0,
				BleedingDamageRate = 0.2,
				BleedingChanceOnHit = 0.7,
				BleedingLastingSeconds = 3f,
				SoulChargeRatePerBleeding = 0.1,
				BleedingDamageType = OutputType.Poison,
				NumberOfBleedingsOnRebirth = 3,
				RebirthBleedingDamageRate = 0.1,
				RebirthBleedingDamageType = OutputType.Poison,
				RebirthBleedingLastingSeconds = 10f
			});
		}
		else if (difficultyLevelMeasurement.DifficultyValue >= 35.0)
		{
			list.Add(new ExtraTargetingData
			{
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				},
				Extra = 2
			});
			list.Add(new DemonSkullData
			{
				SoulCharged = 0.0,
				HaveRevived = false,
				ReviveRate = 1.0,
				ChargedAgilityBoostValue = 200.0,
				RebirthStrengthBoostValue = 50.0,
				BleedingDamageRate = 0.2,
				BleedingChanceOnHit = 0.5,
				BleedingLastingSeconds = 3f,
				SoulChargeRatePerBleeding = 0.1,
				BleedingDamageType = OutputType.Poison,
				NumberOfBleedingsOnRebirth = 3,
				RebirthBleedingDamageRate = 0.1,
				RebirthBleedingDamageType = OutputType.Poison,
				RebirthBleedingLastingSeconds = 10f
			});
		}
		else
		{
			list.Add(new DemonSkullData
			{
				SoulCharged = 0.0,
				HaveRevived = false,
				ReviveRate = 0.7,
				ChargedAgilityBoostValue = 100.0,
				RebirthStrengthBoostValue = 20.0,
				BleedingDamageRate = 0.1,
				BleedingChanceOnHit = 0.2,
				BleedingLastingSeconds = 2f,
				SoulChargeRatePerBleeding = 0.1,
				BleedingDamageType = OutputType.Poison,
				NumberOfBleedingsOnRebirth = 1,
				RebirthBleedingDamageRate = 0.1,
				RebirthBleedingDamageType = OutputType.Poison,
				RebirthBleedingLastingSeconds = 5f
			});
		}
		return list;
	}

	// Token: 0x06004A6B RID: 19051 RVA: 0x001E9A24 File Offset: 0x001E7E24
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (!ResourceType.NightBladeInvitation.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.NightBladeInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return list;
	}

	// Token: 0x06004A6C RID: 19052 RVA: 0x001E9A7C File Offset: 0x001E7E7C
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.StealSoul
		};
	}
}
