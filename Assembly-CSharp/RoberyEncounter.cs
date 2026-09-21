using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020009B9 RID: 2489
public class RoberyEncounter : TripEncounterProcess
{
	// Token: 0x0600442A RID: 17450 RVA: 0x001BA3CE File Offset: 0x001B87CE
	public RoberyEncounter()
	{
	}

	// Token: 0x17000D95 RID: 3477
	// (get) Token: 0x0600442B RID: 17451 RVA: 0x001BA3D6 File Offset: 0x001B87D6
	public override TripEncounterType Type
	{
		get
		{
			return TripEncounterType.Robery;
		}
	}

	// Token: 0x0600442C RID: 17452 RVA: 0x001BA3DC File Offset: 0x001B87DC
	public override ITripeEncounter GenerateEncounterFor(TripRecord trip)
	{
		if (base.GetRequiredTotalContributionValue(JourneyContributeType.BattleSkill, trip.CurrentOnMiles) + base.GetChallengeDistanceIncrementValueFor(JourneyContributeType.BattleSkill) > trip.Contributions.GetValue(JourneyContributeType.BattleSkill))
		{
			int num = UnityEngine.Random.Range(2, 5);
			trip.CurrentHealth -= (double)num;
			return new NormalEncounter
			{
				Type = TripEncounterType.Robery,
				OutcomeType = TripEncounterOutcomeType.RoberyFailed,
				Positive = false,
				Loots = new List<ResourceUpdate>(),
				OnMiles = trip.CurrentOnMiles,
				LossLife = (double)num
			};
		}
		double num2 = base.GetDistanceGrantedBonusRatio(trip.CurrentOnMiles);
		if (trip.CreatedStarRating != null && trip.CreatedStarRating.Value == -1)
		{
			num2 = 1.0;
		}
		if (trip.CreatedStarRating != null && trip.CreatedStarRating.Value == 2)
		{
			num2 = 1.0;
		}
		int numberOfItems = (int)Math.Round((double)this.GetQuantity(trip.CreatedDifficultyValue, (trip.CreatedStarRating == null) ? 1 : trip.CreatedStarRating.Value) * num2, 0);
		DifficultyLevelMeasurement difficultyLevelMeasurementByValue = DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(trip.CreatedDifficultyValue, (trip.CreatedStarRating == null) ? 1 : trip.CreatedStarRating.Value);
		List<ResourceUpdate> list = difficultyLevelMeasurementByValue.GenerateDropableGears(numberOfItems, null, false);
		if (trip.CurrentOnMiles > 48.0)
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.InfusedPowder,
				ChangeAmount = (double)UnityEngine.Random.Range(1, 4),
				RelatedItems = new List<Item>()
			});
		}
		return new NormalEncounter
		{
			Type = TripEncounterType.Robery,
			OutcomeType = TripEncounterOutcomeType.RoberySuccess,
			Loots = list,
			OnMiles = trip.CurrentOnMiles,
			Positive = true,
			LossLife = 0.0
		};
	}

	// Token: 0x0600442D RID: 17453 RVA: 0x001BA5CC File Offset: 0x001B89CC
	private int GetQuantity(double difficultyValue, int starRating)
	{
		if (starRating == 1)
		{
			if (difficultyValue < 100.0)
			{
				return 0;
			}
			if (difficultyValue < 110.0)
			{
				return 2;
			}
			if (difficultyValue < 120.0)
			{
				return 3;
			}
			if (difficultyValue < 130.0)
			{
				return 3;
			}
			if (difficultyValue < 140.0)
			{
				return 3;
			}
			if (difficultyValue < 150.0)
			{
				return 3;
			}
			if (difficultyValue < 160.0)
			{
				return 3;
			}
			if (difficultyValue < 170.0)
			{
				return 3;
			}
			return 4;
		}
		else
		{
			if (starRating == -1)
			{
				return 1;
			}
			return 2;
		}
	}
}
