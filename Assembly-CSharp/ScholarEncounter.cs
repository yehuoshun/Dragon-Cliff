using System;
using System.Collections.Generic;

// Token: 0x020009BB RID: 2491
public class ScholarEncounter : TripEncounterProcess
{
	// Token: 0x06004431 RID: 17457 RVA: 0x001BAA13 File Offset: 0x001B8E13
	public ScholarEncounter()
	{
	}

	// Token: 0x17000D97 RID: 3479
	// (get) Token: 0x06004432 RID: 17458 RVA: 0x001BAA1B File Offset: 0x001B8E1B
	public override TripEncounterType Type
	{
		get
		{
			return TripEncounterType.ScholarEncounter;
		}
	}

	// Token: 0x06004433 RID: 17459 RVA: 0x001BAA20 File Offset: 0x001B8E20
	public override ITripeEncounter GenerateEncounterFor(TripRecord trip)
	{
		if (base.GetRequiredTotalContributionValue(JourneyContributeType.ResearchSkill, trip.CurrentOnMiles) > trip.Contributions.GetValue(JourneyContributeType.ResearchSkill))
		{
			return new NormalEncounter
			{
				Type = TripEncounterType.ScholarEncounter,
				OutcomeType = TripEncounterOutcomeType.ScholarFailed,
				Positive = false,
				Loots = new List<ResourceUpdate>(),
				OnMiles = trip.CurrentOnMiles,
				LossLife = 0.0
			};
		}
		double num = trip.Contributions.GetValue(JourneyContributeType.CultureSkill) / base.GetRequiredTotalContributionValue(JourneyContributeType.CultureSkill, trip.CurrentOnMiles);
		if (num > 1.0)
		{
			num = 1.0;
		}
		double num2 = num + base.GetDistanceGrantedBonusRatio(trip.CurrentOnMiles);
		int num3 = (int)Math.Round((double)this.GetQuantity(trip.CreatedDifficultyValue, (trip.CreatedStarRating == null) ? 1 : trip.CreatedStarRating.Value) * num2, 0);
		return new NormalEncounter
		{
			Type = TripEncounterType.ScholarEncounter,
			OutcomeType = TripEncounterOutcomeType.ScholarSuccess,
			Loots = new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = ResourceType.BookFragments,
					ChangeAmount = (double)num3,
					RelatedItems = new List<Item>()
				}
			},
			OnMiles = trip.CurrentOnMiles,
			Positive = true,
			LossLife = 0.0
		};
	}

	// Token: 0x06004434 RID: 17460 RVA: 0x001BAB80 File Offset: 0x001B8F80
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
				return 1;
			}
			if (difficultyValue < 120.0)
			{
				return 2;
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
				return 4;
			}
			if (difficultyValue < 160.0)
			{
				return 4;
			}
			if (difficultyValue < 170.0)
			{
				return 4;
			}
			return 4;
		}
		else if (starRating == 2)
		{
			if (difficultyValue <= 150.0)
			{
				return 5;
			}
			return 6;
		}
		else
		{
			if (starRating != -1)
			{
				return 4;
			}
			if (difficultyValue <= 250.0)
			{
				return 6;
			}
			return 7;
		}
	}
}
