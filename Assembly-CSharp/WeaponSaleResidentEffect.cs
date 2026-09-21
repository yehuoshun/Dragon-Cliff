using System;

// Token: 0x0200051C RID: 1308
[Serializable]
public class WeaponSaleResidentEffect : IResidentEffect
{
	// Token: 0x0600268F RID: 9871 RVA: 0x00113A02 File Offset: 0x00111E02
	public WeaponSaleResidentEffect()
	{
	}

	// Token: 0x170002E9 RID: 745
	// (get) Token: 0x06002690 RID: 9872 RVA: 0x00113A0A File Offset: 0x00111E0A
	public ResidentEffectType CorrespondingEffectType
	{
		get
		{
			return ResidentEffectType.WeaponSale;
		}
	}

	// Token: 0x06002691 RID: 9873 RVA: 0x00113A0D File Offset: 0x00111E0D
	public bool IsUnique()
	{
		return false;
	}

	// Token: 0x06002692 RID: 9874 RVA: 0x00113A10 File Offset: 0x00111E10
	public void ProcessEvent(IResidentEffect effect, Resident resident, GameWorldEvent evt, object data)
	{
	}

	// Token: 0x06002693 RID: 9875 RVA: 0x00113A14 File Offset: 0x00111E14
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
		return new WeaponSaleResidentEffect
		{
			CurrentRate = num
		};
	}

	// Token: 0x040020E6 RID: 8422
	public double CurrentRate;
}
