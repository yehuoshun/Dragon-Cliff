using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020009A4 RID: 2468
public abstract class DestinationProcessBase
{
	// Token: 0x060043DD RID: 17373 RVA: 0x001B9247 File Offset: 0x001B7647
	protected DestinationProcessBase()
	{
	}

	// Token: 0x060043DE RID: 17374
	public abstract List<TripEncounterPresence> GetEncounterPresences(TripRecord record);

	// Token: 0x17000D89 RID: 3465
	// (get) Token: 0x060043DF RID: 17375
	public abstract DestinationType DestinationType { get; }

	// Token: 0x17000D8A RID: 3466
	// (get) Token: 0x060043E0 RID: 17376 RVA: 0x001B924F File Offset: 0x001B764F
	public virtual int DurabilityCost
	{
		get
		{
			return 3;
		}
	}

	// Token: 0x060043E1 RID: 17377 RVA: 0x001B9254 File Offset: 0x001B7654
	public void Process(TripRecord record)
	{
		double num = Math.Floor(record.CurrentOnMiles / DestinationProcessBase.EncounterRate);
		record.CurrentOnMiles += (double)Time.deltaTime * record.Speed / 60.0;
		record.CurrentHealth -= (double)Time.deltaTime / 60.0;
		double num2 = Math.Floor(record.CurrentOnMiles / DestinationProcessBase.EncounterRate);
		if (num2 > num)
		{
			TripEncounterProcess process = this.GetEncounterPresences(record).WeightedRandomSelect<TripEncounterPresence>().TripEncounterType.GetProcess();
			record.AddEncounter(process.GenerateEncounterFor(record));
		}
		if (record.CurrentHealth <= 0.0)
		{
			record.Completed = true;
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.JourneyCompleted, record);
		}
	}

	// Token: 0x060043E2 RID: 17378 RVA: 0x001B931E File Offset: 0x001B771E
	// Note: this type is marked as 'beforefieldinit'.
	static DestinationProcessBase()
	{
	}

	// Token: 0x04003344 RID: 13124
	public static double EncounterRate = 3.0;
}
