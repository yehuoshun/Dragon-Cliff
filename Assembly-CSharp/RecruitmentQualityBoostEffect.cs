using System;

// Token: 0x02000991 RID: 2449
[Serializable]
public class RecruitmentQualityBoostEffect : TownEffectBase
{
	// Token: 0x06004310 RID: 17168 RVA: 0x001B5AC4 File Offset: 0x001B3EC4
	public RecruitmentQualityBoostEffect(int? lastingNumberOfDays, int startingOnGameDays, double boostRate, int numberOfTotalTriggers) : base(lastingNumberOfDays, startingOnGameDays)
	{
		this.BoostRate = boostRate;
		this.NumberOfTotalTriggers = numberOfTotalTriggers;
	}

	// Token: 0x17000D43 RID: 3395
	// (get) Token: 0x06004311 RID: 17169 RVA: 0x001B5ADD File Offset: 0x001B3EDD
	public override TownEffectType Type
	{
		get
		{
			return TownEffectType.RecruitmentQualityBoost;
		}
	}

	// Token: 0x06004312 RID: 17170 RVA: 0x001B5AE0 File Offset: 0x001B3EE0
	public override bool CanbeMergedWith(TownEffectBase effect)
	{
		return false;
	}

	// Token: 0x06004313 RID: 17171 RVA: 0x001B5AE3 File Offset: 0x001B3EE3
	public override void Merge(TownEffectBase effect)
	{
	}

	// Token: 0x06004314 RID: 17172 RVA: 0x001B5AE8 File Offset: 0x001B3EE8
	public override Description GetDescription()
	{
		Description localization = base.GetLocalization();
		localization.Details1 = localization.Details1.Replace("{rate}", this.BoostRate.ToExpressionMultiply100()).Replace("{total}", this.NumberOfTotalTriggers.ToString());
		return localization;
	}

	// Token: 0x06004315 RID: 17173 RVA: 0x001B5B39 File Offset: 0x001B3F39
	public void RemoveTrigger(int count)
	{
		this.NumberOfTotalTriggers -= count;
		if (this.NumberOfTotalTriggers <= 0)
		{
			GameWorld.instance.PlayerProfile.RemoveTownEffect(this);
		}
	}

	// Token: 0x040032FA RID: 13050
	public double BoostRate;

	// Token: 0x040032FB RID: 13051
	public int NumberOfTotalTriggers;
}
