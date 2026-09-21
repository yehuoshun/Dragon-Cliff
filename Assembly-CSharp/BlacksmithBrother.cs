using System;
using System.Collections.Generic;

// Token: 0x02000AC1 RID: 2753
public class BlacksmithBrother : MajorQuestBossConfiguration
{
	// Token: 0x06004A3C RID: 19004 RVA: 0x001E8DD1 File Offset: 0x001E71D1
	public BlacksmithBrother()
	{
	}

	// Token: 0x17000F8F RID: 3983
	// (get) Token: 0x06004A3D RID: 19005 RVA: 0x001E8DD9 File Offset: 0x001E71D9
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlacksmithBrother;
		}
	}

	// Token: 0x17000F90 RID: 3984
	// (get) Token: 0x06004A3E RID: 19006 RVA: 0x001E8DE0 File Offset: 0x001E71E0
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalDefender;
		}
	}

	// Token: 0x06004A3F RID: 19007 RVA: 0x001E8DE4 File Offset: 0x001E71E4
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Stun,
			SkillType.Stray
		};
	}

	// Token: 0x06004A40 RID: 19008 RVA: 0x001E8E0E File Offset: 0x001E720E
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Poison;
	}

	// Token: 0x06004A41 RID: 19009 RVA: 0x001E8E14 File Offset: 0x001E7214
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new MonksEyesData
				{
					MaxLoss = 0.28
				},
				new ExtraTargetingData
				{
					IsStarEf = new bool?(false),
					CandidateTypes = new List<TargetCandidateType>
					{
						TargetCandidateType.HostileAlive
					},
					Extra = 3
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new MonksEyesData
			{
				MaxLoss = 0.28
			}
		};
	}

	// Token: 0x06004A42 RID: 19010 RVA: 0x001E8EA8 File Offset: 0x001E72A8
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (!ResourceType.CrystalStone.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.CrystalStone,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		if (!ResourceType.RebirthBook.HasObtained())
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.RebirthBook,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		return list;
	}
}
