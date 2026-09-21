using System;
using System.Collections.Generic;

// Token: 0x020009B6 RID: 2486
public class BusinessEncounter : TripEncounterProcess
{
	// Token: 0x0600441C RID: 17436 RVA: 0x001B9DC1 File Offset: 0x001B81C1
	public BusinessEncounter()
	{
	}

	// Token: 0x17000D93 RID: 3475
	// (get) Token: 0x0600441D RID: 17437 RVA: 0x001B9DC9 File Offset: 0x001B81C9
	public override TripEncounterType Type
	{
		get
		{
			return TripEncounterType.BusinessEncounter;
		}
	}

	// Token: 0x0600441E RID: 17438 RVA: 0x001B9DCC File Offset: 0x001B81CC
	public override ITripeEncounter GenerateEncounterFor(TripRecord trip)
	{
		if (base.GetRequiredTotalContributionValue(JourneyContributeType.TradeSkill, trip.CurrentOnMiles) > trip.Contributions.GetValue(JourneyContributeType.TradeSkill))
		{
			return new NormalEncounter
			{
				Type = TripEncounterType.BusinessEncounter,
				OutcomeType = TripEncounterOutcomeType.BusinessEncounterFailed,
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
			Type = TripEncounterType.BusinessEncounter,
			OutcomeType = TripEncounterOutcomeType.BusinessEncounterSuccess,
			Loots = new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = ResourceType.Money,
					ChangeAmount = (double)num3,
					RelatedItems = new List<Item>()
				}
			},
			OnMiles = trip.CurrentOnMiles,
			Positive = true,
			LossLife = 0.0
		};
	}

	// Token: 0x0600441F RID: 17439 RVA: 0x001B9F2C File Offset: 0x001B832C
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
				return 10000;
			}
			if (difficultyValue < 120.0)
			{
				return 12000;
			}
			if (difficultyValue < 130.0)
			{
				return 14000;
			}
			if (difficultyValue < 140.0)
			{
				return 16000;
			}
			if (difficultyValue < 150.0)
			{
				return 18000;
			}
			if (difficultyValue < 160.0)
			{
				return 20000;
			}
			if (difficultyValue < 170.0)
			{
				return 22000;
			}
			return 24000;
		}
		else if (starRating == 2)
		{
			if (difficultyValue < 150.0)
			{
				return 26000;
			}
			if (difficultyValue < 210.0)
			{
				return 28000;
			}
			return 30000;
		}
		else
		{
			if (starRating != -1)
			{
				return 24000;
			}
			if (difficultyValue <= 100.0)
			{
				return 32000;
			}
			if (difficultyValue <= 200.0)
			{
				return 34000;
			}
			if (difficultyValue <= 300.0)
			{
				return 36000;
			}
			if (difficultyValue <= 400.0)
			{
				return 38000;
			}
			if (difficultyValue <= 500.0)
			{
				return 40000;
			}
			if (difficultyValue <= 600.0)
			{
				return 43000;
			}
			if (difficultyValue <= 700.0)
			{
				return 46000;
			}
			if (difficultyValue <= 800.0)
			{
				return 49000;
			}
			if (difficultyValue <= 900.0)
			{
				return 52000;
			}
			return 55000;
		}
	}
}
