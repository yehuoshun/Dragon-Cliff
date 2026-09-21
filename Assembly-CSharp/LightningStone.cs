using System;
using System.Collections.Generic;

// Token: 0x02000B02 RID: 2818
public class LightningStone : MinionUnitConfigurationBase
{
	// Token: 0x06004B9F RID: 19359 RVA: 0x001F1461 File Offset: 0x001EF861
	public LightningStone()
	{
	}

	// Token: 0x17001009 RID: 4105
	// (get) Token: 0x06004BA0 RID: 19360 RVA: 0x001F147C File Offset: 0x001EF87C
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return this._correspondingUnitClass;
		}
	}

	// Token: 0x1700100A RID: 4106
	// (get) Token: 0x06004BA1 RID: 19361 RVA: 0x001F1484 File Offset: 0x001EF884
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return this._correspondingClassStyle;
		}
	}

	// Token: 0x06004BA2 RID: 19362 RVA: 0x001F148C File Offset: 0x001EF88C
	public override List<ISpecialEffectDataLoad> FurtherSpecialEffectsFilter(List<ISpecialEffectDataLoad> original, DifficultyLevelMeasurement relevantDifficultyLevelMeasurement)
	{
		original.AddRange(new List<ISpecialEffectDataLoad>
		{
			new StoneGuardEffectData
			{
				IsStarEf = new bool?(false),
				StunSeconds = 2.0,
				ProgressPush = 0.4,
				ChancePerSecond = 0.3
			},
			new VictiousEffectData
			{
				DamageType = OutputType.Lightening,
				IsStarEf = new bool?(false),
				CurrentTargets = new List<IBattleUnit>(),
				CurrentTargetCounter = 0,
				TargetSwitchTimerCap = 10,
				DamageRatePerSecond = 0.4
			}
		});
		return original;
	}

	// Token: 0x04003AC4 RID: 15044
	private readonly UnitClass _correspondingUnitClass = UnitClass.LightningStone;

	// Token: 0x04003AC5 RID: 15045
	private readonly UnitClassStyle _correspondingClassStyle = UnitClassStyle.Statue;
}
