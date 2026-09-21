using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020009B8 RID: 2488
public class ResourceDiscoveryEncounter : TripEncounterProcess
{
	// Token: 0x06004426 RID: 17446 RVA: 0x001BA120 File Offset: 0x001B8520
	public ResourceDiscoveryEncounter()
	{
	}

	// Token: 0x17000D94 RID: 3476
	// (get) Token: 0x06004427 RID: 17447 RVA: 0x001BA128 File Offset: 0x001B8528
	public override TripEncounterType Type
	{
		get
		{
			return TripEncounterType.ResourceDiscovery;
		}
	}

	// Token: 0x06004428 RID: 17448 RVA: 0x001BA12C File Offset: 0x001B852C
	public override ITripeEncounter GenerateEncounterFor(TripRecord trip)
	{
		if (base.GetRequiredTotalContributionValue(JourneyContributeType.BattleSkill, trip.CurrentOnMiles) > trip.Contributions.GetValue(JourneyContributeType.BattleSkill))
		{
			int num = UnityEngine.Random.Range(1, 3);
			trip.CurrentHealth -= (double)num;
			return new NormalEncounter
			{
				Type = TripEncounterType.ResourceDiscovery,
				OutcomeType = TripEncounterOutcomeType.ResourceDefeated,
				Positive = false,
				Loots = new List<ResourceUpdate>(),
				OnMiles = trip.CurrentOnMiles,
				LossLife = (double)num
			};
		}
		double num2 = trip.Contributions.GetValue(JourneyContributeType.CollectionSkill) / base.GetRequiredTotalContributionValue(JourneyContributeType.CollectionSkill, trip.CurrentOnMiles);
		if (num2 > 1.0)
		{
			num2 = 1.0;
		}
		double num3 = num2 + base.GetDistanceGrantedBonusRatio(trip.CurrentOnMiles);
		int num4 = (int)Math.Round((double)this.GetQuantity(trip.CreatedDifficultyValue, (trip.CreatedStarRating == null) ? 1 : trip.CreatedStarRating.Value) * num3, 0);
		return new NormalEncounter
		{
			Type = TripEncounterType.ResourceDiscovery,
			OutcomeType = TripEncounterOutcomeType.ResourceCollected,
			Loots = new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = ResourceType.RefinedOre,
					ChangeAmount = (double)num4,
					RelatedItems = new List<Item>()
				},
				new ResourceUpdate
				{
					ResourceType = ResourceType.RefinedLeather,
					ChangeAmount = (double)num4,
					RelatedItems = new List<Item>()
				}
			},
			OnMiles = trip.CurrentOnMiles,
			Positive = true,
			LossLife = 0.0
		};
	}

	// Token: 0x06004429 RID: 17449 RVA: 0x001BA2D0 File Offset: 0x001B86D0
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
				return 20;
			}
			if (difficultyValue < 120.0)
			{
				return 30;
			}
			if (difficultyValue < 130.0)
			{
				return 40;
			}
			if (difficultyValue < 140.0)
			{
				return 50;
			}
			if (difficultyValue < 150.0)
			{
				return 60;
			}
			if (difficultyValue < 160.0)
			{
				return 70;
			}
			if (difficultyValue < 170.0)
			{
				return 80;
			}
			return 100;
		}
		else if (starRating == 2)
		{
			if (difficultyValue <= 150.0)
			{
				return 120;
			}
			return 140;
		}
		else
		{
			if (starRating != -1)
			{
				return 100;
			}
			if (difficultyValue <= 200.0)
			{
				return 140;
			}
			if (difficultyValue <= 400.0)
			{
				return 160;
			}
			return 180;
		}
	}
}
