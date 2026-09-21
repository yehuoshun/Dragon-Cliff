using System;
using System.Collections.Generic;

// Token: 0x02000ACF RID: 2767
public class LavaBeast : MajorQuestBossConfiguration
{
	// Token: 0x06004A91 RID: 19089 RVA: 0x001E9F92 File Offset: 0x001E8392
	public LavaBeast()
	{
	}

	// Token: 0x17000FAB RID: 4011
	// (get) Token: 0x06004A92 RID: 19090 RVA: 0x001E9F9A File Offset: 0x001E839A
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.LavaBeast;
		}
	}

	// Token: 0x17000FAC RID: 4012
	// (get) Token: 0x06004A93 RID: 19091 RVA: 0x001E9FA1 File Offset: 0x001E83A1
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004A94 RID: 19092 RVA: 0x001E9FA4 File Offset: 0x001E83A4
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Fire;
	}

	// Token: 0x06004A95 RID: 19093 RVA: 0x001E9FA8 File Offset: 0x001E83A8
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.FireBall,
			SkillType.Flame
		};
	}

	// Token: 0x06004A96 RID: 19094 RVA: 0x001E9FD4 File Offset: 0x001E83D4
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new LavaBeastEffectData
				{
					HaveRevived = false,
					SecondStageSkill = SkillType.FireBreath,
					SecondStageSkillLevel = 9,
					FireSeedChancePerSecond = 1.0,
					ReviveRate = 1.0
				},
				new FieryTaleEffectData
				{
					IsStarEf = new bool?(false),
					FiresPerHit = 2,
					StartFires = 2
				},
				new ExtraTargetingData
				{
					IsStarEf = new bool?(false),
					CandidateTypes = new List<TargetCandidateType>
					{
						TargetCandidateType.HostileAlive
					},
					Extra = 2
				},
				new DispelOnHitData
				{
					Chance = 0.7,
					IsStar = false,
					NumberOfDispels = 1
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new LavaBeastEffectData
			{
				HaveRevived = false,
				SecondStageSkill = SkillType.FireBreath,
				SecondStageSkillLevel = 1,
				FireSeedChancePerSecond = 1.0,
				ReviveRate = 1.0
			},
			new ExtraTargetingData
			{
				Extra = 2,
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				}
			}
		};
	}

	// Token: 0x06004A97 RID: 19095 RVA: 0x001EA140 File Offset: 0x001E8540
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (!ResourceType.PaladinInvitation.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.PaladinInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return list;
	}
}
