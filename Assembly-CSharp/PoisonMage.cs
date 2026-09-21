using System;
using System.Collections.Generic;

// Token: 0x02000A86 RID: 2694
public class PoisonMage : ImperialMausoleumBossConfigurationBase
{
	// Token: 0x06004941 RID: 18753 RVA: 0x001E4262 File Offset: 0x001E2662
	public PoisonMage()
	{
	}

	// Token: 0x17000F21 RID: 3873
	// (get) Token: 0x06004942 RID: 18754 RVA: 0x001E426A File Offset: 0x001E266A
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PoisonMage;
		}
	}

	// Token: 0x17000F22 RID: 3874
	// (get) Token: 0x06004943 RID: 18755 RVA: 0x001E4271 File Offset: 0x001E2671
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004944 RID: 18756 RVA: 0x001E4274 File Offset: 0x001E2674
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Nightmare,
			SkillType.Flame
		};
	}

	// Token: 0x06004945 RID: 18757 RVA: 0x001E42A0 File Offset: 0x001E26A0
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ExtraTargetingData
			{
				Extra = 3,
				CandidateTypes = new List<TargetCandidateType>
				{
					TargetCandidateType.HostileAlive
				},
				IsStarEf = new bool?(false)
			},
			new DivineBlindnessData
			{
				IsStarEf = new bool?(false),
				ChargeCap = 4,
				ChargeCounter = 0,
				PushPercentage = 0.5
			}
		};
	}
}
