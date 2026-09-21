using System;
using System.Collections.Generic;

// Token: 0x02000ACB RID: 2763
public class Golem : MajorQuestBossConfiguration
{
	// Token: 0x06004A79 RID: 19065 RVA: 0x001E9C33 File Offset: 0x001E8033
	public Golem()
	{
	}

	// Token: 0x17000FA3 RID: 4003
	// (get) Token: 0x06004A7A RID: 19066 RVA: 0x001E9C3B File Offset: 0x001E803B
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Golem;
		}
	}

	// Token: 0x17000FA4 RID: 4004
	// (get) Token: 0x06004A7B RID: 19067 RVA: 0x001E9C42 File Offset: 0x001E8042
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004A7C RID: 19068 RVA: 0x001E9C45 File Offset: 0x001E8045
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Divine;
	}

	// Token: 0x06004A7D RID: 19069 RVA: 0x001E9C48 File Offset: 0x001E8048
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ExtraTargetingData
			{
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				},
				Extra = 2
			},
			new DivineBlindnessData
			{
				ChargeCounter = 0,
				ChargeCap = 5,
				PushPercentage = 0.25
			}
		};
	}

	// Token: 0x06004A7E RID: 19070 RVA: 0x001E9CB0 File Offset: 0x001E80B0
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.ShieldBurn,
			SkillType.LightningSpeed
		};
	}
}
