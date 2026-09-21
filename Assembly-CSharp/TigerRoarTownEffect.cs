using System;
using System.Collections.Generic;

// Token: 0x02000994 RID: 2452
[Serializable]
public class TigerRoarTownEffect : TownEffectBase
{
	// Token: 0x06004322 RID: 17186 RVA: 0x001B5EDD File Offset: 0x001B42DD
	public TigerRoarTownEffect(int lastingNumberOfDays, int startingOnGameDays, double chance, double reductionRate, int lastingSeconds) : base(new int?(lastingNumberOfDays), startingOnGameDays)
	{
		this.Chance = chance;
		this.ReductionRate = reductionRate;
		this.LastingSeconds = lastingSeconds;
	}

	// Token: 0x17000D46 RID: 3398
	// (get) Token: 0x06004323 RID: 17187 RVA: 0x001B5F03 File Offset: 0x001B4303
	public override TownEffectType Type
	{
		get
		{
			return TownEffectType.TigerRoarEffect;
		}
	}

	// Token: 0x06004324 RID: 17188 RVA: 0x001B5F08 File Offset: 0x001B4308
	public override List<ISpecialEffectDataLoad> GetPlayerEffectsForAdventure()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new TigerRoarData
			{
				IsStar = false,
				Chance = this.Chance,
				LastingSeconds = this.LastingSeconds,
				ReductionRate = this.ReductionRate
			}
		};
	}

	// Token: 0x06004325 RID: 17189 RVA: 0x001B5F54 File Offset: 0x001B4354
	public override bool CanbeMergedWith(TownEffectBase effect)
	{
		return effect is TigerRoarTownEffect;
	}

	// Token: 0x06004326 RID: 17190 RVA: 0x001B5F60 File Offset: 0x001B4360
	public override void Merge(TownEffectBase effect)
	{
		TigerRoarTownEffect tigerRoarTownEffect = effect as TigerRoarTownEffect;
		if (tigerRoarTownEffect.Chance > this.Chance)
		{
			this.Chance = tigerRoarTownEffect.Chance;
		}
		if (tigerRoarTownEffect.LastingSeconds > this.LastingSeconds)
		{
			this.LastingSeconds = tigerRoarTownEffect.LastingSeconds;
		}
		if (tigerRoarTownEffect.ReductionRate > this.ReductionRate)
		{
			this.ReductionRate = tigerRoarTownEffect.ReductionRate;
		}
		if (this.LastingNumberOfDays != null)
		{
			int? lastingNumberOfDays = this.LastingNumberOfDays;
			bool flag = lastingNumberOfDays != null;
			int? lastingNumberOfDays2 = tigerRoarTownEffect.LastingNumberOfDays;
			this.LastingNumberOfDays = ((!(flag & lastingNumberOfDays2 != null)) ? null : new int?(lastingNumberOfDays.GetValueOrDefault() + lastingNumberOfDays2.GetValueOrDefault()));
			if (this.LastingNumberOfDays > 12)
			{
				this.LastingNumberOfDays = new int?(12);
			}
		}
	}

	// Token: 0x06004327 RID: 17191 RVA: 0x001B6058 File Offset: 0x001B4458
	public override Description GetDescription()
	{
		Description localization = base.GetLocalization();
		localization.Details1 = localization.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{seconds}", this.LastingSeconds.ToString()).Replace("{rate}", this.ReductionRate.ToExpressionMultiply100());
		return localization;
	}

	// Token: 0x04003301 RID: 13057
	public double Chance;

	// Token: 0x04003302 RID: 13058
	public double ReductionRate;

	// Token: 0x04003303 RID: 13059
	public int LastingSeconds;
}
