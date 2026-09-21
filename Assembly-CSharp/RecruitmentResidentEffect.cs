using System;

// Token: 0x0200051A RID: 1306
[Serializable]
public class RecruitmentResidentEffect : IResidentEffect
{
	// Token: 0x06002685 RID: 9861 RVA: 0x001137DA File Offset: 0x00111BDA
	public RecruitmentResidentEffect()
	{
	}

	// Token: 0x170002E7 RID: 743
	// (get) Token: 0x06002686 RID: 9862 RVA: 0x001137E2 File Offset: 0x00111BE2
	public ResidentEffectType CorrespondingEffectType
	{
		get
		{
			return ResidentEffectType.Recruitment;
		}
	}

	// Token: 0x06002687 RID: 9863 RVA: 0x001137E6 File Offset: 0x00111BE6
	public bool IsUnique()
	{
		return false;
	}

	// Token: 0x06002688 RID: 9864 RVA: 0x001137E9 File Offset: 0x00111BE9
	public void ProcessEvent(IResidentEffect effect, Resident resident, GameWorldEvent evt, object data)
	{
	}

	// Token: 0x06002689 RID: 9865 RVA: 0x001137EC File Offset: 0x00111BEC
	public static IResidentEffect CreateDifficultyRelatedEffect(DifficultyLevelMeasurement measurement, double qualityCoeff)
	{
		double num = 0.1;
		if (measurement.DifficultyValue >= 70.0 || measurement.StarRating > 1)
		{
			num = 0.7;
		}
		else if (measurement.DifficultyValue >= 50.0)
		{
			num = 0.6;
		}
		else if (measurement.DifficultyValue >= 40.0)
		{
			num = 0.5;
		}
		else if (measurement.DifficultyValue >= 30.0)
		{
			num = 0.4;
		}
		else if (measurement.DifficultyValue >= 20.0)
		{
			num = 0.3;
		}
		else if (measurement.DifficultyValue >= 10.0)
		{
			num = 0.2;
		}
		num *= qualityCoeff;
		return new RecruitmentResidentEffect
		{
			Chance = num
		};
	}

	// Token: 0x040020E4 RID: 8420
	public double Chance;
}
