using System;
using System.Collections.Generic;

// Token: 0x02000997 RID: 2455
[Serializable]
public class WarmFlowTownEffect : TownEffectBase
{
	// Token: 0x06004333 RID: 17203 RVA: 0x001B60BE File Offset: 0x001B44BE
	public WarmFlowTownEffect(int lastingNumberOfDays, int startingOnGameDays, int maxSeconds, int healSeconds, double healRate) : base(new int?(lastingNumberOfDays), startingOnGameDays)
	{
		this.MaxSeconds = maxSeconds;
		this.HealSeconds = healSeconds;
		this.HealRate = healRate;
	}

	// Token: 0x17000D48 RID: 3400
	// (get) Token: 0x06004334 RID: 17204 RVA: 0x001B60E4 File Offset: 0x001B44E4
	public override TownEffectType Type
	{
		get
		{
			return TownEffectType.WarmFlowEffect;
		}
	}

	// Token: 0x06004335 RID: 17205 RVA: 0x001B60E8 File Offset: 0x001B44E8
	public override List<ISpecialEffectDataLoad> GetPlayerEffectsForAdventure()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new WarmFlowData
			{
				IsStar = false,
				HealRate = this.HealRate,
				Counter = 0,
				HealSeconds = this.HealSeconds,
				MaxSeconds = this.MaxSeconds
			}
		};
	}

	// Token: 0x06004336 RID: 17206 RVA: 0x001B613B File Offset: 0x001B453B
	public override bool CanbeMergedWith(TownEffectBase effect)
	{
		return effect is WarmFlowTownEffect;
	}

	// Token: 0x06004337 RID: 17207 RVA: 0x001B6148 File Offset: 0x001B4548
	public override void Merge(TownEffectBase effect)
	{
		WarmFlowTownEffect warmFlowTownEffect = effect as WarmFlowTownEffect;
		if (warmFlowTownEffect.HealRate > this.HealRate)
		{
			this.HealRate = warmFlowTownEffect.HealRate;
		}
		if (warmFlowTownEffect.HealSeconds > this.HealSeconds)
		{
			this.HealSeconds = warmFlowTownEffect.HealSeconds;
		}
		if (warmFlowTownEffect.MaxSeconds > this.MaxSeconds)
		{
			this.MaxSeconds = warmFlowTownEffect.MaxSeconds;
		}
		if (this.LastingNumberOfDays != null)
		{
			int? lastingNumberOfDays = this.LastingNumberOfDays;
			bool flag = lastingNumberOfDays != null;
			int? lastingNumberOfDays2 = warmFlowTownEffect.LastingNumberOfDays;
			this.LastingNumberOfDays = ((!(flag & lastingNumberOfDays2 != null)) ? null : new int?(lastingNumberOfDays.GetValueOrDefault() + lastingNumberOfDays2.GetValueOrDefault()));
			if (this.LastingNumberOfDays > 12)
			{
				this.LastingNumberOfDays = new int?(12);
			}
		}
	}

	// Token: 0x06004338 RID: 17208 RVA: 0x001B6240 File Offset: 0x001B4640
	public override Description GetDescription()
	{
		Description localization = base.GetLocalization();
		localization.Details1 = localization.Details1.Replace("{rate}", this.HealRate.ToExpressionMultiply100()).Replace("{seconds}", this.HealSeconds.ToString()).Replace("{max}", this.MaxSeconds.ToString());
		return localization;
	}

	// Token: 0x04003313 RID: 13075
	public int MaxSeconds;

	// Token: 0x04003314 RID: 13076
	public int HealSeconds;

	// Token: 0x04003315 RID: 13077
	public double HealRate;
}
