using System;
using System.Collections.Generic;

// Token: 0x02000AFF RID: 2815
public class FireStone : MinionUnitConfigurationBase
{
	// Token: 0x06004B94 RID: 19348 RVA: 0x001F1301 File Offset: 0x001EF701
	public FireStone()
	{
	}

	// Token: 0x17001003 RID: 4099
	// (get) Token: 0x06004B95 RID: 19349 RVA: 0x001F1309 File Offset: 0x001EF709
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.FireStone;
		}
	}

	// Token: 0x17001004 RID: 4100
	// (get) Token: 0x06004B96 RID: 19350 RVA: 0x001F1310 File Offset: 0x001EF710
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.Statue;
		}
	}

	// Token: 0x06004B97 RID: 19351 RVA: 0x001F1314 File Offset: 0x001EF714
	public override List<ISpecialEffectDataLoad> FurtherSpecialEffectsFilter(List<ISpecialEffectDataLoad> original, DifficultyLevelMeasurement relevantDifficultyLevelMeasurement)
	{
		original.AddRange(new List<ISpecialEffectDataLoad>
		{
			new ImmortalShieldEffectData
			{
				IsStarEf = new bool?(false),
				NumberOfShields = 1
			},
			new VictiousEffectData
			{
				DamageType = OutputType.Fire,
				IsStarEf = new bool?(false),
				CurrentTargets = new List<IBattleUnit>(),
				CurrentTargetCounter = 0,
				TargetSwitchTimerCap = 10,
				DamageRatePerSecond = 0.3
			}
		});
		return original;
	}
}
