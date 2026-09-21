using System;
using System.Collections.Generic;

// Token: 0x020009B7 RID: 2487
[Serializable]
public class NormalEncounter : ITripeEncounter
{
	// Token: 0x06004420 RID: 17440 RVA: 0x001BA0F0 File Offset: 0x001B84F0
	public NormalEncounter()
	{
	}

	// Token: 0x06004421 RID: 17441 RVA: 0x001BA0F8 File Offset: 0x001B84F8
	public TripEncounterType GetEncounterType()
	{
		return this.Type;
	}

	// Token: 0x06004422 RID: 17442 RVA: 0x001BA100 File Offset: 0x001B8500
	public TripEncounterOutcomeType GetEncounterOutcomeType()
	{
		return this.OutcomeType;
	}

	// Token: 0x06004423 RID: 17443 RVA: 0x001BA108 File Offset: 0x001B8508
	public List<ResourceUpdate> GetLoots()
	{
		return this.Loots;
	}

	// Token: 0x06004424 RID: 17444 RVA: 0x001BA110 File Offset: 0x001B8510
	public bool IsPositive()
	{
		return this.Positive;
	}

	// Token: 0x06004425 RID: 17445 RVA: 0x001BA118 File Offset: 0x001B8518
	public double TriggerOnMiles()
	{
		return this.OnMiles;
	}

	// Token: 0x0400337A RID: 13178
	public TripEncounterType Type;

	// Token: 0x0400337B RID: 13179
	public TripEncounterOutcomeType OutcomeType;

	// Token: 0x0400337C RID: 13180
	public List<ResourceUpdate> Loots;

	// Token: 0x0400337D RID: 13181
	public bool Positive;

	// Token: 0x0400337E RID: 13182
	public double LossLife;

	// Token: 0x0400337F RID: 13183
	public double OnMiles;
}
