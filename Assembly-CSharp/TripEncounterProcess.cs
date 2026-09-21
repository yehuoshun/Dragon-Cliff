using System;

// Token: 0x020009BD RID: 2493
public abstract class TripEncounterProcess
{
	// Token: 0x0600443B RID: 17467 RVA: 0x001B9CE6 File Offset: 0x001B80E6
	protected TripEncounterProcess()
	{
	}

	// Token: 0x0600443C RID: 17468 RVA: 0x001B9CEE File Offset: 0x001B80EE
	protected double GetChallengeMeanValueFor(JourneyContributeType type)
	{
		if (type == JourneyContributeType.BattleSkill)
		{
			return 65.0;
		}
		return 10.0;
	}

	// Token: 0x0600443D RID: 17469 RVA: 0x001B9D0A File Offset: 0x001B810A
	protected double GetChallengeDistanceIncrementValueFor(JourneyContributeType type)
	{
		if (type == JourneyContributeType.BattleSkill)
		{
			return 20.0;
		}
		return 8.0;
	}

	// Token: 0x0600443E RID: 17470 RVA: 0x001B9D28 File Offset: 0x001B8128
	public double GetRequiredTotalContributionValue(JourneyContributeType type, double miles)
	{
		if (miles <= 24.0)
		{
			return this.GetChallengeMeanValueFor(type);
		}
		if (miles <= 48.0)
		{
			return this.GetChallengeMeanValueFor(type) + this.GetChallengeDistanceIncrementValueFor(type);
		}
		return this.GetChallengeMeanValueFor(type) + 3.0 * this.GetChallengeDistanceIncrementValueFor(type);
	}

	// Token: 0x0600443F RID: 17471 RVA: 0x001B9D84 File Offset: 0x001B8184
	protected double GetDistanceGrantedBonusRatio(double distance)
	{
		if (distance <= 24.0)
		{
			return 1.0;
		}
		if (distance <= 48.0)
		{
			return 2.0;
		}
		return 3.0;
	}

	// Token: 0x17000D9A RID: 3482
	// (get) Token: 0x06004440 RID: 17472
	public abstract TripEncounterType Type { get; }

	// Token: 0x06004441 RID: 17473
	public abstract ITripeEncounter GenerateEncounterFor(TripRecord trip);
}
