using System;

// Token: 0x0200051B RID: 1307
[Serializable]
public class WealthResidentEffect : IResidentEffect
{
	// Token: 0x0600268A RID: 9866 RVA: 0x001138EE File Offset: 0x00111CEE
	public WealthResidentEffect()
	{
	}

	// Token: 0x170002E8 RID: 744
	// (get) Token: 0x0600268B RID: 9867 RVA: 0x001138F6 File Offset: 0x00111CF6
	public ResidentEffectType CorrespondingEffectType
	{
		get
		{
			return ResidentEffectType.Wealth;
		}
	}

	// Token: 0x0600268C RID: 9868 RVA: 0x001138FA File Offset: 0x00111CFA
	public bool IsUnique()
	{
		return true;
	}

	// Token: 0x0600268D RID: 9869 RVA: 0x001138FD File Offset: 0x00111CFD
	public void ProcessEvent(IResidentEffect effect, Resident resident, GameWorldEvent evt, object data)
	{
	}

	// Token: 0x0600268E RID: 9870 RVA: 0x00113900 File Offset: 0x00111D00
	public static IResidentEffect CreateDifficultyRelatedEffect(DifficultyLevelMeasurement measurement, double coeffecient)
	{
		double num = 50.0;
		if (measurement.DifficultyValue >= 70.0 || measurement.StarRating > 1)
		{
			num = 250.0;
		}
		else if (measurement.DifficultyValue >= 50.0)
		{
			num = 180.0;
		}
		else if (measurement.DifficultyValue >= 40.0)
		{
			num = 150.0;
		}
		else if (measurement.DifficultyValue >= 30.0)
		{
			num = 110.0;
		}
		else if (measurement.DifficultyValue >= 20.0)
		{
			num = 90.0;
		}
		else if (measurement.DifficultyValue >= 10.0)
		{
			num = 70.0;
		}
		num *= coeffecient;
		return new WealthResidentEffect
		{
			ContributionAmount = num
		};
	}

	// Token: 0x040020E5 RID: 8421
	public double ContributionAmount;
}
