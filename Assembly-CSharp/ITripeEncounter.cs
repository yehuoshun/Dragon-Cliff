using System;
using System.Collections.Generic;

// Token: 0x020009B2 RID: 2482
public interface ITripeEncounter
{
	// Token: 0x0600440D RID: 17421
	TripEncounterType GetEncounterType();

	// Token: 0x0600440E RID: 17422
	TripEncounterOutcomeType GetEncounterOutcomeType();

	// Token: 0x0600440F RID: 17423
	List<ResourceUpdate> GetLoots();

	// Token: 0x06004410 RID: 17424
	bool IsPositive();

	// Token: 0x06004411 RID: 17425
	double TriggerOnMiles();
}
