using System;
using System.Collections.Generic;

// Token: 0x020009A7 RID: 2471
public class RedRiverProcess : DestinationProcessBase
{
	// Token: 0x060043E6 RID: 17382 RVA: 0x001B93C1 File Offset: 0x001B77C1
	public RedRiverProcess()
	{
	}

	// Token: 0x060043E7 RID: 17383 RVA: 0x001B93CC File Offset: 0x001B77CC
	public override List<TripEncounterPresence> GetEncounterPresences(TripRecord record)
	{
		return new List<TripEncounterPresence>
		{
			new TripEncounterPresence
			{
				Presence = 100,
				TripEncounterType = TripEncounterType.ScholarEncounter
			},
			new TripEncounterPresence
			{
				Presence = 100,
				TripEncounterType = TripEncounterType.ResourceDiscovery
			},
			new TripEncounterPresence
			{
				Presence = 100,
				TripEncounterType = TripEncounterType.BusinessEncounter
			},
			new TripEncounterPresence
			{
				Presence = 50,
				TripEncounterType = TripEncounterType.Robery
			},
			new TripEncounterPresence
			{
				Presence = 8,
				TripEncounterType = TripEncounterType.RoyalFleetEncounter
			}
		};
	}

	// Token: 0x17000D8C RID: 3468
	// (get) Token: 0x060043E8 RID: 17384 RVA: 0x001B946B File Offset: 0x001B786B
	public override DestinationType DestinationType
	{
		get
		{
			return DestinationType.RedRiver;
		}
	}
}
