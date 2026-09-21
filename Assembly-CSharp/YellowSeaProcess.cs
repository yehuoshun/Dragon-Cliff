using System;
using System.Collections.Generic;

// Token: 0x020009A8 RID: 2472
public class YellowSeaProcess : DestinationProcessBase
{
	// Token: 0x060043E9 RID: 17385 RVA: 0x001B946E File Offset: 0x001B786E
	public YellowSeaProcess()
	{
	}

	// Token: 0x060043EA RID: 17386 RVA: 0x001B9478 File Offset: 0x001B7878
	public override List<TripEncounterPresence> GetEncounterPresences(TripRecord record)
	{
		return new List<TripEncounterPresence>
		{
			new TripEncounterPresence
			{
				Presence = 300,
				TripEncounterType = TripEncounterType.BusinessEncounter
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
				Presence = 3,
				TripEncounterType = TripEncounterType.RoyalFleetEncounter
			}
		};
	}

	// Token: 0x17000D8D RID: 3469
	// (get) Token: 0x060043EB RID: 17387 RVA: 0x001B94FE File Offset: 0x001B78FE
	public override DestinationType DestinationType
	{
		get
		{
			return DestinationType.YellowSea;
		}
	}
}
