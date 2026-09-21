using System;

// Token: 0x02000516 RID: 1302
[Serializable]
public class LuckResidentEffect : IResidentEffect
{
	// Token: 0x06002671 RID: 9841 RVA: 0x0011338A File Offset: 0x0011178A
	public LuckResidentEffect()
	{
	}

	// Token: 0x170002E3 RID: 739
	// (get) Token: 0x06002672 RID: 9842 RVA: 0x00113392 File Offset: 0x00111792
	public ResidentEffectType CorrespondingEffectType
	{
		get
		{
			return ResidentEffectType.Luck;
		}
	}

	// Token: 0x06002673 RID: 9843 RVA: 0x00113395 File Offset: 0x00111795
	public bool IsUnique()
	{
		return false;
	}

	// Token: 0x06002674 RID: 9844 RVA: 0x00113398 File Offset: 0x00111798
	public void ProcessEvent(IResidentEffect effect, Resident resident, GameWorldEvent evt, object data)
	{
	}

	// Token: 0x06002675 RID: 9845 RVA: 0x0011339C File Offset: 0x0011179C
	public static IResidentEffect CreateDifficultyRelatedEffect(DifficultyLevelMeasurement measurement, double qualityCoeff)
	{
		double num = 0.1;
		if (measurement.DifficultyValue >= 70.0 || measurement.StarRating > 1)
		{
			num = 1.5;
		}
		else if (measurement.DifficultyValue >= 50.0)
		{
			num = 1.05;
		}
		else if (measurement.DifficultyValue >= 40.0)
		{
			num = 0.75;
		}
		else if (measurement.DifficultyValue >= 30.0)
		{
			num = 0.6;
		}
		else if (measurement.DifficultyValue >= 20.0)
		{
			num = 0.45;
		}
		else if (measurement.DifficultyValue >= 10.0)
		{
			num = 0.3;
		}
		num *= qualityCoeff;
		return new LuckResidentEffect
		{
			CurrentRate = num
		};
	}

	// Token: 0x040020E0 RID: 8416
	public double CurrentRate;
}
