using System;
using System.Collections.Generic;

// Token: 0x02000B03 RID: 2819
public class PoisonStone : MinionUnitConfigurationBase
{
	// Token: 0x06004BA3 RID: 19363 RVA: 0x001F1536 File Offset: 0x001EF936
	public PoisonStone()
	{
	}

	// Token: 0x1700100B RID: 4107
	// (get) Token: 0x06004BA4 RID: 19364 RVA: 0x001F153E File Offset: 0x001EF93E
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PoisonStone;
		}
	}

	// Token: 0x1700100C RID: 4108
	// (get) Token: 0x06004BA5 RID: 19365 RVA: 0x001F1545 File Offset: 0x001EF945
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.Statue;
		}
	}

	// Token: 0x06004BA6 RID: 19366 RVA: 0x001F154C File Offset: 0x001EF94C
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.LightningSpeed
		};
	}

	// Token: 0x06004BA7 RID: 19367 RVA: 0x001F156C File Offset: 0x001EF96C
	public override List<ISpecialEffectDataLoad> FurtherSpecialEffectsFilter(List<ISpecialEffectDataLoad> original, DifficultyLevelMeasurement relevantDifficultyLevelMeasurement)
	{
		original.Add(new VictiousEffectData
		{
			DamageType = OutputType.Poison,
			IsStarEf = new bool?(false),
			CurrentTargets = new List<IBattleUnit>(),
			CurrentTargetCounter = 0,
			DamageRatePerSecond = 0.4,
			TargetSwitchTimerCap = 4
		});
		return original;
	}
}
