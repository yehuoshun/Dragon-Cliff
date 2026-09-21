using System;
using System.Collections.Generic;

// Token: 0x02000992 RID: 2450
[Serializable]
public class SpiritualHeartTownEffect : TownEffectBase
{
	// Token: 0x06004316 RID: 17174 RVA: 0x001B5B65 File Offset: 0x001B3F65
	public SpiritualHeartTownEffect(int lastingNumberOfDays, int startingOnGameDays, double chance, double reductionRate, int damageSeconds) : base(new int?(lastingNumberOfDays), startingOnGameDays)
	{
		this.Chance = chance;
		this.ReductionRate = reductionRate;
		this.DamageSeconds = damageSeconds;
	}

	// Token: 0x17000D44 RID: 3396
	// (get) Token: 0x06004317 RID: 17175 RVA: 0x001B5B8B File Offset: 0x001B3F8B
	public override TownEffectType Type
	{
		get
		{
			return TownEffectType.SpiritualHeartEffect;
		}
	}

	// Token: 0x06004318 RID: 17176 RVA: 0x001B5B90 File Offset: 0x001B3F90
	public override List<ISpecialEffectDataLoad> GetPlayerEffectsForAdventure()
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SpiritualHeartData
			{
				IsStar = false,
				Chance = this.Chance,
				ReductionRate = this.ReductionRate,
				DamageSeconds = this.DamageSeconds
			}
		};
	}

	// Token: 0x06004319 RID: 17177 RVA: 0x001B5BDC File Offset: 0x001B3FDC
	public override bool CanbeMergedWith(TownEffectBase effect)
	{
		return effect is SpiritualHeartTownEffect;
	}

	// Token: 0x0600431A RID: 17178 RVA: 0x001B5BE8 File Offset: 0x001B3FE8
	public override void Merge(TownEffectBase effect)
	{
		SpiritualHeartTownEffect spiritualHeartTownEffect = effect as SpiritualHeartTownEffect;
		if (spiritualHeartTownEffect.Chance > this.Chance)
		{
			this.Chance = spiritualHeartTownEffect.Chance;
		}
		if (spiritualHeartTownEffect.DamageSeconds > this.DamageSeconds)
		{
			this.DamageSeconds = spiritualHeartTownEffect.DamageSeconds;
		}
		if (spiritualHeartTownEffect.ReductionRate > this.ReductionRate)
		{
			this.ReductionRate = spiritualHeartTownEffect.ReductionRate;
		}
		if (this.LastingNumberOfDays != null)
		{
			int? lastingNumberOfDays = this.LastingNumberOfDays;
			bool flag = lastingNumberOfDays != null;
			int? lastingNumberOfDays2 = spiritualHeartTownEffect.LastingNumberOfDays;
			this.LastingNumberOfDays = ((!(flag & lastingNumberOfDays2 != null)) ? null : new int?(lastingNumberOfDays.GetValueOrDefault() + lastingNumberOfDays2.GetValueOrDefault()));
			if (this.LastingNumberOfDays > 12)
			{
				this.LastingNumberOfDays = new int?(12);
			}
		}
	}

	// Token: 0x0600431B RID: 17179 RVA: 0x001B5CE0 File Offset: 0x001B40E0
	public override Description GetDescription()
	{
		Description localization = base.GetLocalization();
		localization.Details1 = localization.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{seconds}", this.DamageSeconds.ToString()).Replace("{rate}", this.ReductionRate.ToExpressionMultiply100());
		return localization;
	}

	// Token: 0x040032FC RID: 13052
	public double Chance;

	// Token: 0x040032FD RID: 13053
	public double ReductionRate;

	// Token: 0x040032FE RID: 13054
	public int DamageSeconds;
}
