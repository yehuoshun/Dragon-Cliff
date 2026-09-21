using System;

// Token: 0x02000515 RID: 1301
[Serializable]
public class DivineHeartResidentEffect : IResidentEffect
{
	// Token: 0x0600266C RID: 9836 RVA: 0x00113276 File Offset: 0x00111676
	public DivineHeartResidentEffect()
	{
	}

	// Token: 0x170002E2 RID: 738
	// (get) Token: 0x0600266D RID: 9837 RVA: 0x0011327E File Offset: 0x0011167E
	public ResidentEffectType CorrespondingEffectType
	{
		get
		{
			return ResidentEffectType.DivineHeart;
		}
	}

	// Token: 0x0600266E RID: 9838 RVA: 0x00113281 File Offset: 0x00111681
	public bool IsUnique()
	{
		return false;
	}

	// Token: 0x0600266F RID: 9839 RVA: 0x00113284 File Offset: 0x00111684
	public void ProcessEvent(IResidentEffect effect, Resident resident, GameWorldEvent evt, object data)
	{
	}

	// Token: 0x06002670 RID: 9840 RVA: 0x00113288 File Offset: 0x00111688
	public static IResidentEffect CreateDifficultyRelatedEffect(DifficultyLevelMeasurement measurement, double qualityCoeff)
	{
		double num = 0.06;
		if (measurement.DifficultyValue >= 70.0 || measurement.StarRating > 1)
		{
			num = 0.6;
		}
		else if (measurement.DifficultyValue >= 50.0)
		{
			num = 0.5;
		}
		else if (measurement.DifficultyValue >= 40.0)
		{
			num = 0.4;
		}
		else if (measurement.DifficultyValue >= 30.0)
		{
			num = 0.3;
		}
		else if (measurement.DifficultyValue >= 20.0)
		{
			num = 0.2;
		}
		else if (measurement.DifficultyValue >= 10.0)
		{
			num = 0.1;
		}
		num *= qualityCoeff;
		return new DivineHeartResidentEffect
		{
			CurrentRate = num
		};
	}

	// Token: 0x040020DF RID: 8415
	public double CurrentRate;
}
