using System;

// Token: 0x02000518 RID: 1304
[Serializable]
public class PracticeResidentEffect : IResidentEffect
{
	// Token: 0x0600267B RID: 9851 RVA: 0x001135B2 File Offset: 0x001119B2
	public PracticeResidentEffect()
	{
	}

	// Token: 0x170002E5 RID: 741
	// (get) Token: 0x0600267C RID: 9852 RVA: 0x001135BA File Offset: 0x001119BA
	public ResidentEffectType CorrespondingEffectType
	{
		get
		{
			return ResidentEffectType.Practice;
		}
	}

	// Token: 0x0600267D RID: 9853 RVA: 0x001135BD File Offset: 0x001119BD
	public bool IsUnique()
	{
		return false;
	}

	// Token: 0x0600267E RID: 9854 RVA: 0x001135C0 File Offset: 0x001119C0
	public void ProcessEvent(IResidentEffect effect, Resident resident, GameWorldEvent evt, object data)
	{
	}

	// Token: 0x0600267F RID: 9855 RVA: 0x001135C4 File Offset: 0x001119C4
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
		return new PracticeResidentEffect
		{
			CurrentRate = num
		};
	}

	// Token: 0x040020E2 RID: 8418
	public double CurrentRate;
}
