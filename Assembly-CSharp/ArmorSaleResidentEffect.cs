using System;

// Token: 0x02000513 RID: 1299
[Serializable]
public class ArmorSaleResidentEffect : IResidentEffect
{
	// Token: 0x06002661 RID: 9825 RVA: 0x0011313B File Offset: 0x0011153B
	public ArmorSaleResidentEffect()
	{
	}

	// Token: 0x170002E0 RID: 736
	// (get) Token: 0x06002662 RID: 9826 RVA: 0x00113143 File Offset: 0x00111543
	public ResidentEffectType CorrespondingEffectType
	{
		get
		{
			return ResidentEffectType.ArmorSale;
		}
	}

	// Token: 0x06002663 RID: 9827 RVA: 0x00113146 File Offset: 0x00111546
	public bool IsUnique()
	{
		return false;
	}

	// Token: 0x06002664 RID: 9828 RVA: 0x00113149 File Offset: 0x00111549
	public void ProcessEvent(IResidentEffect effect, Resident resident, GameWorldEvent evt, object data)
	{
	}

	// Token: 0x06002665 RID: 9829 RVA: 0x0011314C File Offset: 0x0011154C
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
		return new ArmorSaleResidentEffect
		{
			CurrentRate = num
		};
	}

	// Token: 0x040020DD RID: 8413
	public double CurrentRate;
}
