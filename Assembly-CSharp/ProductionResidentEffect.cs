using System;

// Token: 0x02000519 RID: 1305
[Serializable]
public class ProductionResidentEffect : IResidentEffect
{
	// Token: 0x06002680 RID: 9856 RVA: 0x001136C6 File Offset: 0x00111AC6
	public ProductionResidentEffect()
	{
	}

	// Token: 0x170002E6 RID: 742
	// (get) Token: 0x06002681 RID: 9857 RVA: 0x001136CE File Offset: 0x00111ACE
	public ResidentEffectType CorrespondingEffectType
	{
		get
		{
			return ResidentEffectType.Production;
		}
	}

	// Token: 0x06002682 RID: 9858 RVA: 0x001136D1 File Offset: 0x00111AD1
	public bool IsUnique()
	{
		return false;
	}

	// Token: 0x06002683 RID: 9859 RVA: 0x001136D4 File Offset: 0x00111AD4
	public void ProcessEvent(IResidentEffect effect, Resident resident, GameWorldEvent evt, object data)
	{
	}

	// Token: 0x06002684 RID: 9860 RVA: 0x001136D8 File Offset: 0x00111AD8
	public static IResidentEffect CreateDifficultyRelatedEffect(DifficultyLevelMeasurement measurement, double qualityCoeff)
	{
		double num = 0.2;
		if (measurement.DifficultyValue >= 70.0 || measurement.StarRating > 1)
		{
			num = 3.0;
		}
		else if (measurement.DifficultyValue >= 50.0)
		{
			num = 2.1;
		}
		else if (measurement.DifficultyValue >= 40.0)
		{
			num = 1.5;
		}
		else if (measurement.DifficultyValue >= 30.0)
		{
			num = 1.2;
		}
		else if (measurement.DifficultyValue >= 20.0)
		{
			num = 0.9;
		}
		else if (measurement.DifficultyValue >= 10.0)
		{
			num = 0.6;
		}
		num *= qualityCoeff;
		return new ProductionResidentEffect
		{
			CurrentRate = num
		};
	}

	// Token: 0x040020E3 RID: 8419
	public double CurrentRate;
}
