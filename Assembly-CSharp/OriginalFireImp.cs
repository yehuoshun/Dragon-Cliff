using System;
using System.Collections.Generic;

// Token: 0x02000AE5 RID: 2789
public class OriginalFireImp : BossUnitConfigurationBase
{
	// Token: 0x06004B2C RID: 19244 RVA: 0x001EBC2C File Offset: 0x001EA02C
	public OriginalFireImp()
	{
	}

	// Token: 0x17000FD3 RID: 4051
	// (get) Token: 0x06004B2D RID: 19245 RVA: 0x001EBC34 File Offset: 0x001EA034
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.FireImp;
		}
	}

	// Token: 0x17000FD4 RID: 4052
	// (get) Token: 0x06004B2E RID: 19246 RVA: 0x001EBC3B File Offset: 0x001EA03B
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004B2F RID: 19247 RVA: 0x001EBC3E File Offset: 0x001EA03E
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Physical;
	}

	// Token: 0x06004B30 RID: 19248 RVA: 0x001EBC44 File Offset: 0x001EA044
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		return new List<ResourceUpdate>
		{
			new ResourceUpdate
			{
				ResourceType = ResourceType.FirePlayerInvitation,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			},
			new ResourceUpdate
			{
				ResourceType = ResourceType.FlameBook,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			}
		};
	}

	// Token: 0x06004B31 RID: 19249 RVA: 0x001EBCBC File Offset: 0x001EA0BC
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.FireBurst
		};
	}

	// Token: 0x06004B32 RID: 19250 RVA: 0x001EBCDC File Offset: 0x001EA0DC
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new FieryTaleEffectData
			{
				StartFires = 4,
				FiresPerHit = 3
			},
			new ExtraTargetingData
			{
				IsStarEf = new bool?(false),
				Extra = 2,
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				}
			}
		};
	}
}
