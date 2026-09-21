using System;
using System.Collections.Generic;

// Token: 0x020009A6 RID: 2470
public class NorthernSeaProcess : DestinationProcessBase
{
	// Token: 0x060043E3 RID: 17379 RVA: 0x001B932E File Offset: 0x001B772E
	public NorthernSeaProcess()
	{
	}

	// Token: 0x060043E4 RID: 17380 RVA: 0x001B9338 File Offset: 0x001B7738
	public override List<TripEncounterPresence> GetEncounterPresences(TripRecord record)
	{
		return new List<TripEncounterPresence>
		{
			new TripEncounterPresence
			{
				Presence = 300,
				TripEncounterType = TripEncounterType.ResourceDiscovery
			},
			new TripEncounterPresence
			{
				Presence = 50,
				TripEncounterType = TripEncounterType.Robery
			},
			new TripEncounterPresence
			{
				Presence = 50,
				TripEncounterType = TripEncounterType.ScholarEncounter
			},
			new TripEncounterPresence
			{
				Presence = 8,
				TripEncounterType = TripEncounterType.RoyalFleetEncounter
			}
		};
	}

	// Token: 0x17000D8B RID: 3467
	// (get) Token: 0x060043E5 RID: 17381 RVA: 0x001B93BE File Offset: 0x001B77BE
	public override DestinationType DestinationType
	{
		get
		{
			return DestinationType.NorthernSea;
		}
	}
}
