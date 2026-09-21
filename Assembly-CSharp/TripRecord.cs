using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020009B5 RID: 2485
[Serializable]
public class TripRecord
{
	// Token: 0x06004412 RID: 17426 RVA: 0x001B9972 File Offset: 0x001B7D72
	public TripRecord()
	{
	}

	// Token: 0x06004413 RID: 17427 RVA: 0x001B997C File Offset: 0x001B7D7C
	public static TripRecord Initialize(Vehicle boat, DestinationType destination)
	{
		List<ITraveller> list = new List<ITraveller>();
		using (List<ITraveller>.Enumerator enumerator = boat.Travellers.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ITraveller boatTraveller = enumerator.Current;
				if (boatTraveller is AdventurerProfile)
				{
					if (GameWorld.instance.PlayerProfile.AdventurerProfiles.Any((AdventurerProfile a) => a.Id == boatTraveller.GetId()))
					{
						list.Add(boatTraveller);
					}
				}
				else if (GameWorld.instance.PlayerProfile.Residents.Any((Resident r) => r.Id == boatTraveller.GetId()))
				{
					list.Add(boatTraveller);
				}
			}
		}
		DifficultyLevelMeasurement productionDifficultyLevelMeasurement = GameWorld.instance.PlayerProfile.GetProductionDifficultyLevelMeasurement();
		TripRecord tripRecord = new TripRecord();
		tripRecord.Id = Guid.NewGuid().ToString();
		tripRecord.Travellers = list;
		tripRecord.CurrentDestination = destination;
		tripRecord.Vehicle = boat;
		tripRecord.Stats = (from s in boat.Stats
		select new VechileAttributeModifier
		{
			AttributeType = s.AttributeType,
			Value = s.Value,
			Key = s.Key
		}).ToList<VechileAttributeModifier>();
		tripRecord.Contributions = boat.GetContribution();
		tripRecord.CurrentHealth = boat.Stats.GetValue(VehicleAttributeType.Life);
		tripRecord.CurrentOnMiles = 0.0;
		tripRecord.Completed = false;
		tripRecord.Encounters = new List<ITripeEncounter>();
		tripRecord.Claimed = false;
		tripRecord.Speed = boat.Stats.GetValue(VehicleAttributeType.Speed);
		tripRecord.CreatedDifficultyValue = productionDifficultyLevelMeasurement.DifficultyValue;
		tripRecord.CreatedStarRating = new int?(productionDifficultyLevelMeasurement.StarRating);
		return tripRecord;
	}

	// Token: 0x06004414 RID: 17428 RVA: 0x001B9B58 File Offset: 0x001B7F58
	public void AddEncounter(ITripeEncounter encounter)
	{
		this.Encounters.Add(encounter);
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.TripEncounterCollected, encounter);
	}

	// Token: 0x06004415 RID: 17429 RVA: 0x001B9B78 File Offset: 0x001B7F78
	public void Callback()
	{
		if (!this.Completed)
		{
			this.Completed = true;
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.JourneyCompleted, this);
		}
	}

	// Token: 0x06004416 RID: 17430 RVA: 0x001B9B9E File Offset: 0x001B7F9E
	public void ProcessRecord()
	{
		if (!this.Completed)
		{
			this.CurrentDestination.GetProcess().Process(this);
		}
	}

	// Token: 0x06004417 RID: 17431 RVA: 0x001B9BBC File Offset: 0x001B7FBC
	public List<ResourceUpdate> GetLoots()
	{
		return this.Encounters.SelectMany((ITripeEncounter e) => e.GetLoots()).ToList<ResourceUpdate>();
	}

	// Token: 0x06004418 RID: 17432 RVA: 0x001B9BEC File Offset: 0x001B7FEC
	public void ClaimLoots()
	{
		if (!this.Claimed && this.Completed)
		{
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(this.GetLoots());
			this.Claimed = true;
			if (GameWorld.instance.PlayerProfile.CurrentJourneys.Any((TripRecord j) => j == this))
			{
				GameWorld.instance.PlayerProfile.CurrentJourneys.Remove(this);
			}
		}
	}

	// Token: 0x06004419 RID: 17433 RVA: 0x001B9C68 File Offset: 0x001B8068
	[CompilerGenerated]
	private static VechileAttributeModifier <Initialize>m__0(VechileAttributeModifier s)
	{
		return new VechileAttributeModifier
		{
			AttributeType = s.AttributeType,
			Value = s.Value,
			Key = s.Key
		};
	}

	// Token: 0x0600441A RID: 17434 RVA: 0x001B9CA0 File Offset: 0x001B80A0
	[CompilerGenerated]
	private static IEnumerable<ResourceUpdate> <GetLoots>m__1(ITripeEncounter e)
	{
		return e.GetLoots();
	}

	// Token: 0x0600441B RID: 17435 RVA: 0x001B9CA8 File Offset: 0x001B80A8
	[CompilerGenerated]
	private bool <ClaimLoots>m__2(TripRecord j)
	{
		return j == this;
	}

	// Token: 0x0400336A RID: 13162
	public double CurrentOnMiles;

	// Token: 0x0400336B RID: 13163
	public double CurrentHealth;

	// Token: 0x0400336C RID: 13164
	public List<JourneyContributionModifier> Contributions;

	// Token: 0x0400336D RID: 13165
	public DestinationType CurrentDestination;

	// Token: 0x0400336E RID: 13166
	public List<VechileAttributeModifier> Stats;

	// Token: 0x0400336F RID: 13167
	public List<ITraveller> Travellers;

	// Token: 0x04003370 RID: 13168
	public Vehicle Vehicle;

	// Token: 0x04003371 RID: 13169
	public string Id;

	// Token: 0x04003372 RID: 13170
	public bool Completed;

	// Token: 0x04003373 RID: 13171
	public List<ITripeEncounter> Encounters;

	// Token: 0x04003374 RID: 13172
	public bool Claimed;

	// Token: 0x04003375 RID: 13173
	public double Speed;

	// Token: 0x04003376 RID: 13174
	public double CreatedDifficultyValue;

	// Token: 0x04003377 RID: 13175
	public int? CreatedStarRating;

	// Token: 0x04003378 RID: 13176
	[CompilerGenerated]
	private static Func<VechileAttributeModifier, VechileAttributeModifier> <>f__am$cache0;

	// Token: 0x04003379 RID: 13177
	[CompilerGenerated]
	private static Func<ITripeEncounter, IEnumerable<ResourceUpdate>> <>f__am$cache1;

	// Token: 0x02001009 RID: 4105
	[CompilerGenerated]
	private sealed class <Initialize>c__AnonStorey0
	{
		// Token: 0x060067D5 RID: 26581 RVA: 0x001B9CAE File Offset: 0x001B80AE
		public <Initialize>c__AnonStorey0()
		{
		}

		// Token: 0x060067D6 RID: 26582 RVA: 0x001B9CB6 File Offset: 0x001B80B6
		internal bool <>m__0(AdventurerProfile a)
		{
			return a.Id == this.boatTraveller.GetId();
		}

		// Token: 0x060067D7 RID: 26583 RVA: 0x001B9CCE File Offset: 0x001B80CE
		internal bool <>m__1(Resident r)
		{
			return r.Id == this.boatTraveller.GetId();
		}

		// Token: 0x040061D3 RID: 25043
		internal ITraveller boatTraveller;
	}
}
