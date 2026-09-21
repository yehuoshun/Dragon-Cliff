using System;
using System.Collections.Generic;

// Token: 0x02000ACD RID: 2765
public class Hydra : MajorQuestBossConfiguration
{
	// Token: 0x06004A86 RID: 19078 RVA: 0x001E9E50 File Offset: 0x001E8250
	public Hydra()
	{
	}

	// Token: 0x17000FA7 RID: 4007
	// (get) Token: 0x06004A87 RID: 19079 RVA: 0x001E9E58 File Offset: 0x001E8258
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Hydra;
		}
	}

	// Token: 0x17000FA8 RID: 4008
	// (get) Token: 0x06004A88 RID: 19080 RVA: 0x001E9E5F File Offset: 0x001E825F
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004A89 RID: 19081 RVA: 0x001E9E62 File Offset: 0x001E8262
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Fire;
	}

	// Token: 0x06004A8A RID: 19082 RVA: 0x001E9E68 File Offset: 0x001E8268
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ExtraTargetingData
			{
				Extra = 2,
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				}
			},
			new HydraSpiritData
			{
				TickCounter = 0,
				HealRate = 0.05,
				TickCap = 3,
				MaxFireySoulCap = 5
			}
		};
	}

	// Token: 0x06004A8B RID: 19083 RVA: 0x001E9ED8 File Offset: 0x001E82D8
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Pierce,
			SkillType.Swift,
			SkillType.BloodThirst
		};
	}
}
