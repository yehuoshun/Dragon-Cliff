using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200049B RID: 1179
public static class ResidentsExtensions
{
	// Token: 0x0600230E RID: 8974 RVA: 0x00100B6A File Offset: 0x000FEF6A
	public static ResidentBase GetResidentBase(this ResidentType type)
	{
		return ResidentsExtensions.ResidentBaseLogics[type];
	}

	// Token: 0x0600230F RID: 8975 RVA: 0x00100B77 File Offset: 0x000FEF77
	public static int ResidentLevelUpRequiredDays(int toLevel)
	{
		return 5 * toLevel;
	}

	// Token: 0x06002310 RID: 8976 RVA: 0x00100B7C File Offset: 0x000FEF7C
	public static Resident CreateResidentByCoeff(this ResidentType type, DifficultyLevelMeasurement difficultyLevelMeasurement, double determinedQualityCoef = 0.0)
	{
		QualityGrade grade = QualityGrade.Normal;
		if (determinedQualityCoef > 0.2 && determinedQualityCoef <= 0.4)
		{
			grade = QualityGrade.Rare;
		}
		if (determinedQualityCoef > 0.4 && determinedQualityCoef <= 0.6)
		{
			grade = QualityGrade.Epic;
		}
		if (determinedQualityCoef > 0.6 && determinedQualityCoef <= 0.8)
		{
			grade = QualityGrade.Legendary;
		}
		if (determinedQualityCoef > 0.8)
		{
			grade = QualityGrade.Ancient;
		}
		return new Resident
		{
			Type = type,
			Level = difficultyLevelMeasurement.GetResidentLevel(),
			Grade = grade,
			Id = Guid.NewGuid().ToString(),
			UntilLevelUpDaysCounter = ResidentsExtensions.ResidentLevelUpRequiredDays(2),
			Effects = type.GetResidentBase().GetEffects(difficultyLevelMeasurement, determinedQualityCoef + 1.0),
			GeneratedOnDifficultyValue = difficultyLevelMeasurement.DifficultyValue,
			GeneratedOnStarRating = new int?(difficultyLevelMeasurement.StarRating),
			JourneyContributionModifiers = type.GetResidentBase().GenerateJourneyContributions(difficultyLevelMeasurement, grade)
		};
	}

	// Token: 0x06002311 RID: 8977 RVA: 0x00100C94 File Offset: 0x000FF094
	public static Resident CreateResidentByQuality(this ResidentType type, DifficultyLevelMeasurement difficultyLevelMeasurement, QualityGrade? presetQuality = null)
	{
		if (presetQuality == null)
		{
			presetQuality = new QualityGrade?(ResidentsExtensions.DefaultResidentSpawnDistribution.GetGrade());
		}
		QualityGrade value = presetQuality.Value;
		float num = UnityEngine.Random.Range(0f, 0.2f);
		if (value == QualityGrade.Rare)
		{
			num = UnityEngine.Random.Range(0.2f, 0.4f);
		}
		if (value == QualityGrade.Epic)
		{
			num = UnityEngine.Random.Range(0.4f, 0.6f);
		}
		if (value == QualityGrade.Legendary)
		{
			num = UnityEngine.Random.Range(0.6f, 0.8f);
		}
		if (value == QualityGrade.Ancient)
		{
			num = UnityEngine.Random.Range(0.8f, 1f);
		}
		return type.CreateResidentByCoeff(difficultyLevelMeasurement, (double)num);
	}

	// Token: 0x06002312 RID: 8978 RVA: 0x00100D3C File Offset: 0x000FF13C
	public static Resident SpawnResident_Default(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		IEnumerable<ResidentType> source = difficultyLevelMeasurement.ResidentCandidates();
		if (ResidentsExtensions.<>f__mg$cache0 == null)
		{
			ResidentsExtensions.<>f__mg$cache0 = new Func<ResidentType, ResidentBase>(ResidentsExtensions.GetResidentBase);
		}
		List<ResidentBase> list = source.Select(ResidentsExtensions.<>f__mg$cache0).ToList<ResidentBase>();
		List<ResidentBase> list2 = (from t in list
		where !GameWorld.instance.PlayerProfile.ResidentsCreated.ContainsKey(t.ResidentType) || GameWorld.instance.PlayerProfile.ResidentsCreated[t.ResidentType] == 0
		select t).ToList<ResidentBase>();
		ResidentBase residentBase = list.WeightedRandomSelect<ResidentBase>();
		if (list2.Any<ResidentBase>())
		{
			residentBase = list2.WeightedRandomSelect<ResidentBase>();
		}
		if (GameWorld.instance.PlayerProfile.ResidentsCreated.ContainsKey(residentBase.ResidentType))
		{
			Dictionary<ResidentType, int> residentsCreated;
			ResidentType residentType;
			(residentsCreated = GameWorld.instance.PlayerProfile.ResidentsCreated)[residentType = residentBase.ResidentType] = residentsCreated[residentType] + 1;
		}
		else
		{
			GameWorld.instance.PlayerProfile.ResidentsCreated.Add(residentBase.ResidentType, 1);
		}
		return residentBase.ResidentType.CreateResidentByQuality(difficultyLevelMeasurement, null);
	}

	// Token: 0x06002313 RID: 8979 RVA: 0x00100E38 File Offset: 0x000FF238
	// Note: this type is marked as 'beforefieldinit'.
	static ResidentsExtensions()
	{
	}

	// Token: 0x06002314 RID: 8980 RVA: 0x00100EC0 File Offset: 0x000FF2C0
	[CompilerGenerated]
	private static bool <SpawnResident_Default>m__0(ResidentBase t)
	{
		return !GameWorld.instance.PlayerProfile.ResidentsCreated.ContainsKey(t.ResidentType) || GameWorld.instance.PlayerProfile.ResidentsCreated[t.ResidentType] == 0;
	}

	// Token: 0x06002315 RID: 8981 RVA: 0x00100F0C File Offset: 0x000FF30C
	[CompilerGenerated]
	private static ResidentType <ResidentBaseLogics>m__1(ResidentBase root)
	{
		return root.ResidentType;
	}

	// Token: 0x04001E3C RID: 7740
	public static Dictionary<ResidentType, ResidentBase> ResidentBaseLogics = ItemExtensions.GetDictionaryOfAbastract<ResidentType, ResidentBase>((ResidentBase root) => root.ResidentType);

	// Token: 0x04001E3D RID: 7741
	public static readonly GenerationDistribution DefaultResidentSpawnDistribution = new GenerationDistribution(0.1, 0.02, 0.01, 0.003);

	// Token: 0x04001E3E RID: 7742
	public static Dictionary<QualityGrade, int> NumberOfExtraTraitsPerGrade = new Dictionary<QualityGrade, int>
	{
		{
			QualityGrade.Normal,
			0
		},
		{
			QualityGrade.Rare,
			0
		},
		{
			QualityGrade.Epic,
			1
		},
		{
			QualityGrade.Legendary,
			2
		},
		{
			QualityGrade.Ancient,
			3
		}
	};

	// Token: 0x04001E3F RID: 7743
	[CompilerGenerated]
	private static Func<ResidentType, ResidentBase> <>f__mg$cache0;

	// Token: 0x04001E40 RID: 7744
	[CompilerGenerated]
	private static Func<ResidentBase, bool> <>f__am$cache0;
}
