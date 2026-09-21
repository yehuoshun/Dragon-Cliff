using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020009BA RID: 2490
public class RoyalFleetEncounter : TripEncounterProcess
{
	// Token: 0x0600442E RID: 17454 RVA: 0x001BA674 File Offset: 0x001B8A74
	public RoyalFleetEncounter()
	{
	}

	// Token: 0x17000D96 RID: 3478
	// (get) Token: 0x0600442F RID: 17455 RVA: 0x001BA67C File Offset: 0x001B8A7C
	public override TripEncounterType Type
	{
		get
		{
			return TripEncounterType.RoyalFleetEncounter;
		}
	}

	// Token: 0x06004430 RID: 17456 RVA: 0x001BA680 File Offset: 0x001B8A80
	public override ITripeEncounter GenerateEncounterFor(TripRecord trip)
	{
		double num = base.GetRequiredTotalContributionValue(JourneyContributeType.BattleSkill, trip.CurrentOnMiles) + base.GetChallengeDistanceIncrementValueFor(JourneyContributeType.BattleSkill);
		double value = trip.Contributions.GetValue(JourneyContributeType.BattleSkill);
		double num2 = base.GetRequiredTotalContributionValue(JourneyContributeType.CultureSkill, trip.CurrentOnMiles) + base.GetChallengeDistanceIncrementValueFor(JourneyContributeType.CultureSkill);
		double value2 = trip.Contributions.GetValue(JourneyContributeType.CultureSkill);
		if (num > value)
		{
			int num3 = UnityEngine.Random.Range(2, 4);
			trip.CurrentHealth -= (double)num3;
			return new NormalEncounter
			{
				Type = TripEncounterType.RoyalFleetEncounter,
				OutcomeType = TripEncounterOutcomeType.RoyalFleetEncounterFail,
				Positive = false,
				Loots = new List<ResourceUpdate>(),
				OnMiles = trip.CurrentOnMiles,
				LossLife = (double)num3
			};
		}
		if (num2 <= value2)
		{
			int num4 = 3;
			double num5 = base.GetDistanceGrantedBonusRatio(trip.CurrentOnMiles);
			QualityGrade value3 = QualityGrade.Ancient;
			if (trip.CreatedStarRating != null && trip.CreatedStarRating == 2)
			{
				num4 = 2;
				num5 = 1.0;
				if ((double)UnityEngine.Random.value <= 0.8)
				{
					value3 = QualityGrade.Legendary;
				}
			}
			if (trip.CreatedStarRating != null && trip.CreatedStarRating == -1)
			{
				num4 = 1;
				num5 = 1.0;
				if ((double)UnityEngine.Random.value <= 0.6)
				{
					value3 = QualityGrade.Legendary;
				}
			}
			int numberOfItems = (int)((double)num4 * num5);
			DifficultyLevelMeasurement difficultyLevelMeasurementByValue = DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(trip.CreatedDifficultyValue, (trip.CreatedStarRating == null) ? 1 : trip.CreatedStarRating.Value);
			List<ResourceUpdate> list = new List<ResourceUpdate>();
			list.AddRange(difficultyLevelMeasurementByValue.GenerateDropableGears(numberOfItems, new QualityGrade?(value3), false));
			if (trip.CurrentOnMiles > 48.0 && (double)UnityEngine.Random.value <= 0.5)
			{
				list.AddRange(difficultyLevelMeasurementByValue.GenerateDropableGears(1, new QualityGrade?(QualityGrade.Ancient), false));
			}
			return new NormalEncounter
			{
				Type = TripEncounterType.RoyalFleetEncounter,
				OutcomeType = TripEncounterOutcomeType.RoyalFleetEncounterSuccess_Complete,
				Loots = list,
				OnMiles = trip.CurrentOnMiles,
				Positive = true,
				LossLife = 0.0
			};
		}
		int num6 = 2;
		double num7 = base.GetDistanceGrantedBonusRatio(trip.CurrentOnMiles);
		QualityGrade value4 = QualityGrade.Ancient;
		if (trip.CreatedStarRating != null && trip.CreatedStarRating == 2)
		{
			num6 = 1;
			num7 = 1.0;
			value4 = QualityGrade.Legendary;
		}
		if (trip.CreatedStarRating != null && trip.CreatedStarRating == -1)
		{
			num6 = 1;
			num7 = 1.0;
			value4 = QualityGrade.Legendary;
		}
		int numberOfItems2 = (int)((double)num6 * num7);
		DifficultyLevelMeasurement difficultyLevelMeasurementByValue2 = DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(trip.CreatedDifficultyValue, (trip.CreatedStarRating == null) ? 1 : trip.CreatedStarRating.Value);
		List<ResourceUpdate> list2 = new List<ResourceUpdate>();
		list2.AddRange(difficultyLevelMeasurementByValue2.GenerateDropableGears(numberOfItems2, new QualityGrade?(value4), false));
		return new NormalEncounter
		{
			Type = TripEncounterType.RoyalFleetEncounter,
			OutcomeType = TripEncounterOutcomeType.RoyalFleetEncounterSuccess_BattleOnly,
			Loots = list2,
			OnMiles = trip.CurrentOnMiles,
			Positive = true,
			LossLife = 0.0
		};
	}
}
