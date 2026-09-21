using System;

// Token: 0x02000517 RID: 1303
[Serializable]
public class MysticStoneResidentEffect : IResidentEffect
{
	// Token: 0x06002676 RID: 9846 RVA: 0x0011349E File Offset: 0x0011189E
	public MysticStoneResidentEffect()
	{
	}

	// Token: 0x170002E4 RID: 740
	// (get) Token: 0x06002677 RID: 9847 RVA: 0x001134A6 File Offset: 0x001118A6
	public ResidentEffectType CorrespondingEffectType
	{
		get
		{
			return ResidentEffectType.MysticStone;
		}
	}

	// Token: 0x06002678 RID: 9848 RVA: 0x001134A9 File Offset: 0x001118A9
	public bool IsUnique()
	{
		return false;
	}

	// Token: 0x06002679 RID: 9849 RVA: 0x001134AC File Offset: 0x001118AC
	public void ProcessEvent(IResidentEffect effect, Resident resident, GameWorldEvent evt, object data)
	{
	}

	// Token: 0x0600267A RID: 9850 RVA: 0x001134B0 File Offset: 0x001118B0
	public static IResidentEffect CreateDifficultyRelatedEffect(DifficultyLevelMeasurement measurement, double qualityCoeff)
	{
		double num = 0.08;
		if (measurement.DifficultyValue >= 70.0 || measurement.StarRating > 1)
		{
			num = 0.5;
		}
		else if (measurement.DifficultyValue >= 50.0)
		{
			num = 0.42;
		}
		else if (measurement.DifficultyValue >= 40.0)
		{
			num = 0.37;
		}
		else if (measurement.DifficultyValue >= 30.0)
		{
			num = 0.3;
		}
		else if (measurement.DifficultyValue >= 20.0)
		{
			num = 0.22;
		}
		else if (measurement.DifficultyValue >= 10.0)
		{
			num = 0.15;
		}
		num *= qualityCoeff;
		return new MysticStoneResidentEffect
		{
			CurrentRate = num
		};
	}

	// Token: 0x040020E1 RID: 8417
	public double CurrentRate;
}
