using System;
using System.Collections.Generic;

// Token: 0x02000A88 RID: 2696
public class PurpleBloodEye : ImperialMausoleumBossConfigurationBase
{
	// Token: 0x0600494B RID: 18763 RVA: 0x001E43B4 File Offset: 0x001E27B4
	public PurpleBloodEye()
	{
	}

	// Token: 0x17000F25 RID: 3877
	// (get) Token: 0x0600494C RID: 18764 RVA: 0x001E43BC File Offset: 0x001E27BC
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleBloodEye;
		}
	}

	// Token: 0x17000F26 RID: 3878
	// (get) Token: 0x0600494D RID: 18765 RVA: 0x001E43C3 File Offset: 0x001E27C3
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.Statue;
		}
	}

	// Token: 0x0600494E RID: 18766 RVA: 0x001E43C8 File Offset: 0x001E27C8
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new ProtectorsPrideEffectData
				{
					IsStarEf = new bool?(false),
					ShieldCount = 2,
					TauntChance = 1.0
				},
				new VictiousEffectData
				{
					DamageType = OutputType.Poison,
					IsStarEf = new bool?(false),
					CurrentTargets = new List<IBattleUnit>(),
					CurrentTargetCounter = 0,
					TargetSwitchTimerCap = 10,
					DamageRatePerSecond = 1.6
				},
				new RejuvenationEffectData
				{
					IsStarEf = new bool?(false),
					Rate = 0.01
				},
				new MonksEyesData
				{
					IsStarEf = new bool?(false),
					MaxLoss = 0.2
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new ProtectorsPrideEffectData
			{
				IsStarEf = new bool?(false),
				ShieldCount = 2,
				TauntChance = 1.0
			},
			new VictiousEffectData
			{
				DamageType = OutputType.Poison,
				IsStarEf = new bool?(false),
				CurrentTargets = new List<IBattleUnit>(),
				CurrentTargetCounter = 0,
				TargetSwitchTimerCap = 10,
				DamageRatePerSecond = 1.6
			},
			new RejuvenationEffectData
			{
				IsStarEf = new bool?(false),
				Rate = 0.01
			}
		};
	}
}
