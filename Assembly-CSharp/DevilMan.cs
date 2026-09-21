using System;
using System.Collections.Generic;

// Token: 0x02000AC9 RID: 2761
public class DevilMan : MajorQuestBossConfiguration
{
	// Token: 0x06004A6D RID: 19053 RVA: 0x001E9A9B File Offset: 0x001E7E9B
	public DevilMan()
	{
	}

	// Token: 0x17000F9F RID: 3999
	// (get) Token: 0x06004A6E RID: 19054 RVA: 0x001E9AA3 File Offset: 0x001E7EA3
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.DevilMan;
		}
	}

	// Token: 0x17000FA0 RID: 4000
	// (get) Token: 0x06004A6F RID: 19055 RVA: 0x001E9AAA File Offset: 0x001E7EAA
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}

	// Token: 0x06004A70 RID: 19056 RVA: 0x001E9AAD File Offset: 0x001E7EAD
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Fire;
	}

	// Token: 0x06004A71 RID: 19057 RVA: 0x001E9AB0 File Offset: 0x001E7EB0
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
			}
		};
	}

	// Token: 0x06004A72 RID: 19058 RVA: 0x001E9AEC File Offset: 0x001E7EEC
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.LightFire,
			SkillType.Flame,
			SkillType.MultiStrike
		};
	}
}
