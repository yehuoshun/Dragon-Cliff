using System;
using System.Collections.Generic;

// Token: 0x02000AD2 RID: 2770
public class Nameless : MajorQuestBossConfiguration
{
	// Token: 0x06004AB4 RID: 19124 RVA: 0x001EA2E0 File Offset: 0x001E86E0
	public Nameless()
	{
	}

	// Token: 0x17000FAF RID: 4015
	// (get) Token: 0x06004AB5 RID: 19125 RVA: 0x001EA2E8 File Offset: 0x001E86E8
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Nameless;
		}
	}

	// Token: 0x17000FB0 RID: 4016
	// (get) Token: 0x06004AB6 RID: 19126 RVA: 0x001EA2EF File Offset: 0x001E86EF
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004AB7 RID: 19127 RVA: 0x001EA2F4 File Offset: 0x001E86F4
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Swift,
			SkillType.Meteorolite
		};
	}

	// Token: 0x06004AB8 RID: 19128 RVA: 0x001EA320 File Offset: 0x001E8720
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
				Chance = 1.0
			},
			new ExtraTargetingData
			{
				IsStarEf = new bool?(false),
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				},
				Extra = 4
			},
			new PushOnHitData
			{
				IsStar = true,
				PushBackRate = 0.05
			}
		};
	}

	// Token: 0x06004AB9 RID: 19129 RVA: 0x001EA418 File Offset: 0x001E8818
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (!ResourceType.BluePrintOfScrolls.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.BluePrintOfScrolls,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return list;
	}
}
